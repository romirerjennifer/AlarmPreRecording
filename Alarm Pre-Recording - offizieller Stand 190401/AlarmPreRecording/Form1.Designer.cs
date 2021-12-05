namespace AlarmPreRecording
{
  partial class AlarmPreRecMain
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmPreRecMain));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.closeprogram = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.projektErstellenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.projektLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.anleitungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.kamerakonfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.anzahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.kamerazuweisungWarnungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sPSKonfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sPSVerbindungStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.datenbausteineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.VideoauswertungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.videoaufnahmeStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.Panel_Switch = new System.Windows.Forms.Panel();
      this.CurrentWorkStatus = new System.Windows.Forms.TextBox();
      this.ClearMeldungsfenster = new System.Windows.Forms.Button();
      this.HauptprgrmStatus = new System.Windows.Forms.ToolStripMenuItem();
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
            this.kamerakonfigurationToolStripMenuItem,
            this.sPSKonfigurationToolStripMenuItem,
            this.VideoauswertungToolStripMenuItem,
            this.videoaufnahmeStartenToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(9, 9);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(534, 24);
      this.menuStrip.TabIndex = 1;
      this.menuStrip.Text = "menuStrip1";
      // 
      // closeprogram
      // 
      this.closeprogram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.HauptprgrmStatus,
            this.toolStripSeparator1,
            this.projektErstellenToolStripMenuItem,
            this.projektLadenToolStripMenuItem,
            this.toolStripSeparator3,
            this.anleitungToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.toolStripSeparator2,
            this.beendenToolStripMenuItem});
      this.closeprogram.Name = "closeprogram";
      this.closeprogram.Size = new System.Drawing.Size(46, 20);
      this.closeprogram.Text = "Datei";
      this.closeprogram.Click += new System.EventHandler(this.closeprogram_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
      this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
      this.toolStripMenuItem1.Text = "Home";
      this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
      // 
      // projektErstellenToolStripMenuItem
      // 
      this.projektErstellenToolStripMenuItem.Name = "projektErstellenToolStripMenuItem";
      this.projektErstellenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
      this.projektErstellenToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.projektErstellenToolStripMenuItem.Text = "Projekt erstellen";
      this.projektErstellenToolStripMenuItem.Click += new System.EventHandler(this.projektErstellenToolStripMenuItem_Click);
      // 
      // projektLadenToolStripMenuItem
      // 
      this.projektLadenToolStripMenuItem.Name = "projektLadenToolStripMenuItem";
      this.projektLadenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
      this.projektLadenToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.projektLadenToolStripMenuItem.Text = "Projekt laden";
      this.projektLadenToolStripMenuItem.Click += new System.EventHandler(this.projektLadenToolStripMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
      // 
      // anleitungToolStripMenuItem
      // 
      this.anleitungToolStripMenuItem.Name = "anleitungToolStripMenuItem";
      this.anleitungToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.anleitungToolStripMenuItem.Text = "Anleitung";
      this.anleitungToolStripMenuItem.Click += new System.EventHandler(this.anleitungToolStripMenuItem_Click);
      // 
      // infoToolStripMenuItem
      // 
      this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
      this.infoToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.infoToolStripMenuItem.Text = "Info";
      this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
      // 
      // beendenToolStripMenuItem
      // 
      this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
      this.beendenToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.beendenToolStripMenuItem.Text = "Beenden";
      this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
      // 
      // kamerakonfigurationToolStripMenuItem
      // 
      this.kamerakonfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anzahlToolStripMenuItem,
            this.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem,
            this.kamerazuweisungWarnungenToolStripMenuItem});
      this.kamerakonfigurationToolStripMenuItem.Name = "kamerakonfigurationToolStripMenuItem";
      this.kamerakonfigurationToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
      this.kamerakonfigurationToolStripMenuItem.Text = "Kamerakonfiguration";
      // 
      // anzahlToolStripMenuItem
      // 
      this.anzahlToolStripMenuItem.Name = "anzahlToolStripMenuItem";
      this.anzahlToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
      this.anzahlToolStripMenuItem.Text = "Anzahl der Kameras";
      this.anzahlToolStripMenuItem.Click += new System.EventHandler(this.anzahlToolStripMenuItem_Click);
      // 
      // vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem
      // 
      this.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem.Name = "vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem";
      this.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
      this.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem.Text = "Vorlaufzeit und Nachlaufzeit der Kamera";
      this.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem.Click += new System.EventHandler(this.vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem_Click);
      // 
      // kamerazuweisungWarnungenToolStripMenuItem
      // 
      this.kamerazuweisungWarnungenToolStripMenuItem.Name = "kamerazuweisungWarnungenToolStripMenuItem";
      this.kamerazuweisungWarnungenToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
      this.kamerazuweisungWarnungenToolStripMenuItem.Text = "Kamerazuweisung Meldung";
      this.kamerazuweisungWarnungenToolStripMenuItem.Click += new System.EventHandler(this.kamerazuweisungWarnungenToolStripMenuItem_Click);
      // 
      // sPSKonfigurationToolStripMenuItem
      // 
      this.sPSKonfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sPSVerbindungStripMenuItem,
            this.datenbausteineToolStripMenuItem});
      this.sPSKonfigurationToolStripMenuItem.Name = "sPSKonfigurationToolStripMenuItem";
      this.sPSKonfigurationToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
      this.sPSKonfigurationToolStripMenuItem.Text = "SPS Konfiguration";
      // 
      // sPSVerbindungStripMenuItem
      // 
      this.sPSVerbindungStripMenuItem.Name = "sPSVerbindungStripMenuItem";
      this.sPSVerbindungStripMenuItem.Size = new System.Drawing.Size(158, 22);
      this.sPSVerbindungStripMenuItem.Text = "SPS Verbindung";
      this.sPSVerbindungStripMenuItem.Click += new System.EventHandler(this.sPSVerbindungStripMenuItem_Click);
      // 
      // datenbausteineToolStripMenuItem
      // 
      this.datenbausteineToolStripMenuItem.Name = "datenbausteineToolStripMenuItem";
      this.datenbausteineToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
      this.datenbausteineToolStripMenuItem.Text = "Datenbausteine";
      this.datenbausteineToolStripMenuItem.Click += new System.EventHandler(this.datenbausteineToolStripMenuItem_Click);
      // 
      // VideoauswertungToolStripMenuItem
      // 
      this.VideoauswertungToolStripMenuItem.Name = "VideoauswertungToolStripMenuItem";
      this.VideoauswertungToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
      this.VideoauswertungToolStripMenuItem.Text = "Videoausgabe";
      this.VideoauswertungToolStripMenuItem.Click += new System.EventHandler(this.videoauswertungToolStripMenuItem_Click);
      // 
      // videoaufnahmeStartenToolStripMenuItem
      // 
      this.videoaufnahmeStartenToolStripMenuItem.Name = "videoaufnahmeStartenToolStripMenuItem";
      this.videoaufnahmeStartenToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
      this.videoaufnahmeStartenToolStripMenuItem.Text = "Videoaufnahme starten";
      this.videoaufnahmeStartenToolStripMenuItem.Click += new System.EventHandler(this.videoaufnahmeStartenToolStripMenuItem_Click);
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
      this.Panel_Switch.Location = new System.Drawing.Point(-1, 36);
      this.Panel_Switch.MaximumSize = new System.Drawing.Size(580, 226);
      this.Panel_Switch.Name = "Panel_Switch";
      this.Panel_Switch.Size = new System.Drawing.Size(580, 226);
      this.Panel_Switch.TabIndex = 1;
      this.Panel_Switch.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Switch_Paint);
      // 
      // CurrentWorkStatus
      // 
      this.CurrentWorkStatus.BackColor = System.Drawing.Color.White;
      this.CurrentWorkStatus.Location = new System.Drawing.Point(-1, 268);
      this.CurrentWorkStatus.MaximumSize = new System.Drawing.Size(580, 20);
      this.CurrentWorkStatus.Name = "CurrentWorkStatus";
      this.CurrentWorkStatus.ReadOnly = true;
      this.CurrentWorkStatus.Size = new System.Drawing.Size(508, 20);
      this.CurrentWorkStatus.TabIndex = 2;
      this.CurrentWorkStatus.TextChanged += new System.EventHandler(this.CurrentWorkStatus_TextChanged);
      // 
      // ClearMeldungsfenster
      // 
      this.ClearMeldungsfenster.Location = new System.Drawing.Point(504, 266);
      this.ClearMeldungsfenster.Name = "ClearMeldungsfenster";
      this.ClearMeldungsfenster.Size = new System.Drawing.Size(75, 23);
      this.ClearMeldungsfenster.TabIndex = 3;
      this.ClearMeldungsfenster.Text = "Clear";
      this.ClearMeldungsfenster.UseVisualStyleBackColor = true;
      this.ClearMeldungsfenster.Click += new System.EventHandler(this.ClearMeldungsfenster_Click);
      // 
      // HauptprgrmStatus
      // 
      this.HauptprgrmStatus.Name = "HauptprgrmStatus";
      this.HauptprgrmStatus.Size = new System.Drawing.Size(200, 22);
      this.HauptprgrmStatus.Text = "Hauptprogramm Status";
      this.HauptprgrmStatus.Click += new System.EventHandler(this.HauptprgrmStatus_Click);
      // 
      // AlarmPreRecMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(581, 293);
      this.Controls.Add(this.ClearMeldungsfenster);
      this.Controls.Add(this.CurrentWorkStatus);
      this.Controls.Add(this.Panel_Switch);
      this.Controls.Add(this.menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(597, 332);
      this.Name = "AlarmPreRecMain";
      this.Text = "Alarm Pre-Recording";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmPreRecMain_FormClosing);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem closeprogram;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem projektErstellenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem projektLadenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem kamerakonfigurationToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sPSKonfigurationToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem anzahlToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem vorlaufzeitUndNachlaufzeitDerKameraToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem kamerazuweisungWarnungenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sPSVerbindungStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem datenbausteineToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem VideoauswertungToolStripMenuItem;
    private System.Windows.Forms.Panel Panel_Switch;
    private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem videoaufnahmeStartenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem anleitungToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.TextBox CurrentWorkStatus;
    private System.Windows.Forms.Button ClearMeldungsfenster;
    private System.Windows.Forms.ToolStripMenuItem HauptprgrmStatus;
  }
}

