namespace AlarmPreRecording
{
  partial class KameraVorNachLauf
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
      this.VorNachLauf_Save = new System.Windows.Forms.Button();
      this.VorNachDataGrid = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.VorNachDataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // VorNachLauf_Save
      // 
      this.VorNachLauf_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.VorNachLauf_Save.Location = new System.Drawing.Point(508, 202);
      this.VorNachLauf_Save.Name = "VorNachLauf_Save";
      this.VorNachLauf_Save.Size = new System.Drawing.Size(75, 23);
      this.VorNachLauf_Save.TabIndex = 6;
      this.VorNachLauf_Save.Text = "Speichern";
      this.VorNachLauf_Save.UseVisualStyleBackColor = true;
      this.VorNachLauf_Save.Click += new System.EventHandler(this.VorNachLauf_Save_Click_1);
      // 
      // VorNachDataGrid
      // 
      this.VorNachDataGrid.AllowUserToAddRows = false;
      this.VorNachDataGrid.AllowUserToDeleteRows = false;
      this.VorNachDataGrid.AllowUserToResizeColumns = false;
      this.VorNachDataGrid.AllowUserToResizeRows = false;
      this.VorNachDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.VorNachDataGrid.BackgroundColor = System.Drawing.Color.White;
      this.VorNachDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.VorNachDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.VorNachDataGrid.Location = new System.Drawing.Point(3, -3);
      this.VorNachDataGrid.Name = "VorNachDataGrid";
      this.VorNachDataGrid.Size = new System.Drawing.Size(580, 208);
      this.VorNachDataGrid.TabIndex = 7;
      this.VorNachDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VorNachDataGrid_CellContentClick);
      this.VorNachDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.VorNachDataGrid_CellValueChanged);
      // 
      // KameraVorNachLauf
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.VorNachLauf_Save);
      this.Controls.Add(this.VorNachDataGrid);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "KameraVorNachLauf";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "KameraVorNachLauf";
      this.Load += new System.EventHandler(this.KameraVorNachLauf_Load);
      ((System.ComponentModel.ISupportInitialize)(this.VorNachDataGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button VorNachLauf_Save;
    private System.Windows.Forms.DataGridView VorNachDataGrid;
  }
}