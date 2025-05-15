using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Project_2024_Inventory
{
    public partial class Product_sales : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-CMSSRQKS\SQLEXPRESS;Initial Catalog=canteen_inventory;Integrated Security=True;Encrypt=True;TrustServerCertificate=True; MultipleActiveResultSets=true");

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
        void FillCombo()
        {
            Name_textB.Items.Clear();
            //conn.Open();


            SqlCommand cmd = new SqlCommand();
                cmd=conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select product_name from Fill_Combo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows) { 
                Name_textB.Items.Add(dr["product_name"].ToString());
                //Price_textB.Items.Add(dr["price"].ToString());
               
            }
            //conn.Close();

            //display();
        }
        public Panel Product_sales_panel
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        public Product_sales()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_butt_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Product_sales (product_name, price, quantity, units) values('" + Name_textB.Text + "','" + Price_textB.Text + "','" + Quantuty_textB.Text + "','" + unit_textB.Text + "')";
            cmd.ExecuteNonQuery();


            Name_textB.Text = "";
            Price_textB.Text = "";
            Quantuty_textB.Text = "";
            unit_textB.Text = "";

            FillCombo();
            display();
        }

        private void ClearBut_Click(object sender, EventArgs e)
        {

            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Product_sales where id=" + id + "";
            cmd.ExecuteNonQuery();

            display();
            Name_textB.Items.Clear();
            Price_textB.Items.Clear();
            Quantuty_textB.Items.Clear();
            unit_textB.Items.Clear();

            FillCombo();
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
                cmd.CommandText = "update Product_sales set product_name = '" + Name_textB.Text + "', price='" + Price_textB.Text + "', quantity= '" + Quantuty_textB.Text + "', units= '" + unit_textB.Text + "' where id ='"+id+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                Name_textB.ResetText();
                Price_textB.ResetText();
                Quantuty_textB.ResetText();
                unit_textB.ResetText();
                display();
                FillCombo();


            }
        }

        private void Product_sales_Load(object sender, EventArgs e)
        {

            

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
            cmd.CommandText = "select * from Product_sales";
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
            cmd.CommandText = "select * from Product_sales";
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

        private void sortBut_Click(object sender, EventArgs e)
        {
            display();
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product_sales order by product_name desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            FillCombo();
        }

        private void Name_textB_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Price_textB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into product_sales(product_name, price, quantity,units) select count(case when try_cast(product_name as int) is null then product_name end) ,sum(case when try_cast(product_name as int) is null then price end), sum(case when try_cast(product_name as int) is null then quantity end),sum(case when try_cast(product_name as int) is null then units end) from product_sales ";
               cmd.ExecuteNonQuery();
            display();
            FillCombo();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Name_textB_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlCommand cmd;
            string sql;

            string Pname = Name_textB.Text;

            sql = "select * from Fill_Combo where product_name = @Pname";


            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Pname", Pname);
            SqlDataReader dr;

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Price_textB.Text = dr["product_price"].ToString();
            }

            else
            {

            }
        }
    }
}
//selection of data, 
//count(), case statement=if statement, when clause= keyword for case, try_cast() = converts data into specified datatype, true=returns value, false returns null.
