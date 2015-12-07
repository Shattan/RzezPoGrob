namespace RPG.Formy
{
    partial class EkranHandel
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
            this.przedmiotyGracza = new System.Windows.Forms.FlowLayoutPanel();
            this.przedmiotySprzedawca = new System.Windows.Forms.FlowLayoutPanel();
            this.labelGracz = new System.Windows.Forms.Label();
            this.labelSprzedawca = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // przedmiotyGracza
            // 
            this.przedmiotyGracza.Location = new System.Drawing.Point(129, 106);
            this.przedmiotyGracza.Name = "przedmiotyGracza";
            this.przedmiotyGracza.Size = new System.Drawing.Size(200, 355);
            this.przedmiotyGracza.TabIndex = 0;
            // 
            // przedmiotySprzedawca
            // 
            this.przedmiotySprzedawca.Location = new System.Drawing.Point(574, 106);
            this.przedmiotySprzedawca.Name = "przedmiotySprzedawca";
            this.przedmiotySprzedawca.Size = new System.Drawing.Size(200, 355);
            this.przedmiotySprzedawca.TabIndex = 1;
            // 
            // labelGracz
            // 
            this.labelGracz.AutoSize = true;
            this.labelGracz.Location = new System.Drawing.Point(140, 61);
            this.labelGracz.Name = "labelGracz";
            this.labelGracz.Size = new System.Drawing.Size(35, 13);
            this.labelGracz.TabIndex = 2;
            this.labelGracz.Text = "label1";
            // 
            // labelSprzedawca
            // 
            this.labelSprzedawca.AutoSize = true;
            this.labelSprzedawca.Location = new System.Drawing.Point(591, 61);
            this.labelSprzedawca.Name = "labelSprzedawca";
            this.labelSprzedawca.Size = new System.Drawing.Size(35, 13);
            this.labelSprzedawca.TabIndex = 3;
            this.labelSprzedawca.Text = "label2";
            // 
            // EkranHandel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 516);
            this.Controls.Add(this.labelSprzedawca);
            this.Controls.Add(this.labelGracz);
            this.Controls.Add(this.przedmiotySprzedawca);
            this.Controls.Add(this.przedmiotyGracza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EkranHandel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EkranHandel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel przedmiotyGracza;
        private System.Windows.Forms.FlowLayoutPanel przedmiotySprzedawca;
        private System.Windows.Forms.Label labelGracz;
        private System.Windows.Forms.Label labelSprzedawca;
    }
}