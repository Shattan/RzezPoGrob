using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace RPG.Narzedzia
{
    public static class Ustawienia
    {
        public static double GlosnoscMuzyki
        {
            get
            {
                double glosnosc;
                if(!double.TryParse( ConfigurationManager.AppSettings["GlosnoscMuzyki"],out glosnosc))
                {
                    glosnosc=5;
                }
                return glosnosc;
            }
            set
            {
                ZapiszUstawienie("GlosnoscMuzyki", value.ToString());
            }
        }
        public static double GlosnoscDzwiekow
        {
            get
            {
                double glosnosc;
                if (!double.TryParse(ConfigurationManager.AppSettings["GlosnoscDzwiekow"], out glosnosc))
                {
                    glosnosc = 5;
                }
                return glosnosc;
            }
            set
            {
                ZapiszUstawienie("GlosnoscDzwiekow", value.ToString());
            }
        }
        private static void ZapiszUstawienie(string nazwa,string wartosc)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[nazwa] == null)
            {
                settings.Add(nazwa, wartosc);
            }
            else
            {
                settings[nazwa].Value = wartosc;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
