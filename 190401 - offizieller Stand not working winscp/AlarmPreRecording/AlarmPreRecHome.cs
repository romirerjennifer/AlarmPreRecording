using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

using System.Timers;

using System.Runtime.InteropServices; //Um den Paramter optional zu machen 

namespace AlarmPreRecording
{
  public partial class AlarmPreRecMain : Form
  {
    public static System.Timers.Timer TimerClearMeldungszeile = new System.Timers.Timer();

    public AlarmPreRecMain()
    {

      InitializeComponent();
      //Wenn Timer durch andere Form gestoppt wurde, ist der Timer nicht mehr enabled - daher ...
      if (!TimerClearMeldungszeile.Enabled)
      {
        TimerClearMeldungszeile.Elapsed += new ElapsedEventHandler(T_changeMeldungszeile);
        TimerClearMeldungszeile.Interval = 10000; //alle 10s die Meldungszeile zu löschen
        TimerClearMeldungszeile.Start(); //wird auch gestoppt und deaktiviert
      }

      //Menustrips deaktivieren, wenn man sie noch nicht erreichen darf.
      enableKameraCNT(false);
      enableVorNachLauf(false);
      enableDB(false);
      enableWarnung(false);
      Einstellungen.RefToMainForm = this;
    }
    public static void T_changeMeldungszeile(object sender, EventArgs e)
    {
      Einstellungen.RefToMainForm.ClearMeldungsfenster_Click(sender, e);
    }
    private Form CurrentPanel { get; set; }
    public static string projektFolderPath = null;

    //##################HOMEPANEL- PanelSwitching##################################
    //Öffnen des Home Panels mittels Menübar-Aufrufes
    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {

      //letztverwendetes Panel aus dem RAM und aus dem Azeigemodus entfernen
      if (CurrentPanel != null)
      {
        Panel_Switch.Controls.Remove(CurrentPanel);
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
          CurrentPanel = null;
        }
        else
        {
          //Wenn kein neues Panel hinzugefügt wird, bleibt der Typ Kamerastatus im Panel bestehen und wird nicht entfernt. Daher
          //wird CurrentPanel auf null gesetzt, was auch den Datentyp entfernt
          //Würde man CurrentPanel nochmal löschen - entsteht ein NullReferenceError
          CurrentPanel.Dispose(); //Dispose behält den Typ des vorigen Panels daher current= null
        }
      }
      changeCurrentWorkStatus_Meldungsfeld("", Color.White);
      if (projektFolderPath == null)
        this.Text = "Alarm Pre-Recording";
      else
        this.Text = projektFolderPath + "  ||   Alarm Pre-Recording";

    }
    //Öffnen des Kamerawarnungpanels
    public void kamerazuweisungWarnungenToolStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {
      if (Einstellungen.DBBitzeichenfolge == null)
      {
        changeCurrentWorkStatus_Meldungsfeld("Kein Meldungsbaustein gefunden. Erstellen Sie ihn erneut.", Color.Red);

        return;
      }

      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus")
        //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      //Neue Instanz der Form erstellen
      KameraWarnung KameraMeldungPanelForm = new KameraWarnung();
      KameraMeldungPanelForm.TopLevel = false;
      //hier wird die WindowsForm KameraMeldung als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(KameraMeldungPanelForm);
      CurrentPanel = KameraMeldungPanelForm;
      KameraMeldungPanelForm.Show();
      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Kamerazuweisung Meldung";

    }
    //Öffnen des Kameraanzahlpanels
    public void anzahlToolStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {

      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      Kameraanzahl KameraanzahlPanelForm = new Kameraanzahl();
      KameraanzahlPanelForm.TopLevel = false;
      //hier wird die WindowsForm Kameraanzahl als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(KameraanzahlPanelForm);
      CurrentPanel = KameraanzahlPanelForm;
      KameraanzahlPanelForm.Show();
      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Kameraanzahl";
    }

