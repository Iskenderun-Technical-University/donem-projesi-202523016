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

    public partial class yonsifredegis : Form

    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";
        public void captchaolustur()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            label4.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            sonuc = ilk + ikinci;
            textBox4.Clear();
        }
        public yonsifredegis()
        {
            InitializeComponent();
        }
        public int sonuc = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == sonuc.ToString())
            {
                labelmesaj.Text = " ";
                if(textBox2.Text==textBox3.Text)
                {
                    eskisifrekontrol();
                }
                else
                {
                    labelmesaj.Text = "Girilen Şifreler Aynı Değil!";
                        
                }
            }
            else
            {
                labelmesaj.Text = "Captchca Hatalı Girildi..";
            }
           
        }
        public void eskisifrekontrol()
        {
            con = new SqlConnection(SqlCon);
            string sorgu = "select sifre from yonetici_login where username=@name and sifre=@pass";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@name", yoneticilogincs.kullanicimSession);
            cmd.Parameters.AddWithValue("@pass", veritabani.MD5Sifrele(textBox1.Text));
           
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con = new SqlConnection(SqlCon);
                string sql = "update yonetici_login set sifre= '"+veritabani.MD5Sifrele(textBox3.Text)+"'";
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Şifre Başarıyla Değiştirildi..");
                this.Hide();
            }
            else
            {
                labelmesaj.Text = "Eski Şifreniz Hatalı..";
                

            }
            con.Close();

        }

        private void yonsifredegis_Load(object sender, EventArgs e)
        {
    
            captchaolustur();
        }
    }
}
