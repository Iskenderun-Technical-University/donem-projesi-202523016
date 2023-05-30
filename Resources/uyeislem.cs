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
    public partial class uyeislem : Form
    {
        public uyeislem()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";
        int sonuc = 0;
        public void captchaolustur()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            labelcaptcha.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            sonuc = ilk + ikinci;
            textBox4.Clear();
        }

        private void uyeislem_Load(object sender, EventArgs e)
        {
            
            captchaolustur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == sonuc.ToString())
            {
                labelmesaj.Text = " ";
                if (textBox2.Text == textBox3.Text)
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
            string sorgu = "select şifre from ziyaretci_login where tc=@no and şifre=@pass";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@no", uyelogin.kullaniciSession);
            cmd.Parameters.AddWithValue("@pass", veritabani.MD5Sifrele(textBox1.Text));

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con = new SqlConnection(SqlCon);
                string sql = "update ziyaretci_login set şifre= '" + veritabani.MD5Sifrele(textBox2.Text) + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
    }
