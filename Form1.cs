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
using System.Data.SqlTypes;
namespace Project_2024_Inventory
{
    public partial class Form1 : Form
    {
        public bool MaximizeBox {  get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-CMSSRQKS\SQLEXPRESS;Initial Catalog=canteen_inventory;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Form1()
        {

            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registration where UserName = '"+ textBox1.Text +"' AND Password = '"+ textBox2.Text +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            int i = 0;
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            // dt.Rows.Count: Gets the number of rows returned by the SQL query.
            if (i == 0)
            {
                MessageBox.Show("This Username Password does not match.");
            }
            else
            {
                this.Hide();
                Home_page hp = new Home_page();
                hp.Show();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            To_ADD_newuser reg = new To_ADD_newuser();
            reg.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
