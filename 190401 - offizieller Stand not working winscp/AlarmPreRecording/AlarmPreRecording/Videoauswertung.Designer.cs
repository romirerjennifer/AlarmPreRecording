namespace AlarmPreRecording
{
  partial class Videoauswertung
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Videoauswertung));
      this.DisplayFile = new System.Windows.Forms.ListBox();
      this.BrowseVideo = new System.Windows.Forms.Button();
      this.WinMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
      ((System.ComponentModel.ISupportInitialize)(this.WinMediaPlayer)).BeginInit();
      this.SuspendLayout();
      // 
      // DisplayFile
      // 
      this.DisplayFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DisplayFile.FormattingEnabled = true;
      this.DisplayFile.Location = new System.Drawing.Point(399, 41);
      this.DisplayFile.Name = "DisplayFile";
      this.DisplayFile.Size = new System.Drawing.Size(169, 95);
      this.DisplayFile.TabIndex = 4;
      this.DisplayFile.SelectedIndexChanged += new System.EventHandler(this.DisplayFolder_SelectedIndexChanged);
      // 
      // BrowseVideo
      // 
      this.BrowseVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BrowseVideo.Location = new System.Drawing.Point(399, 142);
      this.BrowseVideo.Name = "BrowseVideo";
      this.BrowseVideo.Size = new System.Drawing.Size(75, 23);
      this.BrowseVideo.TabIndex = 3;
      this.BrowseVideo.Text = "&Open";
      this.BrowseVideo.UseVisualStyleBackColor = true;
      this.BrowseVideo.Click += new System.EventHandler(this.BrowseVideo_Click);
      // 
      // WinMediaPlayer
      // 
      this.WinMediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.WinMediaPlayer.Enabled = true;
      this.WinMediaPlayer.Location = new System.Drawing.Point(12, 12);
      this.WinMediaPlayer.Name = "WinMediaPlayer";
      this.WinMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WinMediaPlayer.OcxState")));
      this.WinMediaPlayer.Size = new System.Drawing.Size(381, 211);
      this.WinMediaPlayer.TabIndex = 5;
      // 
      // Videoauswertung
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(580, 235);
      this.Controls.Add(this.WinMediaPlayer);
      this.Controls.Add(this.DisplayFile);
      this.Controls.Add(this.BrowseVideo);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Videoauswertung";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Videoauswertung";
      ((System.ComponentModel.ISupportInitialize)(this.WinMediaPlayer)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button BrowseVideo;
    private AxWMPLib.AxWindowsMediaPlayer WinMediaPlayer;
    private System.Windows.Forms.ListBox DisplayFile;
  }
}