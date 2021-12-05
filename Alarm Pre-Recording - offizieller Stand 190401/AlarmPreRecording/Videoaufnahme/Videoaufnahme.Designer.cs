namespace AlarmPreRecording
{
  partial class Videoaufnahme
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Videoaufnahme));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.closeprogram = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.verbindungZuDenKamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rasperryEinstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.vorNachlaufzeitenFilesSendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.kamerastatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.videoaufnahmeStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.videoausgabeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.Panel_Switch = new System.Windows.Forms.Panel();
      this.CurrentWorkStatus_Videoaufnahme = new System.Windows.Forms.TextBox();
      this.ClearMeldungsfenster_Videoaufnahme = new System.Windows.Forms.Button();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.AllowMerge = false;
      this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.menuStrip.BackColor = System.Drawing.Color.Transparent;
      this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeprogram,
            this.verbindungZuDenKamerasToolStripMenuItem,
            this.kamerastatusToolStripMenuItem,
            this.videoaufnahmeStartenToolStripMenuItem,
            this.videoausgabeToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(9, 9);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(519, 24);
      this.menuStrip.TabIndex = 2;
      this.menuStrip.Text = "menuStrip1";
      // 
      // closeprogram
      // 
      this.closeprogram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
      this.closeprogram.Name = "closeprogram";
      this.closeprogram.Size = new System.Drawing.Size(46, 20);
      this.closeprogram.Text = "Datei";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
      this.toolStripMenuItem1.Text = "Home";
      this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
      // 
      // beendenToolStripMenuItem
      // 
      this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
      this.beendenToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
      this.beendenToolStripMenuItem.Text = "Alles Beenden";
      this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
      // 
      // verbindungZuDenKamerasToolStripMenuItem
      // 
      this.verbindungZuDenKamerasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rasperryEinstellungenToolStripMenuItem,
            this.vorNachlaufzeitenFilesSendenToolStripMenuItem});
      this.verbindungZuDenKamerasToolStripMenuItem.Name = "verbindungZuDenKamerasToolStripMenuItem";
      this.verbindungZuDenKamerasToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
      this.verbindungZuDenKamerasToolStripMenuItem.Text = "Verbindung zu den Kameras";
      // 
      // rasperryEinstellungenToolStripMenuItem
      // 
      this.rasperryEinstellungenToolStripMenuItem.Name = "rasperryEinstellungenToolStripMenuItem";
      this.rasperryEinstellungenToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
      this.rasperryEinstellungenToolStripMenuItem.Text = "Rasperry Einstellungen";
      this.rasperryEinstellungenToolStripMenuItem.Click += new System.EventHandler(this.rasperryEinstellungenToolStripMenuItem_Click);
      // 
      // vorNachlaufzeitenFilesSendenToolStripMenuItem
      // 
      this.vorNachlaufzeitenFilesSendenToolStripMenuItem.Name = "vorNachlaufzeitenFilesSendenToolStripMenuItem";
      this.vorNachlaufzeitenFilesSendenToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
      this.vorNachlaufzeitenFilesSendenToolStripMenuItem.Text = "Vor-Nachlaufzeiten Files senden";
      this.vorNachlaufzeitenFilesSendenToolStripMenuItem.Click += new System.EventHandler(this.vorNachlaufzeitenFilesSendenToolStripMenuItem_Click);
      // 
      // kamerastatusToolStripMenuItem
      // 
      this.kamerastatusToolStripMenuItem.Name = "kamerastatusToolStripMenuItem";
      this.kamerastatusToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
      this.kamerastatusToolStripMenuItem.Text = "Kamerastatus";
      this.kamerastatusToolStripMenuItem.Click += new System.EventHandler(this.kamerastatusToolStripMenuItem_Click);
      // 
      // videoaufnahmeStartenToolStripMenuItem
      // 
      this.videoaufnahmeStartenToolStripMenuItem.Name = "videoaufnahmeStartenToolStripMenuItem";
      this.videoaufnahmeStartenToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
      this.videoaufnahmeStartenToolStripMenuItem.Text = "APR Einstellungen";
      this.videoaufnahmeStartenToolStripMenuItem.Click += new System.EventHandler(this.ZurueckZuDenEinstellungenToolStripMenuItem_Click);
      // 
      // videoausgabeToolStripMenuItem
      // 
      this.videoausgabeToolStripMenuItem.Name = "videoausgabeToolStripMenuItem";
      this.videoausgabeToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
      this.videoausgabeToolStripMenuItem.Text = "Videoausgabe";
      this.videoausgabeToolStripMenuItem.Click += new System.EventHandler(this.videoausgabeToolStripMenuItem_Click);
      // 
      // Panel_Switch
      // 
      this.Panel_Switch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.Panel_Switch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Panel_Switch.BackColor = System.Drawing.Color.White;
      this.Panel_Switch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_Switch.BackgroundImage")));
      this.Panel_Switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.Panel_Switch.Location = new System.Drawing.Point(0, 37);
      this.Panel_Switch.MaximumSize = new System.Drawing.Size(580, 226);
      this.Panel_Switch.Name = "Panel_Switch";
      this.Panel_Switch.Size = new System.Drawing.Size(580, 226);
      this.Panel_Switch.TabIndex = 5;
      // 
      // CurrentWorkStatus_Videoaufnahme
      // 
      this.CurrentWorkStatus_Videoaufnahme.BackColor = System.Drawing.Color.White;
      this.CurrentWorkStatus_Videoaufnahme.Location = new System.Drawing.Point(0, 269);
      this.CurrentWorkStatus_Videoaufnahme.MaximumSize = new System.Drawing.Size(580, 20);
      this.CurrentWorkStatus_Videoaufnahme.Name = "CurrentWorkStatus_Videoaufnahme";
      this.CurrentWorkStatus_Videoaufnahme.ReadOnly = true;
      this.CurrentWorkStatus_Videoaufnahme.Size = new System.Drawing.Size(508, 20);
      this.CurrentWorkStatus_Videoaufnahme.TabIndex = 6;
      this.CurrentWorkStatus_Videoaufnahme.TextChanged += new System.EventHandler(this.CurrentWorkStatus_Videoaufnahme_TextChanged);
      // 
      // ClearMeldungsfenster_Videoaufnahme
      // 
      this.ClearMeldungsfenster_Videoaufnahme.Location = new System.Drawing.Point(505, 267);
      this.ClearMeldungsfenster_Videoaufnahme.Name = "ClearMeldungsfenster_Videoaufnahme";
      this.ClearMeldungsfenster_Videoaufnahme.Size = new System.Drawing.Size(75, 23);
      this.ClearMeldungsfenster_Videoaufnahme.TabIndex = 7;
      this.ClearMeldungsfenster_Videoaufnahme.Text = "Clear";
      this.ClearMeldungsfenster_Videoaufnahme.UseVisualStyleBackColor = true;
      this.ClearMeldungsfenster_Videoaufnahme.Click += new System.EventHandler(this.ClearMeldungsfenster_Videoaufnahme_Click);
      // 
      // Videoaufnahme
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(581, 293);
      this.Controls.Add(this.ClearMeldungsfenster_Videoaufnahme);
      this.Controls.Add(this.CurrentWorkStatus_Videoaufnahme);
      this.Controls.Add(this.Panel_Switch);
      this.Controls.Add(this.menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(597, 332);
      this.MinimumSize = new System.Drawing.Size(597, 332);
      this.Name = "Videoaufnahme";
      this.Text = "Videoaufnahme";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Videoaufnahme_FormClosing);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem closeprogram;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem videoaufnahmeStartenToolStripMenuItem;
    private System.Windows.Forms.Panel Panel_Switch;
    private System.Windows.Forms.ToolStripMenuItem verbindungZuDenKamerasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem vorNachlaufzeitenFilesSendenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rasperryEinstellungenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem kamerastatusToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem videoausgabeToolStripMenuItem;
    private System.Windows.Forms.TextBox CurrentWorkStatus_Videoaufnahme;
    private System.Windows.Forms.Button ClearMeldungsfenster_Videoaufnahme;
  }
}