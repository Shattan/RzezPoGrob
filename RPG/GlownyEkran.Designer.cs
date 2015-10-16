namespace RPG
{
    partial class GlownyEkran
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
            this.Wyswietlacz = new System.Windows.Forms.PictureBox();
            this.ButtonWyjdz = new System.Windows.Forms.Button();
            this.ButtonRozpocznij = new System.Windows.Forms.Button();
            this.PictureBoxWyjdz = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdz)).BeginInit();
            this.SuspendLayout();
            // 
            // Wyswietlacz
            // 
            this.Wyswietlacz.BackColor = System.Drawing.Color.Black;
            this.Wyswietlacz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wyswietlacz.Location = new System.Drawing.Point(0, 0);
            this.Wyswietlacz.Name = "Wyswietlacz";
            this.Wyswietlacz.Size = new System.Drawing.Size(292, 273);
            this.Wyswietlacz.TabIndex = 0;
            this.Wyswietlacz.TabStop = false;
            // 
            // ButtonWyjdz
            // 
            this.ButtonWyjdz.ForeColor = System.Drawing.Color.Yellow;
            this.ButtonWyjdz.Location = new System.Drawing.Point(12, 12);
            this.ButtonWyjdz.Name = "ButtonWyjdz";
            this.ButtonWyjdz.Size = new System.Drawing.Size(75, 23);
            this.ButtonWyjdz.TabIndex = 1;
            this.ButtonWyjdz.Text = "Wyjdź";
            this.ButtonWyjdz.UseVisualStyleBackColor = true;
            this.ButtonWyjdz.Click += new System.EventHandler(this.PrzyciskWyjdz_Click);
            // 
            // ButtonRozpocznij
            // 
            this.ButtonRozpocznij.ForeColor = System.Drawing.Color.Yellow;
            this.ButtonRozpocznij.Location = new System.Drawing.Point(94, 12);
            this.ButtonRozpocznij.Name = "ButtonRozpocznij";
            this.ButtonRozpocznij.Size = new System.Drawing.Size(75, 23);
            this.ButtonRozpocznij.TabIndex = 2;
            this.ButtonRozpocznij.Text = "Rozpocznij";
            this.ButtonRozpocznij.UseVisualStyleBackColor = true;
            // 
            // PictureBoxWyjdz
            // 
            this.PictureBoxWyjdz.Location = new System.Drawing.Point(13, 54);
            this.PictureBoxWyjdz.Name = "PictureBoxWyjdz";
            this.PictureBoxWyjdz.Size = new System.Drawing.Size(100, 50);
            this.PictureBoxWyjdz.TabIndex = 3;
            this.PictureBoxWyjdz.TabStop = false;
            this.PictureBoxWyjdz.Click += new System.EventHandler(this.PictureBoxWyjdz_Click);
            // 
            // GlownyEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.PictureBoxWyjdz);
            this.Controls.Add(this.ButtonRozpocznij);
            this.Controls.Add(this.ButtonWyjdz);
            this.Controls.Add(this.Wyswietlacz);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GlownyEkran";
            this.Text = "Rzeź Po Grób";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Wyswietlacz;
        private System.Windows.Forms.Button ButtonWyjdz;
        private System.Windows.Forms.Button ButtonRozpocznij;
        private System.Windows.Forms.PictureBox PictureBoxWyjdz;
    }
}

