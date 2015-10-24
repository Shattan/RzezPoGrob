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
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.PictureBoxRuszaj = new System.Windows.Forms.PictureBox();
            this.PictureBoxOpcje = new System.Windows.Forms.PictureBox();
            this.PictureBoxWyjscie = new System.Windows.Forms.PictureBox();
            this.PictureBoxMgla = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpcje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMgla)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.BackColor = System.Drawing.Color.Black;
            this.LabelInformacje.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.Location = new System.Drawing.Point(64, 207);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(62, 101);
            this.LabelInformacje.TabIndex = 0;
            this.LabelInformacje.Text = "LabelInformacje";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBoxRuszaj
            // 
            this.PictureBoxRuszaj.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxRuszaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxRuszaj.Location = new System.Drawing.Point(290, 12);
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
            this.PictureBoxOpcje.Location = new System.Drawing.Point(151, 12);
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
            this.PictureBoxWyjscie.Location = new System.Drawing.Point(12, 12);
            this.PictureBoxWyjscie.Name = "PictureBoxWyjscie";
            this.PictureBoxWyjscie.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxWyjscie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxWyjscie.TabIndex = 6;
            this.PictureBoxWyjscie.TabStop = false;
            this.PictureBoxWyjscie.Click += new System.EventHandler(this.PictureBoxWyjscie_Click);
            this.PictureBoxWyjscie.MouseEnter += new System.EventHandler(this.PictureBoxWyjscie_MouseEnter);
            this.PictureBoxWyjscie.MouseLeave += new System.EventHandler(this.PictureBoxWyjscie_MouseLeave);
            // 
            // PictureBoxMgla
            // 
            this.PictureBoxMgla.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxMgla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxMgla.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxMgla.Name = "PictureBoxMgla";
            this.PictureBoxMgla.Size = new System.Drawing.Size(117, 109);
            this.PictureBoxMgla.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxMgla.TabIndex = 7;
            this.PictureBoxMgla.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.PictureBoxMgla);
            this.panel1.Location = new System.Drawing.Point(372, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 109);
            this.panel1.TabIndex = 8;
            // 
            // GlownyEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(893, 780);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LabelInformacje);
            this.Controls.Add(this.PictureBoxRuszaj);
            this.Controls.Add(this.PictureBoxOpcje);
            this.Controls.Add(this.PictureBoxWyjscie);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "GlownyEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rzeź Po Grób";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpcje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMgla)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.PictureBox PictureBoxRuszaj;
        private System.Windows.Forms.PictureBox PictureBoxOpcje;
        private System.Windows.Forms.PictureBox PictureBoxWyjscie;
        private System.Windows.Forms.PictureBox PictureBoxMgla;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
    }
}

