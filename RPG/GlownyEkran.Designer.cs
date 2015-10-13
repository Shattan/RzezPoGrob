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
            this.PrzyciskWyjdz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).BeginInit();
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
            // PrzyciskWyjdz
            // 
            this.PrzyciskWyjdz.Location = new System.Drawing.Point(12, 12);
            this.PrzyciskWyjdz.Name = "PrzyciskWyjdz";
            this.PrzyciskWyjdz.Size = new System.Drawing.Size(75, 23);
            this.PrzyciskWyjdz.TabIndex = 1;
            this.PrzyciskWyjdz.Text = "Wyjdź";
            this.PrzyciskWyjdz.UseVisualStyleBackColor = true;
            this.PrzyciskWyjdz.Click += new System.EventHandler(this.PrzyciskWyjdz_Click);
            // 
            // GlownyEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.PrzyciskWyjdz);
            this.Controls.Add(this.Wyswietlacz);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GlownyEkran";
            this.Text = "Rzeź Po Grób";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Wyswietlacz;
        private System.Windows.Forms.Button PrzyciskWyjdz;
    }
}

