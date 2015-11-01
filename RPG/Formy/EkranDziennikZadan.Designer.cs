namespace RPG
{
    partial class EkranDziennikZadan
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
            this.ListBoxZadania = new System.Windows.Forms.ListBox();
            this.LabelZadania = new System.Windows.Forms.Label();
            this.LabelOpis = new System.Windows.Forms.Label();
            this.LabelOpisZadania = new System.Windows.Forms.Label();
            this.PictureBoxZamknij = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZamknij)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxZadania
            // 
            this.ListBoxZadania.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(108)))));
            this.ListBoxZadania.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ListBoxZadania.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ListBoxZadania.FormattingEnabled = true;
            this.ListBoxZadania.ItemHeight = 23;
            this.ListBoxZadania.Items.AddRange(new object[] {
            "Głodne wilki dwa"});
            this.ListBoxZadania.Location = new System.Drawing.Point(107, 76);
            this.ListBoxZadania.Name = "ListBoxZadania";
            this.ListBoxZadania.Size = new System.Drawing.Size(226, 257);
            this.ListBoxZadania.TabIndex = 0;
            this.ListBoxZadania.SelectedIndexChanged += new System.EventHandler(this.ListBoxZadania_SelectedIndexChanged);
            // 
            // LabelZadania
            // 
            this.LabelZadania.AutoSize = true;
            this.LabelZadania.Font = new System.Drawing.Font("Segoe Print", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelZadania.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LabelZadania.Location = new System.Drawing.Point(95, 9);
            this.LabelZadania.Name = "LabelZadania";
            this.LabelZadania.Size = new System.Drawing.Size(205, 71);
            this.LabelZadania.TabIndex = 1;
            this.LabelZadania.Text = "Zadania:";
            // 
            // LabelOpis
            // 
            this.LabelOpis.AutoSize = true;
            this.LabelOpis.Font = new System.Drawing.Font("Segoe Print", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelOpis.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LabelOpis.Location = new System.Drawing.Point(493, 9);
            this.LabelOpis.Name = "LabelOpis";
            this.LabelOpis.Size = new System.Drawing.Size(193, 71);
            this.LabelOpis.TabIndex = 2;
            this.LabelOpis.Text = "Notatki:";
            // 
            // LabelOpisZadania
            // 
            this.LabelOpisZadania.Font = new System.Drawing.Font("Segoe Print", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelOpisZadania.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LabelOpisZadania.Location = new System.Drawing.Point(502, 76);
            this.LabelOpisZadania.Name = "LabelOpisZadania";
            this.LabelOpisZadania.Size = new System.Drawing.Size(213, 277);
            this.LabelOpisZadania.TabIndex = 3;
            this.LabelOpisZadania.Text = "Kliknij na zadanie, aby wyświetlić opis.";
            // 
            // PictureBoxZamknij
            // 
            this.PictureBoxZamknij.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxZamknij.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxZamknij.Location = new System.Drawing.Point(679, 356);
            this.PictureBoxZamknij.Name = "PictureBoxZamknij";
            this.PictureBoxZamknij.Size = new System.Drawing.Size(158, 60);
            this.PictureBoxZamknij.TabIndex = 23;
            this.PictureBoxZamknij.TabStop = false;
            this.PictureBoxZamknij.Click += new System.EventHandler(this.PictureBoxZamknij_Click);
            // 
            // EkranDziennikZadan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(883, 451);
            this.Controls.Add(this.PictureBoxZamknij);
            this.Controls.Add(this.LabelOpisZadania);
            this.Controls.Add(this.ListBoxZadania);
            this.Controls.Add(this.LabelOpis);
            this.Controls.Add(this.LabelZadania);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranDziennikZadan";
            this.Text = "EkranDziennikZadan";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EkranOpcje_FormClosing);
            this.Load += new System.EventHandler(this.EkranDziennikZadan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZamknij)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxZadania;
        private System.Windows.Forms.Label LabelZadania;
        private System.Windows.Forms.Label LabelOpis;
        private System.Windows.Forms.Label LabelOpisZadania;
        private System.Windows.Forms.PictureBox PictureBoxZamknij;
    }
}