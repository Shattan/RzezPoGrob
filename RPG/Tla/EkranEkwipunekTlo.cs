﻿#region Biblioteki systemowe
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace RPG
{
    public partial class EkranEkwipunekTlo : Form
    {
        #region Zmienne
        EkranEkwipunek ekranEkwipunek;
        #endregion

        public EkranEkwipunekTlo(EkranEkwipunek ekranEkwipunek)
        {
            InitializeComponent();
            this.ekranEkwipunek = ekranEkwipunek;

            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
        }

        #region Obsluga zdarzeń
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranEkwipunek.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion
    }
}