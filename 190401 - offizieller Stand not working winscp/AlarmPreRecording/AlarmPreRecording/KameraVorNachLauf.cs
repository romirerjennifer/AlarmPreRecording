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
using System.Globalization;
namespace AlarmPreRecording
{
  public partial class KameraVorNachLauf : Form
  {
    public KameraVorNachLauf()
    {
      InitializeComponent();


    }
    //######################VORNACHLAUF########################
    private void KameraVorNachLauf_Load(object sender, EventArgs e)
    {
      DataTable VorNachLaufTable = new DataTable();
      VorNachLaufTable.Columns.Add("Kamera", typeof(string));

      //dynamisch die Reihen erstellen, je nachdem wie viele Kameras benötigt werden
      for (int kameracnt = 1; kameracnt <= Einstellungen.Kameraanzahl; kameracnt++)
      {
        VorNachLaufTable.Rows.Add("Kamera " + kameracnt);
      }

      VorNachLaufTable.Columns.Add("Vorlaufzeit der Kameraufnahme [in Sekunden]", typeof(string));

      VorNachLaufTable.Columns.Add("Nachlaufzeit der Kameraufnahme [in Sekunden]", typeof(string));

      VorNachDataGrid.DataSource = VorNachLaufTable;
      //Die erste Spalte - die Namen der Merkerbits - dürfen nicht verändert werden
      VorNachDataGrid.Columns[0].ReadOnly = true;



      //Wenn Einstellungen bereits existieren - anzeigen lassen
      if (Einstellungen.SPSVorNachLaufArray != null)
      {
        for (int rows = 0; rows < Einstellungen.SPSVorNachLaufArray.GetLength(0); rows++)
        {
          //Das Zählen der Spalten beginnt erst ab 1, weil die 1. Spalte eine Überschriftenspalte ist 
          //und nicht überprüft werden soll.
          for (int col = 1; col <= Einstellungen.SPSVorNachLaufArray.GetLength(1); col++)
          {
            VorNachDataGrid.Rows[rows].Cells[col].Value = Einstellungen.SPSVorNachLaufArray[rows, col - 1];
          }
        }
      }
    }

    //VorNachLaufZeiten im File speichern
    public static void VorNachLauf_Saver()
    {
      if (AlarmPreRecMain.projektFolderPath == null)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projekt angegeben! " +
          "Erstellen Sie ein neues oder laden Sie ein bereits vorhandenes Projekt", System.Drawing.Color.Red);
        return;
      }
      Einstellungen.SaveAllSettingsInFile(); //ins File auslagern
    }
    //Speichern der Kamerazeiten 
    private void VorNachLauf_Save_Click_1(object sender, EventArgs e)
    {
      //Zeiten lokal speichern
      string[,] VorNachLaufArray = new string[(int)Einstellungen.Kameraanzahl, 2];
      int col;
      //Überprüfen der Eingabe auf unzulässige Zeichen (nur Zahlen sind zulässig)
      for (int rows = 0; rows < VorNachDataGrid.Rows.Count; rows++)
      {
        //Das Zählen der Spalten beginnt erst ab 1, weil die 1. Spalte eine Überschriftenspalte ist und 
        //nicht überprüft werden soll.
        for (col = 1; col < VorNachDataGrid.Rows[rows].Cells.Count; col++)
        {
          string value = VorNachDataGrid.Rows[rows].Cells[col].Value.ToString();
          VorNachLaufArray[rows, col - 1] = value;


          //Überprüfen, ob nur Zahlen vorhanden sind
          //isNumeric = True - wenn erfolgreich konvertiert wurde
          //isNumeric = False - wenn in 'value' ungültige Zeichen (Buchstaben, Sonderzeichen) vorhanden 
          //sind oder dieser leer ist
          //nur positive Zahlen
          bool isNumeric = Int32.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture,
            out int resultplacebo);

          if (!isNumeric)
          {
            Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Ungültige Eingabe", 
              System.Drawing.Color.Red);
            VorNachLaufArray = null;
            return;
          }
          if (Int32.Parse(value) == 0)
          {
            Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kamerazeiten dürfen nicht 0 sein", System.Drawing.Color.Red);
            VorNachLaufArray = null;
            return;

          }
        }
        //Zeilenweise max Zeit berechnen - maximal 60 sec
        if ((Int32.Parse(VorNachDataGrid.Rows[rows].Cells[col - 2].Value.ToString()) +
          Int32.Parse(VorNachDataGrid.Rows[rows].Cells[col - 1].Value.ToString())) > 60)
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Das Video der Kamera " +
            (rows + 1) + " darf maximal 60 Sekunden lang sein", System.Drawing.Color.Red);
          VorNachLaufArray = null;
          return;
        }
      }
      //Vor und Nachlaufzeiten lokal speichern
      Einstellungen.SPSVorNachLaufArray = VorNachLaufArray;
      VorNachLauf_Saver();
      Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Zeiten wurden erfolgreich" +
        " gespeichert", System.Drawing.Color.LightGreen);
      Einstellungen.RefToMainForm.OpenhauptPrgrmStatus();
    }

    private void VorNachDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      checkCellValue(sender, e);

    }

    private void checkCellValue(object sender, DataGridViewCellEventArgs e)
    {

      if (e.ColumnIndex == VorNachDataGrid.Columns[2].Index || e.ColumnIndex == VorNachDataGrid.Columns[1].Index)
      {
        //Überprüfen, ob nur Zahlen vorhanden sind
        //isNumeric = True - wenn erfolgreich konvertiert wurde
        //isNumeric = False - wenn in 'value' ungültige Zeichen (Buchstaben, Sonderzeichen) vorhanden sind oder dieser leer ist
        //nur positive Zahlen
        bool isNumeric = Int32.TryParse(VorNachDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.None, CultureInfo.InvariantCulture, out int resultplacebo);

        if (!isNumeric)
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Ungültige Eingabe bei Kamera " + (e.RowIndex + 1), System.Drawing.Color.Red);
          return;
        }
        if (Int32.Parse(VorNachDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == 0)
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kamerazeiten dürfen nicht 0 sein", System.Drawing.Color.Red);
          return;
        }

      }
    }
    private void VorNachDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

  }
}
