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
    public partial class personelanaekran : Form
    {
        public personelanaekran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eserler es = new eserler();
            es.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rezerve re = new Rezerve();
            re.Show();
        }

        private void rezervasyonEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezerveislem ri = new Rezerveislem();
            ri.Show();
        }

        private void eserİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void üyelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeler uye = new uyeler();
            uye.Show();
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personsifre sifre = new personsifre();
            sifre.Show();
        }

        private void eserPersonelBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eserperson ep = new eserperson();
            ep.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eserİşlemleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            eserislem ei = new eserislem();
            ei.Show();
        }
    }
}
