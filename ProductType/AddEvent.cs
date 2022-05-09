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

namespace CapstoneApp.ProductType
{
    public partial class AddEvent : Form
    {
        private SqlConnectionStringBuilder _builder;
        public delegate void AddEventsEventHandler(object sender, AddEventEventArgs e);
        public event AddEventsEventHandler AddEventHandler;
        public List<string> EventList = new List<string>();

        public AddEvent(SqlConnectionStringBuilder connection)
        {
            this._builder = connection;
            this.InitializeComponent();
            this.GetCurrentEventList();
        }

        private void GetCurrentEventList()
        {
            try
            {
                SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                string selectQuery = "SELECT * FROM EventType";
                connection.Open();

                // Add New Product Type to the product Type Table
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.EventListClickBox.Items.Add(reader[0].ToString());
                    }
                }

                connection.Close();
            } // try
            catch (SqlException err)
        {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                MessageBox.Show($"Error Getting Event List");
            } // catch
        }

        /*
         (void) CancelButton_Click returns and closes current window
         */
        private void CancelButton_Click(object sender, EventArgs e) => this.Close(); // CancelButton_Click

        /*
         (void) SubmitButton_Click will send all of the selected events back to the original sender page
         */
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string[] selectedItems = this.EventListClickBox.CheckedItems.Cast<string>().ToArray();
            AddEventEventArgs addEvent = new AddEventEventArgs() { EventList = selectedItems };
            AddEventHandler(this, addEvent);
            this.Close();
        } // SubmitButton_Click

        private void keywordTextbox_TextChanged(object sender, EventArgs e)
        {
            string keyword = this.keywordTextbox.Text;

            this.EventListClickBox.Items.Clear();
            this.GetCurrentEventList();

             List<string> currentEvents = new List<string> { };
             foreach (string eventItem in this.EventListClickBox.Items)
             {
                if(eventItem.ToLower().Contains(keyword.ToLower()))
                    currentEvents.Add(eventItem);
             }

             this.EventListClickBox.Items.Clear();
             this.EventListClickBox.Items.AddRange(currentEvents.ToArray());
        }
    }

    public class AddEventEventArgs : EventArgs
    {
        public string[] EventList{ get; set; }
    }
}
