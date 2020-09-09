using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace Chat_App
{

    public partial class Form4 : Form
    {
        public static string CurrentLog;
        

        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((logInUserText.Text != null && logInUserText.Text.Length>0) && (loginPassText.Text != null && loginPassText.Text.Length>0))
            {

                LogInService log = new LogInService();
                int result = log.LoginValidation(logInUserText.Text, loginPassText.Text);

                if (result == 1)
                {
                    MessageBox.Show("Welcome " + logInUserText.Text);
                    CurrentLog = logInUserText.Text;
                    Form5 f5 = new Form5();
                    this.Hide();
                    f5.Show();
                }
                else
                {
                    MessageBox.Show("Invalid User.");
                }
            }
            else
            {
                MessageBox.Show("Please Fill all field.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
