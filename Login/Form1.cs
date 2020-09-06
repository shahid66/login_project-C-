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

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
        }

        private void logInBTN_Click(object sender, EventArgs e)
        {
            string userName = userTextBox.Text;
            string userPassword = passwordTextBox.Text;

            string connectionString = "Data Source=DESKTOP-Q2QFTAN;Initial Catalog=login_DB;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            string query = "SELECT * FROM registration_tb where user_name='" + userName + "'and user_password='" + userPassword + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query,connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);

           
            
            if (dt.Rows.Count==1)
            {
                this.Hide();
                Form3 f3 = new Form3(userTextBox.Text);
                f3.ShowDialog();
                f3.Close();

            }
            else
            {
                MessageBox.Show("Login faield");
            }
        }

        private void registerBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            f2.Close();
        }
    }
}
