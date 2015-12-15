﻿using RPG.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG.Formy
{
    public partial class EkranDialog : Form
    {
     
        DialogiBaza _Dialogi;
        Postac aktualniemowiaca;
        public EkranDialog(DialogiBaza dialogi)
        {

            _Dialogi = dialogi;
            InitializeComponent();
            dialogi.Konfiguracja();
            dialogipokazane.Add(_Dialogi.NastepnaAkcja());
        }
        List<LiniaDialogowa> dialogipokazane = new List<LiniaDialogowa>();

        private void EkranDialog_Paint(object sender, PaintEventArgs e)
        {
         

            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            Brush b=new SolidBrush(Color.Black);
            Image tlo = Narzedzia.MenagerZasobow.PobierzBitmape("resources/Grafiki menu/plotno.png");
            Rectangle tlopozycja=new Rectangle(0,(int)(Height/2),Width,Height);
            RectangleF zrodlotla=new RectangleF(0,0,tlo.Width,tlo.Height/2);

    
            int znakowwlini=50;

            g.DrawImage(tlo, tlopozycja, zrodlotla, GraphicsUnit.Pixel);

            if (!dialogipokazane.Any())
            {
                return;
            }
            Font f = new Font("Segoe Script", 20);
            Rectangle pozycjatekstu = new Rectangle(300, (int)(Height / 2) + 80, Width - 300, Height / 2);
             
            StringBuilder sb = new StringBuilder();
            for(int j=dialogipokazane.Count-1;j>=0;j--)
            {
                sb.Insert(0, string.Format("{0} - {1}\n", dialogipokazane[j].Wypowiadajacy.Nazwa, dialogipokazane[j].Tresc));
                float lini = (float)sb.Length / (float)znakowwlini;
                if(lini*f.Height>pozycjatekstu.Height-100)
                {
                    break;
                }
            }
             sb.Append("\nNaciśnij spację aby kontynuować");

             g.DrawString(sb.ToString(), f, b, pozycjatekstu);

          
        }
    
        private void EkranDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode!=Keys.Space)
            {
                return;
            }
            LiniaDialogowa tmp = _Dialogi.NastepnaAkcja();
            if (tmp == null)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }

            dialogipokazane.Add(tmp);
            Invalidate();
        }
     

    
    }
}
