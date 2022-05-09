using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static CapstoneApp.ProductType.ProductTypeObject;
using System.Globalization;
using CapstoneApp;
using CapstoneProject.PopUpWindows;

public class AddPart : Form
{
    private List<PartDetails> partList = new List<PartDetails>();
    private SqlConnectionStringBuilder _builder;
    private Dictionary<string, string> storageDetails;
    private TextBox _productSNInput;
    private TextBox _productLNInput;
    private Button generateLotButton;
    private Label productSN;
    private Button generateButton;
    private Label customerName;
    private Label productionStatus;
    private Label productionType;
    private Label aligniID;
    private Label prevSN;
    private Label dateCode;
    private Label bulkAddCount;
    private Button addAnotherButton;
    private Button _exportCSV;
    private TextBox _bulkCount;
    private TextBox _productAligniInput;
    private TextBox _productPreSNInput;
    private TextBox _customerNameInput;
    private ComboBox _productionStatusInput;
    private ComboBox _productionTypeInput;
    private TextBox _dateCodeInput;
    private TextBox _bulkAddCountInput;
    private Button _submitButton;
    private Button _bulkSubmitButton;
    private Button _bulkLeftButton;
    private Dictionary<string, int> _numberOfPCB;
    private Button _bulkRightButton;
    private Panel _bulkAddPanel;
    private Label partInfo;
    private Label productLN;
    private Button Get_BinID;
    private Label BinID_Label;
    private TextBox BinID_Display;
    private DataGridView _partListBox;

    private Dictionary<String, String> aligniPairs = new Dictionary<string, string>();
    

    public AddPart(SqlConnectionStringBuilder connection)
    {
        this._builder = connection;

    } // AddPart()

