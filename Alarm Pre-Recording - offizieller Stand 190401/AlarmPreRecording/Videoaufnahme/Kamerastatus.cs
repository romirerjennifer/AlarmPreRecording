using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

using System.Runtime.InteropServices; //Um den Paramter optional zu machen 
namespace AlarmPreRecording
{
  public partial class Kamerastatus : Form
  {

    public static System.Timers.Timer TimerRefreshStatus = new System.Timers.Timer();
    private static DataGridView Kameradatagridref;
    public Kamerastatus()
    {
      InitializeComponent();
      Kameradatagridref = KameraStatusDataGridView; //Der Timer ist ein eigener Thread, weshalb diesem gesagt werden muss welches Kameradatagrid neu geladen werden soll

      //Wenn Timer durch andere Form gestoppt wurde, ist der Timer nicht mehr enabled - daher ...
      if (!TimerRefreshStatus.Enabled)
      {
        TimerRefreshStatus.Elapsed += new ElapsedEventHandler(RepaintForm);
        TimerRefreshStatus.Interval = 2000; //alle 2 sec Check ob Video fertig geschrieben wurde
                                            //Timer starten lassen, wenn die Form neu initialisiert wird - neu aufgemacht
        TimerRefreshStatus.Start(); //wird auch gestoppt und deaktiviert
      }
      //Load Datagridview 
      KameraStatusDataGridView.Columns.Add("Kameras", "Kameras");
      KameraStatusDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      KameraStatusDataGridView.Columns.Add("Status", "Status");
      KameraStatusDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      KameraStatusDataGridView.Columns[1].Width = 150;

      for (int kameracnt = 1; kameracnt <= Einstellungen.Kameraanzahl; kameracnt++)
      {
        KameraStatusDataGridView.Rows.Add("Kamera" + kameracnt, kameracnt);
      }
      KameraStatusDataGridView.Rows.Add("Trigger auf Meldungen", "Trigger auf Meldungen");
      RepaintForm(); //Laden der Inhalte

    }
    //[Optional] macht den Paramter optional, kann, muss aber nicht angegeben werden
    public void RepaintForm([Optional]object source, [Optional]ElapsedEventArgs e)
    {
      //load colour and text
      int rows;
      for (rows = 0; rows < Einstellungen.Kameraanzahl; rows++)
      {
        //Defaultaussehen der Zustände
        Kameradatagridref.Rows[rows].Cells[1].Value = "Gestoppt";
        Kameradatagridref.Rows[rows].Cells[1].Style.BackColor = Color.Red;
        //wenn die Kamera vor dem Klicken des Menüpunktes verbunden ist, wird die jeweilige Farbe angezeigt
        if (Videoaufnahme.KameraXIsConnected != null)
        {
          if (Videoaufnahme.KameraXIsConnected[rows] == true)
          {
            Kameradatagridref.Rows[rows].Cells[1].Value = "Gestartet";
            Kameradatagridref.Rows[rows].Cells[1].Style.BackColor = Color.Lime;
          }
        }

      }
      //Trigger bei Meldungen anzeigen lassen
      if (Datenbaustein.Meldungstrigger_aktiv) //Variable wird mit Timeraktivirung gesetzt 
      {
        //Reihen müssen nicht mehr inkrementiert werden, damit man unter die letzte Reihe der Kameras kommt, weil rows++ rows bereits inkremetiert hat bevor Überprüfung stattfindet
        Kameradatagridref.Rows[rows].Cells[1].Value = "Aktiv";
        Kameradatagridref.Rows[rows].Cells[1].Style.BackColor = Color.Lime;
      }
      else
      {
        Kameradatagridref.Rows[rows].Cells[1].Value = "Inaktiv";
        Kameradatagridref.Rows[rows].Cells[1].Style.BackColor = Color.Red;

      }
    }

  }
}

