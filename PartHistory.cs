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
    public partial class PartHistory : UserControl
    {
        private SqlConnectionStringBuilder _builder;
        private string _serialNumber; // for use with going to a product page for extra details
        enum SearchType
        {
            SerialNumber,
            LotNumber
        }

        public PartHistory(SqlConnectionStringBuilder connection)
        {
            this.InitializeComponent();
            this._builder = connection;
        } // PartHistory()

        public void FormLayout()
        {
            List<String> attributes = new List<String>();

            WindowLayout();
            this.searchPart.KeyDown += new System.Windows.Forms.KeyEventHandler((object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Return)
                {
                    SerialSearchClick(sender, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            });

            this.searchLot.KeyDown += new System.Windows.Forms.KeyEventHandler((object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Return)
                {
                    LotSearchClick(sender, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            });

            this.PopulateData();
        } // FormLayout()

        /*
        (void) WindowLayout configures the new window created for the search
        applet.
        */
        public void WindowLayout()
        {
            this.Name = Constants.windowName;
            this.Text = Constants.windowName;
            this.Size = new System.Drawing.Size(Constants.width, Constants.height);
        } // WindowLayout()

        /*
        (void) PopulateData performs an SQL query to grab the entire parts schema
        from the database. If the current (SqlConnectionStringBuilder) builder is
        invalid (null), no data will be populated. By default, PopulateData will
        fill the (DataGridView) historyDisplay element with first few entries
        in the database, along with all columns present at the start.
        */
        public async void PopulateData()
        {
            if (this._builder == null)
                return;
            // Attempt to populate fields with Parts table
            try
            {
                SqlConnection connection = new SqlConnection(_builder.ConnectionString);
                String sql = "SELECT * FROM Product;";
                SqlCommand command = new SqlCommand(sql, connection);

                this.productListDataView.Columns.Clear();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // get all column names and display them in columnCheckedListBox - but only if list box is empty
                if (this.columnCheckedListBox.Items.Count == 0)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        this.columnCheckedListBox.Items.Add(reader.GetName(i));
                    }
                }
                connection.Close();

                connection.Open();
                // use the sql commend to get dataset, fill dataset with values returned and update the dataview
                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                this.productListDataView.DataSource = ds.Tables[0];

                if (productListDataView.Rows.Count > 0)
                {
                    productListDataView.Rows[0].Selected = true;
                    detailsButton.Visible = true;
                    this._serialNumber = (string) productListDataView.Rows[0].Cells["ProductSN"].Value;
                }
                else
                {
                    detailsButton.Visible = false;
                }

                // only show the first 4 main columns when first populating data
                this.productListDataView.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
                this.AddCheckboxColumn();
                for (int i = 0; i < 5; i++)
                {
                    this.productListDataView.Columns[i].Visible = true;
                }
                
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.ToString());
                string[] fakeRecord = new string[3];
                fakeRecord[0] = "ZZZZZZ-AAAAA-DDDD";
                fakeRecord[1] = "Error Getting Part Infromation";
                fakeRecord[2] = "";
                productListDataView.Rows.Add(fakeRecord);
            } // catch(SqlException)
        } // PopulateData()

        /*
        (void) SearchClick is activated when the search button is clicked in the
        part searching applet. This function takes the text inputted into the
        adjacent search field (TextBox) this.searchPart, and attempts to
        search for the serial number inputted into the field. If the user
        inputs just whitespace or an illegal sql query, the query will
        default to calling PopulateData(). Table containing data from query will
        grow dynamically based on the greatest subset of columns between records
        not containing just NULL values.
        */
        private void SerialSearchClick(object sender, EventArgs e) => this.SearchClick(SearchType.SerialNumber);
        private void LotSearchClick(object sender, EventArgs e) => this.SearchClick(SearchType.LotNumber);
        private void ExportClick(object sender, EventArgs e)
        {
            CSV.data.exportCSV();
            CSV.data.removeSerialNumbers();
            // Update gridview
            PopulateData();
        }
        private void CheckboxChanged(object o, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.productListDataView.Columns[0].Index && e.RowIndex != -1)
            {
                if ((bool) this.productListDataView.Rows[e.RowIndex].Cells["CSV"].Value)
                {
                    Console.WriteLine("Selected SN: " + this.productListDataView.Rows[e.RowIndex].Cells["ProductSN"].Value);
                    CSV.data.addSerialNumber((String) this.productListDataView.Rows[e.RowIndex].Cells["ProductSN"].Value);
                }
                else
                {
                    CSV.data.removeSerialNumber((String) this.productListDataView.Rows[e.RowIndex].Cells["ProductSN"].Value);
                }
            }
        }
        private void CheckboxMouseUp(object o, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == this.productListDataView.Columns[0].Index && e.RowIndex != -1)
            {
                this.productListDataView.EndEdit();
            }
        }
        private void SearchClick(SearchType searchType)
        {
            String uniqueid;

            if (searchType == SearchType.SerialNumber)
                uniqueid = this.searchPart.Text;
            else
                uniqueid = this.searchLot.Text;

            this.productListDataView.Columns.Clear();
            if ((String.IsNullOrWhiteSpace(uniqueid) || uniqueid.Contains(";")
                || uniqueid.Contains("\"") || uniqueid.Contains("\'")))
            {
                PopulateData();
                while (this.columnCheckedListBox.CheckedIndices.Count > 0)
                    this.columnCheckedListBox.SetItemChecked(this.columnCheckedListBox.CheckedIndices[0], false);
                if (searchType == SearchType.SerialNumber)
                {
                    this.searchPart.Text = ""; // Clear text on search
                }
                else
                    this.searchLot.Text = "";
                return;
            } // if(String.IsNullOrWhiteSpace(uniqueid) || uniqueid.Contains(";"))

            try
            {
                SqlConnection connection = new SqlConnection(_builder.ConnectionString);
                // Search both ProductSN and CustomerName fields
                string sql = searchType == SearchType.SerialNumber ? $"SELECT * FROM Product WHERE ProductSN LIKE @uniqueid OR CustomerName LIKE @uniqueid;" : $"SELECT * FROM Product WHERE LotNum LIKE @uniqueid;";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@uniqueid", $"%{uniqueid}%");

                connection.Open();
                // use the sql commend to get dataset, fill dataset with values returned and update the dataview
                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                this.productListDataView.DataSource = ds.Tables[0];
                connection.Close();

                this.productListDataView.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
                this.AddCheckboxColumn();
                if (this.columnCheckedListBox.CheckedItems.Count > 0)
                {
                    foreach (var item in this.columnCheckedListBox.CheckedItems)
                    {
                        string value = item.ToString();
                        this.productListDataView.Columns[value].Visible = true;
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        this.productListDataView.Columns[i].Visible = true;
                    }
                }
                


                if (searchType == SearchType.SerialNumber)
                    this.searchPart.Text = ""; // Clear text on search
                else
                    this.searchLot.Text = "";

                if (productListDataView.Rows.Count > 0)
                {
                    productListDataView.Rows[0].Selected = true;
                    detailsButton.Visible = true;
                    this._serialNumber = (string) productListDataView.Rows[0].Cells["ProductSN"].Value;
                }
                else
                {
                    detailsButton.Visible = false;
                }
            } // try
            catch (SqlException err)
            {
                Console.WriteLine(err.ToString());
                string[] fakeRecord = new string[3];
                fakeRecord[0] = "ZZZZZZ-AAAAA-DDDD";
                fakeRecord[1] = "fake part name";
                fakeRecord[2] = "fake company";
                productListDataView.Rows.Add(fakeRecord);
            } // catch(SqlException)

        } // SearchClick()

        /*
        (void) PartClick is run whenever an item in the Data
        */
        void PartClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView ourView = (DataGridView) sender;
            if (e.RowIndex < 0)
            {
                return; // Prevent out of bounds read
            }
            this._serialNumber = (String) ourView.Rows[e.RowIndex].Cells["ProductSN"].Value;

        } // PartClick()

        private void ProductDetails(object sender, EventArgs e)
        {
            Menu menu = this.ParentForm as Menu;
            menu.DisplayPanel.Controls.Clear();
            ProductDetails details = new ProductDetails(this._builder, this._serialNumber)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Parent = menu,
                Dock = DockStyle.Fill
            };
            details.FormLayout();
            menu.DisplayPanel.Controls.Add(details);
            details.Show();
        }

        private void ColumnCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var checkedListBox = (CheckedListBox) sender;
            var checkedItemText = checkedListBox.Items[e.Index].ToString();
            var checkedItemCount = this.columnCheckedListBox.CheckedItems.Count;

            // column was checked && first item to be selected - hide all fields, add current item to gridview
            if (e.NewValue == CheckState.Checked && checkedItemCount == 0)
            {
                this.productListDataView.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
                this.productListDataView.Columns[0].Visible = true;
                this.productListDataView.Columns[checkedItemText].Visible = true;
            }
            // column was checked - add to gridview
            else if (e.NewValue == CheckState.Checked)
            {
                this.productListDataView.Columns[checkedItemText].Visible = true;
            }
            // column was unchecked - reset gridview to default
            else if (checkedItemCount == 1)
            {
                for (int i = 1; i < 5; i++)
                {
                    this.productListDataView.Columns[i].Visible = true;
                }
            }
            // column was unchecked - remove from gridview
            else
            {
                this.productListDataView.Columns[checkedItemText].Visible = false;
            }
        }

        private void AddCheckboxColumn()
        {
            DataGridViewCheckBoxColumn dgvCmb = new();
            dgvCmb.Name = "CSV";
            dgvCmb.HeaderText = "CSV";
            dgvCmb.ReadOnly = false;
            this.productListDataView.Columns.Insert(0, dgvCmb);
        }
    }

} // PartHistory : Form
