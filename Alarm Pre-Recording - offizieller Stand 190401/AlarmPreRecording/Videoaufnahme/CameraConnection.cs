using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace AlarmPreRecording
{
  public partial class CameraConnection : Form
  {
    public CameraConnection()
    {
      InitializeComponent();
      //Je nachdem wie oft man diese Form anzeigen muss, wird die KameraCntWindowsForm Variable erhöht und die Überschrift mit diesen Daten erstellt.
      //3 Kameras - 3 Aufrufe
      KameraNR.Text = "Kamera " + (Videoaufnahme.KameraCntWindowsForm + 1);
    }

    private void Next_Click(object sender, EventArgs e)
    {

      IPAddress IPADDRESSEref;
      if (!IPAddress.TryParse(IPadressTXTBox.Text, out IPADDRESSEref)) //parst den eingegeben Text in ein IP Adressenformat. Wenn dies OK ist wird weitergearbeitet
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Ungültige IP-Adresse", System.Drawing.Color.Red);
        return;

      }
      if (UsernameTXT.Text.Equals("")) //Username darf nicht leer sein
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bitte geben Sie einen Benutzernamen an", System.Drawing.Color.Red);
        return;
      }
      if (PasswordTxt.Text.Equals("")) //Passwort darf nicht leer sein
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Bitte geben Sie ein Passwort an", System.Drawing.Color.Red);
        return;
      }
      try
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Es wird eine Verbindung mit Kamera " + (Videoaufnahme.KameraCntWindowsForm + 1) + " hergestellt.", System.Drawing.Color.White);

        //Kamera wird mit den obigen Daten verbunden - geöffnete Session wird in Kameraverbindung gespeichert
        if (KameraVerbindung.ConnectCamera(IPADDRESSEref.ToString(), PasswordTxt.Text, UsernameTXT.Text, (int)Videoaufnahme.KameraCntWindowsForm))
        {
          //Setzt die Variable, wenn diese Kamera verbunden ist
          KameraVerbindung.KameraIPadressen[0, (int)Videoaufnahme.KameraCntWindowsForm] = IPADDRESSEref.ToString();
          KameraVerbindung.KameraIPadressen[1, (int)Videoaufnahme.KameraCntWindowsForm] = PasswordTxt.Text;
          KameraVerbindung.KameraIPadressen[2, (int)Videoaufnahme.KameraCntWindowsForm] = UsernameTXT.Text;
          
          Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Kamera " + (Videoaufnahme.KameraCntWindowsForm + 1) + " wurde verbunden.", System.Drawing.Color.Green);

          if ((Videoaufnahme.KameraCntWindowsForm + 1) < Einstellungen.Kameraanzahl)
          {  //Wenn die Kameraanzahl (Start bei 1) noch nicht von Kameracntwindowsform(start bei 0) erreicht wurde, lade die Form nochmal

            //Wenn Form geschlossen wird, wird die FormCntvariable erhöht.
            Videoaufnahme.KameraCntWindowsForm++;
            Einstellungen.ViewVideoAufnahme.CallConnection();
          }
          else
          {   // Wenn alle Kameraeinstellungen festgelegt worden sind, werden sie gespeichert - in das FIle ausgeschrieben
            if (!Einstellungen.SaveAllSettingsInFile()) //alle Einstellungen speichern 
              return;                                   //Wenn Speichern nicht erfolgreich
            Videoaufnahme.KameraCntWindowsForm = 0;      //Rücksetzen der Variable
            //sonst starte das SendenForm
            Einstellungen.ViewVideoAufnahme.CallSendFiles();
          }
        }
      }
      catch
      {
        Einstellungen.ViewVideoAufnahme.changeCurrentWorkStatus_Meldungsfeld_Videoaufnahme("Es konnte keine Verbindung zur Kamera hergestellt werden", System.Drawing.Color.Red);
        return;
      }
    }

    private void CameraConnection_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void CameraConnection_Load(object sender, EventArgs e)
    {
      //Wenn erstes Element nicht leer ist, sind andere Elemente auch nicht leer
      if (KameraVerbindung.KameraIPadressen[0, (int)Videoaufnahme.KameraCntWindowsForm] != null)
      {
        IPadressTXTBox.Text = KameraVerbindung.KameraIPadressen[0, (int)Videoaufnahme.KameraCntWindowsForm];
        PasswordTxt.Text = KameraVerbindung.KameraIPadressen[1, (int)Videoaufnahme.KameraCntWindowsForm];
        UsernameTXT.Text = KameraVerbindung.KameraIPadressen[2, (int)Videoaufnahme.KameraCntWindowsForm];
      }
    }
  }
}
