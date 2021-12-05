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
  public partial class KameraWarnung : Form
  {
    public KameraWarnung()
    {
      InitializeComponent();
    }
    private DataTable Meldungtable = new DataTable();
    private void KameraWarnung_Load(object sender, EventArgs e)
    {
      Meldungtable.Columns.Add("Meldungen", typeof(string));

      //dynamisch Reihen erstellen, je nachdem wie groß das Warnungsarray ist
      for (int meldungcnt = 0; meldungcnt < Einstellungen.DBBitzeichenfolge.GetLength(0); meldungcnt++)
      {
        //Meldungsnamen aus dem Bitzeichnfolge-Array erstellen
        Meldungtable.Rows.Add(Einstellungen.DBBitzeichenfolge[meldungcnt, 0]);
      }
      for (int kameracnt = 1; kameracnt <= Einstellungen.Kameraanzahl; kameracnt++)
      {
        Meldungtable.Columns.Add("Kamera " + kameracnt, typeof(bool));

      }
      WarnungenDataGridView.DataSource = Meldungtable;
      //Die erste Spalte - die Namen der Merkerbits - dürfen nicht verändert werden
      WarnungenDataGridView.Columns[0].ReadOnly = true;


      //2 Schleifen für Erstellen Datagridviews, weil zuerst die Chechkoxen im Datatable erstellt werden müssen. 
      //Dann wird der Datatable mit dem Datagridview gebunden - visuell erstellt 
      //und danach kann man erst im visuellen Datagridview die Größe der Spalte ändern
      for (int kameracnt = 1; kameracnt <= Einstellungen.Kameraanzahl; kameracnt++)
      {
        WarnungenDataGridView.Columns[kameracnt].Width = 70;
      }

      //Zuvor gespeicherte Werte in das Datagrid laden
      if (Einstellungen.SPSWarnungsEinstellungArray != null)
      {
        bool x;
        foreach (DataGridViewRow row in WarnungenDataGridView.Rows)
        {
          for (int col = 1; col < WarnungenDataGridView.ColumnCount; col++)
          {
            try //wennn das Array einen Wert null liefert, so wird ein exception handling aufgerufen
            {
              x = Boolean.Parse(Einstellungen.SPSWarnungsEinstellungArray[row.Index, col - 1]);
            }
            catch (ArgumentNullException)
            {
              x = false;
            }
            if (x == true)
            {
              (WarnungenDataGridView.Rows[row.Index].Cells[col] as DataGridViewCheckBoxCell).Value = x;
            }
          }
        }
      }
    }

    public static bool KameraMeldung_Saver()
    {
      if (AlarmPreRecMain.projektFolderPath == null)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projekt angegeben! Erstellen Sie ein neues oder laden Sie ein bereits vorhandenes Projekt", System.Drawing.Color.Red);
        return false;
      }
      //Kameraeinstellungen in File speichern 
      if (!Einstellungen.SaveAllSettingsInFile())
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Vor- und Nachlaufzeiten konnten" +
          " nicht gespseichert werden", System.Drawing.Color.Red);
        return false;
      }
      else
        return true;

    }

    private void Warnungen_Save_Click_1(object sender, EventArgs e)
    {
      //Einstellungen lokal speichern
      string[,] Warnungarray = new string[Einstellungen.DBBitzeichenfolge.GetLength(0), (int)Einstellungen.Kameraanzahl];

      for (int x = 0; x < WarnungenDataGridView.Rows.Count; x++)
      {
        for (int y = 1; y < (WarnungenDataGridView.ColumnCount); y++)
        {
          try
          {
            string CheckedCell = WarnungenDataGridView.Rows[x].Cells[y].Value.ToString();
            if (CheckedCell != null)
            {
              //nochmal abfragen, weil CheckedCell auch Reihennamen beinhaltet
              if (CheckedCell == "True")
                Warnungarray[x, y - 1] = "True";
              else
                Warnungarray[x, y - 1] = "False";
            }
          }
          catch
          {
            Warnungarray[x, y - 1] = "False";
          }
        }
      }
      Einstellungen.SPSWarnungsEinstellungArray = Warnungarray;
      //wenn die Kameranmeldungen erfolgreich gespeichert werden konnten, dann
      if (KameraMeldung_Saver())
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kameraeinstellungen für" +
          " Meldungen wurden gespeichert", System.Drawing.Color.White);
        Einstellungen.RefToMainForm.OpenhauptPrgrmStatus();
      }
    }
  }
}

