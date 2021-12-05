using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
namespace AlarmPreRecording
{

  public partial class Videoaufnahme : Form
  {
    public Videoaufnahme()
    {

      InitializeComponent();
      Datenbaustein.newFileName = new string[(int)Einstellungen.Kameraanzahl];
      for (int i = 0; i < (int)Einstellungen.Kameraanzahl; i++)
        Datenbaustein.newFileName.SetValue("000000_00-00-00", i);
      //sicherstellen, dass null ist
      Datenbaustein.Videowird_wurde_erstellt = null;
      Datenbaustein.Videowird_wurde_erstellt = new bool[(int)Einstellungen.Kameraanzahl, 2];

      Einstellungen.ViewVideoAufnahme = this;
      Einstellungen.ViewVideoAufnahme.Show();
      Datenbaustein.initialize();
      //Wenn bereits Einstellungen in Videoaufnahme vorgenommen wurden, ist die Kamera bereits verbunden
      if (VideoaufnahmeWasAlreadyOpen)
      {
        if (KameraXIsConnected == null)//wenn Kameraanzahl geändert wurde, wird array auf null gesetzt
        {
          KameraXIsConnected = new bool[(int)Einstellungen.Kameraanzahl]; //Neue Variable anlegen, Verbindungsstatus Kamera
          return;
        }

        //Schaut, ob jede Kamera verbunden ist, wenn ja werden VorNachlaufzeiten übertragen
        for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
        {
          if (KameraXIsConnected[i] == false)
          {
            Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Es wurden noch keine Verbindung zu den Kameras " +
              "hergestellt. Die Zeiten konnten noch nicht übertragen werden.", System.Drawing.Color.Yellow);
            return;
          }
        }
        //Kameras sind bereits verbunden - Vor NachLaufzeiten neu übertragen
        CameraSendFiles.alleVorNachZeitensenden();
        CallKamerastatus();
      }
      else
      {
        //Neue Variable anlegen, Verbindungsstatus Kamera
        KameraXIsConnected = new bool[(int)Einstellungen.Kameraanzahl];
        if (KameraVerbindung.KameraIPadressen == null)
        {
          //IP-Adressengröße anlegen
          KameraVerbindung.KameraIPadressen = new string[(int)Einstellungen.Kameraanzahl, 3];
          for (int row = 0; row < Einstellungen.Kameraanzahl; row++)
          {
            for (int column = 0; column < 3; column++)
            {
              KameraVerbindung.KameraIPadressen[row, column] = "";
            }
          }
        }
        CallConnection();
      }
    }
    public static bool CheckifKameraisConn()
    {
      if (KameraXIsConnected != null)
      {
        if (KameraXIsConnected.GetLength(0) > 0)
        {//Schaut, ob jede Kamera verbunden ist, wenn ja werden VorNachlaufzeiten übertragen
          for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
          {
            if (KameraXIsConnected[i] == false)
            {

              return false;
            }
            else//Kamera sollte verbunden sein
            {
              if (!KameraVerbindung.FileExists(i, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/started.txt"))
              {
                //Wenn man nicht überprüfen konnte ob ein File auf dem Raspberry existiert, ist die Verbindung mit großer WSK unterbrochen
                KameraXIsConnected[i] = false;
                return false;
              }
            }
          }
          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        return false;
      }
    }
    //private Variable - Wenn videoaufnahme geöffnet und gechlossen wurde, wird diese Variable gesetzt. Wenn Variable gesetzt wurde,
    //werden die Vor- Nachlaufzeiten auf Änderungen überprüft
    private static bool VideoaufnahmeWasAlreadyOpen = false;
    //zählt, wie oft ein Fenster geöffnet wurde
    public static decimal KameraCntWindowsForm = 0;
    private Form CurrentPanel { get; set; }
    //Standardwert für Elemente ist false - gibt an, ob Kamera X (Index Array) verbunden ist 
    public static bool[] KameraXIsConnected = { };

    public static void ResetData()
    {
      KameraCntWindowsForm = 0;
      KameraXIsConnected = null;

    }
    private void Videoaufnahme_FormClosing(object sender, FormClosingEventArgs e)
    {
      //Überprüfen ob kein Video downgeloaded wird
      for (int kameracnt = 0; kameracnt < (int)Einstellungen.Kameraanzahl; kameracnt++)
      {

        if (Datenbaustein.Videowird_wurde_erstellt[kameracnt, 0] == true || Datenbaustein.Videowird_wurde_erstellt[kameracnt, 1] == true)//Video wurde angefordert und fertiggestellt
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Schließen nicht möglich. Video wird erstellt", System.Drawing.Color.Red);
          e.Cancel = true; //bricht Event Schließen ab
          return;
        }
      }

      //alles wird geschlossen
      for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
      {
        if (Videoaufnahme.KameraXIsConnected != null)
        {

          if (Videoaufnahme.KameraXIsConnected[i] == true)
            KameraVerbindung.Disconnect(i);
        }
        ResetData();
        Kamerastatus.TimerRefreshStatus.Dispose(); //Timer disponieren

      }
      Einstellungen.RefToMainForm.Close();
      //Kamera und SPS Verbindung werden im Main-Programm geschlossen
    }

    private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int kameracnt = 0; kameracnt < (int)Einstellungen.Kameraanzahl; kameracnt++)
      {

        if (Datenbaustein.Videowird_wurde_erstellt[kameracnt, 0] == true || Datenbaustein.Videowird_wurde_erstellt[kameracnt, 1] == true)//Video wurde angfordert und fertiggestellt
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Schließen nicht möglich. Video wird erstellt", System.Drawing.Color.Red);
          return;
        }
      }

