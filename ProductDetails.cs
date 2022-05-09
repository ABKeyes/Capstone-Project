using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System;
using CapstoneApp.ProductDetailWindows;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Collections.Generic;
using static CapstoneApp.ProductType.ProductTypeObject;

public class ProductDetails : Form
{
    public SqlConnectionStringBuilder _builder;
    public static string SerialNumber { get; set; }
    private string _serialNumber;
    private Label label1;
    private ToolTip toolTip1;
    private System.ComponentModel.IContainer components;
    private Label productSNLabel;
    private Label label2;
    private Button updateButton;
    private ComboBox productionStatus;
    private Panel mainPanel;
    private Panel displayPanel;
    private Panel buttonPanel;
    private Button viewDetails;
    private Button removeProduct;
    private Button addEvent;
    private Button addNote;
    private Button viewLog;
    private ComboBox updateProductType;
    private Button productTypeButton;
    private Label productTypeLabel;
    private Button addImage;
    private Button updateCustomer;
    private Button storageButton;
    public ProductionPacket PacketInfo { protected get; set; }

    /*
    Function to help pass along the data of the selected row
    */
    public ProductDetails(SqlConnectionStringBuilder connection, string serialNumber) {
        this._builder = connection;
        this.Size = new System.Drawing.Size(950, 560);
        SerialNumber = serialNumber;
        this._serialNumber = serialNumber;
        this.PacketInfo = new ProductionPacket();
    } // ProductionDetails()

    public void FormLayout()
    {
        this.WindowLayout();
        this.InitializeComponent();
        this.PopulateData();
        this.productionStatus.Items.AddRange(ProductionStatusInfo.ProductionStatuses);
        this.productionStatus.SelectedItem = this.PacketInfo.ProductionStatus;
        this.productSNLabel.Text += SerialNumber;
        this.updateProductType.DataSource = new BindingSource(Menu.ProductTypeList, null);
        this.updateProductType.SelectedValue = this.PacketInfo.ProductType; 
        this.ShowEventLog();
    } // FormLayout()

