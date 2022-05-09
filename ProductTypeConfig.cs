using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapstoneApp.ProductType;
using Microsoft.Data.SqlClient;
using static CapstoneApp.ProductType.ProductTypeObject;

namespace CapstoneApp
{
    public partial class ProductTypeConfig : Form
    {
        private static SqlConnectionStringBuilder _builder;
        private enum MoveDirection { Up = -1, Down = 1 };
        private string currentProductType;

        public ProductTypeConfig(SqlConnectionStringBuilder connection)
        {
            _builder = connection;
            this.InitializeComponent();
            this.ProductTypeComboBox.Items.Add("");
            this.ProductTypeComboBox.Items.AddRange(Menu.ProductTypeList.Keys.ToArray());
        } // ProductTypeConfig();

        /*
        (void) FormLayout configures the new window created for the product event list
        applet.
        */
        public void FormLayout()
        {
            this.Name = Constants.windowName;
            this.Text = Constants.windowName;
            this.Size = new Size(Constants.width, Constants.height);
            this.StartPosition = FormStartPosition.CenterScreen;
        } // WindowLayout();

        /*
         (void) GetProductTypes will fill the Product type dictionary using the tables within the sql database.
         */
        public static void GetProductTypes(SqlConnectionStringBuilder builder)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            string selectQuery = "SELECT * FROM ProductEvent";
            connection.Open();

            // Add New Product Type to the product Type Table
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if(!Menu.ProductTypeList.ContainsKey(reader[0].ToString()))
                        Menu.ProductTypeList.Add(reader[0].ToString(), new List<EventListItem>());

                    EventListItem item = new EventListItem
                    {
                        SeqOrder = (int)reader[2],
                        EventName = reader[1].ToString(),
                    };

