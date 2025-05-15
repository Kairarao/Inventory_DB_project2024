using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2024_Inventory
{
    public partial class Home_page : Form
    {
        static Home_page Form_obj;

        public static Home_page Instance
        {
            get
            {
                if (Form_obj == null)
                { 
                
                Form_obj = new Home_page(); 
                }
                return Form_obj;
            }
        }

        public Panel Home_page_panel
        {
            get { return Main_panel; }
            set { Main_panel = value; }
        }

        public Button BackButton
        {
            get { return Back_button; }
            set { Back_button = value; }

        }
        public Home_page()
        {
            InitializeComponent();
        }

        private void Home_page_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            button4.Visible = false;
            Back_button.Visible = false;
            Form_obj = this;

            Banner uc = new Banner();
            uc.Dock = DockStyle.Fill;
            Home_page_panel.Controls.Add(uc);
        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            Home_page_panel.Controls["Banner"].BringToFront();
            
            Back_button.Visible = false;
            button4.Visible = false; 

        }

        private void I_m_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            if (!Home_page.Instance.Home_page_panel.Controls.ContainsKey("Inventory"))
            {
                Inventory un = new Inventory();
                un.TopLevel=false;
                un.AutoScroll = true;
                un.Dock = DockStyle.Fill;

                Home_page.Instance.Home_page_panel.Controls.Add(un);
                un.Show();
               
            }
            Home_page.Instance.Home_page_panel.Controls["Inventory"].BringToFront();
            Home_page.Instance.BackButton.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (!Home_page.Instance.Home_page_panel.Controls.ContainsKey("unit"))
            {
                unit u = new unit();
                u.TopLevel = false;
                u.AutoScroll = true;
                u.Dock = DockStyle.Fill;

                Home_page.Instance.Home_page_panel.Controls.Add(u);
                u.Show();
            }
            Home_page.Instance.Home_page_panel.Controls["unit"].BringToFront();
            Home_page.Instance.BackButton.Visible = true;
        }
    }
}
