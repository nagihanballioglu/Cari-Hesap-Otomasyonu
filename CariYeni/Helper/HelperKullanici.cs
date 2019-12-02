using CariYeni.Entitiy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariYeni.Helper
{
    class HelperKullanici
    {
        public static Kullanici GetKullanici(string kullanici, string sifre)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                return ch.Kullanici.Where(x => x.KullaniciAdi == kullanici && x.KullaniciSifre == sifre).FirstOrDefault();
            }
        }
        public static Kullanici GetKullanici(int ID)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                return ch.Kullanici.Where(x => x.KullaniciID == ID).FirstOrDefault();
            }
        }
        public static Kullanici UpdateKullanici(Kullanici k)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                ch.Entry(k).State = EntityState.Modified;
                ch.Kullanici.Add(k);
                ch.SaveChanges();
                return k;
            }
        }
    }
}