                    Menu.ProductTypeList[reader[0].ToString()].Add(item);
                }
            }

            connection.Close();
        } // GetProductTypes();

        /*
         (void) SelectButton_Click updates the display window to show the selected items event list ordered by the sequence orders
         */
        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (this.ProductTypeComboBox.SelectedItem == null)
                return;
            string selectedProductType = this.ProductTypeComboBox.SelectedItem.ToString();
            this.currentProductType = selectedProductType;
            this.EventListView.Items.Clear();

            if (!Menu.ProductTypeList.ContainsKey(selectedProductType))
                return;

            List<EventListItem> eventList = Menu.ProductTypeList[selectedProductType].OrderBy(o => o.SeqOrder).ToList();
            foreach (EventListItem eventitem in eventList)
                this.EventListView.Items.Add(eventitem.EventName);

        } // SelectButton_Click();

        /*
         (void) Move_Direction_Button_Click handles reordering the selected item by moving the item up or down, depending on button, in the event list
         */
        private void MoveUpButton_Click(object sender, EventArgs e) => this.MoveListViewItems(MoveDirection.Up); // MoveUpButton_Click
        private void MoveDownButton_Click(object sender, EventArgs e) => this.MoveListViewItems(MoveDirection.Down); // MoveDownButton_Click

        /*
         (void) MoveListViewItems will handle moving items in the listview up or down depending on the direction passed
                    Before handling the move, method will check if move is valid
         */
        private void MoveListViewItems(MoveDirection direction)
        {
            int dir = (int)direction;

            bool valid = this.EventListView.SelectedItems.Count > 0 &&
                            ((direction == MoveDirection.Down && (this.EventListView.SelectedItems[0].Index < this.EventListView.Items.Count - 1))
                        || (direction == MoveDirection.Up && (this.EventListView.SelectedItems[0].Index > 0)));

            if (valid)
            {
                // add direction to determine new location in list
                ListViewItem item = this.EventListView.SelectedItems[0];
                int index = item.Index + dir;
                this.EventListView.Items.RemoveAt(item.Index);
                this.EventListView.Items.Insert(index, item);
            }
        } // MoveListViewItems();

        /*
         (void) RemoveButton_Click will remove the selected event from the list
         */
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (this.EventListView.SelectedItems.Count > 0)
            {
                this.EventListView.Items.RemoveAt(this.EventListView.SelectedItems[0].Index);
            }
        } // RemoveButton_Click();

        /*
         (void) SaveButton_Click removes the previous event list from the SQL database and will add the next event
         */
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.currentProductType == "" || this.currentProductType == null)
            {
                MessageBox.Show("No Product Type Specified, Please Use Save As");
                return;
            }
                
            DialogResult result = MessageBox.Show($"Overwrite \"{this.currentProductType}\" with current event list?", "Save", MessageBoxButtons.OKCancel);
            if (result == DialogResult.No)
                return;

            // remove old product type list and add the new one
            Menu.ProductTypeList[this.currentProductType].Clear();
            string responseMessage;
            try
            {
                SqlConnection connection = new SqlConnection(_builder.ConnectionString);
                string removeQuery = "DELETE FROM ProductEvent WHERE ProductType = @ProductType;";
                string insertQuery = "INSERT INTO ProductEvent VALUES ((SELECT * FROM ProductType WHERE ProductType=@ProductType), @EventType, @SeqOrder)";
                connection.Open();


                // Remove Previous Event List
                SqlCommand removeCommand = new SqlCommand(removeQuery, connection);
                removeCommand.Parameters.AddWithValue("@ProductType", this.currentProductType);
                removeCommand.ExecuteNonQuery();

                // Add New List to SQL database and update producttype dictionary
                for (int i = 0; i < this.EventListView.Items.Count; i++)
                {
                    EventListItem eventitem = new EventListItem
                    {
                        SeqOrder = i,
                        EventName = this.EventListView.Items[i].Text,
                    };
                    Menu.ProductTypeList[this.currentProductType].Add(eventitem);

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@ProductType", this.currentProductType);
                    insertCommand.Parameters.AddWithValue("@EventType", eventitem.EventName);
                    insertCommand.Parameters.AddWithValue("@SeqOrder", eventitem.SeqOrder);
                    insertCommand.ExecuteNonQuery();
                }

                connection.Close();
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                responseMessage = $"Error Overwiting \"{this.currentProductType}\"";
            } // catch

            responseMessage = $"\"{this.currentProductType}\" Saved Sussefully";
            // notify user of sql response
            MessageBox.Show(responseMessage);

        } // SaveButton_Click();

        /*
         (void) SaveAsButton_Click will ask the User for the new product name and then add the new product type and all events to the database
         */
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            string newProductTypeName = SmallPrompt.ShowDialog("", "Save New Product Type");
            if (newProductTypeName == "")
                return;

            Menu.ProductTypeList.Add(newProductTypeName, new List<EventListItem>());
            // add new product type to database and save events to the event list
            string responseMessage;
            try
            {
                SqlConnection connection = new SqlConnection(_builder.ConnectionString);
                string insertProductTypeQuery = "INSERT INTO ProductType values (@ProductType)";
                string insertEventQuery = "INSERT INTO ProductEvent values (@ProductType, @EventName, @SeqOrder)";
                connection.Open();

                // Add New Product Type to the product Type Table
                SqlCommand insertProductCommand = new SqlCommand(insertProductTypeQuery, connection);
                insertProductCommand.Parameters.AddWithValue("@ProductType", newProductTypeName);
                insertProductCommand.ExecuteNonQuery();

                // Add New List to SQL database and update producttype dictionary
                for (int i = 0; i < this.EventListView.Items.Count; i++)
                {
                    EventListItem eventitem = new EventListItem
                    {
                        SeqOrder = i,
                        EventName = this.EventListView.Items[i].Text,
                    };
                    Menu.ProductTypeList[newProductTypeName].Add(eventitem);

                    SqlCommand insertEventCommand = new SqlCommand(insertEventQuery, connection);
                    insertEventCommand.Parameters.AddWithValue("@ProductType", newProductTypeName);
                    insertEventCommand.Parameters.AddWithValue("@EventName", eventitem.EventName);
                    insertEventCommand.Parameters.AddWithValue("@SeqOrder", eventitem.SeqOrder);
                    insertEventCommand.ExecuteNonQuery();
                }

                connection.Close();
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                responseMessage = $"Error Writing \"{newProductTypeName}\"";
            } // catch

            responseMessage = $"\"{newProductTypeName}\" Saved Sussefully";
            // notify user of sql response
            MessageBox.Show(responseMessage);

            currentProductType = newProductTypeName;
            this.ProductTypeComboBox.Items.Add(newProductTypeName);
            this.ProductTypeComboBox.SelectedIndex = this.ProductTypeComboBox.Items.Count - 1;
        } // SaveAsButton_Click();

        /*
         (void) AddNewEventButton_Click will prompt user for the name of the new event and add it to the sql database
                    The new event will also append to the end of the currently selected event list
         */
        private void AddNewEventButton_Click(object sender, EventArgs e)
        {
            string newEventName = SmallPrompt.ShowDialog("", "Add New Event");

            if (newEventName == "")
                return;

            // add event to the listview and to SQL Database

            try
            {
                SqlConnection connection = new SqlConnection(_builder.ConnectionString);
                string insertQuery = "INSERT INTO EventType values (@EventName)";
                connection.Open();

                // Add New Product Type to the product Type Table
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@EventName", newEventName);
                insertCommand.ExecuteNonQuery();

                connection.Close();

                this.EventListView.Items.Add(newEventName);
            } // try
            catch (SqlException err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                MessageBox.Show($"Error Saving New Event to Database");
            } // catch

        } // AddNewEventButton_Click();

        /*
         (void) AddButton_Click will popup window with avaiable events and user can select with the checkbox all items that should be added to the listview
                    Once submitted all items will be added to the listview
         */
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddEvent addEvent = new AddEvent(_builder);
            addEvent.AddEventHandler += new AddEvent.AddEventsEventHandler(this.SavedHandler);
            addEvent.Show();

        } // AddButton_Click();

        private void SavedHandler(object sender, AddEventEventArgs e)
        {
            foreach(string item in e.EventList)
                this.EventListView.Items.Add(item);
        } // SavedHandler();
    }
}
