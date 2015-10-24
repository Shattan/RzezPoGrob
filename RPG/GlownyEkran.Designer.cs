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
            this.PanelInformacje = new System.Windows.Forms.Panel();
            this.LabelInformacje = new System.Windows.Forms.Label();
            this.Zegar = new System.Windows.Forms.Timer(this.components);
            this.GroupBoxDzwiek = new System.Windows.Forms.GroupBox();
            this.GroupBoxGlosnoscMuzyki = new System.Windows.Forms.GroupBox();
            this.RadioButtonGlosnoscMuzyki10 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki1 = new System.Windows.Forms.RadioButton();
            this.CheckBoxWylaczMuzyke = new System.Windows.Forms.CheckBox();
            this.RadioButtonGlosnoscMuzyki2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki3 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki4 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki5 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki6 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki7 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki8 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscMuzyki9 = new System.Windows.Forms.RadioButton();
            this.GroupBoxGlosnoscEfektowDzwiekowych = new System.Windows.Forms.GroupBox();
            this.RadioButtonGlosnoscEfektowDzwiekowych1 = new System.Windows.Forms.RadioButton();
            this.CheckBoxWylaczEfektyDzwiekowe = new System.Windows.Forms.CheckBox();
            this.RadioButtonGlosnoscEfektowDzwiekowych9 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych10 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych3 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych8 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych4 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych7 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych5 = new System.Windows.Forms.RadioButton();
            this.RadioButtonGlosnoscEfektowDzwiekowych6 = new System.Windows.Forms.RadioButton();
            this.GroupBoxEkran = new System.Windows.Forms.GroupBox();
            this.CheckBoxZawszeNaWierzchu = new System.Windows.Forms.CheckBox();
            this.CheckBoxPelnyEkran = new System.Windows.Forms.CheckBox();
            this.PanelOpcje = new System.Windows.Forms.Panel();
            this.PictureBoxUstawienia = new System.Windows.Forms.PictureBox();
            this.PanelWyswietlacza = new System.Windows.Forms.Panel();
            this.PictureBoxWyjscie = new System.Windows.Forms.PictureBox();
            this.PictureBoxRuszaj = new System.Windows.Forms.PictureBox();
            this.PictureBoxOpcje = new System.Windows.Forms.PictureBox();
            this.PanelInformacje.SuspendLayout();
            this.GroupBoxDzwiek.SuspendLayout();
            this.GroupBoxGlosnoscMuzyki.SuspendLayout();
            this.GroupBoxGlosnoscEfektowDzwiekowych.SuspendLayout();
            this.GroupBoxEkran.SuspendLayout();
            this.PanelOpcje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUstawienia)).BeginInit();
            this.PanelWyswietlacza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpcje)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelInformacje
            // 
            this.PanelInformacje.BackColor = System.Drawing.Color.Black;
            this.PanelInformacje.Controls.Add(this.LabelInformacje);
            this.PanelInformacje.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelInformacje.ForeColor = System.Drawing.Color.Yellow;
            this.PanelInformacje.Location = new System.Drawing.Point(486, 3);
            this.PanelInformacje.Name = "PanelInformacje";
            this.PanelInformacje.Size = new System.Drawing.Size(62, 101);
            this.PanelInformacje.TabIndex = 4;
            // 
            // LabelInformacje
            // 
            this.LabelInformacje.BackColor = System.Drawing.Color.OrangeRed;
            this.LabelInformacje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInformacje.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelInformacje.Location = new System.Drawing.Point(0, 0);
            this.LabelInformacje.Name = "LabelInformacje";
            this.LabelInformacje.Size = new System.Drawing.Size(62, 101);
            this.LabelInformacje.TabIndex = 0;
            this.LabelInformacje.Text = "LabelInformacje";
            this.LabelInformacje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Zegar
            // 
            this.Zegar.Interval = 300;
            this.Zegar.Tick += new System.EventHandler(this.Zegar_Tick);
            // 
            // GroupBoxDzwiek
            // 
            this.GroupBoxDzwiek.BackColor = System.Drawing.Color.Transparent;
            this.GroupBoxDzwiek.Controls.Add(this.GroupBoxGlosnoscMuzyki);
            this.GroupBoxDzwiek.Controls.Add(this.GroupBoxGlosnoscEfektowDzwiekowych);
            this.GroupBoxDzwiek.Location = new System.Drawing.Point(116, 88);
            this.GroupBoxDzwiek.Name = "GroupBoxDzwiek";
            this.GroupBoxDzwiek.Size = new System.Drawing.Size(228, 214);
            this.GroupBoxDzwiek.TabIndex = 0;
            this.GroupBoxDzwiek.TabStop = false;
            this.GroupBoxDzwiek.Text = "Dźwięk";
            // 
            // GroupBoxGlosnoscMuzyki
            // 
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki10);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki1);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.CheckBoxWylaczMuzyke);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki2);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki3);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki4);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki5);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki6);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki7);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki8);
            this.GroupBoxGlosnoscMuzyki.Controls.Add(this.RadioButtonGlosnoscMuzyki9);
            this.GroupBoxGlosnoscMuzyki.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GroupBoxGlosnoscMuzyki.Location = new System.Drawing.Point(6, 24);
            this.GroupBoxGlosnoscMuzyki.Name = "GroupBoxGlosnoscMuzyki";
            this.GroupBoxGlosnoscMuzyki.Size = new System.Drawing.Size(216, 88);
            this.GroupBoxGlosnoscMuzyki.TabIndex = 25;
            this.GroupBoxGlosnoscMuzyki.TabStop = false;
            this.GroupBoxGlosnoscMuzyki.Text = "Głośność Muzyki";
            // 
            // RadioButtonGlosnoscMuzyki10
            // 
            this.RadioButtonGlosnoscMuzyki10.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki10.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki10.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki10.Location = new System.Drawing.Point(149, 52);
            this.RadioButtonGlosnoscMuzyki10.Name = "RadioButtonGlosnoscMuzyki10";
            this.RadioButtonGlosnoscMuzyki10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki10.Size = new System.Drawing.Size(26, 35);
            this.RadioButtonGlosnoscMuzyki10.TabIndex = 11;
            this.RadioButtonGlosnoscMuzyki10.Text = "10";
            this.RadioButtonGlosnoscMuzyki10.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki10.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki1
            // 
            this.RadioButtonGlosnoscMuzyki1.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki1.BackColor = System.Drawing.Color.Transparent;
            this.RadioButtonGlosnoscMuzyki1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RadioButtonGlosnoscMuzyki1.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki1.Location = new System.Drawing.Point(6, 52);
            this.RadioButtonGlosnoscMuzyki1.Name = "RadioButtonGlosnoscMuzyki1";
            this.RadioButtonGlosnoscMuzyki1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki1.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki1.TabIndex = 2;
            this.RadioButtonGlosnoscMuzyki1.Text = "1";
            this.RadioButtonGlosnoscMuzyki1.UseVisualStyleBackColor = false;
            this.RadioButtonGlosnoscMuzyki1.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // CheckBoxWylaczMuzyke
            // 
            this.CheckBoxWylaczMuzyke.AutoSize = true;
            this.CheckBoxWylaczMuzyke.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBoxWylaczMuzyke.Location = new System.Drawing.Point(6, 24);
            this.CheckBoxWylaczMuzyke.Name = "CheckBoxWylaczMuzyke";
            this.CheckBoxWylaczMuzyke.Size = new System.Drawing.Size(123, 22);
            this.CheckBoxWylaczMuzyke.TabIndex = 0;
            this.CheckBoxWylaczMuzyke.Text = "Wyłącz Muzykę";
            this.CheckBoxWylaczMuzyke.UseVisualStyleBackColor = true;
            this.CheckBoxWylaczMuzyke.CheckedChanged += new System.EventHandler(this.CheckBoxWylaczMuzyke_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki2
            // 
            this.RadioButtonGlosnoscMuzyki2.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki2.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki2.Location = new System.Drawing.Point(22, 52);
            this.RadioButtonGlosnoscMuzyki2.Name = "RadioButtonGlosnoscMuzyki2";
            this.RadioButtonGlosnoscMuzyki2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki2.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki2.TabIndex = 3;
            this.RadioButtonGlosnoscMuzyki2.Text = "2";
            this.RadioButtonGlosnoscMuzyki2.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki2.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki3
            // 
            this.RadioButtonGlosnoscMuzyki3.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki3.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki3.Location = new System.Drawing.Point(38, 52);
            this.RadioButtonGlosnoscMuzyki3.Name = "RadioButtonGlosnoscMuzyki3";
            this.RadioButtonGlosnoscMuzyki3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki3.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki3.TabIndex = 4;
            this.RadioButtonGlosnoscMuzyki3.Text = "3";
            this.RadioButtonGlosnoscMuzyki3.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki3.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki4
            // 
            this.RadioButtonGlosnoscMuzyki4.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki4.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki4.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki4.Location = new System.Drawing.Point(54, 52);
            this.RadioButtonGlosnoscMuzyki4.Name = "RadioButtonGlosnoscMuzyki4";
            this.RadioButtonGlosnoscMuzyki4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki4.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki4.TabIndex = 5;
            this.RadioButtonGlosnoscMuzyki4.Text = "4";
            this.RadioButtonGlosnoscMuzyki4.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki4.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki5
            // 
            this.RadioButtonGlosnoscMuzyki5.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki5.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki5.Checked = true;
            this.RadioButtonGlosnoscMuzyki5.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki5.Location = new System.Drawing.Point(70, 52);
            this.RadioButtonGlosnoscMuzyki5.Name = "RadioButtonGlosnoscMuzyki5";
            this.RadioButtonGlosnoscMuzyki5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki5.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki5.TabIndex = 6;
            this.RadioButtonGlosnoscMuzyki5.TabStop = true;
            this.RadioButtonGlosnoscMuzyki5.Text = "5";
            this.RadioButtonGlosnoscMuzyki5.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki5.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki6
            // 
            this.RadioButtonGlosnoscMuzyki6.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki6.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki6.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki6.Location = new System.Drawing.Point(86, 52);
            this.RadioButtonGlosnoscMuzyki6.Name = "RadioButtonGlosnoscMuzyki6";
            this.RadioButtonGlosnoscMuzyki6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki6.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki6.TabIndex = 7;
            this.RadioButtonGlosnoscMuzyki6.Text = "6";
            this.RadioButtonGlosnoscMuzyki6.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki6.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki7
            // 
            this.RadioButtonGlosnoscMuzyki7.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki7.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki7.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki7.Location = new System.Drawing.Point(102, 52);
            this.RadioButtonGlosnoscMuzyki7.Name = "RadioButtonGlosnoscMuzyki7";
            this.RadioButtonGlosnoscMuzyki7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki7.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki7.TabIndex = 8;
            this.RadioButtonGlosnoscMuzyki7.Text = "7";
            this.RadioButtonGlosnoscMuzyki7.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki7.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki8
            // 
            this.RadioButtonGlosnoscMuzyki8.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki8.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki8.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki8.Location = new System.Drawing.Point(118, 52);
            this.RadioButtonGlosnoscMuzyki8.Name = "RadioButtonGlosnoscMuzyki8";
            this.RadioButtonGlosnoscMuzyki8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki8.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki8.TabIndex = 9;
            this.RadioButtonGlosnoscMuzyki8.Text = "8";
            this.RadioButtonGlosnoscMuzyki8.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki8.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // RadioButtonGlosnoscMuzyki9
            // 
            this.RadioButtonGlosnoscMuzyki9.AutoSize = true;
            this.RadioButtonGlosnoscMuzyki9.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki9.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscMuzyki9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscMuzyki9.Location = new System.Drawing.Point(134, 52);
            this.RadioButtonGlosnoscMuzyki9.Name = "RadioButtonGlosnoscMuzyki9";
            this.RadioButtonGlosnoscMuzyki9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscMuzyki9.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscMuzyki9.TabIndex = 10;
            this.RadioButtonGlosnoscMuzyki9.Text = "9";
            this.RadioButtonGlosnoscMuzyki9.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscMuzyki9.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscMuzyki_CheckedChanged);
            // 
            // GroupBoxGlosnoscEfektowDzwiekowych
            // 
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych1);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.CheckBoxWylaczEfektyDzwiekowe);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych9);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych2);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych10);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych3);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych8);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych4);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych7);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych5);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Controls.Add(this.RadioButtonGlosnoscEfektowDzwiekowych6);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GroupBoxGlosnoscEfektowDzwiekowych.Location = new System.Drawing.Point(6, 118);
            this.GroupBoxGlosnoscEfektowDzwiekowych.Name = "GroupBoxGlosnoscEfektowDzwiekowych";
            this.GroupBoxGlosnoscEfektowDzwiekowych.Size = new System.Drawing.Size(216, 88);
            this.GroupBoxGlosnoscEfektowDzwiekowych.TabIndex = 26;
            this.GroupBoxGlosnoscEfektowDzwiekowych.TabStop = false;
            this.GroupBoxGlosnoscEfektowDzwiekowych.Text = "Głośność Efektów Dźwiękowych";
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych1
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych1.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych1.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych1.Location = new System.Drawing.Point(6, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych1.Name = "RadioButtonGlosnoscEfektowDzwiekowych1";
            this.RadioButtonGlosnoscEfektowDzwiekowych1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych1.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych1.TabIndex = 13;
            this.RadioButtonGlosnoscEfektowDzwiekowych1.Text = "1";
            this.RadioButtonGlosnoscEfektowDzwiekowych1.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych1.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // CheckBoxWylaczEfektyDzwiekowe
            // 
            this.CheckBoxWylaczEfektyDzwiekowe.AutoSize = true;
            this.CheckBoxWylaczEfektyDzwiekowe.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBoxWylaczEfektyDzwiekowe.Location = new System.Drawing.Point(6, 24);
            this.CheckBoxWylaczEfektyDzwiekowe.Name = "CheckBoxWylaczEfektyDzwiekowe";
            this.CheckBoxWylaczEfektyDzwiekowe.Size = new System.Drawing.Size(190, 22);
            this.CheckBoxWylaczEfektyDzwiekowe.TabIndex = 24;
            this.CheckBoxWylaczEfektyDzwiekowe.Text = "Wyłącz Efekty Dźwiękowe";
            this.CheckBoxWylaczEfektyDzwiekowe.UseVisualStyleBackColor = true;
            this.CheckBoxWylaczEfektyDzwiekowe.CheckedChanged += new System.EventHandler(this.CheckBoxWylaczEfektyDzwiekowe_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych9
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych9.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych9.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych9.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych9.Location = new System.Drawing.Point(134, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych9.Name = "RadioButtonGlosnoscEfektowDzwiekowych9";
            this.RadioButtonGlosnoscEfektowDzwiekowych9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych9.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych9.TabIndex = 21;
            this.RadioButtonGlosnoscEfektowDzwiekowych9.Text = "9";
            this.RadioButtonGlosnoscEfektowDzwiekowych9.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych9.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych2
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych2.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych2.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych2.Location = new System.Drawing.Point(22, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych2.Name = "RadioButtonGlosnoscEfektowDzwiekowych2";
            this.RadioButtonGlosnoscEfektowDzwiekowych2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych2.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych2.TabIndex = 14;
            this.RadioButtonGlosnoscEfektowDzwiekowych2.Text = "2";
            this.RadioButtonGlosnoscEfektowDzwiekowych2.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych2.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych10
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych10.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych10.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych10.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych10.Location = new System.Drawing.Point(149, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych10.Name = "RadioButtonGlosnoscEfektowDzwiekowych10";
            this.RadioButtonGlosnoscEfektowDzwiekowych10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych10.Size = new System.Drawing.Size(26, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych10.TabIndex = 22;
            this.RadioButtonGlosnoscEfektowDzwiekowych10.Text = "10";
            this.RadioButtonGlosnoscEfektowDzwiekowych10.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych10.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych3
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych3.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych3.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych3.Location = new System.Drawing.Point(38, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych3.Name = "RadioButtonGlosnoscEfektowDzwiekowych3";
            this.RadioButtonGlosnoscEfektowDzwiekowych3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych3.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych3.TabIndex = 15;
            this.RadioButtonGlosnoscEfektowDzwiekowych3.Text = "3";
            this.RadioButtonGlosnoscEfektowDzwiekowych3.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych3.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych8
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych8.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych8.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych8.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych8.Location = new System.Drawing.Point(118, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych8.Name = "RadioButtonGlosnoscEfektowDzwiekowych8";
            this.RadioButtonGlosnoscEfektowDzwiekowych8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych8.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych8.TabIndex = 20;
            this.RadioButtonGlosnoscEfektowDzwiekowych8.Text = "8";
            this.RadioButtonGlosnoscEfektowDzwiekowych8.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych8.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych4
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych4.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych4.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych4.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych4.Location = new System.Drawing.Point(54, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych4.Name = "RadioButtonGlosnoscEfektowDzwiekowych4";
            this.RadioButtonGlosnoscEfektowDzwiekowych4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych4.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych4.TabIndex = 16;
            this.RadioButtonGlosnoscEfektowDzwiekowych4.Text = "4";
            this.RadioButtonGlosnoscEfektowDzwiekowych4.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych4.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych7
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych7.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych7.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych7.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych7.Location = new System.Drawing.Point(102, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych7.Name = "RadioButtonGlosnoscEfektowDzwiekowych7";
            this.RadioButtonGlosnoscEfektowDzwiekowych7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych7.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych7.TabIndex = 19;
            this.RadioButtonGlosnoscEfektowDzwiekowych7.Text = "7";
            this.RadioButtonGlosnoscEfektowDzwiekowych7.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych7.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych5
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych5.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.Checked = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.Location = new System.Drawing.Point(70, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych5.Name = "RadioButtonGlosnoscEfektowDzwiekowych5";
            this.RadioButtonGlosnoscEfektowDzwiekowych5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych5.TabIndex = 17;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.TabStop = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.Text = "5";
            this.RadioButtonGlosnoscEfektowDzwiekowych5.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych5.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // RadioButtonGlosnoscEfektowDzwiekowych6
            // 
            this.RadioButtonGlosnoscEfektowDzwiekowych6.AutoSize = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych6.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych6.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RadioButtonGlosnoscEfektowDzwiekowych6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonGlosnoscEfektowDzwiekowych6.Location = new System.Drawing.Point(86, 52);
            this.RadioButtonGlosnoscEfektowDzwiekowych6.Name = "RadioButtonGlosnoscEfektowDzwiekowych6";
            this.RadioButtonGlosnoscEfektowDzwiekowych6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RadioButtonGlosnoscEfektowDzwiekowych6.Size = new System.Drawing.Size(19, 35);
            this.RadioButtonGlosnoscEfektowDzwiekowych6.TabIndex = 18;
            this.RadioButtonGlosnoscEfektowDzwiekowych6.Text = "6";
            this.RadioButtonGlosnoscEfektowDzwiekowych6.UseVisualStyleBackColor = true;
            this.RadioButtonGlosnoscEfektowDzwiekowych6.CheckedChanged += new System.EventHandler(this.RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged);
            // 
            // GroupBoxEkran
            // 
            this.GroupBoxEkran.BackColor = System.Drawing.Color.Transparent;
            this.GroupBoxEkran.Controls.Add(this.CheckBoxZawszeNaWierzchu);
            this.GroupBoxEkran.Controls.Add(this.CheckBoxPelnyEkran);
            this.GroupBoxEkran.Location = new System.Drawing.Point(350, 91);
            this.GroupBoxEkran.Name = "GroupBoxEkran";
            this.GroupBoxEkran.Size = new System.Drawing.Size(228, 108);
            this.GroupBoxEkran.TabIndex = 24;
            this.GroupBoxEkran.TabStop = false;
            this.GroupBoxEkran.Text = "Ekran";
            // 
            // CheckBoxZawszeNaWierzchu
            // 
            this.CheckBoxZawszeNaWierzchu.AutoSize = true;
            this.CheckBoxZawszeNaWierzchu.Checked = true;
            this.CheckBoxZawszeNaWierzchu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxZawszeNaWierzchu.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBoxZawszeNaWierzchu.Location = new System.Drawing.Point(6, 52);
            this.CheckBoxZawszeNaWierzchu.Name = "CheckBoxZawszeNaWierzchu";
            this.CheckBoxZawszeNaWierzchu.Size = new System.Drawing.Size(154, 22);
            this.CheckBoxZawszeNaWierzchu.TabIndex = 1;
            this.CheckBoxZawszeNaWierzchu.Text = "Zawsze Na Wierzchu";
            this.CheckBoxZawszeNaWierzchu.UseVisualStyleBackColor = true;
            this.CheckBoxZawszeNaWierzchu.CheckedChanged += new System.EventHandler(this.CheckBoxZawszeNaWierzchu_CheckedChanged);
            // 
            // CheckBoxPelnyEkran
            // 
            this.CheckBoxPelnyEkran.AutoSize = true;
            this.CheckBoxPelnyEkran.Checked = true;
            this.CheckBoxPelnyEkran.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxPelnyEkran.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CheckBoxPelnyEkran.Location = new System.Drawing.Point(6, 24);
            this.CheckBoxPelnyEkran.Name = "CheckBoxPelnyEkran";
            this.CheckBoxPelnyEkran.Size = new System.Drawing.Size(99, 22);
            this.CheckBoxPelnyEkran.TabIndex = 0;
            this.CheckBoxPelnyEkran.Text = "Pełny Ekran";
            this.CheckBoxPelnyEkran.UseVisualStyleBackColor = true;
            this.CheckBoxPelnyEkran.CheckedChanged += new System.EventHandler(this.CheckBoxPelnyEkran_CheckedChanged);
            // 
            // PanelOpcje
            // 
            this.PanelOpcje.BackColor = System.Drawing.Color.DimGray;
            this.PanelOpcje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelOpcje.Controls.Add(this.GroupBoxEkran);
            this.PanelOpcje.Controls.Add(this.GroupBoxDzwiek);
            this.PanelOpcje.Controls.Add(this.PictureBoxUstawienia);
            this.PanelOpcje.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelOpcje.ForeColor = System.Drawing.Color.Black;
            this.PanelOpcje.Location = new System.Drawing.Point(12, 110);
            this.PanelOpcje.Name = "PanelOpcje";
            this.PanelOpcje.Size = new System.Drawing.Size(802, 394);
            this.PanelOpcje.TabIndex = 5;
            this.PanelOpcje.Visible = false;
            // 
            // PictureBoxUstawienia
            // 
            this.PictureBoxUstawienia.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxUstawienia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxUstawienia.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxUstawienia.Name = "PictureBoxUstawienia";
            this.PictureBoxUstawienia.Size = new System.Drawing.Size(802, 394);
            this.PictureBoxUstawienia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxUstawienia.TabIndex = 25;
            this.PictureBoxUstawienia.TabStop = false;
            // 
            // PanelWyswietlacza
            // 
            this.PanelWyswietlacza.BackColor = System.Drawing.Color.Red;
            this.PanelWyswietlacza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelWyswietlacza.Controls.Add(this.PictureBoxRuszaj);
            this.PanelWyswietlacza.Controls.Add(this.PictureBoxOpcje);
            this.PanelWyswietlacza.Controls.Add(this.PictureBoxWyjscie);
            this.PanelWyswietlacza.Controls.Add(this.PanelOpcje);
            this.PanelWyswietlacza.Controls.Add(this.PanelInformacje);
            this.PanelWyswietlacza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWyswietlacza.Location = new System.Drawing.Point(0, 0);
            this.PanelWyswietlacza.Name = "PanelWyswietlacza";
            this.PanelWyswietlacza.Size = new System.Drawing.Size(893, 780);
            this.PanelWyswietlacza.TabIndex = 6;
            // 
            // PictureBoxWyjscie
            // 
            this.PictureBoxWyjscie.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxWyjscie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBoxWyjscie.Location = new System.Drawing.Point(12, 3);
            this.PictureBoxWyjscie.Name = "PictureBoxWyjscie";
            this.PictureBoxWyjscie.Size = new System.Drawing.Size(133, 132);
            this.PictureBoxWyjscie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxWyjscie.TabIndex = 6;
            this.PictureBoxWyjscie.TabStop = false;
            this.PictureBoxWyjscie.MouseEnter += new System.EventHandler(this.PictureBoxWyjscie_MouseEnter);
            this.PictureBoxWyjscie.MouseLeave += new System.EventHandler(this.PictureBoxWyjscie_MouseLeave);
            // 
            // PictureBoxRuszaj
            // 
            this.PictureBoxRuszaj.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxRuszaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxRuszaj.Location = new System.Drawing.Point(290, 3);
            this.PictureBoxRuszaj.Name = "PictureBoxRuszaj";
            this.PictureBoxRuszaj.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxRuszaj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxRuszaj.TabIndex = 2;
            this.PictureBoxRuszaj.TabStop = false;
            // 
            // PictureBoxOpcje
            // 
            this.PictureBoxOpcje.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxOpcje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxOpcje.Location = new System.Drawing.Point(151, 3);
            this.PictureBoxOpcje.Name = "PictureBoxOpcje";
            this.PictureBoxOpcje.Size = new System.Drawing.Size(133, 101);
            this.PictureBoxOpcje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxOpcje.TabIndex = 1;
            this.PictureBoxOpcje.TabStop = false;
            this.PictureBoxOpcje.Click += new System.EventHandler(this.PictureBoxOpcje_Click);
            // 
            // GlownyEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(893, 780);
            this.Controls.Add(this.PanelWyswietlacza);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "GlownyEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rzeź Po Grób";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanelInformacje.ResumeLayout(false);
            this.GroupBoxDzwiek.ResumeLayout(false);
            this.GroupBoxGlosnoscMuzyki.ResumeLayout(false);
            this.GroupBoxGlosnoscMuzyki.PerformLayout();
            this.GroupBoxGlosnoscEfektowDzwiekowych.ResumeLayout(false);
            this.GroupBoxGlosnoscEfektowDzwiekowych.PerformLayout();
            this.GroupBoxEkran.ResumeLayout(false);
            this.GroupBoxEkran.PerformLayout();
            this.PanelOpcje.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUstawienia)).EndInit();
            this.PanelWyswietlacza.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWyjscie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRuszaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpcje)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelInformacje;
        private System.Windows.Forms.Label LabelInformacje;
        private System.Windows.Forms.Timer Zegar;
        private System.Windows.Forms.GroupBox GroupBoxDzwiek;
        private System.Windows.Forms.GroupBox GroupBoxGlosnoscMuzyki;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki10;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki1;
        private System.Windows.Forms.CheckBox CheckBoxWylaczMuzyke;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki2;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki3;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki4;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki5;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki6;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki7;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki8;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscMuzyki9;
        private System.Windows.Forms.GroupBox GroupBoxGlosnoscEfektowDzwiekowych;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych1;
        private System.Windows.Forms.CheckBox CheckBoxWylaczEfektyDzwiekowe;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych9;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych2;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych10;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych3;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych8;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych4;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych7;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych5;
        private System.Windows.Forms.RadioButton RadioButtonGlosnoscEfektowDzwiekowych6;
        private System.Windows.Forms.GroupBox GroupBoxEkran;
        private System.Windows.Forms.CheckBox CheckBoxZawszeNaWierzchu;
        private System.Windows.Forms.CheckBox CheckBoxPelnyEkran;
        private System.Windows.Forms.Panel PanelOpcje;
        private System.Windows.Forms.Panel PanelWyswietlacza;
        private System.Windows.Forms.PictureBox PictureBoxRuszaj;
        private System.Windows.Forms.PictureBox PictureBoxOpcje;
        private System.Windows.Forms.PictureBox PictureBoxWyjscie;
        private System.Windows.Forms.PictureBox PictureBoxUstawienia;
    }
}

