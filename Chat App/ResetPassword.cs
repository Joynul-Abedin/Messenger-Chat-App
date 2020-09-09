using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Services;
namespace Chat_App
{
    public partial class ResetPassword : Form
    {
        public int id = 0;
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != null && textBox1.Text.Length > 0)
                && (textBox2.Text != null && textBox2.Text.Length > 0))
            {
                if (textBox1.Text == textBox2.Text)
                {

                    User user = new User();
                    UserService sr = new UserService();

                    user.Id = id;
                    user.Password = textBox1.Text;

                    int? result = sr.UpdatePassword(user);

                    /*DataAccess data = new DataAccess();
                    ResetPassword rs = new ResetPassword();
                    Form2 f2 = new Form2();
                    User user = new User();

                    string sql = "Update Login_Credentials Set Password='"+textBox1.Text+"' where User_Id="+user.Id;*/

                    if (result > 0)
                    {
                        Form4 f4 = new Form4();
                        this.Hide();
                        f4.Show();
                    }
                    else 
                    {
                        MessageBox.Show("Unkonwn Error");
                    }
                }
                else
                {
                    MessageBox.Show("Password Does Not Match");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All the Fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }
    }
}
