using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace RPG
{
    public partial class EkranEkwipunek : Form
    {
        #region Zmienne
        EkranGry ekranGry;
        Gracz tymczasowyBohater = new Gracz();
        Ekwipunek przenoszonyPrzedmiot = new Ekwipunek();
        //Ekwipunek przechowanyPrzedmiot = new Ekwipunek();
        #endregion

        public EkranEkwipunek(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            DodanieDragAndDropDlaObrazkow();
            Zegar.Start();
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Rozmieszczanie statystyk
            LabelNazwyStatystyk.Size = new Size(Width * 23 / 100, Height * 80 / 100);
            LabelWartosciStatystyk.Size = new Size(Width * 4 / 100, LabelNazwyStatystyk.Height);

            LabelStatystyki.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Screen.PrimaryScreen.Bounds.Height * 8 / 100);
            LabelNazwyStatystyk.Location = new Point(LabelStatystyki.Location.X, LabelStatystyki.Location.Y + LabelStatystyki.Height);
            LabelWartosciStatystyk.Location = new Point(LabelStatystyki.Location.X + LabelNazwyStatystyk.Width, LabelStatystyki.Location.Y + LabelStatystyki.Height);

            //Rozmieszczanie przycisków
            PictureBoxPotwierdz.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 15 / 100, Screen.PrimaryScreen.Bounds.Height * 15 / 100);
            PictureBoxPotwierdz.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 75 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);

            const int wielkoscPrzyciskow = 25;
            PictureBoxSilaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxSilaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);

            const int odleglosciMiedzyPrzyciskamiX = 5;
            const int odleglosciMiedzyPrzyciskamiY = wielkoscPrzyciskow;
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width, LabelWartosciStatystyk.Location.Y + wielkoscPrzyciskow*2);
            PictureBoxSilaPlus.Location = new Point(PictureBoxSilaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxSilaMinus.Location.Y);
            PictureBoxZrecznoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxSilaMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxZrecznoscPlus.Location = new Point(PictureBoxZrecznoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxZrecznoscMinus.Location.Y);
            PictureBoxWitalnoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxZrecznoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxWitalnoscPlus.Location = new Point(PictureBoxWitalnoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxWitalnoscMinus.Location.Y);
            PictureBoxInteligencjaMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxWitalnoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxInteligencjaPlus.Location = new Point(PictureBoxInteligencjaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxInteligencjaMinus.Location.Y);


            //Rozmieszczanie ekwipunku
            FlowLayoutPanelPancerze.Size = new Size(Width * 22 / 100, Height * 60 / 100);
            PictureBoxBron.Size = new Size(Width * 5 / 100, Height * 8 / 100);
            PictureBoxPancerz.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);
            PictureBoxTarcza.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);

            FlowLayoutPanelPancerze.Location = new Point(Width * 71 / 100, Height * 10 / 100);
            PictureBoxBron.Location = new Point(Width * 45 / 100, Height * 28 / 100);
            PictureBoxPancerz.Location = new Point(Width * 51 / 100, Height * 23 / 100);
            PictureBoxTarcza.Location = new Point(Width * 57 / 100, Height * 23 / 100);

            int szerokoscIkon = (Width * 5 / 100)-5;
            int wysokoscIkon = Height * 8 / 100;

            //Dodawanie pól ekwipunku
            const int miejscWEkwipunku = 59;
            for (int i = 0; i <= miejscWEkwipunku; i++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(szerokoscIkon, wysokoscIkon);
                Program.UstawObrazEkwipunku(x, null);
                x.ImageLocation = null;
                x.Name = null;
                FlowLayoutPanelPancerze.Controls.Add(x);
            }
        }
        void KolorujElementy()
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPotwierdz, "Resources/Grafiki menu/Wyjdź.png");

            //Przyciski do rozdawania statystyk
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");

            Program.UstawObrazEkwipunku(PictureBoxBron, ekranGry.gra.gracz.obecnaBronGracza.Obrazek);
            Program.UstawObrazEkwipunku(PictureBoxPancerz, ekranGry.gra.gracz.obecnyPancerzGracza.Obrazek);
            Program.UstawObrazEkwipunku(PictureBoxTarcza, ekranGry.gra.gracz.obecnaTarczaGracza.Obrazek);


            //pozniej trzeba zmienic .listaPrzedmiotow na .gracz.plecakGracza 
            foreach (Ekwipunek przedmiot in ekranGry.gra.listaPrzedmiotow)
            {
                //tymczasowe zabezpieczenie na wypadek wiekszej ilosci przedmiotow niz miejsc w plecaku
                if (ekranGry.gra.listaPrzedmiotow.IndexOf(przedmiot) < FlowLayoutPanelPancerze.Controls.Count)
                {
                    Program.UstawObrazEkwipunku((FlowLayoutPanelPancerze.Controls[ekranGry.gra.listaPrzedmiotow.IndexOf(przedmiot)] as PictureBox), przedmiot.Obrazek);
                    (FlowLayoutPanelPancerze.Controls[ekranGry.gra.listaPrzedmiotow.IndexOf(przedmiot)] as PictureBox).Name = przedmiot.Nazwa;
                }
            }
        }

        #region Funkcje odświeżające okienka z informacjami
        void OdswiezStatystyki()
        {
            LabelNazwyStatystyk.Text = tymczasowyBohater.Nazwa + "\n";   
            LabelNazwyStatystyk.Text += "Pozostałe punkty do rozdania:\n";
            LabelNazwyStatystyk.Text += "Siła:\n";
            LabelNazwyStatystyk.Text += "Zręczność:\n";
            LabelNazwyStatystyk.Text += "Witalność:\n";
            LabelNazwyStatystyk.Text += "Inteligencja:\n";
            LabelNazwyStatystyk.Text += "Obrażenia:\n";
            LabelNazwyStatystyk.Text += "Pancerz:\n";
            LabelNazwyStatystyk.Text += "Zdrowie:\n";
            LabelNazwyStatystyk.Text += "Energia:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie krytyczne:\n";

            LabelWartosciStatystyk.Text = "\n";
            LabelWartosciStatystyk.Text += tymczasowyBohater.Punkty + "\n";               //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += tymczasowyBohater.Sila + "\n";                 //Siła
            LabelWartosciStatystyk.Text += tymczasowyBohater.Zrecznosc + "\n";            //Zręczność
            LabelWartosciStatystyk.Text += tymczasowyBohater.Witalnosc + "\n";            //Witalność
            LabelWartosciStatystyk.Text += tymczasowyBohater.Inteligencja + "\n";         //Inteligencja
            LabelWartosciStatystyk.Text += tymczasowyBohater.Obrazenia + "\n";            //Obrażenia
            LabelWartosciStatystyk.Text += tymczasowyBohater.Pancerz + "\n";              //Pancerz
            LabelWartosciStatystyk.Text += tymczasowyBohater.HP + "\n";                   //Zdrowie
            LabelWartosciStatystyk.Text += tymczasowyBohater.Energia + "\n";              //Energia
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaTrafienie + "%\n";   //Szansa na trafienie
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaKrytyczne + "%\n";   //Szansa na trafienie krytyczne
        }

        void OdswiezInformacjeOPrzedmiocie(Ekwipunek przedmiot)
        {
            LabelNazwaPrzedmiotu.Text = przedmiot.Nazwa;

            LabelOpisStatystykPrzedmiotu.Text = "Wartość:";
            LabelOpisStatystykPrzedmiotu.Text += "\nSiła:";
            LabelOpisStatystykPrzedmiotu.Text += "\nZręczność:";
            LabelOpisStatystykPrzedmiotu.Text += "\nWitalność:";
            LabelOpisStatystykPrzedmiotu.Text += "\nInteligencja:";
            LabelOpisStatystykPrzedmiotu.Text += "\nObrazenia:";
            LabelOpisStatystykPrzedmiotu.Text += "\nPancerz:";
            LabelOpisStatystykPrzedmiotu.Text += "\nPunkty życia:";
            LabelOpisStatystykPrzedmiotu.Text += "\nEnergia:";
            LabelOpisStatystykPrzedmiotu.Text += "\nSzansa na trafienie:";
            LabelOpisStatystykPrzedmiotu.Text += "\nSzansa na krytyczne:";

            LabelWartosciStatystykPrzedmiotu.Text = przedmiot.Cena.ToString();
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Sila;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Zrecznosc;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Witalnosc;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Inteligencja;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Obrazenia;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Pancerz;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.HP;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Energia;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.SzansaNaTrafienie;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.SzansaNaKrytyczne;
        }
        #endregion

        void WczytajStatystykiOdGracza()
        {
            tymczasowyBohater = new Gracz(ekranGry.gra.gracz);
            OdswiezStatystyki();
        }

        void ZapiszStatystykiDoGracza()
        {
            ekranGry.gra.gracz = new Gracz(tymczasowyBohater);
        }

        void DodanieDragAndDropDlaObrazkow()
        {
            //Dodawanie operacji Drop and Drag dla wszystkich PictureBox z FlowLayoutPanelPancerze
            foreach (PictureBox obiekt in FlowLayoutPanelPancerze.Controls.OfType<PictureBox>())
            {
                obiekt.AllowDrop = true;
                
                obiekt.MouseDown += przedmiot_MouseDownPrzedmiot;
                //obiekt.DragEnter += new DragEventHandler(przedmiot_DragEnterPrzedmiot);
                obiekt.DragOver += new DragEventHandler(przedmiot_DragOverPrzedmiot);
                //obiekt.DragLeave += new EventHandler(przedmiot_DragLeavePrzedmiot);
                obiekt.DragDrop += new DragEventHandler(przedmiot_DragDropPrzedmiot);

                obiekt.MouseEnter += przedmiot_MouseEnterPrzedmiot;
                obiekt.MouseLeave += przedmiot_MouseLeavePrzedmiot;
            }

            //Dodawanie operacji Drop and Drag dla PictureBox Bron/Pancerz/Tarcza
            PictureBoxBron.AllowDrop = true;
            PictureBoxPancerz.AllowDrop = true;
            PictureBoxTarcza.AllowDrop = true;
            
            //Gdy mysz jest naciśnięta na PictureBox, bądź obiekt upuszczony jest poza innym obiektem mogącym go przyjąć
            PictureBoxBron.MouseDown += przedmiot_MouseDownBron;
            PictureBoxPancerz.MouseDown += przedmiot_MouseDownPancerz;
            PictureBoxTarcza.MouseDown += przedmiot_MouseDownTarcza;

            //Gdy w obręb obiektu zostaje wniesiony przenoszony obiekt 
            PictureBoxBron.DragEnter += new DragEventHandler(przedmiot_DragEnterBron);
            PictureBoxPancerz.DragEnter += new DragEventHandler(przedmiot_DragEnterPancerz);
            PictureBoxTarcza.DragEnter += new DragEventHandler(przedmiot_DragEnterTarcza);

            //Gdy w obrębie obiektu porusza się przenoszony obiekt
            PictureBoxBron.DragOver += new DragEventHandler(przedmiot_DragOverBron);
            PictureBoxPancerz.DragOver += new DragEventHandler(przedmiot_DragOverPancerz);
            PictureBoxTarcza.DragOver += new DragEventHandler(przedmiot_DragOverTarcza);

            //Gdy z obrębu obiektu zostaje wyniesiony przenoszony obiekt
            PictureBoxBron.DragLeave += new EventHandler(przedmiot_DragLeaveBron);
            PictureBoxPancerz.DragLeave += new EventHandler(przedmiot_DragLeavePancerz);
            PictureBoxTarcza.DragLeave += new EventHandler(przedmiot_DragLeaveTarcza);

            //Gdy w obrębie obiektu zostanie upuszczony przenoszony obiekt
            PictureBoxBron.DragDrop += new DragEventHandler(przedmiot_DragDropBron);
            PictureBoxPancerz.DragDrop += new DragEventHandler(przedmiot_DragDropPancerz);
            PictureBoxTarcza.DragDrop += new DragEventHandler(przedmiot_DragDropTarcza);


            PictureBoxBron.MouseEnter += przedmiot_MouseEnterPrzedmiot;
            PictureBoxPancerz.MouseEnter += przedmiot_MouseEnterPrzedmiot;
            PictureBoxTarcza.MouseEnter += przedmiot_MouseEnterPrzedmiot;


            PictureBoxBron.MouseLeave += przedmiot_MouseLeavePrzedmiot;
            PictureBoxPancerz.MouseLeave += przedmiot_MouseLeavePrzedmiot;
            PictureBoxTarcza.MouseLeave += przedmiot_MouseLeavePrzedmiot;
            
        }
        #endregion




        #region Zdarzenia

        //Aby dostać się do przedmiotu przenoszonego:
        //(e.Data.GetData(typeof(PictureBox)) as PictureBox).Name
        //Aby dostać się do przedmiotu, na którym aktualnie jest Drag and Drop
        //(sender as PictureBox).Name

        void przedmiot_MouseEnterPrzedmiot(object sender, EventArgs e)
        {
            if (MouseButtons != MouseButtons.Left && (sender as PictureBox).ImageLocation!=null)
            {
                PanelOpisPrzedmiotu.Visible = true;
                int index = ekranGry.gra.listaPrzedmiotow.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
                if (index >= 0)
                {
                    Program.UstawObrazEkwipunku(PictureBoxPrzenoszony, ekranGry.gra.listaPrzedmiotow[index].Obrazek);
                    OdswiezInformacjeOPrzedmiocie(ekranGry.gra.listaPrzedmiotow[index]);
                }
            }
        }
        void przedmiot_MouseLeavePrzedmiot(object sender, EventArgs e)
        {
            if (MouseButtons != MouseButtons.Left)
            {
                PanelOpisPrzedmiotu.Visible = false;
            }
        }

        void przedmiot_MouseDownPrzedmiot(object sender, MouseEventArgs e)
        {
            if ((sender as PictureBox).ImageLocation != null)
            {
                PanelOpisPrzedmiotu.Visible = true;
                int index = ekranGry.gra.listaPrzedmiotow.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
                if (index >= 0)
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow[index];
                    Program.UstawObrazEkwipunku(PictureBoxPrzenoszony, przenoszonyPrzedmiot.Obrazek);
                    OdswiezInformacjeOPrzedmiocie(przenoszonyPrzedmiot);
                }
                DoDragDrop(sender, DragDropEffects.Move);
                PanelOpisPrzedmiotu.Visible = false;
            }
        }
        //private void przedmiot_DragEnterPrzedmiot(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;
        //}
        private void przedmiot_DragOverPrzedmiot(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        //private void przedmiot_DragLeavePrzedmiot(object sender, EventArgs e)
        //{
        //}
        private void przedmiot_DragDropPrzedmiot(object sender, DragEventArgs e)
        {
            if (MouseButtons != System.Windows.Forms.MouseButtons.Left)
            {
                if ((sender as PictureBox) != null)
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow.Find(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));

                    (sender as PictureBox).ImageLocation = (e.Data.GetData(typeof(PictureBox)) as PictureBox).ImageLocation;
                    (sender as PictureBox).Image = (e.Data.GetData(typeof(PictureBox)) as PictureBox).Image;

                    if ((sender as PictureBox).ImageLocation != null)
                    {
                        (e.Data.GetData(typeof(PictureBox)) as PictureBox).ImageLocation = przenoszonyPrzedmiot.Obrazek;
                        Program.UstawObrazEkwipunku((e.Data.GetData(typeof(PictureBox)) as PictureBox), przenoszonyPrzedmiot.Obrazek);
                    }
                }
            }
        }




        void przedmiot_MouseDownBron(object sender, MouseEventArgs e)
        {
        }
        private void przedmiot_DragEnterBron(object sender, DragEventArgs e)
        {
        }
        private void przedmiot_DragDropBron(object sender, DragEventArgs e)
        {
        }
        private void przedmiot_DragOverBron(object sender, DragEventArgs e)
        {
        }
        private void przedmiot_DragLeaveBron(object sender, EventArgs e)
        {
        }
        




        void przedmiot_MouseDownTarcza(object sender, MouseEventArgs e)
        {
        }
        private void przedmiot_DragEnterTarcza(object sender, DragEventArgs e)
        {
        }
        private void przedmiot_DragOverTarcza(object sender, DragEventArgs e)
        {
        }
        private void przedmiot_DragLeaveTarcza(object sender, EventArgs e)
        {
        }
        private void przedmiot_DragDropTarcza(object sender, DragEventArgs e)
        {
        }



        void przedmiot_MouseDownPancerz(object sender, MouseEventArgs e)
        {
        }
        private void przedmiot_DragEnterPancerz(object sender, DragEventArgs e)
        {
        }
        private void przedmiot_DragOverPancerz(object sender, DragEventArgs e)
        {
        }
        private void przedmiot_DragLeavePancerz(object sender, EventArgs e)
        {
        }
        private void przedmiot_DragDropPancerz(object sender, DragEventArgs e)
        {
        }









        private void EkranEkwipunek_Load(object sender, EventArgs e)
        {
            WczytajStatystykiOdGracza();
        }


        private void Zegar_Tick(object sender, EventArgs e)
        {
            PanelOpisPrzedmiotu.Location = new Point(MousePosition.X + 10, MousePosition.Y);
            PanelOpisPrzedmiotu.BringToFront();
        }


        #region Przyciski do modyfikowania statystyk
        private void PictureBoxSilaMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Sila > ekranGry.gra.gracz.Sila)
            {
                tymczasowyBohater.Sila--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxSilaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Sila++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxZrecznoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Zrecznosc > ekranGry.gra.gracz.Zrecznosc)
            {
                tymczasowyBohater.Zrecznosc--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxZrecznoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Zrecznosc++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxWitalnoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Witalnosc > ekranGry.gra.gracz.Witalnosc)
            {
                tymczasowyBohater.Witalnosc--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxWitalnoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Witalnosc++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxInteligencjaMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Inteligencja > ekranGry.gra.gracz.Inteligencja)
            {
                tymczasowyBohater.Inteligencja--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxInteligencjaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Inteligencja++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }
        #endregion

        #region Zamykanie forma
        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            ZapiszStatystykiDoGracza();
            Close();
        }

        private void EkranEkwipunek_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zegar.Stop();
        }
        #endregion

        #endregion

    }
}
