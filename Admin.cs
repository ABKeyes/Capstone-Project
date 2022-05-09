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
    public partial class Admin : Form
    {
        private SqlConnectionStringBuilder _builder;
        private string selectedUser = "";
        private string currentPosition = "";


        public Admin(SqlConnectionStringBuilder builder)
        {
            this._builder = builder;
            InitializeComponent();
            this.PopulateData();
        }

        private void PopulateData()
        {
            this.populatePositions();
            this.populateUsers();
            this.userDataGridView.ReadOnly = true;

        }

        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string id = this.userDataGridView.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            this.currentPosition = this.userDataGridView.Rows[e.RowIndex].Cells["Position"].Value.ToString();
            Console.WriteLine(this.currentPosition);
            this.selectedUserDisplay.Text = id;



        }

        private void populateUsers()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(_builder.ConnectionString))
                {
                    string sql = $"SELECT Name, Position From Employee where Name != 'dbo';";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
                    Console.WriteLine(sql);
                    DataTable dtbl = new DataTable();

                    adapter.Fill(dtbl);
                    this.userDataGridView.DataSource = dtbl;
                    this.userDataGridView.Columns["Name"].DisplayIndex = 0;
                    this.userDataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.userDataGridView.Columns["Position"].DisplayIndex = 1;
                    this.userDataGridView.Columns["Position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
        }

        private void populatePositions()
        {
            string[] s = { "admin", "customer service", "engineering" };

            foreach (string item in s)
            {
                RoleOfNewUser.Items.Add(item);
                roleOfModifyUser.Items.Add(item);
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (this.RoleOfNewUser.SelectedItem == null)
            {
                this.Message_Output.Text = "Please Select Role for new user.";
                return;
            }
            using (SqlConnection connection = new SqlConnection(_builder.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction;
                SqlCommand cmd = connection.CreateCommand();
                transaction = connection.BeginTransaction("Admin Transaction");
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                try
                {
                    string user = AddUserInput.Text;
                    string sql = $"CREATE USER [{user}] FROM EXTERNAL PROVIDER;\n" +
                        $"ALTER ROLE db_datareader ADD MEMBER [{user}];\n" +
                        $"ALTER ROLE db_datawriter ADD MEMBER [{user}];\n";
                    if (RoleOfNewUser.SelectedItem == "admin")
                    {
                        sql += $"ALTER ROLE db_ddladmin ADD MEMBER [{user}];\n";
                    }
                    sql += $"GRANT VIEW DATABASE STATE TO [{user}]";

                    cmd.CommandText = sql;
                    //cmd.Parameters.AddWithValue("@USER", AddUserInput.Text);
                    cmd.ExecuteNonQuery();
                    sql = "INSERT INTO Employee (Name, Position) VALUES (@USER, @POSITION);";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@USER", AddUserInput.Text);
                    cmd.Parameters.AddWithValue("@POSITION", RoleOfNewUser.SelectedItem);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    this.populateUsers();
                    this.Message_Output.Text = $"New user {AddUserInput.Text} in role {RoleOfNewUser.SelectedItem}";
                    this.AddUserInput.Text = "";

                }
                catch (SqlException ex)
                {
                    this.Message_Output.Text = "Rolling Back Changes.\n" + ex.Message;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (SqlException ex2)
                    {
                        this.Message_Output.Text = "Changes Failed, Rollback Failed\n";
                    }
                }
            }

        }

        private void DropButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Are you sure you wish to drop user {selectedUserDisplay.Text}?", "Drop User", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(this._builder.ConnectionString))
                    {
                        connection.Open();
                        string sql = $"DROP USER [{this.selectedUserDisplay.Text}];";
                        Console.WriteLine(sql);
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        sql = $"DELETE FROM Employee WHERE Name = @USER;";
                        Console.WriteLine(sql);
                        cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@USER", this.selectedUserDisplay.Text);
                        cmd.ExecuteNonQuery();
                        this.Message_Output.Text = $"Successfully dropped {selectedUserDisplay.Text}";
                        selectedUserDisplay.Text = "";
                        this.populateUsers();

                    }
                }
                catch (SqlException ex)
                {
                    this.Message_Output.Text = ex.Message;
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (this.roleOfModifyUser.SelectedItem.ToString() == currentPosition)
            {
                this.Message_Output.Text = "User is already that role.";
            }
            if (this.roleOfModifyUser.SelectedItem == null)
            {
                this.Message_Output.Text = "Please Select Role for user.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(this._builder.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction("Update Role Transaction");
                try
                {

                    
                    string user = this.selectedUserDisplay.Text;
                    string sql = "";
                    if (this.roleOfModifyUser.SelectedItem.ToString() == "admin")
                    {
                        Console.WriteLine("Creating new Admin");
                        sql += $"ALTER ROLE db_ddladmin ADD MEMBER [{user}];\n";
                    }
                    if (this.currentPosition == "admin")
                    {
                        Console.WriteLine("Dropping admin");
                        sql += $"ALTER ROLE db_ddladmin DROP MEMBER [{user}];\n";
                    }
                    sql += "UPDATE Employee SET Position = @Position WHERE Name = @USER;\n";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@Position", this.roleOfModifyUser.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@USER", user);
                    Console.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    this.populateUsers();
                    this.selectedUserDisplay.Text = "";
                }
                catch (SqlException ex)
                {
                    this.Message_Output.Text = "Changes failed, Rolling Back.\n" + ex.Message;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch(SqlException ex2)
                    {
                        this.Message_Output.Text = "Critical Failure, unable to Rollback failed changes.";
                    }
                }
            }
        }
    }
}
