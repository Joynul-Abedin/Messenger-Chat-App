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
using Services;
using Repositories;
using System.Threading;

namespace Chat_App
{
    public partial class Form7 : Form
    {
        DataAccess instance = DataAccess.Instance;
        private static int? User1, User2;
        

        
        public Form7()
        {
            InitializeComponent();
            nameLable.Text = Form5.Name;
            this.AcceptButton = sendButton;
            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            this.Hide();
            f8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            this.Hide();
            f9.Show();
        }

        SqlConnection connect = new SqlConnection("Data Source=ZARIF-PC\\SQLEXPRESS;Initial Catalog=ChatDataBase;Integrated Security=True");

        public void ShowData()
        {
            Thread childThread = new Thread(
                delegate() 
                {
                    try
                    {
                        while (true)
                        {
                            
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() => 
                                {
                                    User2 = Form5.Selected;
                                    string query = "Select * from Login_Credentials where User_Name = '" + Form4.CurrentLog + "'";
                                    SqlDataReader reader = instance.ReadSqlData(query);
                                    if (reader != null && reader.Read())
                                        User1 = (int)reader["Id"];
                                    instance.CloseConnection();

                                    query = "SELECT Text from Messages where Sender_Id = " + User1;
                                    reader = instance.ReadSqlData(query);
                                    List<Message> chatMessages = new List<Message>();
                                    while (reader != null && reader.Read())
                                    {
                                        chatMessages.Add(new Message() { Text = reader["Text"].ToString() });
                                    }
                                    instance.CloseConnection();

                                    dataGridView1.DataSource = chatMessages;


                                    query = "SELECT Text from Messages where Sender_Id = " + User2;
                                    reader = instance.ReadSqlData(query);
                                    chatMessages = new List<Message>();
                                    while (reader != null && reader.Read())
                                    {
                                        chatMessages.Add(new Message() { Text = reader["Text"].ToString() });
                                    }
                                    instance.CloseConnection();
                                    dataGridView2.DataSource = chatMessages;
                                   
                                }));
                            }

                            Thread.Sleep(2000);

                        }
                        
                    }
                    catch { }
                });
            childThread.Start();


        }
        private void backButton_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                User2 = Form5.Selected;
                //"Insert into Messages (User1, User2, Chat_Line) values('" + User1 + "', '" + User2 + "', '" + textFieldBox.Text + "')";
                if (textFieldBox.Text != null && textFieldBox.Text.Length > 0)
                {
                    string query = null;
                    query = "SELECT Id from Chats_Table where (User1 = " + User1 + " and User2 = " + User2 + ") or (User1 =" + User2 + " and User2 = " + User1 + ")";


                    SqlDataReader data = instance.ReadSqlData(query);
                    Console.WriteLine("hi");
                    int? chatId = null;
                    if (data.Read()) chatId = (int)data["Id"];
                    instance.CloseConnection();

                    if (chatId == null)
                    {
                        query = "INSERT INTO Chats_Table (User1, User2) Output Inserted.Id values (" + User1 + "," + User2 + ")";
                        chatId = int.Parse(instance.ExecuteSqlScalar(query));
                        instance.CloseConnection();

                    }
                    query = "INSERT INTO Messages (Sender_Id, Chat_Id, Text) values (" + User1 + "," + chatId + ", '" + textFieldBox.Text + "')";
                    int? success = instance.ExecuteSqlQuery(query);

                    instance.CloseConnection();
                    textFieldBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Fill the text field first.");
                }
            }
            catch(Exception x) { MessageBox.Show(x.Message); }
        }
    }
}
