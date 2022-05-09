using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapstoneApp;
using CapstoneProject.Properties;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using static CapstoneApp.ProductType.ProductTypeObject;

/*
The Menu class is used to build the initial window containing the list of
applets to use.
*/
public class Menu : Form
{

    public static Dictionary<string, List<EventListItem>> ProductTypeList = new Dictionary<string, List<EventListItem>>();
    public Panel DisplayPanel;
    private SqlConnectionStringBuilder _builder;
    private SplitContainer mainDisplay;
    private ListView productionStatusListView;
    private Button searchButton;
    private Button exitButton;
    private Button eventButton;
    private Button addPart;
    private Button editEventButton;
    private Button customerServiceButton;
    private ColumnHeader productType;
    private ColumnHeader serialNumber;
    private ColumnHeader customerName;
    private Button storageButton;
    private Button adminButton;
    private string userType = "";


    public Menu(SqlConnectionStringBuilder connection)
    {
        this._builder = connection;
        this.userType = UserGlobals.userType;
        if (ProductTypeList.Values.Count == 0) 
            ProductTypeConfig.GetProductTypes(this._builder);
    } // Menu()

    public void FormLayout()
    {
        this.WindowLayout();
        this.InitializeComponent();
        this.UpdateDisplay();
        this.AddTreeView();
    } // FormLayout()

    /* UpdateDisplay will hide any buttons that are not accessible to the user based on their userType
     *          The Enabled command is not nessecary, but placed incase the visible property doesn't apply
     */
    private void UpdateDisplay()
    {
        switch (this.userType)
        {
            case "admin":
                //this.customerServiceButton.Visible = false;
                //this.customerServiceButton.Enabled = false;
                this.adminButton.Visible = true;
                this.adminButton.Enabled = true;
                break;
            case "customer service":
                this.searchButton.Visible = false;
                this.searchButton.Enabled = false;
                this.editEventButton.Visible = false;
                this.editEventButton.Enabled = false;
                this.addPart.Visible = false;
                this.addPart.Enabled = false;
                this.eventButton.Visible = false;
                this.eventButton.Enabled = false;
                break;
            case "engineering":
                this.customerServiceButton.Enabled = false;
                this.customerServiceButton.Visible = false;
                this.editEventButton.Enabled = false;
                this.editEventButton.Visible = false;
                break;
            default:
                break;
        }
    }
    /*
    (void) WindowLayout configures the window for the initial applet.
    */
    void WindowLayout()
    {
        this.Name = Constants.windowName;
        this.Text = Constants.windowName;
        this.BackColor = Color.White;
        this.Size = new Size(1000, 850);
        this.StartPosition = FormStartPosition.CenterScreen;
    } // WindowLayout()
    
    /*
    (void) SwitchToSlimPickens opens the Slim Pickens application and keeps
    the current window open.
    */

    /*
    (void) SwitchToSlimPickens opens the Slim Pickens application and keeps
    the current window open.
    */
    public void SwitchToProductTypeConfig(object sender, System.EventArgs e)
    {
        this.DisplayPanel.Controls.Clear();
        ProductTypeConfig productType = new(this._builder);
        productType.FormBorderStyle = FormBorderStyle.None;
        productType.TopLevel = false;
        productType.Parent = this.DisplayPanel;
        productType.Dock = DockStyle.Fill;
        productType.FormLayout();
        this.DisplayPanel.Controls.Add(productType);
        productType.Show();
    } // SwitchToProductTypeConfig()

    /*
    (void) SwitchToPartHistory opens the search applet application window and
    closes the current window.
    */
    private void SwitchToPartHistory(object sender, EventArgs e) => SwitchToPartHistory(this);
   public static void SwitchToPartHistory(Menu control)
    {
        //Menu menu = sender as Menu;
        control.DisplayPanel.Controls.Clear();
        PartHistory history = new PartHistory(control._builder)
        {
            Parent = control,
            Dock = DockStyle.Fill
        };
        history.FormLayout();
        control.DisplayPanel.Controls.Add(history);
        history.Show();
    } // SwitchToPartHistory()

