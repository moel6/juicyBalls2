using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Mime;
using Library;
using Microsoft.SqlServer.Server;

namespace Library
{
    public class DBClass
    {
        #region publicaccess

        private SqlConnection connection;

        private string connectionString =
            @"Data Source=mssql.fhict.local;Initial Catalog = dbi389783; User ID = dbi389783; Password=Welkom01";
        #endregion

        #region publicconnectionstring
        public SqlConnection GetConnection()
        {
            connection = new SqlConnection(connectionString);
            return connection;
        }
        #endregion

        #region Account Methods

        public void CreateUser(Account account)
        {
            string query = "INSERT INTO [Accounts] (Username, Password) VALUES(@Username, @password)";

            using (GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.ExecuteScalar();
            }
        }

        public void CheckPassword(Account account)
        {
            string username = account.Username;
            string password = account.PasswordToCheck;
            string query = "SELECT Password FROM Accounts WHERE Username = " + "@Username";

            using (GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", account.Username);
                SqlDataReader myReader = command.ExecuteReader();
                myReader.Read();
                account.dbpassword = myReader.GetString(0);
            }
        }

        public void CheckExistingUsers(Account account)
        {
            string query = "SELECT Username FROM Accounts";

            using (GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader myReader = command.ExecuteReader();
                command.Parameters.AddWithValue(account.Username, "@Username");
                string test;

                while (myReader.Read())
                {
                    test = myReader.GetString(0);
                    account.accounts.Add(test.ToString());
                }
            }
        }

        public void DeleteUser(Account account)
        {
            string query = "DELETE FROM Accounts where @Username = " + account.Username;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", account.Username);
        }

        public void SaveChanges()
        {

        }

        #endregion

        #region movie methods

        public void GetAllAccounts(Account account)
        {
            string query = "SELECT * FROM Accounts";

            using (GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader myReader = command.ExecuteReader();
                command.Parameters.AddWithValue(account.Username, "@Username");
               

                string test;

                while (myReader.Read())
                {
                    account.Username = myReader.GetString(1);
                    account.accounts.Add(account.Username);
                }
            }
        }

        private void AddMovie()
        {

        }

        private void DeleteMovie()
        {

        }

        private void EditMovie()
        {

        }
        #endregion
    }
}
