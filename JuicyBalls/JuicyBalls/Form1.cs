using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace JuicyBalls
{
    public partial class Form1 : Form
    {
        DBClass dbclass = new DBClass();
        Account account = new Account();
        bool signin1 = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void signin(Button Used, TextBox Name, TextBox Password, GroupBox container, Button Settings)
        {
            if (signin1 == true)
            {
                Settings.Visible = false;
                container.BackColor = Color.Transparent;
                Used.BackColor = Color.Transparent;
                Used.Text = "Confirm";
                Name.Text = "";
                Password.Text = "";
                signin1 = false;
            }
            else
            {
                if (Name.Text == "Test" && Password.Text == "Test")
                {
                    container.BackColor = Color.Green;
                    Used.BackColor = Color.Red;
                    Used.Text = "Cancel";
                    Settings.Visible = true;
                    signin1 = true;
                }
            }

        }

        private void btnConfirmPlayer1_Click(object sender, EventArgs e)
        {
            signin(btnConfirmPlayer1, textBoxNamePlayer1, textBoxPasswordPlayer1, groupBox1, btnSettingsPlayer1);
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnSettingsPlayer1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            account.Username = textBoxRegisterName.Text;
            account.CheckedPassword = textBoxRegisterPassword.Text;
            account.PasswordEncryption();
            dbclass.CreateUser(account);

            //add mechanism to check if username or password are empty
            //add check if password and confirm password are equal
            //add checck if username + password are right.
        }
    }
}
