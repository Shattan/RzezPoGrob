namespace RPG
{
    partial class NowaGra
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PictureBoxPotwierdz = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPotwierdz)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(63, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 0;
            // 
            // PictureBoxPotwierdz
            // 
            this.PictureBoxPotwierdz.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PictureBoxPotwierdz.Location = new System.Drawing.Point(172, 199);
            this.PictureBoxPotwierdz.Name = "PictureBoxPotwierdz";
            this.PictureBoxPotwierdz.Size = new System.Drawing.Size(100, 50);
            this.PictureBoxPotwierdz.TabIndex = 1;
            this.PictureBoxPotwierdz.TabStop = false;
            this.PictureBoxPotwierdz.Click += new System.EventHandler(this.PictureBoxPotwierdz_Click);
            // 
            // NowaGra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.PictureBoxPotwierdz);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NowaGra";
            this.Text = "NowaGra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Opcje_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPotwierdz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox PictureBoxPotwierdz;
    }
}