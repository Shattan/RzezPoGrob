namespace RPG
{
    partial class EkranGryTlo
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
            this.PictureBoxMgla = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMgla)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxMgla
            // 
            this.PictureBoxMgla.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxMgla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxMgla.Location = new System.Drawing.Point(56, 66);
            this.PictureBoxMgla.Name = "PictureBoxMgla";
            this.PictureBoxMgla.Size = new System.Drawing.Size(172, 129);
            this.PictureBoxMgla.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBoxMgla.TabIndex = 8;
            this.PictureBoxMgla.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EkranGryTlo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(880, 601);
            this.Controls.Add(this.PictureBoxMgla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranGryTlo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EkranGryTlo";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Shown += new System.EventHandler(this.EkranGryTlo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMgla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxMgla;
        private System.Windows.Forms.Timer timer1;
    }
}