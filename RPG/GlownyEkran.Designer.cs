﻿namespace RPG
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
            this.Wyswietlacz = new System.Windows.Forms.PictureBox();
            this.PanelInformacje = new System.Windows.Forms.Panel();
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.Zegar = new System.Windows.Forms.Timer(this.components);
            this.PanelOpcje = new System.Windows.Forms.Panel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelOpcjeTytul = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).BeginInit();
            this.PanelInformacje.SuspendLayout();
            this.PanelOpcje.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wyswietlacz
            // 
            this.Wyswietlacz.BackColor = System.Drawing.Color.Black;
            this.Wyswietlacz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Wyswietlacz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wyswietlacz.Location = new System.Drawing.Point(0, 0);
            this.Wyswietlacz.Name = "Wyswietlacz";
            this.Wyswietlacz.Size = new System.Drawing.Size(855, 368);
            this.Wyswietlacz.TabIndex = 0;
            this.Wyswietlacz.TabStop = false;
            // 
            // PanelInformacje
            // 
            this.PanelInformacje.BackColor = System.Drawing.Color.Black;
            this.PanelInformacje.Controls.Add(this.LabelInformacje);
            this.PanelInformacje.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelInformacje.ForeColor = System.Drawing.Color.Yellow;
            this.PanelInformacje.Location = new System.Drawing.Point(792, 0);
            this.PanelInformacje.Name = "PanelInformacje";
            this.PanelInformacje.Size = new System.Drawing.Size(63, 100);
            this.PanelInformacje.TabIndex = 4;
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInformacje.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.Location = new System.Drawing.Point(0, 0);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(63, 100);
            this.LabelInformacje.TabIndex = 0;
            this.LabelInformacje.Text = "LabelInformacje";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Zegar
            // 
            this.Zegar.Tick += new System.EventHandler(this.Zegar_Tick);
            // 
            // PanelOpcje
            // 
            this.PanelOpcje.BackColor = System.Drawing.Color.Black;
            this.PanelOpcje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelOpcje.Controls.Add(this.GroupBox2);
            this.PanelOpcje.Controls.Add(this.LabelOpcjeTytul);
            this.PanelOpcje.Controls.Add(this.GroupBox1);
            this.PanelOpcje.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PanelOpcje.ForeColor = System.Drawing.Color.Yellow;
            this.PanelOpcje.Location = new System.Drawing.Point(12, 28);
            this.PanelOpcje.Name = "PanelOpcje";
            this.PanelOpcje.Size = new System.Drawing.Size(374, 178);
            this.PanelOpcje.TabIndex = 5;
            this.PanelOpcje.Visible = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Location = new System.Drawing.Point(3, 27);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(179, 142);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Pierwsze ustawienia";
            // 
            // LabelOpcjeTytul
            // 
            this.LabelOpcjeTytul.AutoSize = true;
            this.LabelOpcjeTytul.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelOpcjeTytul.Location = new System.Drawing.Point(3, 0);
            this.LabelOpcjeTytul.Name = "LabelOpcjeTytul";
            this.LabelOpcjeTytul.Size = new System.Drawing.Size(108, 24);
            this.LabelOpcjeTytul.TabIndex = 1;
            this.LabelOpcjeTytul.Text = "Ustawienia";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Location = new System.Drawing.Point(188, 27);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(179, 142);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Drugie ustawienia";
            // 
            // GlownyEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(855, 368);
            this.Controls.Add(this.PanelOpcje);
            this.Controls.Add(this.PanelInformacje);
            this.Controls.Add(this.Wyswietlacz);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GlownyEkran";
            this.Text = "Rzeź Po Grób";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).EndInit();
            this.PanelInformacje.ResumeLayout(false);
            this.PanelOpcje.ResumeLayout(false);
            this.PanelOpcje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Wyswietlacz;
        private System.Windows.Forms.Panel PanelInformacje;
        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.Timer Zegar;
        private System.Windows.Forms.Panel PanelOpcje;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Label LabelOpcjeTytul;
        private System.Windows.Forms.GroupBox GroupBox1;
    }
}

