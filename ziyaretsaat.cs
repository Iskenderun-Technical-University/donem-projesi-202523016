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
    public partial class ziyaretsaat : Form
    {
        public ziyaretsaat()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";
        SqlConnection conn = new SqlConnection("Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True");
 
        void cmbDoldur(ComboBox cmb, string sqlselectsorgu)
        {
            conn.Open();

            SqlCommand doldur = new SqlCommand(sqlselectsorgu, conn);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                
               cmb.Items.Add(dr[0]);

            }
            conn.Close();
        }


        private void ziyaretsaat_Load(object sender, EventArgs e)
        {
            veritabani.GridDoldur(dataGridView1, "select * from ziyaret_saatleri");
            cmbDoldur(comboBox3, "select tablolar from ziyaret_saatleri");
            cmbDoldur(comboBox2, "select Dinieserler from ziyaret_saatleri");
            cmbDoldur(comboBox1, "select Tarihieserler from ziyaret_saatleri");
            cmbDoldur(comboBox4, "select Heykeller from ziyaret_saatleri");
            cmbDoldur(comboBox5, "select Arkeolojikeserler from ziyaret_saatleri");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          label1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox4.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox5.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            label2.Text = dataGridView1.Columns[1].HeaderText.ToString();
            label3.Text = dataGridView1.Columns[2].HeaderText.ToString();
            label4.Text = dataGridView1.Columns[3].HeaderText.ToString();
            label5.Text = dataGridView1.Columns[4].HeaderText.ToString();
            label6.Text = dataGridView1.Columns[5].HeaderText.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            con = new SqlConnection(SqlCon);
            string sql = "update ziyaret_saatleri set tckimlikno=@tcno, personel_ad=@name where personID=@id";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@tcno", textBox3.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            veritabani.GridDoldur(dataGridView1, "select * from ziyaret_saatleri");*/

        }
    }
}
