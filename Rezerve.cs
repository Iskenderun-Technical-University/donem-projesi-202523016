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
    public partial class Rezerve : Form
    {
        public Rezerve()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public static string SqlCon = "Data Source = EBRUACER\\SQLEXPRESS;Initial Catalog = eser; Integrated Security = True";

        private void Rezerve_Load(object sender, EventArgs e)
        {
            Verialma();
        }
        public void Verialma()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from rezerve_tablo", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();
            bindingSource1.DataSource = ds.Tables[0];
            bindingNavigator1.BindingSource = bindingSource1;
            textBox1.DataBindings.Add(new Binding("Text", bindingSource1, "ad" ));
            textBox2.DataBindings.Add(new Binding("Text", bindingSource1, "soyad"));
            dateTimePicker1.DataBindings.Add(new Binding("Value", bindingSource1, "giristarihi"));
            comboBox1.DataBindings.Add(new Binding("Text", bindingSource1, "girişsaati"));

        }
    }
}
