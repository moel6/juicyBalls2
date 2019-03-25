using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuicyBalls
{
    public partial class Form1 : Form
    {
        private Library.SerialMessenger serialMessenger;
        private Timer readMessageTimer;
        // TODO: Below fill in the actual Arduino COM port.
        private string port = "COM3";
        private int speed = 9600;

        public Form1()
        {
            InitializeComponent();

            //MessageBuilder messageBuilder = new MessageBuilder('#', '%');
            Library.MessageBuilder messageBuilder = new Library.MessageBuilder('\n');
            serialMessenger = new Library.SerialMessenger(port, speed, messageBuilder);

            readMessageTimer = new Timer();
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
    }
}

