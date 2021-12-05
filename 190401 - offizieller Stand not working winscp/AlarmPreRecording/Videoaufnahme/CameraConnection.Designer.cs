namespace AlarmPreRecording
{
  partial class CameraConnection
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Next = new System.Windows.Forms.Button();
      this.RPIIP = new System.Windows.Forms.Label();
      this.IPadressTXTBox = new System.Windows.Forms.TextBox();
      this.PasswordTxt = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.UsernameTXT = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.KameraNR = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // Next
      // 
      this.Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Next.Location = new System.Drawing.Point(502, 196);
      this.Next.Name = "Next";
      this.Next.Size = new System.Drawing.Size(65, 23);
      this.Next.TabIndex = 20;
      this.Next.Text = "Weiter";
      this.Next.UseVisualStyleBackColor = true;
      this.Next.Click += new System.EventHandler(this.Next_Click);
      // 
      // RPIIP
      // 
      this.RPIIP.AutoSize = true;
      this.RPIIP.Location = new System.Drawing.Point(12, 69);
      this.RPIIP.Name = "RPIIP";
      this.RPIIP.Size = new System.Drawing.Size(282, 13);
      this.RPIIP.TabIndex = 11;
      this.RPIIP.Text = "IP-Adresse des RasperryPIs der Kamera (z.B: 192.168.1.1)";
      // 
      // IPadressTXTBox
      // 
      this.IPadressTXTBox.Location = new System.Drawing.Point(393, 66);
      this.IPadressTXTBox.Name = "IPadressTXTBox";
      this.IPadressTXTBox.Size = new System.Drawing.Size(174, 20);
      this.IPadressTXTBox.TabIndex = 12;
      this.IPadressTXTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // PasswordTxt
      // 
      this.PasswordTxt.Location = new System.Drawing.Point(393, 147);
      this.PasswordTxt.Name = "PasswordTxt";
      this.PasswordTxt.PasswordChar = '*';
      this.PasswordTxt.Size = new System.Drawing.Size(174, 20);
      this.PasswordTxt.TabIndex = 16;
      this.PasswordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 154);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(133, 13);
      this.label1.TabIndex = 13;
      this.label1.Text = "Password des RasperryPIs";
      // 
      // UsernameTXT
      // 
      this.UsernameTXT.Location = new System.Drawing.Point(393, 105);
      this.UsernameTXT.Name = "UsernameTXT";
      this.UsernameTXT.Size = new System.Drawing.Size(174, 20);
      this.UsernameTXT.TabIndex = 14;
      this.UsernameTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 108);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(155, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Benutzername des RasperryPIs";
      // 
      // KameraNR
      // 
      this.KameraNR.AutoSize = true;
      this.KameraNR.Location = new System.Drawing.Point(243, 9);
      this.KameraNR.Name = "KameraNR";
      this.KameraNR.Size = new System.Drawing.Size(46, 13);
      this.KameraNR.TabIndex = 17;
      this.KameraNR.Text = "Kamera ";
      this.KameraNR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // CameraConnection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.KameraNR);
      this.Controls.Add(this.UsernameTXT);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.PasswordTxt);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.IPadressTXTBox);
      this.Controls.Add(this.RPIIP);
      this.Controls.Add(this.Next);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximumSize = new System.Drawing.Size(579, 231);
      this.Name = "CameraConnection";
      this.Text = "CameraConnection";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CameraConnection_FormClosed);
      this.Load += new System.EventHandler(this.CameraConnection_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button Next;
    private System.Windows.Forms.Label RPIIP;
    private System.Windows.Forms.TextBox IPadressTXTBox;
    private System.Windows.Forms.TextBox PasswordTxt;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox UsernameTXT;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label KameraNR;
  }
}