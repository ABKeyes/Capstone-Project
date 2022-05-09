namespace CapstoneApp.ProductDetailWindows
{
    partial class ManageStorageWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Storage_Reset = new System.Windows.Forms.Button();
            this.CurrentStorageBox = new System.Windows.Forms.GroupBox();
            this.Storeroom_Value = new System.Windows.Forms.Label();
            this.Bin_Value = new System.Windows.Forms.Label();
            this.Shelf_Value = new System.Windows.Forms.Label();
            this.Rack_Value = new System.Windows.Forms.Label();
            this.Current_Storeroom = new System.Windows.Forms.Label();
            this.Current_Bin = new System.Windows.Forms.Label();
            this.Current_Rack = new System.Windows.Forms.Label();
            this.Current_Shelf = new System.Windows.Forms.Label();
            this.storageDataGridView = new System.Windows.Forms.DataGridView();
            this.Select_Button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.New_Storage = new System.Windows.Forms.GroupBox();
            this.New_Bin_Value = new System.Windows.Forms.Label();
            this.New_Shelf_Value = new System.Windows.Forms.Label();
            this.New_Bin = new System.Windows.Forms.Label();
            this.New_Shelf = new System.Windows.Forms.Label();
            this.New_Rack_Value = new System.Windows.Forms.Label();
            this.New_Rack = new System.Windows.Forms.Label();
            this.New_Storeroom_Value = new System.Windows.Forms.Label();
            this.New_Storeroom = new System.Windows.Forms.Label();
            this.Update_Storage = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.GroupBox();
            this.Message_Output = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.CurrentStorageBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).BeginInit();
            this.New_Storage.SuspendLayout();
            this.Message.SuspendLayout();
            this.SuspendLayout();
            // 
            // Storage_Reset
            // 
            this.Storage_Reset.Location = new System.Drawing.Point(96, 300);
            this.Storage_Reset.Name = "Storage_Reset";
            this.Storage_Reset.Size = new System.Drawing.Size(75, 23);
            this.Storage_Reset.TabIndex = 8;
            this.Storage_Reset.Text = "Reset";
            this.Storage_Reset.UseVisualStyleBackColor = true;
            this.Storage_Reset.Click += new System.EventHandler(this.Storage_Reset_Click);
            // 
            // CurrentStorageBox
            // 
            this.CurrentStorageBox.Controls.Add(this.Storeroom_Value);
            this.CurrentStorageBox.Controls.Add(this.Bin_Value);
            this.CurrentStorageBox.Controls.Add(this.Shelf_Value);
            this.CurrentStorageBox.Controls.Add(this.Rack_Value);
            this.CurrentStorageBox.Controls.Add(this.Current_Storeroom);
            this.CurrentStorageBox.Controls.Add(this.Current_Bin);
            this.CurrentStorageBox.Controls.Add(this.Current_Rack);
            this.CurrentStorageBox.Controls.Add(this.Current_Shelf);
            this.CurrentStorageBox.Location = new System.Drawing.Point(12, 12);
            this.CurrentStorageBox.Name = "CurrentStorageBox";
            this.CurrentStorageBox.Size = new System.Drawing.Size(558, 91);
            this.CurrentStorageBox.TabIndex = 10;
            this.CurrentStorageBox.TabStop = false;
            this.CurrentStorageBox.Text = "Current Storage";
            this.CurrentStorageBox.Enter += new System.EventHandler(this.CurrentStorageBox_Enter);
            // 
            // Storeroom_Value
            // 
            this.Storeroom_Value.AutoSize = true;
            this.Storeroom_Value.Location = new System.Drawing.Point(78, 19);
            this.Storeroom_Value.Name = "Storeroom_Value";
            this.Storeroom_Value.Size = new System.Drawing.Size(114, 15);
            this.Storeroom_Value.TabIndex = 7;
            this.Storeroom_Value.Text = "Placeholder---------";
            // 
            // Bin_Value
            // 
            this.Bin_Value.AutoSize = true;
            this.Bin_Value.Location = new System.Drawing.Point(285, 49);
            this.Bin_Value.Name = "Bin_Value";
            this.Bin_Value.Size = new System.Drawing.Size(114, 15);
            this.Bin_Value.TabIndex = 1;
            this.Bin_Value.Text = "Placeholder---------";
            // 
            // Shelf_Value
            // 
            this.Shelf_Value.AutoSize = true;
            this.Shelf_Value.Location = new System.Drawing.Point(48, 49);
            this.Shelf_Value.Name = "Shelf_Value";
            this.Shelf_Value.Size = new System.Drawing.Size(114, 15);
            this.Shelf_Value.TabIndex = 6;
            this.Shelf_Value.Text = "Placeholder---------";
            // 
            // Rack_Value
            // 
            this.Rack_Value.AutoSize = true;
            this.Rack_Value.Location = new System.Drawing.Point(294, 19);
            this.Rack_Value.Name = "Rack_Value";
            this.Rack_Value.Size = new System.Drawing.Size(114, 15);
            this.Rack_Value.TabIndex = 5;
            this.Rack_Value.Text = "Placeholder---------";
            // 
            // Current_Storeroom
            // 
            this.Current_Storeroom.AutoSize = true;
            this.Current_Storeroom.Location = new System.Drawing.Point(6, 19);
            this.Current_Storeroom.Name = "Current_Storeroom";
            this.Current_Storeroom.Size = new System.Drawing.Size(66, 15);
            this.Current_Storeroom.TabIndex = 4;
            this.Current_Storeroom.Text = "Storeroom:";
            // 
            // Current_Bin
            // 
            this.Current_Bin.AutoSize = true;
            this.Current_Bin.Location = new System.Drawing.Point(252, 49);
            this.Current_Bin.Name = "Current_Bin";
            this.Current_Bin.Size = new System.Drawing.Size(27, 15);
            this.Current_Bin.TabIndex = 0;
            this.Current_Bin.Text = "Bin:";
            // 
            // Current_Rack
            // 
            this.Current_Rack.AutoSize = true;
            this.Current_Rack.Location = new System.Drawing.Point(252, 19);
            this.Current_Rack.Name = "Current_Rack";
            this.Current_Rack.Size = new System.Drawing.Size(35, 15);
            this.Current_Rack.TabIndex = 2;
            this.Current_Rack.Text = "Rack:";
            // 
            // Current_Shelf
            // 
            this.Current_Shelf.AutoSize = true;
            this.Current_Shelf.Location = new System.Drawing.Point(6, 49);
            this.Current_Shelf.Name = "Current_Shelf";
            this.Current_Shelf.Size = new System.Drawing.Size(36, 15);
            this.Current_Shelf.TabIndex = 3;
            this.Current_Shelf.Text = "Shelf:";
            // 
            // storageDataGridView
            // 
            this.storageDataGridView.AllowUserToAddRows = false;
            this.storageDataGridView.AllowUserToDeleteRows = false;
            this.storageDataGridView.AllowUserToResizeColumns = false;
            this.storageDataGridView.AllowUserToResizeRows = false;
            this.storageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select_Button});
            this.storageDataGridView.Location = new System.Drawing.Point(268, 109);
            this.storageDataGridView.Name = "storageDataGridView";
            this.storageDataGridView.RowTemplate.Height = 25;
            this.storageDataGridView.Size = new System.Drawing.Size(302, 287);
            this.storageDataGridView.TabIndex = 19;
            this.storageDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.storageDataGridView_CellContentClick);
            // 
            // Select_Button
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Select";
            this.Select_Button.DefaultCellStyle = dataGridViewCellStyle1;
            this.Select_Button.HeaderText = "Select_Button";
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.ReadOnly = true;
            // 
            // New_Storage
            // 
            this.New_Storage.Controls.Add(this.New_Bin_Value);
            this.New_Storage.Controls.Add(this.New_Shelf_Value);
            this.New_Storage.Controls.Add(this.New_Bin);
            this.New_Storage.Controls.Add(this.New_Shelf);
            this.New_Storage.Controls.Add(this.New_Rack_Value);
            this.New_Storage.Controls.Add(this.New_Rack);
            this.New_Storage.Controls.Add(this.New_Storeroom_Value);
            this.New_Storage.Controls.Add(this.New_Storeroom);
            this.New_Storage.Location = new System.Drawing.Point(12, 173);
            this.New_Storage.Name = "New_Storage";
            this.New_Storage.Size = new System.Drawing.Size(250, 121);
            this.New_Storage.TabIndex = 20;
            this.New_Storage.TabStop = false;
            this.New_Storage.Text = "New Storage";
            // 
            // New_Bin_Value
            // 
            this.New_Bin_Value.AutoSize = true;
            this.New_Bin_Value.Location = new System.Drawing.Point(78, 95);
            this.New_Bin_Value.Name = "New_Bin_Value";
            this.New_Bin_Value.Size = new System.Drawing.Size(27, 15);
            this.New_Bin_Value.TabIndex = 7;
            this.New_Bin_Value.Text = "----";
            // 
            // New_Shelf_Value
            // 
            this.New_Shelf_Value.AutoSize = true;
            this.New_Shelf_Value.Location = new System.Drawing.Point(78, 70);
            this.New_Shelf_Value.Name = "New_Shelf_Value";
            this.New_Shelf_Value.Size = new System.Drawing.Size(27, 15);
            this.New_Shelf_Value.TabIndex = 6;
            this.New_Shelf_Value.Text = "----";
            // 
            // New_Bin
            // 
            this.New_Bin.AutoSize = true;
            this.New_Bin.Location = new System.Drawing.Point(6, 95);
            this.New_Bin.Name = "New_Bin";
            this.New_Bin.Size = new System.Drawing.Size(27, 15);
            this.New_Bin.TabIndex = 5;
            this.New_Bin.Text = "Bin:";
            // 
            // New_Shelf
            // 
            this.New_Shelf.AutoSize = true;
            this.New_Shelf.Location = new System.Drawing.Point(6, 70);
            this.New_Shelf.Name = "New_Shelf";
            this.New_Shelf.Size = new System.Drawing.Size(36, 15);
            this.New_Shelf.TabIndex = 4;
            this.New_Shelf.Text = "Shelf:";
            // 
            // New_Rack_Value
            // 
            this.New_Rack_Value.AutoSize = true;
            this.New_Rack_Value.Location = new System.Drawing.Point(78, 43);
            this.New_Rack_Value.Name = "New_Rack_Value";
            this.New_Rack_Value.Size = new System.Drawing.Size(27, 15);
            this.New_Rack_Value.TabIndex = 3;
            this.New_Rack_Value.Text = "----";
            // 
            // New_Rack
            // 
            this.New_Rack.AutoSize = true;
            this.New_Rack.Location = new System.Drawing.Point(6, 43);
            this.New_Rack.Name = "New_Rack";
            this.New_Rack.Size = new System.Drawing.Size(35, 15);
            this.New_Rack.TabIndex = 2;
            this.New_Rack.Text = "Rack:";
            // 
            // New_Storeroom_Value
            // 
            this.New_Storeroom_Value.AutoSize = true;
            this.New_Storeroom_Value.Location = new System.Drawing.Point(78, 19);
            this.New_Storeroom_Value.Name = "New_Storeroom_Value";
            this.New_Storeroom_Value.Size = new System.Drawing.Size(27, 15);
            this.New_Storeroom_Value.TabIndex = 1;
            this.New_Storeroom_Value.Text = "----";
            // 
            // New_Storeroom
            // 
            this.New_Storeroom.AutoSize = true;
            this.New_Storeroom.Location = new System.Drawing.Point(6, 19);
            this.New_Storeroom.Name = "New_Storeroom";
            this.New_Storeroom.Size = new System.Drawing.Size(66, 15);
            this.New_Storeroom.TabIndex = 0;
            this.New_Storeroom.Text = "Storeroom:";
            // 
            // Update_Storage
            // 
            this.Update_Storage.Location = new System.Drawing.Point(12, 300);
            this.Update_Storage.Name = "Update_Storage";
            this.Update_Storage.Size = new System.Drawing.Size(75, 23);
            this.Update_Storage.TabIndex = 21;
            this.Update_Storage.Text = "Update";
            this.Update_Storage.UseVisualStyleBackColor = true;
            this.Update_Storage.Click += new System.EventHandler(this.Update_Storage_Click);
            // 
            // Message
            // 
            this.Message.Controls.Add(this.Message_Output);
            this.Message.Location = new System.Drawing.Point(12, 109);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(250, 67);
            this.Message.TabIndex = 22;
            this.Message.TabStop = false;
            this.Message.Text = "Message Box";
            // 
            // Message_Output
            // 
            this.Message_Output.Location = new System.Drawing.Point(6, 16);
            this.Message_Output.Multiline = true;
            this.Message_Output.Name = "Message_Output";
            this.Message_Output.ReadOnly = true;
            this.Message_Output.Size = new System.Drawing.Size(238, 45);
            this.Message_Output.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(181, 300);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 23;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ManageStorageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 510);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Update_Storage);
            this.Controls.Add(this.New_Storage);
            this.Controls.Add(this.storageDataGridView);
            this.Controls.Add(this.CurrentStorageBox);
            this.Controls.Add(this.Storage_Reset);
            this.Name = "ManageStorageWindow";
            this.Text = "ManageStorageWindow";
            this.CurrentStorageBox.ResumeLayout(false);
            this.CurrentStorageBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).EndInit();
            this.New_Storage.ResumeLayout(false);
            this.New_Storage.PerformLayout();
            this.Message.ResumeLayout(false);
            this.Message.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Storage_Reset;
        private System.Windows.Forms.GroupBox CurrentStorageBox;
        private System.Windows.Forms.Label Storeroom_Value;
        private System.Windows.Forms.Label Shelf_Value;
        private System.Windows.Forms.Label Rack_Value;
        private System.Windows.Forms.Label Current_Storeroom;
        private System.Windows.Forms.Label Current_Shelf;
        private System.Windows.Forms.Label Current_Rack;
        private System.Windows.Forms.Label Bin_Value;
        private System.Windows.Forms.Label Current_Bin;
        private System.Windows.Forms.DataGridView storageDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn Select_Button;
        private System.Windows.Forms.GroupBox New_Storage;
        private System.Windows.Forms.Label New_Storeroom;
        private System.Windows.Forms.Label New_Storeroom_Value;
        private System.Windows.Forms.Label New_Rack;
        private System.Windows.Forms.Label New_Rack_Value;
        private System.Windows.Forms.Label New_Shelf;
        private System.Windows.Forms.Label New_Bin_Value;
        private System.Windows.Forms.Label New_Shelf_Value;
        private System.Windows.Forms.Label New_Bin;
        private System.Windows.Forms.Button Update_Storage;
        private System.Windows.Forms.GroupBox Message;
        private System.Windows.Forms.TextBox Message_Output;
        private System.Windows.Forms.Button backButton;
    }
}
