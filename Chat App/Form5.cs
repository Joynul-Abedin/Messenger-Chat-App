using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Repositories;
using Services;
using Entities;

namespace Chat_App
{
    public partial class Form5 : Form
    {
        DataAccess instance = DataAccess.Instance;
        public static int Selected;
        public static int  Id=0;
        public static string Name;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "Select * from Login_Credentials where User_Name = '" + Form4.CurrentLog + "'";
                SqlDataReader reader = instance.ReadSqlData(query);
                if (reader != null && reader.Read())
                    Id = (int)reader["User_Id"];
                instance.CloseConnection();

                List<User> userList = new List<User>();
                string query1 = "Select * from Users Where Id = (Select User2 from Chats_Table where Id= (select Chat_Id from Messages where Sender_Id = "+Id+" ))";
                reader = instance.ReadSqlData(query1);
                
                if (reader != null && reader.Read())
                {
                    System.Console.WriteLine("Hi");
                    User user = new User()
                    {
                        FirstName = reader["First_Name"].ToString()
                    };
                    userList.Add(user);
                }

                dataGridView1.DataSource = userList;
            }
            catch { }


             dataGridView1_CellClick(null , null);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string message = "Do you want to logout?";
            string title = "Welcome to Chat App!!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.No)
            {
                this.Show();
            }
            else
            {
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
                Form4.CurrentLog = "";
                
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        SqlConnection connect = new SqlConnection("Data Source=.\\SHOKAL1;Initial Catalog=Chat App;Integrated Security=True");
        
        private void searchButton_Click(object sender, EventArgs e)
        {
            string query1 = "Select First_Name from Users where First_Name='" +searchFriend.Text+ "'";

            SqlCommand data = new SqlCommand(query1, connect);


            connect.Open();

            data.ExecuteNonQuery();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(data);

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            connect.Close();

        }

        private void friendsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                string query = "Select * from Users where First_Name='" + name + "'";

                DataAccess data = new DataAccess();

                SqlDataReader reader = data.ReadSqlData(query);

                List<User> userList = new List<User>();

                int? id = null;
                if (reader.Read())
                {
                    id = (int)reader["Id"];
                    User user = new User()
                    {
                        Id = (int)id,
                        FirstName = reader["First_Name"].ToString(),
                        LastName = reader["Last_Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        DOB = reader["DOB"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Region = reader["Region"].ToString(),
                        State = reader["State"].ToString(),
                        Religion = reader["Religion"].ToString(),
                        Password = "Confidential"
                    };
                    userList.Add(user);
                }

                Selected = (int)id;
                Name = name;

                dataGridView2.DataSource = userList;
            }
            catch { }

        }

        //SELECT * FROM USERS 

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
