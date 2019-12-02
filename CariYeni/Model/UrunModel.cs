using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariYeni.Model
{
   public class UrunModel
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public int AlisFiyati { get; set; }
        public int SatisFiyati { get; set; }
        public Nullable<int> UrunStok { get; set; }
        public string UrunAciklama { get; set; }

        public KategoriModel km = new KategoriModel();
        public SatisModel sm = new SatisModel();
    }
}