    /*
    (void) SwitchToAddPart opens the AddPart applet application window and
    closes the current window.
    */
    public void SwitchToAddPart(object sender, System.EventArgs e)
    {
        this.DisplayPanel.Controls.Clear();
        AddPart newPart = new(this._builder);
        newPart.FormBorderStyle = FormBorderStyle.None;
        newPart.TopLevel = false;
        newPart.Parent = this.DisplayPanel;
        newPart.Dock = DockStyle.Fill;
        newPart.FormLayout();
        this.DisplayPanel.Controls.Add(newPart);
        newPart.Show();
    } //SwitchToAddPart()

    /*
    (void) SwitchToEventLog opens the EventLog applet application window and
    closes the current window.
    */
    public void SwitchToEventLog(object sender, System.EventArgs e)
    {
        this.DisplayPanel.Controls.Clear();
        EventLog eventLog = new(this._builder);
        eventLog.FormBorderStyle = FormBorderStyle.None;
        eventLog.TopLevel = false;
        eventLog.Parent = this.DisplayPanel;
        eventLog.Dock = DockStyle.Fill;
        eventLog.FormLayout();
        this.DisplayPanel.Controls.Add(eventLog);
        eventLog.Show();      
    } //SwitchToEventLog()

    /*
    (void) SwitchToCustomerService opens the CustomerService applet application window and
    closes the current window.
    */
    private void SwitchToCustomerService(object sender, System.EventArgs e)
    {
        this.DisplayPanel.Controls.Clear();
        CustomerService customerService = new(this._builder);
        customerService.FormBorderStyle = FormBorderStyle.None;
        customerService.TopLevel = false;
        customerService.Parent = this.DisplayPanel;
        customerService.Dock = DockStyle.Fill;
        customerService.FormLayout();
        this.DisplayPanel.Controls.Add(customerService);
        customerService.Show();
    } //SwitchToCustomerService

    /*
     (void) SwitchToModifyStorage opens the Modify Storage applet within the application
    allowing the user to make changes.
    */
    private void SwitchToModifyStorage(object sender, EventArgs e)
    {
        this.DisplayPanel.Controls.Clear();
        ModifyStorage modifyStorage = new(this._builder);
        modifyStorage.FormBorderStyle = FormBorderStyle.None;
        modifyStorage.TopLevel = false;
        modifyStorage.Parent = this.DisplayPanel;
        modifyStorage.Dock = DockStyle.Fill;
        this.DisplayPanel.Controls.Add(modifyStorage);
        modifyStorage.Show();
    } //SwitchToModifyStorage

    /*
    (void) Logout opens the Login applet application window and
    closes the current window.
    */
    private void Logout(object sender, System.EventArgs e)
    {
        Application.Restart();
    }

    /// <summary>
    /// adminButton_Click opens the admin applet within the application allowing the user to control user logins.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void adminButton_Click(object sender, EventArgs e)
    {
        this.DisplayPanel.Controls.Clear();
        Admin admin = new(this._builder);
        admin.FormBorderStyle = FormBorderStyle.None;
        admin.TopLevel = false;
        admin.Parent = this.DisplayPanel;
        admin.Dock = DockStyle.Fill;
        this.DisplayPanel.Controls.Add(admin);
        admin.Show();

    }

