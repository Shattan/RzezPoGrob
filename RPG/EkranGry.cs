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

//dodane przeze mnie
using System.Media;
using System.Threading;
using System.Windows.Media;
#endregion

namespace RPG
{
    public partial class EkranGry : Form
    {
        #region Zmienne
        Gra gra;

        GlownyEkran glownyEkran;
        DziennikZadan dziennikZadan;
        #endregion

        public EkranGry(GlownyEkran Eg, Boolean czyWczytujemy)   //false nowa gra, true - wczytuejmy
        {
            glownyEkran = Eg;
            //glownyEkran.opcje.OdtworzDzwiek(odtwarzacz, sciezka);

            gra = new Gra();
            dziennikZadan = new DziennikZadan();

            InitializeComponent();

            if (!czyWczytujemy)
            {

            }
            else
            {
                //Deserializacja z XML          //Wczytujemy stan gry
            }

            ////gra.WczytajDane(...);

            UstawElementyNaEkranie();
        }

        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Chodzacy ludek
            PictureBoxGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/42/dół.gif");
            PictureBoxGracz.Size = new Size(PictureBoxGracz.Image.Width, PictureBoxGracz.Image.Height);
        }

        //Tutaj dzieki zdarzeniom bedziemy tylko wywolywac metody z klasy Gra
        //Dzieki temu mamy oddzielona gre od warstwy srodowiska

        #region Obsluga zdarzeń
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (dziennikZadan.Visible == false)
            {
                dziennikZadan.Visible = true;
                dziennikZadan.BringToFront();
            }
            else
            {
                dziennikZadan.Visible = false;
            }
        }
        #endregion

        #region sprawiamy, ze okno jest niewidoczne w alt+tab

        //Obsluga wychodzenia - zakaz alt+f4
        private void Opcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        //Nie pojawia sie w alt+tab
        private void Opcje_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
        }

        //Usuwamy ramke (nie pojawia sie w alt+tab)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        #endregion
    }
}
