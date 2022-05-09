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
    public partial class UpdateProduct : UserControl
    {
        private ProductionPacket productionPacket;
        private SqlConnectionStringBuilder _builder;
        public UpdateProduct(SqlConnectionStringBuilder connection, ProductionPacket productionPacket)
        {
            this.productionPacket = productionPacket;
            this._builder = connection;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCN_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Product SET CustomerName = @CustomerName WHERE ProductSN = @ProductSN", connection);
            command.Parameters.AddWithValue("@CustomerName", this.inputCN.Text);
            command.Parameters.AddWithValue("@ProductSN", this.productionPacket.ProductSN);
            try
            {
                command.ExecuteNonQuery();
                this.label1.Text = "Customer name: " + this.inputCN.Text;
            } catch
            {
                this.label1.Text = "Error updating: Please enter valid customer name";
            }
            connection.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT CustomerName FROM Product WHERE ProductSN = @ProductSN", connection);
            command.Parameters.AddWithValue("@ProductSN", this.productionPacket.ProductSN);
            String customerName = (String) command.ExecuteScalar();
            this.label1.Text = "Customer name: " + customerName;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSN_Click(object sender, EventArgs e)
        {
            
        }
    }
}
