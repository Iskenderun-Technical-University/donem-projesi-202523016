using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otomasyon
{
    public partial class uyeol : Form
    {
        public uyeol()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";
        void kayıt()
        {

            con = new SqlConnection(SqlCon);
            string sql = "insert into ziyaretci_login(tc, ad, soyad , cinsiyet, şifre, giristarihi) values (@tcno, @name, @lastname, @cinsiyet, @pass, @tarih)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@tcno", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox3.Text);
            cmd.Parameters.AddWithValue("@cinsiyet", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@pass", veritabani.MD5Sifrele(textBox4.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == textBox5.Text)
            {
                kayıt();
                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleşti, Lütfen Giriş Yapınız..");
                this.Hide();
                Anaekran ae = new Anaekran();
                ae.Show();
            }
            else
            {
                labelmesaj.Text = "Girilen Şifreler Aynı Değil!";
                textBox4.Clear();
                textBox5.Clear();
                textBox4.Focus();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anaekran ae = new Anaekran();
            ae.Show();

        }
    }
}
  
                        
                         

 
