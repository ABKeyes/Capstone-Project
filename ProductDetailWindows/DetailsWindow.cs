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
    public partial class DetailsWindow : UserControl
    {
        private SqlConnectionStringBuilder _builder;
        private ProductionPacket productionPacket;
        /*
        Function to help pass along the data of the selected row
        */
        public DetailsWindow(SqlConnectionStringBuilder connection, ProductionPacket productionPacket)
        {
            this._builder = connection;
            this.productionPacket = productionPacket;
            this.InitializeComponent();

            // Populate Product Information
            if (productionPacket.WarrantyActive)
                this.warrantyIcon.Image = global::CapstoneProject.Properties.Resources.Yes16x16;
            if (productionPacket.WarratyStart != DateTime.MinValue)
            {
                this.WarrantyStart.Value = productionPacket.WarratyStart;
                this.warrantyEnd.Value = productionPacket.WarrantyEnd;
            }

        } // ProductionDetails()
        public DetailsWindow()
        {
            this.InitializeComponent();
        }

        /* 
         UpdateButton_click updates the warranty end date and warranty status of the product currently being viewed
         */
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // get new warranty end date
            DateTime newWarranty = this.warrantyEnd.Value;

            // add update date in the sql database
            string responseMessage;
            try
            {
                SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                string updateQuery;
                connection.Open();

                // update warranty start date; but only if it is a default value
                updateQuery = this.productionPacket.WarratyStart == DateTime.MinValue
                    ? "UPDATE Product SET WarrantyEnd = @WarrantyEnd, WarrantyStart = @WarrantyStart WHERE ProductSN = @ProductSN;"
                    : "UPDATE Product SET WarrantyEnd = @WarrantyEnd WHERE ProductSN = @ProductSN;";

                // Add Product to Product Table
                SqlCommand productCommand = new SqlCommand(updateQuery, connection);
                productCommand.Parameters.AddWithValue("@ProductSN", this.productionPacket.ProductSN);
                productCommand.Parameters.AddWithValue("@WarrantyEnd", newWarranty);
                productCommand.Parameters.AddWithValue("@WarrantyStart", DateTime.Today);
                productCommand.ExecuteNonQuery();

                connection.Close();
                responseMessage = "Warranty Updated Successfully";
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                responseMessage = "Something Went Wrong, Please Try Again";
            } // catch

            // notify user of sql response
            MessageBox.Show(responseMessage);

            // Update Warranty information within the packet and display
            this.warrantyIcon.Image = global::CapstoneProject.Properties.Resources.Yes16x16;
            if (!this.productionPacket.WarrantyActive)
            {
                this.WarrantyStart.Value = DateTime.Today;
                this.productionPacket.WarratyStart = DateTime.Today;
                this.productionPacket.WarrantyActive = true;
            }
            this.warrantyEnd.Value = newWarranty;
            this.productionPacket.WarrantyEnd = newWarranty;
            this.Update();

            //log the update to the datebase
            ProductDetails.WriteUpdatesToLog(this._builder,
                                            this.productionPacket.ProductSN,
                                            string.Format("Updated Warranty End Date To: {0}\nWarranty Start Date To: {1}", newWarranty, this.productionPacket.WarratyStart),
                                            "Warranty Change");
        } // UpdateButton_Click

        private void apiContainers_Panel1_Paint(object sender, PaintEventArgs e)
        {
            String aligniID = this.productionPacket.AligniSN;
            this.label2.Text = "Aligni ID: " + aligniID;

            String fishbowlID = this.productionPacket.FishbowlSN;
            this.label3.Text = "Fishbowl ID: " + fishbowlID;
        }

        private void apiContainers_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            string updateQuery = "UPDATE Product SET FishbowlSN = @FishbowlSN WHERE ProductSN = @ProductSN";
            connection.Open();

            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@FishbowlSN", this.fishbowlText.Text);
            command.Parameters.AddWithValue("@ProductSN", this.productionPacket.ProductSN);
            command.ExecuteNonQuery();

            connection.Close();

            this.label3.Text = "Fishbowl ID: " + this.fishbowlText.Text;
        }
    }
}
