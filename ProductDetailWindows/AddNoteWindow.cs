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
    public partial class AddNoteWindow : Form
    {
        private SqlConnectionStringBuilder _builder;

        /*
        Function to help pass along the data of the selected row
        */
        public AddNoteWindow(SqlConnectionStringBuilder connection)
        {
            this._builder = connection;
            this.InitializeComponent();
            this.PopulateData();
        } // LogWindow()
        public AddNoteWindow()
        {
            this.InitializeComponent();
        } // LogWindow()

        /*
           PopulateData takes the serial number from productdetails and grabs all of the notes information
           and sets them as the datasource for the gridview.
        */
        public void PopulateData()
        {
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

        /*
         * SubmitButton_Click adds the new note to the database under the Serial number entered.
         */
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // get text from textbox
            string outputNote = this.addNoteTextBox.Text;

            // add note to the sql database
            try
            {
                SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                connection.Open();
                string addNoteQuery = "insert into Note(ProductSN,Note) values (@ProductSN, @Note)";

                // Add Product to Product Table
                SqlCommand productCommand = new SqlCommand(addNoteQuery, connection);
                productCommand.Parameters.AddWithValue("@ProductSN", ProductDetails.SerialNumber);
                productCommand.Parameters.AddWithValue("@Note", outputNote);
                productCommand.ExecuteNonQuery();

                connection.Close();
                this.PopulateData();
                this.addNoteTextBox.Text = null;
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                // notify user of sql error
                MessageBox.Show("Something Went Wrong, Please Try Again");
            } // catch

        }
    } // AddNoteWindow() : Form
}
