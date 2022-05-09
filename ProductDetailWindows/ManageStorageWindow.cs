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

namespace CapstoneApp.ProductDetailWindows
{
    public partial class ManageStorageWindow : Form
    {
        private SqlConnectionStringBuilder _builder;
        private ProductionPacket productionPacket;
        private readonly string defaultSN = "----";
        private string currentTable = "";
        public ManageStorageWindow(SqlConnectionStringBuilder _builder, ProductionPacket productionPacket)
        {
            this._builder = _builder;
            this.productionPacket = productionPacket;
            this.InitializeComponent();
            this.PopulateData();
        }

        public void PopulateData()
        {
            this.BinText = this.productionPacket.BinID;
            this.RackText = this.productionPacket.RackID;
            this.ShelfText = this.productionPacket.ShelfID;
            this.StoreroomText = this.productionPacket.StoreroomID;
            Populate_storeroom();

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
                        this.Message_Output.Text = "No Entries in Storeroom";
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

        private void Storage_Reset_Click(object sender, EventArgs e)
        {
            this.Populate_storeroom();
            this.New_Storeroom_Value.Text = this.defaultSN;
            this.New_Rack_Value.Text = this.defaultSN;
            this.New_Shelf_Value.Text = this.defaultSN;
            this.New_Bin_Value.Text = this.defaultSN;
            this.Message_Output.Text = "";
        }

        private void CurrentStorageBox_Enter(object sender, EventArgs e)
        {

        }

        public string BinText
        {
            get => this.Bin_Value.Text;
            set => this.Bin_Value.Text = value;
        }

        public string ShelfText
        {
            get => this.Rack_Value.Text;
            set => this.Rack_Value.Text = value;
        }
        public string RackText
        {
            get => this.Shelf_Value.Text;
            set => this.Shelf_Value.Text = value;
        }

        public string StoreroomText
        {
            get => this.Storeroom_Value.Text;
            set => this.Storeroom_Value.Text = value;
        }

        private void storageDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    this.New_Storeroom_Value.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    this.Populate_DGV("Storeroom", "Rack", text);
                    break;
                case "RackID":
                    this.New_Rack_Value.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    this.Populate_DGV("Rack", "Shelf", text);
                    break;
                case "ShelfID":
                    this.New_Shelf_Value.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    this.Populate_DGV("Shelf", "Bin", text);
                    break;
                case "BinID":
                    this.New_Bin_Value.Text = text;
                    this.Message_Output.Text = $"{table_type}: {text}";
                    break;
                default:
                    break;
            }
        }

        private void Update_Storage_Click(object sender, EventArgs e)
        {
            if (New_Bin_Value.Text == this.defaultSN)
            {
                this.Message_Output.Text = "Please Select Bin";
                return;
            }
            if (New_Bin_Value.Text == Bin_Value.Text)
            {
                this.Message_Output.Text = "Please select a different Bin.";
                return;
            }
            DialogResult dr = MessageBox.Show($"Update Product: {this.productionPacket.ProductSN} Storage Location?", "Update Dialog", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                this.Message_Output.Text = $"Storage Modification Aborted";
                return;
            }
            try
            {
                using (SqlConnection connect = new SqlConnection(this._builder.ConnectionString))
                {
                    connect.Open();
                    string sql = $"UPDATE Product SET BinID = @ID WHERE ProductSN = @SN;";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    cmd.Parameters.AddWithValue("@ID", this.New_Bin_Value.Text);
                    Console.WriteLine(sql);
                    Console.WriteLine(this.New_Bin_Value.Text);
                    cmd.Parameters.AddWithValue("@SN", this.productionPacket.ProductSN);
                    Console.WriteLine(this.productionPacket.ProductSN);
                    cmd.ExecuteNonQuery();
                    this.Message_Output.Text = $"Successfully Moved Product: {this.productionPacket.ProductSN}.";
                }
            }
            catch (SqlException ex)
            {
                this.Message_Output.Text = ex.Message;
            }

            this.productionPacket.BinID = this.New_Bin_Value.Text;
            this.productionPacket.ShelfID = this.New_Shelf_Value.Text;
            this.productionPacket.RackID = this.New_Rack_Value.Text;
            this.productionPacket.StoreroomID = this.New_Storeroom_Value.Text;

            this.PopulateData();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            switch (this.currentTable)
            {
                case "Rack":
                    this.Populate_storeroom();
                    this.New_Storeroom_Value.Text = this.defaultSN;
                    break;
                case "Shelf":
                    this.Populate_DGV("Storeroom", "Rack", this.New_Storeroom_Value.Text);
                    this.New_Rack_Value.Text = this.defaultSN;
                    break;
                case "Bin":
                    this.Populate_DGV("Rack", "Shelf", this.New_Rack_Value.Text);
                    this.New_Shelf_Value.Text = this.defaultSN;
                    this.New_Bin_Value.Text = this.defaultSN;
                    break;
                default:
                    break;
            }
        }
    }
}
