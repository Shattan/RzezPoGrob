namespace RPG
{
    partial class EkranGry
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
            this.label1 = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.panelPraweMenu = new System.Windows.Forms.Panel();
            this.panelMapa = new System.Windows.Forms.Panel();
            this.PictureBoxGracz = new System.Windows.Forms.PictureBox();
            this.pBWalka = new System.Windows.Forms.PictureBox();
            this.pBKolizja = new System.Windows.Forms.PictureBox();
            this.timerPrzeplywCzasu = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.panelMapa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGracz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBWalka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBKolizja)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PictureBox.Location = new System.Drawing.Point(133, 44);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(92, 50);
            this.PictureBox.TabIndex = 2;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // panelPraweMenu
            // 
            this.panelPraweMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelPraweMenu.Location = new System.Drawing.Point(1453, -6);
            this.panelPraweMenu.Name = "panelPraweMenu";
            this.panelPraweMenu.Size = new System.Drawing.Size(88, 73);
            this.panelPraweMenu.TabIndex = 29;
            // 
            // panelMapa
            // 
            this.panelMapa.Controls.Add(this.PictureBoxGracz);
            this.panelMapa.Controls.Add(this.pBWalka);
            this.panelMapa.Controls.Add(this.pBKolizja);
            this.panelMapa.Location = new System.Drawing.Point(81, 203);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(1369, 492);
            this.panelMapa.TabIndex = 30;
            // 
            // PictureBoxGracz
            // 
            this.PictureBoxGracz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.PictureBoxGracz.Location = new System.Drawing.Point(610, 199);
            this.PictureBoxGracz.Name = "PictureBoxGracz";
            this.PictureBoxGracz.Size = new System.Drawing.Size(100, 100);
            this.PictureBoxGracz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBoxGracz.TabIndex = 29;
            this.PictureBoxGracz.TabStop = false;
            // 
            // pBWalka
            // 
            this.pBWalka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pBWalka.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBWalka.Location = new System.Drawing.Point(928, 358);
            this.pBWalka.Name = "pBWalka";
            this.pBWalka.Size = new System.Drawing.Size(27, 42);
            this.pBWalka.TabIndex = 31;
            this.pBWalka.TabStop = false;
            // 
            // pBKolizja
            // 
            this.pBKolizja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pBKolizja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBKolizja.Location = new System.Drawing.Point(928, 146);
            this.pBKolizja.Name = "pBKolizja";
            this.pBKolizja.Size = new System.Drawing.Size(37, 32);
            this.pBKolizja.TabIndex = 30;
            this.pBKolizja.TabStop = false;
            // 
            // timerPrzeplywCzasu
            // 
            this.timerPrzeplywCzasu.Interval = 5;
            this.timerPrzeplywCzasu.Tick += new System.EventHandler(this.timerPrzeplywCzasu_Tick);
            // 
            // EkranGry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1543, 854);
            this.Controls.Add(this.panelMapa);
            this.Controls.Add(this.panelPraweMenu);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranGry";
            this.Text = "Gra";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EkranOpcje_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.przechwytywanieKlawiszy_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.przechwytywanieKlawiszy_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.panelMapa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGracz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBWalka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBKolizja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Panel panelPraweMenu;
        private System.Windows.Forms.Panel panelMapa;
        private System.Windows.Forms.PictureBox PictureBoxGracz;
        private System.Windows.Forms.Timer timerPrzeplywCzasu;
        private System.Windows.Forms.PictureBox pBWalka;
        private System.Windows.Forms.PictureBox pBKolizja;
    }
}