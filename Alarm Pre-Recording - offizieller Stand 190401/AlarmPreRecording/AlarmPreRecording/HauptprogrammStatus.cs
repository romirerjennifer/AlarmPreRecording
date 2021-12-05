using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Runtime.InteropServices; //Um den Paramter optional zu machen 

namespace AlarmPreRecording
{
  public partial class HauptprogrammStatus : Form
  {
    public static System.Timers.Timer TimerRefreshStatus = new System.Timers.Timer();

    public HauptprogrammStatus()
    {
      InitializeComponent();
      startspskamer.Enabled = false;
      //Wenn Timer durch andere Form gestoppt wurde, ist der Timer nicht mehr enabled - daher ...
      if (!TimerRefreshStatus.Enabled)
      {
        TimerRefreshStatus.Elapsed += new ElapsedEventHandler(RepaintForm);
        TimerRefreshStatus.Interval = 20000; //alle 20 sec Check ob Video fertig geschrieben wurde
                                             //Timer starten lassen, wenn die Form neu initialisiert wird - neu aufgemacht
        TimerRefreshStatus.Start(); //wird auch gestoppt und deaktiviert
      }

    }

    private void HauptprogrmStatusDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == HauptprogrmStatusDataGrid.Columns[2].Index)
      {
        switch (e.RowIndex)
        {
          case 0:
            if(HauptprogStatusButtonEnabled[0])
              Einstellungen.RefToMainForm.anzahlToolStripMenuItem_Click();
            break;
          case 1:
            if (HauptprogStatusButtonEnabled[1])
              Einstellungen.RefToMainForm.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem_Click();
            break;
          case 2:
            if (HauptprogStatusButtonEnabled[2])
              Einstellungen.RefToMainForm.datenbausteineToolStripMenuItem_Click();
            break;
          case 3:
            if (HauptprogStatusButtonEnabled[3])
              Einstellungen.RefToMainForm.kamerazuweisungWarnungenToolStripMenuItem_Click();
            break;
          case 4:
           
              Einstellungen.RefToMainForm.sPSVerbindungStripMenuItem_Click();
            break;
          case 5:
              Einstellungen.RefToMainForm.videoaufnahmeStartenToolStripMenuItem_Click();
            break;
        }
      }
    }
    public static bool[] HauptprogStatusButtonEnabled= new bool[4];

    private void HauptprogrammStatus_Load(object sender, EventArgs e)
    {
      HauptprogrmStatusDataGrid.Rows.Add("Kameraanzahl", "");
      HauptprogrmStatusDataGrid.Rows.Add("Vor- und Nachlaufzeiten", "");
      HauptprogrmStatusDataGrid.Rows.Add("Datenbits für Meldungen", "");
      HauptprogrmStatusDataGrid.Rows.Add("Meldungszuweisungen", "");
      HauptprogrmStatusDataGrid.Rows.Add("SPS - Verbindung", "");
      HauptprogrmStatusDataGrid.Rows.Add("Kamera - Verbindung", "");
      refToHauptStatus = HauptprogrmStatusDataGrid;
      RepaintForm();
    }
    private static DataGridView refToHauptStatus;
    //[Optional] macht den Paramter optional, kann, muss aber nicht angegeben werden
    public void RepaintForm([Optional]object source, [Optional]ElapsedEventArgs e)
    {
      //load colour and text

      //Defaultaussehen der Zustände
      refToHauptStatus.Rows[0].Cells[1].Value = "0";
      refToHauptStatus.Rows[0].Cells[1].Style.BackColor = Color.Red;
      //wenn die Kameraanzahl eingestellt wurde, wird die jeweilige Farbe angezeigt
      if (Einstellungen.Kameraanzahl != 0)
      {

        refToHauptStatus.Rows[0].Cells[1].Value = Einstellungen.Kameraanzahl.ToString();
        refToHauptStatus.Rows[0].Cells[1].Style.BackColor = Color.LightGreen;
      }

      //default wert der Vor- und Nachlaufzeiten
      refToHauptStatus.Rows[1].Cells[1].Value = "keine vorhanden";
      refToHauptStatus.Rows[1].Cells[1].Style.BackColor = Color.Red;
      if (Einstellungen.SPSVorNachLaufArray != null)
      {
        if (Einstellungen.SPSVorNachLaufArray[0, 1] != "")
        {

          refToHauptStatus.Rows[1].Cells[1].Value = "eingestellt";
          refToHauptStatus.Rows[1].Cells[1].Style.BackColor = Color.LightGreen;
        }
      }
      //default wert der Datenbits
      refToHauptStatus.Rows[2].Cells[1].Value = "keine vorhanden";
      refToHauptStatus.Rows[2].Cells[1].Style.BackColor = Color.Red;
      if (Einstellungen.DBBitzeichenfolge != null)
      {
        if (Einstellungen.DBBitzeichenfolge[0, 1] != "")
        {

          refToHauptStatus.Rows[2].Cells[1].Value = "Aktiv";
          refToHauptStatus.Rows[2].Cells[1].Style.BackColor = Color.LightGreen;
        }
      }

      //default wert der Meldungszuweisungen
      refToHauptStatus.Rows[3].Cells[1].Value = "keine zugewiesen";
      refToHauptStatus.Rows[3].Cells[1].Style.BackColor = Color.Red;
      if (Einstellungen.SPSWarnungsEinstellungArray != null)
      {
        if (checkmeldungeniftrue())
        {

          refToHauptStatus.Rows[3].Cells[1].Value = "zugewiesen";
          refToHauptStatus.Rows[3].Cells[1].Style.BackColor = Color.LightGreen;
        }
      }

      //default wert der SPS Verbindung
      refToHauptStatus.Rows[4].Cells[1].Value = "nicht verbunden";
      refToHauptStatus.Rows[4].Cells[1].Style.BackColor = Color.Red;
      if (SPSConnection.CheckifConnected())
      {

        refToHauptStatus.Rows[4].Cells[1].Value = "verbunden";
        refToHauptStatus.Rows[4].Cells[1].Style.BackColor = Color.LightGreen;
      }

      //default wert der Kamera Verbindung
      refToHauptStatus.Rows[5].Cells[1].Value = "nicht verbunden";
      refToHauptStatus.Rows[5].Cells[1].Style.BackColor = Color.Red;
      if (Videoaufnahme.CheckifKameraisConn())
      {

        refToHauptStatus.Rows[5].Cells[1].Value = "verbunden";
        refToHauptStatus.Rows[5].Cells[1].Style.BackColor = Color.LightGreen;
      }



      //Buttonname laden
      refToHauptStatus.Rows[0].Cells[2].Value = "Kameraanzahl bearbeiten";
      refToHauptStatus.Rows[1].Cells[2].Value = "Vor-& Nachlaufzeiten bearbeiten";
      refToHauptStatus.Rows[2].Cells[2].Value = "Meldungsbits bearbeiten";
      refToHauptStatus.Rows[3].Cells[2].Value = "Meldungszuweisungen bearbeiten";
      refToHauptStatus.Rows[4].Cells[2].Value = "SPS Verbindung bearbeiten";
      refToHauptStatus.Rows[5].Cells[2].Value = "Kamera Verbindung bearbeiten";



      if (File.Exists(AlarmPreRecMain.projektFolderPath + "\\AGLink40CfgDev0000.xml"))
      {
        for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
        {
          if (KameraVerbindung.KameraIPadressen[0, i].Equals("") || KameraVerbindung.KameraIPadressen[1, i].Equals("") || KameraVerbindung.KameraIPadressen[2, i].Equals(""))
          {
            startspskamer.Enabled = false; //Die Einstellungen sind nicht vollständig
            return;
          }
        }
        startspskamer.Enabled = true;
      }

    }


    private bool checkmeldungeniftrue()
    {
      bool x;
      for (int row = 0; row < Einstellungen.SPSWarnungsEinstellungArray.GetLength(0); row++)
      {
        for (int col = 0; col < Einstellungen.SPSWarnungsEinstellungArray.GetLength(1); col++)
        {
          try //wennn das Array einen Wert null liefert, so wird ein exception handling aufgerufen
          {
            x = Boolean.Parse(Einstellungen.SPSWarnungsEinstellungArray[row, col]);
          }
          catch (ArgumentNullException)
          {
            x = false;
          }
          if (x == true)
          {
            return x;
          }
        }
      }
      return false;

    }

    private void startspskamer_Click(object sender, EventArgs e)
    { //überprüft, ob ConfigFile schon existiert, Nachsehen in Projektpfad
      if (File.Exists(AlarmPreRecMain.projektFolderPath + "\\AGLink40CfgDev0000.xml"))
      {
        if (!SPSConnection.ConnectSPS())
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Die Verbindung zur SPS konnte" +
            " nicht hergestellt werden.", Color.Red);
          return;
        }
      }
      else
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Es wurden noch keine Konfigurationen für die SPS erstellt.", Color.Red);
        return;
      }

      Einstellungen.RefToMainForm.videoaufnahmeStartenToolStripMenuItem_Click();// Start der neuen Form

      //Kameras Verbinden und 
      if (!KameraVerbindung.ConnectCameraAllinOne())
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Die Kameras konnten nicht verbunden werden. Überprüfen Sie die Verbindungseinstellungen", Color.Red);
      }
      else
      {
        Einstellungen.ViewVideoAufnahme.CallKamerastatus();
      }
    }
  }
}

