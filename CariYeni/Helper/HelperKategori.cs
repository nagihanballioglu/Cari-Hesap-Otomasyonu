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
    class HelperKategori
    {

        public static Kategori ConvertToMusteriler(KategoriModel km)//Kategori tablosunu model sınıfına dönderir.
        {
            Kategori yeniKategori = new Kategori();
            yeniKategori.KategoriID = km.KategoriID;
            yeniKategori.KategoriAdi = km.KategoriAdi;
            yeniKategori.KategoriAciklama = km.KategoriAciklama;

            return yeniKategori;
        }
        public static bool AddKategori(KategoriModel k)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                Kategori kategori = ConvertToMusteriler(k);
                ch.Kategori.Add(kategori);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool UpdateKategori(KategoriModel km)
        {
            using(CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                Kategori kategori = ConvertToMusteriler(km);
                ch.Kategori.Add(kategori);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            //var kategori = ConvertToMusteriler(km);
            //using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            //{
            //    ch.Entry(kategori).State = EntityState.Modified;
            //    if (ch.SaveChanges() > 0)
            //    {
            //        return true;
            //    }
            //    else
            //        return false;
            //}
        }

        public static bool DeleteKategori(int ID)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var s = ch.Kategori.Find(ID);
                ch.Kategori.Remove(s);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static List<KategoriModel> KategoriListesiModel()// kategori listesini model cinsinden döner.
        {
            List<KategoriModel> kategoriList = new List<KategoriModel>();
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var list = ch.Kategori.ToList();
                foreach (Kategori item in list)
                {
                    KategoriModel km = new KategoriModel();
                    km.KategoriAdi = item.KategoriAdi;
                    km.KategoriAciklama = item.KategoriAciklama;
                   
                    kategoriList.Add(km);
                }
            }
            return kategoriList;
        }

        public static int FindKategori(KategoriModel km)//kategori düzenlemeyi aktifleştirmek ve düzenle butonunda  kullanıldı.
        {
            int kategoriID = 0;
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var list = ch.Kategori.ToList();
                foreach (var item in list)
                {
                    if (km.KategoriAdi.Equals(item.KategoriAdi) && km.KategoriAciklama.Equals(item.KategoriAciklama)) 

                    {
                        kategoriID = item.KategoriID;
                    }
                }
            }
            return kategoriID;
        }
            public static List<Kategori> GetKategoriList()
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                return ch.Kategori.ToList();
            }
        }
    }
}
