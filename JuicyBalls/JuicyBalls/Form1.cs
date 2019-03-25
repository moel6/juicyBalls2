﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace JuicyBalls
{
    public partial class Form1 : Form
    {
        private bool signin1 = false;
        private string password = "Test";
        private string name = "Test";


      

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
            if (textBoxOldPassword.Text == password && textBoxConfirmNewPassword.Text == textBoxNewPassword.Text)
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
        }

        private void buttonCloseChangePassword_Click(object sender, EventArgs e)
        {
            groupBoxChangePassword.Visible = false;
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
            //Buttons
            btnConfirmPlayer1.BackColor = Color.DimGray;
    
            btnConfirmPlayer2.BackColor = Color.DimGray;
            
            btnConfirmPlayer3.BackColor = Color.DimGray;
            
            btnConfirmPlayer4.BackColor = Color.DimGray;
            
            btnGoToRegister.BackColor = Color.DimGray;
            btnGoToRegister.ForeColor = Color.White;
            btnStartGame.BackColor = Color.DimGray;
            btnStartGame.ForeColor = Color.White;
            btnRefill1.BackColor = Color.DimGray;
            btnRefill2.BackColor = Color.DimGray;
            btnRefill3.BackColor = Color.DimGray;
            btnRefill4.BackColor = Color.DimGray;
            btnRefill5.BackColor = Color.DimGray;
            btnGoToLogin.BackColor = Color.DimGray;
            btnGoToLogin.ForeColor = Color.White;
            buttonGoToLogin2.BackColor = Color.DimGray;
            buttonGoToLogin2.ForeColor = Color.White;
            buttonChangePassword.BackColor = Color.DimGray;
            buttonChangePassword.ForeColor = Color.White;
            btnRegisterAccount.BackColor = Color.DimGray;
            btnRegisterAccount.ForeColor = Color.White;
            buttonCloseChangePassword.BackColor = Color.DimGray;
            buttonOpenChangePassword.BackColor = Color.DimGray;
            buttonOpenChangePassword.ForeColor = Color.White;
            

            //Groupboxes
            groupBox1.BackColor = Color.DimGray;
            groupBox1.ForeColor = Color.White;
            groupBox2.BackColor = Color.DimGray;
            groupBox2.ForeColor = Color.White;
            groupBox3.BackColor = Color.DimGray;
            groupBox3.ForeColor = Color.White;
            groupBox4.BackColor = Color.DimGray;
            groupBox4.ForeColor = Color.White;
            groupBox5.BackColor = Color.DimGray;
            groupBox5.ForeColor = Color.White;
            groupBox6.BackColor = Color.DimGray;
            groupBox6.ForeColor = Color.White;
            groupBox7.BackColor = Color.DimGray;
            groupBox7.ForeColor = Color.White;
            groupBox8.BackColor = Color.DimGray;
            groupBox8.ForeColor = Color.White;
            groupBox9.BackColor = Color.DimGray;
            groupBox9.ForeColor = Color.White;
            groupBox10.BackColor = Color.DimGray;
            groupBox10.ForeColor = Color.White;
            groupBoxChangeName.BackColor = Color.DimGray;
            groupBoxChangePassword.BackColor = Color.DimGray;

            //TextBoxes
            textBoxNamePlayer1.BackColor = Color.LightGray;
            textBoxNamePlayer2.BackColor = Color.LightGray;
            textBoxNamePlayer3.BackColor = Color.LightGray;
            textBoxNamePlayer4.BackColor = Color.LightGray;
            textBoxPasswordPlayer1.BackColor = Color.LightGray;
            textBoxPasswordPlayer2.BackColor = Color.LightGray;
            textBoxPasswordPlayer3.BackColor = Color.LightGray;
            textBoxPasswordPlayer4.BackColor = Color.LightGray;
            textBoxRegisterName.BackColor = Color.LightGray;
            textBoxRegisterPassword.BackColor = Color.LightGray;
            textBoxConfirmPassword.BackColor = Color.LightGray;
            textBoxOldPassword.BackColor = Color.LightGray;
            textBoxNewPassword.BackColor = Color.LightGray;
            textBoxConfirmNewPassword.BackColor = Color.LightGray;


            //pictureboxes
            pictureBox1.BackColor = Color.DimGray;

            //Listboxes
            listBoxLog.BackColor = Color.DimGray;
            //listBoxStats.BackColor = Color.DimGray;
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}