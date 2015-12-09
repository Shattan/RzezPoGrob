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
        Gracz gracz;
        Handlarz sprzedawca;
        public EkranHandel(Gracz gracz,Handlarz sprzedawca)
        {
            this.gracz = gracz;
            this.sprzedawca = sprzedawca;
            InitializeComponent();
            WczytajPrzedmioty(przedmiotyGracza, gracz.Plecak,true);
            WczytajPrzedmioty(przedmiotySprzedawca, sprzedawca.PosiadanePrzedmioty,false);
            WczytajLabele();
        }

        private void WczytajLabele()
        {
            //labelGracz.Text = "Przedmioty " + gracz.Nazwa;
            //labelSprzedawca.Text = "Przedmioty " + sprzedawca.Nazwa;
        }
        private void WczytajPrzedmioty(Control c,List<Ekwipunek> przedmioty,bool sprzedawane)
        {
            c.Controls.Clear();
            c.Tag = sprzedawane;
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
                x.AllowDrop = true;
                x.MouseDown += x_MouseDown;
                x.DragEnter += x_DragEnter;
                x.DragDrop += x_DragDrop;
                c.Controls.Add(x);
            }


            for (int i = 0; i < przedmioty.Count; i++)
            {
                Ekwipunek przedmiot = przedmioty[i];
                PictureBox pb = (c.Controls[i] as PictureBox);
                pb.Tag = przedmiot;
                pb.Name = sprzedawane.ToString() + "_" + i;
                Program.UstawObrazEkwipunku(pb, przedmiot);
            }
        }

        void x_MouseDown(object sender, MouseEventArgs e)
        {
            Control c=(Control)sender;
            if(c.Tag!=null)
            {
                   DoDragDrop(sender, DragDropEffects.Move);
            }
        }

        void x_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox upuszczany = (PictureBox)e.Data.GetData(typeof(PictureBox));
            PictureBox celupuszczenia = (PictureBox)sender;
            if ((bool)upuszczany.Parent.Tag == (bool)celupuszczenia.Parent.Tag)
            {
                return;//nic nie robimy bo cel jest taki sam jak źródło
            }

            tbLogi.Text += "PRzesuniecie z " + upuszczany.Parent.Tag + " do " + celupuszczenia.Parent.Tag + "\r\n";
            tbLogi.SelectionStart = tbLogi.Text.Length - 1;
            tbLogi.SelectionLength = 0;
            tbLogi.ScrollToCaret();
            Ekwipunek eupu = (Ekwipunek)upuszczany.Tag;
            Ekwipunek enaup = (Ekwipunek)celupuszczenia.Tag;
            upuszczany.Tag = null;
            upuszczany.Image = null;
            celupuszczenia.Tag = null;
            celupuszczenia.Image = null;


            Program.UstawObrazEkwipunku(upuszczany, eupu);
            upuszczany.Tag = eupu;
            Program.UstawObrazEkwipunku(celupuszczenia, enaup);
            celupuszczenia.Tag = enaup;
        }

        void x_DragEnter(object sender, DragEventArgs e)
        {
            Ekwipunek ek = (e.Data.GetData(typeof(PictureBox)) as PictureBox).Tag as Ekwipunek;
                if (ek != null)//sprawdzenie, czy przenoszony przedmiot jest bronią
                {
                    e.Effect = DragDropEffects.Move;
                }
        }
    }
}
