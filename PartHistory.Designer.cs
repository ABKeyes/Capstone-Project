using System.Windows.Forms;

namespace CapstoneApp
{
    partial class PartHistory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tablePanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.columnCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.lotSearchButton = new System.Windows.Forms.Button();
            this.searchLot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchPart = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.productListDataView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productListDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tablePanel1);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel1MinSize = 220;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.productListDataView);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
            // 
            // tablePanel1
            // 
            this.tablePanel1.AutoSize = true;
            this.tablePanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablePanel1.ColumnCount = 1;
            this.tablePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel1.Controls.Add(this.columnCheckedListBox, 0, 9);
            this.tablePanel1.Controls.Add(this.label2, 0, 8);
            this.tablePanel1.Controls.Add(this.exportButton, 0, 7);
            this.tablePanel1.Controls.Add(this.detailsButton, 0, 6);
            this.tablePanel1.Controls.Add(this.lotSearchButton, 0, 5);
            this.tablePanel1.Controls.Add(this.searchLot, 0, 4);
            this.tablePanel1.Controls.Add(this.label1, 0, 3);
            this.tablePanel1.Controls.Add(this.searchButton, 0, 2);
            this.tablePanel1.Controls.Add(this.searchPart, 0, 1);
            this.tablePanel1.Controls.Add(this.TitleLabel, 0, 0);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.RowCount = 10;
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel1.Size = new System.Drawing.Size(220, 561);
            this.tablePanel1.TabIndex = 6;
            // 
            // columnCheckedListBox
            // 
            this.columnCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnCheckedListBox.Location = new System.Drawing.Point(3, 272);
            this.columnCheckedListBox.MinimumSize = new System.Drawing.Size(220, 0);
            this.columnCheckedListBox.MultiColumn = true;
            this.columnCheckedListBox.Name = "columnCheckedListBox";
            this.columnCheckedListBox.Size = new System.Drawing.Size(244, 288);
            this.columnCheckedListBox.TabIndex = 10;
            this.columnCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ColumnCheckedListBox_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 244);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Columns:";
            // 
            // exportButton
            // 
            this.exportButton.AutoSize = true;
            this.exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportButton.Location = new System.Drawing.Point(3, 216);
            this.exportButton.MaximumSize = new System.Drawing.Size(0, 25);
            this.exportButton.MinimumSize = new System.Drawing.Size(100, 25);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(244, 25);
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportClick);
            // 
            // detailsButton
            // 
            this.detailsButton.AutoSize = true;
            this.detailsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.detailsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsButton.Location = new System.Drawing.Point(3, 185);
            this.detailsButton.MaximumSize = new System.Drawing.Size(0, 25);
            this.detailsButton.MinimumSize = new System.Drawing.Size(100, 25);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(244, 25);
            this.detailsButton.TabIndex = 4;
            this.detailsButton.Text = "Details";
            this.detailsButton.UseVisualStyleBackColor = true;
            this.detailsButton.Click += new System.EventHandler(this.ProductDetails);
            // 
            // lotSearchButton
            // 
            this.lotSearchButton.AutoSize = true;
            this.lotSearchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lotSearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lotSearchButton.Location = new System.Drawing.Point(3, 154);
            this.lotSearchButton.MaximumSize = new System.Drawing.Size(0, 25);
            this.lotSearchButton.MinimumSize = new System.Drawing.Size(100, 25);
            this.lotSearchButton.Name = "lotSearchButton";
            this.lotSearchButton.Size = new System.Drawing.Size(244, 25);
            this.lotSearchButton.TabIndex = 7;
            this.lotSearchButton.Text = "Search";
            this.lotSearchButton.UseVisualStyleBackColor = true;
            this.lotSearchButton.Click += new System.EventHandler(this.LotSearchClick);
            // 
            // searchLot
            // 
            this.searchLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLot.Location = new System.Drawing.Point(3, 125);
            this.searchLot.Name = "searchLot";
            this.searchLot.Size = new System.Drawing.Size(244, 23);
            this.searchLot.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 97);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search Using Lot #:";
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = true;
            this.searchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButton.Location = new System.Drawing.Point(3, 69);
            this.searchButton.MaximumSize = new System.Drawing.Size(0, 25);
            this.searchButton.MinimumSize = new System.Drawing.Size(100, 25);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(244, 25);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SerialSearchClick);
            // 
            // searchPart
            // 
            this.searchPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPart.Location = new System.Drawing.Point(3, 38);
            this.searchPart.MaximumSize = new System.Drawing.Size(500, 25);
            this.searchPart.MinimumSize = new System.Drawing.Size(100, 25);
            this.searchPart.Name = "searchPart";
            this.searchPart.Size = new System.Drawing.Size(244, 25);
            this.searchPart.TabIndex = 1;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Location = new System.Drawing.Point(3, 0);
            this.TitleLabel.MaximumSize = new System.Drawing.Size(220, 0);
            this.TitleLabel.MinimumSize = new System.Drawing.Size(200, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.TitleLabel.Size = new System.Drawing.Size(220, 35);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Search Using Serial Number \r\nor Customer Name:";
            // 
            // productListDataView
            // 
            this.productListDataView.AllowUserToAddRows = false;
            this.productListDataView.AllowUserToDeleteRows = false;
            this.productListDataView.AllowUserToOrderColumns = true;
            this.productListDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productListDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productListDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productListDataView.Location = new System.Drawing.Point(0, 0);
            this.productListDataView.Name = "productListDataView";
            this.productListDataView.RowHeadersVisible = false;
            this.productListDataView.RowHeadersWidth = 220;
            this.productListDataView.RowTemplate.Height = 25;
            this.productListDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productListDataView.Size = new System.Drawing.Size(560, 561);
            this.productListDataView.TabIndex = 0;
            this.productListDataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartClick);
            this.productListDataView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CheckboxMouseUp);
            this.productListDataView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckboxChanged);
            // 
            // PartHistory
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "PartHistory";
            this.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productListDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddBin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.DataGridView productListDataView;
        private System.Windows.Forms.TextBox searchLot;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TableLayoutPanel tablePanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchPart;
        private System.Windows.Forms.CheckedListBox checkedListBoxControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox columnCheckedListBox;
        private System.Windows.Forms.Button lotSearchButton;
        private Label TitleLabel;
    }
}
