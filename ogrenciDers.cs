using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Ders
        {
            public string DersIsmi {  get; set; }
            public Ogrenci Ogrenci { get; set; }

            public Ders(string dersIsmi)
            {
                DersIsmi = dersIsmi;
            }

            public void OgrenciAta(Ogrenci ogrenci)
            {
                Ogrenci = ogrenci;
            }

            public void DersBilgileriniGoster()
            {
                Console.WriteLine($"Dersin Adı: {DersIsmi}");

                if (Ogrenci != null)
                {
                    Console.WriteLine($"Dersi Alan Öğrenci: {Ogrenci.Ad}");
                }
                else
                {
                    Console.WriteLine("Dersi Alan Öğrenci Bulunmamaktadır.");
                }
            }
        }

        public class Ogrenci
        {
            public string Ad {  get; set; }
            public List<Ders> Dersler { get; set; } = new List<Ders>();

            public Ogrenci(string ad)
            {
                this.Ad = ad;
            }

            public void DersEkle(Ders ders)
            {
                Dersler.Add(ders);
                ders.OgrenciAta(this);
            }

            public void OgrencininDersleriniGoster()
            {
                Console.WriteLine($"{Ad} İsimli Öğrencinin Dersleri:");
                foreach (var ders in Dersler)
                {
                    Console.WriteLine($"- {ders.DersIsmi}");
                }
            }
        }

        public class AssociationOrnek
        {
            public static void Main(string[] args)
            {
                Ogrenci ogrenci = new Ogrenci("Berre");
                Ders ders1 = new Ders("Oyun Motoru");
                Ders ders2 = new Ders("Sanal ve Artırılmış Gerçeklik Tasarımı");
                Ders ders3 = new Ders("Yaratıcı Fikir Geliştirme");
                Ders ders4 = new Ders("Nesneye Dayalı Programlama");

                ogrenci.DersEkle(ders1);
                ogrenci.DersEkle(ders2);
                ogrenci.DersEkle(ders3);
                ogrenci.DersEkle(ders4);

                ders1.DersBilgileriniGoster();
                ders2.DersBilgileriniGoster();
                ders3.DersBilgileriniGoster();
                ders4.DersBilgileriniGoster();
            }
        }
    }
}
