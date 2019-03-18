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

        bool signin1 = false;
        string password = "Test";
        string name = "Test";
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
                if (Name.Text == name && Password.Text == password)
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
        private void buttonGoToLogin2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnSettingsPlayer1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void buttonChangeName_Click(object sender, EventArgs e)
        {
            name = textBoxNewName.Text;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if(textBoxOldPassword.Text == password && textBoxConfirmNewPassword.Text == textBoxNewPassword.Text)
            {
                password = textBoxNewPassword.Text;
                MessageBox.Show("Changed Password");
            }
        }

        private void buttonOpenChangeName_Click(object sender, EventArgs e)
        {
            groupBoxChangeName.Visible = true;
            labelNewName.Visible = true;
            textBoxNewName.Visible = true;
            buttonChangeName.Visible = true;
            buttonCloseChangeName.Visible = true;
            buttonOpenChangeName.Visible = false;
            buttonOpenChangePassword.Visible = false;
        }

        private void buttonCloseChangeName_Click(object sender, EventArgs e)
        {
            groupBoxChangeName.Visible = false;
            labelNewName.Visible = false;
            textBoxNewName.Visible = false;
            buttonChangeName.Visible = false;
            buttonCloseChangeName.Visible = false;
            buttonOpenChangeName.Visible = true;
            buttonOpenChangePassword.Visible = true;

        }

        private void buttonOpenChangePassword_Click(object sender, EventArgs e)
        {
            groupBoxChangePassword.Visible = true;
            textBoxOldPassword.Visible = true;
            textBoxNewPassword.Visible = true;
            textBoxConfirmNewPassword.Visible = true;
            labelOldPassword.Visible = true;
            labelNewPassword.Visible = true;
            labelConfirmNewPassword.Visible = true;
            buttonChangePassword.Visible = true;
            buttonCloseChangePassword.Visible = true;
        }

        private void buttonCloseChangePassword_Click(object sender, EventArgs e)
        {
            groupBoxChangePassword.Visible = false;
            textBoxOldPassword.Visible = false;
            textBoxNewPassword.Visible = false;
            textBoxConfirmNewPassword.Visible = false;
            labelOldPassword.Visible = false;
            labelNewPassword.Visible = false;
            labelConfirmNewPassword.Visible = false;
            buttonChangePassword.Visible = false;
            buttonCloseChangePassword.Visible = false;
            buttonOpenChangePassword.Visible = true;
        }
    }
}