      DialogResult dialogResult = MessageBox.Show("Wollen Sie zu den Alarm Pre-Recording Einstellungen zurückkehren? Die Kameraaufzeichnung wird unterbrochen" +
    " und bei Änderungen der Vor und Nachlaufzeiten werden die Einstellungen automatisch übertragen und das System automatisch neu gestartet.[Nein]\nSonst, werden alle" +
    " Programmprozesse geschlossen.[Ja]", "Schließen", MessageBoxButtons.YesNo);
      if (dialogResult == DialogResult.No)
      {//Wenn man zurück zu den Einstellungen möchte, werden die Timer gestoppt, die Verbindung zur Kamera
       //existiert noch
       //und die Einstellungen werden angezeigt
        KameraCntWindowsForm = 0;
        //Kameraverbindung muss nicht getrennt werden, weil die Timer gestoppt sind und keine weiteren 
        //Dateien übertragen werden können     
        VideoaufnahmeWasAlreadyOpen = true;
        Einstellungen.ViewVideoAufnahme.Hide();
        AlarmPreRecMain.TimerClearMeldungszeile.Start();
        Einstellungen.RefToMainForm.Show();
        Datenbaustein.StopTimers();
        //letztverwendetes Panel aus dem RAM und aus dem Azeigemodus entfernen
        if (CurrentPanel != null)
        {
          if (CurrentPanel.GetType().Name == "Kamerastatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen Timer gelöscht werden
          {
            Kamerastatus.TimerRefreshStatus.Stop();
          }
          Panel_Switch.Controls.Remove(CurrentPanel);
          CurrentPanel.Dispose();
        }

      }
      else if (dialogResult == DialogResult.Yes)
      {
        this.Close();
      }
    }

