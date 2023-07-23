using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasiG053
{

    internal class Uygulama
    {
        
        private Galeri OtoGaleri = new Galeri();

        private int sayac = 0;

        public void Calistir()
        {
            while (true)
            {
                this.Menu();
                while (true)
                {
                    string secim = this.SecimAl();
                    Console.WriteLine();
                    switch (secim)
                    {
                        case "1":
                        case "K":
                            this.ArabaKirala();
                            goto case "X";
                        case "2":
                        case "T":
                            this.ArabaTeslimi();
                            goto case "X";
                        case "3":
                        case "R":
                            this.ArabalariListele("Kirada");
                            goto case "X";
                        case "4":
                        case "M":
                            this.ArabalariListele("Galeride");
                            goto case "X";
                        case "5":
                        case "A":
                            this.ArabalariListele("ArabaYok");
                            goto case "X";
                        case "6":
                        case "I":
                            this.KiralamaIptal();
                            goto case "X";
                        case "7":
                        case "Y":
                            this.YeniAraba();
                            goto case "X";
                        case "8":
                        case "S":
                            this.ArabaSil();
                            goto case "X";
                        case "9":
                        case "G":
                            this.BilgileriGoster();
                            goto case "X";
                        case "X":
                            continue;
                        case "ÇIKIŞ":
                            this.Cikis();
                            goto case "X";
                        default:
                            Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                            ++this.sayac;
                            goto case "X";
                    }
                }
            }
        }

        public void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                    ");
            Console.WriteLine("1- Araba Kirala (K)                 ");
            Console.WriteLine("2- Araba Teslim Al (T)              ");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)   ");
            Console.WriteLine("4- Galerideki Arabaları Listele (M) ");
            Console.WriteLine("5- Tüm Arabaları Listele (A)        ");
            Console.WriteLine("6- Kiralama İptali (I)              ");
            Console.WriteLine("7- Araba Ekle (Y)                   ");
            Console.WriteLine("8- Araba Sil (S)                    ");
            Console.WriteLine("9- Bilgileri Göster (G)             ");
        }

        public string SecimAl()
        {
            if (this.sayac != 10)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                return Console.ReadLine().ToUpper();
            }
            Console.WriteLine();
            Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
            return "ÇIKIŞ";
        }

        private void Cikis()
        {
            Environment.Exit(0);
        }

        private void ArabaKirala()
        {
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();

            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
                return;
            }

            if (OtoGaleri.GaleridekiAracSayisi == 0)
            {
                Console.WriteLine("Tüm araçlar kirada.");
                return;
            }

            string plaka;
            while (true)
            {
                plaka = EkVeri.PlakaAl("Kiralanacak arabanın plakası: ");
                if (plaka == "X")
                    return;

                string durum = OtoGaleri.DurumGetir(plaka);
                switch (durum)
                {
                    case "Kirada":
                        Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                        break;
                    case "ArabaYok":
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                        break;
                    default:
                        int sure = EkVeri.SayiAl("Kiralanma süresi: ");
                        OtoGaleri.ArabaKirala(plaka, sure);
                        Console.WriteLine();
                        Console.WriteLine($"{plaka.ToUpper()} plakalı araba {sure} saatliğine kiralandı.");
                        return;
                }
            }

        }

        private void ArabaTeslimi()
        {
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();

            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
                return;
            }

            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Kirada hiç araba yok.");
                return;
            }

            string plaka;
            while (true)
            {
                plaka = EkVeri.PlakaAl("Teslim edilecek arabanın plakası: ");
                if (plaka == "X")
                    return;

                string durum = OtoGaleri.DurumGetir(plaka);
                switch (durum)
                {
                    case "Galeride":
                        Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                        break;
                    case "ArabaYok":
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                        break;
                    default:
                        OtoGaleri.ArabaTeslimAl(plaka);
                        Console.WriteLine();
                        Console.WriteLine("Araba galeride beklemeye alındı.");
                        return;
                }
            }
        }


        public void ArabalariListele(string durum)
        {
            switch (durum)
            {
                case "Kirada":
                    Console.WriteLine("-Kiradaki Arabalar-");
                    break;
                case "Galeride":
                    Console.WriteLine("-Galerideki Arabalar-");
                    break;
                default:
                    Console.WriteLine("-Tüm Arabalar-");
                    break;
            }
            Console.WriteLine();
            this.ArabaListele(this.OtoGaleri.ArabaListesiGetir(durum));
        }

        private void ArabaListele(List<Araba> liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");
                Console.WriteLine("".PadRight(70, '-'));
                foreach (Araba araba in liste)
                    Console.WriteLine(araba.Plaka.PadRight(14) + araba.Marka.PadRight(12) + araba.KiralamaBedeli.ToString().PadRight(12) + araba.AracTipi.ToString().PadRight(12) + araba.KiralamaSayisi.ToString().PadRight(12) + araba.Durum);
            }
        }
    
    

        private void KiralamaIptal()
        {
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();

            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Kirada araba yok.");
                return;
            }

            string plaka;
            while (true)
            {
                plaka = EkVeri.PlakaAl("Kiralaması iptal edilecek arabanın plakası: ");
                if (plaka == "X")
                    return;

                string durum = OtoGaleri.DurumGetir(plaka);
                switch (durum)
                {
                    case "Galeride":
                        Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                        break;
                    case "ArabaYok":
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                        break;
                    default:
                        OtoGaleri.KiralamaIptal(plaka);
                        Console.WriteLine();
                        Console.WriteLine("İptal gerçekleştirildi.");
                        return;
                }
            }
        }

        private void YeniAraba()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();
            try 
            {
                string plaka;
                while (true)
                {
                    plaka = EkVeri.PlakaAl("Plaka: ");
                    if (plaka == "X")
                        return;

                    if (OtoGaleri.DurumGetir(plaka) == "Kirada" || OtoGaleri.DurumGetir(plaka) == "Galeride")
                    {
                        Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                    }
                    else
                    {
                        break;
                    }
                }

                string marka = EkVeri.YaziAl("Marka: ");
                if (marka == "X")
                    return;

                float kiralamaBedeli = EkVeri.SayiAl("Kiralama bedeli: ");
                string aracTipi = EkVeri.AracTipiAl();

                this.OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aracTipi);

                Console.WriteLine();
                Console.WriteLine("Araba başarılı bir şekilde eklendi.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Çıkış")
                    return;
                Console.WriteLine(ex.Message);
            }

        }
        
        

        private void ArabaSil()
        {
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();

            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Galeride silinecek araba yok.");
                return;
            }

            string plaka;
            while (true)
            {
                plaka = EkVeri.PlakaAl("Silmek istediğiniz arabanın plakasını giriniz: ");
                if (plaka == "X")
                    return;

                if (OtoGaleri.DurumGetir(plaka) == "ArabaYok")
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
                else if (OtoGaleri.DurumGetir(plaka) == "Kirada")
                {
                    Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                }
                else
                {
                    OtoGaleri.ArabaSil(plaka);
                    Console.WriteLine();
                    Console.WriteLine("Araba silindi.");
                    return;
                }
            }
        }

        private void BilgileriGoster()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine($"Toplam araba sayısı: {OtoGaleri.ToplamAracSayisi.ToString()}");
            Console.WriteLine($"Kiradaki araba sayısı: {OtoGaleri.KiradakiAracSayisi.ToString()}");
            Console.WriteLine($"Bekleyen araba sayısı: {OtoGaleri.GaleridekiAracSayisi.ToString()}");
            Console.WriteLine($"Toplam araba kiralama süresi: {OtoGaleri.ToplamAracKiralamaSuresi.ToString()}");
            Console.WriteLine($"Toplam araba kiralama adedi: {OtoGaleri.ToplamAracKiralamaAdedi.ToString()}");
            Console.WriteLine($"Ciro: {OtoGaleri.Ciro.ToString()}");
        }
    }
}
