using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmPreRecording
{
  public partial class DBBits : Form
  {
    public DBBits()
    {
      InitializeComponent();
    }

    private void DBBits_Load(object sender, EventArgs e)
    {
      DataTable DBBitsTable = new DataTable();
      DBBitsTable.Columns.Add("Merkerbitname", typeof(string));
      //dynamisch die Reihen erstellen, je nachdem wie viele Kameras benötigt werden

      DBBitsTable.Rows.Add("Merkerbit1");
      //vorherige Einstellungen anzeigen lassen
      if (Einstellungen.DBBitzeichenfolge != null)
      {
        while (DBBitsTable.Rows.Count < Einstellungen.DBBitzeichenfolge.GetLength(0))
        {
          DBBitsTable.Rows.Add("");
        }
      }
      DBBitsTable.Columns.Add("Datenbausteinnummer", typeof(string));

      DBBitsTable.Columns.Add("Bytenummer", typeof(string));

      DBBitsTable.Columns.Add("Bitnummer", typeof(string));
      DBBitsDataGrid.DataSource = DBBitsTable;
      DBBitsDataGrid.Columns[1/*Datenbausteinnummer breiter machen*/].Width = 150;


      //vorige Einstellungen anzeigen lassen
      if (Einstellungen.DBBitzeichenfolge != null)
      {
        int rows;
        for (rows = 0; rows < Einstellungen.DBBitzeichenfolge.GetLength(0); rows++)
        {
          for (int col = 0; col < Einstellungen.DBBitzeichenfolge.GetLength(1); col++)
          {
            DBBitsDataGrid.Rows[rows].Cells[col].Value = Einstellungen.DBBitzeichenfolge[rows, col];
          }
        }
      }
    }

    public static void DBBits_Saver()
    {
      if (AlarmPreRecMain.projektFolderPath == null)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projekt angegeben! Laden Sie ein bereits bestehendes oder erstellen Sie ein neues Projekt.", System.Drawing.Color.Red);
        return;
      }
      //DBBitzeichenfolge in File speichern 
      try
      {
        Einstellungen.SaveAllSettingsInFile();
        if(Einstellungen.Kameraanzahl>0)
          Einstellungen.RefToMainForm.enableWarnung(true);
      }
      catch (Exception)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Merkerbits konnten nicht gespeichert werden", System.Drawing.Color.Red);
      }
    }

    private void DBBits_Save_Click(object sender, EventArgs e)
    {
      //Zeiten lokal speichern
      string[,] DBBitsArray = new string[(DBBitsDataGrid.Rows.Count - 1), 4];
      int col;
      //Überprüfen der Eingabe auf unzulässige Zeichen (nur Zahlen sind zulässig)
      for (int rows = 0; rows < (DBBitsDataGrid.Rows.Count - 1); rows++)
      {
        if (DBBitsDataGrid.Rows[rows].Cells[0].Value.Equals(null))
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Dem Merkerbit wurde kein Name zugewiesen", System.Drawing.Color.Red);
          DBBitsArray = null;
          return;
        }
        for (col = 0; col < DBBitsDataGrid.Rows[rows].Cells.Count; col++)
        {

          string value = DBBitsDataGrid.Rows[rows].Cells[col].Value.ToString();
          DBBitsArray[rows, col] = value;

          //Überprüft, ob Einträge leer sind
          if (value.Equals(""))
          {
            Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Entfernen Sie die leeren Einträge aus der Tabelle", System.Drawing.Color.Red);
            DBBitsArray = null;
            return;
          }

          //check if value is all numbers
          //isNumeric = True - wenn erfolgreich konvertiert wurde
          //isNumeric = False - wenn in 'value' ungültige Zeichen (Buchstaben, Sonderzeichen) vorhanden
          //sind oder dieser leer ist

          //nur positive Zahlen
          if (col != 0)
          {
            bool isNumeric = Int32.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture,
              out int resultplacebo);

            if (!isNumeric)
            {
              Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Ungültige Eingabe bei" +
                " Kamera "+ (rows+1),System.Drawing.Color.Red);
              DBBitsArray = null;
              return;
            }
          }
        }
        //Größenbeschränkung der Bits zeilenweise auf 1 Byte
        if (Int16.Parse(DBBitsDataGrid.Rows[rows].Cells[3/*Dies ist die Bitnummer*/].Value.ToString()) > 7)
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Bitnummer muss im Intervall [0;7] liegen!", System.Drawing.Color.Red);
          DBBitsArray = null;
          return;
        }
      }
      //DBits lokal speichern
      Einstellungen.DBBitzeichenfolge = DBBitsArray;
      Einstellungen.ReloadDataSetUponDBBitsChange();
      Einstellungen.DBZustandbeiBit = new int[Einstellungen.DBBitzeichenfolge.GetLength(0)];
      DBBits_Saver();
      Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Merkerbits wurden erfolgreich" +
        " gespeichert", System.Drawing.Color.White);
      Einstellungen.RefToMainForm.OpenhauptPrgrmStatus();
    }

    private void DBBitsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
