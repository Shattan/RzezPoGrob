﻿namespace RPG
{
    partial class EkranGryTloMapa
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
            this.PictureBoxTrawa = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTrawa)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxTrawa
            // 
            this.PictureBoxTrawa.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxTrawa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxTrawa.Location = new System.Drawing.Point(345, 84);
            this.PictureBoxTrawa.Name = "PictureBoxTrawa";
            this.PictureBoxTrawa.Size = new System.Drawing.Size(172, 129);
            this.PictureBoxTrawa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBoxTrawa.TabIndex = 8;
            this.PictureBoxTrawa.TabStop = false;
            // 
            // EkranGryTloMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(880, 601);
            this.Controls.Add(this.PictureBoxTrawa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranGryTloMapa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EkranGryTloMapa";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.EkranGryTloMapa_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTrawa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxTrawa;
    }
}