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
            this.components = new System.ComponentModel.Container();
            this.PanelInformacje = new System.Windows.Forms.Panel();
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.Zegar = new System.Windows.Forms.Timer(this.components);
            this.PanelWyswietlacza = new System.Windows.Forms.Panel();
            this.PictureBoxRuszaj = new System.Windows.Forms.PictureBox();
            this.PictureBoxOpcje = new System.Windows.Forms.PictureBox();
            this.PictureBoxWyjscie = new System.Windows.Forms.PictureBox();
            this.PanelInformacje.SuspendLayout();
            this.PanelWyswietlacza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpcje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelInformacje
            // 
            this.PanelInformacje.BackColor = System.Drawing.Color.Black;
            this.PanelInformacje.Controls.Add(this.LabelInformacje);
            this.PanelInformacje.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelInformacje.ForeColor = System.Drawing.Color.Yellow;
            this.PanelInformacje.Location = new System.Drawing.Point(486, 3);
            this.PanelInformacje.Name = "PanelInformacje";
            this.PanelInformacje.Size = new System.Drawing.Size(62, 101);
            this.PanelInformacje.TabIndex = 4;
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.BackColor = System.Drawing.Color.OrangeRed;
            this.LabelInformacje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInformacje.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.Location = new System.Drawing.Point(0, 0);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(62, 101);
            this.LabelInformacje.TabIndex = 0;
            this.LabelInformacje.Text = "LabelInformacje";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Zegar
            // 
            this.Zegar.Interval = 300;
            this.Zegar.Tick += new System.EventHandler(this.Zegar_Tick);
            // 
            // PanelWyswietlacza
            // 
            this.PanelWyswietlacza.BackColor = System.Drawing.Color.Red;
            this.PanelWyswietlacza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelWyswietlacza.Controls.Add(this.PictureBoxRuszaj);
            this.PanelWyswietlacza.Controls.Add(this.PictureBoxOpcje);
            this.PanelWyswietlacza.Controls.Add(this.PictureBoxWyjscie);
            this.PanelWyswietlacza.Controls.Add(this.PanelInformacje);
            this.PanelWyswietlacza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWyswietlacza.Location = new System.Drawing.Point(0, 0);
            this.PanelWyswietlacza.Name = "PanelWyswietlacza";
            this.PanelWyswietlacza.Size = new System.Drawing.Size(893, 780);
            this.PanelWyswietlacza.TabIndex = 6;
            // 
            // PictureBoxRuszaj
            // 
            this.PictureBoxRuszaj.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxRuszaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxRuszaj.Location = new System.Drawing.Point(290, 3);
            this.PictureBoxRuszaj.Name = "PictureBoxRuszaj";
            this.PictureBoxRuszaj.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxRuszaj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxRuszaj.TabIndex = 2;
            this.PictureBoxRuszaj.TabStop = false;
            this.PictureBoxRuszaj.Click += new System.EventHandler(this.PictureBoxRuszaj_Click);
            // 
            // PictureBoxOpcje
            // 
            this.PictureBoxOpcje.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxOpcje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxOpcje.Location = new System.Drawing.Point(151, 3);
            this.PictureBoxOpcje.Name = "PictureBoxOpcje";
            this.PictureBoxOpcje.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxOpcje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxOpcje.TabIndex = 1;
            this.PictureBoxOpcje.TabStop = false;
            this.PictureBoxOpcje.Click += new System.EventHandler(this.PictureBoxOpcje_Click);
            // 
            // PictureBoxWyjscie
            // 
            this.PictureBoxWyjscie.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxWyjscie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBoxWyjscie.Location = new System.Drawing.Point(12, 3);
            this.PictureBoxWyjscie.Name = "PictureBoxWyjscie";
            this.PictureBoxWyjscie.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxWyjscie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxWyjscie.TabIndex = 6;
            this.PictureBoxWyjscie.TabStop = false;
            this.PictureBoxWyjscie.Click += new System.EventHandler(this.PictureBoxWyjscie_Click);
            this.PictureBoxWyjscie.MouseEnter += new System.EventHandler(this.PictureBoxWyjscie_MouseEnter);
            this.PictureBoxWyjscie.MouseLeave += new System.EventHandler(this.PictureBoxWyjscie_MouseLeave);
            // 
            // GlownyEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(893, 780);
            this.Controls.Add(this.PanelWyswietlacza);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "GlownyEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rzeź Po Grób";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanelInformacje.ResumeLayout(false);
            this.PanelWyswietlacza.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpcje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelInformacje;
        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.Timer Zegar;
        private System.Windows.Forms.Panel PanelWyswietlacza;
        private System.Windows.Forms.PictureBox PictureBoxRuszaj;
        private System.Windows.Forms.PictureBox PictureBoxOpcje;
        private System.Windows.Forms.PictureBox PictureBoxWyjscie;
    }
}

