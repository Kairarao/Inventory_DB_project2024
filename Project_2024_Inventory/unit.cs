using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Project_2024_Inventory
{
    public partial class unit : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\C#_Project_2024\Project_2024_Inventory\Project_2024_Inventory\SuryaAsha_canteen_Inventory.mdf;Integrated Security=True");
        public unit()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from units where units='" + textBox1.Text+ "' ";
            cmd1.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            int count = 0;
            count = Convert.ToInt32(dt1.Rows.Count.ToString());

            if (count == 0)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO units values('" + textBox1.Text + "')";
                cmd.ExecuteNonQuery();


                dispaly();
            }
            else
            {
                MessageBox.Show("This unit already exists.");
            }
        }

        private void unit_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {

            con.Close(); 
            }
            con.Open();
            dispaly();
        }

        public void dispaly()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from units";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id=Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from units where id ="+id+"";
            cmd.ExecuteNonQuery();
            dispaly();
        }
    }
}
