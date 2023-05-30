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
    public partial class personelislem : Form
    {
        public personelislem()
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

            SqlCommand doldur = new SqlCommand("select cinsiyet from person_login", conn);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {

                comboBox2.Items.Add(dr[0]);
                
            }
            conn.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            yoneticianaekran.anaekran();
        }

        private void button4_Click(object sender, EventArgs e)
        { 
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBox2.SelectedIndex = -1;
            /*groupBox1.Controls*/
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[5].Value;
            dataGridView1.Columns[4].Visible = false;
        }

        private void personelislem_Load(object sender, EventArgs e)
        {
            veritabani.GridDoldur(dataGridView1, "select * from person_login");
            cmbDoldur();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "insert into person_login(tckimlikno, personel_ad, cinsiyet, şifre, giristarihi) values (@tcno, @name, @cinsiyet, @pass, @tarih)";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@tcno", textBox3.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@cinsiyet", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@pass", veritabani.MD5Sifrele(textBox4.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.GridDoldur(dataGridView1, "select * from person_login");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from person_login where tckimlikno=@tcno and personID= @id";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@tcno", textBox3.Text);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.GridDoldur(dataGridView1, "select * from person_login");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql ="update person_login set tckimlikno=@tcno, personel_ad=@name where personID=@id";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@tcno", textBox3.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            veritabani.GridDoldur(dataGridView1, "select * from person_login");
                
        }
    }
}
