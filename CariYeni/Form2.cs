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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var result = Helper.HelperKullanici.GetKullanici(textBox1.Text, textBox2.Text);
                Helper.HelperSifre.Admin = result.KullaniciAdi;
                Helper.HelperSifre.AdminID = result.KullaniciID;
                if (result != null)
                {
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    label4.Text = "Giriş Başarısız...";
                    label4.ForeColor = Color.Red;
                }
                label4.Visible = true;
            }
            else
            {
                label4.Text = "Boş alanları doldurun!";
                label4.Visible = true;
                label4.ForeColor = Color.Red;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            label4.Visible = false;
        }
    }
}