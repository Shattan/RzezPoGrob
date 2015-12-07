using RPG.Klasy.PostacieNiezalezne;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG.Formy
{
    public partial class EkranHandel : Form
    {
        public EkranHandel(Gracz gracz,Handlarz sprzedawca)
        {
            
            InitializeComponent();
            WczytajPrzedmioty(przedmiotyGracza, gracz.Plecak);
            WczytajPrzedmioty(przedmiotySprzedawca, sprzedawca.PosiadanePrzedmioty);
        }
        private void WczytajPrzedmioty(Control c,List<Ekwipunek> przedmioty)
        {
            c.Controls.Clear();

            int szerokoscIkon = (Width * 5 / 100) - 5;
            int wysokoscIkon = Height * 8 / 100;

            //Dodawanie pól ekwipunku
            int miejscWEkwipunku = przedmioty.Count + 10 - (przedmioty.Count + 10) % 4;//Plecak zawsze dodaje puste pola na końcu, wyrównujące poziom pól(nieograniczona ilość miejsc w plecaku)
            for (int i = 0; i < miejscWEkwipunku; i++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(szerokoscIkon, wysokoscIkon);
                Program.UstawObrazEkwipunku(x, null);
                x.ImageLocation = null;
                x.Name = null;
                c.Controls.Add(x);
            }


            for (int i = 0; i < przedmioty.Count; i++)
            {
                Ekwipunek przedmiot = przedmioty[i];
                PictureBox pb = (c.Controls[i] as PictureBox);
                pb.Tag = przedmiot;
                Program.UstawObrazEkwipunku(pb, przedmiot);
            }
        }
    }
}
