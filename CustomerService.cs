using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic;

class CustomerDetails
{
    [System.ComponentModel.DisplayName("Customer Note")]
    public string note {get; set;}
    public CustomerDetails(string note)
    {
        this.note = note;
    }
}
public class CustomerService : Form
{
    private SqlConnectionStringBuilder _builder;
    private Button _submitButton;
    private TextBox _searchEvent;
    private DataGridView _detailListBox;
    private Panel _bulkAddPanel;
    List<CustomerDetails> detailList = new List<CustomerDetails>();
    public CustomerService(SqlConnectionStringBuilder connection)
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
    }

    public void InterfaceLayout()
    {

        // Submit
        this._submitButton = new Button { Height = Constants.AddPartButtonHeight, Width = Constants.AddPartButtonWidth };
        this._submitButton.Text = "Add Note";
        this._submitButton.Location = new System.Drawing.Point(680, 10);
        this._submitButton.Click += this.SubmitClick;
        this.Controls.Add(this._submitButton);

        //Search Textbox
        this._searchEvent = new TextBox();
        this._searchEvent.Focus();
        this._searchEvent.Size = new System.Drawing.Size(100, 25);
        this._searchEvent.Name = "Search Event";
        this._searchEvent.Location = new System.Drawing.Point(40, 10);
        this._searchEvent.Text = null;
        this._searchEvent.KeyDown += EnterPressed;
        this.Controls.Add(this._searchEvent);

        // Search Button
        Button searchGo = new Button {Height = 25, Width = 100};
        searchGo.Text = "Search";
        searchGo.Location = new System.Drawing.Point(160, 10);
        searchGo.Click += SearchClick;
        this.Controls.Add(searchGo);

        // Bulk Add Display
        this._bulkAddPanel = new Panel();
        this._bulkAddPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this._bulkAddPanel.AutoSize = true;
        this._bulkAddPanel.Location = new System.Drawing.Point(40, 40);
        this._bulkAddPanel.Name = "Bulk Parts Panel";
        this._bulkAddPanel.Size = new System.Drawing.Size(600, this.Height - 100);
        this.Controls.Add(this._bulkAddPanel);

        this._detailListBox = new DataGridView();
        this._detailListBox.AutoGenerateColumns = true;
        var bindingList = new BindingList<CustomerDetails>(detailList);
        var source = new BindingSource(bindingList, null);
        this._detailListBox.DataSource = source;
        this._detailListBox.Dock = DockStyle.Fill;
        this._detailListBox.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        this._bulkAddPanel.Controls.Add(this._detailListBox);
    }

    /*
    (void) SubmitClick sends the users input to the database.
    */
    void SubmitClick(object sender, System.EventArgs e)
    {
        Console.WriteLine(_searchEvent.Text);
        if(_searchEvent.Text == ""){
            MessageBox.Show("No Serial Number entered.");
        }
        else{
            string responseString = Prompt.ShowDialog("", "Add Note");

            if (responseString == null || responseString == "") {
                return;
            }
            string serialNumber = _searchEvent.Text;
            SqlConnection connection = new SqlConnection(_builder.ConnectionString);
            try {
                connection.Open();
                SqlCommand checkNotes = new SqlCommand("INSERT INTO Note(ProductSN, CreationTime, Note) VALUES (@serialNumber, @CreationTime, @Note)", connection);
                checkNotes.Parameters.AddWithValue("@serialNumber", serialNumber);
                checkNotes.Parameters.AddWithValue("@CreationTime", DateTime.Now);
                checkNotes.Parameters.AddWithValue("@Note", responseString);
                int checkQuery = checkNotes.ExecuteNonQuery();
                if (checkQuery < 1) {
                    MessageBox.Show("Serial Number Does Not Exist. Cannot Add Note.");
                    return;
                }
                MessageBox.Show("Note added Successfully");
                SearchClick();
            } catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }
    }

    /// <summary>
    /// When the enter key is pressed while in the search event textbox the program will attempt to search the database for the SN entered
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EnterPressed(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            this.SearchClick();
        }
    }

    /// <summary>
    /// Searched the SQL database for the SN found within the <see cref="_searchEvent"/> textbox.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchClick(object sender, System.EventArgs e) => this.SearchClick();
    private void SearchClick (){
        if (this._searchEvent.Text == String.Empty)
        {
            MessageBox.Show("Product Serial Number is Required");
            return;
        }
        string serialNumber = _searchEvent.Text;
        SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        try
        {
            this.detailList.Clear();
            connection.Open();
            SqlCommand checkNotes = new SqlCommand("SELECT * FROM Note WHERE ([ProductSN] = @serialNumber)", connection);
            checkNotes.Parameters.AddWithValue("@serialNumber", serialNumber);
            SqlDataReader reader = checkNotes.ExecuteReader();
            if (!reader.HasRows) {
                MessageBox.Show("Serial Number Does Not Exist or No Notes Were Found");
                return;
            }

            var bindingList = new BindingList<CustomerDetails>(detailList);
            var source = new BindingSource(bindingList, null);
            while (reader.Read())
            {
                this.detailList.Add(new CustomerDetails(reader[2].ToString()));
            }
            this._detailListBox.DataSource = source;
            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            MessageBox.Show($"Error While Attempting to Find {serialNumber}");
        }
    }
}
