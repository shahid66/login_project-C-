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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void registerBTN_Click(object sender, EventArgs e)
        {
            string userName = userText.Text;
            string userPass = userPassword.Text;

            

            
            string connectionString = "Data Source=DESKTOP-Q2QFTAN;Initial Catalog=login_DB;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionString);
            string query = "INSERT INTO registration_tb (user_name,user_password) values('"+userName+"','"+userPass+"') ";
            SqlCommand comand = new SqlCommand(query, connect);
            connect.Open();
            int rowAffected = comand.ExecuteNonQuery();
            connect.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("Register Successufull");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
