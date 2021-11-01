using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;//imported

namespace FinalTermProject
{
    public partial class LoginForm : Form
    {

        int xLast, yLast;
        bool mouseDown;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ButtonClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimiseButton(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //@ or //(double slash)
            var strCon = ConfigurationManager.ConnectionStrings["FinalTermProject.Properties.Settings.ConnectionString"].ToString();
            LinqLoginDataContext query = new LinqLoginDataContext(strCon);
            {
                var x = from login in query.Logins
                        where login.Username == textBox_username.Text && login.Password == textBox_pass.Text
                        select login;

                if (x.Any())
                {
                    
                    Home h1 = new Home();
                    this.Hide();
                    h1.Show();
                }
                else
                {
                    labelMessage.Visible = true;
                    labelMessage.Text = "Invalid Username/Password. Try again.";
                   
                    //delete this
                    //Home h1 = new Home();
                    //this.Hide();
                    //h1.Show();
                }

            }

        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int newX = this.Left + (e.X - xLast);
                int newY = this.Top + (e.Y - yLast);
                this.Location = new Point(newX, newY);
            }
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;

            xLast = e.X;
            yLast = e.Y;
        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This section is not currently available!");
        }

        private void TextBox_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                LoginButton_Click(sender, e);
        }

    }
}