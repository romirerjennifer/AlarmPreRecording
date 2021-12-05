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
  public partial class Projekt_erstellen : Form
  {
    public Projekt_erstellen()
    {
      InitializeComponent();
    }

    private string projektName;

    private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
    private FolderBrowserDialog browseProjektFolderPath = new FolderBrowserDialog();

    private void findpath_Click(object sender, EventArgs e)
    {
      //setzt beim Öffnen der Suchfunktion den initialisierten Pfad auf den vorherigen Pfad
      browseProjektFolderPath.RootFolder = Environment.SpecialFolder.MyComputer;
      if (AlarmPreRecMain.projektFolderPath != null)
        browseProjektFolderPath.SelectedPath = AlarmPreRecMain.projektFolderPath;

      // Suchen eines neuen Pfades, der der neue Projektpfad werden soll
      DialogResult result = browseProjektFolderPath.ShowDialog();
      if (result == DialogResult.OK)
      {
        //Pfad wurde in der globalen privaten Variable zwischengespeichert - wird überschrieben
        //ausgewählten Pfad in der Textbox anzeigen lassen
        prjktPath_txtBox.Clear();
        prjktPath_txtBox.AppendText(browseProjektFolderPath.SelectedPath);
      }
    }

    private void prjktPath_txtBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void projektname_TextChanged(object sender, EventArgs e)
    {
      projektname.Text = string.Concat(projektname.Text.Where(char.IsLetterOrDigit));
      projektname.SelectionStart = projektname.Text.Length + 1;
      projektName = projektname.Text;
    }

    private void Create_Project_Click(object sender, EventArgs e)
    {
      if (browseProjektFolderPath.SelectedPath == null)
      {

        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projektpfad angegeben!" +
          " Erstellen des Projektes wird abgebrochen", 
          System.Drawing.Color.Red);
        return;
      }

      // neuen Projektordner erstellen
      if (projektName == null || projektName.Equals(""))
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projektname angegeben! " +
          "Erstellen des Projektes wird abgebrochen", 
          System.Drawing.Color.Red);
        return;
      }

      AlarmPreRecMain.projektFolderPath = browseProjektFolderPath.SelectedPath + "\\" + projektName;
      //Erstellt keinen Ordner, wenn das Verzeichnis bereits vorhanden ist
      Directory.CreateDirectory(AlarmPreRecMain.projektFolderPath);
      //bereits geladene Werte zurücksetzen - Werte aus vorigen Projekten
      Einstellungen.ResetDataSet();
      Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Projekt wurde erstellt.", System.Drawing.Color.LightGreen);
      Einstellungen.RefToMainForm.OpenhauptPrgrmStatus();//Statusfenster öffnen.

    }
  }
}
