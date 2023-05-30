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
    public partial class eserperson : Form
    {
        public eserperson()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd, cmd1;
        SqlDataAdapter da;
        DataSet ds;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";
        public string sql;
        void GridDoldur(string sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "eser_tablo");
            dataGridView1.DataSource = ds.Tables["eser_tablo"];
            con.Close();


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            { 
                GridDoldur("select eser_tablo.* , person_login.* from eser_tablo INNER JOIN person_login ON eser_tablo.personel_ad = person_login.personel_ad where eser_tablo.eser_adi like '%" + textBox1.Text + "%'");
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Eser Adı";
            dataGridView1.Columns[2].HeaderText = "Eser Sahibi";
            dataGridView1.Columns[3].HeaderText = "Eser Kategori";
            dataGridView1.Columns[5].HeaderText = "Giriş Tarihi";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Personel Adı";
            dataGridView1.Columns[9].HeaderText = "Cinsiyet";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].HeaderText = "Giriş Tarihi";



        }
    }
}
