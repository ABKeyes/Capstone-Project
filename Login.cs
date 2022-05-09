using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CapstoneApp
{
    public partial class Login : Form
    {
        private SqlConnectionStringBuilder _builder;
        static public string Az_SQLDB_svrName = "capstone-420.database.windows.net";
        static public string Initial_DatabaseName = "capstone-420";
        static public string Initial_Catalog = "Capstone_Mock_Database";
        public Login()
        {
            this.InitializeComponent();
            this._builder = new SqlConnectionStringBuilder();
            this.Show();
        }

        private void QuitButton_Click(object sender, EventArgs e) => Application.Exit();

        public void AzureAD()
        {
            //ActiveDirectoryAuthenticationProvider provider = new ActiveDirectoryAuthenticationProvider();

            //SqlAuthenticationProvider.SetProvider(SqlAuthenticationMethod.ActiveDirectoryInteractive, provider);
            Connection();
        }

        public void set_Connection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = Az_SQLDB_svrName;
            builder.InitialCatalog = Initial_Catalog;
            builder.ConnectTimeout = 15;
            builder.TrustServerCertificate = true;
            builder.Pooling = false;
            builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
            SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString);

            this._builder = builder;

            Console.WriteLine(builder);

            SqlCommand cmd = new("SELECT CURRENT_USER;", sqlConnection);

            try
            {
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    string msg = "";
                    string role = "";
                    
                    while (rdr.Read())
                    {
                        msg = rdr.GetString(0);
                    }
                    rdr.Close();

                    cmd = new("SELECT Position From Employee where Name = @name;", sqlConnection);
                    cmd.Parameters.AddWithValue("@name", msg);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        role = rdr.GetString(0);
                    }
                    rdr.Close();

                    Console.WriteLine(msg);
                    Console.WriteLine(":Success");

                    string query = "INSERT INTO LoginAudit (Name, Position, LogTime) Values (@Name, @Position, @LogTime)";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@Name", msg);
                    command.Parameters.AddWithValue("@Position", role);
                    command.Parameters.AddWithValue("@LogTime", DateTime.Now);
                    command.ExecuteNonQuery();
                    Console.WriteLine(msg.ToString());
                    Console.WriteLine(":Success");
                    UserGlobals.userType = role;
                    UserGlobals.userName = msg;
                    this.openMenu();
                }
                else
                {
                    Console.WriteLine(":Failed");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Connection failed with the following exception...");
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
                MessageBox.Show($"Connection failed with the following exception: {ex.Message}");
            }

            this._builder = builder;
        }

        public void Connection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = Az_SQLDB_svrName;
            builder.InitialCatalog = Initial_Catalog;
            builder.ConnectTimeout = 15;
            builder.TrustServerCertificate = true;
            builder.Pooling = false;
            builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
            SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString);

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Product;",
                sqlConnection);
            try
            {
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    var rdr = cmd.ExecuteReader();
                    var msg = new StringBuilder();
                    while (rdr.Read())
                    {
                        msg.AppendLine(rdr.GetString(0));
                    }
                    Console.WriteLine(msg.ToString());
                    Console.WriteLine(":Success");
                    openMenu();
                }
                else
                {
                    Console.WriteLine(":Failed");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Connection failed with the following exception...");
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }
        }

        private void openMenu()
        {
            Menu menu = new Menu(this._builder);
            menu.FormLayout();
            menu.Show();
            this.Close();
        }

        private void loginSubmit_Click(object sender, EventArgs e)
        {
            

            string username = this.usernameInput.Text;
            string password = this.passwordInput.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Invalid username/password");
            }

            if (this._builder == null)
            {
                return;
            }

            try
            {
                // Sign into Azure SQL database
                this._builder.DataSource = Az_SQLDB_svrName;
                this._builder.UserID = this.usernameInput.Text;
                this._builder.Password = this.passwordInput.Text;
                this._builder.InitialCatalog = Initial_Catalog;
                this._builder.MaxPoolSize = 30; // Limit queries to up to 30 at once

            } // try
            catch (SqlException err)
            {
                MessageBox.Show("Error Logging in.");
                Console.WriteLine(err.ToString());
            } // catch(SqlException)

            openMenu();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            //AzureAD();
            set_Connection();
        }
    }
}
public static class UserGlobals
{
    public static string userType = "";
    public static string userName = "";
}
