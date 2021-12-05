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
namespace AlarmPreRecording
{
  public partial class Kameraanzahl : Form
  {
    public Kameraanzahl()
    {
      InitializeComponent();
      //letzten Kameraanzahlwert anzeigen lassen
      if (Einstellungen.Kameraanzahl != 0)
      {
        anzKameras.Value = Einstellungen.Kameraanzahl;
      }
    }


    //#############################Kameraanzahl################################
    //Ausführen des Codes beim Klicken des "Speichern"-Buttons der Kameraanzahl

    //Schießen des Kameranzahlpanels und Speichern der Variable in einem File
    private void anzKSave_Click(object sender, EventArgs e)
    {

      if (anzKameras.Value == 0)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Geben Sie eine Kameraanzahl ein",
          System.Drawing.Color.Red);
        return;
      }
      //Um sicher zu gehen
      if (AlarmPreRecMain.projektFolderPath == null)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projekt angegeben!" +
          " Erstellen Sie ein neues oder laden Sie ein bereits vorhandenes Projekt",
          System.Drawing.Color.Red);
        return;
      }
      try
      {

        //Kameraanzahl in das File speichern und die Einstellungen lokal
        Einstellungen.Kameraanzahl = anzKameras.Value;
        //Kameraanzahl könnte geändert worden sein, wenn dies der Fall ist werden die 
        //abhängigen Einstellungen angepasst
        Einstellungen.ReloadDataSetUponKameraAnzahlChange(); 
        //Daten in das Einstellungsfile speichern
        Einstellungen.SaveAllSettingsInFile();
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kameraanzahl wurde erfolgreich" +
          " gespeichert", System.Drawing.Color.LightGreen);

        //Kameravornachlauf aktivieren
        Einstellungen.RefToMainForm.enableVorNachLauf(true);
        Einstellungen.RefToMainForm.enableDB(true);
        Einstellungen.RefToMainForm.OpenhauptPrgrmStatus();

      }
      catch (Exception)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kameraanzahl konnte nicht" +
          " gespeichert werden", System.Drawing.Color.Red);
        return;
      }
    }
  }

}
