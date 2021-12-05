namespace AlarmPreRecording
{
  partial class CameraSendFiles
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
      this.SendFiles = new System.Windows.Forms.Label();
      this.sendFiless = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // SendFiles
      // 
      this.SendFiles.AutoSize = true;
      this.SendFiles.Location = new System.Drawing.Point(13, 13);
      this.SendFiles.Name = "SendFiles";
      this.SendFiles.Size = new System.Drawing.Size(242, 13);
      this.SendFiles.TabIndex = 0;
      this.SendFiles.Text = "Alle Dateien zu den zugehörigen Kameras senden";
      // 
      // sendFiless
      // 
      this.sendFiless.Location = new System.Drawing.Point(492, 12);
      this.sendFiless.Name = "sendFiless";
      this.sendFiless.Size = new System.Drawing.Size(75, 23);
      this.sendFiless.TabIndex = 1;
      this.sendFiless.Text = "Senden";
      this.sendFiless.UseVisualStyleBackColor = true;
      this.sendFiless.Click += new System.EventHandler(this.sendFiless_Click);
      // 
      // CameraSendFiles
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.sendFiless);
      this.Controls.Add(this.SendFiles);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximumSize = new System.Drawing.Size(579, 231);
      this.Name = "CameraSendFiles";
      this.Text = "CameraSendFiles";
      this.Load += new System.EventHandler(this.CameraSendFiles_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label SendFiles;
    private System.Windows.Forms.Button sendFiless;
  }
}