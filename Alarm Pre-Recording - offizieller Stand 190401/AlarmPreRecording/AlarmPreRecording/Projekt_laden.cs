using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmPreRecording
{
  public partial class Projekt_laden : Form
  {
    public Projekt_laden()
    {
      InitializeComponent();
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

      // Sucht den zu verwendeten Pfad
      DialogResult result = browseProjektFolderPath.ShowDialog();
      if (result == DialogResult.OK)
      {
        AlarmPreRecording.AlarmPreRecMain.projektFolderPath = browseProjektFolderPath.SelectedPath;
        //Projektpfad in der Textbox anzeigen lassen
        prjktPath_txtBox.Clear();
        prjktPath_txtBox.AppendText(AlarmPreRecMain.projektFolderPath);
        //Einstellungen neu laden
        Einstellungen.LoadCompleteEinstellungsfile();
        Einstellungen.RefToMainForm.OpenhauptPrgrmStatus();
      }
    }
  }
}
  