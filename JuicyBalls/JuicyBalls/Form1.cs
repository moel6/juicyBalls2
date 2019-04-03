using System;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace JuicyBalls
{
    public partial class Form1 : Form
    {
        private bool signin1 = false;
        private string password = "Test";
        private string name = "Test";
        bool darkmode = false;

        private Library.SerialMessenger serialMessenger;
        private System.Windows.Forms.Timer readMessageTimer;
        // TODO: Below fill in the actual Arduino COM port.
        private string port = "COM3";
        private int speed = 9600;
        Account account = new Account();
        DBClass dbclass = new DBClass();

        public Form1()
        {
            InitializeComponent();

            //Hides the tabcontrol headers
            tabControl1.Appearance = TabAppearance.FlatButtons; tabControl1.ItemSize = new Size(0, 1); tabControl1.SizeMode = TabSizeMode.Fixed;

            //MessageBuilder messageBuilder = new MessageBuilder('#', '%');
            Library.MessageBuilder messageBuilder = new Library.MessageBuilder('\n');
            serialMessenger = new Library.SerialMessenger(port, speed, messageBuilder);

            readMessageTimer = new System.Windows.Forms.Timer();
            readMessageTimer.Interval = 10;
            readMessageTimer.Tick += new EventHandler(ReadMessageTimer_Tick);
        }

        /*
        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                serialMessenger.Connect();
                readMessageTimer.Enabled = true;
                labelConnected.Text = "Connected to Arduino\n" + port;
                labelConnected.BackColor = Color.LightGreen;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        
        private void disconnecButton_Click(object sender, EventArgs e)
        {
            disconnect();
            labelConnected.Text = "not connected";
            labelConnected.BackColor = Color.Red;

        }
        */

        private void ReadMessageTimer_Tick(object sender, EventArgs e)
        {
            string[] messages = serialMessenger.ReadMessages();
            if (messages != null)
            {
                foreach (string message in messages)
                {
                    processReceivedMessage(message);
                }
            }
        }

        /// <summary>
        /// handle received messages
        /// </summary>
        /// <param name="message"></param>
        private void processReceivedMessage(string message)
        {
            // First trim whitespace characters like a trailing '\r'.
            // This is needed because the Arduino Serial.println adds \r\n.
            // '\n' will be removed because this is used as the message separation character,
            // but the '\r' must also be removed, otherwise comparing the message strings will not work.
            message = message.Trim();
            // Add message to the listBox.


            /*
            listBoxMessagesReceived.Items.Add(message);

            */


            // TODO: Below fill in your message handling.
            // The message handling below is only for illustration.
            if (message == "LED on")
            {
                MessageBox.Show(message);
            }
            else if (message == "LED off")
            {
                MessageBox.Show(message);
            }
        }

        private int getParamValue(string message)
        {
            int colonIndex = message.IndexOf(':');
            if (colonIndex != -1)
            {
                string param = message.Substring(colonIndex + 1);
                int value;
                bool done = int.TryParse(param, out value);
                if (done)
                {
                    return value;
                }
            }
            throw new ArgumentException("message contains no value parameter");
        }

        private void RemoteControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconnect();
        }

        private void disconnect()
        {
            try
            {
                readMessageTimer.Enabled = false;
                serialMessenger.Disconnect();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /*
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxMessagesReceived.Items.Clear();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            serialMessenger.SendMessage(textBoxSendMessage.Text);
        }
        */

        private void Form1_Load(object sender, EventArgs e)
        {

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
            account.Username = textBoxNamePlayer1.Text;
            account.PasswordToCheck = textBoxPasswordPlayer1.Text;
            account.CheckHash(account);
            dbclass.CheckPassword(account);
            if (account.PasswordToCheck != account.dbpassword)
            {
                MessageBox.Show("Password incorrect!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Welcome " + account.Username);
                textBoxPasswordPlayer1.Clear();
            }
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
            if (darkmode == false)
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
                groupBoxChangePassword.ForeColor = Color.White;

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

                //Tabpages
                tabPage1.BackColor = Color.DimGray;
                tabPage2.BackColor = Color.DimGray;
                tabPage3.BackColor = Color.DimGray;
                tabPage4.BackColor = Color.DimGray;

                //pictureboxes
                pictureBox1.BackColor = Color.DimGray;

                //Listboxes
                listBoxLog.BackColor = Color.DimGray;
                listBoxLog.ForeColor = Color.White;
                listBoxStats.BackColor = Color.DimGray;
                listBoxStats.ForeColor = Color.White;

                buttonDarkMode.Text = "Lightmode";
                buttonDarkMode2.Text = "Lightmode";
                buttonDarkMode3.Text = "Lightmode";
                buttonDarkMode4.Text = "Lightmode";

                //bool
                darkmode = true;
            }
            else if(darkmode == true)
            {
                //Buttons
                btnConfirmPlayer1.BackColor = Color.White;
                btnConfirmPlayer2.BackColor = Color.White;
                btnConfirmPlayer3.BackColor = Color.White;
                btnConfirmPlayer4.BackColor = Color.White;
                btnGoToRegister.BackColor = Color.White;
                btnGoToRegister.ForeColor = Color.Black;
                btnStartGame.BackColor = Color.White;
                btnStartGame.ForeColor = Color.Black;
                btnRefill1.BackColor = Color.White;
                btnRefill2.BackColor = Color.White;
                btnRefill3.BackColor = Color.White;
                btnRefill4.BackColor = Color.White;
                btnRefill5.BackColor = Color.White;
                btnGoToLogin.BackColor = Color.White;
                btnGoToLogin.ForeColor = Color.Black;
                buttonGoToLogin2.BackColor = Color.White;
                buttonGoToLogin2.ForeColor = Color.Black;
                buttonChangePassword.BackColor = Color.White;
                buttonChangePassword.ForeColor = Color.Black;
                btnRegisterAccount.BackColor = Color.White;
                btnRegisterAccount.ForeColor = Color.Black;
                buttonCloseChangePassword.BackColor = Color.White;
                buttonOpenChangePassword.BackColor = Color.White;
                buttonOpenChangePassword.ForeColor = Color.Black;

                //Groupboxes
                groupBox1.BackColor = Color.White;
                groupBox1.ForeColor = Color.Black;
                groupBox2.BackColor = Color.White;
                groupBox2.ForeColor = Color.Black;
                groupBox3.BackColor = Color.White;
                groupBox3.ForeColor = Color.Black;
                groupBox4.BackColor = Color.White;
                groupBox4.ForeColor = Color.Black;
                groupBox5.BackColor = Color.White;
                groupBox5.ForeColor = Color.Black;
                groupBox6.BackColor = Color.White;
                groupBox6.ForeColor = Color.Black;
                groupBox7.BackColor = Color.White;
                groupBox7.ForeColor = Color.Black;
                groupBox8.BackColor = Color.White;
                groupBox8.ForeColor = Color.Black;
                groupBox9.BackColor = Color.White;
                groupBox9.ForeColor = Color.Black;
                groupBox10.BackColor = Color.White;
                groupBox10.ForeColor = Color.Black;
                groupBoxChangeName.BackColor = Color.White;
                groupBoxChangePassword.BackColor = Color.White;
                groupBoxChangePassword.ForeColor = Color.Black;

                //TextBoxes
                textBoxNamePlayer1.BackColor = Color.White;
                textBoxNamePlayer2.BackColor = Color.White;
                textBoxNamePlayer3.BackColor = Color.White;
                textBoxNamePlayer4.BackColor = Color.White;
                textBoxPasswordPlayer1.BackColor = Color.White;
                textBoxPasswordPlayer2.BackColor = Color.White;
                textBoxPasswordPlayer3.BackColor = Color.White;
                textBoxPasswordPlayer4.BackColor = Color.White;
                textBoxRegisterName.BackColor = Color.White;
                textBoxRegisterPassword.BackColor = Color.White;
                textBoxConfirmPassword.BackColor = Color.White;
                textBoxOldPassword.BackColor = Color.White;
                textBoxNewPassword.BackColor = Color.White;
                textBoxConfirmNewPassword.BackColor = Color.White;

                //Tabpages
                tabPage1.BackColor = Color.White;
                tabPage2.BackColor = Color.White;
                tabPage3.BackColor = Color.White;
                tabPage4.BackColor = Color.White;

                //pictureboxes
                pictureBox1.BackColor = Color.White;

                //Listboxes
                listBoxLog.BackColor = Color.White;
                listBoxLog.ForeColor = Color.Black;
                listBoxStats.BackColor = Color.White;
                listBoxStats.ForeColor = Color.Black;

                buttonDarkMode.Text = "Darkmode";
                buttonDarkMode2.Text = "Darkmode";
                buttonDarkMode3.Text = "Darkmode";
                buttonDarkMode4.Text = "Darkmode";

                //bool
                darkmode = false;
            }
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            if (textBoxRegisterPassword.Text == textBoxConfirmPassword.Text)
            {
                account.Username = textBoxRegisterName.Text;
                dbclass.CheckExistingUsers(account);
                if (!account.accounts.Contains(account.Username))
                {
                    account.CheckedPassword = textBoxRegisterPassword.Text;
                    account.PasswordEncryption();
                    dbclass.CreateUser(account);
                }
                else
                {
                    MessageBox.Show("Username already taken!", "Error", MessageBoxButtons.OK);
                    return;
                }

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBoxJumpScare_MouseLeave(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://cdn.discordapp.com/attachments/537810314167844865/561344507807793153/image0.jpg");
        }

        private void btnConfirmPlayer2_Click(object sender, EventArgs e)
        {
            account.Username = textBoxNamePlayer2.Text;
            account.PasswordToCheck = textBoxPasswordPlayer2.Text;
            account.CheckHash(account);
            dbclass.CheckPassword(account);
            if (account.PasswordToCheck != account.dbpassword)
            {
                MessageBox.Show("Password incorrect!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Welcome " + account.Username);
                textBoxPasswordPlayer2.Clear();
            }
        }

        private void btnConfirmPlayer3_Click(object sender, EventArgs e)
        {
            account.Username = textBoxNamePlayer3.Text;
            account.PasswordToCheck = textBoxPasswordPlayer3.Text;
            account.CheckHash(account);
            dbclass.CheckPassword(account);
            if (account.PasswordToCheck != account.dbpassword)
            {
                MessageBox.Show("Password incorrect!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Welcome " + account.Username);
                textBoxPasswordPlayer3.Clear();
            }
        }

        private void btnConfirmPlayer4_Click(object sender, EventArgs e)
        {
            account.Username = textBoxNamePlayer4.Text;
            account.PasswordToCheck = textBoxPasswordPlayer4.Text;
            account.CheckHash(account);
            dbclass.CheckPassword(account);
            if (account.PasswordToCheck != account.dbpassword)
            {
                MessageBox.Show("Password incorrect!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                MessageBox.Show("Welcome " + account.Username);
                textBoxPasswordPlayer4.Clear();
            }
        }
    }
}


