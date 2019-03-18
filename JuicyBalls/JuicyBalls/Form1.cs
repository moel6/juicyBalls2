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

        private void btnSettingsPlayer1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
