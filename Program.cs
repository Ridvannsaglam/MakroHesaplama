using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakroHesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            makroCalculator();
        }

        public static void makroCalculator()
        {
            bool status = true;
            while (status)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("---Günlük Makro Besin İhtiyacı Hesaplama---");
                Console.WriteLine("-------------------------------------------");

                Console.Write("Ad Soyad: ");
                string adSoyad = Console.ReadLine();

                Console.Write("Cisiyet Giriniz (E-K): ");
                string cinsiyetSelect = Console.ReadLine();
                cinsiyetSelect = cinsiyetSelect.ToLower().Substring(0, 1);
                int cinsiyet = cinsiyetSelect == "e" ? 5 : -161;

                Console.Write("Yaş: ");
                int yas = Convert.ToInt32(Console.ReadLine());

                Console.Write("Boy: ");
                double boy = Convert.ToDouble(Console.ReadLine());
                if (boy < 3) boy *= 100;

                Console.Write("Kilo: ");
                int kilo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Hareket Derecesi Seçiniz: ");
                Console.WriteLine("Hareketsiz   (1) ");
                Console.WriteLine("Hafif Aktif  (2) ");
                Console.WriteLine("Orta Aktif   (3) ");
                Console.WriteLine("Çok Aktif    (4) ");
                Console.WriteLine("Ekstra Aktif (5) ");
                Console.Write("Derece Seçimi:  ");
                int dereceSelect = Convert.ToInt32(Console.ReadLine());

                double derece = dereceSelect == 1 ? 1.2 :
                                dereceSelect == 2 ? 1.375 :
                                dereceSelect == 3 ? 1.55 :
                                dereceSelect == 4 ? 1.725 :
                                dereceSelect == 5 ? 1.9 : 1.55;

                double kalori = calory(kilo, boy, yas, cinsiyet, derece);

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("\n-------------Kişisel Bilgiler--------------\n");

                Console.WriteLine("Ad Soyad : " + adSoyad);
                Console.WriteLine("Cinsiyet : " + (cinsiyetSelect == "e" ? "Erkek" : "Kadın"));
                Console.WriteLine("Yaş      : " + yas);
                Console.WriteLine("Boy      : " + boy);
                Console.WriteLine("Kilo     : " + kilo);

                makroKYP(kalori);

                status = ProgarmControl();

            }
        }

        public static double calory(int kilo, double boy, int yas, int cinsiyet, double derece)
        {
            double kalori = (10 * kilo + 6.25 * boy - 5 * yas + cinsiyet) * derece;
            return kalori;
        }
        public static void makroKYP(double kalori)
        {
            double makroKarbonhidrat = kalori * .60;
            double makroYag = kalori * .20;
            double makroProtein = kalori * .20;

            double makroKarbonhidratGram = (kalori * .60) / 4;
            double makroYagGram = (kalori * .20) / 9;
            double makroProteinGram = (kalori * .20) / 4;

            Console.WriteLine("\n----------Günlük Kalori İhtiyacı-----------\n");

            Console.WriteLine("Toplam Kalori İhtiyacı (cal): " + Math.Round(kalori, 3) + " cal");
            Console.WriteLine("\nKarbonhidrat ihtiyacı (cal) : " + Math.Round(makroKarbonhidrat, 3) + " cal");
            Console.WriteLine("Yağ ihtiyacı (cal)          : " + Math.Round(makroYag, 3) + " cal");
            Console.WriteLine("Protein ihtiyacı (cal)      : " + Math.Round(makroProtein, 3) + " cal");

            Console.WriteLine("\nKarbonhidrat ihtiyacı (gram): " + Math.Round(makroKarbonhidratGram, 3) + " gram");
            Console.WriteLine("Yağ ihtiyacı (gram)         : " + Math.Round(makroYagGram, 3) + " gram");
            Console.WriteLine("Protein ihtiyacı (gram)     : " + Math.Round(makroProteinGram, 3) + " gram");
            Console.WriteLine("\n-------------------------------------------\n");
        }

        public static bool ProgarmControl()
        {
            bool status = true;
            while (true)
            {
                Console.WriteLine("Başka Bir Hesaplama İçin (D) \nProgramı Kapatmak İçin (K)");
                ConsoleKeyInfo basilanTus = Console.ReadKey();

                if (basilanTus.Key.ToString().ToLower() == "k")
                {
                    Console.WriteLine("\nProgram Sonlandı Ekranı Kapatmak İçin Bir Tuşa Basınız");
                    status = false;
                    break;
                }
                else if (basilanTus.Key.ToString().ToLower() == "d")
                {
                    Console.WriteLine("\nYeni Veri Girişi İçin Bir Tuşa Basınız");
                    break;
                }
                else
                {
                    Console.WriteLine("\nYanlış Bir Tuşa Basıldı Tekrar Deneyiniz");
                }
            }
            Console.ReadKey();//herhangi bir tuşa basılmasını bekleme
            Console.Clear();//bir tuşa basıldığında ekran temizlenecek

            return status;
        }
    }
}
