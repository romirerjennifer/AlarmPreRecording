namespace AlarmPreRecording
{
  partial class HauptprogrammStatus
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
      this.HauptprogrmStatusDataGrid = new System.Windows.Forms.DataGridView();
      this.Anzeige = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Buttons = new System.Windows.Forms.DataGridViewButtonColumn();
      this.startspskamer = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.HauptprogrmStatusDataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // HauptprogrmStatusDataGrid
      // 
      this.HauptprogrmStatusDataGrid.AllowUserToAddRows = false;
      this.HauptprogrmStatusDataGrid.AllowUserToDeleteRows = false;
      this.HauptprogrmStatusDataGrid.AllowUserToResizeColumns = false;
      this.HauptprogrmStatusDataGrid.AllowUserToResizeRows = false;
      this.HauptprogrmStatusDataGrid.BackgroundColor = System.Drawing.Color.White;
      this.HauptprogrmStatusDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.HauptprogrmStatusDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.HauptprogrmStatusDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anzeige,
            this.Status,
            this.Buttons});
      this.HauptprogrmStatusDataGrid.Location = new System.Drawing.Point(13, 13);
      this.HauptprogrmStatusDataGrid.Name = "HauptprogrmStatusDataGrid";
      this.HauptprogrmStatusDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.HauptprogrmStatusDataGrid.Size = new System.Drawing.Size(554, 188);
      this.HauptprogrmStatusDataGrid.TabIndex = 0;
      this.HauptprogrmStatusDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HauptprogrmStatusDataGrid_CellContentClick);
      // 
      // Anzeige
      // 
      this.Anzeige.Frozen = true;
      this.Anzeige.HeaderText = "";
      this.Anzeige.Name = "Anzeige";
      this.Anzeige.ReadOnly = true;
      this.Anzeige.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Anzeige.Width = 150;
      // 
      // Status
      // 
      this.Status.Frozen = true;
      this.Status.HeaderText = "Status";
      this.Status.Name = "Status";
      this.Status.ReadOnly = true;
      this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Status.Width = 180;
      // 
      // Buttons
      // 
      this.Buttons.Frozen = true;
      this.Buttons.HeaderText = "Bearbeiten";
      this.Buttons.Name = "Buttons";
      this.Buttons.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Buttons.Width = 180;
      // 
      // startspskamer
      // 
      this.startspskamer.Location = new System.Drawing.Point(356, 202);
      this.startspskamer.Name = "startspskamer";
      this.startspskamer.Size = new System.Drawing.Size(211, 23);
      this.startspskamer.TabIndex = 1;
      this.startspskamer.Text = "Peripherie verbinden und System starten";
      this.startspskamer.UseVisualStyleBackColor = true;
      this.startspskamer.Click += new System.EventHandler(this.startspskamer_Click);
      // 
      // HauptprogrammStatus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.startspskamer);
      this.Controls.Add(this.HauptprogrmStatusDataGrid);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "HauptprogrammStatus";
      this.Text = "HauptprogrammStatus";
      this.Load += new System.EventHandler(this.HauptprogrammStatus_Load);
      ((System.ComponentModel.ISupportInitialize)(this.HauptprogrmStatusDataGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView HauptprogrmStatusDataGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Anzeige;
    private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    private System.Windows.Forms.DataGridViewButtonColumn Buttons;
    private System.Windows.Forms.Button startspskamer;
  }
}