using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciYonetimUygulamasi
{
    class Uygulama
    {

        List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        public void Calistir()
        {
            SahteVeriGir();
            OgrenciYonetimUygulamasi();
        }

        public void SahteVeriGir()
        {

            Ogrenci o1 = new Ogrenci();
            o1.Ad = "Naz";
            o1.Soyad = "Şimşek";
            o1.No = 34;
            o1.Sube = "A";
            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Mehmet";
            o2.Soyad = "Batı";
            o2.No = 54;
            o2.Sube = "B";

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Ahmet";
            o3.Soyad = "Doğu";
            o3.No = 40;
            o3.Sube = "B";

            Ogrenciler.Add(o1);
            Ogrenciler.Add(o2);
            Ogrenciler.Add(o3);

        }

        public void OgrenciYonetimUygulamasi()
        {
            Menu();
            string secim = "123";
            while (secim != "")
            {
                
                secim = SecimAl();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                        OgrenciEkle();
                        break;
                    case "2":
                        OgrenciSil();
                        break;
                    case "3":
                        OgrenciListele();
                        break;
                }
            }
        }

        public string SecimAl()
        {
            int sayac = 0;
            string secim = "",cikti = "";
            bool kapi = true;
            while(kapi)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                secim = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "E":
                        cikti = "1";
                        kapi = false;
                        break;
                    case "2":
                    case "S":
                        cikti = "2";
                        kapi = false;
                        break;
                    case "3":
                    case "L":
                        cikti = "3";
                        kapi = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş yapıldı.");
                        sayac++;
                        if (sayac == 10)
                        {
                            Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                            kapi = false;
                        }
                        break;

                }// end switch case
            }// end while

            return cikti;
        }// end SecimAl

        public void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması V1");
            Console.WriteLine("1 - Öğrenci Ekle(E)          ");
            Console.WriteLine("2 - Öğrenci Sil(S)           ");
            Console.WriteLine("3 - Öğrenci Listele(L)       ");
            Console.WriteLine("4 - Çıkış(X)                 ");
        }

        public void OgrenciEkle()
        {
            //klavyede girilen değerlerle bir öğrenci oluşturlarım
            Ogrenci o = new Ogrenci();
            int siradaki_ogrenci = Ogrenciler.Count + 1;

            Console.WriteLine("1- Öğrenci Ekle -------------");
            Console.WriteLine(siradaki_ogrenci + ". Öğrencinin");
            int no;
            do
            {
                Console.Write("No: ");
                no = int.Parse(Console.ReadLine());
            } while (OgrenciNoSorgula(no));
            Console.Write("Adı: ");
            o.Ad = Console.ReadLine();
            Console.Write("Soyadı: ");
            o.Soyad = Console.ReadLine();
            Console.Write("Sube: ");
            o.Sube = Console.ReadLine();


            Ogrenciler.Add(o);
        }

        public bool OgrenciNoSorgula(int no) // girilen no ile öğrenci no su eşleştiğinde true değerini verir
        {
            bool deger = false;
            foreach (Ogrenci item in Ogrenciler)
                if(item.No == no)
                {
                    deger = true;
                    break;
                }
            
            return deger;
        }

        public void OgrenciListele()
        {
            Console.WriteLine("3- Öğrenci Listele--------------");
            Console.WriteLine();
            Console.WriteLine("Şube    No   Ad Soyad");
            Console.WriteLine("------------------------");

            for (int i = 0; i < Ogrenciler.Count; i++)
            {
                Ogrenci t = Ogrenciler[i];
                Console.WriteLine(" " + t.Sube + "      " + t.No + "  " + t.Ad + " " + t.Soyad);
            }


            foreach (Ogrenci t in Ogrenciler)
            {
                Console.WriteLine(" " + t.Sube + "      " + t.No + "  " + t.Ad + " " + t.Soyad);
            }

        }
        public void OgrenciSil()
        {
            Ogrenci o = null;
            Console.WriteLine("2- Öğrenci Sil -----------");
            if(Ogrenciler.Count == 0)
                Console.WriteLine("Listede silinecek öğrenci yok.");
            else
            {

                Console.WriteLine("Silmek istediğiniz öğrencinin");
                Console.Write("No: ");
                int no = int.Parse(Console.ReadLine());
                

                foreach (Ogrenci t in Ogrenciler)
                {
                    if (t.No == no)
                    {
                        o = t;
                        break;
                    }
                }
            }



            if (o != null)
            {
                Console.WriteLine("Adı: " + o.Ad);
                Console.WriteLine("Soyadı: " + o.Soyad);
                Console.WriteLine("Şubesi: " + o.Sube);
                Console.WriteLine("Öğrenciyi silmek istediğinize emin misiniz? (E/H)");
                string giris = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (giris == "e")
                {
                    Ogrenciler.Remove(o);
                    Console.WriteLine("Öğrenci silindi.");
                }
                else
                {
                    Console.WriteLine("Öğrenci silinmedi.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Bu numaraya sahip bir öğrenci yok.");
            }

        }// end OgrenciSil

    }
}
