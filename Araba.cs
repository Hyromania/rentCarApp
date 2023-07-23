using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasiG053
{
    internal class Araba
    {
        public List<int> KiralamaSureleri { get; } = new List<int>();

        public string Plaka { get; set; }

        public string Marka { get; set; }

        public float KiralamaBedeli { get; set; }

        public string AracTipi { get; set; }

        private string durum;

        public string Durum
        {
            get { return durum; }
            set { durum = value; }
        }

        public int KiralamaSayisi => KiralamaSureleri.Count;

        public int ToplamKiralamaSuresi => KiralamaSureleri.Sum();

        public Araba(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            Plaka = plaka.ToUpper();
            Marka = marka.ToUpper();
            KiralamaBedeli = kiralamaBedeli;
            AracTipi = aracTipi;
            Durum = "Galeride";
        }
    }
}