using CariYeni.Entitiy;
using CariYeni.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariYeni.Helper
{
    class HelperMusteri
    {

        public static List<Musteri> GetMusteriList()//comboboxa müşteri eklemek için listeleme 
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                return ch.Musteri.ToList();
            }
        }
        public static Musteri ConvertToMusteriler(MusteriModel mm)//müşteri tablosunu model sınıfına dönderir.
        {
            Musteri yenimusteri = new Musteri();
            yenimusteri.MusteriID = mm.MusteriID;
            yenimusteri.MusteriAdi = mm.MusteriAdi;
            yenimusteri.MüsteriSoyadi = mm.MüsteriSoyadi;
            yenimusteri.MüsteriTelefon = mm.MüsteriTelefon;
            yenimusteri.MüsteriAdres = mm.MüsteriAdres;
            return yenimusteri;
        }
        public static bool AddMusteri(MusteriModel m)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                Musteri musteri = ConvertToMusteriler(m);
                ch.Musteri.Add(musteri);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static List<MusteriModel> MusteriListesiModel()// müşteri listesini model cinsinden döner.
        {
            List<MusteriModel> musteriList = new List<MusteriModel>();
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var list = ch.Musteri.ToList();
                foreach (Musteri item in list)
                {
                    MusteriModel mm = new MusteriModel();
                    mm.MusteriAdi = item.MusteriAdi;
                    mm.MüsteriSoyadi = item.MüsteriSoyadi;
                    mm.MüsteriTelefon = item.MüsteriTelefon;
                    mm.MüsteriAdres = item.MüsteriAdres;
                    musteriList.Add(mm);
                }
            }
            return musteriList;
        }
        public static int FindMusteri(MusteriModel m)//müşteri düzenlemeyi aktifleştirmek ve silme butonunda  kullanıldı.
        {
            int musteriID = 0;
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var list = ch.Musteri.ToList();
                foreach (var item in list)
                {
                    if (m.MusteriAdi.Equals(item.MusteriAdi) && m.MüsteriSoyadi.Equals(item.MüsteriSoyadi)
                     && m.MüsteriTelefon.Equals(item.MüsteriTelefon) && m.MüsteriAdres.Equals(item.MüsteriAdres))
                    {
                        musteriID = item.MusteriID; 
                    }
                }
            }

            return musteriID;
        }
      
        public static bool UpdateMusteri(MusteriModel mm)
        {
            var musteri = ConvertToMusteriler(mm);
            using (CariHesapOtomasyonuEntities he = new CariHesapOtomasyonuEntities())
            {
                he.Entry(musteri).State = EntityState.Modified;
                if (he.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool DeleteMusteri(int ID)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var customerdelete = ch.Musteri.Find(ID);
                ch.Musteri.Remove(customerdelete);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }   
}