    //Öffnen des Kameravorlaufpanels
    public void vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      KameraVorNachLauf VorNachLaufPanelForm = new KameraVorNachLauf();
      VorNachLaufPanelForm.TopLevel = false;
      //hier wird die WindowsForm VorNachLauf als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(VorNachLaufPanelForm);
      CurrentPanel = VorNachLaufPanelForm;
      VorNachLaufPanelForm.Show();

      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   Kamera Vor- und Nachlaufzeiten";
    }
    //Öffnen des Videoauswertungpanels
    public void videoauswertungToolStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
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
      if (projektFolderPath == null)
        this.Text = "Videoausgabe";
      else
        this.Text = projektFolderPath + "  ||   Videoausgabe";
    }
    //Öffnen des Projekterstellenpanels
    public void projektErstellenToolStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {//letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      Projekt_erstellen Projekt_erstellenPanelForm = new Projekt_erstellen();
      Projekt_erstellenPanelForm.TopLevel = false;
      Panel_Switch.Controls.Add(Projekt_erstellenPanelForm);
      CurrentPanel = Projekt_erstellenPanelForm;
      Projekt_erstellenPanelForm.Show();

      if (projektFolderPath == null)
        this.Text = "Projekt erstellen";
      else
        this.Text = projektFolderPath + "  ||   Projekt erstellen";
    }
    //Öffnen des Projektladenpanels
    public void projektLadenToolStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      Projekt_laden Projekt_ladenPanelForm = new Projekt_laden();
      Projekt_ladenPanelForm.TopLevel = false;
      Panel_Switch.Controls.Add(Projekt_ladenPanelForm);
      CurrentPanel = Projekt_ladenPanelForm;
      Projekt_ladenPanelForm.Show();
      if (projektFolderPath == null)
        this.Text = "Projekt laden";
      else
        this.Text = projektFolderPath + "  ||   Projekt laden";
    }

    public void sPSVerbindungStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {
      try
      {
        //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
        if (CurrentPanel != null)
        {
          if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
          {
            HauptprogrammStatus.TimerRefreshStatus.Stop();
          }
          Panel_Switch.Controls.Remove(CurrentPanel);
          CurrentPanel.Dispose();
        }
        SPSConnection SPSConnectionPanelForm = new SPSConnection();
        SPSConnectionPanelForm.TopLevel = false;
        Panel_Switch.Controls.Add(SPSConnectionPanelForm);
        CurrentPanel = SPSConnectionPanelForm;
        SPSConnectionPanelForm.Show();

        if (projektFolderPath == null)
          this.Text = "SPS-Verbindung";
        else
          this.Text = projektFolderPath + "  ||   SPS-Verbindung";
      }
      catch
      {
        changeCurrentWorkStatus_Meldungsfeld("AGLINK4 Lizenzen konnten nicht gefunden werden", Color.Red);
      }
    }

    private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
    {


      this.Close();
    }
    //Öffnen der Datenbausteineinstellungen
    public void datenbausteineToolStripMenuItem_Click([Optional]object sender, [Optional] EventArgs e)
    {
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      DBBits DBBitsPanelForm = new DBBits();
      DBBitsPanelForm.TopLevel = false;
      //hier werden die WindowsForm DBBits als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(DBBitsPanelForm);
      CurrentPanel = DBBitsPanelForm;
      DBBitsPanelForm.Show();

      this.Text = AlarmPreRecMain.projektFolderPath + "   ||   DBBits";

    }

    public void videoaufnahmeStartenToolStripMenuItem_Click([Optional]object sender, [Optional]EventArgs e)
    {
      //Start der Videoaufnahme
      //Einstellungen- Form wird geschlossen und die Aufnahme läuft im Hintergrund
      //dort eigener Button um Videoaufnahme zu unterbrechen und Einstellungen wieder aufzurufen 
      if (AlarmPreRecMain.projektFolderPath == null)
      {
        changeCurrentWorkStatus_Meldungsfeld("Kein Projekt angegeben. Laden Sie ein bereits vorhandenes Projekt oder erstellen Sie ein neues.", Color.Red);
        return;
      }
      //Um sich mit der Kamera verbinden zu dürfen, müssen diese Einstellungen vorhanden sein
      if (Einstellungen.Kameraanzahl == 0 || Einstellungen.SPSVorNachLaufArray == (null) || 
        Einstellungen.SPSWarnungsEinstellungArray == (null))
      {
        changeCurrentWorkStatus_Meldungsfeld("Nicht alle benötigten Daten wurden angegeben.", Color.Red);
        return;
      }
      try
      {
        if (!SPSConnection.Ag_connection.Connected)
        {
          changeCurrentWorkStatus_Meldungsfeld("SPS nicht verbunden", Color.Red);
          return;
        }
      }
      catch (NullReferenceException)
      {
        changeCurrentWorkStatus_Meldungsfeld("SPS nicht verbunden", Color.Red);
        return;
      }
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      TimerClearMeldungszeile.Stop();
      this.Hide();

      Videoaufnahme Videoform = new Videoaufnahme();

    }

    private void anleitungToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("1) Anlegen eines neuen Projekt oder Laden eines bereits bestehenden.\n\n" +
                      "2) Anzahl der möglichen Kameras festlegen.\n\n" +
                      "3) Vor- und Nachlaufzeiten der einzelnen Kameras festlegen.\n\n" +
                      "4) Zu verwendende Datenbausteine angeben und Eintragen Meldungsnamen und Meldebits.\n\n" +
                      "5) Angeben, welche Kamera bei welcher Meldung reagieren soll. \n\n" +
                      "6) Verbindung zur SPS herstellen.\n\n" +
                      "7) Einstellungen für ALLE Kameras vornehmen. Vor-und Nachlaufzeiten senden.\n\n" +
                      "8) Sollten bereits Daten für den Raspberry Pi vorhanden sein, müssen nur Vor- und Nachlaufzeiten gesendet werden.", "Anleitung", MessageBoxButtons.OK);

    }

    private void infoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("ALarm Pre-recording\n" +
        "Dieses Projekt ist eine Diplomarbeit\nvon Veronika Stangl und Jennifer Romirer-Maierhofer.\n" +
        "Schüler der HTLuVa Pinkafeld\n\n©2018-2019" +
        "\n Im Auftrag des Unternehmens DAM", "Informationen", MessageBoxButtons.OK);
    }

    //*********************************************************************************************
    //Freigeben oder Deaktivieren der einzelnen Toolstripitems
    public void enableKameraCNT(bool setzenoderned)
    {
      anzahlToolStripMenuItem.Enabled = setzenoderned;
      HauptprogrammStatus.HauptprogStatusButtonEnabled[0] = setzenoderned;
    }
    public void enableVorNachLauf(bool setzenoderned)
    {
      vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem.Enabled = setzenoderned;

      HauptprogrammStatus.HauptprogStatusButtonEnabled[1] = setzenoderned;
    }
    public void enableWarnung(bool setzenoderned)
    {
      kamerazuweisungWarnungenToolStripMenuItem.Enabled = setzenoderned;

      HauptprogrammStatus.HauptprogStatusButtonEnabled[3] = setzenoderned;
    }
    public void enableDB(bool setzenoderned)
    {
      datenbausteineToolStripMenuItem.Enabled = setzenoderned;

      HauptprogrammStatus.HauptprogStatusButtonEnabled[2] = setzenoderned;
    }
    //Beim Schließen der Form müssen die Timer gestoppt werden
    private void AlarmPreRecMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      //Alle Verbindungen zu externen Geräten trennen
      SPSConnection.DisconnectSPS();
      if (Videoaufnahme.KameraXIsConnected != null)
      {
        if (Videoaufnahme.KameraXIsConnected.GetLength(0) > 0)
        {
          for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
          {

            if (Videoaufnahme.KameraXIsConnected[i] == true)
              KameraVerbindung.Disconnect(i);
          }
        }
      }
      TimerClearMeldungszeile.Dispose();
      HauptprogrammStatus.TimerRefreshStatus.Dispose();
      Datenbaustein.TimerCheckDB.Dispose();
      Datenbaustein.TimerCheckIFVideoWasProduced.Dispose();

    }

    private void Panel_Switch_Paint(object sender, PaintEventArgs e)
    {

    }


    public void changeCurrentWorkStatus_Meldungsfeld(string currStatus, Color colourforTxt)
    {
      CurrentWorkStatus.Text = currStatus;
      CurrentWorkStatus.BackColor = colourforTxt;
    }

    private void CurrentWorkStatus_TextChanged(object sender, EventArgs e)
    {

    }
    public void OpenhauptPrgrmStatus()
    {
      //letztes Panel aus dem RAM und dem Panel-Switch entfernen 
      if (CurrentPanel != null)
      {
        if (CurrentPanel.GetType().Name == "HauptprogrammStatus") //Check, ob das letzte Panel ein Kamerastatus Panel war - dann müssen die Timer gelöscht werden
        {
          HauptprogrammStatus.TimerRefreshStatus.Stop();
        }
        Panel_Switch.Controls.Remove(CurrentPanel);
        CurrentPanel.Dispose();
      }
      //Neue Instanz der Form erstellen
      HauptprogrammStatus HauptprogrammStatusPanelForm = new HauptprogrammStatus();
      HauptprogrammStatusPanelForm.TopLevel = false;
      //hier wird die WindowsForm HauptprogrammStatus als Control in das Panel_Switch 
      //Panel eingespeist und angezeigt
      Panel_Switch.Controls.Add(HauptprogrammStatusPanelForm);
      CurrentPanel = HauptprogrammStatusPanelForm;
      HauptprogrammStatusPanelForm.Show();
      if (projektFolderPath == null)
        this.Text = "Status";
      else
        this.Text = projektFolderPath + "  ||   Status";


    }

    //Erstellen des Delegate Handlers - rekursive Methode
    delegate void StringArgReturningVoidDelegate(object sender, EventArgs e);
    private void ClearMeldungsfenster_Click(object sender, EventArgs e)
    {
      //Abfrage, ob Controll Element aktiviert werden muss
      if (this.CurrentWorkStatus.InvokeRequired)
      {
        //neuer Delegat erstellt und die Methode mit diesem Delegat aufgerufen 
        StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(ClearMeldungsfenster_Click);
        this.Invoke(d, new object[] { sender, e });
      }
      else
      {

        CurrentWorkStatus.Text = "";
        CurrentWorkStatus.BackColor = Color.White;
      }
    }
    private void closeprogram_Click(object sender, EventArgs e)
    {

    }
    private void HauptprgrmStatus_Click(object sender, EventArgs e)
    {
      OpenhauptPrgrmStatus();
    }
  }
}

