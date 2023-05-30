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

    public partial class eserislem : Form
    {
        
        public eserislem()
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

            SqlCommand doldur = new SqlCommand("select personel_ad from person_login", conn);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                comboBoxperson.Items.Add(dr[0]);
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBoxperson.SelectedIndex = -1;
        }

        private void eserislem_Load(object sender, EventArgs e)
        {
            veritabani.GridDoldur(dataGridView1, "select * from eser_tablo");
            cmbDoldur();
            
            

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void eserİşlemlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            this.Hide();
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "insert into eser_tablo(eser_adi, eser_sahibi, eser_kategori, personel_ad, giriş_tarihi) values (@esername, @esahip, @ekategori, @eperson, @tarih)";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@esername", textBox3.Text);
            cmd.Parameters.AddWithValue("@esahip", textBox2.Text);
            cmd.Parameters.AddWithValue("@ekategori", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@eperson", comboBoxperson.SelectedItem);
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.GridDoldur(dataGridView1, "select * from eser_tablo");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from eser_tablo where eser_adi=@esername and eserID= @id";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@esername", textBox3.Text);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.GridDoldur(dataGridView1, "select * from eser_tablo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "update eser_tablo set eser_kategori=@ekategori,personel_ad=@eperson where eser_adi=@esername and eserID=@id";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@esername", textBox3.Text);
            cmd.Parameters.AddWithValue("@eperson", comboBoxperson.SelectedItem);
            cmd.Parameters.AddWithValue("@ekategori", comboBox1.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.GridDoldur(dataGridView1, "select * from eser_tablo");
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBoxperson.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

      
    }
    }
  


