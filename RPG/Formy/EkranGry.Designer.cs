﻿namespace RPG
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
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.PictureBoxZamknij = new System.Windows.Forms.PictureBox();
            this.panelPraweMenu = new System.Windows.Forms.Panel();
            this.timerPrzeplywCzasu = new System.Windows.Forms.Timer(this.components);
            this.PictureBoxLewyMowiacy = new System.Windows.Forms.PictureBox();
            this.PictureBoxPrawyMowiacy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZamknij)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLewyMowiacy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPrawyMowiacy)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.BackColor = System.Drawing.Color.Black;
            this.LabelInformacje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.ForeColor = System.Drawing.Color.Red;
            this.LabelInformacje.Location = new System.Drawing.Point(231, 16);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(514, 94);
            this.LabelInformacje.TabIndex = 1;
            this.LabelInformacje.Text = "Tutaj powinny pojawiać się informacje na temat aktualnie wykonywanej czynności or" +
    "az dialogi.";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBoxZamknij
            // 
            this.PictureBoxZamknij.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PictureBoxZamknij.Location = new System.Drawing.Point(81, 46);
            this.PictureBoxZamknij.Name = "PictureBoxZamknij";
            this.PictureBoxZamknij.Size = new System.Drawing.Size(144, 64);
            this.PictureBoxZamknij.TabIndex = 2;
            this.PictureBoxZamknij.TabStop = false;
            this.PictureBoxZamknij.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // panelPraweMenu
            // 
            this.panelPraweMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelPraweMenu.Location = new System.Drawing.Point(1453, -6);
            this.panelPraweMenu.Name = "panelPraweMenu";
            this.panelPraweMenu.Size = new System.Drawing.Size(88, 73);
            this.panelPraweMenu.TabIndex = 29;
            // 
            // timerPrzeplywCzasu
            // 
            this.timerPrzeplywCzasu.Interval = 5;
            this.timerPrzeplywCzasu.Tick += new System.EventHandler(this.timerPrzeplywCzasu_Tick);
            // 
            // PictureBoxLewyMowiacy
            // 
            this.PictureBoxLewyMowiacy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PictureBoxLewyMowiacy.Location = new System.Drawing.Point(81, 116);
            this.PictureBoxLewyMowiacy.Name = "PictureBoxLewyMowiacy";
            this.PictureBoxLewyMowiacy.Size = new System.Drawing.Size(100, 50);
            this.PictureBoxLewyMowiacy.TabIndex = 30;
            this.PictureBoxLewyMowiacy.TabStop = false;
            // 
            // PictureBoxPrawyMowiacy
            // 
            this.PictureBoxPrawyMowiacy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PictureBoxPrawyMowiacy.Location = new System.Drawing.Point(187, 116);
            this.PictureBoxPrawyMowiacy.Name = "PictureBoxPrawyMowiacy";
            this.PictureBoxPrawyMowiacy.Size = new System.Drawing.Size(100, 50);
            this.PictureBoxPrawyMowiacy.TabIndex = 31;
            this.PictureBoxPrawyMowiacy.TabStop = false;
            // 
            // EkranGry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.PictureBoxPrawyMowiacy);
            this.Controls.Add(this.PictureBoxLewyMowiacy);
            this.Controls.Add(this.panelPraweMenu);
            this.Controls.Add(this.PictureBoxZamknij);
            this.Controls.Add(this.LabelInformacje);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranGry";
            this.Text = "Gra";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EkranOpcje_FormClosing);
            this.Load += new System.EventHandler(this.EkranGry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.przechwytywanieKlawiszy_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.przechwytywanieKlawiszy_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZamknij)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLewyMowiacy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPrawyMowiacy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.PictureBox PictureBoxZamknij;
        private System.Windows.Forms.Panel panelPraweMenu;
        private System.Windows.Forms.Timer timerPrzeplywCzasu;
        private System.Windows.Forms.PictureBox PictureBoxLewyMowiacy;
        private System.Windows.Forms.PictureBox PictureBoxPrawyMowiacy;
    }
}