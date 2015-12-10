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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EkranHandel));
            this.przedmiotyGracza = new System.Windows.Forms.FlowLayoutPanel();
            this.przedmiotySprzedawca = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.graczZloto = new System.Windows.Forms.Label();
            this.tbLogi = new System.Windows.Forms.TextBox();
            this.btnWyjdz = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbImfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // przedmiotyGracza
            // 
            this.przedmiotyGracza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.przedmiotyGracza.Location = new System.Drawing.Point(47, 57);
            this.przedmiotyGracza.Name = "przedmiotyGracza";
            this.przedmiotyGracza.Padding = new System.Windows.Forms.Padding(30);
            this.przedmiotyGracza.Size = new System.Drawing.Size(372, 400);
            this.przedmiotyGracza.TabIndex = 0;
            // 
            // przedmiotySprzedawca
            // 
            this.przedmiotySprzedawca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.przedmiotySprzedawca.Location = new System.Drawing.Point(747, 57);
            this.przedmiotySprzedawca.Name = "przedmiotySprzedawca";
            this.przedmiotySprzedawca.Padding = new System.Windows.Forms.Padding(30);
            this.przedmiotySprzedawca.Size = new System.Drawing.Size(374, 400);
            this.przedmiotySprzedawca.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbLogi, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1175, 651);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.przedmiotyGracza, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.przedmiotySprzedawca, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1169, 514);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // graczZloto
            // 
            this.graczZloto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.graczZloto.AutoSize = true;
            this.graczZloto.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.graczZloto.ForeColor = System.Drawing.Color.Gold;
            this.graczZloto.Location = new System.Drawing.Point(73, 97);
            this.graczZloto.Name = "graczZloto";
            this.graczZloto.Size = new System.Drawing.Size(81, 32);
            this.graczZloto.TabIndex = 2;
            this.graczZloto.Text = "label1";
            // 
            // tbLogi
            // 
            this.tbLogi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogi.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLogi.Location = new System.Drawing.Point(3, 523);
            this.tbLogi.Multiline = true;
            this.tbLogi.Name = "tbLogi";
            this.tbLogi.ReadOnly = true;
            this.tbLogi.Size = new System.Drawing.Size(1169, 125);
            this.tbLogi.TabIndex = 1;
            // 
            // btnWyjdz
            // 
            this.btnWyjdz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnWyjdz.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWyjdz.BackgroundImage")));
            this.btnWyjdz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWyjdz.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWyjdz.ForeColor = System.Drawing.Color.Gold;
            this.btnWyjdz.Location = new System.Drawing.Point(35, 451);
            this.btnWyjdz.Name = "btnWyjdz";
            this.btnWyjdz.Size = new System.Drawing.Size(156, 54);
            this.btnWyjdz.TabIndex = 3;
            this.btnWyjdz.Text = "Wyjdź";
            this.btnWyjdz.UseVisualStyleBackColor = true;
            this.btnWyjdz.Click += new System.EventHandler(this.btnWyjdz_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.graczZloto, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnWyjdz, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbImfo, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(470, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.79464F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.20536F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(227, 508);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // lbImfo
            // 
            this.lbImfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbImfo.AutoSize = true;
            this.lbImfo.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbImfo.ForeColor = System.Drawing.Color.Gold;
            this.lbImfo.Location = new System.Drawing.Point(113, 276);
            this.lbImfo.Name = "lbImfo";
            this.lbImfo.Size = new System.Drawing.Size(0, 25);
            this.lbImfo.TabIndex = 4;
            // 
            // EkranHandel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1175, 651);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EkranHandel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EkranHandel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel przedmiotyGracza;
        private System.Windows.Forms.FlowLayoutPanel przedmiotySprzedawca;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbLogi;
        private System.Windows.Forms.Label graczZloto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnWyjdz;
        private System.Windows.Forms.Label lbImfo;
    }
}