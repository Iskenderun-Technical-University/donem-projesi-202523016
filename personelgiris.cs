using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon
{
    public partial class personelgiris : Form
    {
        public personelgiris()
        {
            InitializeComponent();
        }
        public static string kullaniciSession = "";
        int sonuc = 0;
        public void captchaolustur()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            labelcaptcha.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            sonuc = ilk + ikinci;
            textBox3.Clear();
        }
        private void personelgiris_Load(object sender, EventArgs e)
        {
            captchaolustur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == sonuc.ToString())
            {
                if (veritabani.personelgiriskontrol(textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("Başarılı Giriş! Sisteme Hoşgeldiniz..");
                    this.Hide();
                    kullaniciSession = textBox1.Text;
                    personelanaekran pa = new personelanaekran();
                    pa.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız, Tekrar Deneyiniz!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                labelmesaj.Text = "Captcha Hatalı Girildi..";
                textBox3.Clear();
                textBox3.Focus();

            }

        }
    }
}
