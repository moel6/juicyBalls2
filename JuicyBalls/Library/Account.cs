using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class Account
    {
        public bool WasPasswordCorrect;
        public bool IsLoggedIn;
        private int id;
        public List<string> accounts = new List<string>();

        private string DBPassword;

        public string dbpassword
        {
            get { return DBPassword; }
            set { DBPassword = value; }
        }


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string checkedpassword;

        public string CheckedPassword
        {
            get { return checkedpassword; }
            set { checkedpassword = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        private string passwordtocheck;

        public string PasswordToCheck
        {
            get { return passwordtocheck; }
            set { passwordtocheck = value; }
        }

        public Account(string passwordtocheck)
        {
            this.passwordtocheck = passwordtocheck;
        }


        public Account()
        {

        }

        public Account(bool wasPasswordCorrect, bool isLoggedIn, int id, string dbPassword, string username, string checkedpassword, string password, string passwordtocheck)
        {
            WasPasswordCorrect = wasPasswordCorrect;
            IsLoggedIn = isLoggedIn;
            this.id = id;
            DBPassword = dbPassword;
            this.username = username;
            this.checkedpassword = checkedpassword;
            this.password = password;
            this.passwordtocheck = passwordtocheck;
        }

        public void PasswordEncryption()
        {
            {
                // Create a SHA256 
                using (SHA256 sha256Hash = new SHA256Managed())
                {
                    // ComputeHash - returns byte array 
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(checkedpassword));

                    // Convert byte array to a string 
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    password = builder.ToString();
                }
            }
        }

        public void CheckHash(Account Account)
        {
            {
                // Create a SHA256 
                using (SHA256 sha256Hash = new SHA256Managed())
                {
                    // ComputeHash - returns byte array 
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(passwordtocheck));

                    // Convert byte array to a string 
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    passwordtocheck = builder.ToString();
                }
            }
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
