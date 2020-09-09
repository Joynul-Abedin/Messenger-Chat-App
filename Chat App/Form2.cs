using Repositories;
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
using Entities;
using Services;

namespace Chat_App
{
    public partial class Form2 : Form
    {
        public int userId = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                UserService sr = new UserService();

                if (emailSearchText.Text != null && emailSearchText.Text.Length > 0)
                {
                    /*DataAccess data = new DataAccess();
                    string sql = "Select * From Users where Email = '" + emailSearchText.Text + "'";
                    SqlDataReader reader = data.GetData(sql);
                    reader.Read();
                    int id = (int)reader["Id"];
                    this.userId = id;

                    data = new DataAccess();
                    string sql1 = "Select * From Login_Credentials where User_Id =" + id;
                    reader = data.GetData(sql1);
                    reader.Read();
                    int id1 = (int)reader["User_Id"];
                    */

                    int result = sr.searchByEmailAdd(emailSearchText.Text);
                    
                    ResetPassword rs = new ResetPassword();
                    this.Hide();
                    rs.Show();
                    rs.id = result;
                    
                }
                else
                {
                    MessageBox.Show("Type your Email.");
                }

               
        }
    }
}
