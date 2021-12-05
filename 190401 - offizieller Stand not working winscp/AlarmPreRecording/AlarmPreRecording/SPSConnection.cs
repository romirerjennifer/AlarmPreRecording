using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accon.AGLink;
using System.IO;

namespace AlarmPreRecording
{
  public partial class SPSConnection : Form
  {
    public static IAGLink4 Ag_connection { get; private set; } = null;

    public SPSConnection()
    {
      InitializeComponent();
      //überprüft, ob ConfigFile schon existiert, Nachsehen in Projektpfad
      bool configExistsAlready = File.Exists(AlarmPreRecMain.projektFolderPath + "\\AGLink40CfgDev0000.xml");
      //wenn obiges File existiert, wird der Verbinden Button freigeschalten, sonst muss man manuelle 
      //Verbindung hergestellt werden
      buttonVerb.Enabled = configExistsAlready;
    }

    private static Int32 devNr = 0;
    private static Int32 plcNr = 0;            //ist variabel
    public static Int32 timeout = 3000; //Standard timeout - ist variabel
    private Int32 resConf;
    private Button buttonConf;



    private void buttonConf_Click_1(object sender, EventArgs e)
    {
      if (AlarmPreRecMain.projektFolderPath == null)
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Kein Projekt angegeben! Erstellen Sie ein neues oder laden Sie ein " +
          "bereits vorhandenes Projekt", System.Drawing.Color.Red);
        return;
      }
      //Öffnen des AGLink Verbindungskonfigurators
      resConf = AGL4.ConfigEx(devNr, "-f -p=\"" + AlarmPreRecMain.projektFolderPath + "\"");
      //Pfad für Speichern der Verbindungsdaten
      AGL4.SetParaPath(AlarmPreRecMain.projektFolderPath);

      //AGLink konnte erfolgreich eine Probeverbindung herstellen. Die Einstellungen passen für AGLINK
      if (resConf == AGL4.AGL40_SUCCESS)
      {
        buttonVerb.Enabled = true;
      }
      else
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("Konfigurator konnte nicht " +
          "ausgeführt werden", System.Drawing.Color.Red);
      }
    }
    private void buttonVerb_Click(object sender, EventArgs e)
    {
      if (ConnectSPS())
        Einstellungen.RefToMainForm.OpenhauptPrgrmStatus();
    }
    public static bool CheckifConnected()
    {
      if (Ag_connection != null)
      { if (Ag_connection.Connected)
        {
          if (AGL4.AGL40_SUCCESS != Datenbaustein.ReadBitFromDatenBaustein(0, SPSConnection.timeout, Int16.Parse(Einstellungen.DBBitzeichenfolge[0, 1]), Int16.Parse(Einstellungen.DBBitzeichenfolge[0, 2]), Int16.Parse(Einstellungen.DBBitzeichenfolge[0, 3])))
          {//SPS nicht mehr verbunden
            return false;
          }
         else
          {
            //sps ist verbunden
            return true;
          }
        }
      }
      return false;
    }
    public static bool ConnectSPS()
    {
      if (Ag_connection != null)
        if (Ag_connection.Connected)
        {
          Datenbaustein.ReadBitFromDatenBaustein(0, SPSConnection.timeout, Int16.Parse(Einstellungen.DBBitzeichenfolge[0, 1]), Int16.Parse(Einstellungen.DBBitzeichenfolge[0, 2]), Int16.Parse(Einstellungen.DBBitzeichenfolge[0, 3]));
          DisconnectSPS();
        }
      //Pfad für Speichern der Verbindungsdaten
      AGL4.SetParaPath(AlarmPreRecMain.projektFolderPath);

      //Instanz wird hergestellt um eine Verbindung mit diesen Daten möglich zu machen
      if (Ag_connection == null)
        Ag_connection = AGL4ConnectionFactory.CreateInstance(devNr, plcNr, timeout);
      try
      {
        bool result = false;
        //Verbindungsaufbau 
        result = Ag_connection.Connect();

        if (!result)
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("SPS-Verbindung konnte nicht " +
            "hergestellt werden", System.Drawing.Color.Red);

          return false;
        }
        else
        {
          Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("SPS-Verbindung wurde " +
            "erfolgreich hergestellt", System.Drawing.Color.White);
          return true;
        }
      }
      catch
      {
        Einstellungen.RefToMainForm.changeCurrentWorkStatus_Meldungsfeld("SPS-Verbindung konnte nicht hergestellt werden",
          System.Drawing.Color.Red);
        return false;

      }
    }
    public static void DisconnectSPS()
    {
      //Wenn die AGLINK Connection nie aufgerufen wurde können die dazugehörigen Variablen nicht gelesen
      //und somit auch nicht verarbeitet werden
      try
      {
        if (Ag_connection.Connected)
          Ag_connection.Disconnect();

      }
      catch
      {

      }
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      plcNr = (int)numericUpDown1.Value;
    }

    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
    {
      timeout = (int)numericUpDown2.Value;
    }

  }

}
