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
    public partial class moveStorageDialog : Form
    {
        private string toBeMoved;
        public string newrefSN;
        private SqlConnectionStringBuilder _builder;
        private readonly string defaultSN = "----";
        private string currentTable = "";
        public moveStorageDialog(string toBeMoved, SqlConnectionStringBuilder connection)
        {
            this.InitializeComponent();
            this.toBeMoved = toBeMoved;
            this._builder = connection;
            this.Populate_storeroom();
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
                    DataTable dtbl = new DataTable();

                    adapter.Fill(dtbl);
                    //if (dtbl.Rows.Count <= 0)
                    //{
                    //    this.Message_Output.Text = $"No Entries in {reftable}: {refSN}";
                    //    return;
                    //}
                    this.storageDataGridView.DataSource = dtbl;
                    this.storageDataGridView.Columns[$"{table}ID"].DisplayIndex = 0;
                    this.storageDataGridView.Columns[$"{table}ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }
            this.currentTable = table;
        }

        private void Confirm_Move(string text)
        {
            DialogResult dr = MessageBox.Show($"Confirm move {this.toBeMoved}: {text}?", "Confirm", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.newrefSN = text;
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.newrefSN = text;
            this.DialogResult = DialogResult.Cancel;
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
                    if (this.toBeMoved == "Rack")
                    {
                        this.Confirm_Move(text);

                    }
                    this.Populate_DGV("Storeroom", "Rack", text);
                    break;
                case "RackID":
                    this.Selected_Rack.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    if (this.toBeMoved == "Shelf")
                    {
                        this.Confirm_Move(text);
                    }
                    this.Populate_DGV("Rack", "Shelf", text);
                    break;
                case "ShelfID":
                    this.Selected_Shelf.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    if (this.toBeMoved == "Bin")
                    {
                        this.Confirm_Move(text);
                    }
                    break;
                default:
                    break;
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            switch (this.currentTable)
            {
                case "Storeroom":
                    break;
                case "Rack":
                    this.Populate_storeroom();
                    this.Selected_Storeroom.Text = this.defaultSN;
                    break;
                case "Shelf":
                    this.Populate_DGV("Storeroom", "Rack", this.Selected_Storeroom.Text);
                    this.Selected_Rack.Text = this.defaultSN;
                    break;
                default:
                    break;
            }
        }

        private void Reset_all()
        {
            this.Populate_storeroom();
            this.Selected_Storeroom.Text = this.defaultSN;
            this.Selected_Rack.Text = this.defaultSN;
            this.Selected_Shelf.Text = this.defaultSN;
        }
        private void Reset_Button_Click(object sender, EventArgs e) => this.Reset_all();
    }
}
