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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EkranGry));
            this.panelPraweMenu = new System.Windows.Forms.Panel();
            this.timerPrzeplywCzasu = new System.Windows.Forms.Timer(this.components);
            this.Wstecz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelPraweMenu
            // 
            this.panelPraweMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelPraweMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPraweMenu.BackgroundImage")));
            this.panelPraweMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPraweMenu.Location = new System.Drawing.Point(1114, 46);
            this.panelPraweMenu.Name = "panelPraweMenu";
            this.panelPraweMenu.Size = new System.Drawing.Size(229, 589);
            this.panelPraweMenu.TabIndex = 29;
            // 
            // timerPrzeplywCzasu
            // 
            this.timerPrzeplywCzasu.Interval = 1;
            this.timerPrzeplywCzasu.Tick += new System.EventHandler(this.timerPrzeplywCzasu_Tick);
            // 
            // Wstecz
            // 
            this.Wstecz.AutoSize = true;
            this.Wstecz.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Wstecz.Location = new System.Drawing.Point(65, 46);
            this.Wstecz.Name = "Wstecz";
            this.Wstecz.Size = new System.Drawing.Size(91, 32);
            this.Wstecz.TabIndex = 30;
            this.Wstecz.Text = "Powrót";
            this.Wstecz.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // EkranGry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.Wstecz);
            this.Controls.Add(this.panelPraweMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranGry";
            this.Text = "Gra";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EkranOpcje_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPraweMenu;
        private System.Windows.Forms.Timer timerPrzeplywCzasu;
        private System.Windows.Forms.Label Wstecz;
    }
}