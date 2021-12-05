namespace AlarmPreRecording
{
  partial class KameraWarnung
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
      this.Warnungen_Save = new System.Windows.Forms.Button();
      this.WarnungenDataGridView = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.WarnungenDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // Warnungen_Save
      // 
      this.Warnungen_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Warnungen_Save.Location = new System.Drawing.Point(495, 203);
      this.Warnungen_Save.Name = "Warnungen_Save";
      this.Warnungen_Save.Size = new System.Drawing.Size(75, 23);
      this.Warnungen_Save.TabIndex = 5;
      this.Warnungen_Save.Text = "Speichern";
      this.Warnungen_Save.UseVisualStyleBackColor = true;
      this.Warnungen_Save.Click += new System.EventHandler(this.Warnungen_Save_Click_1);
      // 
      // WarnungenDataGridView
      // 
      this.WarnungenDataGridView.AllowUserToAddRows = false;
      this.WarnungenDataGridView.AllowUserToDeleteRows = false;
      this.WarnungenDataGridView.AllowUserToResizeColumns = false;
      this.WarnungenDataGridView.AllowUserToResizeRows = false;
      this.WarnungenDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.WarnungenDataGridView.BackgroundColor = System.Drawing.Color.White;
      this.WarnungenDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.WarnungenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.WarnungenDataGridView.Location = new System.Drawing.Point(-4, 2);
      this.WarnungenDataGridView.Name = "WarnungenDataGridView";
      this.WarnungenDataGridView.Size = new System.Drawing.Size(581, 207);
      this.WarnungenDataGridView.TabIndex = 1;
      // 
      // KameraWarnung
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(580, 235);
      this.Controls.Add(this.Warnungen_Save);
      this.Controls.Add(this.WarnungenDataGridView);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "KameraWarnung";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "KameraWarnung";
      this.Load += new System.EventHandler(this.KameraWarnung_Load);
      ((System.ComponentModel.ISupportInitialize)(this.WarnungenDataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button Warnungen_Save;
    private System.Windows.Forms.DataGridView WarnungenDataGridView;
  }
}