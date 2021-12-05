using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;
using System.Windows.Forms;
using System.IO;

using System.Runtime.InteropServices;   //für optional
namespace AlarmPreRecording
{
  class KameraVerbindung
  {
    public static string[,] KameraIPadressen;
    public static SessionOptions options = new SessionOptions
    {
      Protocol = Protocol.Scp,            //Protokoll für Kommunikation mit RaspberryPi ist SCP
      HostName = "",                      //IP-Adresse des Pis
      Password = "",                      //Passwort
      UserName = "",                       //Username
      GiveUpSecurityAndAcceptAnySshHostKey = true     //Sicherheitsstufe
    };
    //In Liste werden alle Sessions für Kameras gespeichert. Jede Kamera besitzt ihre eigene Session
    public static List<Session> sessionList = new List<Session>();
    public static bool FileExists(int KameraCnt, string path)
    {
      try
      {
        return sessionList[KameraCnt].FileExists(path);
      }
      catch
      {
        return false;
      }
    }

    public static bool ConnectCamera(string hostnameref, string passwordref, string usernameref, int kameracnt)
    {
      try
      {
        options.HostName = hostnameref;
        options.Password = passwordref;
        options.UserName = usernameref;
        options.TimeoutInMilliseconds = 20000;   //nach 20 sec Timeout der Session

        Session sessionlocal = new Session();
        //Wenn die Liste leer ist, dann kann man sowieso ein Element hinzufügen 
        //Wenn sie nicht leer ist und der Index der genutzt werden soll bereits Element existiert, wird dies 
        //zuerst dort gelöscht und dann eingefügt
        if (sessionList.Count != 0)
        {
          if ((kameracnt + 1) <= sessionList.Count)
          {

            if (Videoaufnahme.KameraXIsConnected[kameracnt] == true)
            {
              Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Es" +
                " besteht bereits eine Verbindung mit der Kamera",System.Drawing.Color.Yellow);
              return true;
            }
            sessionList.RemoveAt(kameracnt); //Entfernt bereits vorhandene Session beim Index
            //KameracntWindowsForm - macht Platz für neue Session
          }
        }
        sessionList.Insert(kameracnt, sessionlocal);     //fügt eine neue Session in Liste ein 
        sessionList[kameracnt].Open(options);           //Verbinden

        if (!sessionList[kameracnt].Opened)                    //Abfrage Verbindung
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bei der Verbindung mit der angegeben Kamera trat ein Fehler auf", System.Drawing.Color.Red);
          return false;
        }
        if(FileExists(kameracnt, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/AufnPoll.cpp")) //Kamera fix verbunden
            return true;
        else
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bei der Verbindung mit der angegeben Kamera trat ein Fehler auf", System.Drawing.Color.Red);
          return false;
        }
      }

      catch
      {
        //keine Kamera eingestellt
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bei der Verbindung mit der angegebene Kamera trat ein Fehler auf", System.Drawing.Color.Red);
        return false;
      }
    }
    
    public static bool UploadFile(int KameraCnt, string File, string targetPathRPI)
    {
      try
      {
        TransferOptions transferOptionsUpload = new TransferOptions();
        transferOptionsUpload.TransferMode = TransferMode.Binary;               //Binärübertragung

        TransferOperationResult transferResultUpload;
        transferResultUpload = sessionList[KameraCnt].PutFiles((AlarmPreRecMain.projektFolderPath + File),
          targetPathRPI, false, transferOptionsUpload);

        transferResultUpload.Check();                 //wenn nicht übertragen - Error
        return true;
      }

      catch
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Die Dateien konnten Kamera " + (KameraCnt + 1) + " nicht übergeben werden.", System.Drawing.Color.Red);
        return false;
      }
    }
    public static bool DownloadFile(int KameraCnt, string downloadFile, string targetFile, bool removeATDownload)
    {
      try
      {
        TransferOptions transferOptionsDownload = new TransferOptions();
        transferOptionsDownload.TransferMode = TransferMode.Binary;

        TransferOperationResult transferResultDownload;

        Directory.CreateDirectory(new FileInfo(AlarmPreRecMain.projektFolderPath + targetFile).Directory.FullName);
        sessionList[KameraCnt].RemoveFiles("/home/pi/Documents/FileEditing/AufnehmenMitPolling/SendRequestToStoreVideo.csv");
        //get Files holt sich aus den 1. Parameter das Video des Kamerasystems, speichert es in den Pfad des 2. Parameters.
        //3. Parameter legt fest, ob File am Raspberry gelöschen werden soll
        transferResultDownload = sessionList[KameraCnt].GetFiles(@downloadFile, (AlarmPreRecMain.projektFolderPath + @targetFile), removeATDownload, transferOptionsDownload);

        transferResultDownload.Check();                 //wenn nicht übertragen - Error
        return true;
      }

      catch
      {
        return false;
      }

    }
    public static bool ConnectCameraAllinOne()
    {
      for (int i = 0; i < Einstellungen.Kameraanzahl; i++)
      {
        if(KameraIPadressen[0, i].Equals("")|| KameraIPadressen[1, i].Equals("")|| KameraIPadressen[2, i].Equals(""))
        {
          return false; //Die Einstellungen sind nicht vollständig
        }
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Es wird eine Verbindung mit Kamera " + (Videoaufnahme.KameraCntWindowsForm + 1) + " hergestellt.", System.Drawing.Color.White);

        //Kamera wird mit den obigen Daten verbunden - geöffnete Session wird in Kameraverbindung gespeichert
        if (ConnectCamera(KameraIPadressen[0, i], KameraIPadressen[1, i], KameraIPadressen[2, i], i))
        {
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Kamera " + (i + 1) + " wurde verbunden.", System.Drawing.Color.Green);
        }
        else
        {
          return false;
        }
      }
      CameraSendFiles.alleVorNachZeitensenden();
     
      return true;
    }
    public static void RemoveFile(int KameraCnt, string PathToRemove)
    {
      try
      {
        sessionList[KameraCnt].RemoveFiles(PathToRemove);
      }
      catch
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Beim Löschen des VideoFiles der Kamera" + KameraCnt + "trat ein Fehler auf", System.Drawing.Color.Red);
      }
    }
    public static bool KameraIsConnected(int kameracnt)
    {
      if (FileExists(kameracnt, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/started.txt"))
        return true;
      else
      {
        Videoaufnahme.KameraXIsConnected[kameracnt] = false;
        return false;
      }
    }
    public static void reconnectKamera(int kameracnt)
    {
      KameraVerbindung.ConnectCamera(KameraVerbindung.KameraIPadressen[0, kameracnt], KameraVerbindung.KameraIPadressen[1, kameracnt]
        , KameraVerbindung.KameraIPadressen[2, kameracnt], kameracnt);
    }
    public static void Disconnect(int KameraCnt)
    {
      try
      {
        sessionList[KameraCnt].Close();//Schließen der Verbindung
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Die Verbindung " +
          "mit der Kamera " + (KameraCnt + 1) +" wurde getrennt", System.Drawing.Color.White);
      }
      catch (ArgumentNullException)
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Mit Kamera " + KameraCnt + " bestand keine Verbindung, daher konnte sie nicht getrennt werden.", System.Drawing.Color.Red);
      }
      catch
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Die Verbindung mit der Kamera konnte nicht getrennt werden.", System.Drawing.Color.Red);
      }

    }
  }
}

