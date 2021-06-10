using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
namespace Personel
{
    class Program
    {
        static void footer()
        {
            Console.Write("\n\n4)Ana Menu\t0)Cikis");

            Console.Write("\n\n//////////////////////////////////////////////////////////////////////////////////////////");
        hatalisecim:
            Console.Write("\nSeciminiz  :  ");
            int getirsecim = Convert.ToInt32(Console.ReadLine());

            switch (getirsecim)
            {
       
                case 4:
                    Console.WriteLine("Ana Menu");

                    Console.Clear();
                    Menu();
                    break;
                case 0:
                    Console.WriteLine("Cikis");
                    System.Environment.Exit(0);
                    break;



                default:
                    Console.WriteLine("Default case");
                    goto hatalisecim;
            }
        }

        static void departmanfooter()
        {
            Console.Write("\n\n1)Departman Ekleme\t2)Departman Silme\t3)Departman Guncelleme\t 4)Departmana Gore Sorgu \t5)Anamenu\t0)Cikis");

            Console.Write("\n\n//////////////////////////////////////////////////////////////////////////////////////////");
        hatalisecim:
            Console.Write("\n\nSeciminiz  :  ");
            int getirsecim = Convert.ToInt32(Console.ReadLine());

            switch (getirsecim)
            {
                case 1:
                    Console.WriteLine("Departman Ekle");
                    DepartmanEkle();
                    break;
                case 2:
                    Console.WriteLine("Departman Sil");
                    DepartmanSil();
                    break;
                case 3:
                    Console.WriteLine("Departman Guncelle");
                    DepartmanGuncelleme();
                    break;
                case 4:
                    depal();
                  break;
                case 5:
                   
                    Console.WriteLine("Ana Menu");

                    Console.Clear();
                    Menu();
                    break;
                case 0:
                    Console.WriteLine("Cikis");
                    System.Environment.Exit(0);
                    break;



                default:
                    Console.WriteLine("Default case");
                    goto hatalisecim;
            }
        }
        static void kayitfooter() 
        {
            Console.Write("\n\n1)Personel Ekleme\t2)Personel Silme\t3)Personel Guncelleme\t 4)Personel izin\t 5)Anamenu\t0)Cikis");

            Console.Write("\n\n//////////////////////////////////////////////////////////////////////////////////////////");
        hatalisecim:
            Console.Write("\n\nSeciminiz  :  ");
            int getirsecim = Convert.ToInt32(Console.ReadLine());

            switch (getirsecim)
            {
                case 1:
                    Console.WriteLine("Personel Ekle");
                    KayitEkle();
                    break;
                case 2:
                    Console.WriteLine("PErsonel Sil");
                    KayitSil();
                    break;
                case 3:
                    Console.WriteLine("Personel Guncelle");
                    KayitGuncelle();
                    break;
                case 4:


                    Personelizinleri();
                    break;
                case 5:


                    Menu();
                    break;
                case 0:
                    Console.WriteLine("Cikis");
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Default case");
                    goto hatalisecim;
            }
        }
        static void Menu() 
        {
        menu:
            Console.Clear();
            Console.WriteLine("\t          Personel Takip Sistemi             \n");
            Console.WriteLine("   1-PERSONEL LISTELE ");
            
            Console.WriteLine("   2-DEPARTMAN LISTELE");
      
            Console.WriteLine("   3-Tarih Sirasina Gore Sorgu\n");
            Console.Write("   Seçiminiz [1..3]  : ");
            int secim = 0;
            try
            {
                secim = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {

                Console.WriteLine("Hatalı Seçim Tekrar Deneyin....");
                goto menu;

            }
            if (secim == 1)
            {
                Console.Clear();
                KayitGetir();
            }
         
            else if (secim == 2)
            {
                DepartmanGetir();
            }
           
             else if (secim == 3)
            {
                departmanagore();
                
            }
     

            Console.ReadKey();
        
        }


        static void Main(string[] args)
        {
        basla1:
          
            Console.Write("  Kullanıcı adınızı giriniz : ");
            string kad = Console.ReadLine();
            if (kad == "admin")
            {
            basla2:
                Console.Write("  Şifrenizi giriniz : ");
                string sifre = Console.ReadLine();
                if (sifre == "admin")
                {
                    Console.WriteLine("Giriş başarılı...");
                    System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Menu();

                }
                else
                {
                    Console.Write("Şifreniz yanlış...\n");
                    System.Threading.Thread.Sleep(1000);
                  
                    goto basla2;

                }
            }
            else
            {
                Console.WriteLine("Kullanıcı adı hatalı...");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                goto basla1;
            }
            Console.ReadKey();



        }
      

        public static void KayitGetir()
        {
            Console.Clear();
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("select * from personel", baglanti);
            OleDbDataReader bilgigetir = komut.ExecuteReader();
            Console.WriteLine("\n\nid\tAdı\t Soyadı\t Departmani\n");
            int toplamkayit = 0;
            while (bilgigetir.Read())
            {
                toplamkayit++;
                Console.WriteLine(bilgigetir[0] + "\t" + bilgigetir[1] + "\t" +  bilgigetir[2]+ "\t\t" + bilgigetir[3]);
            }
            Console.WriteLine("\nToplam Kayıt : " + toplamkayit.ToString());
            baglanti.Close();

            kayitfooter();
        }
        public static void KayitEkle()
        {
            Console.Clear();
            Console.Write("\n\n Personel Adi\t\t : ");
            string ad = Console.ReadLine();
            Console.Write("Personel Soyadı\t : ");
            string soyad = Console.ReadLine();
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("select * from departman", baglanti);
            OleDbDataReader bilgigetir = komut.ExecuteReader();
            Console.WriteLine("\n\nID\tAdı\n");
      
            while (bilgigetir.Read())
            {
             
                Console.WriteLine(bilgigetir[0] + "\t" + bilgigetir[1]);
            }

            baglanti.Close();
          /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine(" departman seciniz");
            int dprt=Convert.ToInt32( Console.ReadLine());

            string blm = null;

           
            OleDbDataAdapter adaptor3 = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("select * from departman where id_dp="+ dprt+ "", baglanti);
            OleDbDataReader bilgigetir3 = komut.ExecuteReader();
           
            
            while (bilgigetir3.Read())
            {
               
               
                blm =Convert.ToString( bilgigetir3[1]);
            }
            Console.WriteLine(blm);
            baglanti.Close();      
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("INSERT INTO personel (adi,soyadi,departmani) VALUES ('" + ad + "','" + soyad + "','" + blm + "')", baglanti);
                int sonuc = komut.ExecuteNonQuery();
                baglanti.Close();
                if (sonuc > 0)
                {
                    Console.WriteLine("Kayıt Eklendi");
                }
                else
                {
                    Console.WriteLine("İşlem Başarısız");
                }
                KayitGetir();
                }
        public static void KayitSil()
        {
            sil:
           
            Console.Write("\n\nKaydı Silinecek Personelin Numarası");
            int silinecek = Convert.ToInt32(Console.ReadLine());
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)


                Console.Write("\nSilemk Istediginize Eminmisiniz E/H\t : ");
            string sor = Console.ReadLine();

            if (sor == "E")
            {
                baglanti.Open();
            komut = new OleDbCommand("Delete from personel Where id=" + silinecek, baglanti);
            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Kayıt Silindi");
                KayitGetir();
            }
            else
            {

            
                Console.WriteLine("İşlem Başarısız");
            }
            }
            else if (sor == "H") { KayitGetir(); }
            else { Console.Write("\n\n Evet Icin (E) HAyir Icin (H) Giriniz"); goto sil;
            }
        }
        public static void KayitGuncelle()
        {
           
            Console.Write("\n\nPersonelin Adı\t\t..:");
            string ad = Console.ReadLine();
            Console.Write("Personelin Soyadı\t : ");
            string soyad = Console.ReadLine();
            Console.Write("Personelin Departmani\t : ");
            string departmani = Console.ReadLine();
            Console.Write("Personel Numarası\t : ");
            int numara = Convert.ToInt32( Console.ReadLine());
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("UPDATE personel SET adi='" + ad + "',soyadi='" + soyad + "',departmani='" + departmani + "' WHERE id=" + numara, baglanti);
            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Kayıt Güncellendi");
                KayitGetir();
            }
            else
            {
                Console.WriteLine("İşlem Başarısız");
            }
        }
        public static void DepartmanGetir()
        {
            Console.Clear();
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("select * from departman", baglanti);
            OleDbDataReader bilgigetir = komut.ExecuteReader();
            Console.WriteLine("\n\nID\tAdı\n");
            int toplamkayit = 0;
            while (bilgigetir.Read())
            {
                toplamkayit++;
                Console.WriteLine(bilgigetir[0] + "\t" + bilgigetir[1]);
            }
            Console.WriteLine("Toplam Departman : " + toplamkayit.ToString());
            baglanti.Close();
            departmanfooter();
        }

        public static void DepartmanEkle()
        {
            Console.Clear();
            Console.Write("\n\n Departman Adi\t\t : ");
            string departmanadi = Console.ReadLine();
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("INSERT INTO departman (adi) VALUES ('" + departmanadi + "')", baglanti);
            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Kayıt Eklendi");
                DepartmanGetir();
            }
            else
            {
                Console.WriteLine("İşlem Başarısız");
            }
        }
        public static void DepartmanSil()
        {
        dsil:
           
            Console.Write("\n\nKaydı Silinecek Departman Numarası : ");
            int silinecek = Convert.ToInt32(Console.ReadLine());
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
        

                Console.Write("\n\nSilmek IStediginize Eminmisiniz (E/H) : ");
            string sor = Console.ReadLine();

            if (sor == "E") { 


                baglanti.Open();
            komut = new OleDbCommand("Delete from departman Where id_dp=" + silinecek, baglanti);
            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Kayıt Silindi");
                DepartmanGetir();
            }
            else
            {
                Console.WriteLine("İşlem Başarısız");
            }
            }
            else if (sor == "H") { Console.Write("\n\n Silme Islemi Iptak Edildi "); DepartmanGetir(); }
            else {
                Console.Write("\n\n Evet Icin (E) HAyir Icin (H) Giriniz");
                goto dsil;


            }




        }
        public static void DepartmanGuncelleme()
        {
           
            Console.Write("\n\nDepartman Adı\t\t : ");
            string ad = Console.ReadLine();
            Console.Write("\n\nGuncellenecek Departmanin Numarasi\t\t : ");
            int id =Convert.ToInt32( Console.ReadLine());
   
            string numara = Console.ReadLine();
            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("UPDATE departman SET adi='" + ad + "' WHERE id_dp=" + id, baglanti);
 
            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Kayıt Güncellendi");
                DepartmanGetir();
            }
            else
            {
                Console.WriteLine("İşlem Başarısız");
            }
        }

        public static void Personelizinleri()
        {
        tekrarla:

            Console.Clear();
            IzinliGetir();

            Console.Write("                                                                                 AnaMenu icin (0)\n");
            Console.Write("Izin Eklenecek Personel Numarası\t : ");
            int numara = Convert.ToInt32(Console.ReadLine());
            if (numara == 00)
            { Menu(); }
            else
            {

                try
                {
                    Console.Write("\n Izin Baslangic Tarihi (GG,AA,YY)\t\t :");
                    string ibaslangic = Console.ReadLine();

                    Console.Write("Izin Bitis Tarihi (GG,AA,YY)\t : ");
                    string ibitis = Console.ReadLine();
                    string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
                    OleDbCommand komut = new OleDbCommand();
                    OleDbDataAdapter adaptor = new OleDbDataAdapter();
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    komut = new OleDbCommand("UPDATE personel SET izin_baslangic='" + ibaslangic + "',izin_bitis='" + ibitis + "' WHERE id=" + numara, baglanti);
                    int sonuc = komut.ExecuteNonQuery();
                    baglanti.Close();
                    if (sonuc > 0)
                    {
                        Console.WriteLine("Izin Ekleme Basarili");
                        IzinliGetir();
                        goto tekrarla;

                    }
                    else
                    {
                        Console.WriteLine("İşlem Başarısız");
                    }

                }
                catch
                {

                    Console.WriteLine("Hatali giris yaptiniz");
                    System.Threading.Thread.Sleep(2000);
                    goto tekrarla;
                }

            }
        }


        public static void IzinliGetir()
        {
            Console.Clear();

            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new OleDbCommand("select * from personel", baglanti);
            OleDbDataReader bilgigetir = komut.ExecuteReader();
            Console.WriteLine("\n\nid\tAdı\t Soyadı\t\t Departmani   \t  Izin Baslangici  \t Izin Bitisi\n");
            int toplamkayit = 0;
            while (bilgigetir.Read())
            {
                toplamkayit++;
                Console.WriteLine(bilgigetir[0] + "\t" + bilgigetir[1] + "\t" + bilgigetir[2] + "\t\t" + bilgigetir[3] + "\t\t" + bilgigetir[4] + "\t" + bilgigetir[5]);
            }
            Console.WriteLine("\nToplam Kayıt : " + toplamkayit.ToString());
            baglanti.Close();

            

        }
        public static void departmanagore()
        {
            Console.Clear();
            Console.WriteLine(SqlDbType.DateTime);
            DateTime zaman = DateTime.Now;
           
            
            Console.WriteLine(zaman);
       
            DateTime dt= DateTime.Now.AddDays(-5);

         

            string way = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut = new OleDbCommand();
      
            OleDbDataAdapter adaptor = new OleDbDataAdapter();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

         komut = new OleDbCommand("select * from personel where izin_baslangic between "+ DateTime.Now.AddDays(-5) +"  and " + zaman  +" ", baglanti);
    

           
            OleDbDataReader bilgigetir = komut.ExecuteReader();
            Console.WriteLine("\n\nid\tAdı\t Soyadı\t\t Departmani   \t  Izin Baslangici  \t Izin Bitisi\n");
            int toplamkayit = 0;
            while (bilgigetir.Read())
            {
                toplamkayit++;
                Console.WriteLine(bilgigetir[0] + "\t" + bilgigetir[1] + "\t" + bilgigetir[2] + "\t\t" + bilgigetir[3] + "\t\t" + bilgigetir[4] + "\t" + bilgigetir[5]);
            }
            Console.WriteLine("\nToplam Kayıt : " + toplamkayit.ToString());
            baglanti.Close();

            footer();


        }
        public static void depal() 
        {
         
            Console.WriteLine(" \ndepartman seciniz");
            int dprt=Convert.ToInt32( Console.ReadLine());

            string blm = null;
            string way3 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OleDbConnection baglanti3 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + way3 + "/vt.accdb;Persist Security Info=False");
            OleDbCommand komut3 = new OleDbCommand();
            OleDbDataAdapter adaptor3 = new OleDbDataAdapter();
            if (baglanti3.State == ConnectionState.Closed)
                baglanti3.Open();
            komut3 = new OleDbCommand("select * from departman where id_dp="+ dprt+ "", baglanti3);
            OleDbDataReader bilgigetir3 = komut3.ExecuteReader();
           
            
            while (bilgigetir3.Read())
            {
               
               
                blm =Convert.ToString( bilgigetir3[1]);
            }
            Console.WriteLine();
            baglanti3.Close();
        
            if (baglanti3.State == ConnectionState.Closed)
                baglanti3.Open();
            komut3 = new OleDbCommand("select * from personel where departmani='" + blm + "'", baglanti3);
            OleDbDataReader bilgigetir4 = komut3.ExecuteReader();

            Console.WriteLine("\n\nid\tAdı\t Soyadı\t\t Departmani   \t  Izin Baslangici  \t Izin Bitisi\n");
            while (bilgigetir4.Read())
            {
                Console.WriteLine(bilgigetir4[0] + "\t" + bilgigetir4[1] + "\t" + bilgigetir4[2] + "\t\t" + bilgigetir4[3] + "\t\t" + bilgigetir4[4] + "\t" + bilgigetir4[5]);           
            }
            Console.WriteLine();
            baglanti3.Close();

            footer();      
        }
   
    }
}