    public void FormLayout()
    {
        this.WindowLayout();
        this.InitializeComponent();
        /* Handle modifications unavailable to Windows Forms */
        // Bulk Part List
        BindingList<PartDetails> bindingList = new BindingList<PartDetails>(this.partList);
        BindingSource source = new BindingSource(bindingList, null);
        this._partListBox = new DataGridView
        {
            AutoGenerateColumns = true,
            DataSource = source,
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            RowHeadersVisible = false
        };
        this._bulkAddPanel.Controls.Add(this._partListBox);
        this._numberOfPCB = new Dictionary<string, int>();
        this._bulkLeftButton.Text = "\u2191";
        this._bulkRightButton.Text = "\u2193";
        this._bulkCount.KeyDown += new System.Windows.Forms.KeyEventHandler((object sender, KeyEventArgs e) => {
            if (e.KeyCode == Keys.Return)
            {
                this.SearchBulk(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        });

        this._productionStatusInput.Items.AddRange(ProductionStatusInfo.ProductionStatuses);

        this._productionTypeInput.DataSource = new BindingSource(Menu.ProductTypeList, null);
        this._productionTypeInput.DisplayMember = "Key";
        this._productionTypeInput.ValueMember = "Key";
        this._productionTypeInput.SelectedIndex = -1;

        this._exportCSV.Click += (o, e) => {
            try
            {
                CSVCreator addCreator = new CSVCreator();
                foreach (PartDetails part in this.partList) addCreator.addSerialNumber(part.ProductSN);
                addCreator.exportCSV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, there was an unexpected error: " + ex.ToString());
            }
        };

        // Set the Calendar instance to US standard for the current year and set the datecode to the format WWYY
        CultureInfo currentCI = new CultureInfo("en-US");
        Calendar appCalendar = currentCI.Calendar;
        int week = appCalendar.GetWeekOfYear(DateTime.Today, currentCI.DateTimeFormat.CalendarWeekRule, currentCI.DateTimeFormat.FirstDayOfWeek);
        this._dateCodeInput.Text = (--week).ToString() + DateTime.Now.Year.ToString().Substring(2); //week (for 2022) calculated 53 weeks but required format is 0 to 52 weeks and year requires last two digits of year
    } // FormLayout()

    /*
    (void) WindowLayout configures the new window created for the search
    applet.
    */
    public void WindowLayout()
    {
        this.Name = Constants.windowName;
        this.Text = Constants.windowName;
        this.Size = new System.Drawing.Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
    } // WindowLayout()

    void printSettings(object sender, System.EventArgs e)
    {
        CapstoneApp.PrintSettings settings = new CapstoneApp.PrintSettings(this._builder);
        settings.Show();
    }

    /*
    (string) createSN will generate a new serial number based on a specific format
    */
    public string CreateSN(bool lot)
    {
        string snformat = "XXXXXXXX-XXXX-XXXX-X";
        string validKeys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        string newSN = "";
        Random rnd = new Random();

        if (lot)
        {
            snformat = "XXX";
        }
        foreach (char c in snformat)
        {
            newSN += (c == 'X') ? validKeys[rnd.Next(validKeys.Length)] : c;
        }
        return newSN;
    } // CreateSN()

    /*
    (void) generateClick will automatically generate a Serial Number that does not currently exist in the database.
    */
    private void GenerateClick(object sender, System.EventArgs e)
    {
        string serialNumber;
        SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
        connection.Open();
        while (true)
        {
            serialNumber = this.CreateSN(false);

            SqlCommand checkSNQuery = new SqlCommand("SELECT * FROM Product WHERE ([ProductSN] = @serialNumber)", connection);
            checkSNQuery.Parameters.AddWithValue("@serialNumber", serialNumber);
            SqlDataReader reader = checkSNQuery.ExecuteReader();
            if (!reader.HasRows)
            {
                break;
            }
        }
        connection.Close();
        this._productSNInput.Text = serialNumber;
    }


/* 
(void) generateLotClick will automatically generate a Serial Number and Lot Number that does not currently exist in the database.
*/
    private void GenerateLotClick(object sender, System.EventArgs e)
    {
        string lotNumber;
        string serialNumber;
        SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
        connection.Open();
        while (true)
        {
            serialNumber = this.CreateSN(false);
            lotNumber = this.CreateSN(true);

            SqlCommand checkSNQuery = new SqlCommand("SELECT * FROM Product WHERE ([ProductSN] = @serialNumber)", connection);
            SqlCommand checkLNQuery = new SqlCommand("SELECT * FROM Lot WHERE ([LotNum] = @LotNumber)", connection);
            checkLNQuery.Parameters.AddWithValue("@LotNumber", lotNumber);
            checkSNQuery.Parameters.AddWithValue("@serialNumber", serialNumber);
            SqlDataReader reader = checkSNQuery.ExecuteReader();
            if (!reader.HasRows)
            {
                break;
            }
            reader = checkLNQuery.ExecuteReader();
            if (!reader.HasRows)
            {
                break;
            }
        }
        connection.Close();
        this._productLNInput.Text = lotNumber;
        this._productSNInput.Text = serialNumber;
    }

    /*
    (void) SubmitClick sents the users input to the database.
    */
    private async void SubmitClick(object sender, System.EventArgs e)
    {
        // obtain values from form fields
        if (this._productSNInput.Text == string.Empty || this._productLNInput.Text == string.Empty)
        {
            MessageBox.Show("Product Serial and Lot Number are Required");
            return;
        }
        string productionStatusInputString;
        string productTypeInputString;
        string productSNInputString = this._productSNInput.Text;
        string productLNInputString = this._productLNInput.Text;
        string productAligniIDInputString = this._productAligniInput.Text;
        string productPreSNInputString = this._productPreSNInput.Text;
        string customerNameInputString = this._customerNameInput.Text;
        string productDateCodeInputString = this._dateCodeInput.Text;
        if (this._productionStatusInput.SelectedItem != null && this._productionTypeInput.SelectedItem != null)
        {
            productionStatusInputString = this._productionStatusInput.SelectedItem.ToString();
            // get new product type
            KeyValuePair<string, List<EventListItem>> selectedEntry = (KeyValuePair<string, List<EventListItem>>) this._productionTypeInput.SelectedItem;

            // get selected Key
            productTypeInputString = selectedEntry.Key;

        }
        else
        {
            MessageBox.Show("Missing Required Fields");
            return;
        }

        // display wait window while products are added to database
        WaitWindow waitWindow = new WaitWindow();
        waitWindow.TopMost = true;
        waitWindow.StartPosition = FormStartPosition.CenterScreen;
        waitWindow.FormBorderStyle = FormBorderStyle.None;
        waitWindow.Show();
        this.Cursor = Cursors.WaitCursor;

        // Add the product to the Aligni database
        bool usingAligni = productAligniIDInputString.Length == 0 ? false : true;
        if (usingAligni) {
            // Fetch unit_id
            AAPI aligni = new AAPI();
            await aligni.getGeneralPartData(productAligniIDInputString);
            QueryData res = aligni.getResult();
            if (res == null) {
                MessageBox.Show("Invalid Aligni ID: " + productAligniIDInputString);
                return;
            } else {
                await aligni.UpdateInventory(productAligniIDInputString, 1, res.unit_id, productSNInputString, productDateCodeInputString,
                    productLNInputString);
                res = aligni.getResult();
                if (!res.status) {
                    MessageBox.Show("Error: " + res.msg);
                }
            }
        }
        // add values to the sql database
        string responseMessage;
        try
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();
            string customerNameQuery = "IF NOT EXISTS(Select CustomerName From Customer where CustomerName = @CustomerName) insert into Customer values(@CustomerName)";
            string productStatusQuery = "IF NOT EXISTS(Select ProductionStatus From ProductionStatus where ProductionStatus = @ProductionStatus) insert into ProductionStatus values(@ProductionStatus)";
            string productTypeQuery = "IF NOT EXISTS(Select ProductType From ProductType where ProductType = @ProductType) insert into ProductType values(@ProductType)";
            string lotQuery = "IF NOT EXISTS(Select LotNum From Lot where LotNum = @LotNum) insert into Lot values(@LotNum)";
            string insertQuery = "INSERT INTO Product(ProductSN, AligniSN, FishbowlSN, ProductType, LotNum, CustomerName, PreviousSN, ProductionStatus, WarrantyActive, DateCode, BinID) Values (@ProductSN, @AligniSN, @FishbowlSN, (SELECT * From ProductType WHERE ProductType=@ProductType), @LotNum, (SELECT * FROM Customer WHERE CustomerName=@CustomerName),  @PreviousSN, (SELECT * From ProductionStatus WHERE ProductionStatus=@ProductionStatus), @WarrantyActive, @DateCode, @BinID)";

            // Update Customer Table First; if Customer Name is not already within table
            SqlCommand customerNameCommand = new SqlCommand(customerNameQuery, connection);
            customerNameCommand.Parameters.AddWithValue("@CustomerName", customerNameInputString);
            customerNameCommand.ExecuteNonQuery();

            // Followed by ProductionStatus Table
            SqlCommand productStatusCommand = new SqlCommand(productStatusQuery, connection);
            productStatusCommand.Parameters.AddWithValue("@ProductionStatus", productionStatusInputString);
            productStatusCommand.ExecuteNonQuery();

            // ProductType Table
            SqlCommand productTypeCommand = new SqlCommand(productTypeQuery, connection);
            productTypeCommand.Parameters.AddWithValue("@ProductType", productTypeInputString);
            productTypeCommand.ExecuteNonQuery();

            // Lot Table
            SqlCommand insertLotCommand = new SqlCommand(lotQuery, connection);
            insertLotCommand.Parameters.AddWithValue("@LotNum", productLNInputString);
            insertLotCommand.ExecuteNonQuery();

            // Add Product to Product Table
            SqlCommand productCommand = new SqlCommand(insertQuery, connection);
            productCommand.Parameters.AddWithValue("@ProductSN", productSNInputString);
            productCommand.Parameters.AddWithValue("@AligniSN", productAligniIDInputString);
            productCommand.Parameters.AddWithValue("@FishbowlSN", "");
            productCommand.Parameters.AddWithValue("@ProductType", productTypeInputString);
            productCommand.Parameters.AddWithValue("@LotNum", productLNInputString);
            productCommand.Parameters.AddWithValue("@CustomerName", customerNameInputString);
            productCommand.Parameters.AddWithValue("@PreviousSN", productPreSNInputString);
            productCommand.Parameters.AddWithValue("@ProductionStatus", productionStatusInputString);
            productCommand.Parameters.AddWithValue("@WarrantyActive", false);
            productCommand.Parameters.AddWithValue("@DateCode", productDateCodeInputString);
            productCommand.Parameters.AddWithValue("@BinID", this.BinID_Display.Text);
            productCommand.ExecuteNonQuery();

            // close connection and wait window
            connection.Close();
            this.Cursor = Cursors.Default;
            waitWindow.Close();

            responseMessage = "Part Added Successfully";
        } // try
        catch (SqlException err)
        {
            System.Diagnostics.Debug.WriteLine(err.ToString());

            //Remove Product insertion
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();

            string productRemoveQuery = "DELETE FROM Product WHERE ProductSN = @ProductSN";

            SqlCommand removeProductCommand = new SqlCommand(productRemoveQuery, connection);
            removeProductCommand.Parameters.AddWithValue("@ProductSN", productSNInputString);
            removeProductCommand.ExecuteNonQuery();

            connection.Close();
            responseMessage = "Something Went Wrong, Please Try Again";
        } // catch

        // notify user of sql response
        MessageBox.Show(responseMessage);

    }

    /*
    (void) BulkClickCount will add an input amount of parts to a list;
        once completed the list will be submitted at once.
    */
    private void BulkClickCount(object sender, System.EventArgs e)
    {
        this._exportCSV.Visible = true;
        this._submitButton.Visible = false;
        this._bulkSubmitButton.Visible = true;
        if (int.TryParse(this._bulkAddCountInput.Text, out int countForBulk))
        {
            if (this._productLNInput.Text.Length > 0)
            {
                for (int i = 0; i < countForBulk; i++)
                {
                    if (this._productSNInput.Text.Length == 0 || i > 0)
                    {
                        string serialNumber;
                        SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
                        connection.Open();
                        while (true)
                        {
                            serialNumber = this.CreateSN(false);

                            SqlCommand checkSNQuery = new SqlCommand("SELECT * FROM Product WHERE ([ProductSN] = @serialNumber)", connection);
                            checkSNQuery.Parameters.AddWithValue("@serialNumber", serialNumber);
                            SqlDataReader reader = checkSNQuery.ExecuteReader();
                            if (!reader.HasRows)
                            {
                                break;
                            }
                        }
                        connection.Close();
                        this._productSNInput.Text = serialNumber;
                    }
                    if (this._productionStatusInput.SelectedItem == null)
                    {
                        MessageBox.Show("Production status is Required");
                        return;
                    }
                    else if (this._productionTypeInput.Text == string.Empty)
                    {
                        MessageBox.Show("Product type is Required");
                        return;
                    }

                    // get new product type
                    KeyValuePair<string, List<EventListItem>> selectedEntry = (KeyValuePair<string, List<EventListItem>>) this._productionTypeInput.SelectedItem;

                    // get selected Key
                    PartDetails newPart = new PartDetails
                    {
                        ProductionStatus = this._productionStatusInput.SelectedItem.ToString(),
                        ProductSN = this._productSNInput.Text,
                        CustomerName = this._customerNameInput.Text,
                        ProductLN = this._productLNInput.Text,
                        ProductType = selectedEntry.Key,
                        DateCode = this._dateCodeInput.Text,
                        PrevSN = this._productPreSNInput.Text,
                        AligniID = this._productAligniInput.Text
                    };
                    this.partList.Add(newPart);
                    this._partListBox.DataSource = null;
                    this._partListBox.DataSource = this.partList;
                    this._partListBox.Refresh();

                    this._productSNInput.Text = null;
                    this._productSNInput.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lot Number is required");
            }
        }
        else
        {
            MessageBox.Show("Bulk Count was invalid");
        }
    }
    /*
    (void) BulkSubmitClick will add all parts from the list to the database.
    */
    private async void BulkSubmitClick(object sender, System.EventArgs e)
    {
        // Update the number of related by PCBGroupSN (accounting for manual editing)
        foreach (PartDetails part in this.partList)
        {
            if (this._numberOfPCB.ContainsKey(part.ProductLN))
            {
                this._numberOfPCB[part.ProductLN]++;
            }
            else
            {
                this._numberOfPCB.Add(part.ProductLN, 1);
            }
        }

        int submittedCount = 0; // Track number of submitted items in case the bulk add fails and items must be removed

        // display wait window while products are added to database
        WaitWindow waitWindow = new WaitWindow();
        waitWindow.TopMost = true;
        waitWindow.StartPosition = FormStartPosition.CenterScreen;
        waitWindow.FormBorderStyle = FormBorderStyle.None;
        waitWindow.Show();
        this.Cursor = Cursors.WaitCursor;

        // add values to the sql database
        string responseMessage;
        try
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();
            string customerNameQuery = "IF NOT EXISTS(Select CustomerName From Customer where CustomerName = @CustomerName) insert into Customer values(@CustomerName)";
            string productStatusQuery = "IF NOT EXISTS(Select ProductionStatus From ProductionStatus where ProductionStatus = @ProductionStatus) insert into ProductionStatus values(@ProductionStatus)";
            string productTypeQuery = "IF NOT EXISTS(Select ProductType From ProductType where ProductType = @ProductType) insert into ProductType values(@ProductType)";
            string lotQuery = "IF NOT EXISTS(Select LotNum From Lot where LotNum = @LotNum) insert into Lot values(@LotNum)";
            string insertQuery = "INSERT INTO Product(ProductSN, AligniSN, FishbowlSN, ProductType, LotNum, CustomerName, PreviousSN, ProductionStatus, WarrantyActive, DateCode, BinID) Values (@ProductSN, @AligniSN, @FishbowlSN, (SELECT * From ProductType WHERE ProductType=@ProductType), @LotNum, (SELECT * FROM Customer WHERE CustomerName=@CustomerName),  @PreviousSN, (SELECT * From ProductionStatus WHERE ProductionStatus=@ProductionStatus), @WarrantyActive, @DateCode, @BinID)";
            string productDateCodeInputString = this._dateCodeInput.Text;
            //Dictionary<String, List<PartDetails>> lotPairs = new Dictionary<string, List<PartDetails>>();
            List<PartDetails> aligniItems = new List<PartDetails>();
            List<String> invalidAligniIDs = new List<String>(); // Keep track of previous error messages
            AAPI aligni = new AAPI();
            foreach (PartDetails part in this.partList) {
                // Check if the part has an aligni ID
                bool usesAligni = part.AligniID.Length == 0 ? false : true;
                // Fetch UNIT ID if aligni ID is used and is not in aligniPairs table
                if (usesAligni && !aligniPairs.ContainsKey(part.AligniID)) {
                    await aligni.getGeneralPartData(part.AligniID);
                    QueryData res = aligni.getResult();
                    if (res == null) {
                        usesAligni = false;
                        // Reduce error message spam
                        if (!invalidAligniIDs.Contains(part.AligniID)) {
                            MessageBox.Show("Invalid Aligni ID: " + part.AligniID);
                            invalidAligniIDs.Add(part.AligniID);
                        }
                    } else {
                        aligniPairs[part.AligniID] = res.unit_id; // Set unit ID to lot number pair
                    }
                }
                if (usesAligni) aligniItems.Add(part);
                /* For old lot insertion method
                if (usesAligni) {
                    // If the lotpairs does not have the product lot number key, create new list
                    if (!lotPairs.ContainsKey(part.ProductLN)) {
                        lotPairs[part.ProductLN] = new List<PartDetails>();
                    }
                    // Add current part to respective lotPairs list
                    lotPairs[part.ProductLN].Add(part);
                }*/
                // Update Customer Table First; if Customer Name is not already within table
                SqlCommand customerNameCommand = new SqlCommand(customerNameQuery, connection);
                customerNameCommand.Parameters.AddWithValue("@CustomerName", part.CustomerName);
                customerNameCommand.ExecuteNonQuery();

                // Followed by ProductStatus Table
                SqlCommand productStatusCommand = new SqlCommand(productStatusQuery, connection);
                productStatusCommand.Parameters.AddWithValue("@ProductionStatus", part.ProductionStatus);
                productStatusCommand.ExecuteNonQuery();

                // ProductType Table
                SqlCommand productTypeCommand = new SqlCommand(productTypeQuery, connection);
                productTypeCommand.Parameters.AddWithValue("@ProductType", part.ProductType);
                productTypeCommand.ExecuteNonQuery();

                // Lot Table
                SqlCommand insertLotCommand = new SqlCommand(lotQuery, connection);
                insertLotCommand.Parameters.AddWithValue("@LotNum", part.ProductLN);
                insertLotCommand.ExecuteNonQuery();

                // Add Product to Product Table
                SqlCommand productCommand = new SqlCommand(insertQuery, connection);
                productCommand.Parameters.AddWithValue("@ProductSN", part.ProductSN);
                productCommand.Parameters.AddWithValue("@AligniSN", part.AligniID);
                productCommand.Parameters.AddWithValue("@FishbowlSN", "");
                productCommand.Parameters.AddWithValue("@ProductType", part.ProductType);
                productCommand.Parameters.AddWithValue("@LotNum", part.ProductLN);
                productCommand.Parameters.AddWithValue("@CustomerName", part.CustomerName);
                productCommand.Parameters.AddWithValue("@PreviousSN", part.PrevSN);
                productCommand.Parameters.AddWithValue("@ProductionStatus", part.ProductionStatus);
                productCommand.Parameters.AddWithValue("@WarrantyActive", false);
                productCommand.Parameters.AddWithValue("@DateCode", productDateCodeInputString);
                productCommand.Parameters.AddWithValue("@BinID", this.BinID_Display.Text);
                productCommand.ExecuteNonQuery();
                submittedCount++;
            }
            /* Old - might use later. Would submit in lots rather than individual
            // Submit lots as Aligni inventory
            foreach (String lotNo in lotPairs.Keys) {
                foreach (PartDetails part in lotPairs[lotNo]) {
                    // Insert each part into aligni
                    await aligni.UpdateInventory(part.AligniID, 1, aligniPairs[part.AligniID], part.DateCode, part.ProductLN);
                }
            }
            */
            foreach (PartDetails item in aligniItems) {
                await aligni.UpdateInventory(item.AligniID, 1, aligniPairs[item.AligniID], item.ProductSN, item.DateCode, item.ProductLN);
            }
            connection.Close();
            waitWindow.Close();
            this.Cursor = Cursors.Default;

            responseMessage = "Parts were Added Successfully";
        } // try
        catch (SqlException err)
        {
            SqlConnection connection = new SqlConnection(this._builder.ConnectionString);
            connection.Open();

            int removeCount = 0;
            foreach (PartDetails part in this.partList)
            {
                if (removeCount == submittedCount)
                {
                    break;
                }
                SqlCommand productRemove = new SqlCommand("DELETE FROM Product WHERE ProductSN = @ProductSN", connection);
                productRemove.Parameters.AddWithValue("@ProductSN", part.ProductSN);
                productRemove.ExecuteNonQuery();

                removeCount++;
            }

            connection.Close();

            System.Diagnostics.Debug.WriteLine(err.ToString());
            responseMessage = "Something Went Wrong, Please Try Again";
        } // catch

        // notify user of sql response
        MessageBox.Show(responseMessage);
        this.partList = null;
    }
    /*
    (void) SearchBulk allows for quickly selecting a row 
    */
    private void SearchBulk(object sender, EventArgs e)
    {
        this._partListBox.ClearSelection();
        int chosenRow = int.Parse(this._bulkCount.Text);
        if (!chosenRow.Equals(null) && 0 < chosenRow && chosenRow <= (this._partListBox.Rows.Count))
        {
            this._partListBox.Rows[chosenRow - 1].Selected = true;
        }
    }
    /*
    (void) LeftSearchBulk switches the selection to the row above
    */
    private void LeftSearchBulk(object sender, EventArgs e)
    {
        try
        {
            int desiredRow = this._partListBox.SelectedRows[0].Index - 1;
            this._partListBox.ClearSelection();
            if (desiredRow < this._partListBox.Rows.Count)
            {
                if (!desiredRow.Equals(null) && desiredRow >= 0)
                {
                    this._partListBox.Rows[desiredRow].Selected = true;
                }
            }
        }
        catch
        {
            this._partListBox.ClearSelection();
            this._partListBox.Rows[0].Selected = true;
        }
    }
    /*
    (void) RightSearchBulk switches the selection to the row below
    */
    private void RightSearchBulk(object sender, EventArgs e)
    {
        try
        {
            int desiredRow = this._partListBox.SelectedRows[0].Index + 1;
            this._partListBox.ClearSelection();
            if (desiredRow < this._partListBox.Rows.Count)
            {
                if (!desiredRow.Equals(null) && desiredRow >= 0)
                {
                    this._partListBox.Rows[desiredRow].Selected = true;
                }
            }
        }
        catch
        {
            this._partListBox.ClearSelection();
            this._partListBox.Rows[this._partListBox.Rows.Count - 1].Selected = true;
        }
    }
    private void InitializeComponent()
    {
        this.partInfo = new System.Windows.Forms.Label();
        this.productLN = new System.Windows.Forms.Label();
        this._productLNInput = new System.Windows.Forms.TextBox();
        this.generateLotButton = new System.Windows.Forms.Button();
        this.productSN = new System.Windows.Forms.Label();
        this._productSNInput = new System.Windows.Forms.TextBox();
        this.generateButton = new System.Windows.Forms.Button();
        this.customerName = new System.Windows.Forms.Label();
        this._customerNameInput = new System.Windows.Forms.TextBox();
        this.productionStatus = new System.Windows.Forms.Label();
        this._productionStatusInput = new System.Windows.Forms.ComboBox();
        this.productionType = new System.Windows.Forms.Label();
        this._productionTypeInput = new System.Windows.Forms.ComboBox();
        this.aligniID = new System.Windows.Forms.Label();
        this._productAligniInput = new System.Windows.Forms.TextBox();
        this.prevSN = new System.Windows.Forms.Label();
        this._productPreSNInput = new System.Windows.Forms.TextBox();
        this.dateCode = new System.Windows.Forms.Label();
        this._dateCodeInput = new System.Windows.Forms.TextBox();
        this.bulkAddCount = new System.Windows.Forms.Label();
        this._bulkAddCountInput = new System.Windows.Forms.TextBox();
        this._submitButton = new System.Windows.Forms.Button();
        this.addAnotherButton = new System.Windows.Forms.Button();
        this._bulkAddPanel = new System.Windows.Forms.Panel();
        this._exportCSV = new System.Windows.Forms.Button();
        this._bulkSubmitButton = new System.Windows.Forms.Button();
        this._bulkLeftButton = new System.Windows.Forms.Button();
        this._bulkCount = new System.Windows.Forms.TextBox();
        this._bulkRightButton = new System.Windows.Forms.Button();
        this.Get_BinID = new System.Windows.Forms.Button();
        this.BinID_Label = new System.Windows.Forms.Label();
        this.BinID_Display = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // partInfo
        // 
        this.partInfo.AutoSize = true;
        this.partInfo.Location = new System.Drawing.Point(10, 10);
        this.partInfo.Name = "partInfo";
        this.partInfo.Size = new System.Drawing.Size(219, 20);
        this.partInfo.TabIndex = 0;
        this.partInfo.Text = "Add a new part to the datebase";
        // 
        // productLN
        // 
        this.productLN.AutoSize = true;
        this.productLN.Location = new System.Drawing.Point(50, 40);
        this.productLN.Name = "productLN";
        this.productLN.Size = new System.Drawing.Size(154, 20);
        this.productLN.TabIndex = 2;
        this.productLN.Text = "Product Lot Number : ";
        // 
        // _productLNInput
        // 
        this._productLNInput.Location = new System.Drawing.Point(200, 40);
        this._productLNInput.Name = "_productLNInput";
        this._productLNInput.Size = new System.Drawing.Size(200, 27);
        this._productLNInput.TabIndex = 3;
        // 
        // generateLotButton
        // 
        this.generateLotButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.generateLotButton.Location = new System.Drawing.Point(405, 40);
        this.generateLotButton.Name = "generateLotButton";
        this.generateLotButton.Size = new System.Drawing.Size(80, 25);
        this.generateLotButton.TabIndex = 4;
        this.generateLotButton.Text = "Generate";
        this.generateLotButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        this.generateLotButton.UseVisualStyleBackColor = true;
        this.generateLotButton.Click += new System.EventHandler(this.GenerateLotClick);
        // 
        // productSN
        // 
        this.productSN.AutoSize = true;
        this.productSN.Location = new System.Drawing.Point(50, 70);
        this.productSN.Name = "productSN";
        this.productSN.Size = new System.Drawing.Size(170, 20);
        this.productSN.TabIndex = 5;
        this.productSN.Text = "Product Serial Number : ";
        // 
        // _productSNInput
        // 
        this._productSNInput.Location = new System.Drawing.Point(200, 70);
        this._productSNInput.Name = "_productSNInput";
        this._productSNInput.Size = new System.Drawing.Size(200, 27);
        this._productSNInput.TabIndex = 6;
        // 
        // generateButton
        // 
        this.generateButton.Location = new System.Drawing.Point(405, 70);
        this.generateButton.Name = "generateButton";
        this.generateButton.Size = new System.Drawing.Size(80, 25);
        this.generateButton.TabIndex = 7;
        this.generateButton.Text = "Generate";
        this.generateButton.UseVisualStyleBackColor = true;
        this.generateButton.Click += new System.EventHandler(this.GenerateClick);
        // 
        // customerName
        // 
        this.customerName.AutoSize = true;
        this.customerName.Location = new System.Drawing.Point(50, 100);
        this.customerName.Name = "customerName";
        this.customerName.Size = new System.Drawing.Size(127, 20);
        this.customerName.TabIndex = 8;
        this.customerName.Text = "Customer Name : ";
        // 
        // _customerNameInput
        // 
        this._customerNameInput.Location = new System.Drawing.Point(200, 100);
        this._customerNameInput.Name = "_customerNameInput";
        this._customerNameInput.Size = new System.Drawing.Size(200, 27);
        this._customerNameInput.TabIndex = 9;
        // 
        // productionStatus
        // 
        this.productionStatus.AutoSize = true;
        this.productionStatus.Location = new System.Drawing.Point(50, 130);
        this.productionStatus.Name = "productionStatus";
        this.productionStatus.Size = new System.Drawing.Size(136, 20);
        this.productionStatus.TabIndex = 10;
        this.productionStatus.Text = "Production Status : ";
        // 
        // _productionStatusInput
        // 
        this._productionStatusInput.FormattingEnabled = true;
        this._productionStatusInput.Location = new System.Drawing.Point(200, 130);
        this._productionStatusInput.Name = "_productionStatusInput";
        this._productionStatusInput.Size = new System.Drawing.Size(200, 28);
        this._productionStatusInput.TabIndex = 11;
        // 
        // productionType
        // 
        this.productionType.AutoSize = true;
        this.productionType.Location = new System.Drawing.Point(50, 160);
        this.productionType.Name = "productionType";
        this.productionType.Size = new System.Drawing.Size(106, 20);
        this.productionType.TabIndex = 12;
        this.productionType.Text = "Product Type : ";
        this.productionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _productionTypeInput
        // 
        this._productionTypeInput.FormattingEnabled = true;
        this._productionTypeInput.Location = new System.Drawing.Point(200, 160);
        this._productionTypeInput.Name = "_productionTypeInput";
        this._productionTypeInput.Size = new System.Drawing.Size(200, 28);
        this._productionTypeInput.TabIndex = 13;
        // 
        // aligniID
        // 
        this.aligniID.AutoSize = true;
        this.aligniID.Location = new System.Drawing.Point(50, 190);
        this.aligniID.Name = "aligniID";
        this.aligniID.Size = new System.Drawing.Size(94, 20);
        this.aligniID.TabIndex = 14;
        this.aligniID.Text = "Aligni ID(s) : ";
        // 
        // _productAligniInput
        // 
        this._productAligniInput.Location = new System.Drawing.Point(200, 190);
        this._productAligniInput.Name = "_productAligniInput";
        this._productAligniInput.Size = new System.Drawing.Size(200, 27);
        this._productAligniInput.TabIndex = 15;
        // 
        // prevSN
        // 
        this.prevSN.AutoSize = true;
        this.prevSN.Location = new System.Drawing.Point(50, 220);
        this.prevSN.Name = "prevSN";
        this.prevSN.Size = new System.Drawing.Size(114, 20);
        this.prevSN.TabIndex = 16;
        this.prevSN.Text = "Previous SN(s) : ";
        // 
        // _productPreSNInput
        // 
        this._productPreSNInput.Location = new System.Drawing.Point(200, 220);
        this._productPreSNInput.Name = "_productPreSNInput";
        this._productPreSNInput.Size = new System.Drawing.Size(200, 27);
        this._productPreSNInput.TabIndex = 17;
        // 
        // dateCode
        // 
        this.dateCode.AutoSize = true;
        this.dateCode.Location = new System.Drawing.Point(50, 250);
        this.dateCode.Name = "dateCode";
        this.dateCode.Size = new System.Drawing.Size(91, 20);
        this.dateCode.TabIndex = 18;
        this.dateCode.Text = "Date Code : ";
        // 
        // _dateCodeInput
        // 
        this._dateCodeInput.Location = new System.Drawing.Point(200, 250);
        this._dateCodeInput.Name = "_dateCodeInput";
        this._dateCodeInput.ReadOnly = true;
        this._dateCodeInput.Size = new System.Drawing.Size(200, 27);
        this._dateCodeInput.TabIndex = 19;
        // 
        // bulkAddCount
        // 
        this.bulkAddCount.AutoSize = true;
        this.bulkAddCount.Location = new System.Drawing.Point(50, 280);
        this.bulkAddCount.Name = "bulkAddCount";
        this.bulkAddCount.Size = new System.Drawing.Size(153, 20);
        this.bulkAddCount.TabIndex = 20;
        this.bulkAddCount.Text = "Number of Products : ";
        // 
        // _bulkAddCountInput
        // 
        this._bulkAddCountInput.Location = new System.Drawing.Point(200, 280);
        this._bulkAddCountInput.Name = "_bulkAddCountInput";
        this._bulkAddCountInput.Size = new System.Drawing.Size(200, 27);
        this._bulkAddCountInput.TabIndex = 21;
        this._bulkAddCountInput.Text = "1";
        // 
        // _submitButton
        // 
        this._submitButton.Location = new System.Drawing.Point(190, 360);
        this._submitButton.Name = "_submitButton";
        this._submitButton.Size = new System.Drawing.Size(80, 25);
        this._submitButton.TabIndex = 22;
        this._submitButton.Text = "Submit";
        this._submitButton.UseVisualStyleBackColor = true;
        this._submitButton.Click += new System.EventHandler(this.SubmitClick);
        // 
        // addAnotherButton
        // 
        this.addAnotherButton.Location = new System.Drawing.Point(280, 360);
        this.addAnotherButton.Name = "addAnotherButton";
        this.addAnotherButton.Size = new System.Drawing.Size(80, 25);
        this.addAnotherButton.TabIndex = 23;
        this.addAnotherButton.Text = "Bulk Add";
        this.addAnotherButton.UseVisualStyleBackColor = true;
        this.addAnotherButton.Click += new System.EventHandler(this.BulkClickCount);
        // 
        // _bulkAddPanel
        // 
        this._bulkAddPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this._bulkAddPanel.AutoSize = true;
        this._bulkAddPanel.Location = new System.Drawing.Point(495, 40);
        this._bulkAddPanel.Name = "_bulkAddPanel";
        this._bulkAddPanel.Size = new System.Drawing.Size(275, 350);
        this._bulkAddPanel.TabIndex = 24;
        // 
        // _exportCSV
        // 
        this._exportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this._exportCSV.Location = new System.Drawing.Point(670, 510);
        this._exportCSV.Name = "_exportCSV";
        this._exportCSV.Size = new System.Drawing.Size(100, 25);
        this._exportCSV.TabIndex = 0;
        this._exportCSV.Text = "Export CSV";
        this._exportCSV.UseVisualStyleBackColor = true;
        this._exportCSV.Visible = false;
        // 
        // _bulkSubmitButton
        // 
        this._bulkSubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this._bulkSubmitButton.Location = new System.Drawing.Point(680, 475);
        this._bulkSubmitButton.Name = "_bulkSubmitButton";
        this._bulkSubmitButton.Size = new System.Drawing.Size(80, 25);
        this._bulkSubmitButton.TabIndex = 25;
        this._bulkSubmitButton.Text = "Submit";
        this._bulkSubmitButton.UseVisualStyleBackColor = true;
        this._bulkSubmitButton.Visible = false;
        this._bulkSubmitButton.Click += new System.EventHandler(this.BulkSubmitClick);
        // 
        // _bulkLeftButton
        // 
        this._bulkLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this._bulkLeftButton.Location = new System.Drawing.Point(495, 400);
        this._bulkLeftButton.Name = "_bulkLeftButton";
        this._bulkLeftButton.Size = new System.Drawing.Size(80, 25);
        this._bulkLeftButton.TabIndex = 26;
        this._bulkLeftButton.Text = "\\u2191";
        this._bulkLeftButton.UseVisualStyleBackColor = true;
        this._bulkLeftButton.Click += new System.EventHandler(this.LeftSearchBulk);
        // 
        // _bulkCount
        // 
        this._bulkCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this._bulkCount.Location = new System.Drawing.Point(612, 400);
        this._bulkCount.Name = "_bulkCount";
        this._bulkCount.Size = new System.Drawing.Size(45, 27);
        this._bulkCount.TabIndex = 27;
        this._bulkCount.Text = "1";
        // 
        // _bulkRightButton
        // 
        this._bulkRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this._bulkRightButton.Location = new System.Drawing.Point(690, 400);
        this._bulkRightButton.Name = "_bulkRightButton";
        this._bulkRightButton.Size = new System.Drawing.Size(80, 25);
        this._bulkRightButton.TabIndex = 28;
        this._bulkRightButton.Text = "\\u2193";
        this._bulkRightButton.UseVisualStyleBackColor = true;
        this._bulkRightButton.Click += new System.EventHandler(this.RightSearchBulk);
        // 
        // Get_BinID
        // 
        this.Get_BinID.Location = new System.Drawing.Point(405, 310);
        this.Get_BinID.Name = "Get_BinID";
        this.Get_BinID.Size = new System.Drawing.Size(80, 23);
        this.Get_BinID.TabIndex = 29;
        this.Get_BinID.Text = "Select Bin";
        this.Get_BinID.UseVisualStyleBackColor = true;
        this.Get_BinID.Click += new System.EventHandler(this.Get_BinID_Click);
        // 
        // BinID_Label
        // 
        this.BinID_Label.AutoSize = true;
        this.BinID_Label.Location = new System.Drawing.Point(50, 310);
        this.BinID_Label.Name = "BinID_Label";
        this.BinID_Label.Size = new System.Drawing.Size(38, 15);
        this.BinID_Label.TabIndex = 30;
        this.BinID_Label.Text = "BinID:";
        // 
        // BinID_Display
        // 
        this.BinID_Display.Location = new System.Drawing.Point(200, 310);
        this.BinID_Display.Name = "BinID_Display";
        this.BinID_Display.ReadOnly = true;
        this.BinID_Display.Size = new System.Drawing.Size(200, 23);
        this.BinID_Display.TabIndex = 31;
        // 
        // AddPart
        // 
        this.ClientSize = new System.Drawing.Size(782, 553);
        this.Controls.Add(this.BinID_Display);
        this.Controls.Add(this.BinID_Label);
        this.Controls.Add(this.Get_BinID);
        this.Controls.Add(this._bulkRightButton);
        this.Controls.Add(this._bulkCount);
        this.Controls.Add(this._bulkLeftButton);
        this.Controls.Add(this._bulkSubmitButton);
        this.Controls.Add(this._exportCSV);
        this.Controls.Add(this._bulkAddPanel);
        this.Controls.Add(this.addAnotherButton);
        this.Controls.Add(this._submitButton);
        this.Controls.Add(this._bulkAddCountInput);
        this.Controls.Add(this.bulkAddCount);
        this.Controls.Add(this._dateCodeInput);
        this.Controls.Add(this.dateCode);
        this.Controls.Add(this._productPreSNInput);
        this.Controls.Add(this.prevSN);
        this.Controls.Add(this._productAligniInput);
        this.Controls.Add(this.aligniID);
        this.Controls.Add(this._productionTypeInput);
        this.Controls.Add(this.productionType);
        this.Controls.Add(this._productionStatusInput);
        this.Controls.Add(this.productionStatus);
        this.Controls.Add(this._customerNameInput);
        this.Controls.Add(this.customerName);
        this.Controls.Add(this.generateButton);
        this.Controls.Add(this._productSNInput);
        this.Controls.Add(this.productSN);
        this.Controls.Add(this.generateLotButton);
        this.Controls.Add(this._productLNInput);
        this.Controls.Add(this.productLN);
        this.Controls.Add(this.partInfo);
        this.Name = "AddPart";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private void Get_BinID_Click(object sender, EventArgs e)
    {
        storageDialog dialog = new(this._builder);
        if(dialog.ShowDialog() == DialogResult.OK)
        {
            this.storageDetails = dialog.storageDetails;
            this.BinID_Display.Text = this.storageDetails["BinID"];
        }
        dialog.Dispose();
    }
}

public static class ProductionStatusInfo
{
    public static string[] ProductionStatuses = { "Panel", "PCB", "PCBA", "Tested", "Rework", "Assembled", "RTS", "Shipped", "RMA" };
}

public class PartDetails
{
    [System.ComponentModel.DisplayName("Product Lot Number")]
    public string ProductLN
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Product Serial Number")]
    public string ProductSN
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Customer Name")]
    public string CustomerName
    {
        get; set;
    }
    [DisplayName("Production Status")]
    public string ProductionStatus
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Product Type")]
    public string ProductType
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Prev SN")]
    public string PrevSN
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Aligni ID")]
    public string AligniID
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Date Code")]
    public string DateCode
    {
        get; set;
    }
}
