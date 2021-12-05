namespace AlarmPreRecording
{
  partial class Projekt_erstellen
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
      this.findpath = new System.Windows.Forms.Button();
      this.projektpath = new System.Windows.Forms.Label();
      this.prjktPath_txtBox = new System.Windows.Forms.TextBox();
      this.projektname = new System.Windows.Forms.TextBox();
      this.prjktname = new System.Windows.Forms.Label();
      this.Infoneuerstellen = new System.Windows.Forms.Label();
      this.Create_Project = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // findpath
      // 
      this.findpath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.findpath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.findpath.Location = new System.Drawing.Point(472, 75);
      this.findpath.Name = "findpath";
      this.findpath.Size = new System.Drawing.Size(95, 23);
      this.findpath.TabIndex = 0;
      this.findpath.Text = "&suchen";
      this.findpath.UseVisualStyleBackColor = true;
      this.findpath.Click += new System.EventHandler(this.findpath_Click);
      // 
      // projektpath
      // 
      this.projektpath.AutoSize = true;
      this.projektpath.Location = new System.Drawing.Point(12, 80);
      this.projektpath.Name = "projektpath";
      this.projektpath.Size = new System.Drawing.Size(106, 13);
      this.projektpath.TabIndex = 1;
      this.projektpath.Text = "Projektpfad angeben";
      this.projektpath.Click += new System.EventHandler(this.label1_Click);
      // 
      // prjktPath_txtBox
      // 
      this.prjktPath_txtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.prjktPath_txtBox.BackColor = System.Drawing.Color.White;
      this.prjktPath_txtBox.Location = new System.Drawing.Point(282, 77);
      this.prjktPath_txtBox.Name = "prjktPath_txtBox";
      this.prjktPath_txtBox.ReadOnly = true;
      this.prjktPath_txtBox.Size = new System.Drawing.Size(184, 20);
      this.prjktPath_txtBox.TabIndex = 2;
      this.prjktPath_txtBox.TextChanged += new System.EventHandler(this.prjktPath_txtBox_TextChanged);
      // 
      // projektname
      // 
      this.projektname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.projektname.Location = new System.Drawing.Point(282, 39);
      this.projektname.Name = "projektname";
      this.projektname.ShortcutsEnabled = false;
      this.projektname.Size = new System.Drawing.Size(184, 20);
      this.projektname.TabIndex = 3;
      this.projektname.TextChanged += new System.EventHandler(this.projektname_TextChanged);
      // 
      // prjktname
      // 
      this.prjktname.AutoSize = true;
      this.prjktname.Location = new System.Drawing.Point(12, 39);
      this.prjktname.Name = "prjktname";
      this.prjktname.Size = new System.Drawing.Size(111, 13);
      this.prjktname.TabIndex = 4;
      this.prjktname.Text = "Projektname angeben";
      // 
      // Infoneuerstellen
      // 
      this.Infoneuerstellen.AutoSize = true;
      this.Infoneuerstellen.Location = new System.Drawing.Point(12, 9);
      this.Infoneuerstellen.Name = "Infoneuerstellen";
      this.Infoneuerstellen.Size = new System.Drawing.Size(504, 13);
      this.Infoneuerstellen.TabIndex = 5;
      this.Infoneuerstellen.Text = "Beim Erstellen eines neuem Projekts, müssen alle Einstellungen neu eingegeben und" +
    " gespeichert werden!";
      // 
      // Create_Project
      // 
      this.Create_Project.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Create_Project.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Create_Project.Location = new System.Drawing.Point(472, 196);
      this.Create_Project.Name = "Create_Project";
      this.Create_Project.Size = new System.Drawing.Size(95, 23);
      this.Create_Project.TabIndex = 6;
      this.Create_Project.Text = "Projekt erstellen";
      this.Create_Project.UseVisualStyleBackColor = true;
      this.Create_Project.Click += new System.EventHandler(this.Create_Project_Click);
      // 
      // Projekt_erstellen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.Create_Project);
      this.Controls.Add(this.Infoneuerstellen);
      this.Controls.Add(this.prjktname);
      this.Controls.Add(this.projektname);
      this.Controls.Add(this.prjktPath_txtBox);
      this.Controls.Add(this.projektpath);
      this.Controls.Add(this.findpath);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Projekt_erstellen";
      this.Text = "Projekt_erstellen";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button findpath;
    private System.Windows.Forms.Label projektpath;
    private System.Windows.Forms.TextBox prjktPath_txtBox;
    private System.Windows.Forms.TextBox projektname;
    private System.Windows.Forms.Label prjktname;
    private System.Windows.Forms.Label Infoneuerstellen;
    private System.Windows.Forms.Button Create_Project;
  }
}