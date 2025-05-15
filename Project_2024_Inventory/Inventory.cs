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
    public partial class Inventory : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\C#_Project_2024\Project_2024_Inventory_KR\Project_2024_Inventory\SuryaAsha_canteen_Inventory.mdf;Integrated Security=True");

        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Product values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            /*int i = 0;
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = " insert into Registration values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                cmd1.ExecuteNonQuery();


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("User Record inserted succefully.");
            }
            else
            {
                MessageBox.Show("This user name has been already registered. Please enter a unique username.");
            }*/

            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
            //textBox1.Focus();


            listBox2.Items.Add(textBox2.Text);
            textBox2.Clear();
            //textBox2.Focus();

            listBox3.Items.Add(textBox3.Text);
            textBox3.Clear();
            //textBox4.Focus();

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();

            //button1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }

            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
            listBox3.Items.Remove(listBox3.SelectedItem);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            //textBox1.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }


            int index = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(index);
            listBox1.Items.Insert(index, textBox1.Text);
            textBox1.Clear();

            listBox3.Items.RemoveAt(index);
            listBox3.Items.Insert(index, textBox3.Text);
            textBox3.Clear();

            listBox2.Items.RemoveAt(index);
            listBox2.Items.Insert(index, textBox2.Text);
            textBox2.Clear();


        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Fill the name");
            }

            else
            {
                errorProvider1.Clear();
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider3.SetError(this.textBox2, "Please Fill the Units");
                button1.Enabled = false;
            }

            else if(textBox2.Text != string.Empty)
            {
                button1.Enabled = true;
            }

            else
            {
                errorProvider3.Clear();
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider2.SetError(this.textBox3, "Please Fill the Quntity");
            }
            else

            {
                errorProvider2.Clear();
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listBox2.SelectedIndex;
            if (index != -1)
            {
                textBox2.Text = listBox2.SelectedItem.ToString();
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listBox3.SelectedIndex;
            if (index != -1)
            {
                textBox3.Text = listBox3.SelectedItem.ToString();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
