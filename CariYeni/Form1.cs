using CariYeni.Entitiy;
using CariYeni.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariYeni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MusteriListele();
            UrunListele();
            KategoriListele();
           //satislistele();
            dataGridView1.ClearSelection();// seçili olan hücreyi temizler
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            label24.Visible = false;
            label25.Visible = false;
            label30.Visible = false;
            button2.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label11.Text = Helper.HelperSifre.Admin;
            cmbEkle();
            cmbMüsteri();
            
        }
        public int selectedkategori;
        public int selectedmusteri;
        public int getID;
        public int kategoriId;
        public int UrunID;
        public int selectedfiyat;
        public int urunID;
        string mAd, mSoyad, mTel, mAdres;
        string uAd, uAciklama;
        string uKategori;
        string kAd, kAciklama;
        int alisfiyati = 0, satisfiyati = 0, stok = 0;
        int musteriID = 0;
        int kID = 0;
        //int secilenUrunKID = 0;

        DataTable table;
            
        private void Form1_Load(object sender, EventArgs e)
        {
            label29.Visible = false;
            KategoriEkle();
            table = new DataTable();

            table.Columns.Add("MüşteriAdı", typeof(string));
            table.Columns.Add("ÜrünKategori", typeof(string));
            table.Columns.Add("ÜrünAdı", typeof(string));
            table.Columns.Add("Adedi", typeof(int));
            table.Columns.Add("Fiyatı", typeof(int));
            table.Columns.Add("EklenmeTarihi", typeof(DateTime));
            dataGridView5.DataSource = table;

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mAd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mSoyad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            mTel = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mAdres = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            uAd = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            uKategori = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            alisfiyati = Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value);
            satisfiyati = Convert.ToInt32(dataGridView2.CurrentRow.Cells[3].Value);
            stok = Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value);
            uAciklama = dataGridView2.CurrentRow.Cells[5].Value.ToString();

           
        }
        private void DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)// datagride kategori ekleme
        {
            kAd = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            kAciklama = dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)  //Müşteri Ekle
        {
            MusteriModel yeniMusteri = new MusteriModel();
            yeniMusteri.MusteriAdi = textBox1.Text;
            yeniMusteri.MüsteriSoyadi = textBox2.Text;
            yeniMusteri.MüsteriTelefon = maskedTextBox1.Text;
            yeniMusteri.MüsteriAdres = textBox4.Text;

            bool eklendiMi = Helper.HelperMusteri.AddMusteri(yeniMusteri);

            if (eklendiMi)
            {
                MessageBox.Show("Müşteri eklendi!");
                dataGridView1.Rows.Clear();
                MusteriListele();
            }
            else
                MessageBox.Show("Müşteri eklenemedi, tekrar deneyiniz.");
        }

        private void Button3_Click(object sender, EventArgs e)//Müşteri silme
        {
            //string Cid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //bool success = Helper.HelperMusteri.DeleteMusteri(Convert.ToInt32(Cid));
            //if (success)
            //{
            //    MusteriListele();
            //}
            DialogResult result = MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?", "Müşteri Silme", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                MusteriModel mm = new MusteriModel();
                mm.MusteriAdi = mAd;
                mm.MüsteriSoyadi = mSoyad;
                mm.MüsteriTelefon = mTel;
                mm.MüsteriAdres = mAdres;

                bool silindiMi = Helper.HelperMusteri.DeleteMusteri(Helper.HelperMusteri.FindMusteri(mm));

                if (silindiMi)
                {
                    MessageBox.Show("Müşteri silindi");
                    dataGridView1.Rows.Clear();
                    MusteriListele();
                }
                else
                    MessageBox.Show("Silme işlemi gerçekleştirilemedi!!!");
            }
            else
                MessageBox.Show("Silme işlemi iptal edildi");
        }

        private void Button8_Click(object sender, EventArgs e)// kategori silme
        {
            DialogResult result = MessageBox.Show("Kategoriyi silmek istediğinize emin misiniz?", "Kategori Silme", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                KategoriModel km = new KategoriModel();
                km.KategoriAdi = kAd;
                km.KategoriAciklama = kAciklama;

                bool silindiMi = Helper.HelperKategori.DeleteKategori(Helper.HelperKategori.FindKategori(km));

                if (silindiMi)
                {
                    MessageBox.Show("Kategori silindi");
                    dataGridView3.Rows.Clear();
                    KategoriListele();
                }
                else
                    MessageBox.Show("Silme işlemi gerçekleştirilemedi!!!");
            }
            else
                MessageBox.Show("Silme işlemi iptal edildi");
            
        }
        private void Button13_Click(object sender, EventArgs e)//Müşteri düzenle butonunu aktive eder.
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = mAd;
                textBox2.Text = mSoyad;
                maskedTextBox1.Text = mTel;
                textBox4.Text = mAdres;

                MusteriModel updm = new MusteriModel();
                updm.MusteriAdi = mAd;
                updm.MüsteriSoyadi = mSoyad;
                updm.MüsteriTelefon = mTel;
                updm.MüsteriAdres = mAdres;
                musteriID = Helper.HelperMusteri.FindMusteri(updm);

                updm.MusteriID = musteriID;
                button2.Enabled = true;

            }
            else
                MessageBox.Show("Öncelikle listeden düzenlemek istediğiniz müşteriyi seçiniz.");
        }

        private void Button14_Click(object sender, EventArgs e) //Kategori düzenle değiştir butonunu aktive eder.
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                textBox13.Text = kAd;
                textBox12.Text = kAciklama;

                KategoriModel km = new KategoriModel();
                km.KategoriAdi = kAd;
                km.KategoriAciklama = kAciklama;
                kategoriId = Helper.HelperKategori.FindKategori(km);
                km.KategoriID = kategoriId;
                button9.Enabled = true;
            }
        }
        private void Button2_Click(object sender, EventArgs e)//Müşteri Düzenleme
        {
            MusteriModel mm = new MusteriModel();
            mm.MusteriAdi = textBox1.Text;
            mm.MüsteriSoyadi = textBox2.Text;
            mm.MüsteriTelefon = maskedTextBox1.Text;
            mm.MüsteriAdres = textBox4.Text;

            Helper.HelperMusteri.AddMusteri(mm);
            MessageBox.Show("Müşteri güncellendi!");
            dataGridView1.Rows.Clear();
            MusteriListele();
        }

        private void Button6_Click(object sender, EventArgs e)//Ürün Ekle
        {
            UrunModel yeniurun = new UrunModel();

            yeniurun.UrunAdi = textBox8.Text;
            yeniurun.KategoriID = Convert.ToInt32(comboBox1.SelectedValue);
            yeniurun.AlisFiyati = Convert.ToInt32(textBox7.Text);
            yeniurun.SatisFiyati = Convert.ToInt32(textBox9.Text);
            yeniurun.UrunStok = Convert.ToInt32(textBox5.Text);
            yeniurun.UrunAciklama = textBox10.Text;
            Helper.HelperUrun.AddUrun(yeniurun);

            MessageBox.Show("Ürün eklendi.");
            dataGridView2.Rows.Clear();
            UrunListele();
            dataGridView2.ClearSelection();
        }

        private void Button7_Click(object sender, EventArgs e)//ürün güncelle
        {

            UrunModel dUrun = new UrunModel();
            dUrun.UrunAdi = textBox8.Text;
            dUrun.KategoriID = Convert.ToInt32(comboBox1.SelectedValue);
            dUrun.AlisFiyati = Convert.ToInt32(textBox7.Text);
            dUrun.SatisFiyati = Convert.ToInt32(textBox9.Text);
            dUrun.UrunStok = Convert.ToInt32(textBox5.Text);
            //dUrun.UrunID = Helper.HelperUrun.FindUrun(dUrun);
            dUrun.UrunAciklama = textBox10.Text;
            Helper.HelperUrun.AddUrun(dUrun);
            MessageBox.Show("Ürün güncellendi.");
            dataGridView2.Rows.Clear();
            UrunListele();
            dataGridView2.ClearSelection();

            
        }

        private void Button4_Click(object sender, EventArgs e)//Ürün silme
        {

            DialogResult result = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "Ürün Silme", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                UrunModel um = new UrunModel();
                um.UrunAdi = uAd;
                um.AlisFiyati = alisfiyati;
                um.SatisFiyati = satisfiyati;
                bool silindiMi = Helper.HelperUrun.DeleteUrun(Helper.HelperUrun.FindUrun(um));
                if (silindiMi)
                {
                    MessageBox.Show("Başarıyla silindi");
                    dataGridView2.Rows.Clear();
                    UrunListele(); dataGridView2.ClearSelection();
                }
            }
            else
                MessageBox.Show("Silme işlemi iptal edildi");
        }

        private void Button10_Click(object sender, EventArgs e)//Satışları Listele
        {
            kID = Helper.HelperSatis.FindKategoriID(comboBox2.SelectedItem.ToString());
            dataGridView4.Rows.Clear();
            satislistele();
            dataGridView4.ClearSelection();
           // dataGridView4.Rows.Clear();
            var urun = Helper.HelperSatis.GetUrunList(selectedkategori);
            foreach (var item in urun)
            {
                dataGridView4.Rows.Add(item.UrunAdi, item.SatisFiyati, item.UrunAciklama);
            }
           
        }
        private void Button11_Click(object sender, EventArgs e) //Satışı tamamla
        {
                SatisModel s = new SatisModel();
                bool result = Helper.HelperSatis.AddSatis(s);
                if (result)
                {
                    MessageBox.Show("Satış Yapıldı.");
                satislistele();
                }
                else
                {
                    MessageBox.Show("Satış yapılamadı.");
                }
               
        }

        private void Button12_Click(object sender, EventArgs e) //Kategori Ekle
        {
            KategoriModel yeniKategori = new KategoriModel();
            yeniKategori.KategoriAdi = textBox13.Text;
            yeniKategori.KategoriAciklama = textBox12.Text;

            bool eklendiMi = Helper.HelperKategori.AddKategori(yeniKategori);


            if (eklendiMi)
            {
                MessageBox.Show("Kategori eklendi!");
                dataGridView3.Rows.Clear();
                KategoriListele();
            }
            else
                MessageBox.Show("Müşteri eklenemedi, tekrar deneyiniz.");
        }

        private void Button15_Click(object sender, EventArgs e) //Kullanıcı şifresi değiştirme
        {
            Kullanici kk = new Kullanici();
            int userID = Helper.HelperSifre.AdminID;
            var u = Helper.HelperKullanici.GetKullanici(userID);
            if (u.KullaniciSifre == textBox17.Text)
            {
                label29.Visible = false;

                if ((textBox16.Text != "" && textBox15.Text != "") && (textBox16.Text == textBox15.Text))
                {
                    u.KullaniciSifre = textBox15.Text;
                    Helper.HelperKullanici.UpdateKullanici(kk);
                    label29.ForeColor = Color.Green;
                    label29.Visible = true;
                    label29.Text = "Şifre Kaydedildi";
                }
            }
            else
            {
                label29.ForeColor = Color.Red;
                label29.Visible = true;
                label29.Text = "Girdiğiniz şifre yanlış ya da eksik.";
            }
        }


        private void TextBox14_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            if (radioButton1.Checked==true)
            {
                string isim = textBox14.Text;
                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;
                var rapor = Helper.HelperSatis.GetSatisModels();
                if (rapor.Count()>0)
                {
                    foreach (var item in rapor)
                    {
                        dataGridView5.Rows.Add(isim, item.urun.KategoriID, item.urun.UrunAdi, item.SatisFiyati);
                    }
                    label25.Visible = true;
                }
                else
                {
                    MessageBox.Show("lütfen kontrol ediniz.Ürünün satışı gerçekleştirilememiştir.");
                }
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            KategoriModel km = new KategoriModel();
            km.KategoriAdi = textBox13.Text;
            km.KategoriAciklama = textBox12.Text;
            Helper.HelperKategori.UpdateKategori(km);
            dataGridView3.Rows.Clear();
            KategoriListele();
            
        }

        
        public void MusteriListele()//müşteri listesini gridviewa model cinsinden ekler.
        {
            List<MusteriModel> musteriList = Helper.HelperMusteri.MusteriListesiModel();
            foreach (MusteriModel item in musteriList)
            {
                dataGridView1.Rows.Add(item.MusteriAdi, item.MüsteriSoyadi, item.MüsteriTelefon, item.MüsteriAdres);

            }
        }
         
        public void KategoriListele()//kategori listesini gridviewa model cinsinden ekler.
        {
            List<KategoriModel> kategoriList = Helper.HelperKategori.KategoriListesiModel();
            foreach (KategoriModel item in kategoriList)
            {
                dataGridView3.Rows.Add(item.KategoriAdi, item.KategoriAciklama);
                    
            }
        }

        private void DataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)// kategorisi seçilen ürünü getirir.
        {
            uAd = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView4.SelectedRows.Count > 0)
            {
                textBox11.Text = uAd;
            }
            SatisModel urunmodelgel = new SatisModel();
            urunmodelgel.urun.UrunAdi = uAd;

        }

        private void Button5_Click(object sender, EventArgs e)//ürün düzenle butonunu aktive eder adı get nulls olduğu için çalışmıyor.
        {
            button7.Enabled = true;
            comboBox1.Enabled = true;

            textBox8.Text = uAd;
           // comboBox1.SelectedItem = comboBox1.Items[ComboBoxKategori()];
            textBox7.Text = alisfiyati.ToString();
            textBox9.Text = satisfiyati.ToString();
            textBox5.Text = stok.ToString();
            textBox10.Text = uAciklama;
        }

        
        public void UrunListele() // ürün listesini gridviewa model cinsinden ekler
        {
            List<UrunModel> urunList = Helper.HelperUrun.UrunListesiModel();
            foreach (var item in urunList)
            {
                dataGridView2.Rows.Add(item.UrunAdi, item.km.KategoriAdi, item.AlisFiyati, item.SatisFiyati, item.UrunStok, item.UrunAciklama);
            }
        }

        
        public void satislistele()// satış yönetimi sayfasına gride veri ekler.
        {
            List<UrunModel> kategori = Helper.HelperUrun.UrunListesiModel();
            foreach (var item in kategori)
            {
                dataGridView4.Rows.Add(item.UrunAdi, item.SatisFiyati, item.UrunAciklama);
            }
        }
        public void KategoriEkle()// combobox a veri gönderme
        {
            comboBox1.Items.Clear();
            comboBox1.ValueMember = "KategoriID";
            comboBox1.DisplayMember = "KategoriAdi";
            comboBox1.DataSource = Helper.HelperKategori.GetKategoriList();
        }

        public void cmbEkle() //comboboxa kategori ekleme
        {
            comboBox2.ValueMember = "KategoriID";
            comboBox2.DisplayMember = "KategoriAdi";
            comboBox2.DataSource = Helper.HelperKategori.GetKategoriList();
        }

        public void cmbMüsteri() //Comboboxa müşteri ekleme
        {
            comboBox3.ValueMember = "MusteriID";
            comboBox3.DisplayMember = "MusteriAdi";
            comboBox3.DataSource =Helper.HelperMusteri.GetMusteriList();
        }

        public void SatisEkle()
        {
            var result = Helper.HelperSatis.GetSatisModels();
            foreach (var item in result)
            {

                var adet = item.SatisFiyati / item.urun.SatisFiyati;
                table.Rows.Add(item.musteriler.MusteriAdi + " " + item.musteriler.MüsteriSoyadi, item.urun.Kategori.KategoriAdi, item.urun.UrunAdi, adet, item.SatisFiyati);
            }
        }

        
    }
    
}
