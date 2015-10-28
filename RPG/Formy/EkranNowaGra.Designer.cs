namespace RPG
{
    partial class EkranNowaGra
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PictureBoxPotwierdz = new System.Windows.Forms.PictureBox();
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.PictureBoxWyjscie = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPotwierdz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic);
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(452, 387);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 27);
            this.textBox1.TabIndex = 0;
            // 
            // PictureBoxPotwierdz
            // 
            this.PictureBoxPotwierdz.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PictureBoxPotwierdz.Location = new System.Drawing.Point(611, 373);
            this.PictureBoxPotwierdz.Name = "PictureBoxPotwierdz";
            this.PictureBoxPotwierdz.Size = new System.Drawing.Size(100, 50);
            this.PictureBoxPotwierdz.TabIndex = 1;
            this.PictureBoxPotwierdz.TabStop = false;
            this.PictureBoxPotwierdz.Click += new System.EventHandler(this.PictureBoxPotwierdz_Click);
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.BackColor = System.Drawing.Color.Black;
            this.LabelInformacje.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.ForeColor = System.Drawing.Color.Yellow;
            this.LabelInformacje.Location = new System.Drawing.Point(167, 742);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(784, 44);
            this.LabelInformacje.TabIndex = 2;
            this.LabelInformacje.Text = "LabelInformacje";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBoxWyjscie
            // 
            this.PictureBoxWyjscie.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxWyjscie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBoxWyjscie.Location = new System.Drawing.Point(21, 12);
            this.PictureBoxWyjscie.Name = "PictureBoxWyjscie";
            this.PictureBoxWyjscie.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxWyjscie.TabIndex = 7;
            this.PictureBoxWyjscie.TabStop = false;
            this.PictureBoxWyjscie.Click += new System.EventHandler(this.PictureBoxWyjscie_Click);
            this.PictureBoxWyjscie.MouseEnter += new System.EventHandler(this.PictureBoxWyjscie_MouseEnter);
            this.PictureBoxWyjscie.MouseLeave += new System.EventHandler(this.PictureBoxWyjscie_MouseLeave);
            // 
            // EkranNowaGra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1232, 795);
            this.Controls.Add(this.PictureBoxWyjscie);
            this.Controls.Add(this.LabelInformacje);
            this.Controls.Add(this.PictureBoxPotwierdz);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranNowaGra";
            this.Text = "EkranNowaGra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPotwierdz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox PictureBoxPotwierdz;
        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.PictureBox PictureBoxWyjscie;
    }
}