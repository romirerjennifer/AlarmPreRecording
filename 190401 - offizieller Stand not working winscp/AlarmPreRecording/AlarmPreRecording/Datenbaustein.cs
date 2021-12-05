
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accon.AGLink;
using System.Windows.Forms;
using System.Timers;
using System.IO;//für Overflow Buffer

namespace AlarmPreRecording
{
  static class Datenbaustein
  {
    //Timer
    public static bool Meldungstrigger_aktiv = false;
    public static System.Timers.Timer TimerCheckDB = new System.Timers.Timer();
    public static System.Timers.Timer TimerCheckIFVideoWasProduced = new System.Timers.Timer();
    public static void startTimers()

    {
      Meldungstrigger_aktiv = true;

      if (!TimerCheckDB.Enabled)
      {
        TimerCheckDB.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
        TimerCheckDB.Interval = 1000; // 1000 ms ist eine Sekunde
        TimerCheckDB.Start(); //wird auch gestoppt und deaktiviert  - hier startet Timer
      }
      if (!TimerCheckIFVideoWasProduced.Enabled)
      {
        TimerCheckIFVideoWasProduced.Elapsed += new ElapsedEventHandler(TIMERVIDWASPRODUCEDEVENT);
        TimerCheckIFVideoWasProduced.Interval = 10000; //alle 10 sec Check ob Video fertig geschrieben wurde
        TimerCheckIFVideoWasProduced.Start(); //wird auch gestoppt und deaktiviert
      }

    }

    public static void StopTimers()
    {

      Meldungstrigger_aktiv = false;
      TimerCheckIFVideoWasProduced.Stop();
      TimerCheckDB.Stop();
    }

    private static int[] lastBitValue = null;
    public static bool[,] Videowird_wurde_erstellt; //[0,0] = Video wird erstellt/requested; [0,1] Video wurde erstellt, aber noch nicht gelöscht
    public static string[] newFileName;
    public static void initialize()
    {

      if (lastBitValue == null)
      {
        lastBitValue = new int[Einstellungen.DBZustandbeiBit.GetLength(0)];
      }
      else if (lastBitValue.GetLength(0) != Einstellungen.DBZustandbeiBit.GetLength(0))
      {
        int[] newarray = new int[Einstellungen.DBZustandbeiBit.GetLength(0)];
        if (lastBitValue.GetLength(0) < Einstellungen.DBZustandbeiBit.GetLength(0))
        {
          for (int j = 0; j < lastBitValue.GetLength(0); j++)
            newarray[j] = lastBitValue[j];
          for (int j = lastBitValue.GetLength(0); j < Einstellungen.DBZustandbeiBit.GetLength(0); j++)
            newarray[j] = 0;

        }
        else if (lastBitValue.GetLength(0) > Einstellungen.DBZustandbeiBit.GetLength(0))
        {
          for (int j = 0; j < Einstellungen.DBZustandbeiBit.GetLength(0); j++)
            newarray[j] = lastBitValue[j];
        }
        lastBitValue = null;
        lastBitValue = newarray;
      }
    }
    private static bool allowWorkOnRPI = true;
    private static readonly object lockMethods = new object(); //versichert, dass der Code nur von einem Thread ausgeführt werden darf

