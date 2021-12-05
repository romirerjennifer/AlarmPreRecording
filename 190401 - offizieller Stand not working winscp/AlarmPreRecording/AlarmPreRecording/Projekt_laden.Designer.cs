namespace AlarmPreRecording
{
  partial class Projekt_laden
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
      this.prjktPath_txtBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.findpath = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // prjktPath_txtBox
      // 
      this.prjktPath_txtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.prjktPath_txtBox.BackColor = System.Drawing.Color.White;
      this.prjktPath_txtBox.Location = new System.Drawing.Point(200, 25);
      this.prjktPath_txtBox.Name = "prjktPath_txtBox";
      this.prjktPath_txtBox.ReadOnly = true;
      this.prjktPath_txtBox.Size = new System.Drawing.Size(266, 20);
      this.prjktPath_txtBox.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(99, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Projektordner laden";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // findpath
      // 
      this.findpath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.findpath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.findpath.Location = new System.Drawing.Point(472, 23);
      this.findpath.Name = "findpath";
      this.findpath.Size = new System.Drawing.Size(95, 23);
      this.findpath.TabIndex = 3;
      this.findpath.Text = "&Öffnen";
      this.findpath.UseVisualStyleBackColor = true;
      this.findpath.Click += new System.EventHandler(this.findpath_Click);
      // 
      // Projekt_laden
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.prjktPath_txtBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.findpath);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Projekt_laden";
      this.Text = "Projekt_laden";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox prjktPath_txtBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button findpath;
  }
}