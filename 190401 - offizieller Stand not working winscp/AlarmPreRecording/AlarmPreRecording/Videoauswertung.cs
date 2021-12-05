using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmPreRecording
{
  public partial class Videoauswertung : Form
  {
    public Videoauswertung()
    {
      InitializeComponent();


      DisplayFile.ValueMember = "Path";
      DisplayFile.DisplayMember = "FileName";
    }

    private void BrowseVideo_Click(object sender, EventArgs e)
    {

      using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true,
        Filter = "AVI|*.avi" })
      {
        if (AlarmPreRecMain.projektFolderPath != null)
        {
          //Suchpfad im Projektpfad öffnen
          if (Directory.Exists(AlarmPreRecMain.projektFolderPath + "\\"))
          {
            ofd.InitialDirectory = AlarmPreRecMain.projektFolderPath + "\\";
          }
        }
        else
        {
          ofd.InitialDirectory = "C:\\";
        }
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          List<Mediaplayer> files = new List<Mediaplayer>();
          foreach (string fileName in ofd.FileNames)
          {
            //Auch mehrere Files in der Listbox anzeigbar
            FileInfo fi = new FileInfo(fileName);
            files.Add(new Mediaplayer() { Filename = Path.GetFileNameWithoutExtension(fi.FullName),
              Path = fi.FullName });
          }
          DisplayFile.DataSource = files;
          return;
        }
      }
    }

    private void DisplayFolder_SelectedIndexChanged(object sender, EventArgs e)
    {
      Mediaplayer file = DisplayFile.SelectedItem as Mediaplayer;
      if (file != null)
      {
        WinMediaPlayer.URL = file.Path;
        WinMediaPlayer.Ctlcontrols.play();
      }
    }
  }
}
