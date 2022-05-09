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
    public partial class ModifyStorage : Form
    {
        private readonly SqlConnectionStringBuilder _builder;
        private static Random random = new();
        private string currentTable = "";
        private readonly string defaultSN = "----";
        public ModifyStorage(SqlConnectionStringBuilder connection)
        {
            this._builder = connection;
            this.InitializeComponent();
            this.storageDataGridView.ReadOnly = true;
            this.Populate_storeroom();

        }

        private void MenuReturn_Click(object sender, EventArgs e)
        {
            Menu menu = new(this._builder);
            menu.FormLayout();
            menu.Show();
            this.Close();
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPWRSTUVWXYZ0123456789-";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GetNewSN(string table)
        {

            try
            {
                using (SqlConnection connect = new(this._builder.ConnectionString))
                {
                    string newSN;
                    connect.Open();
                    while (true)
                    {
                        newSN = RandomString(20);
                        Console.WriteLine("New SN:" + newSN);
                        string sql = $"SELECT COUNT(*) FROM {table} WHERE {table}ID = '{newSN}'";
                        Console.WriteLine(sql);
                        SqlCommand cmd = new SqlCommand(sql, connect);
                        int exist = (int) cmd.ExecuteScalar();

                        if (exist == 0) // This SN is already on the table, try a new one.
                        {
                            return newSN;
                        }

                    }
                    
                }

            }
            catch(SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
                return "FAILED";
            }
            
        }

        private void Populate_storeroom()
        {
            try
            {
                using (SqlConnection connect = new(this._builder.ConnectionString))
                {
                    connect.Open();
                    SqlDataAdapter adapter = new("SELECT * FROM Storeroom", connect);
                    DataTable dtbl = new();

                    adapter.Fill(dtbl);
                    if (dtbl.Rows.Count <= 0)
                    {
                        this.Message_Output.Text = "No Entries in Storeroom.";
                        return;
                    }
                    this.storageDataGridView.DataSource = dtbl;
                    this.storageDataGridView.Columns["Select_Button"].DisplayIndex = 1;
                    this.storageDataGridView.Columns["StoreroomID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
            this.currentTable = "Storeroom";
        }

        private void Populate_DGV(string reftable, string table, string refSN)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(this._builder.ConnectionString))
                {
                    connect.Open();
                    string sql = $"SELECT {table}ID FROM {table} WHERE {reftable}ID = '{refSN}';";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
                    Console.WriteLine(sql);
                    DataTable dtbl = new();

                    Console.WriteLine(dtbl.Rows.Count);

                    adapter.Fill(dtbl);
                    this.storageDataGridView.DataSource = dtbl;
                    this.storageDataGridView.Columns[$"{table}ID"].DisplayIndex = 0;
                    this.storageDataGridView.Columns[$"{table}ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch(SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
            this.currentTable = table;
        }

        private void Reset_Fields_Click(object sender, EventArgs e) => this.Reset_all();

        private void Reset_all()
        {
            this.Populate_storeroom();
            this.Selected_Storeroom.Text = this.defaultSN;
            this.Selected_Rack.Text = this.defaultSN;
            this.Selected_Shelf.Text = this.defaultSN;
            this.Selected_Bin.Text = this.defaultSN;
            this.storageDataGridView.Columns["Select_Button"].Visible = true;
        }

        private void Delete_Item(string table, string sN)
        {
            if (sN == this.defaultSN)
            {
                this.Message_Output.Text = $"Please Select a {table}.";
                return;
            }

            DialogResult dr = MessageBox.Show($"Are you sure you want to delete {table}: {sN}?", "Yes No", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                this.Message_Output.Text = $"Deletion of {table}: {sN} aborted.";
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(this._builder.ConnectionString))
                {
                    connection.Open();
                    string sql = $"DELETE FROM {table} WHERE {table}ID = @SN";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@SN", sN);
                    cmd.ExecuteNonQuery();
                    this.Message_Output.Text = $"Successfully Deleted {table}: {sN}";

                }
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
        }

        private void Delete_Storeroom_Click(object sender, EventArgs e)
        {
            this.Delete_Item("Storeroom", this.Selected_Storeroom.Text);
            this.Populate_storeroom();
        }

        private void Delete_Rack_Click(object sender, EventArgs e)
        {
            this.Delete_Item("Rack", this.Selected_Rack.Text);
            this.Populate_DGV("Storeroom", "Rack", this.Selected_Storeroom.Text);

        }

        private void Delete_Shelf_Click(object sender, EventArgs e)
        {
            this.Delete_Item("Shelf", this.Selected_Shelf.Text);
            this.Populate_DGV("Rack", "Shelf", this.Selected_Rack.Text);
        }

        private void Delete_Bin_Click(object sender, EventArgs e)
        {
            this.Delete_Item("Bin", this.Selected_Bin.Text);
            this.Populate_DGV("Shelf", "Bin", this.Selected_Shelf.Text);

        }

        private void StorageDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            string table_type = this.storageDataGridView.Columns[1].HeaderText;
            string text = this.storageDataGridView.Rows[e.RowIndex].Cells[table_type].Value.ToString();

            switch (table_type)
            {
                case "StoreroomID":
                    this.Selected_Storeroom.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    this.Populate_DGV("Storeroom", "Rack", text);
                    break;
                case "RackID":
                    this.Selected_Rack.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    this.Populate_DGV("Rack", "Shelf", text);
                    break;
                case "ShelfID":
                    this.Selected_Shelf.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    this.Populate_DGV("Shelf", "Bin", text);
                    break;
                case "BinID":
                    this.Selected_Bin.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    break;
                default:
                    break;
            }
        }

        private void Insert_Into_Storage(string reftable, string table, string reftableSN)
        {
            if (reftableSN == this.defaultSN)
            {
                this.Message_Output.Text = $"Please Select a {reftable}";
            }
            try
            {
                using (SqlConnection connect = new SqlConnection(this._builder.ConnectionString))
                {
                    string newSN = this.GetNewSN(table);
                    string sql = $"INSERT INTO {table} ({reftable}ID, {table}ID) VALUES (@RSN, @NSN);";
                    

                    SqlCommand cmd = new SqlCommand(sql, connect);
                    cmd.Parameters.AddWithValue("@RSN", reftableSN);
                    cmd.Parameters.AddWithValue("@NSN", newSN);
                    Console.WriteLine(sql);
                    connect.Open();
                    cmd.ExecuteNonQuery();
                    this.Message_Output.Text = $"Successfully Inserted {table}: {newSN}";
                }

            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
            
        }

        private void Add_Storeroom_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(this._builder.ConnectionString);
                string sql = "INSERT INTO Storeroom (StoreroomID) Values (@SID);";
                string sID = this.GetNewSN("Storeroom");
                if (sID == "FAILED")
                {
                    this.Message_Output.Text = "Failed to Generate new SN.";
                    return;
                }
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.Parameters.AddWithValue("@SID", sID);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                this.Message_Output.Text = $"Successfully Inserted Storeroom: {sID}";
                this.Populate_storeroom();
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
        }

        private void Add_Rack_Click(object sender, EventArgs e)
        {
            this.Insert_Into_Storage("Storeroom", "Rack", this.Selected_Storeroom.Text);
            this.Populate_DGV("Storeroom", "Rack", this.Selected_Storeroom.Text);
        }
        private void Add_Shelf_Click(object sender, EventArgs e)
        {
            this.Insert_Into_Storage("Rack", "Shelf", this.Selected_Rack.Text);
            this.Populate_DGV("Rack", "Shelf", this.Selected_Rack.Text);
        }


        private void Add_Bin_Click(object sender, EventArgs e)
        {
            this.Insert_Into_Storage("Shelf", "Bin", this.Selected_Shelf.Text);
            this.Populate_DGV("Shelf", "Bin", this.Selected_Shelf.Text);
        }

        private void Read_Bin_Click(object sender, EventArgs e)
        {
            if (this.Selected_Bin.Text == this.defaultSN)
            {
                this.Message_Output.Text = "Please select a bin";
                return;
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(this._builder.ConnectionString))
                {
                    string iD = this.Selected_Bin.Text;
                    string sql = $"Select ProductSN, Customername FROM Product Where BinID = '{iD}';";
                    Console.WriteLine(sql);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
                    DataTable dtbl = new DataTable();

                    adapter.Fill(dtbl);
                    if (dtbl.Rows.Count <= 0)
                    {
                        this.Message_Output.Text = "No Product in Bin";
                        return;
                    }
                    this.storageDataGridView.DataSource = dtbl;
                    this.storageDataGridView.Columns["Select_Button"].Visible = false;
                    this.storageDataGridView.Columns["ProductSN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.storageDataGridView.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
        }

        private void Move_Item(string reftable, string table, string sN, string refSN)
        {
            if (sN == this.defaultSN)
            {
                this.Message_Output.Text = $"Please Select a {table}.";
                return;
            }

            //MessageBox.Show($"Move {table}: {sN} from {reftable}: {refSN}");

            moveStorageDialog dialog = new(table, this._builder);

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                string newrefSN = dialog.newrefSN;
                if (refSN == newrefSN)
                {
                    this.Message_Output.Text = "Move would result in no change.";
                    dialog.Dispose();
                    return;
                }
                try
                {
                    string sql = $"UPDATE {table} SET {reftable}ID = '{newrefSN}' where {table}ID = '{sN}';";
                    using (SqlConnection connect = new SqlConnection(this._builder.ConnectionString))
                    {
                        connect.Open();
                        SqlCommand cmd = new SqlCommand(sql, connect);
                        cmd.ExecuteNonQuery();
                        this.Message_Output.Text = $"Moved {table}: {sN} to {reftable}: {newrefSN}";
                    }
                }
                catch (SqlException ex)
                {
                    this.Message_Output.Text = ex.Message;
                }
                this.Reset_all();
            }
            if (result == DialogResult.Cancel)
            {
                this.Message_Output.Text = "Move Cancled.";
            }
            dialog.Dispose();

            
        }

        private void Move_Rack_Click(object sender, EventArgs e) => this.Move_Item("Storeroom", "Rack", this.Selected_Rack.Text, this.Selected_Storeroom.Text);

        private void Move_Shelf_Click(object sender, EventArgs e) => this.Move_Item("Rack", "Shelf", this.Selected_Shelf.Text, this.Selected_Rack.Text);

        private void Move_Bin_Click(object sender, EventArgs e) => this.Move_Item("Shelf", "Bin", this.Selected_Bin.Text, this.Selected_Shelf.Text);

        private void BackButton_Click(object sender, EventArgs e)
        {
            switch (this.currentTable)
            {
                case "Rack":
                    this.Populate_storeroom();
                    this.Selected_Storeroom.Text = this.defaultSN;
                    break;
                case "Shelf":
                    this.Populate_DGV("Storeroom", "Rack", this.Selected_Storeroom.Text);
                    this.Selected_Rack.Text = this.defaultSN;
                    break;
                case "Bin":
                    this.Populate_DGV("Rack", "Shelf", this.Selected_Rack.Text);
                    this.Selected_Shelf.Text = this.defaultSN;
                    this.Selected_Bin.Text = this.defaultSN;
                    break;
                default:
                    break;
            }

        }
    }
}
