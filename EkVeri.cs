using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasiG053
{
    internal class EkVeri
    {

        public static bool PlakaMi(string veri)
        {
            int result;
            return veri.Length > 6 && veri.Length < 10 && int.TryParse(veri.Substring(0, 2), out result) && HarfMi(veri.Substring(2, 1)) && (veri.Length == 7 && int.TryParse(veri.Substring(3), out result) || veri.Length < 9 && HarfMi(veri.Substring(3, 1)) && int.TryParse(veri.Substring(4), out result) || HarfMi(veri.Substring(3, 2)) && int.TryParse(veri.Substring(5), out result));
        }

        public static bool HarfMi(string veri)
        {
            veri = veri.ToUpper();
            foreach (char c in veri)
            {
                if (c < 'A' || c > 'Z')
                {
                    return false;
                }
            }
            return true;
        }

        public static string YaziAl(string yazi)
        {
            while (true)
            {
                Console.Write(yazi);
                string input = Console.ReadLine().ToUpper();
                if (int.TryParse(input, out int _))
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
                else
                {
                    return input == "X" ? input : input;
                }
            }
        }

        public static int SayiAl(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                string input = Console.ReadLine().ToUpper();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else if (input == "X")
                {
                    throw new Exception("Çıkış");
                }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
            }
        }

        public static string PlakaAl(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                string input = Console.ReadLine().ToUpper();
                if (input == "X")
                {
                    return input;
                }
                else if (PlakaMi(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                }
            }
        }

        public static string AracTipiAl()
        {
            Console.WriteLine("Araç tipi: ");
            Console.WriteLine("SUV için 1");
            Console.WriteLine("Hatchback için 2");
            Console.WriteLine("Sedan için 3");
            while (true)
            {
                Console.Write("Araba tipi: ");
                string input = Console.ReadLine().ToUpper();
                if (!(input == "X"))
                {
                    switch (input)
                    {
                        case "1":
                            return "SUV";
                        case "2":
                            return "Hatchback";
                        case "3":
                            return "Sedan";
                        default:
                            Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                            continue;
                    }
                }
                else
                    break;
            }
            throw new Exception("Çıkış");
        }

        }
    }