    private void ZurueckZuDenEinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Während laufender KameraAufnahme/Download können Einstellungen nicht eingesehen werden
      for (int kameracnt = 0; kameracnt < (int)Einstellungen.Kameraanzahl; kameracnt++)
      {

        if (Datenbaustein.Videowird_wurde_erstellt[kameracnt, 0] == true || Datenbaustein.Videowird_wurde_erstellt[kameracnt, 1] == true)//Video wurde angefordert und fertiggestellt
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Schließen nicht möglich. Video wird erstellt", System.Drawing.Color.Red);
          return;
        }
      }

      DialogResult dialogResult = MessageBox.Show("Es werden alle laufenden Kameraaufzeichnungen unterbrochen. Beim Wiedereinsteigen werden die neuen Zeiten" +
        " auf die Kamera übertragen. Falls dies nicht möglich ist, müssen sie manuell übertragen werden.", "Einstellungen", MessageBoxButtons.OKCancel);
      if (dialogResult == DialogResult.Cancel)
        return;
      //Wenn man zurück zu den Einstellungen möchte und die Kamera noch ein Video erstellt, darf man bis zu der Fertigstellung des Videos nicht zurück zu den Einstellungen
      //Keine Kamera darf ein Video erstellen
      for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
      {
        if (Datenbaustein.Videowird_wurde_erstellt[i, 0] == true || Datenbaustein.Videowird_wurde_erstellt[i, 1] == true)
        {
          changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Während ein Video erstellt wird können die Einstellungen nicht geöffnet werden", Color.Red);
          return;
        }
      }
      //Wenn man zurück zu den Einstellungen möchte, werden die Timer gestoppt, die Verbindung zur Kamera existiert noch
      //und die Einstellungen werden angezeigt
      KameraCntWindowsForm = 0;
      //Kameraverbindung muss nicht getrennt werden, weil die Timer gestoppt sind und keine weiteren Dateien übertragen werden können     
      VideoaufnahmeWasAlreadyOpen = true;
      AlarmPreRecMain.TimerClearMeldungszeile.Start();
      Einstellungen.ViewVideoAufnahme.Hide();
      Einstellungen.RefToMainForm.Show();
      Datenbaustein.StopTimers();
      //letztverwendetes Panel aus dem RAM und aus dem Anzeigemodus entfernen
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "Kamerastatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          Kamerastatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }

    }
    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {

      //Homepanel aufrufen
      //letztverwendetes Panel aus dem RAM und aus dem Anzeigemodus entfernen
      if (CurrentPanel != null)
      {

        Panel_Switch.Controls.Remove(CurrentPanel);
        if (CurrentPanel.GetType().Name == "Kamerastatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          Kamerastatus.TimerRefreshStatus.Stop();
          CurrentPanel = null;
        }
        else
        {
          //Wenn kein neues Panel hinzugefügt wird, bleibt der Typ Kamerastatus im Panel bestehen und wird nicht entfernt. Daher
          //wird CurrentPanel auf null gesetzt, was auch den Datentyp entfernt
          //Würde man CurrentPanel nochmal löschen - entsteht ein NullReferenceError
          CurrentPanel.Dispose(); //Dispose behält den Typ des vorigen Panels daher current= null
        }
        KameraCntWindowsForm = 0;
      }
      changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("", System.Drawing.Color.White);
      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Videoaufnahme";

    }
  
    public void CallConnection()
    {//Connection Form starten
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "Kamerastatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          Kamerastatus.TimerRefreshStatus.Stop();
        }

        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      CameraConnection CameraConnectionPanelForm = new CameraConnection();
      CameraConnectionPanelForm.TopLevel = false;
      //hier wird die WindowsForm CameraConnection als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(CameraConnectionPanelForm);
      CurrentPanel = CameraConnectionPanelForm;
      CameraConnectionPanelForm.Show();
      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Raspberry Pi Einstellungen";
    }
    public void CallSendFiles()
    {
      //Callsend Form starten
      KameraCntWindowsForm = 0;
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "Kamerastatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          Kamerastatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      CameraSendFiles CameraSendFilesPanelForm = new CameraSendFiles();
      CameraSendFilesPanelForm.TopLevel = false;
      //hier wird die WindowsForm CameraSendFiles als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(CameraSendFilesPanelForm);
      CurrentPanel = CameraSendFilesPanelForm;
      CameraSendFilesPanelForm.Show();
      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Senden der Dateien";
    }

    private void vorNachlaufzeitenFilesSendenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Schaut, ob jede Kamera verbunden ist, wenn ja werden VorNachlaufzeiten übertragen
      for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
      {
        if (KameraXIsConnected[i] == false)
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bitte geben Sie zunächst Einstellungen für den Raspberry Pi an", System.Drawing.Color.Red);
          return;
        }
      }
      CallSendFiles();
    }

    private void rasperryEinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //öffnen der RaspberryEinstellungen - Verbindung
      CallConnection();
    }

    private Kamerastatus KameraStatusPanelForm;
    public void CallKamerastatus()
    {

      //Kamerastatus anzeigen lassen
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "Kamerastatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          Kamerastatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      KameraStatusPanelForm = new Kamerastatus();
      KameraStatusPanelForm.TopLevel = false;
      //hier wird die WindowsForm KameraStatus als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(KameraStatusPanelForm);
      CurrentPanel = KameraStatusPanelForm;
      KameraStatusPanelForm.Show();
      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Kamera Status";

    }
    private void kamerastatusToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CallKamerastatus();
    }
    private void videoausgabeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "Kamerastatus") //Check, ob das letzte Panel Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          Kamerastatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      Videoauswertung VideoauswertungPanelForm = new Videoauswertung();
      VideoauswertungPanelForm.TopLevel = false;

      //hier wird die WindowsForm Videoauswertung als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(VideoauswertungPanelForm);
      CurrentPanel = VideoauswertungPanelForm;
      VideoauswertungPanelForm.Show();

      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Videoausgabe";

    }
    //Erstellen des Delegate Handlers - rekursive Methode
    delegate void StringArgReturningVoidDelegate(string currStatus, Color colourforTxt);
    public void changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme(string currStatus, Color colourforTxt)
    {
      //Abfrage, ob Controll Element aktiviert werden muss
      if (this.CurrentWorkStatus_Videoaufnahme.InvokeRequired)
      {
        //neuer Delegat erstellt und die Methode mit diesem Delegat aufgerufen 
        StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(
          changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme);
        this.Invoke(d, new object[] { currStatus, colourforTxt });
      }
      else
      {
        //Kein Invoke benötigt, oder durch Delegat bereits aufgerufen
        CurrentWorkStatus_Videoaufnahme.Text = currStatus;
        CurrentWorkStatus_Videoaufnahme.BackColor = colourforTxt;
      }
    }

    private void ClearMeldungsfenster_Videoaufnahme_Click(object sender, EventArgs e)
    {
      if (this.CurrentWorkStatus_Videoaufnahme.InvokeRequired)
      {
        StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme);
        this.Invoke(d, new object[] { });
      }
      else
      {
        CurrentWorkStatus_Videoaufnahme.Text = "";
        CurrentWorkStatus_Videoaufnahme.BackColor = Color.White;
      }
    }

    private void CurrentWorkStatus_Videoaufnahme_TextChanged(object sender, EventArgs e)
    {

    }
  }
}

