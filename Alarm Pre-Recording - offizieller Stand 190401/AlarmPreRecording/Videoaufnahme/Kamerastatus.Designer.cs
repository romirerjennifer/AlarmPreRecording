namespace AlarmPreRecording
{
  partial class Kamerastatus
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
      this.KameraStatusDataGridView = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.KameraStatusDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // KameraStatusDataGridView
      // 
      this.KameraStatusDataGridView.AllowUserToAddRows = false;
      this.KameraStatusDataGridView.AllowUserToDeleteRows = false;
      this.KameraStatusDataGridView.AllowUserToResizeColumns = false;
      this.KameraStatusDataGridView.AllowUserToResizeRows = false;
      this.KameraStatusDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.KameraStatusDataGridView.BackgroundColor = System.Drawing.Color.White;
      this.KameraStatusDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.KameraStatusDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.KameraStatusDataGridView.Location = new System.Drawing.Point(0, 0);
      this.KameraStatusDataGridView.Name = "KameraStatusDataGridView";
      this.KameraStatusDataGridView.ReadOnly = true;
      this.KameraStatusDataGridView.Size = new System.Drawing.Size(579, 231);
      this.KameraStatusDataGridView.TabIndex = 3;
      // 
      // Kamerastatus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.KameraStatusDataGridView);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximumSize = new System.Drawing.Size(579, 231);
      this.Name = "Kamerastatus";
      this.Text = "Kamerastatus";
      ((System.ComponentModel.ISupportInitialize)(this.KameraStatusDataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView KameraStatusDataGridView;
  }
}