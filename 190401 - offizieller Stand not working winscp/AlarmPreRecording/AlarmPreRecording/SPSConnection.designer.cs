namespace AlarmPreRecording
{
    partial class SPSConnection
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
      this.buttonConf = new System.Windows.Forms.Button();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.buttonVerb = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonConf
      // 
      this.buttonConf.Location = new System.Drawing.Point(180, 158);
      this.buttonConf.Name = "buttonConf";
      this.buttonConf.Size = new System.Drawing.Size(197, 23);
      this.buttonConf.TabIndex = 0;
      this.buttonConf.Text = "SPS Verbindungskonfigurator öffnen";
      this.buttonConf.UseVisualStyleBackColor = true;
      this.buttonConf.Click += new System.EventHandler(this.buttonConf_Click_1);
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(281, 37);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(96, 20);
      this.numericUpDown1.TabIndex = 2;
      this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
      // 
      // numericUpDown2
      // 
      this.numericUpDown2.Location = new System.Drawing.Point(281, 85);
      this.numericUpDown2.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new System.Drawing.Size(96, 20);
      this.numericUpDown2.TabIndex = 3;
      this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(180, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "AG-Nummer";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(177, 87);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Timeout [ms]";
      // 
      // buttonVerb
      // 
      this.buttonVerb.Location = new System.Drawing.Point(201, 196);
      this.buttonVerb.Name = "buttonVerb";
      this.buttonVerb.Size = new System.Drawing.Size(154, 23);
      this.buttonVerb.TabIndex = 1;
      this.buttonVerb.Text = "SPS-Verbindung herstellen";
      this.buttonVerb.UseVisualStyleBackColor = true;
      this.buttonVerb.Click += new System.EventHandler(this.buttonVerb_Click);
      // 
      // SPSConnection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(579, 231);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.numericUpDown2);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.buttonVerb);
      this.Controls.Add(this.buttonConf);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximumSize = new System.Drawing.Size(579, 231);
      this.Name = "SPSConnection";
      this.Text = "SPSConnection";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button buttonVerb;
  }
}