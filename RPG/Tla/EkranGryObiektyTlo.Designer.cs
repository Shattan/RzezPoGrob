namespace RPG
{
    partial class EkranGryObiektyTlo
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
            this.panelMapa = new System.Windows.Forms.Panel();
            this.pBGracz = new System.Windows.Forms.PictureBox();
            this.panelMapa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBGracz)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMapa
            // 
            this.panelMapa.BackColor = System.Drawing.Color.Black;
            this.panelMapa.Controls.Add(this.pBGracz);
            this.panelMapa.Location = new System.Drawing.Point(0, 0);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(10000, 10000);
            this.panelMapa.TabIndex = 31;
            // 
            // pBGracz
            // 
            this.pBGracz.BackColor = System.Drawing.Color.Transparent;
            this.pBGracz.Location = new System.Drawing.Point(610, 199);
            this.pBGracz.Name = "pBGracz";
            this.pBGracz.Size = new System.Drawing.Size(100, 100);
            this.pBGracz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pBGracz.TabIndex = 29;
            this.pBGracz.TabStop = false;
            // 
            // EkranGryObiektyTlo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1405, 672);
            this.Controls.Add(this.panelMapa);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranGryObiektyTlo";
            this.Text = "EkranGryTloObiekty";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EkranGryObiektyTlo_FormClosing);
            this.Shown += new System.EventHandler(this.EkranGryTloObiekty_Shown);
            this.panelMapa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBGracz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelMapa;
        public System.Windows.Forms.PictureBox pBGracz;
    }
}