using CariYeni.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariYeni.Model
{
    public class SatisModel
    {
        public int SatisID { get; set; }
        public Nullable<int> MusteriID { get; set; }
        public Nullable<int> UrunID { get; set; }
        public int SatisFiyati { get; set; }

        public Musteri musteriler = new Musteri();

        public Urun urun = new Urun();
        

        //public virtual Musteri Musteri { get; set; }
        //public virtual Urun Urun { get; set; }
    }
}
