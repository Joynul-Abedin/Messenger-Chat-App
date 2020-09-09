using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_App
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((fNameText.Text != null && fNameText.Text.Length > 0)
                && (lNameText.Text != null && lNameText.Text.Length > 0)
                && (emailText.Text != null && emailText.Text.Length > 0)
                && (dobPicker.Text != null && dobPicker.Text.Length > 0)
                && (phoneText.Text != null && phoneText.Text.Length > 0)
                && (regionComboText.Text != null && regionComboText.Text.Length > 0)
                && (stateComboText.Text != null && stateComboText.Text.Length > 0)
                && (religionComboText.Text != null && religionComboText.Text.Length > 0)
                && (userNameText.Text != null && userNameText.Text.Length > 0)
                && (passText.Text != null && passText.Text.Length > 0)
                && (confPassTextBox.Text != null && confPassTextBox.Text.Length>0))
            {
                RegistrationService reg = new RegistrationService();
                var count = reg.UserRegistration(fNameText.Text, lNameText.Text, emailText.Text, dobPicker.Text, phoneText.Text, regionComboText.Text, stateComboText.Text, religionComboText.Text, userNameText.Text, passText.Text);
                if (count == 1)
                {
                    string message = "Do you want to login?";
                    string title = "Welcome to Chat App!!";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        Form4 f4 = new Form4();
                        this.Hide();
                        f4.Show();
                    }

                }
                else
                {
                    DataAccess data = new DataAccess();
                    //string sql = "SELECT Email FROM Chat App WHERE TABLE_NAME = 'Users'";

                    MessageBox.Show("Invalid Registration!");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All the Fields`");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
