using System;
using System.Windows.Forms;

namespace AlarmPreRecording
{
  partial class Kameraanzahl
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
      this.Kameraanzahltxt = new System.Windows.Forms.Label();
      this.anzKameras = new System.Windows.Forms.NumericUpDown();
      this.anzKSave = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.anzKameras)).BeginInit();
      this.SuspendLayout();
      // 
      // Kameraanzahltxt
      // 
      this.Kameraanzahltxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.Kameraanzahltxt.AutoSize = true;
      this.Kameraanzahltxt.Location = new System.Drawing.Point(12, 9);
      this.Kameraanzahltxt.Name = "Kameraanzahltxt";
      this.Kameraanzahltxt.Size = new System.Drawing.Size(253, 13);
      this.Kameraanzahltxt.TabIndex = 11;
      this.Kameraanzahltxt.Text = "Auswählen der Anzahl der zu verwendeten Kameras";
      // 
      // anzKameras
      // 
      this.anzKameras.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.anzKameras.AutoSize = true;
      this.anzKameras.Location = new System.Drawing.Point(224, 31);
      this.anzKameras.Name = "anzKameras";
      this.anzKameras.Size = new System.Drawing.Size(41, 20);
      this.anzKameras.TabIndex = 10;
      // 
      // anzKSave
      // 
      this.anzKSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.anzKSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.anzKSave.Location = new System.Drawing.Point(502, 196);
      this.anzKSave.Name = "anzKSave";
      this.anzKSave.Size = new System.Drawing.Size(65, 23);
      this.anzKSave.TabIndex = 9;
      this.anzKSave.Text = "Speichern";
      this.anzKSave.UseVisualStyleBackColor = true;
      this.anzKSave.Click += new System.EventHandler(this.anzKSave_Click);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "Anzahl Kameras";
      // 
      // Kameraanzahl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.anzKSave);
      this.Controls.Add(this.anzKameras);
      this.Controls.Add(this.Kameraanzahltxt);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximumSize = new System.Drawing.Size(579, 231);
      this.Name = "Kameraanzahl";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Kameraanzahl";
      ((System.ComponentModel.ISupportInitialize)(this.anzKameras)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    private void AnzahlKamera_Paint(object sender, PaintEventArgs e)
    {
      throw new NotImplementedException();
    }

    #endregion
    private System.Windows.Forms.Label Kameraanzahltxt;
    private System.Windows.Forms.NumericUpDown anzKameras;
    private System.Windows.Forms.Button anzKSave;
    private System.Windows.Forms.Label label1;
  }
}