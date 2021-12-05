namespace AlarmPreRecording
{
  partial class DBBits
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
      this.DBBits_Save = new System.Windows.Forms.Button();
      this.DBBitsDataGrid = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.DBBitsDataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // DBBits_Save
      // 
      this.DBBits_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.DBBits_Save.Location = new System.Drawing.Point(504, 203);
      this.DBBits_Save.Name = "DBBits_Save";
      this.DBBits_Save.Size = new System.Drawing.Size(75, 23);
      this.DBBits_Save.TabIndex = 8;
      this.DBBits_Save.Text = "Speichern";
      this.DBBits_Save.UseVisualStyleBackColor = true;
      this.DBBits_Save.Click += new System.EventHandler(this.DBBits_Save_Click);
      // 
      // DBBitsDataGrid
      // 
      this.DBBitsDataGrid.AllowUserToResizeRows = false;
      this.DBBitsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DBBitsDataGrid.BackgroundColor = System.Drawing.Color.White;
      this.DBBitsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.DBBitsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DBBitsDataGrid.Location = new System.Drawing.Point(-1, 2);
      this.DBBitsDataGrid.Name = "DBBitsDataGrid";
      this.DBBitsDataGrid.Size = new System.Drawing.Size(580, 208);
      this.DBBitsDataGrid.TabIndex = 9;
      this.DBBitsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBBitsDataGrid_CellContentClick);
      // 
      // DBBits
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.DBBits_Save);
      this.Controls.Add(this.DBBitsDataGrid);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximumSize = new System.Drawing.Size(579, 231);
      this.Name = "DBBits";
      this.Text = "DBBits";
      this.Load += new System.EventHandler(this.DBBits_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DBBitsDataGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button DBBits_Save;
    private System.Windows.Forms.DataGridView DBBitsDataGrid;
  }
}