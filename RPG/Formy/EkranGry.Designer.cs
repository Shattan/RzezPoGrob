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
            this.PictureBoxZamknij = new System.Windows.Forms.PictureBox();
            this.panelPraweMenu = new System.Windows.Forms.Panel();
            this.timerPrzeplywCzasu = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZamknij)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(800, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // PictureBoxZamknij
            // 
            this.PictureBoxZamknij.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PictureBoxZamknij.Location = new System.Drawing.Point(81, 30);
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
            // EkranGry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.panelPraweMenu);
            this.Controls.Add(this.PictureBoxZamknij);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PictureBoxZamknij;
        private System.Windows.Forms.Panel panelPraweMenu;
        private System.Windows.Forms.Timer timerPrzeplywCzasu;
    }
}