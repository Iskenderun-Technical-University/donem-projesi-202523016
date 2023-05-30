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
    public partial class Anaekran : Form
    {
        public Anaekran()
        {
            InitializeComponent();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            yoneticilogincs yf = new yoneticilogincs();
            this.Hide();
            yf.Show();
            
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            uyeol kayıt = new uyeol();
            kayıt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            uyelogin zlogin = new uyelogin();
            zlogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            personelgiris pg = new personelgiris();
            pg.Show();
        }
    }
}
