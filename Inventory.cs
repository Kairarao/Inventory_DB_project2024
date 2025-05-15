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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_2024_Inventory
{
    public partial class Inventory : UserControl        
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-CMSSRQKS\SQLEXPRESS;Initial Catalog=canteen_inventory;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        static Inventory Form_obj;

        public static Inventory Instance
        {
            get
            {
                if (Form_obj == null)
                {

                    Form_obj = new Inventory();
                }
                return Form_obj;
            }
        }

        public Panel Inventory_panel
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        public Inventory()
        {
            InitializeComponent();
            

            
        }

        void FillCombo()
        {
            Name_textB.Items.Clear();
            //conn.Open();


            SqlCommand cmd = new SqlCommand();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select product_name from Purchased_db";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Name_textB.Items.Add(dr["product_name"].ToString());
               // Price_textB.Items.Add(dr["price"].ToString());
            }
            //conn.Close();

            //display();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Purchased_db (product_name, price, quantity, units) values('" + Name_textB.Text + "','" + Price_textB.Text + "','" + Quantuty_textB.Text + "','" + unit_textB.Text + "')";
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
            cmd.CommandText = "delete from Purchased_db where id=" + id + "";
            cmd.ExecuteNonQuery();
            
            display();
            Name_textB.Items.Clear();
            Price_textB.Items.Clear();
            Quantuty_textB.Items.Clear();
            unit_textB.Items.Clear();
            //textBox1.Focus();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           

           

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
                cmd.CommandText = "update Purchased_db set product_name = '" + Name_textB.Text + "', price='" + Price_textB.Text + "', quantity= '" + Quantuty_textB.Text + "', units= '" + unit_textB.Text + "' where id ='"+id+"'";
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

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }

        void AutoCompleteTB()
        {
            /*string[] units = { "Kgs", "Packets", "L", "ml", "Grams", "Bundels", "Liters", "Milliliters", textBox3.Text };
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteCustomSource.AddRange(units);*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            AutoCompleteTB();

            //this.WindowState = FormWindowState.Maximized;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            display();
            //fill_dd();
            FillCombo();

        }
        public void display()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Purchased_db order by id desc";
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
            cmd.CommandText = "select * from purchased_db";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Name_textB.Items.Add(dr["product_name"].ToString());
                Price_textB.Items.Add(dr["price"].ToString());
                Quantuty_textB.Items.Add(dr["quantity"].ToString());
                unit_textB.Items.Add(dr["units"].ToString());

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void listBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void sortBut_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from purchased_db order by product_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            display();

            
        }

        private void AddUnit_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Purchased_db(product_name, price, quantity) select count(case when try_cast(product_name as int) is null then product_name end) ,sum(case when try_cast(product_name as int) is null then price end), sum(case when try_cast(product_name as int) is null then quantity end) from Purchased_db ";
            //selection of data, 
            //count(), case statement=if statement, when clause= keyword for case, try_cast() = converts data into specified datatype, true=returns value, false returns null.
            cmd.ExecuteNonQuery();
            display();
        }

        private void Name_textB_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void Quantuty_textB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Price_textB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void unit_textB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void countBut_Click(object sender, EventArgs e)
        {

        }

        private void alpha_sort_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
        }
    }
}
