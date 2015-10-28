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
    public partial class EkranEkranDziennikZadanTlo : Form
    {
        #region Zmienne
        EkranDziennikZadan ekranDziennikZadan;
        readonly Bitmap tlo = new Bitmap("Resources/Grafiki menu/Nowa Gra.png");
        #endregion

        public EkranEkranDziennikZadanTlo(EkranDziennikZadan ekranDziennikZadan)
        {
            InitializeComponent();
            this.ekranDziennikZadan = ekranDziennikZadan;

            BackgroundImage = tlo;
        }

        #region Obsluga zdarzeń
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranDziennikZadan.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion
    }
}