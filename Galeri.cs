using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasiG053
{
    internal class Galeri
    {
    
    public List<Araba> Arabalar { get; } = new List<Araba>();

        public Galeri()
        {
            SahteVeriGir();
        }

        public int GaleridekiAracSayisi => this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Durum == "Galeride")).ToList<Araba>().Count;

        public int KiradakiAracSayisi => this.Arabalar.Where<Araba>((Func<Araba, bool>)(t => t.Durum == "Kirada")).ToList<Araba>().Count;

        public int ToplamAracSayisi => this.Arabalar.Count;

        public int ToplamAracKiralamaSuresi => this.Arabalar.Sum<Araba>((Func<Araba, int>)(a => a.KiralamaSureleri.Sum()));

        public int ToplamAracKiralamaAdedi => this.Arabalar.Sum<Araba>((Func<Araba, int>)(a => a.KiralamaSayisi));

        public float Ciro => this.Arabalar.Sum<Araba>((Func<Araba, float>)(a => (float)a.ToplamKiralamaSuresi * a.KiralamaBedeli));

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            Arabalar.Add(new Araba(plaka, marka, kiralamaBedeli, aracTipi));
        }

        public void SahteVeriGir()
        {
            ArabaEkle("34ARB3434", "FIAT", 70f, "Sedan");
            ArabaEkle("35ARB3535", "KIA", 60f, "SUV");
            ArabaEkle("34US2342", "OPEL", 50f, "Hatchback");
        }

        public string DurumGetir(string plaka)
        {
            Araba araba = Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            return araba != null ? araba.Durum : "ArabaYok";
        }

        public void ArabaKirala(string plaka, int sure)
        {
            Araba araba = Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            if (araba != null && araba.Durum == "Galeride")
            {
                araba.Durum = "Kirada";
                araba.KiralamaSureleri.Add(sure);
            }
        }



       public List<Araba> ArabaListesiGetir(string durum)
        { 
            List<Araba> arabaList = this.Arabalar;
            if (durum == "Kirada" || durum == "Galeride")
                arabaList = this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Durum == durum)).ToList<Araba>();
            return arabaList;
        }

        public void ArabaTeslimAl(string plaka)
        {
            Araba araba = Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            if (araba != null)
            {
                araba.Durum = "Galeride";
            }
        }

        public void KiralamaIptal(string plaka)
        {
            Araba araba = Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            if (araba != null)
            {
                araba.Durum = "Galeride";
                araba.KiralamaSureleri.RemoveAt(araba.KiralamaSureleri.Count - 1);
            }
        }

        public void ArabaSil(string plaka)
        {
            Araba araba = Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            if (araba != null && araba.Durum == "Galeride")
            {
                Arabalar.Remove(araba);
            }
        }
    }
}
   