    /* AutoGenerated Code from Designer - Use Caution when modifying - */
    private void InitializeComponent()
    {
            this.mainDisplay = new System.Windows.Forms.SplitContainer();
            this.exitButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.storageButton = new System.Windows.Forms.Button();
            this.editEventButton = new System.Windows.Forms.Button();
            this.eventButton = new System.Windows.Forms.Button();
            this.addPart = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.customerServiceButton = new System.Windows.Forms.Button();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.productionStatusListView = new System.Windows.Forms.ListView();
            this.productType = new System.Windows.Forms.ColumnHeader();
            this.serialNumber = new System.Windows.Forms.ColumnHeader();
            this.customerName = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.mainDisplay)).BeginInit();
            this.mainDisplay.Panel1.SuspendLayout();
            this.mainDisplay.Panel2.SuspendLayout();
            this.mainDisplay.SuspendLayout();
            this.DisplayPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDisplay
            // 
            this.mainDisplay.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.mainDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDisplay.Location = new System.Drawing.Point(0, 0);
            this.mainDisplay.Name = "mainDisplay";
            this.mainDisplay.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainDisplay.Panel1
            // 
            this.mainDisplay.Panel1.Controls.Add(this.exitButton);
            this.mainDisplay.Panel1.Controls.Add(this.adminButton);
            this.mainDisplay.Panel1.Controls.Add(this.storageButton);
            this.mainDisplay.Panel1.Controls.Add(this.editEventButton);
            this.mainDisplay.Panel1.Controls.Add(this.eventButton);
            this.mainDisplay.Panel1.Controls.Add(this.addPart);
            this.mainDisplay.Panel1.Controls.Add(this.searchButton);
            this.mainDisplay.Panel1.Controls.Add(this.customerServiceButton);
            this.mainDisplay.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // mainDisplay.Panel2
            // 
            this.mainDisplay.Panel2.Controls.Add(this.DisplayPanel);
            this.mainDisplay.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainDisplay.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainDisplay.Size = new System.Drawing.Size(972, 621);
            this.mainDisplay.SplitterDistance = 114;
            this.mainDisplay.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = global::CapstoneProject.Properties.Resources.SignOut;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(700, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 114);
            this.exitButton.TabIndex = 3;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.Logout);
            // 
            // adminButton
            // 
            this.adminButton.BackgroundImage = global::CapstoneProject.Properties.Resources.ModifyUsers;
            this.adminButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.adminButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.adminButton.Enabled = false;
            this.adminButton.FlatAppearance.BorderSize = 0;
            this.adminButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.adminButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminButton.Location = new System.Drawing.Point(600, 0);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(100, 114);
            this.adminButton.TabIndex = 8;
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Visible = false;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // storageButton
            // 
            this.storageButton.BackgroundImage = global::CapstoneProject.Properties.Resources.ManageStorage;
            this.storageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.storageButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.storageButton.FlatAppearance.BorderSize = 0;
            this.storageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.storageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.storageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.storageButton.Location = new System.Drawing.Point(500, 0);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(100, 114);
            this.storageButton.TabIndex = 7;
            this.storageButton.UseVisualStyleBackColor = true;
            this.storageButton.Click += new System.EventHandler(this.SwitchToModifyStorage);
            // 
            // editEventButton
            // 
            this.editEventButton.BackgroundImage = global::CapstoneProject.Properties.Resources.UpdateProductType;
            this.editEventButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editEventButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.editEventButton.FlatAppearance.BorderSize = 0;
            this.editEventButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.editEventButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.editEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editEventButton.Location = new System.Drawing.Point(400, 0);
            this.editEventButton.Name = "editEventButton";
            this.editEventButton.Size = new System.Drawing.Size(100, 114);
            this.editEventButton.TabIndex = 4;
            this.editEventButton.UseVisualStyleBackColor = true;
            this.editEventButton.Click += new System.EventHandler(this.SwitchToProductTypeConfig);
            // 
            // eventButton
            // 
            this.eventButton.BackgroundImage = global::CapstoneProject.Properties.Resources._event;
            this.eventButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eventButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.eventButton.FlatAppearance.BorderSize = 0;
            this.eventButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.eventButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.eventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventButton.Location = new System.Drawing.Point(300, 0);
            this.eventButton.Name = "eventButton";
            this.eventButton.Size = new System.Drawing.Size(100, 114);
            this.eventButton.TabIndex = 2;
            this.eventButton.UseVisualStyleBackColor = true;
            this.eventButton.Click += new System.EventHandler(this.SwitchToEventLog);
            // 
            // addPart
            // 
            this.addPart.BackgroundImage = global::CapstoneProject.Properties.Resources.addPart;
            this.addPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addPart.Dock = System.Windows.Forms.DockStyle.Left;
            this.addPart.FlatAppearance.BorderSize = 0;
            this.addPart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addPart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPart.Location = new System.Drawing.Point(200, 0);
            this.addPart.Name = "addPart";
            this.addPart.Size = new System.Drawing.Size(100, 114);
            this.addPart.TabIndex = 1;
            this.addPart.UseVisualStyleBackColor = true;
            this.addPart.Click += new System.EventHandler(this.SwitchToAddPart);
            // 
            // searchButton
            // 
            this.searchButton.BackgroundImage = global::CapstoneProject.Properties.Resources.Search;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(100, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 114);
            this.searchButton.TabIndex = 0;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SwitchToPartHistory);
            // 
            // customerServiceButton
            // 
            this.customerServiceButton.BackgroundImage = global::CapstoneProject.Properties.Resources.CustomerService;
            this.customerServiceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customerServiceButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.customerServiceButton.FlatAppearance.BorderSize = 0;
            this.customerServiceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.customerServiceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.customerServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customerServiceButton.Location = new System.Drawing.Point(0, 0);
            this.customerServiceButton.Name = "customerServiceButton";
            this.customerServiceButton.Size = new System.Drawing.Size(100, 114);
            this.customerServiceButton.TabIndex = 6;
            this.customerServiceButton.UseVisualStyleBackColor = true;
            this.customerServiceButton.Click += new System.EventHandler(this.SwitchToCustomerService);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.Controls.Add(this.productionStatusListView);
            this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayPanel.Location = new System.Drawing.Point(0, 0);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(972, 503);
            this.DisplayPanel.TabIndex = 1;
            // 
            // productionStatusListView
            // 
            this.productionStatusListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.productionStatusListView.AllowDrop = true;
            this.productionStatusListView.AutoArrange = false;
            this.productionStatusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productType,
            this.serialNumber,
            this.customerName});
            this.productionStatusListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productionStatusListView.HideSelection = false;
            this.productionStatusListView.Location = new System.Drawing.Point(0, 0);
            this.productionStatusListView.Name = "productionStatusListView";
            this.productionStatusListView.Size = new System.Drawing.Size(972, 503);
            this.productionStatusListView.TabIndex = 0;
            this.productionStatusListView.UseCompatibleStateImageBehavior = false;
            this.productionStatusListView.View = System.Windows.Forms.View.Tile;
            // 
            // productType
            // 
            this.productType.Text = "Product Type";
            // 
            // serialNumber
            // 
            this.serialNumber.Text = "Serial Number";
            // 
            // customerName
            // 
            this.customerName.Text = "Customer Name";
            // 
            // Menu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(972, 621);
            this.Controls.Add(this.mainDisplay);
            this.Name = "Menu";
            this.mainDisplay.Panel1.ResumeLayout(false);
            this.mainDisplay.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDisplay)).EndInit();
            this.mainDisplay.ResumeLayout(false);
            this.DisplayPanel.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    /*
     * AddTreeView takes the products from the sql database and displays the contents 
     *  within a treeview;
     */
    private void AddTreeView()
    {
        DataSet productDataSet = new();

        foreach(string status in ProductionStatusInfo.ProductionStatuses)
            this.productionStatusListView.Groups.Add(new ListViewGroup(status));

        // grab data from database
        try
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            string productDataQuery = "SELECT ProductSN, CustomerName, ProductionStatus, ProductType FROM Product;";

            // grab all of the Event information for the serial number
            SqlCommand productCommand = new SqlCommand(productDataQuery, connection);

            connection.Open();
            SqlDataReader reader = productCommand.ExecuteReader();

            while (reader.Read())
            {
                string propertyType = reader[3].ToString() == "" ? "unk" : reader[3].ToString();
                ListViewItem item = new(new string[]
                    {propertyType,
                     reader[0].ToString(),
                     reader[1].ToString()
                     });
                int groupNumber = Array.FindIndex(ProductionStatusInfo.ProductionStatuses, product => product.Contains(reader[2].ToString()));
                item.Group = this.productionStatusListView.Groups[groupNumber];

                this.productionStatusListView.Items.Add(item);
            }

             connection.Close();

        } // try
        catch (SqlException err)
        {
            System.Diagnostics.Debug.WriteLine(err.ToString());
            // notify user of sql error
            MessageBox.Show("Error getting product information, Please Try Again");
        } // catch

    } // AddTreeView
} // Menu : Form
