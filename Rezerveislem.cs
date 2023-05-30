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
    public partial class Rezerveislem : Form
    {
        public Rezerveislem()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "insert into rezerve_tablo(ad, soyad, giristarihi, girişsaati) values (@name, @lastname, @tarih, @saat)";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
            cmd.Parameters.AddWithValue("@saat", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarıyla Oluşturuldu..");
            this.Hide();
        }
    }
}
