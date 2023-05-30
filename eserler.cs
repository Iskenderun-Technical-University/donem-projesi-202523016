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
    public partial class eserler : Form
    {
        public eserler()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd, cmd1;
        SqlDataAdapter da;
        DataSet ds;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";
        SqlConnection conn = new SqlConnection("Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True");
        void cmbDoldur()
        {
            conn.Open();

            SqlCommand doldur = new SqlCommand("select eser_kategori from eser_tablo", conn);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            conn.Close();
        }

        public string sql;
         void GridDoldur(string sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds,"eser_tablo");
            dataGridView1.DataSource = ds.Tables["eser_tablo"];
            con.Close();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void eserler_Load(object sender, EventArgs e)
        {
            cmbDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                GridDoldur("select * from eser_tablo where eser_kategori like '%" + comboBox1.SelectedItem.ToString() + "%' order by eser_kategori ASC");

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Eser Adı";
                dataGridView1.Columns[2].HeaderText = "Eser Sahibi";
                dataGridView1.Columns[3].HeaderText = "Eser Kategori";
                dataGridView1.Columns[5].HeaderText = "Giriş Tarihi";
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           if(textBox1.Text != "")
            {
                if (radioButton1.Checked)
                {
                   
                    
                  GridDoldur("select * from eser_tablo where eser_adi like '%" +textBox1.Text+ "%' order by eser_adi ASC");

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Eser Adı";
                    dataGridView1.Columns[2].HeaderText = "Eser Sahibi";
                    dataGridView1.Columns[3].HeaderText = "Eser Kategori";
                    dataGridView1.Columns[5].HeaderText = "Giriş Tarihi";

                }
                else if (radioButton3.Checked)
                {
             
                    GridDoldur( "select * from eser_tablo where eser_sahibi like '%" +textBox1.Text+ "%' order by eser_sahibi ASC");

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Eser Adı";
                    dataGridView1.Columns[2].HeaderText = "Eser Sahibi";
                    dataGridView1.Columns[3].HeaderText = "Eser Kategori";
                    dataGridView1.Columns[5].HeaderText = "Giriş Tarihi";

                }
                
            }
        }
    }
}
