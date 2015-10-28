namespace RPG
{
    partial class EkranGlowny
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
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.PictureBoxRuszaj = new System.Windows.Forms.PictureBox();
            this.PictureBoxEkranOpcje = new System.Windows.Forms.PictureBox();
            this.PictureBoxWyjscie = new System.Windows.Forms.PictureBox();
            this.PictureBoxWczytaj = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEkranOpcje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWczytaj)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.BackColor = System.Drawing.Color.Black;
            this.LabelInformacje.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.Location = new System.Drawing.Point(54, 727);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(784, 44);
            this.LabelInformacje.TabIndex = 0;
            this.LabelInformacje.Text = "LabelInformacje";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBoxRuszaj
            // 
            this.PictureBoxRuszaj.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxRuszaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBoxRuszaj.Location = new System.Drawing.Point(429, 12);
            this.PictureBoxRuszaj.Name = "PictureBoxRuszaj";
            this.PictureBoxRuszaj.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxRuszaj.TabIndex = 2;
            this.PictureBoxRuszaj.TabStop = false;
            this.PictureBoxRuszaj.Click += new System.EventHandler(this.PictureBoxRuszaj_Click);
            this.PictureBoxRuszaj.MouseEnter += new System.EventHandler(this.PictureBoxRuszaj_MouseEnter);
            this.PictureBoxRuszaj.MouseLeave += new System.EventHandler(this.PictureBoxRuszaj_MouseLeave);
            // 
            // PictureBoxEkranOpcje
            // 
            this.PictureBoxEkranOpcje.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxEkranOpcje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBoxEkranOpcje.Location = new System.Drawing.Point(151, 12);
            this.PictureBoxEkranOpcje.Name = "PictureBoxEkranOpcje";
            this.PictureBoxEkranOpcje.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxEkranOpcje.TabIndex = 1;
            this.PictureBoxEkranOpcje.TabStop = false;
            this.PictureBoxEkranOpcje.Click += new System.EventHandler(this.PictureBoxEkranOpcje_Click);
            this.PictureBoxEkranOpcje.MouseEnter += new System.EventHandler(this.PictureBoxEkranOpcje_MouseEnter);
            this.PictureBoxEkranOpcje.MouseLeave += new System.EventHandler(this.PictureBoxEkranOpcje_MouseLeave);
            // 
            // PictureBoxWyjscie
            // 
            this.PictureBoxWyjscie.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxWyjscie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBoxWyjscie.Location = new System.Drawing.Point(12, 12);
            this.PictureBoxWyjscie.Name = "PictureBoxWyjscie";
            this.PictureBoxWyjscie.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxWyjscie.TabIndex = 6;
            this.PictureBoxWyjscie.TabStop = false;
            this.PictureBoxWyjscie.Click += new System.EventHandler(this.PictureBoxWyjscie_Click);
            this.PictureBoxWyjscie.MouseEnter += new System.EventHandler(this.PictureBoxWyjscie_MouseEnter);
            this.PictureBoxWyjscie.MouseLeave += new System.EventHandler(this.PictureBoxWyjscie_MouseLeave);
            // 
            // PictureBoxWczytaj
            // 
            this.PictureBoxWczytaj.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxWczytaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBoxWczytaj.Location = new System.Drawing.Point(290, 12);
            this.PictureBoxWczytaj.Name = "PictureBoxWczytaj";
            this.PictureBoxWczytaj.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxWczytaj.TabIndex = 8;
            this.PictureBoxWczytaj.TabStop = false;
            this.PictureBoxWczytaj.Click += new System.EventHandler(this.PictureBoxWczytaj_Click);
            this.PictureBoxWczytaj.MouseEnter += new System.EventHandler(this.PictureBoxWczytaj_MouseEnter);
            this.PictureBoxWczytaj.MouseLeave += new System.EventHandler(this.PictureBoxWczytaj_MouseLeave);
            // 
            // EkranGlowny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(888, 780);
            this.Controls.Add(this.PictureBoxWczytaj);
            this.Controls.Add(this.LabelInformacje);
            this.Controls.Add(this.PictureBoxRuszaj);
            this.Controls.Add(this.PictureBoxEkranOpcje);
            this.Controls.Add(this.PictureBoxWyjscie);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "EkranGlowny";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rzeź Po Grób";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEkranOpcje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWczytaj)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.PictureBox PictureBoxRuszaj;
        private System.Windows.Forms.PictureBox PictureBoxEkranOpcje;
        private System.Windows.Forms.PictureBox PictureBoxWyjscie;
        private System.Windows.Forms.PictureBox PictureBoxWczytaj;
    }
}

