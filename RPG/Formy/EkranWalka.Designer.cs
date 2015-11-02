namespace RPG
{
    partial class EkranWalka
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
            this.buttonWygralem = new System.Windows.Forms.Button();
            this.buttonPrzegralem = new System.Windows.Forms.Button();
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.PictureBoxUcieczka = new System.Windows.Forms.PictureBox();
            this.PictureBoxAtakMagiczny = new System.Windows.Forms.PictureBox();
            this.PictureBoxEkwipunek = new System.Windows.Forms.PictureBox();
            this.PictureBoxAtakFizyczny = new System.Windows.Forms.PictureBox();
            this.FlowLayoutPanelWyborAtakuFizycznego = new System.Windows.Forms.FlowLayoutPanel();
            this.PictureBoxWyjdzZAtakowFizycznych = new System.Windows.Forms.PictureBox();
            this.FlowLayoutPanelWyborAtakuMagicznego = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxWyjdzZAtakowMagicznych = new System.Windows.Forms.PictureBox();
            this.FlowLayoutPanelWyborMikstury = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxWyjdzZEkwipunku = new System.Windows.Forms.PictureBox();
            this.FlowLayoutPanelWyboru = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUcieczka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAtakMagiczny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEkwipunek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAtakFizyczny)).BeginInit();
            this.FlowLayoutPanelWyborAtakuFizycznego.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdzZAtakowFizycznych)).BeginInit();
            this.FlowLayoutPanelWyborAtakuMagicznego.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWyjdzZAtakowMagicznych)).BeginInit();
            this.FlowLayoutPanelWyborMikstury.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWyjdzZEkwipunku)).BeginInit();
            this.FlowLayoutPanelWyboru.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWygralem
            // 
            this.buttonWygralem.BackColor = System.Drawing.Color.Lime;
            this.buttonWygralem.Location = new System.Drawing.Point(40, 12);
            this.buttonWygralem.Name = "buttonWygralem";
            this.buttonWygralem.Size = new System.Drawing.Size(178, 69);
            this.buttonWygralem.TabIndex = 0;
            this.buttonWygralem.Text = "Wygrałem!";
            this.buttonWygralem.UseVisualStyleBackColor = false;
            this.buttonWygralem.Click += new System.EventHandler(this.buttonWygralem_Click);
            // 
            // buttonPrzegralem
            // 
            this.buttonPrzegralem.BackColor = System.Drawing.Color.Red;
            this.buttonPrzegralem.Location = new System.Drawing.Point(224, 12);
            this.buttonPrzegralem.Name = "buttonPrzegralem";
            this.buttonPrzegralem.Size = new System.Drawing.Size(178, 69);
            this.buttonPrzegralem.TabIndex = 1;
            this.buttonPrzegralem.Text = "Przegrałem..";
            this.buttonPrzegralem.UseVisualStyleBackColor = false;
            this.buttonPrzegralem.Click += new System.EventHandler(this.buttonPrzegralem_Click);
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.BackColor = System.Drawing.Color.Black;
            this.LabelInformacje.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.ForeColor = System.Drawing.Color.Red;
            this.LabelInformacje.Location = new System.Drawing.Point(409, 450);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(393, 128);
            this.LabelInformacje.TabIndex = 2;
            this.LabelInformacje.Text = "LabelInformacje";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBoxUcieczka
            // 
            this.PictureBoxUcieczka.BackColor = System.Drawing.Color.White;
            this.PictureBoxUcieczka.Location = new System.Drawing.Point(3, 114);
            this.PictureBoxUcieczka.Name = "PictureBoxUcieczka";
            this.PictureBoxUcieczka.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxUcieczka.TabIndex = 3;
            this.PictureBoxUcieczka.TabStop = false;
            this.PictureBoxUcieczka.Click += new System.EventHandler(this.PictureBoxUcieczka_Click);
            // 
            // PictureBoxAtakMagiczny
            // 
            this.PictureBoxAtakMagiczny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PictureBoxAtakMagiczny.Location = new System.Drawing.Point(3, 40);
            this.PictureBoxAtakMagiczny.Name = "PictureBoxAtakMagiczny";
            this.PictureBoxAtakMagiczny.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxAtakMagiczny.TabIndex = 2;
            this.PictureBoxAtakMagiczny.TabStop = false;
            this.PictureBoxAtakMagiczny.Click += new System.EventHandler(this.PictureBoxAtakMagiczny_Click);
            // 
            // PictureBoxEkwipunek
            // 
            this.PictureBoxEkwipunek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PictureBoxEkwipunek.Location = new System.Drawing.Point(3, 77);
            this.PictureBoxEkwipunek.Name = "PictureBoxEkwipunek";
            this.PictureBoxEkwipunek.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxEkwipunek.TabIndex = 1;
            this.PictureBoxEkwipunek.TabStop = false;
            this.PictureBoxEkwipunek.Click += new System.EventHandler(this.PictureBoxEkwipunek_Click);
            // 
            // PictureBoxAtakFizyczny
            // 
            this.PictureBoxAtakFizyczny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PictureBoxAtakFizyczny.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxAtakFizyczny.Name = "PictureBoxAtakFizyczny";
            this.PictureBoxAtakFizyczny.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxAtakFizyczny.TabIndex = 0;
            this.PictureBoxAtakFizyczny.TabStop = false;
            this.PictureBoxAtakFizyczny.Click += new System.EventHandler(this.PictureBoxAtakFizyczny_Click);
            // 
            // FlowLayoutPanelWyborAtakuFizycznego
            // 
            this.FlowLayoutPanelWyborAtakuFizycznego.AutoScroll = true;
            this.FlowLayoutPanelWyborAtakuFizycznego.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FlowLayoutPanelWyborAtakuFizycznego.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyborAtakuFizycznego.Controls.Add(this.PictureBoxWyjdzZAtakowFizycznych);
            this.FlowLayoutPanelWyborAtakuFizycznego.Location = new System.Drawing.Point(19, 87);
            this.FlowLayoutPanelWyborAtakuFizycznego.Name = "FlowLayoutPanelWyborAtakuFizycznego";
            this.FlowLayoutPanelWyborAtakuFizycznego.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyborAtakuFizycznego.TabIndex = 0;
            this.FlowLayoutPanelWyborAtakuFizycznego.Visible = false;
            // 
            // PictureBoxWyjdzZAtakowFizycznych
            // 
            this.PictureBoxWyjdzZAtakowFizycznych.BackColor = System.Drawing.Color.Red;
            this.PictureBoxWyjdzZAtakowFizycznych.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxWyjdzZAtakowFizycznych.Name = "PictureBoxWyjdzZAtakowFizycznych";
            this.PictureBoxWyjdzZAtakowFizycznych.Size = new System.Drawing.Size(379, 31);
            this.PictureBoxWyjdzZAtakowFizycznych.TabIndex = 0;
            this.PictureBoxWyjdzZAtakowFizycznych.TabStop = false;
            this.PictureBoxWyjdzZAtakowFizycznych.Click += new System.EventHandler(this.PictureBoxWyjdzZAtakowFizycznych_Click);
            // 
            // FlowLayoutPanelWyborAtakuMagicznego
            // 
            this.FlowLayoutPanelWyborAtakuMagicznego.AutoScroll = true;
            this.FlowLayoutPanelWyborAtakuMagicznego.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.FlowLayoutPanelWyborAtakuMagicznego.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyborAtakuMagicznego.Controls.Add(this.pictureBoxWyjdzZAtakowMagicznych);
            this.FlowLayoutPanelWyborAtakuMagicznego.Location = new System.Drawing.Point(411, 87);
            this.FlowLayoutPanelWyborAtakuMagicznego.Name = "FlowLayoutPanelWyborAtakuMagicznego";
            this.FlowLayoutPanelWyborAtakuMagicznego.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyborAtakuMagicznego.TabIndex = 1;
            this.FlowLayoutPanelWyborAtakuMagicznego.Visible = false;
            // 
            // pictureBoxWyjdzZAtakowMagicznych
            // 
            this.pictureBoxWyjdzZAtakowMagicznych.BackColor = System.Drawing.Color.Red;
            this.pictureBoxWyjdzZAtakowMagicznych.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxWyjdzZAtakowMagicznych.Name = "pictureBoxWyjdzZAtakowMagicznych";
            this.pictureBoxWyjdzZAtakowMagicznych.Size = new System.Drawing.Size(379, 31);
            this.pictureBoxWyjdzZAtakowMagicznych.TabIndex = 0;
            this.pictureBoxWyjdzZAtakowMagicznych.TabStop = false;
            this.pictureBoxWyjdzZAtakowMagicznych.Click += new System.EventHandler(this.pictureBoxWyjdzZAtakowMagicznych_Click);
            // 
            // FlowLayoutPanelWyborMikstury
            // 
            this.FlowLayoutPanelWyborMikstury.AutoScroll = true;
            this.FlowLayoutPanelWyborMikstury.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FlowLayoutPanelWyborMikstury.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyborMikstury.Controls.Add(this.pictureBoxWyjdzZEkwipunku);
            this.FlowLayoutPanelWyborMikstury.Location = new System.Drawing.Point(411, 270);
            this.FlowLayoutPanelWyborMikstury.Name = "FlowLayoutPanelWyborMikstury";
            this.FlowLayoutPanelWyborMikstury.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyborMikstury.TabIndex = 1;
            this.FlowLayoutPanelWyborMikstury.Visible = false;
            // 
            // pictureBoxWyjdzZEkwipunku
            // 
            this.pictureBoxWyjdzZEkwipunku.BackColor = System.Drawing.Color.Red;
            this.pictureBoxWyjdzZEkwipunku.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxWyjdzZEkwipunku.Name = "pictureBoxWyjdzZEkwipunku";
            this.pictureBoxWyjdzZEkwipunku.Size = new System.Drawing.Size(379, 31);
            this.pictureBoxWyjdzZEkwipunku.TabIndex = 0;
            this.pictureBoxWyjdzZEkwipunku.TabStop = false;
            this.pictureBoxWyjdzZEkwipunku.Click += new System.EventHandler(this.pictureBoxWyjdzZEkwipunku_Click);
            // 
            // FlowLayoutPanelWyboru
            // 
            this.FlowLayoutPanelWyboru.AutoScroll = true;
            this.FlowLayoutPanelWyboru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FlowLayoutPanelWyboru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxAtakFizyczny);
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxAtakMagiczny);
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxEkwipunek);
            this.FlowLayoutPanelWyboru.Controls.Add(this.PictureBoxUcieczka);
            this.FlowLayoutPanelWyboru.Location = new System.Drawing.Point(16, 270);
            this.FlowLayoutPanelWyboru.Name = "FlowLayoutPanelWyboru";
            this.FlowLayoutPanelWyboru.Size = new System.Drawing.Size(386, 177);
            this.FlowLayoutPanelWyboru.TabIndex = 1;
            // 
            // EkranWalka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(970, 780);
            this.Controls.Add(this.FlowLayoutPanelWyborAtakuFizycznego);
            this.Controls.Add(this.FlowLayoutPanelWyborAtakuMagicznego);
            this.Controls.Add(this.FlowLayoutPanelWyborMikstury);
            this.Controls.Add(this.FlowLayoutPanelWyboru);
            this.Controls.Add(this.LabelInformacje);
            this.Controls.Add(this.buttonPrzegralem);
            this.Controls.Add(this.buttonWygralem);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranWalka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Walka";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUcieczka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAtakMagiczny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEkwipunek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAtakFizyczny)).EndInit();
            this.FlowLayoutPanelWyborAtakuFizycznego.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjdzZAtakowFizycznych)).EndInit();
            this.FlowLayoutPanelWyborAtakuMagicznego.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWyjdzZAtakowMagicznych)).EndInit();
            this.FlowLayoutPanelWyborMikstury.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWyjdzZEkwipunku)).EndInit();
            this.FlowLayoutPanelWyboru.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWygralem;
        private System.Windows.Forms.Button buttonPrzegralem;
        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.PictureBox PictureBoxUcieczka;
        private System.Windows.Forms.PictureBox PictureBoxAtakMagiczny;
        private System.Windows.Forms.PictureBox PictureBoxEkwipunek;
        private System.Windows.Forms.PictureBox PictureBoxAtakFizyczny;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyborAtakuFizycznego;
        private System.Windows.Forms.PictureBox PictureBoxWyjdzZAtakowFizycznych;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyborAtakuMagicznego;
        private System.Windows.Forms.PictureBox pictureBoxWyjdzZAtakowMagicznych;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyborMikstury;
        private System.Windows.Forms.PictureBox pictureBoxWyjdzZEkwipunku;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelWyboru;
    }
}