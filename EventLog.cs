using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using static CapstoneApp.ProductType.ProductTypeObject;
using System.Linq;
using CapstoneProject.PopUpWindows;
using System.Threading;

class EventDetails
{
    [System.ComponentModel.DisplayName("Serial Numbers")]
    public string serialNo {get; set;}
    // override object.Equals
    public override bool Equals(object obj)
    {

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        EventDetails compare = (EventDetails)obj;
        if (this.serialNo.Equals(compare.serialNo)) {
            return true;
        } else {
            return false;
        }
    }
}

public class EventList
{
    [System.ComponentModel.DisplayName("Event Type")]
    public string type
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Description")]
    public string description
    {
        get; set;
    }
    [System.ComponentModel.DisplayName("Author")]
    public string author
    {
        get; set;
    }
    // override object.Equals
    public override bool Equals(object obj)
    {

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        EventList compare = (EventList)obj;
        if (this.description.Equals(compare.description) && 
            this.author.Equals(compare.author) && 
            this.type.Equals(compare.type)) {
            return true;
        } else {
            return false;
        }
    }
}

public class EventLog : Form {

    public TextBox SearchEvent;
    public Button SearchButton;
    List<EventDetails> detailList = new List<EventDetails>();
    List<EventList> _eventList = new List<EventList>();
    private SqlConnectionStringBuilder _builder;
    private Label AuthorTextLabel;
    private TextBox _descriptionTextBox;
    private ComboBox _typeComboBox;
    private Button _addEventButton;
    private Button _submitButton;
    private Panel _bulkAddPanel;
    private Panel _bulkEventPanel;
    private DataGridView _detailListBox;
    private DataGridView _eventListBox;
    private DataGridViewRow _editRow;
    private enum EditMode {Add, Update};
    private EditMode eventMode = EditMode.Add; // Default to adding events
    
    public EventLog(SqlConnectionStringBuilder connection)
    {
        this._builder = connection;
    }
    public void FormLayout()
    {
        WindowLayout();
        InterfaceLayout();
    }

    public void WindowLayout()
    {
        this.Name = Constants.windowName;
        this.Text = Constants.windowName;
        this.Size = new System.Drawing.Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
    } // WindowLayout()

