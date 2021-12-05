using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;
namespace AlarmPreRecording
{
  static class Einstellungen
  {

    public static void LoadCompleteEinstellungsfile()
    {

      RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Projekt wurde geladen", System.Drawing.Color.White);

      RefToMainForm.enableKameraCNT(true);
      try
      {
        string whole_file = System.IO.File.ReadAllText(AlarmPreRecMain.projektFolderPath + 
          "\\Einstellungen.csv");

        //In Zeilen aufspalten
        whole_file = whole_file.Replace('\n', '\r');
        string[] linesa = whole_file.Split(new char[] { '\r' },
            StringSplitOptions.RemoveEmptyEntries);

        //Abfrage, wie viele Zeilen und Spalten es gibt
        int num_rows = linesa.GetLength(0);

        //Feld laden
        //Laden der Kameraanzahl siehe Tabellenschema

        string[] c_temp = linesa[0].Split(',');
        Kameraanzahl = Convert.ToDecimal(c_temp[0]);
        if (SPSVorNachLaufArray == null)
          SPSVorNachLaufArray = new string[(int)Kameraanzahl, 2];
        //Anzahl der Spalten laut Tabellenschema 
        int num_cols;
        if (num_rows <= 4)
          num_cols = 4;
        else
          num_cols = 4 + (int)Kameraanzahl;
        //Laden der Kameraverbindung - IPadressen etc

        KameraVerbindung.KameraIPadressen = new string[3, (int)Kameraanzahl];
        for (int row = 1; row <= 3; row++)
        {
          string[] line_row = linesa[row].Split(',');
          for (int c = 0; c < (int)Kameraanzahl; c++)
          {
            //Value array soll immer bei 0;0 starten
            KameraVerbindung.KameraIPadressen[row - 1, c] = line_row[c];
          }
        }
        RefToMainForm.enableDB(true);
        RefToMainForm.enableVorNachLauf(true);

        //Laden der Vornachlaufzeiten
        if (((linesa[1].Split(',').Length) - 1) > Kameraanzahl) //man nutzt jene Zeilen, die die Spalten der Vornachlaufzeit beinhalten und man trennt
                                                                //sie bei jedem ",". Diese Trennungen werden gezählt und dies entspricht der Anzahl der Spalten in dieser Zeile
                                                                //-1, weil ein "," zuviel gezählt wird
        {
          for (int rowz = 1; rowz < 3; rowz++)
          {
            string[] line_row = linesa[rowz].Split(',');
            //Siehe Tabellenschema
            for (int c = (int)Kameraanzahl; c < ((int)(Kameraanzahl * 2)); c++)
            {
              //Value array soll immer bei 0;0 starten
              SPSVorNachLaufArray[(c - (int)Kameraanzahl), rowz - 1] = line_row[c]; //Array ist transponiert - siehe Tabellenschema
            }
          }
          RefToMainForm.enableVorNachLauf(true);
        }
        //Laden der DBBitzeichen 
        // es existieren bereits die DBBitzeichen und Meldungen - Kleinstmöglicher Array nur [4;4]

        //erstellt einen Array mit der Länge Anzahl der Meldungen und 4
        DBBitzeichenfolge = new string[(num_rows - 4), 4];
        if (linesa.GetLength(0) > 4)
        {
          //Laden der DBBits
          //alle DB Meldungen bis Ende auslesen
          for (int row = 4; row < num_rows; row++)
          {
            string[] line_row = linesa[row].Split(',');
            for (int c = 0; c < 4; c++)
            {
              //Value array soll immer bei 0;0 starten
              DBBitzeichenfolge[row - 4, c] = line_row[c];
            }
          }
          RefToMainForm.enableWarnung(true);
          DBZustandbeiBit = new int[DBBitzeichenfolge.GetLength(0)];

          //Laden der Meldungszustände in Verbindung mit der Kamera - Welche Kamera wird durch welche Meldung getriggert
          SPSWarnungsEinstellungArray = new string[(num_rows - 4), (int)Kameraanzahl];

          for (int row = 4; row < num_rows; row++)
          {
            string[] line_row = linesa[row].Split(',');
            //Siehe Tabellenschema
            for (int c = 4; c < num_cols; c++)
            {
              //Value array soll immer bei 0;0 starten
              SPSWarnungsEinstellungArray[row - 4, c - 4] = line_row[c];
            }
          }

        }
        else
        {
          RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Es existieren noch keine Meldungen und Kamerazuweisungen. Bitte ergänzen Sie diese",
            System.Drawing.Color.Yellow);

        }

      }
      catch
      {
        RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Es konnten nicht alle Daten aus dem Projektordner gelesen werden. Tragen Sie die Daten neu" +
          " ein.", System.Drawing.Color.Yellow);

      }
    }

    //Laden der bereits gespeicherten Einstellungen aus dem Projektpfad
    //Die Reihenfolge ist hier von Bedeutung, da einzelne Einstellungen voneinander abhängig sind
    //So kann man keine VorNachlaufZeit einstellen, wenn man keine Kameraanzahl angegeben hat
    public static void ResetDataSet()
    {
      //Werte zurücksetzen
      Kameraanzahl = 0;
      Videoaufnahme.ResetData();
      SPSWarnungsEinstellungArray = null;
      SPSVorNachLaufArray = null;
      DBBitzeichenfolge = null;
      DBZustandbeiBit = null;

      //Menüpunkte disablen, wenn man sie noch nicht erreichen darf
      RefToMainForm.enableKameraCNT(false);
      RefToMainForm.enableVorNachLauf(false);
      RefToMainForm.enableWarnung(false);
      RefToMainForm.enableKameraCNT(true);
      RefToMainForm.enableDB(false);
      //Verbindungen trennen
      SPSConnection.DisconnectSPS();
      for (int i = 1; i < Einstellungen.Kameraanzahl; i++)
      {
        KameraVerbindung.Disconnect(i);
      }//Timer stoppen
      Datenbaustein.TimerCheckDB.Stop();
      Datenbaustein.TimerCheckIFVideoWasProduced.Stop();
    }
    //vergrößert oder verkleinert den übergebenen Array um die übergebenen Zeilen und Spalten
    public static string[,] ResizeArray(string[,] original, int rows, int cols, string newValue)
    {
      var newArray = new string[rows, cols];
      //gibt die kleinere Zahl aus  - Restreihen / Spalten sind null
      int minRows = Math.Min(rows, original.GetLength(0));
      int minCols = Math.Min(cols, original.GetLength(1));
      for (int i = 0; i < minRows; i++)
        for (int j = 0; j < minCols; j++)
          newArray[i, j] = original[i, j];
      //Wenn ein array vergrößert wird, müssen die restlichen Indexes mit einem Standardwert - hier newValue - aufgefüllt werden zb "TRUE"
      //Unterschied ob Zeilen (getlength 0 ) oder Spalten(getlength 1) vergrößert werden
      if (rows > original.GetLength(0))
      {
        for (int i = minRows; i < rows; i++)
        {
          for (int j = 0; j < minCols; j++)
            newArray[i, j] = newValue;
        }
      }
      if (cols > original.GetLength(1))
      {
        for (int i = 0; i < minRows; i++)
        {
          for (int j = minCols; j < cols; j++)
            newArray[i, j] = newValue;
        }
      }
      return newArray;
    }
    //Wenn die Anzahl der verwendeten Kameras sich ändert, müssen die einzelnen Einstellungen, die von dieser Größe abhängig sind, verändert werden
    public static void ReloadDataSetUponKameraAnzahlChange()
    {

      if (KameraVerbindung.KameraIPadressen == null)
      {
        //Ip-Adressengröße anlegen
        KameraVerbindung.KameraIPadressen = new string[3, (int)Einstellungen.Kameraanzahl];
        for (int row = 0; row < 3; row++)
        {
          for (int column = 0; column < Kameraanzahl; column++)
          {
            KameraVerbindung.KameraIPadressen[row, column] = "";
          }
        }
      }
      else
      {
        //wenn die Kameraanzahl geändert wurde, müssen alle Kameras neu verbunden und gespeichert werden
        for (int i = 0; i < KameraVerbindung.KameraIPadressen.GetLength(1); i++)
        {
          if (Videoaufnahme.KameraXIsConnected != null)
            if (Videoaufnahme.KameraXIsConnected.GetLength(0) > 0)
              if (Videoaufnahme.KameraXIsConnected[i] == true)
                KameraVerbindung.Disconnect(i); //dadurch, dass alle Kameraverbindungen getrennt wurden,
                                                //müssen die Kameras neu verbunden werden 
                                                //und deren IP Adressen Einstellungen überprüft werden 
        }
        KameraVerbindung.KameraIPadressen = ResizeArray(KameraVerbindung.KameraIPadressen, 3, 
          (int)Kameraanzahl, "");

      }
      Videoaufnahme.KameraXIsConnected = null;//Keine Kameraverbindung ist gültig
      if (SPSVorNachLaufArray != null) //wenn array nicht leer
      {
        if (SPSVorNachLaufArray.GetLength(0) != Kameraanzahl) //und array eine andere Länge als Kameraanzahl hat
        {
          //Die lokalen arrays werden an die neue Kameraanzahl angepasst bzw vergrößert/verkleinert und in die Files ausgeschrieben
          SPSVorNachLaufArray = ResizeArray(SPSVorNachLaufArray, (int)Kameraanzahl, 2, "1");
          //neuen Werte in das VorNachlauffile speichern
          KameraVorNachLauf.VorNachLauf_Saver();



        }
        if (SPSWarnungsEinstellungArray.GetLength(1) != Kameraanzahl)
        {
          SPSWarnungsEinstellungArray = ResizeArray(SPSWarnungsEinstellungArray, DBBitzeichenfolge.GetLength(0), (int)Kameraanzahl, "False");
        }
      }
    }
    //gleich wie Kameraanzahländerung, nur wenn die Anzahl der verwendeten Meldungen sich ändert, müssen die einzelnen Einstellungen verändert werden
    public static void ReloadDataSetUponDBBitsChange()
    {
      if (SPSWarnungsEinstellungArray != null)
      {
        if (SPSWarnungsEinstellungArray.GetLength(0) != DBBitzeichenfolge.GetLength(0))
        {
          //Die lokalen Arrays werden an die neue Kameraanzahl angepasst bzw vergrößert/verkleinert und in die Files ausgeschrieben
          SPSWarnungsEinstellungArray = ResizeArray(SPSWarnungsEinstellungArray, DBBitzeichenfolge.GetLength(0), (int)Kameraanzahl, "False");
        }
      }
      else
      {
        SPSWarnungsEinstellungArray = new string[DBBitzeichenfolge.GetLength(0), (int)Kameraanzahl];
        for (int row = 0; row < DBBitzeichenfolge.GetLength(0); row++)
        {
          for (int column = 0; column < (int)Kameraanzahl; column++)
          {
            SPSWarnungsEinstellungArray[row, column] = "False";
          }
        }
      }
    }

    public static bool SaveAllSettingsInFile()
    {
      //Projektpfad überpüfen
      if (AlarmPreRecMain.projektFolderPath == null)
      {
        RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projekt angegeben! Erstellen Sie ein neues oder laden sie ein bereits vorhandenes Projekt", System.Drawing.Color.Red);
        return false;
      }
      List<string> FilesaveList = new List<string>();

      if (FilesaveList.Count == 0)
        FilesaveList.Add(Kameraanzahl.ToString("00.0") + ",");
      else
        FilesaveList[0] = Kameraanzahl.ToString("00.0") + ",";
      //Speichern der IPAdressen der Kamera 
      try
      {
        //Zeilen sind Ip Adressen und etc, Spalten sind die einzelnen Kameras
        for (int x = 0; x < KameraVerbindung.KameraIPadressen.GetLength(0); x++)
        {
          //speichert die Werte zeilenweise
          string content = "";
          for (int y = 0; y < KameraVerbindung.KameraIPadressen.GetLength(1); y++)
          {
            content += KameraVerbindung.KameraIPadressen[x, y] + ",";//siehe Tabellenschema
          }
          //Wenn die Kameraipadressen gespeichert wurden, werden die Vor- Nachlaufzeiten ergänzt 
          //es gibt nur 2 Reihen im vornachlaufarray - Vor- und Nachlaufreihe
          if (x < 2 && SPSVorNachLaufArray != null)
          {
            //weil spsVornachlaufarray transponiert ist - sonst getlength(1)
            for (int y = 0; y < SPSVorNachLaufArray.GetLength(0); y++)
            {
              content += SPSVorNachLaufArray[y, x] + ",";//siehe Tabellenschema
            }
          }
          //Kameraeinstellungen in das Filearray speichern
          if (FilesaveList.Count < 4)
            FilesaveList.Add(content);
          else
            FilesaveList[x + 1] = content;
        }


        //Speichern der DBBitzeichenfolge und der Meldungseinstellungen 
        if (DBBitzeichenfolge != null)
        {
          if (DBBitzeichenfolge.GetLength(0) != 0)
          {
            for (int x = 0; x < DBBitzeichenfolge.GetLength(0); x++)
            {
              string content_db = "";
              //Wenn die DBBitzeichenfolge existiert, existiert auch die Meldung/Kameraeinstellungen, 
              // auch wenn diese nicht fertig eingestellt sind
              for (int y = 0; y < 4; y++)
              {
                content_db += DBBitzeichenfolge[x, y] + ",";
              }
              for (int y = 4; y < (Kameraanzahl + 4); y++)
              {
                content_db += SPSWarnungsEinstellungArray[x, (y - 4)] + ",";
              }

              //Daten in das Array speichern 
              if (FilesaveList.Count < (DBBitzeichenfolge.GetLength(0) + 4))
                FilesaveList.Add(content_db);
              else
                FilesaveList[x + 4] = content_db;

            }

          }
        }

        //Ausschreiben in das lokale File 
        using (StreamWriter outfile = new StreamWriter(AlarmPreRecMain.projektFolderPath + "\\Einstellungen.csv"))
        {
          //File ausschreiben
          for (int x = 0; x < FilesaveList.Count; x++)
          {
            outfile.WriteLine(FilesaveList[x]);
          }
          outfile.Close();
          return true;
        }
      }
      catch (Exception)
      {
        RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Die Daten konnten nicht Projekt gespeichert werden", System.Drawing.Color.Red);
        return false;
      }
    }
    //Ref zu main form 
    //Referenz um zur Haupt-Form zurückkehren zu können. In diesem Fall ist das AlarmPreRecMain
    public static AlarmPreRecMain RefToMainForm { get; set; }
    //Verweis zur aktiven Form Videoaufnahme - für den Aufruf nicht statischer Methoden
    public static Videoaufnahme ViewVideoAufnahme { get; set; }
    public static decimal Kameraanzahl = 0;
    //Einstellungen xte Kamera soll bei xter Meldung aufnehmen
    public static string[,] SPSWarnungsEinstellungArray = null;
    //Vor- Nachlaufzeiten
    public static string[,] SPSVorNachLaufArray = null;
    //Name, DBNummer,Bytenummer und Bitnummer der Meldung
    public static string[,] DBBitzeichenfolge = null;
    //Zustand der Meldung
    public static int[] DBZustandbeiBit = { };
  }

}