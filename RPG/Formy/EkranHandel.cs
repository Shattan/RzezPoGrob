using RPG.Klasy.PostacieNiezalezne;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            btnWyjdz.TabStop = false;
            btnWyjdz.FlatStyle = FlatStyle.Flat;
            btnWyjdz.FlatAppearance.BorderSize = 0;
            btnWyjdz.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            WczytajLabele();

        }


        private void WczytajLabele()
        {
            graczZloto.Text = string.Format("Złoto\r\n{0} sztuk", gracz.Zloto);
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
                x.Click += x_Click;
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

        void x_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c.Tag != null)
            {
                InfoPrzedmiot((Ekwipunek)c.Tag);
            }
        }




        void x_MouseDown(object sender, MouseEventArgs e)
        {
            Control c=(Control)sender;
            if(c.Tag!=null)
            {
                InfoPrzedmiot((Ekwipunek)c.Tag);
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
            if((bool)upuszczany.Parent.Tag)
            {
                Sprzedaz(upuszczany, celupuszczenia);
            }
            else
            {
                Kupno(upuszczany, celupuszczenia);
            }
      
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

        private void Kupno(PictureBox upuszczany, PictureBox celupuszczenia)
        {
            Ekwipunek kupowany = (Ekwipunek)upuszczany.Tag;
            Ekwipunek enaup = (Ekwipunek)celupuszczenia.Tag;
            DodajKomunikat ( string.Format("Kupiłeś {0} za {1} sztuk złota", kupowany.Nazwa, kupowany.Cena));
            gracz.Zloto -= kupowany.Cena;
            var cel = PobierzDoUpuszczenia(celupuszczenia);
            Program.UstawObrazEkwipunku(cel, kupowany);
            cel.Tag = kupowany;
            upuszczany.Image = null;
            upuszczany.Tag = null;
            gracz.Plecak.Add(kupowany);
            sprzedawca.PosiadanePrzedmioty.Remove(kupowany);
            WczytajLabele();
        }

        private void Sprzedaz(PictureBox upuszczany, PictureBox celupuszczenia)
        {
            Ekwipunek sprzedawany = (Ekwipunek)upuszczany.Tag;
            Ekwipunek enaup = (Ekwipunek)celupuszczenia.Tag;
           DodajKomunikat (string.Format("Sprzedałeś {0} za {1} sztuk złota", sprzedawany.Nazwa,sprzedawany.Cena));
           upuszczany.Tag = null;
           upuszczany.Image = null;

           var cel = PobierzDoUpuszczenia(celupuszczenia);
           Program.UstawObrazEkwipunku(cel, sprzedawany);
           cel.Tag = sprzedawany;
           upuszczany.Image = null;
           upuszczany.Tag = null;
           gracz.Zloto += sprzedawany.Cena;
           gracz.Plecak.Remove(sprzedawany);
           sprzedawca.PosiadanePrzedmioty.Add(sprzedawany);
           WczytajLabele();
        }
        private PictureBox PobierzDoUpuszczenia(PictureBox cel)
        {
            if (cel.Image == null)
            {
                return cel;
            }
            return cel.Parent.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Tag == null);
        }
        private void DodajKomunikat(string komunikat)
        {
            tbLogi.Text += komunikat + "\r\n";
            tbLogi.SelectionStart = tbLogi.Text.Length - 1;
            tbLogi.SelectionLength = 0;
            tbLogi.ScrollToCaret();
        }
        private void InfoPrzedmiot(Ekwipunek przedmiot)
        {
            lbImfo.Text = "";
            lbImfo.Text += string.Format("{0}\r\nCena {1} sztuk złota\r\n", przedmiot.Nazwa, przedmiot.Cena);

            lbImfo.Text += "Siła "+ przedmiot.Sila  +"\n";
            lbImfo.Text += "Zręczność "+ przedmiot.Zrecznosc+"\n";
            lbImfo.Text += "Witalność "+ przedmiot.Witalnosc+"\n";
            lbImfo.Text += "Inteligencja " + przedmiot.Inteligencja+"\n";
            lbImfo.Text += "Obrazenia "+ przedmiot.Obrazenia+"\n";
            lbImfo.Text += "Pancerz "+ przedmiot.Pancerz+"\n";
            lbImfo.Text += "Punkty życia "+ przedmiot.HP+"\n";
            lbImfo.Text += "Energia " + przedmiot.Energia+"\n";
            lbImfo.Text += "Szansa na trafienie "+ przedmiot.SzansaNaTrafienie+"\n";
            lbImfo.Text += "Szansa na krytyczne "+ przedmiot.SzansaNaKrytyczne+"\n";


        }
        void x_DragEnter(object sender, DragEventArgs e)
        {
          
            PictureBox przesuwany=(e.Data.GetData(typeof(PictureBox)) as PictureBox);
            bool sprzedaz =(bool) przesuwany.Parent.Tag;
            Ekwipunek ek = przesuwany.Tag as Ekwipunek;
            if(ek != null)
            {
                if (sprzedaz || gracz.Zloto>=ek.Cena)
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    DodajKomunikat(string.Format("Masz za malo złota aby kupic {0} za {1} sztuk złota", ek.Nazwa, ek.Cena));
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void btnWyjdz_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


      
    }
}
