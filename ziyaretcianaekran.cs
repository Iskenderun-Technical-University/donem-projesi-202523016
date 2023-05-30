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
    public partial class ziyaretcianaekran : Form
    {
        public ziyaretcianaekran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eserler eserler = new eserler();
            eserler.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            uyeislem ui = new uyeislem();
            ui.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anaekran ae = new Anaekran();
            ae.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ziyaretsaat zs = new ziyaretsaat();
            zs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rezerveislem rislem = new Rezerveislem();
            rislem.Show();
        }
    }
}
