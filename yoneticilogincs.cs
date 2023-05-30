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
    
    public partial class yoneticilogincs : Form
    {
        public static yoneticianaekran yae = new yoneticianaekran();
        public static string kullanicimSession = "";
        public yoneticilogincs()
        {
            InitializeComponent();
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (veritabani.yoneticigiriskontrol(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Başarılı Giriş! Sisteme Hoşgeldiniz..");
                this.Hide();
                kullanicimSession = textBox1.Text;
                yoneticianaekran yae = new yoneticianaekran();
                yae.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız, Tekrar Deneyiniz!");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void yoneticilogincs_Load(object sender, EventArgs e)
        {

        }
    }
}

