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
            this.Wyswietlacz = new System.Windows.Forms.PictureBox();
            this.PanelInformacyjny = new System.Windows.Forms.Panel();
            this.LabelInformacyjny = new System.Windows.Forms.Label();
            this.Zegar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).BeginInit();
            this.PanelInformacyjny.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wyswietlacz
            // 
            this.Wyswietlacz.BackColor = System.Drawing.Color.Black;
            this.Wyswietlacz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Wyswietlacz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wyswietlacz.Location = new System.Drawing.Point(0, 0);
            this.Wyswietlacz.Name = "Wyswietlacz";
            this.Wyswietlacz.Size = new System.Drawing.Size(620, 326);
            this.Wyswietlacz.TabIndex = 0;
            this.Wyswietlacz.TabStop = false;
            // 
            // PanelInformacyjny
            // 
            this.PanelInformacyjny.BackColor = System.Drawing.Color.Black;
            this.PanelInformacyjny.Controls.Add(this.LabelInformacyjny);
            this.PanelInformacyjny.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelInformacyjny.ForeColor = System.Drawing.Color.Yellow;
            this.PanelInformacyjny.Location = new System.Drawing.Point(12, 214);
            this.PanelInformacyjny.Name = "PanelInformacyjny";
            this.PanelInformacyjny.Size = new System.Drawing.Size(425, 100);
            this.PanelInformacyjny.TabIndex = 4;
            // 
            // LabelInformacyjny
            // 
            this.LabelInformacyjny.BackColor = System.Drawing.Color.Transparent;
            this.LabelInformacyjny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInformacyjny.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacyjny.Location = new System.Drawing.Point(0, 0);
            this.LabelInformacyjny.Name = "LabelInformacyjny";
            this.LabelInformacyjny.Size = new System.Drawing.Size(425, 100);
            this.LabelInformacyjny.TabIndex = 0;
            this.LabelInformacyjny.Text = "LabelInformacyjny";
            this.LabelInformacyjny.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Zegar
            // 
            this.Zegar.Tick += new System.EventHandler(this.Zegar_Tick);
            // 
            // GlownyEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(620, 326);
            this.Controls.Add(this.PanelInformacyjny);
            this.Controls.Add(this.Wyswietlacz);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GlownyEkran";
            this.Text = "Rzeź Po Grób";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Wyswietlacz)).EndInit();
            this.PanelInformacyjny.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Wyswietlacz;
        private System.Windows.Forms.Panel PanelInformacyjny;
        private System.Windows.Forms.Label LabelInformacyjny;
        private System.Windows.Forms.Timer Zegar;
    }
}

