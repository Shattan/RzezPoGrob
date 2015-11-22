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
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.PictureBoxZamknij = new System.Windows.Forms.PictureBox();
            this.panelPraweMenu = new System.Windows.Forms.Panel();
            this.timerPrzeplywCzasu = new System.Windows.Forms.Timer(this.components);
            this.PictureBoxLewyMowiacy = new System.Windows.Forms.PictureBox();
            this.PictureBoxPrawyMowiacy = new System.Windows.Forms.PictureBox();
            this.FlowLayoutPanelMenuWyboru = new System.Windows.Forms.FlowLayoutPanel();
            this.PictureBoxKontynuuj = new System.Windows.Forms.PictureBox();
            this.PictureBoxZapisz = new System.Windows.Forms.PictureBox();
            this.PictureBoxWczytaj = new System.Windows.Forms.PictureBox();
            this.PictureBoxWyjdzDoMenu = new System.Windows.Forms.PictureBox();
            this.PictureBoxWyjdzZGry = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZamknij)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLewyMowiacy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPrawyMowiacy)).BeginInit();
            this.FlowLayoutPanelMenuWyboru.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxKontynuuj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZapisz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWczytaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdzDoMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdzZGry)).BeginInit();
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
            // FlowLayoutPanelMenuWyboru
            // 
            this.FlowLayoutPanelMenuWyboru.Controls.Add(this.PictureBoxKontynuuj);
            this.FlowLayoutPanelMenuWyboru.Controls.Add(this.PictureBoxZapisz);
            this.FlowLayoutPanelMenuWyboru.Controls.Add(this.PictureBoxWczytaj);
            this.FlowLayoutPanelMenuWyboru.Controls.Add(this.PictureBoxWyjdzDoMenu);
            this.FlowLayoutPanelMenuWyboru.Controls.Add(this.PictureBoxWyjdzZGry);
            this.FlowLayoutPanelMenuWyboru.Location = new System.Drawing.Point(404, 131);
            this.FlowLayoutPanelMenuWyboru.Name = "FlowLayoutPanelMenuWyboru";
            this.FlowLayoutPanelMenuWyboru.Size = new System.Drawing.Size(200, 276);
            this.FlowLayoutPanelMenuWyboru.TabIndex = 32;
            this.FlowLayoutPanelMenuWyboru.Visible = false;
            // 
            // PictureBoxKontynuuj
            // 
            this.PictureBoxKontynuuj.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxKontynuuj.Name = "PictureBoxKontynuuj";
            this.PictureBoxKontynuuj.Size = new System.Drawing.Size(100, 32);
            this.PictureBoxKontynuuj.TabIndex = 1;
            this.PictureBoxKontynuuj.TabStop = false;
            // 
            // PictureBoxZapisz
            // 
            this.PictureBoxZapisz.Location = new System.Drawing.Point(3, 41);
            this.PictureBoxZapisz.Name = "PictureBoxZapisz";
            this.PictureBoxZapisz.Size = new System.Drawing.Size(100, 32);
            this.PictureBoxZapisz.TabIndex = 0;
            this.PictureBoxZapisz.TabStop = false;
            // 
            // PictureBoxWczytaj
            // 
            this.PictureBoxWczytaj.Location = new System.Drawing.Point(3, 79);
            this.PictureBoxWczytaj.Name = "PictureBoxWczytaj";
            this.PictureBoxWczytaj.Size = new System.Drawing.Size(100, 32);
            this.PictureBoxWczytaj.TabIndex = 2;
            this.PictureBoxWczytaj.TabStop = false;
            // 
            // PictureBoxWyjdzDoMenu
            // 
            this.PictureBoxWyjdzDoMenu.Location = new System.Drawing.Point(3, 117);
            this.PictureBoxWyjdzDoMenu.Name = "PictureBoxWyjdzDoMenu";
            this.PictureBoxWyjdzDoMenu.Size = new System.Drawing.Size(100, 32);
            this.PictureBoxWyjdzDoMenu.TabIndex = 3;
            this.PictureBoxWyjdzDoMenu.TabStop = false;
            // 
            // PictureBoxWyjdzZGry
            // 
            this.PictureBoxWyjdzZGry.Location = new System.Drawing.Point(3, 155);
            this.PictureBoxWyjdzZGry.Name = "PictureBoxWyjdzZGry";
            this.PictureBoxWyjdzZGry.Size = new System.Drawing.Size(100, 32);
            this.PictureBoxWyjdzZGry.TabIndex = 4;
            this.PictureBoxWyjdzZGry.TabStop = false;
            // 
            // EkranGry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.FlowLayoutPanelMenuWyboru);
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
            this.FlowLayoutPanelMenuWyboru.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxKontynuuj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZapisz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWczytaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdzDoMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdzZGry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.PictureBox PictureBoxZamknij;
        private System.Windows.Forms.Panel panelPraweMenu;
        private System.Windows.Forms.Timer timerPrzeplywCzasu;
        private System.Windows.Forms.PictureBox PictureBoxLewyMowiacy;
        private System.Windows.Forms.PictureBox PictureBoxPrawyMowiacy;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelMenuWyboru;
        private System.Windows.Forms.PictureBox PictureBoxKontynuuj;
        private System.Windows.Forms.PictureBox PictureBoxZapisz;
        private System.Windows.Forms.PictureBox PictureBoxWczytaj;
        private System.Windows.Forms.PictureBox PictureBoxWyjdzDoMenu;
        private System.Windows.Forms.PictureBox PictureBoxWyjdzZGry;
    }
}