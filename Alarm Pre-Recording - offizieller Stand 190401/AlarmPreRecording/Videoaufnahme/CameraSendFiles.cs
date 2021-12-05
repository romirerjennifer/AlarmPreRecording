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
  public partial class CameraSendFiles : Form
  {
    public CameraSendFiles()
    {
      InitializeComponent();
    }
    //sendet alle Files mit dem Namen VorNachLaufzeiten an die zugehörige Kamera
    private void sendFiless_Click(object sender, EventArgs e)
    {
      if(alleVorNachZeitensenden())
      {
        Einstellungen.ViewVideoAufnahme.CallKamerastatus();
      }
    }
    public static bool alleVorNachZeitensenden()
    {
      //Sobald Kamera die Vor und Nachlaufzeiten und das StartVideoaufnahme File bekommt, arbeitet sie mit
      //den überarbeiteten Zeiten - kein Neustart notwendig
      for (int kameracnt = 0; kameracnt < Einstellungen.Kameraanzahl; kameracnt++)
      {
        //temporär ein File erstellen, das an den RPI gesendet werden kann
        //Die Zeiten werden in eine Zeile, zwei Spalten gespeichert
        StreamWriter outfile = new StreamWriter(AlarmPreRecMain.projektFolderPath + "\\VorNachLaufZeit.csv");
        string content = "";
        for (int y = 0; y < Einstellungen.SPSVorNachLaufArray.GetLength(1); y++)
        {
          content += Einstellungen.SPSVorNachLaufArray[kameracnt, y].ToString() + ",";
        }
        //Versuch, Daten in CSV-File zu schreiben
        outfile.WriteLine(content);
        outfile.Close();

        if (!KameraVerbindung.UploadFile(kameracnt, (@"\VorNachLaufZeit.csv"), "/home/pi/Documents/FileEditing/AufnehmenMitPolling/"))
        {
          //Vornachlaufzeitübertragung erfolgreich - somit File löschen
          if (File.Exists(AlarmPreRecMain.projektFolderPath + "\\VorNachLaufZeit.csv"))
          {
            File.Delete(AlarmPreRecMain.projektFolderPath + "\\VorNachLaufZeit.csv");
          }

          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Die Vor-Nachlaufzeiten konnten nicht an die Kamera übergeben werden", System.Drawing.Color.Red);
          return false;
        }
        //Vornachlaufzeitübertragung erfolgreich - somit File löschen
        File.Delete(AlarmPreRecMain.projektFolderPath + "\\VorNachLaufZeit.csv");
        if (!File.Exists(AlarmPreRecMain.projektFolderPath + "\\StartVideoAufnahme.txt"))
        {
          var myFile = File.Create(AlarmPreRecMain.projektFolderPath + "\\StartVideoAufnahme.txt");
          myFile.Close();
        }
        //startet die Kameraaufnahme bzw startet das eigentliche Programm des Raspberries
        //Raspberry muss zuerst die VorNachLaufzeiten bekommen bevor er starten darf
        //Raspberry erstellt mittels VorNachLaufDaten Variablen die direkt beim Programmstart definiert werden können sollen
        if (!KameraVerbindung.UploadFile(kameracnt, ("\\StartVideoAufnahme.txt"), "/home/pi/Documents/FileEditing/AufnehmenMitPolling/"))
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Die Startsequenz konnte der Kamera nicht übergeben werden", System.Drawing.Color.Red);
          File.Delete(AlarmPreRecMain.projektFolderPath + "\\StartVideoAufnahme.txt");
          return false;
        }
      }

      //Wenn alle Files ordnungsgemäß übertragen werden konnten, dürfen die Timer gestartet werden
      File.Delete(AlarmPreRecMain.projektFolderPath + "\\StartVideoAufnahme.txt");

      Datenbaustein.startTimers();
      Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Trigger auf Meldebits ist aktiv. Die Vor-Nachlaufzeiten wurden der Kamera übergeben", System.Drawing.Color.White);
      return true;
    }
    public static void sendrequestToStoreVideo(int Kameracnt)
    {
      //Wenn das RequestFile noch nicht existiert, muss es erstellt werden
      if (!File.Exists(AlarmPreRecMain.projektFolderPath + "\\SendRequestToStoreVideo.csv"))
      {
        var myFile = File.Create(AlarmPreRecMain.projektFolderPath + "\\SendRequestToStoreVideo.csv");
        myFile.Close();
      }
      //wenn bereits ein Video für die jeweilige Kamera aufgenommen wird, wird kein neues angefordert
      if (KameraVerbindung.FileExists(Kameracnt, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/SendRequestToStoreVideo.csv"))
      {
        //Wenn bereits ein Video auf der Kamera aufgenommen wird, darf kein weiteres Video aufgenommen werden 
        return;
      }
      //Es wird noch kein Video für diese Kamera aufgenommen, deshalb kann man eine Aufnahme anfordern
      KameraVerbindung.UploadFile(Kameracnt, ("\\SendRequestToStoreVideo.csv"), "/home/pi/Documents/FileEditing/AufnehmenMitPolling/");
      File.Delete(AlarmPreRecMain.projektFolderPath + "\\SendRequestToStoreVideo.csv");
    }

    private void CameraSendFiles_Load(object sender, EventArgs e)
    {

    }


  }
}
