using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsMVC.models;

namespace WinFormsMVC
{
    public partial class LoginForm : Form
    {  
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UserLoginParameters LoginParameters = new UserLoginParameters {
                Login = this.loginText.Text,
                Password = this.passwodText.Text
            };
            this.loginText.Text = "";
            this.passwodText.Text = "";
            Router.Run("user/login", LoginParameters);
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