    /*
    (void) InterfaceLayout builds the interface for adding a new part.
    */
    public void InterfaceLayout()
    {
        Label searchInfo = new Label();
        searchInfo.Text = "Enter Serial Number";
        searchInfo.Size = new System.Drawing.Size(100, 30);
        searchInfo.Location = new System.Drawing.Point(10, 10);
        this.Controls.Add(searchInfo);

        //Search Textbox
        this.SearchEvent = new TextBox();
        this.SearchEvent.Focus();
        this.SearchEvent.Size = new System.Drawing.Size(100, 25);
        this.SearchEvent.Name = "Search Event";
        this.SearchEvent.Location = new System.Drawing.Point(120 ,10);
        this.SearchEvent.KeyDown += new System.Windows.Forms.KeyEventHandler((object sender, KeyEventArgs e) => {
            if (e.KeyCode == Keys.Return) {
                SearchClick(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        });
        this.Controls.Add(SearchEvent);

        // Search Button
        SearchButton = new Button {Height = 25, Width = 100};
        SearchButton.Text = "Search";
        SearchButton.Location = new System.Drawing.Point(230, 10);
        SearchButton.Click += SearchClick;
        this.Controls.Add(SearchButton);

        //Author Label and TextBox
        Label authorName = new Label();
        authorName.Text = "Author Name : ";
        authorName.Size = new System.Drawing.Size(100, 25);
        authorName.Location = new System.Drawing.Point(10, 50);
        this.Controls.Add(authorName);

        this.AuthorTextLabel = new Label();
        AuthorTextLabel.AutoSize = false;
        AuthorTextLabel.Size = new System.Drawing.Size(150, 25);
        AuthorTextLabel.Text = UserGlobals.userName;
        AuthorTextLabel.Location = new System.Drawing.Point(10,77);
        this.Controls.Add(AuthorTextLabel);

        //Description Label and TextBox
        Label description = new Label();
        description.Text = "Description : ";
        description.Size = new System.Drawing.Size(100, 25);
        description.Location = new System.Drawing.Point(170, 50);
        this.Controls.Add(description);

        this._descriptionTextBox = new TextBox();
        _descriptionTextBox = new TextBox();
        _descriptionTextBox.AutoSize = false;
        _descriptionTextBox.Size = new System.Drawing.Size(150, 25);        
        _descriptionTextBox.Location = new System.Drawing.Point(170, 75);
        this.Controls.Add(_descriptionTextBox);

        //Type Label and TextBox
        Label type = new Label();
        type.Text = "Type : ";
        type.Size = new System.Drawing.Size(100, 25);
        type.Location = new System.Drawing.Point(330, 50);
        this.Controls.Add(type);

        this._typeComboBox = new ComboBox();
        _typeComboBox.AutoSize = false;
        _typeComboBox.Size = new System.Drawing.Size(150, 25);        
        _typeComboBox.Location = new System.Drawing.Point(330, 75);
        this.Controls.Add(_typeComboBox);

        // Submit
        this._submitButton = new Button { Height = Constants.AddPartButtonHeight, Width = Constants.AddPartButtonWidth };
        _submitButton.Text = "Submit";
        _submitButton.Location = new System.Drawing.Point(145, 160);
        _submitButton.Click += SubmitClick;
        this.Controls.Add(_submitButton);

        // Add Event
        this._addEventButton = new Button {  Height = Constants.AddPartButtonHeight, Width = Constants.AddPartButtonWidth };
        _addEventButton.Text = "Add Event";
        _addEventButton.Location = new System.Drawing.Point(235, 160);
        _addEventButton.Click += AddEvents;
        this.Controls.Add(_addEventButton);

        // Bulk Add Display
        this._bulkAddPanel = new Panel();
        this._bulkAddPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this._bulkAddPanel.AutoSize = true;
        this._bulkAddPanel.Location = new System.Drawing.Point(495, 40);
        this._bulkAddPanel.Name = "Bulk Parts Panel";
        this._bulkAddPanel.Size = new System.Drawing.Size(275, this.Height - 350);
        //this._bulkAddPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.Controls.Add(this._bulkAddPanel);

        // Bulk Add Display for Events
        this._bulkEventPanel = new Panel();
        this._bulkEventPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        this._bulkEventPanel.AutoSize = true;
        this._bulkEventPanel.Location = new System.Drawing.Point(495, this.Height - 300);
        this._bulkEventPanel.Name = "Bulk Events Panel";
        this._bulkEventPanel.Size = new System.Drawing.Size(275, this.Height - 350);
        //this._bulkAddPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.Controls.Add(this._bulkEventPanel);

        // Bulk Part List
        this._detailListBox = new DataGridView();
        this._detailListBox.AutoGenerateColumns = true;
        BindingList<EventDetails> bindingList = new BindingList<EventDetails>(detailList);
        BindingSource source = new BindingSource(bindingList, null);
        this._detailListBox.DataSource = source;
        this._detailListBox.Dock = DockStyle.Fill;
        this._detailListBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this._detailListBox.ReadOnly = true;
        this._detailListBox.AllowUserToAddRows = false;
        this._detailListBox.RowHeadersVisible = false;
        ToolStripMenuItem delSerial = new ToolStripMenuItem();
        delSerial.Text = "Delete";
        delSerial.Click += DeleteSerial;
        ContextMenuStrip serialContext = new ContextMenuStrip();
        serialContext.Items.Add(delSerial);
        this._detailListBox.ContextMenuStrip = serialContext;
        this._detailListBox.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        this._bulkAddPanel.Controls.Add(this._detailListBox);

        // Bulk Event List
        this._eventListBox = new DataGridView();
        this._eventListBox.AutoGenerateColumns = true;
        BindingList<EventList> bindingListE = new BindingList<EventList>(_eventList);
        BindingSource sourceE = new BindingSource(bindingListE, null);
        this._eventListBox.DataSource = sourceE;
        this._eventListBox.Dock = DockStyle.Fill;
        this._eventListBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this._eventListBox.ReadOnly = true;
        this._eventListBox.AllowUserToAddRows = false;
        this._eventListBox.RowHeadersVisible = false;
        ToolStripMenuItem eventEdit = new ToolStripMenuItem();
        ToolStripMenuItem deleteEdit = new ToolStripMenuItem();
        eventEdit.Text = "Edit";
        deleteEdit.Text = "Delete";
        eventEdit.Click += EditEvent;
        deleteEdit.Click += DeleteEvent;
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
        contextMenuStrip.Items.Add(eventEdit);
        contextMenuStrip.Items.Add(deleteEdit);
        this._eventListBox.ContextMenuStrip = contextMenuStrip;
        this._eventListBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        this._bulkEventPanel.Controls.Add(this._eventListBox);
    }

    private bool checkFields() {
        if (this._typeComboBox.SelectedIndex < 0 || 
            this._descriptionTextBox.Text.Length == 0 ||
            this.AuthorTextLabel.Text.Length == 0) {
            MessageBox.Show("A required event field is empty, please fill it in.");
            return false;
        }
        return true;
    }

    void DeleteSerial(object o, EventArgs e) {
        EventDetails searchItem = new EventDetails(), target = null;
        DataGridViewRow searchRow = null;
        // Should just be one selected, iterate through in case weird edge case arises
        foreach (DataGridViewRow row in this._detailListBox.SelectedRows) {
            searchRow = row;
        }
        if (searchRow == null)
        {
            MessageBox.Show("Unable to complete request at this time.");
            return;
        }
        // Set serial number to delete
        searchItem.serialNo = (string) searchRow.Cells["serialNo"].Value; 
        // Remove the current row item
        foreach (EventDetails eD in this.detailList) {
            if (eD.Equals(searchItem)) {
                target = eD;
                break;
            }
        }
        if (target != null) this.detailList.Remove(target);
        this._detailListBox.ClearSelection();
        UpdateDetailList();
    }
    void UpdateEventList()
    {
        _eventListBox.DataSource = null;
        _eventListBox.DataSource = _eventList;
        _eventListBox.Refresh();
        this._descriptionTextBox.Text = "";
        this._typeComboBox.Text = "";
    }

    void UpdateDetailList() {
        _detailListBox.DataSource = null;
        _detailListBox.DataSource = detailList;
        _detailListBox.Refresh();
        SearchEvent.Text = "";
    }

    void HighlightRow(DataGridViewRow row, Color backColor, Color frontColor) {
        foreach (DataGridViewCell cell in row.Cells) {
            cell.Style.BackColor = backColor;
            cell.Style.SelectionBackColor = backColor;
            cell.Style.SelectionForeColor = frontColor;
        }
    }
    void EditEvent(object s, EventArgs e)
    {
        if (eventMode == EditMode.Update) {
            MessageBox.Show("Please finish updating current event first.");
            return;
        }
        // Should just be one selected, iterate through in case weird edge case arises
        foreach (DataGridViewRow row in this._eventListBox.SelectedRows) {
            this._typeComboBox.SelectedItem = (string) row.Cells["type"].Value;
            this._descriptionTextBox.Text = (string) row.Cells["description"].Value;
            this.AuthorTextLabel.Text = (string) row.Cells["author"].Value;
            this._editRow = row; // Update the row currently being edited
        }
        HighlightRow(this._editRow, Color.Orange, Color.Black); // Mark row with color
        this._eventListBox.ClearSelection();
        if (this._editRow != null) { // If we're currently editing a row...
            this._addEventButton.Text = "Update";
            eventMode = EditMode.Update;
        }
    }

    void DeleteEvent(object s, EventArgs e)
    {
        if (eventMode == EditMode.Update) {
            MessageBox.Show("Please finish updating current event first.");
            return;
        }
        EventList searchItem = new EventList(), target = null;
        DataGridViewRow searchRow = null;
        // Should just be one selected, iterate through in case weird edge case arises
        foreach (DataGridViewRow row in this._eventListBox.SelectedRows) {
            searchRow = row;
        }
        if (searchRow == null)
        {
            MessageBox.Show("Unable to complete request at this time.");
            return;
        }
        searchItem.type = (string) searchRow.Cells["type"].Value;
        searchItem.description = (string) searchRow.Cells["description"].Value;
        searchItem.author = (string) searchRow.Cells["author"].Value;
        // Remove the current row item
        foreach (EventList eL in this._eventList) {
            if (eL.Equals(searchItem)) {
                target = eL;
                break;
            }
        }
        if (target != null) this._eventList.Remove(target);
        this._eventListBox.ClearSelection();
        UpdateEventList();
    }

    void AddEvents(object s, System.EventArgs e)
    {
        if (!checkFields()) return;
        switch (eventMode) {
            case EditMode.Add:
                EventList nE = new EventList // nE - newEvent
                {
                    author = this.AuthorTextLabel.Text,
                    description = this._descriptionTextBox.Text,
                    type = this._typeComboBox.SelectedItem.ToString()
                };
                this._eventList.Add(nE);
                UpdateEventList();
                break;
            case EditMode.Update:
                this._editRow.Cells["type"].Value = this._typeComboBox.SelectedItem.ToString();
                this._editRow.Cells["description"].Value = this._descriptionTextBox.Text;
                this._editRow.Cells["author"].Value = this.AuthorTextLabel.Text;
                // Switch back to event insertion mode from update mode
                this._addEventButton.Text = "Add Event";
                eventMode = EditMode.Add; // Switch back to add mode
                UpdateEventList();
                break;
            default:
                break;
        }
    }

    void ClearEventPage() {
        this._eventList.Clear();
        UpdateEventList();
        this.detailList.Clear();
        this._typeComboBox.Text = "";
        UpdateDetailList();
    }
    void SubmitClick(object sender, System.EventArgs e)
    {
        if (eventMode == EditMode.Update) {
            MessageBox.Show("Please exit update mode to submit changes.");
            return;
        }
        if (detailList.Count == 0)
        {
            MessageBox.Show("Please enter at least one serial number to add an event.");
            return;
        }
        if (_eventList.Count == 0)
        {
            if (checkFields()) MessageBox.Show("Please enter at least one event.");
            return;
        }

        WaitWindow waitWindow = new WaitWindow();
        waitWindow.TopMost = true;
        waitWindow.StartPosition = FormStartPosition.CenterScreen;
        waitWindow.FormBorderStyle = FormBorderStyle.None;
        waitWindow.Show();
        this.Cursor = Cursors.WaitCursor;

        SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        connection.Open();
        string Author, Description, Type;
        foreach (EventList eL in this._eventList) {
            Author = eL.author;
            Description = eL.description;
            Type = eL.type;
            for (int i = 0; i < detailList.Count; i++)
            {
                string ProductSN;
                ProductSN = detailList[i].serialNo;
                string insertQuery = "INSERT INTO Event(ProductSN, Author, Description, Type) Values (@ProductSN, @Author, @Description, @Type)";
                    // Add Product to Product Table
                SqlCommand productCommand = new SqlCommand(insertQuery, connection);
                productCommand.Parameters.AddWithValue("@ProductSN", ProductSN);
                productCommand.Parameters.AddWithValue("@Author", Author);
                productCommand.Parameters.AddWithValue("@Description", Description);
                productCommand.Parameters.AddWithValue("@Type", Type);
                productCommand.ExecuteNonQuery();
            }
        }
        connection.Close();

        this.Cursor = Cursors.Default;
        waitWindow.Close();

        MessageBox.Show("Events added successfully");
        // Clear event page contents after a successful submission
        ClearEventPage();
    }


    void SearchClick (object sender, System.EventArgs e){
        if (SearchEvent.Text == String.Empty)
        {
            MessageBox.Show("Product Serial Number is Required");
            return;
        }
        string serialNumber = SearchEvent.Text;
        this._typeComboBox.Items.Clear();
        this._typeComboBox.Text = "";

        SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        connection.Open();
        SqlCommand checkSNQuery = new SqlCommand("SELECT ProductType FROM Product WHERE ([ProductSN] = @serialNumber)", connection);
        checkSNQuery.Parameters.AddWithValue("@serialNumber", serialNumber);
        SqlDataReader reader = checkSNQuery.ExecuteReader();
        if (!reader.HasRows) {
            MessageBox.Show("Serial Number Does Not Exist");
            return;
        }
        string productType = null;
        while (reader.Read())
        {
            productType = reader[0].ToString();
        }

        connection.Close();
        List<EventListItem> eventList = Menu.ProductTypeList[productType].OrderBy(o => o.SeqOrder).ToList();
        foreach (EventListItem eventitem in eventList)
            this._typeComboBox.Items.Add(eventitem.EventName);

        EventDetails newSN = new EventDetails
        {
            serialNo = SearchEvent.Text
        };
        detailList.Add(newSN);
        UpdateDetailList();
    }

}
