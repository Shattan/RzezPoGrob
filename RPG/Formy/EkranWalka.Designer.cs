﻿namespace RPG
{
    partial class EkranWalka
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
            this.PictureBoxUcieczka = new System.Windows.Forms.Label();
            this.PictureBoxAtakMagiczny = new System.Windows.Forms.Label();
            this.PictureBoxEkwipunek = new System.Windows.Forms.Label();
            this.PictureBoxAtakFizyczny = new System.Windows.Forms.Label();
            this.FlowLayoutPanelWyborAtakuFizycznego = new System.Windows.Forms.FlowLayoutPanel();
            this.PictureBoxWyjdzZAtakowFizycznych = new System.Windows.Forms.Label();
            this.FlowLayoutPanelWyborAtakuMagicznego = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxWyjdzZAtakowMagicznych = new System.Windows.Forms.Label();
            this.FlowLayoutPanelWyborMikstury = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxWyjdzZEkwipunku = new System.Windows.Forms.Label();
            this.FlowLayoutPanelWyboru = new System.Windows.Forms.FlowLayoutPanel();
            this.TimerDoZamkniecia = new System.Windows.Forms.Timer(this.components);
            this.PictureBoxPasekHPGracza = new System.Windows.Forms.PictureBox();
            this.PictureBoxPasekEnergiiGracza = new System.Windows.Forms.PictureBox();
            this.PanelDanychPrzeciwnika = new System.Windows.Forms.Panel();
            this.LabelDanePrzeciwnika = new System.Windows.Forms.Label();
            this.PictureBoxPasekHPPrzeciwnika = new System.Windows.Forms.PictureBox();
            this.PictureBoxPasekEnergiiPrzeciwnika = new System.Windows.Forms.PictureBox();
            this.PanelDanychGracza = new System.Windows.Forms.Panel();
            this.LabelDaneGracza = new System.Windows.Forms.Label();
            this.LabelInformacje = new System.Windows.Forms.TextBox();
            this.FlowLayoutPanelWyborAtakuFizycznego.SuspendLayout();
            this.FlowLayoutPanelWyborAtakuMagicznego.SuspendLayout();
            this.FlowLayoutPanelWyborMikstury.SuspendLayout();
            this.FlowLayoutPanelWyboru.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekHPGracza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekEnergiiGracza)).BeginInit();
            this.PanelDanychPrzeciwnika.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekHPPrzeciwnika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekEnergiiPrzeciwnika)).BeginInit();
            this.PanelDanychGracza.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxUcieczka
            // 
            this.PictureBoxUcieczka.BackColor = System.Drawing.Color.White;
            this.PictureBoxUcieczka.Location = new System.Drawing.Point(3, 93);
            this.PictureBoxUcieczka.Name = "PictureBoxUcieczka";
            this.PictureBoxUcieczka.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxUcieczka.TabIndex = 3;
            this.PictureBoxUcieczka.Text = "Ucieczka";
            this.PictureBoxUcieczka.Click += new System.EventHandler(this.PictureBoxUcieczka_Click);
            // 
            // PictureBoxAtakMagiczny
            // 
            this.PictureBoxAtakMagiczny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PictureBoxAtakMagiczny.Location = new System.Drawing.Point(3, 31);
            this.PictureBoxAtakMagiczny.Name = "PictureBoxAtakMagiczny";
            this.PictureBoxAtakMagiczny.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxAtakMagiczny.TabIndex = 2;
            this.PictureBoxAtakMagiczny.Text = "Ataki magiczne";
            this.PictureBoxAtakMagiczny.Click += new System.EventHandler(this.PictureBoxAtakMagiczny_Click);
            // 
            // PictureBoxEkwipunek
            // 
            this.PictureBoxEkwipunek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PictureBoxEkwipunek.Location = new System.Drawing.Point(3, 62);
            this.PictureBoxEkwipunek.Name = "PictureBoxEkwipunek";
            this.PictureBoxEkwipunek.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxEkwipunek.TabIndex = 1;
            this.PictureBoxEkwipunek.Text = "Ekwipunek";
            this.PictureBoxEkwipunek.Click += new System.EventHandler(this.PictureBoxEkwipunek_Click);
            // 
            // PictureBoxAtakFizyczny
            // 
            this.PictureBoxAtakFizyczny.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxAtakFizyczny.Location = new System.Drawing.Point(3, 0);
            this.PictureBoxAtakFizyczny.Name = "PictureBoxAtakFizyczny";
            this.PictureBoxAtakFizyczny.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxAtakFizyczny.TabIndex = 0;
            this.PictureBoxAtakFizyczny.Text = "Ataki fizyczne";
            this.PictureBoxAtakFizyczny.Click += new System.EventHandler(this.PictureBoxAtakFizyczny_Click);
            // 
            // FlowLayoutPanelWyborAtakuFizycznego
            // 
            this.FlowLayoutPanelWyborAtakuFizycznego.AutoScroll = true;
            this.FlowLayoutPanelWyborAtakuFizycznego.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanelWyborAtakuFizycznego.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyborAtakuFizycznego.Controls.Add(this.PictureBoxWyjdzZAtakowFizycznych);
            this.FlowLayoutPanelWyborAtakuFizycznego.Location = new System.Drawing.Point(16, 234);
            this.FlowLayoutPanelWyborAtakuFizycznego.Name = "FlowLayoutPanelWyborAtakuFizycznego";
            this.FlowLayoutPanelWyborAtakuFizycznego.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyborAtakuFizycznego.TabIndex = 0;
            this.FlowLayoutPanelWyborAtakuFizycznego.Visible = false;
            // 
            // PictureBoxWyjdzZAtakowFizycznych
            // 
            this.PictureBoxWyjdzZAtakowFizycznych.BackColor = System.Drawing.Color.LightGray;
            this.PictureBoxWyjdzZAtakowFizycznych.Location = new System.Drawing.Point(3, 0);
            this.PictureBoxWyjdzZAtakowFizycznych.Name = "PictureBoxWyjdzZAtakowFizycznych";
            this.PictureBoxWyjdzZAtakowFizycznych.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxWyjdzZAtakowFizycznych.TabIndex = 0;
            this.PictureBoxWyjdzZAtakowFizycznych.Tag = "Wstecz";
            this.PictureBoxWyjdzZAtakowFizycznych.Text = "Wstecz";
            this.PictureBoxWyjdzZAtakowFizycznych.Click += new System.EventHandler(this.PictureBoxWyjdzZAtakowFizycznych_Click);
            // 
            // FlowLayoutPanelWyborAtakuMagicznego
            // 
            this.FlowLayoutPanelWyborAtakuMagicznego.AutoScroll = true;
            this.FlowLayoutPanelWyborAtakuMagicznego.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanelWyborAtakuMagicznego.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyborAtakuMagicznego.Controls.Add(this.pictureBoxWyjdzZAtakowMagicznych);
            this.FlowLayoutPanelWyborAtakuMagicznego.Location = new System.Drawing.Point(408, 234);
            this.FlowLayoutPanelWyborAtakuMagicznego.Name = "FlowLayoutPanelWyborAtakuMagicznego";
            this.FlowLayoutPanelWyborAtakuMagicznego.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyborAtakuMagicznego.TabIndex = 1;
            this.FlowLayoutPanelWyborAtakuMagicznego.Visible = false;
            // 
            // pictureBoxWyjdzZAtakowMagicznych
            // 
            this.pictureBoxWyjdzZAtakowMagicznych.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxWyjdzZAtakowMagicznych.Location = new System.Drawing.Point(3, 0);
            this.pictureBoxWyjdzZAtakowMagicznych.Name = "pictureBoxWyjdzZAtakowMagicznych";
            this.pictureBoxWyjdzZAtakowMagicznych.Size = new System.Drawing.Size(379, 31);
            this.pictureBoxWyjdzZAtakowMagicznych.TabIndex = 0;
            this.pictureBoxWyjdzZAtakowMagicznych.Tag = "Wstecz";
            this.pictureBoxWyjdzZAtakowMagicznych.Text = "Wstecz";
            this.pictureBoxWyjdzZAtakowMagicznych.Click += new System.EventHandler(this.pictureBoxWyjdzZAtakowMagicznych_Click);
            // 
            // FlowLayoutPanelWyborMikstury
            // 
            this.FlowLayoutPanelWyborMikstury.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanelWyborMikstury.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyborMikstury.Controls.Add(this.pictureBoxWyjdzZEkwipunku);
            this.FlowLayoutPanelWyborMikstury.Location = new System.Drawing.Point(408, 417);
            this.FlowLayoutPanelWyborMikstury.Name = "FlowLayoutPanelWyborMikstury";
            this.FlowLayoutPanelWyborMikstury.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyborMikstury.TabIndex = 1;
            this.FlowLayoutPanelWyborMikstury.Visible = false;
            // 
            // pictureBoxWyjdzZEkwipunku
            // 
            this.pictureBoxWyjdzZEkwipunku.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxWyjdzZEkwipunku.Location = new System.Drawing.Point(3, 0);
            this.pictureBoxWyjdzZEkwipunku.Name = "pictureBoxWyjdzZEkwipunku";
            this.pictureBoxWyjdzZEkwipunku.Size = new System.Drawing.Size(379, 31);
            this.pictureBoxWyjdzZEkwipunku.TabIndex = 0;
            this.pictureBoxWyjdzZEkwipunku.Tag = "Wstecz";
            this.pictureBoxWyjdzZEkwipunku.Text = "Wstecz";
            this.pictureBoxWyjdzZEkwipunku.Click += new System.EventHandler(this.pictureBoxWyjdzZEkwipunku_Click);
            // 
            // FlowLayoutPanelWyboru
            // 
            this.FlowLayoutPanelWyboru.AutoScroll = true;
            this.FlowLayoutPanelWyboru.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanelWyboru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxAtakFizyczny);
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxAtakMagiczny);
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxEkwipunek);
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxUcieczka);
            this.FlowLayoutPanelWyboru.Location = new System.Drawing.Point(13, 417);
            this.FlowLayoutPanelWyboru.Name = "FlowLayoutPanelWyboru";
            this.FlowLayoutPanelWyboru.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyboru.TabIndex = 1;
            // 
            // TimerDoZamkniecia
            // 
            this.TimerDoZamkniecia.Interval = 3000;
            this.TimerDoZamkniecia.Tick += new System.EventHandler(this.TimerDoZamkniecia_Tick);
            // 
            // PictureBoxPasekHPGracza
            // 
            this.PictureBoxPasekHPGracza.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxPasekHPGracza.Name = "PictureBoxPasekHPGracza";
            this.PictureBoxPasekHPGracza.Size = new System.Drawing.Size(416, 17);
            this.PictureBoxPasekHPGracza.TabIndex = 6;
            this.PictureBoxPasekHPGracza.TabStop = false;
            // 
            // PictureBoxPasekEnergiiGracza
            // 
            this.PictureBoxPasekEnergiiGracza.Location = new System.Drawing.Point(3, 26);
            this.PictureBoxPasekEnergiiGracza.Name = "PictureBoxPasekEnergiiGracza";
            this.PictureBoxPasekEnergiiGracza.Size = new System.Drawing.Size(416, 17);
            this.PictureBoxPasekEnergiiGracza.TabIndex = 8;
            this.PictureBoxPasekEnergiiGracza.TabStop = false;
            // 
            // PanelDanychPrzeciwnika
            // 
            this.PanelDanychPrzeciwnika.BackColor = System.Drawing.Color.Transparent;
            this.PanelDanychPrzeciwnika.Controls.Add(this.LabelDanePrzeciwnika);
            this.PanelDanychPrzeciwnika.Controls.Add(this.PictureBoxPasekHPPrzeciwnika);
            this.PanelDanychPrzeciwnika.Controls.Add(this.PictureBoxPasekEnergiiPrzeciwnika);
            this.PanelDanychPrzeciwnika.Location = new System.Drawing.Point(483, 12);
            this.PanelDanychPrzeciwnika.Name = "PanelDanychPrzeciwnika";
            this.PanelDanychPrzeciwnika.Size = new System.Drawing.Size(424, 89);
            this.PanelDanychPrzeciwnika.TabIndex = 9;
            // 
            // LabelDanePrzeciwnika
            // 
            this.LabelDanePrzeciwnika.ForeColor = System.Drawing.Color.Yellow;
            this.LabelDanePrzeciwnika.Location = new System.Drawing.Point(3, 46);
            this.LabelDanePrzeciwnika.Name = "LabelDanePrzeciwnika";
            this.LabelDanePrzeciwnika.Size = new System.Drawing.Size(418, 43);
            this.LabelDanePrzeciwnika.TabIndex = 8;
            this.LabelDanePrzeciwnika.Text = "Tutaj powinny wyświetlić się informacje o przeciwniku";
            // 
            // PictureBoxPasekHPPrzeciwnika
            // 
            this.PictureBoxPasekHPPrzeciwnika.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxPasekHPPrzeciwnika.Name = "PictureBoxPasekHPPrzeciwnika";
            this.PictureBoxPasekHPPrzeciwnika.Size = new System.Drawing.Size(418, 17);
            this.PictureBoxPasekHPPrzeciwnika.TabIndex = 5;
            this.PictureBoxPasekHPPrzeciwnika.TabStop = false;
            // 
            // PictureBoxPasekEnergiiPrzeciwnika
            // 
            this.PictureBoxPasekEnergiiPrzeciwnika.Location = new System.Drawing.Point(3, 26);
            this.PictureBoxPasekEnergiiPrzeciwnika.Name = "PictureBoxPasekEnergiiPrzeciwnika";
            this.PictureBoxPasekEnergiiPrzeciwnika.Size = new System.Drawing.Size(418, 17);
            this.PictureBoxPasekEnergiiPrzeciwnika.TabIndex = 7;
            this.PictureBoxPasekEnergiiPrzeciwnika.TabStop = false;
            // 
            // PanelDanychGracza
            // 
            this.PanelDanychGracza.BackColor = System.Drawing.Color.Transparent;
            this.PanelDanychGracza.Controls.Add(this.LabelDaneGracza);
            this.PanelDanychGracza.Controls.Add(this.PictureBoxPasekHPGracza);
            this.PanelDanychGracza.Controls.Add(this.PictureBoxPasekEnergiiGracza);
            this.PanelDanychGracza.Location = new System.Drawing.Point(411, 107);
            this.PanelDanychGracza.Name = "PanelDanychGracza";
            this.PanelDanychGracza.Size = new System.Drawing.Size(422, 100);
            this.PanelDanychGracza.TabIndex = 10;
            // 
            // LabelDaneGracza
            // 
            this.LabelDaneGracza.ForeColor = System.Drawing.Color.Yellow;
            this.LabelDaneGracza.Location = new System.Drawing.Point(3, 46);
            this.LabelDaneGracza.Name = "LabelDaneGracza";
            this.LabelDaneGracza.Size = new System.Drawing.Size(416, 54);
            this.LabelDaneGracza.TabIndex = 9;
            this.LabelDaneGracza.Text = "Tutaj powinny wyświetlić się informacje o graczu";
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.ForeColor = System.Drawing.Color.Red;
            this.LabelInformacje.Location = new System.Drawing.Point(16, 47);
            this.LabelInformacje.Multiline = true;
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.ReadOnly = true;
            this.LabelInformacje.Size = new System.Drawing.Size(379, 149);
            this.LabelInformacje.TabIndex = 11;
            this.LabelInformacje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EkranWalka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(970, 780);
            this.Controls.Add(this.LabelInformacje);
            this.Controls.Add(this.PanelDanychGracza);
            this.Controls.Add(this.PanelDanychPrzeciwnika);
            this.Controls.Add(this.FlowLayoutPanelWyborAtakuFizycznego);
            this.Controls.Add(this.FlowLayoutPanelWyborAtakuMagicznego);
            this.Controls.Add(this.FlowLayoutPanelWyborMikstury);
            this.Controls.Add(this.FlowLayoutPanelWyboru);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranWalka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Walka";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EkranWalka_FormClosing);
            this.FlowLayoutPanelWyborAtakuFizycznego.ResumeLayout(false);
            this.FlowLayoutPanelWyborAtakuMagicznego.ResumeLayout(false);
            this.FlowLayoutPanelWyborMikstury.ResumeLayout(false);
            this.FlowLayoutPanelWyboru.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekHPGracza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekEnergiiGracza)).EndInit();
            this.PanelDanychPrzeciwnika.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekHPPrzeciwnika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPasekEnergiiPrzeciwnika)).EndInit();
            this.PanelDanychGracza.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PictureBoxUcieczka;
        private System.Windows.Forms.Label PictureBoxAtakMagiczny;
        private System.Windows.Forms.Label PictureBoxEkwipunek;
        private System.Windows.Forms.Label PictureBoxAtakFizyczny;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyborAtakuFizycznego;
        private System.Windows.Forms.Label PictureBoxWyjdzZAtakowFizycznych;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyborAtakuMagicznego;
        private System.Windows.Forms.Label pictureBoxWyjdzZAtakowMagicznych;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyborMikstury;
        private System.Windows.Forms.Label pictureBoxWyjdzZEkwipunku;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyboru;
        private System.Windows.Forms.Timer TimerDoZamkniecia;
        private System.Windows.Forms.PictureBox PictureBoxPasekHPGracza;
        private System.Windows.Forms.PictureBox PictureBoxPasekEnergiiGracza;
        private System.Windows.Forms.Panel PanelDanychPrzeciwnika;
        private System.Windows.Forms.Panel PanelDanychGracza;
        private System.Windows.Forms.Label LabelDanePrzeciwnika;
        private System.Windows.Forms.Label LabelDaneGracza;
        private System.Windows.Forms.PictureBox PictureBoxPasekHPPrzeciwnika;
        private System.Windows.Forms.PictureBox PictureBoxPasekEnergiiPrzeciwnika;
        private System.Windows.Forms.TextBox LabelInformacje;
    }
}