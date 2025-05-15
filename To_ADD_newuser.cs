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

namespace Project_2024_Inventory
{
    public partial class To_ADD_newuser : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-CMSSRQKS\SQLEXPRESS;Initial Catalog=canteen_inventory;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public To_ADD_newuser()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            Form1 bck = new Form1();
            bck.ShowDialog();
            this.Close();
            this.Hide();
        }

        private void To_ADD_newuser_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if(conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            display();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registration where Username = '" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            int i = 0;
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into Registration(FirstName,LastName,UserName, Password,Email,Contact) values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')";
                cmd1.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

                display();
                MessageBox.Show("User record inserted successfully");
            }
            else
            {
                MessageBox.Show("UserName already Exists. Please change username to make it unique.");

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void display()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registration";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id= Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "delete from Registration where id="+id+"";
            cmd2.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);

            display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
        }
    }
}
