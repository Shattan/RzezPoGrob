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
            this.SuspendLayout();
            // 
            // buttonWygralem
            // 
            this.buttonWygralem.Location = new System.Drawing.Point(474, 308);
            this.buttonWygralem.Name = "buttonWygralem";
            this.buttonWygralem.Size = new System.Drawing.Size(178, 69);
            this.buttonWygralem.TabIndex = 0;
            this.buttonWygralem.Text = "Wygrałem!";
            this.buttonWygralem.UseVisualStyleBackColor = true;
            this.buttonWygralem.Click += new System.EventHandler(this.buttonWygralem_Click);
            // 
            // buttonPrzegralem
            // 
            this.buttonPrzegralem.Location = new System.Drawing.Point(474, 415);
            this.buttonPrzegralem.Name = "buttonPrzegralem";
            this.buttonPrzegralem.Size = new System.Drawing.Size(178, 69);
            this.buttonPrzegralem.TabIndex = 1;
            this.buttonPrzegralem.Text = "Przegrałem..";
            this.buttonPrzegralem.UseVisualStyleBackColor = true;
            this.buttonPrzegralem.Click += new System.EventHandler(this.buttonPrzegralem_Click);
            // 
            // EkranWalka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(970, 800);
            this.Controls.Add(this.buttonPrzegralem);
            this.Controls.Add(this.buttonWygralem);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranWalka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Walka";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWygralem;
        private System.Windows.Forms.Button buttonPrzegralem;
    }
}