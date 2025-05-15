using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2024_Inventory
{
    public partial class Indirect_expences : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-CMSSRQKS\SQLEXPRESS;Initial Catalog=canteen_inventory;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        static Indirect_expences Form_obj;

        public static Indirect_expences Instance
        {
            get
            {
                if (Form_obj == null)
                {

                    Form_obj = new Indirect_expences();
                }
                return Form_obj;
            }
        }

        public Panel Indirect_ex_panel
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        public Indirect_expences()
        {
            InitializeComponent();
        }

        private void Add_butt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into p_and_l (expence_name, ex_amount, income_name, in_amount) values('" + Name_textB.Text + "','" + Price_textB.Text + "','" + Quantuty_textB.Text + "','" + unit_textB.Text + "')";
            cmd.ExecuteNonQuery();


            Name_textB.Text = "";
            Price_textB.Text = "";
            Quantuty_textB.Text = "";
            unit_textB.Text = "";

            display();

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();

            //button1.Enabled = true;


        }

        private void ClearBut_Click(object sender, EventArgs e)
        {

            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from p_and_l where id=" + id + "";
            cmd.ExecuteNonQuery();

            display();
            Name_textB.Items.Clear();
            Price_textB.Items.Clear();
            Quantuty_textB.Items.Clear();
            unit_textB.Items.Clear();
            //textBox1.Focus();
        }

        private void UpdateBut_Click(object sender, EventArgs e)
        {

            if (Name_textB.Text == "" && Price_textB.Text == "" && Quantuty_textB.Text == "" && unit_textB.Text == "")
            {
                Name_textB.Text = dataGridView1.SelectedCells[1].Value.ToString();
                Price_textB.Text = dataGridView1.SelectedCells[2].Value.ToString();
                Quantuty_textB.Text = dataGridView1.SelectedCells[3].Value.ToString();
                unit_textB.Text = dataGridView1.SelectedCells[4].Value.ToString();
            }
            else
            {
                int id;
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update p_and_l set expence_name = '" + Name_textB.Text + "', ex_amount='" + Price_textB.Text + "', income_name= '" + Quantuty_textB.Text + "', in_amount= '" + unit_textB.Text + "' where id ='" + id + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                Name_textB.ResetText();
                Price_textB.ResetText();
                Quantuty_textB.ResetText();
                unit_textB.ResetText();


                display();
            }
        }

        private void sortBut_Click(object sender, EventArgs e)
        {

            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from p_and_l order by expence_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            display();
        }

        private void alpha_sort_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into p_and_l(expence_name, ex_amount, income_name, in_amount) select count(case when try_cast(expence_name as int) is null then expence_name end) ,sum(case when try_cast(expence_name as int) is null then ex_amount end), count(case when try_cast(income_name as int) is null then income_name end) ,sum(case when try_cast(income_name as int) is null then in_amount end) from p_and_l ";
            //selection of data, 
            //count(), case statement=if statement, when clause= keyword for case, try_cast() = converts data into specified datatype, true=returns value, false returns null.
            cmd.ExecuteNonQuery();
            display();
        }

        private void Indirect_expences_Load(object sender, EventArgs e)
        {


            //this.WindowState = FormWindowState.Maximized;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            display();
            fill_dd();
            

        }
        public void display()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from p_and_l order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void fill_dd()
        {
            Name_textB.Items.Clear();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from p_and_l";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Name_textB.Items.Add(dr["expence_name"].ToString());
                Price_textB.Items.Add(dr["ex_amount"].ToString());
                Quantuty_textB.Items.Add(dr["income_name"].ToString());
                unit_textB.Items.Add(dr["in_amount"].ToString());

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
