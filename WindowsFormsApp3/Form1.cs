using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public int buyPrice { get; set; }
            public int currentCurrency { get; set; }
            public int amount { get; set; }
        }

        LiteDatabase db = new LiteDatabase(@"MyData.db");

        public Form1()
        {
            InitializeComponent();
           
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //querying the db
            var users = db.GetCollection<User>("users");
            User loggedIn = users.FindOne(Query.And(
                Query.EQ("Login", login.Text.ToString()), 
                Query.EQ("Password", password.Text.ToString()
                )));

            
            if (loggedIn != null)
            {
                Menu_Form menu = new Menu_Form(loggedIn);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }
        }

        private void createAccountBtn_Click(object sender, EventArgs e)
        {   
            User newUser = new User { Login = login.Text.ToString(), Password = password.Text.ToString() };
        
            //creates a collection (like a table)
            var users = db.GetCollection<User>("users");
            // inserts the user in the table, Id is auto generated
            users.Insert(newUser);

            MessageBox.Show("Account sucesfully created");

        }
    }
}
