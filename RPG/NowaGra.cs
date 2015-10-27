using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class NowaGra : Form
    {
        EkranGry ekranGry;

        public NowaGra(EkranGry eG)
        {
            InitializeComponent();

            ekranGry = eG;
            UstawElementyNaEkranie();
        }


        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

        }

       
        #region sprawiamy, ze okno jest niewidoczne w alt+tab
        /*
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
        */
        #endregion

    }
}
