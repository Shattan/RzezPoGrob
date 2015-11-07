namespace RPG
{
    partial class EkranWalkaTlo
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
            this.PictureBoxTloEnergiiGracza = new System.Windows.Forms.PictureBox();
            this.PanelDanychGracza = new System.Windows.Forms.Panel();
            this.PanelDanychPrzeciwnika = new System.Windows.Forms.Panel();
            this.PictureBoxTloEnergiiPrzeciwnika = new System.Windows.Forms.PictureBox();
            this.PictureBoxTloHPPrzeciwnika = new System.Windows.Forms.PictureBox();
            this.PictureBoxTloHPGracza = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloEnergiiGracza)).BeginInit();
            this.PanelDanychGracza.SuspendLayout();
            this.PanelDanychPrzeciwnika.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloEnergiiPrzeciwnika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloHPPrzeciwnika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloHPGracza)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxTloEnergiiGracza
            // 
            this.PictureBoxTloEnergiiGracza.Location = new System.Drawing.Point(3, 26);
            this.PictureBoxTloEnergiiGracza.Name = "PictureBoxTloEnergiiGracza";
            this.PictureBoxTloEnergiiGracza.Size = new System.Drawing.Size(416, 17);
            this.PictureBoxTloEnergiiGracza.TabIndex = 14;
            this.PictureBoxTloEnergiiGracza.TabStop = false;
            // 
            // PanelDanychGracza
            // 
            this.PanelDanychGracza.BackColor = System.Drawing.Color.Transparent;
            this.PanelDanychGracza.Controls.Add(this.PictureBoxTloEnergiiGracza);
            this.PanelDanychGracza.Controls.Add(this.PictureBoxTloHPGracza);
            this.PanelDanychGracza.Location = new System.Drawing.Point(12, 141);
            this.PanelDanychGracza.Name = "PanelDanychGracza";
            this.PanelDanychGracza.Size = new System.Drawing.Size(422, 100);
            this.PanelDanychGracza.TabIndex = 16;
            // 
            // PanelDanychPrzeciwnika
            // 
            this.PanelDanychPrzeciwnika.BackColor = System.Drawing.Color.Transparent;
            this.PanelDanychPrzeciwnika.Controls.Add(this.PictureBoxTloEnergiiPrzeciwnika);
            this.PanelDanychPrzeciwnika.Controls.Add(this.PictureBoxTloHPPrzeciwnika);
            this.PanelDanychPrzeciwnika.Location = new System.Drawing.Point(331, 12);
            this.PanelDanychPrzeciwnika.Name = "PanelDanychPrzeciwnika";
            this.PanelDanychPrzeciwnika.Size = new System.Drawing.Size(424, 89);
            this.PanelDanychPrzeciwnika.TabIndex = 15;
            // 
            // PictureBoxTloEnergiiPrzeciwnika
            // 
            this.PictureBoxTloEnergiiPrzeciwnika.Location = new System.Drawing.Point(6, 26);
            this.PictureBoxTloEnergiiPrzeciwnika.Name = "PictureBoxTloEnergiiPrzeciwnika";
            this.PictureBoxTloEnergiiPrzeciwnika.Size = new System.Drawing.Size(418, 17);
            this.PictureBoxTloEnergiiPrzeciwnika.TabIndex = 12;
            this.PictureBoxTloEnergiiPrzeciwnika.TabStop = false;
            // 
            // PictureBoxTloHPPrzeciwnika
            // 
            this.PictureBoxTloHPPrzeciwnika.Location = new System.Drawing.Point(6, 3);
            this.PictureBoxTloHPPrzeciwnika.Name = "PictureBoxTloHPPrzeciwnika";
            this.PictureBoxTloHPPrzeciwnika.Size = new System.Drawing.Size(418, 17);
            this.PictureBoxTloHPPrzeciwnika.TabIndex = 11;
            this.PictureBoxTloHPPrzeciwnika.TabStop = false;
            // 
            // PictureBoxTloHPGracza
            // 
            this.PictureBoxTloHPGracza.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxTloHPGracza.Name = "PictureBoxTloHPGracza";
            this.PictureBoxTloHPGracza.Size = new System.Drawing.Size(416, 17);
            this.PictureBoxTloHPGracza.TabIndex = 13;
            this.PictureBoxTloHPGracza.TabStop = false;
            // 
            // EkranWalkaTlo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(767, 375);
            this.Controls.Add(this.PanelDanychGracza);
            this.Controls.Add(this.PanelDanychPrzeciwnika);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranWalkaTlo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EkranWalkaTlo";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EkranWalkaTlo_Load);
            this.Shown += new System.EventHandler(this.EkranNowaGraTlo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloEnergiiGracza)).EndInit();
            this.PanelDanychGracza.ResumeLayout(false);
            this.PanelDanychPrzeciwnika.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloEnergiiPrzeciwnika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloHPPrzeciwnika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTloHPGracza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxTloEnergiiGracza;
        private System.Windows.Forms.Panel PanelDanychGracza;
        private System.Windows.Forms.Panel PanelDanychPrzeciwnika;
        private System.Windows.Forms.PictureBox PictureBoxTloHPGracza;
        private System.Windows.Forms.PictureBox PictureBoxTloEnergiiPrzeciwnika;
        private System.Windows.Forms.PictureBox PictureBoxTloHPPrzeciwnika;

    }
}