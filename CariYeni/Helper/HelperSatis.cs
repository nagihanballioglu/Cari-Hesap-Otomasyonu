using CariYeni.Entitiy;
using CariYeni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariYeni.Helper
{
    class HelperSatis
    {
        public static Satis ConvertToSatislar(SatisModel sm)
        {
            Satis ns = new Satis();
            ns.UrunID = sm.UrunID;
            ns.MusteriID = sm.MusteriID;
            ns.UrunID = sm.UrunID;
            ns.SatisFiyati = sm.SatisFiyati;
            return ns;
        }
        public static int FindUrunID(string ad, int kategoriID)
        {
            int urunID = 0;
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var list = ch.Urun.ToList();
                foreach (var item in list)
                {
                    if (item.UrunAdi.Equals(ad) && item.KategoriID.Equals(kategoriID))
                    {
                        urunID = item.UrunID;
                    }
                }
            }
            return urunID;
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
        public static List<Urun> GetUrunList(int kategoriId)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                return ch.Urun.Where(x => x.KategoriID == kategoriId).ToList();
            }
        }

        public static bool AddSatis(SatisModel sm)
        {
            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                var s = ConvertToSatislar(sm);
                ch.Satis.Add(s);
                if (ch.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static List<SatisModel> GetSatisModels()
        {
            using (CariHesapOtomasyonuEntities contex = new CariHesapOtomasyonuEntities())
            {
                var list = contex.Satis.ToList();
                List<SatisModel> sml = new List<SatisModel>();
                foreach (var item in list)
                {
                    SatisModel model = new SatisModel();
                    model.MusteriID = item.MusteriID;
                    model.musteriler.MusteriAdi = item.Musteri.MusteriAdi;
                    model.musteriler.MüsteriSoyadi = item.Musteri.MüsteriSoyadi;
                    model.urun.Kategori = item.Urun.Kategori;
                    model.UrunID = item.UrunID;
                    model.urun.UrunAdi = item.Urun.UrunAdi;
                    model.urun.SatisFiyati = item.Urun.SatisFiyati;
                    model.SatisFiyati = item.SatisFiyati;
                    sml.Add(model);
                }
                return sml;
            }
        }
        public static List<UrunModel> ReturnUrunler(int ID)
        {
            List<UrunModel> urunlerigetir = new List<UrunModel>();

            using (CariHesapOtomasyonuEntities ch = new CariHesapOtomasyonuEntities())
            {
                List<Urun> urunlers = ch.Urun.ToList();
                foreach (var item in urunlers)
                {
                    UrunModel um = new UrunModel();
                    if (item.KategoriID == ID)
                    {
                        um.UrunAdi = item.UrunAdi;
                        um.SatisFiyati = item.SatisFiyati;
                        um.UrunAciklama = item.UrunAciklama;

                        um.KategoriID = item.KategoriID;
                        um.AlisFiyati = item.AlisFiyati;
                        um.UrunStok = item.UrunStok;
                        
                        urunlerigetir.Add(um);
                    }
                }
            }
            return urunlerigetir;
        }

        public static List<SatisModel> GetSatisModels(string musteri, string urun, string kategori, DateTime dt1, DateTime dt2)
        {
            List<SatisModel> SatisModeli = new List<SatisModel> ();
            List<Satis> Satiss = new List<Satis>();
            return SatisModeli;
            //using (CariHesapOtomasyonuEntities contex = new CariHesapOtomasyonuEntities())
            //{
            //    //if (musteri != null)
            //    //{
            //    //    Satiss = contex.Satis.Where(x => x.KayitTarih >= dt1 && x.KayitTarih <= dt2).Where
            //    //        (x => x.Musteriler.MusteriAd.Contains(musteri) || x.Musteriler.MusteriSoyad.Contains(musteri)).ToList();
            //    //}
            //    //else if (urun != null)
            //    //{
            //    //    Satiss = contex.Satis.Where(x => x.KayitTarih >= dt1 && x.KayitTarih <= dt2).Where(x => x.Urun.UrunAd.Contains(urun)).ToList();
            //    //}
            //    //else if (kategori != null)
            //    //{
            //    //    Satiss = contex.Satis.Where(x => x.KayitTarih >= dt1 && x.KayitTarih <= dt2).Where(x => x.Urun.Kategori.KategoriName.Contains(kategori)).ToList();
            //    //}
            //    return contex;
            //}
        }
    }
}
