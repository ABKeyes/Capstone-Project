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
    public partial class storageDialog : Form
    {
        SqlConnectionStringBuilder _builder;
        public Dictionary<string, string> storageDetails = new Dictionary<string, string>();

        public storageDialog(SqlConnectionStringBuilder connection)
        {
            this._builder = connection;
            this.InitializeComponent();
            this.storageDataGridView.ReadOnly = true;
            this.Populate_storeroom();
        }

        private void Populate_storeroom()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(this._builder.ConnectionString))
                {
                    connect.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Storeroom", connect);
                    DataTable dtbl = new DataTable();

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

        }

        private void Populate_DGV(string reftable, string table, string refSN)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(_builder.ConnectionString))
                {
                    connect.Open();
                    string sql = $"SELECT {table}ID FROM {table} WHERE {reftable}ID = '{refSN}';";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
                    Console.WriteLine(sql);
                    DataTable dtbl = new DataTable();

                    adapter.Fill(dtbl);
                    if (dtbl.Rows.Count <= 0)
                    {
                        this.Message_Output.Text = $"No Entries in {reftable}: {refSN}";
                        return;
                    }
                    this.storageDataGridView.DataSource = dtbl;
                    this.storageDataGridView.Columns[$"{table}ID"].DisplayIndex = 0;
                    this.storageDataGridView.Columns[$"{table}ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
        }

        private void StorageDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            this.Populate_storeroom();
            this.Selected_Storeroom.Text = "----";
            this.Selected_Rack.Text = "----";
            this.Selected_Shelf.Text = "----";
            this.Selected_Bin.Text = "----";
            this.storageDataGridView.Columns["Select_Button"].Visible = true;
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.Selected_Bin.Text == "----")
            {
                this.Message_Output.Text = "Please Select Bin.";
                return;
            }
            this.storageDetails["StoreroomID"] = this.Selected_Storeroom.Text;
            this.storageDetails["RackID"] = this.Selected_Rack.Text;
            this.storageDetails["ShelfID"] = this.Selected_Shelf.Text;
            this.storageDetails["BinID"] = this.Selected_Bin.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