    private void WindowLayout()
    {
        this.Name = Constants.windowName;
        this.Text = Constants.windowName;
        this.StartPosition = FormStartPosition.CenterScreen;
    } // WindowLayout()

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.viewLog = new System.Windows.Forms.Button();
            this.addNote = new System.Windows.Forms.Button();
            this.addEvent = new System.Windows.Forms.Button();
            this.removeProduct = new System.Windows.Forms.Button();
            this.viewDetails = new System.Windows.Forms.Button();
            this.addImage = new System.Windows.Forms.Button();
            this.updateCustomer = new System.Windows.Forms.Button();
            this.storageButton = new System.Windows.Forms.Button();
            this.productSNLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.productionStatus = new System.Windows.Forms.ComboBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.productTypeButton = new System.Windows.Forms.Button();
            this.updateProductType = new System.Windows.Forms.ComboBox();
            this.productTypeLabel = new System.Windows.Forms.Label();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "View Product Details";
            // 
            // viewLog
            // 
            this.viewLog.BackColor = System.Drawing.Color.DimGray;
            this.viewLog.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.viewLog.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.viewLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.viewLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.viewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewLog.Location = new System.Drawing.Point(0, 0);
            this.viewLog.Margin = new System.Windows.Forms.Padding(0);
            this.viewLog.Name = "viewLog";
            this.viewLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.viewLog.Size = new System.Drawing.Size(119, 26);
            this.viewLog.TabIndex = 0;
            this.viewLog.Text = "View Log";
            this.toolTip1.SetToolTip(this.viewLog, "View Product Log");
            this.viewLog.UseVisualStyleBackColor = false;
            this.viewLog.Click += new System.EventHandler(this.ViewLog_Click);
            // 
            // addNote
            // 
            this.addNote.BackColor = System.Drawing.Color.DimGray;
            this.addNote.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.addNote.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.addNote.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addNote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNote.Location = new System.Drawing.Point(0, 95);
            this.addNote.Name = "addNote";
            this.addNote.Size = new System.Drawing.Size(119, 23);
            this.addNote.TabIndex = 3;
            this.addNote.Text = "Add Note";
            this.toolTip1.SetToolTip(this.addNote, "Add Note to Log");
            this.addNote.UseVisualStyleBackColor = false;
            this.addNote.Click += new System.EventHandler(this.AddNote_Click);
            // 
            // addEvent
            // 
            this.addEvent.BackColor = System.Drawing.Color.DimGray;
            this.addEvent.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.addEvent.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.addEvent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addEvent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEvent.Location = new System.Drawing.Point(0, 118);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(119, 23);
            this.addEvent.TabIndex = 4;
            this.addEvent.Text = "Add Event";
            this.toolTip1.SetToolTip(this.addEvent, "Add Event to the Log");
            this.addEvent.UseVisualStyleBackColor = false;
            this.addEvent.Click += new System.EventHandler(this.AddEvent_Click);
            // 
            // removeProduct
            // 
            this.removeProduct.BackColor = System.Drawing.Color.DimGray;
            this.removeProduct.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.removeProduct.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.removeProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.removeProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.removeProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeProduct.Location = new System.Drawing.Point(0, 164);
            this.removeProduct.Name = "removeProduct";
            this.removeProduct.Size = new System.Drawing.Size(119, 23);
            this.removeProduct.TabIndex = 6;
            this.removeProduct.Text = "Remove";
            this.toolTip1.SetToolTip(this.removeProduct, "Remove Product from Database");
            this.removeProduct.UseVisualStyleBackColor = false;
            this.removeProduct.Click += new System.EventHandler(this.RemoveProduct_Click);
            // 
            // viewDetails
            // 
            this.viewDetails.BackColor = System.Drawing.Color.DimGray;
            this.viewDetails.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.viewDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.viewDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.viewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewDetails.Location = new System.Drawing.Point(0, 26);
            this.viewDetails.Name = "viewDetails";
            this.viewDetails.Size = new System.Drawing.Size(119, 23);
            this.viewDetails.TabIndex = 1;
            this.viewDetails.Text = "View Details";
            this.toolTip1.SetToolTip(this.viewDetails, "View Product Details");
            this.viewDetails.UseVisualStyleBackColor = false;
            this.viewDetails.Click += new System.EventHandler(this.ViewDetails_Click);
            // 
            // addImage
            // 
            this.addImage.BackColor = System.Drawing.Color.DimGray;
            this.addImage.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.addImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addImage.Location = new System.Drawing.Point(0, 141);
            this.addImage.Name = "addImage";
            this.addImage.Size = new System.Drawing.Size(119, 23);
            this.addImage.TabIndex = 5;
            this.addImage.Text = "Add Image";
            this.toolTip1.SetToolTip(this.addImage, "Add Image to the Log");
            this.addImage.UseVisualStyleBackColor = false;
            this.addImage.Click += new System.EventHandler(this.AddImage_Click);
            // 
            // updateCustomer
            // 
            this.updateCustomer.BackColor = System.Drawing.Color.DimGray;
            this.updateCustomer.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.updateCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.updateCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.updateCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateCustomer.Location = new System.Drawing.Point(0, 49);
            this.updateCustomer.Name = "updateCustomer";
            this.updateCustomer.Size = new System.Drawing.Size(119, 23);
            this.updateCustomer.TabIndex = 7;
            this.updateCustomer.Text = "Update Customer";
            this.toolTip1.SetToolTip(this.updateCustomer, "View Product Details");
            this.updateCustomer.UseVisualStyleBackColor = false;
            this.updateCustomer.Click += new System.EventHandler(this.button1_Click);
            // 
            // storageButton
            // 
            this.storageButton.BackColor = System.Drawing.Color.DimGray;
            this.storageButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.storageButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.storageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.storageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.storageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.storageButton.Location = new System.Drawing.Point(0, 72);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(119, 23);
            this.storageButton.TabIndex = 5;
            this.storageButton.Text = "Manage Storage";
            this.toolTip1.SetToolTip(this.storageButton, "Remove Product from Database");
            this.storageButton.UseVisualStyleBackColor = false;
            this.storageButton.Click += new System.EventHandler(this.StorageButton_Click);
            // 
            // productSNLabel
            // 
            this.productSNLabel.AutoSize = true;
            this.productSNLabel.Location = new System.Drawing.Point(12, 35);
            this.productSNLabel.Name = "productSNLabel";
            this.productSNLabel.Size = new System.Drawing.Size(133, 15);
            this.productSNLabel.TabIndex = 4;
            this.productSNLabel.Text = "Product Serial Number: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Status:";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(184, 59);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 25);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.StatusUpdateButton_Click);
            // 
            // productionStatus
            // 
            this.productionStatus.FormattingEnabled = true;
            this.productionStatus.Location = new System.Drawing.Point(60, 59);
            this.productionStatus.Name = "productionStatus";
            this.productionStatus.Size = new System.Drawing.Size(121, 23);
            this.productionStatus.TabIndex = 7;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Controls.Add(this.productTypeButton);
            this.mainPanel.Controls.Add(this.updateButton);
            this.mainPanel.Controls.Add(this.updateProductType);
            this.mainPanel.Controls.Add(this.productTypeLabel);
            this.mainPanel.Controls.Add(this.displayPanel);
            this.mainPanel.Controls.Add(this.buttonPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(0, 90, 0, 0);
            this.mainPanel.Size = new System.Drawing.Size(874, 489);
            this.mainPanel.TabIndex = 9;
            // 
            // productTypeButton
            // 
            this.productTypeButton.Location = new System.Drawing.Point(530, 59);
            this.productTypeButton.Name = "productTypeButton";
            this.productTypeButton.Size = new System.Drawing.Size(75, 25);
            this.productTypeButton.TabIndex = 11;
            this.productTypeButton.Text = "Update";
            this.productTypeButton.UseVisualStyleBackColor = true;
            this.productTypeButton.Click += new System.EventHandler(this.TypeUpdateButton_Click);
            // 
            // updateProductType
            // 
            this.updateProductType.DisplayMember = "Key";
            this.updateProductType.DropDownWidth = 121;
            this.updateProductType.FormattingEnabled = true;
            this.updateProductType.Location = new System.Drawing.Point(373, 59);
            this.updateProductType.Name = "updateProductType";
            this.updateProductType.Size = new System.Drawing.Size(151, 23);
            this.updateProductType.TabIndex = 9;
            this.updateProductType.ValueMember = "Key";
            // 
            // productTypeLabel
            // 
            this.productTypeLabel.AutoSize = true;
            this.productTypeLabel.Location = new System.Drawing.Point(282, 63);
            this.productTypeLabel.Name = "productTypeLabel";
            this.productTypeLabel.Size = new System.Drawing.Size(79, 15);
            this.productTypeLabel.TabIndex = 10;
            this.productTypeLabel.Text = "Product Type:";
            // 
            // displayPanel
            // 
            this.displayPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.displayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayPanel.Location = new System.Drawing.Point(119, 90);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(755, 399);
            this.displayPanel.TabIndex = 8;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.updateCustomer);
            this.buttonPanel.Controls.Add(this.viewDetails);
            this.buttonPanel.Controls.Add(this.addEvent);
            this.buttonPanel.Controls.Add(this.addNote);
            this.buttonPanel.Controls.Add(this.viewLog);
            this.buttonPanel.Controls.Add(this.addImage);
            this.buttonPanel.Controls.Add(this.removeProduct);
            this.buttonPanel.Controls.Add(this.storageButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPanel.Location = new System.Drawing.Point(0, 90);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(119, 399);
            this.buttonPanel.TabIndex = 1;
            // 
            // ProductDetails
            // 
            this.ClientSize = new System.Drawing.Size(874, 489);
            this.Controls.Add(this.productionStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productSNLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainPanel);
            this.Name = "ProductDetails";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    } // Initialize_Components();

    /* 
     StatusUpdateButton_click updates the production status of the product currently being viewed
     */
    private void StatusUpdateButton_Click(object sender, EventArgs e)
    {
        // get new production status
        string productionStatusInputString = this.productionStatus.SelectedItem.ToString();

        // update status in the sql database
        string responseMessage;
        try
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();
            string updateQuery = "UPDATE Product SET ProductionStatus = @ProductionStatus WHERE ProductSN = @ProductSN;";
            
            // Add Product to Product Table
            SqlCommand productCommand = new SqlCommand(updateQuery, connection);
            productCommand.Parameters.AddWithValue("@ProductionStatus", productionStatusInputString);
            productCommand.Parameters.AddWithValue("@ProductSN", SerialNumber);
            productCommand.ExecuteNonQuery();

            connection.Close();
            responseMessage = "Status Updated Successfully";
        } // try
        catch (SqlException err)
        {
            System.Diagnostics.Debug.WriteLine(err.ToString());
            responseMessage = "Something Went Wrong, Please Try Again";
        } // catch

        // notify user of sql response
        MessageBox.Show(responseMessage);

        // write update to the log and update packet info
        this.PacketInfo.ProductionStatus = productionStatusInputString;
        WriteUpdatesToLog(this._builder, this.PacketInfo.ProductSN, string.Format("Updated Production Status To: {0}", this.PacketInfo.ProductionStatus), "Status Change");
        this.viewLog.PerformClick();

    } // StatusUpdateButton_Click

    /* 
     TypeUpdateButton_click updates the production type of the product currently being viewed
     */
    private void TypeUpdateButton_Click(object sender, EventArgs e)
    {
        // get new product type
        KeyValuePair<string, List<EventListItem>>selectedEntry = (KeyValuePair<string, List<EventListItem>>)this.updateProductType.SelectedItem;

        // get selected Key
        string productTypeInputString = selectedEntry.Key;

        // update status in the sql database
        string responseMessage;
        try
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();
            string updateQuery = "UPDATE Product SET ProductType = @ProductType WHERE ProductSN = @ProductSN;";

            // Add Product to Product Table
            SqlCommand productCommand = new SqlCommand(updateQuery, connection);
            productCommand.Parameters.AddWithValue("@ProductType", productTypeInputString);
            productCommand.Parameters.AddWithValue("@ProductSN", SerialNumber);
            productCommand.ExecuteNonQuery();

            connection.Close();
            responseMessage = "Status Updated Successfully";
        } // try
        catch (SqlException err)
        {
            System.Diagnostics.Debug.WriteLine(err.ToString());
            responseMessage = "Something Went Wrong, Please Try Again";
        } // catch

        // notify user of sql response
        MessageBox.Show(responseMessage);

        // write update to the log and update packet info
        this.PacketInfo.ProductType = productTypeInputString;
        WriteUpdatesToLog(this._builder, this.PacketInfo.ProductSN, string.Format("Updated Product Type To: {0}", this.PacketInfo.ProductType), "Type Change");
        this.viewLog.PerformClick();

    } // TypeUpdateButton_Click

    /*
     addEvent_click will create an instance of the eventlog and display it in the display pannel.
        This function also hides unneeded buttons such as the back button and autofills the product
        serial number
     */
    private void AddEvent_Click(object sender, EventArgs e)
    {
        this.displayPanel.Controls.Clear();
        EventLog addEvent = new(this._builder);
        addEvent.FormLayout();
        addEvent.Dock = DockStyle.Fill;
        addEvent.FormBorderStyle = FormBorderStyle.None;
        addEvent.TopLevel = false;
        addEvent.Parent = this.displayPanel;
        this.displayPanel.Controls.Add(addEvent);
        addEvent.SearchEvent.Text = this.PacketInfo.ProductSN;
        addEvent.Show();
        addEvent.SearchButton.PerformClick();
    } // AddEvent_Click

    /*
     ViewLog_Click and ShowEventLog will create an instance of the logwindow and display it in the display pannel.
     */
    private void ViewLog_Click(object sender, EventArgs e) => this.ShowEventLog();
    private void ShowEventLog()
    {
        this.displayPanel.Controls.Clear();
        LogWindow logWindow = new(this._builder);
        logWindow.Dock = DockStyle.Fill;
        logWindow.FormBorderStyle = FormBorderStyle.None;
        logWindow.TopLevel = false;
        logWindow.Parent = this.displayPanel;
        this.displayPanel.Controls.Add(logWindow);
        logWindow.Show();
    } // ShowEventLog

    /*
     AddNote_Click will update the display panel with an instance of the AddNoteWindow.
     */
    private void AddNote_Click(object sender, EventArgs e)
    {
        this.displayPanel.Controls.Clear();
        AddNoteWindow noteWindow = new(this._builder);
        noteWindow.Dock = DockStyle.Fill;
        noteWindow.FormBorderStyle = FormBorderStyle.None;
        noteWindow.TopLevel = false;
        noteWindow.Parent = this.displayPanel;
        this.displayPanel.Controls.Add(noteWindow);
        noteWindow.Show();
    } // AddNote_Click

    /*
     AddImage_Click will update the display panel with an instance of the AddImageWindow.
     */
    private void AddImage_Click(object sender, EventArgs e)
    {
        this.displayPanel.Controls.Clear();
        AddImageWindow imageWindow = new AddImageWindow(_builder, this._serialNumber);
        imageWindow.Dock = DockStyle.Fill;
        imageWindow.Parent = this.displayPanel;
        this.displayPanel.Controls.Add(imageWindow);
        imageWindow.Show();
    } // AddImage_Click

    /*
       Function for removing entries from the products table. Non admin accounts will only be able
       to make a request that an admin delete the product while an admin account will be able to do
       a deletion when this function is called.
    */
    private void RemoveProduct_Click(object sender, EventArgs e)
    {
        if (UserGlobals.userType == "admin")
        {
            // populate confirmation
            DialogResult dialogResult = MessageBox.Show("Are you sure? This command cannot be undone.", "Remove Product", MessageBoxButtons.YesNo);

            // handle response
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // grab all of the SQL information for the serial number
                    SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                    string productDataQuery = "DELETE FROM Product WHERE ProductSN= @ProductSN;";
                    SqlCommand productCommand = new SqlCommand(productDataQuery, connection);
                    productCommand.Parameters.AddWithValue("@ProductSN", SerialNumber);
                    connection.Open();
                    productCommand.ExecuteNonQuery();
                    connection.Close();
                } // try
                catch (SqlException err)
                {
                    System.Diagnostics.Debug.WriteLine(err.ToString());
                    // notify user of sql error
                    MessageBox.Show("Error Removing Product, Please Try Again");
                    return;
                } // catch

                MessageBox.Show("Product Removed Successfully");
                this.DisplaySearchWindow();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        else
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            String sql = "INSERT INTO DeleteAudit (Name, Position, LogTime, DeletedSN) VALUES (@Name, @Position, @LogTime, @DeletedSN";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", UserGlobals.userName);
            command.Parameters.AddWithValue("@Position", UserGlobals.userType);
            command.Parameters.AddWithValue("@LogTime", DateTime.Now);
            command.Parameters.AddWithValue("@DeletedSN", this.PacketInfo.ProductSN);
            command.ExecuteNonQuery();
        }
    } // RemoveProduct_Click

    private void DisplaySearchWindow() => Menu.SwitchToPartHistory(this.ParentForm as Menu);

    /*
    PopulateData will update the Product Packet that is used to display
    product details within the log page.
    */
    private void PopulateData()
    {
        try
        {
            // grab all of the SQL information for the serial number
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();
            string productDataQuery = "Select * FROM Product LEFT JOIN Bin ON Product.BinID = Bin.BinID LEFT JOIN Shelf ON Bin.ShelfID = Shelf.ShelfID LEFT JOIN Rack On Shelf.RackID = Rack.RackID WHERE ProductSN = @ProductSN;";
            SqlCommand productCommand = new SqlCommand(productDataQuery, connection);
            productCommand.Parameters.AddWithValue("@ProductSN", SerialNumber);
            SqlDataReader reader = productCommand.ExecuteReader();
            // assign all of the fields to the product information packet that can be passed to other pages for later use
            while (reader.Read())
            {
                this.PacketInfo.ProductSN = SerialNumber;
                this.PacketInfo.AligniSN = reader["AligniSN"].ToString();
                this.PacketInfo.FishbowlSN = reader["FishbowlSN"].ToString();
                this.PacketInfo.PreviousSN = reader["PreviousSN"].ToString();
                this.PacketInfo.ProductionStatus = reader["ProductionStatus"].ToString();
                this.PacketInfo.ProductType = reader["ProductType"].ToString();
                this.PacketInfo.BinID = reader["BinID"].ToString();
                this.PacketInfo.RackID = reader["RackID"].ToString();
                this.PacketInfo.ShelfID = reader["ShelfID"].ToString();
                this.PacketInfo.RackID = reader["RackID"].ToString();
                this.PacketInfo.StoreroomID = reader["StoreroomID"].ToString();
                this.PacketInfo.WarratyStart = (reader["WarrantyStart"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(reader["WarrantyStart"]);
                this.PacketInfo.WarrantyEnd = (reader["WarrantyEnd"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(reader["WarrantyEnd"]);
                this.PacketInfo.WarrantyActive = (this.PacketInfo.WarrantyEnd >= DateTime.Today) ? true : false;
            }// while(reader.Read())

            connection.Close();
        } // try
        catch (SqlException err)
        {
            System.Diagnostics.Debug.WriteLine(err.ToString());
            // notify user of sql error
            MessageBox.Show("Error getting product details, Please Try Again");
        } // catch

    } // PopulateData()

    /*
     ViewDetails_Click creates an instance of the product details window and displays that information in the display panel
     */
    private void ViewDetails_Click(object sender, EventArgs e)
    {
        this.displayPanel.Controls.Clear();
        DetailsWindow detailWindow = new(this._builder, this.PacketInfo);
        detailWindow.Parent = this.displayPanel;
        this.displayPanel.Controls.Add(detailWindow);
        detailWindow.Dock = DockStyle.Fill;
        detailWindow.Show();
    } // ViewDetails_Click

    /*
     * WriteUpdatesToLog can be used to add updates to the production log
     *          new logTypes can be added through the GUI - Within Modify Event List -> Click add New Event
     */
    public static void WriteUpdatesToLog(SqlConnectionStringBuilder builder, string productSN, string logDescription, string logType)
    {
        try
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            // write message to the log for the product
            string updateQuery = "INSERT INTO Event(ProductSN, Author, Description, Type) Values (@ProductSN, @Author, @Description, @Type)";

            // Add Product to Product Table
            SqlCommand productCommand = new SqlCommand(updateQuery, connection);
            productCommand.Parameters.AddWithValue("@ProductSN", productSN);
            productCommand.Parameters.AddWithValue("@Author", UserGlobals.userName);
            productCommand.Parameters.AddWithValue("@Description", logDescription);
            productCommand.Parameters.AddWithValue("@Type", logType);
            productCommand.ExecuteNonQuery();

            connection.Close();
        } // try
        catch (SqlException err)
        {
            System.Diagnostics.Debug.WriteLine(err.ToString());
        } // catch
    } // WriteUpdatesToLog

    private void button1_Click(object sender, EventArgs e)
    {
        this.displayPanel.Controls.Clear();
        UpdateProduct updateProduct = new(this._builder, this.PacketInfo);
        updateProduct.Parent = this.displayPanel;
        this.displayPanel.Controls.Add(updateProduct);
        updateProduct.Show();
    }

    private void StorageButton_Click(object sender, EventArgs e)
    {
        this.displayPanel.Controls.Clear();
        ManageStorageWindow storageWindow = new(this._builder, this.PacketInfo);
        storageWindow.FormBorderStyle = FormBorderStyle.None;
        storageWindow.TopLevel = false;
        storageWindow.Parent = this.displayPanel;
        this.displayPanel.Controls.Add(storageWindow);
        storageWindow.Show();
    }
}

public class ProductionPacket
{
    public string ProductSN { get; set; }
    public string AligniSN { get; set; }
    public string FishbowlSN { get; set; }
    public string PreviousSN { get; set; }
    public DateTime WarratyStart { get; set; }
    public bool WarrantyActive { get; set; }
    public string ProductionStatus { get; set; }
    public string ProductType { get; set; }
    public DateTime WarrantyEnd { get; set; }
    public string BinID { get; set; }
    public string RackID {  get; set; }
    public string ShelfID { get; set; }
    public string StoreroomID { get; set; }
} // ProductionPacket