    public static void TIMERVIDWASPRODUCEDEVENT(object source, ElapsedEventArgs e)
    {//Stoppt den Timer, damit die Eventsequenz abgearbeitet werden kann. Würde man es erneut aufrufen würde das Programm abstürzen

      // lock guard
      lock (lockMethods)
      {

        if (!allowWorkOnRPI) //Zwei Timer Methoden nicht gleichzeitig bearbeiten
        {
          return;
        }

        allowWorkOnRPI = false;
        //Polling ob Video fertiggestellt wurde, dann herunterladen 
        for (int kameracnt = ((int)Einstellungen.Kameraanzahl - 1); kameracnt >= 0; kameracnt--)
        {

          if (Videowird_wurde_erstellt[kameracnt, 0] == true && Videowird_wurde_erstellt[kameracnt, 1] == true)//Video wurde angefordert und fertiggestellt
          {
            //Download Videofile von RPI
            //Die Zeit wann der Fehler auftrat wird aus dem Array gelesen und als neuer Name verwendet - siehe newFileName
            Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Video von Kamera " + (kameracnt + 1) + " wird gedownloaded", System.Drawing.Color.White);

            //damit man nicht versucht ein Video 2mal gleichzeitig downzuloaden
            Videowird_wurde_erstellt[kameracnt, 0] = false;
            bool downloadresult = KameraVerbindung.DownloadFile(kameracnt, "/home/pi/Documents/FileEditing/" +
              "AufnehmenMitPolling/out.avi", ("\\Videosequenz-Kamera" + (kameracnt + 1) + "\\" +
              newFileName[kameracnt] + "_Kamera" + (kameracnt + 1) + ".avi"), false);
            Videowird_wurde_erstellt[kameracnt, 0] = true;
            if (!downloadresult)
            {
              //Wenn die Kamera nicht verbunden ist, wird erneut eine Verbindung hergestellt und das File heruntergeladen
              //Wenn zu oft ein File angefordert wird und der RPI die Daten nicht liefert, wird eine Session automatisch geschlossen
              //dies kann oft auftreten, weshalb die Verbindung neu aufgebaut wird
              //Wenn noch immer nicht heruntergeladen werden kann, ist wirklich ein Fehler aufgetreten
              if (!KameraVerbindung.KameraIsConnected(kameracnt))
              {
                KameraVerbindung.reconnectKamera(kameracnt);
                bool downloadresult_1 = KameraVerbindung.DownloadFile(kameracnt, "/home/pi/Documents/" +
                  "FileEditing/AufnehmenMitPolling/out.avi", ("\\Videosequenz-Kamera" + (kameracnt + 1) +
                  "\\" + newFileName[kameracnt] + "_Kamera" + (kameracnt + 1) + ".avi"), false);
                if (!downloadresult_1)
                {
                  //es wird solange probiert das File herunterzuladen bis es funktioniert hat
                  Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme(
                    "Das Video von Kamera " + (kameracnt + 1) + " konnte nicht gedownloaded werden" +
                   " werden.", System.Drawing.Color.Red);

                  allowWorkOnRPI = true;
                  return;
                }
              }
              else
              {
                //es wird solange probiert das File herunterzuladen bis es funktioniert hat
                Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Das Video von Kamera " + (kameracnt + 1) + " konnte nicht gedownloaded werden" +
                 " werden.", System.Drawing.Color.Red);

                allowWorkOnRPI = true;
                return;

              }
            }
            //Overflow Buffer für Videofiles am PC - es dürfen maximal 10 Files im Ordner entstehen - 
            //ältestes File wird gelöscht - 
            //überspringt die ersten 11 elemente und löscht dann das 11. weil out.avi noch dazu kommt
            //muss man um 1 inkrementieren
            foreach (var fi in new DirectoryInfo((AlarmPreRecMain.projektFolderPath + "\\Videosequenz-" +
              "Kamera" + (kameracnt + 1) + "\\")).GetFiles()
              .OrderByDescending(x => x.CreationTime).Skip(10))
              fi.Delete();

            //Video am RPI löschen, damit man dieses Video nicht 2mal downloaded
            KameraVerbindung.RemoveFile(kameracnt, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/out.avi");
            KameraVerbindung.RemoveFile(kameracnt, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/VideoFinished.txt");

            Videowird_wurde_erstellt[kameracnt, 0] = false;
            Videowird_wurde_erstellt[kameracnt, 1] = false;
            Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Das Video von Kamera " + (kameracnt + 1) + " wurde gedownloaded", System.Drawing.Color.Green);
          }
        }
        allowWorkOnRPI = true;
      }
    }
    //arbeitet den Code ab, wenn Timer bzw 1 Sekunde vergangen ist
    //polled DB Werte
    public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
    {
      lock (lockMethods)
      {
        //Stoppt den Timer, damit die Eventsequenz abgearbeitet werden kann. Würde man es erneut aufrufen würde das Programm abstürzen
        if (!allowWorkOnRPI)
        {
          return;
        }


        allowWorkOnRPI = false;

        //abarteit alle eingegeben Meldungen ab
        for (int i = 0; i < (Einstellungen.DBZustandbeiBit.GetLength(0)); i++)
        {
          //liest die merkerbits jeder Meldung/zeile im Array
          int result = ReadBitFromDatenBaustein(0, SPSConnection.timeout, Int16.Parse(
            Einstellungen.DBBitzeichenfolge[i, 1]), Int16.Parse(Einstellungen.DBBitzeichenfolge[i, 2]),
            Int16.Parse(Einstellungen.DBBitzeichenfolge[i, 3]));
          if (result == AGL4.AGL40_SUCCESS)
          {
            //Speichert den Zustand des Bits in einen Array,welcher später mit den Einstellungen der Kamera
            //verglichen wird.
            Einstellungen.DBZustandbeiBit[i] = rwfield[0].B[0];
          }
          else
          {
            Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Die SPS" +
              " ist nicht verbunden. Die Meldung " + i + " konnte gelesen werden.", System.Drawing.Color.Red);
            allowWorkOnRPI = true;
            return;
          }
        }

        //Wenn fertig gelesen wurde, wird verglichen  - neue Schleife, damit sicher alle Daten gespeichert werden konnten, bevor eine Änderung vorgenommen werden konnte
        for (int k = 0; k < (int)Einstellungen.Kameraanzahl; k++)
        {
          //Überprüfen ob Kamerafehler auftrat
          if (Videowird_wurde_erstellt[k, 1] == false)//man darf den Zustand einer Kamera nur abfragen, wenn kein video gedownloaded wird
          {

            //Reihenfolge der Abarbeitung von Bedeutung - Kamera ist gestartet - nur angezeigt, wenn
            //nichts anderes vorher zutrifft
            if (KameraVerbindung.FileExists(k, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/" +
              "VideoFinished.txt"))
            {
              Videowird_wurde_erstellt[k, 1] = true;

              Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Kamera "
                + (k + 1) + " hat das Video fertiggestellt.",
                System.Drawing.Color.LightGreen);
            }
            //Überprüfen, ob bei Video erstellt
            else if (KameraVerbindung.FileExists(k, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/" +
              "WritingVideo.txt"))
            {
              Videowird_wurde_erstellt[k, 0] = true; //Rücksetzen der Variable, wenn Video gedownloaded wird
              Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Kamera "
                + (k + 1) + " erstellt ein Video",
                System.Drawing.Color.White);
            }
            //Überprüfen, ob bei Kamera Fehler exisitert
            else if (KameraVerbindung.FileExists(k, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/Error.txt"))
            {
              Videoaufnahme.KameraXIsConnected[k] = false;
              Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bei Kamera " + (k + 1) + " trat ein Fehler auf. Starten Sie die Kamera neu", System.Drawing.Color.Red);
            }
            //Überprüfung des momentanten Kamerazustandes
            else if (KameraVerbindung.FileExists(k, "/home/pi/Documents/FileEditing/AufnehmenMitPolling/started.txt"))
            {
              Videoaufnahme.KameraXIsConnected[k] = true; //Kamera wird abgearbeitet und ist verbunden - Anzeige in Kamerastatus
            }
          }
        }
        //steigende Flanken Detektion - Wenn Bit steigende Flanke gesetzt wurde, dann Senden Videorequest
        for (int i2 = 0; i2 < (Einstellungen.DBZustandbeiBit.GetLength(0)); i2++)
        {
          if (Einstellungen.DBZustandbeiBit[i2] != lastBitValue[i2])
          {
            lastBitValue[i2] = Einstellungen.DBZustandbeiBit[i2];

            if (Einstellungen.DBZustandbeiBit[i2] == 1)
            {
              for (int k = 0; k < (int)Einstellungen.Kameraanzahl; k++)
              {
                if (Videowird_wurde_erstellt[k, 0] == false) //Man darf nur ein Video für eine Kamera
                                                             //anfordern, wenn diese Kamera nicht gerade ein Video erstellt
                {
                  //Array durchgehen - alle Meldungen
                  if (Einstellungen.SPSWarnungsEinstellungArray[i2, k].Equals("True"))
                  {
                    //Rename File nach YYMMDD_HH-mm-ss.avi - momentante Zeit als neuen Videonamen speichern
                    //- HH is das 24h Format
                    newFileName[k] = DateTime.Now.ToString("yyMMdd_HH-mm-ss");
                    //Wenn Firstread existiert ist der Kamerabuffer noch nicht gefüllt und es dürfen noch
                    //keine Videos angefordert werden, wenn ein Video gerade geschrieben wird, darf kein 
                    //neues angefordert werden - nur um sicher zu gehen nochmal abfragen
                    while (KameraVerbindung.FileExists(k, "/home/pi/Documents/FileEditing/" +
                      "AufnehmenMitPolling/FirstRead.txt"))
                    {

                    }

                    //jeweiliger Kamera File senden
                    //Videorequest auf true setzen - es wurde bereits ein Video angefordert
                    Videowird_wurde_erstellt[k, 0] = true;

                    CameraSendFiles.sendrequestToStoreVideo(k);

                  }
                }
                else
                {
                  Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bei Kamera " + (k + 1) + " wird bereits ein Video aufgenommen.",
                    System.Drawing.Color.Yellow);

                }
              }
            }
          }
        }
        allowWorkOnRPI = true;
      }
    }
    //darin sind die gelesen Daten gespeichert
    public static AGL4.DATA_RW40[] rwfield;
    //lese Bit des Datenbausteins
    public static Int32 ReadBitFromDatenBaustein(Int32 connnr, Int32 timeout, int DBnr_uebergabe, int offset_uebergabe, int bitnr_uebergabe)
    {
      rwfield = new AGL4.DATA_RW40[1];
      //Festlegen welche PLC  SPS gelesen werden soll
      Int32 result = AGL4.AGL40_PARAMETER_ERROR;
      rwfield[0] = new AGL4.DATA_RW40();
      rwfield[0].BitNr = (ushort)bitnr_uebergabe;
      rwfield[0].DBNr = (ushort)DBnr_uebergabe;
      rwfield[0].Offset = (ushort)offset_uebergabe;
      //Der erwartete Wert für "OpAnz" für ReadMix, WriteMix, OptReadMix oder OptWriteMix ist 1
      rwfield[0].OpAnz = 1;
      rwfield[0].OpArea = AGL4.AREA_DATA;
      rwfield[0].OpType = AGL4.TYP_BIT;
      rwfield[0].Result = 0;
      rwfield[0].B = new Byte[rwfield[0].OpAnz];
      rwfield[0].B[0] = 0;

      //nur durchführen wenn Timeout positiv
      //Verbidung mit AG muss hergestellt werden
      if (timeout > 0)
      {
        //Liest die Daten vom DB 
        result = AGL4.ReadMix(connnr, rwfield, rwfield.Length, timeout);
        if (result != AGL4.AGL40_SUCCESS)
        {
          // Error
          String errormsg = "";
          AGL4.GetErrorMsg(result, out errormsg);
        }
      }
      return result;
    }
  }
}
