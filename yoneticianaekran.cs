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
    public partial class yoneticianaekran : Form
    {
        
        public yoneticianaekran()
        {
            InitializeComponent();
           
        }
       
        public static void anaekran()
        {
            yoneticianaekran yae = new yoneticianaekran();
            yae.Show();
        }
        
        private void personelEkleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void yoneticianaekran_Load(object sender, EventArgs e)
        {

        }

        private void eserİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            eserislem ei = new eserislem();
            ei.Show();
            
          
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yonsifredegis ynsifre = new yonsifredegis();
            ynsifre.Show();
        }

        private void personelİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            personelislem pi = new personelislem();
            pi.Show();
        }

        private void rezervasyonİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezerve re = new Rezerve();
            re.Show();
        }

        private void ziyaretSaatleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ziyaretsaat zs = new ziyaretsaat();
            zs.Show();
        }

        private void üyelerimizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeler uye = new uyeler();
            uye.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
