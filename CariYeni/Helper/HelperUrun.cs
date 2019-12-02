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
    class HelperUrun
    {
        public static Urun GetUrun(int urunId)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                return ch.Urun.Where(x => x.UrunID == urunId).FirstOrDefault();
            }
        }
        public static bool DeleteUrun(int urunID)//hatalı
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var urunsil = ch.Urun.Find(urunID);
                ch.Urun.Remove(urunsil);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static Urun ConvertToUrunler(UrunModel um)// ürün tablosunu modele dönderir.
        {
            Urun yeniUrun = new Urun();
            yeniUrun.UrunID = um.UrunID;
            yeniUrun.UrunAdi = um.UrunAdi;
            yeniUrun.KategoriID = um.KategoriID;
            yeniUrun.AlisFiyati = um.AlisFiyati;
            yeniUrun.SatisFiyati = um.SatisFiyati;
            yeniUrun.UrunStok = um.UrunStok;
            yeniUrun.UrunAciklama = um.UrunAciklama;
            return yeniUrun;
        }
        public static bool AddUrun(UrunModel um)
        {
            var u = ConvertToUrunler(um);
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                ch.Urun.Add(u);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool UpdateUrun(UrunModel um)
        {
            var urun = ConvertToUrunler(um);
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                ch.Entry(urun).State = EntityState.Modified;
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static int FindKategoriID(string ad)
        {
            int id = 0;
            using (CariHesapOtomasyonuEntities he = new CariHesapOtomasyonuEntities())
            {
                var kategoriler = he.Kategori.ToList();
                foreach (var item in kategoriler)
                {
                    if (item.KategoriAdi.Equals(ad))
                    {
                        id = item.KategoriID;
                    }
                }
            }
            return id;
        }
        public static int FindUrun(UrunModel um)
        {
            int urunID = 0;
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var urunList = ch.Urun.ToList();

                foreach (var item in urunList)
                {
                    if (um.UrunAdi.Equals(item.UrunAdi))
                        //|| um.km.KategoriAdi.Equals(item.Kategori.KategoriAdi) || um.AlisFiyati.Equals(item.AlisFiyati) || um.SatisFiyati.Equals(item.SatisFiyati) ||
                       // um.UrunStok.Equals(item.UrunStok) || um.UrunAciklama.Equals(item.UrunAciklama))
                    {
                        urunID = item.UrunID;
                    }
                }
            }
            return urunID;
        }
        public static List<UrunModel> KategoriListesiModel()
        {
            List<UrunModel> kategoriList = new List<UrunModel>();
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var kategoriler = ch.Kategori.ToList();
                foreach (var item in kategoriler)
                {
                    UrunModel um = new UrunModel();
                    um.km.KategoriAdi = item.KategoriAdi;
                    um.km.KategoriID = item.KategoriID;
                    um.km.KategoriAciklama = item.KategoriAciklama;
                    kategoriList.Add(um);
                }
            }
            return kategoriList;
        }
        public static List<UrunModel> UrunListesiModel()//kategori adının ve açıklamasının dahil edilmesi
        {
            List<UrunModel> urunlerList = new List<UrunModel>();
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var list = ch.Urun.ToList();
                var categoryList = ch.Kategori.ToList();
                    
                foreach (var item in list)
                {
                    UrunModel um = new UrunModel();
                    um.UrunID = item.UrunID;
                    um.UrunAdi = item.UrunAdi;
                    um.KategoriID = item.KategoriID;
                    um.AlisFiyati = item.AlisFiyati;
                    um.SatisFiyati = item.SatisFiyati;
                    um.KategoriID = item.KategoriID;
                    um.UrunAciklama = item.UrunAciklama;
                    um.UrunStok = item.UrunStok;
                   
                    foreach (var kategori in categoryList)
                    {
                        if (item.KategoriID == kategori.KategoriID)
                        {
                            um.km.KategoriAdi = kategori.KategoriAdi;
                            um.km.KategoriAciklama = kategori.KategoriAciklama;
                        }
                    } 
                    urunlerList.Add(um);
                }
            }
            return urunlerList;

        }
    }
}
