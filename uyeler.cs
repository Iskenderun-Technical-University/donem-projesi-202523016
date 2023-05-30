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
    public partial class uyeler : Form
    {
        public uyeler()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";
        SqlConnection conn = new SqlConnection("Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True");
        void cmbDoldur()
        {
            conn.Open();

            SqlCommand doldur = new SqlCommand("select cinsiyet from ziyaretci_login", conn);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr[0]);

            }
            conn.Close();
        }
        private void uyeler_Load(object sender, EventArgs e)
        {
            veritabani.GridDoldur(dataGridView1, "select * from ziyaretci_login");
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[1].HeaderText = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Giriş Tarihi";
            cmbDoldur();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from ziyaretci_login where tc=@tcno and zID= @id";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@tcno", textBox4.Text);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.GridDoldur(dataGridView1, "select * from ziyaretci_login");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[6].Value;
        }
    }
}
