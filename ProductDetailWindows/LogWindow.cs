using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CapstoneApp.ProductDetailWindows
{
    public partial class LogWindow : Form
    {
        private SqlConnectionStringBuilder _builder;

        /*
        Function to help pass along the data of the selected row and populate the data for the gridviews
        */
        public LogWindow(SqlConnectionStringBuilder connection)
        {
            this._builder = connection;
            this.InitializeComponent();
            this.PopulateData();
            this.logGridView.CellMouseClick += this.LogGridView_CellMouseClick;
            this.notesGridView.CellMouseClick += this.NotesGridView_CellMouseClick;
        } // LogWindow()

        public LogWindow()
        {
            this.InitializeComponent();
        } // LogWindow()

        /*
            PopulateData takes the serial number from productdetails and grbs all of the notes and events information
            and sets them as the datasource for the gridviews.
         */
        public void PopulateData()
        {
            // populate event information in first panel
            try
            {
                SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                string eventDataQuery = "SELECT * FROM Event WHERE ProductSN= @ProductSN;";

                // grab all of the Event information for the serial number
                SqlCommand eventCommand = new SqlCommand(eventDataQuery, connection);
                eventCommand.Parameters.AddWithValue("@ProductSN", ProductDetails.SerialNumber);
                SqlDataAdapter dataAdapter = new();
                dataAdapter.SelectCommand = eventCommand;
                DataSet eventDataSet = new();
                connection.Open();
                dataAdapter.Fill(eventDataSet, "Events");
                connection.Close();
                eventDataSet.Tables["Events"].Columns.RemoveAt(0);
                this.logGridView.DataSource = eventDataSet;
                this.logGridView.DataMember = "Events";
                this.logGridView.Columns["CreationTime"].HeaderText = "Creation Time";
                this.logGridView.Sort(this.logGridView.Columns["CreationTime"], ListSortDirection.Descending);
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                // notify user of sql error
                MessageBox.Show("Error getting event information, Please Try Again");
            } // catch

            // populate notes information in second panel
            try
            {
                SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                string eventDataQuery = "SELECT * FROM Note WHERE ProductSN= @ProductSN;";

                // grab all of the Notes information for the serial number
                SqlCommand eventCommand = new SqlCommand(eventDataQuery, connection);
                eventCommand.Parameters.AddWithValue("@ProductSN", ProductDetails.SerialNumber);
                SqlDataAdapter dataAdapter = new();
                dataAdapter.SelectCommand = eventCommand;
                DataSet notesDataSet = new();
                connection.Open();
                dataAdapter.Fill(notesDataSet, "Notes");
                connection.Close();
                notesDataSet.Tables["Notes"].Columns.RemoveAt(0);
                this.notesGridView.DataSource = notesDataSet;
                this.notesGridView.DataMember = "Notes";
                this.notesGridView.Columns["CreationTime"].HeaderText = "Creation Time";
                this.notesGridView.Sort(this.notesGridView.Columns["CreationTime"], ListSortDirection.Descending);
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                // notify user of sql error
                MessageBox.Show("Error getting notes information, Please Try Again");
            } // catch

        } // PopulateData()

        /* LogGridView_CellMouseClick is the event handler for the right click event within the event log window.
         *      The strip menu will display the log related options at the bottom left of the cell selected
         */
        private void LogGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                return;

            DataGridViewCell currentCell = (sender as DataGridView).CurrentCell;
            this.rightClickMenu.Items.Clear();

            Rectangle cellLocation = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
            Point menuPoint = new Point(cellLocation.X, cellLocation.Y + cellLocation.Height);

            int rowIndex = e.RowIndex;

            this.rightClickMenu.Items.Add("Delete", null, new EventHandler(delegate (object sender, EventArgs e) {
                this.Delete_Click(sender, e, "logGridView", rowIndex);
            }));

            this.rightClickMenu.Show(this.logGridView, menuPoint);

        } // LogGridView_CellMouseClick

        /* NotesGridView_CellMouseClick is the event handler for the right click event within the notes log window.
         *      The strip menu will display the note related options at the bottom left of the cell selected
         */
        private void NotesGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                return;

            DataGridViewCell currentCell = (sender as DataGridView).CurrentCell;
            this.rightClickMenu.Items.Clear();

            Rectangle cellLocation = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
            Point menuPoint = new Point(cellLocation.X, cellLocation.Y + cellLocation.Height);

            int rowIndex = e.RowIndex;

            this.rightClickMenu.Items.Add("Edit", null, new System.EventHandler(delegate (object sender, EventArgs e) {
                this.Edit_Click(sender, e, rowIndex);
            }));
            this.rightClickMenu.Items.Add("Delete", null, new EventHandler(delegate (object sender, EventArgs e) {
                this.Delete_Click(sender, e, "notesGridView", rowIndex);
            }));

            this.rightClickMenu.Show(this.notesGridView, menuPoint);
        }

        /*
         * 
         */
        private void Edit_Click(object sender, EventArgs e, int rowIndex)
        {
            string formattedString = this.notesGridView.Rows[rowIndex].Cells[1].FormattedValue.ToString();
            formattedString = formattedString.Replace("\n", "\r\n");

            string responseString = Prompt.ShowDialog(formattedString, "Edit Note");
            
            if (responseString == "")
                return;

            // update note in the sql database
            string responseMessage;
            try
            {
                SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                connection.Open();
                string updateQuery = "UPDATE Note SET Note = @Note WHERE CreationTime = @CreationTime;";

                // Add Product to Product Table
                SqlCommand productCommand = new SqlCommand(updateQuery, connection);
                productCommand.Parameters.AddWithValue("@Note", responseString);
                productCommand.Parameters.AddWithValue("@CreationTime", this.notesGridView.Rows[rowIndex].Cells[0].Value);
                productCommand.ExecuteNonQuery();

                connection.Close();
                responseMessage = "Note Updated Successfully";
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                responseMessage = "Something Went Wrong, Please Try Again";
            } // catch

            // notify user of sql response and update datagrids to reflect changes
            MessageBox.Show(responseMessage);
            this.PopulateData();
        } // Edit_Click

        /* Delete_Click handles the removal of an event or note entry after delete has been selected from the strip menu
         */
        private void Delete_Click(object sender, EventArgs e, string windowName, int rowIndex)
        {
            // populate confirmation
            DialogResult dialogResult = MessageBox.Show("Are you sure? This command cannot be undone.", "Delete Entry", MessageBoxButtons.YesNo);

            var creationTime = (windowName == "notesGridView") ? this.notesGridView.Rows[rowIndex].Cells[0].Value : this.logGridView.Rows[rowIndex].Cells[2].Value;
            // handle response
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // remove the entry based on the windowname and the timestamp
                    string productDataQuery = (windowName == "notesGridView") ?
                        "DELETE FROM Note WHERE CreationTime= @CreationTime;" :
                        "DELETE FROM Event WHERE CreationTime= @CreationTime;";
                    SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                    SqlCommand productCommand = new SqlCommand(productDataQuery, connection);
                    productCommand.Parameters.AddWithValue("@CreationTime", creationTime);
                    connection.Open();
                    productCommand.ExecuteNonQuery();
                    connection.Close();
                } // try
                catch (SqlException err)
                {
                    System.Diagnostics.Debug.WriteLine(err.ToString());
                    // notify user of sql error
                    MessageBox.Show("Error Removing Entry, Please Try Again");
                    return;
                } // catch

                MessageBox.Show("Entry Removed Successfully");
                this.PopulateData();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        } // Delete_Click
    } // LogWindow() : Form
}
