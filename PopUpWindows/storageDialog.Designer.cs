namespace CapstoneApp
{
    partial class storageDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.storageDataGridView = new System.Windows.Forms.DataGridView();
            this.Select_Button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Message = new System.Windows.Forms.GroupBox();
            this.Message_Output = new System.Windows.Forms.TextBox();
            this.Selected_Items = new System.Windows.Forms.GroupBox();
            this.Selected_Bin = new System.Windows.Forms.Label();
            this.Bin_Label = new System.Windows.Forms.Label();
            this.Selected_Rack = new System.Windows.Forms.Label();
            this.Selected_Shelf = new System.Windows.Forms.Label();
            this.Shelf_Label = new System.Windows.Forms.Label();
            this.Rack_Label = new System.Windows.Forms.Label();
            this.Selected_Storeroom = new System.Windows.Forms.Label();
            this.Storeroom_Label = new System.Windows.Forms.Label();
            this.other_Buttons = new System.Windows.Forms.GroupBox();
            this.Ok_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Reset_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).BeginInit();
            this.Message.SuspendLayout();
            this.Selected_Items.SuspendLayout();
            this.other_Buttons.SuspendLayout();
            this.SuspendLayout();
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
            this.storageDataGridView.Location = new System.Drawing.Point(220, 18);
            this.storageDataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.storageDataGridView.Name = "storageDataGridView";
            this.storageDataGridView.RowHeadersWidth = 51;
            this.storageDataGridView.RowTemplate.Height = 25;
            this.storageDataGridView.Size = new System.Drawing.Size(276, 421);
            this.storageDataGridView.TabIndex = 11;
            this.storageDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StorageDataGridView_CellContentClick);
            // 
            // Select_Button
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Select";
            this.Select_Button.DefaultCellStyle = dataGridViewCellStyle2;
            this.Select_Button.HeaderText = "Select_Button";
            this.Select_Button.MinimumWidth = 6;
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.ReadOnly = true;
            this.Select_Button.Width = 125;
            // 
            // Message
            // 
            this.Message.Controls.Add(this.Message_Output);
            this.Message.Location = new System.Drawing.Point(10, 10);
            this.Message.Margin = new System.Windows.Forms.Padding(1);
            this.Message.Name = "Message";
            this.Message.Padding = new System.Windows.Forms.Padding(1);
            this.Message.Size = new System.Drawing.Size(203, 101);
            this.Message.TabIndex = 20;
            this.Message.TabStop = false;
            this.Message.Text = "Message Box";
            // 
            // Message_Output
            // 
            this.Message_Output.Location = new System.Drawing.Point(4, 18);
            this.Message_Output.Margin = new System.Windows.Forms.Padding(1);
            this.Message_Output.Multiline = true;
            this.Message_Output.Name = "Message_Output";
            this.Message_Output.ReadOnly = true;
            this.Message_Output.Size = new System.Drawing.Size(199, 75);
            this.Message_Output.TabIndex = 0;
            // 
            // Selected_Items
            // 
            this.Selected_Items.Controls.Add(this.Selected_Bin);
            this.Selected_Items.Controls.Add(this.Bin_Label);
            this.Selected_Items.Controls.Add(this.Selected_Rack);
            this.Selected_Items.Controls.Add(this.Selected_Shelf);
            this.Selected_Items.Controls.Add(this.Shelf_Label);
            this.Selected_Items.Controls.Add(this.Rack_Label);
            this.Selected_Items.Controls.Add(this.Selected_Storeroom);
            this.Selected_Items.Controls.Add(this.Storeroom_Label);
            this.Selected_Items.Location = new System.Drawing.Point(10, 113);
            this.Selected_Items.Margin = new System.Windows.Forms.Padding(1);
            this.Selected_Items.Name = "Selected_Items";
            this.Selected_Items.Padding = new System.Windows.Forms.Padding(1);
            this.Selected_Items.Size = new System.Drawing.Size(203, 112);
            this.Selected_Items.TabIndex = 21;
            this.Selected_Items.TabStop = false;
            this.Selected_Items.Text = "Selected";
            // 
            // Selected_Bin
            // 
            this.Selected_Bin.AutoSize = true;
            this.Selected_Bin.Location = new System.Drawing.Point(35, 89);
            this.Selected_Bin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Bin.Name = "Selected_Bin";
            this.Selected_Bin.Size = new System.Drawing.Size(27, 15);
            this.Selected_Bin.TabIndex = 7;
            this.Selected_Bin.Text = "----";
            // 
            // Bin_Label
            // 
            this.Bin_Label.AutoSize = true;
            this.Bin_Label.Location = new System.Drawing.Point(6, 89);
            this.Bin_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Bin_Label.Name = "Bin_Label";
            this.Bin_Label.Size = new System.Drawing.Size(27, 15);
            this.Bin_Label.TabIndex = 6;
            this.Bin_Label.Text = "Bin:";
            // 
            // Selected_Rack
            // 
            this.Selected_Rack.AutoSize = true;
            this.Selected_Rack.Location = new System.Drawing.Point(43, 41);
            this.Selected_Rack.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Rack.Name = "Selected_Rack";
            this.Selected_Rack.Size = new System.Drawing.Size(27, 15);
            this.Selected_Rack.TabIndex = 5;
            this.Selected_Rack.Text = "----";
            // 
            // Selected_Shelf
            // 
            this.Selected_Shelf.AutoSize = true;
            this.Selected_Shelf.Location = new System.Drawing.Point(47, 65);
            this.Selected_Shelf.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Shelf.Name = "Selected_Shelf";
            this.Selected_Shelf.Size = new System.Drawing.Size(27, 15);
            this.Selected_Shelf.TabIndex = 3;
            this.Selected_Shelf.Text = "----";
            // 
            // Shelf_Label
            // 
            this.Shelf_Label.AutoSize = true;
            this.Shelf_Label.Location = new System.Drawing.Point(6, 65);
            this.Shelf_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Shelf_Label.Name = "Shelf_Label";
            this.Shelf_Label.Size = new System.Drawing.Size(39, 15);
            this.Shelf_Label.TabIndex = 2;
            this.Shelf_Label.Text = "Shelf: ";
            // 
            // Rack_Label
            // 
            this.Rack_Label.AutoSize = true;
            this.Rack_Label.Location = new System.Drawing.Point(6, 41);
            this.Rack_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Rack_Label.Name = "Rack_Label";
            this.Rack_Label.Size = new System.Drawing.Size(35, 15);
            this.Rack_Label.TabIndex = 4;
            this.Rack_Label.Text = "Rack:";
            // 
            // Selected_Storeroom
            // 
            this.Selected_Storeroom.AutoSize = true;
            this.Selected_Storeroom.Location = new System.Drawing.Point(74, 16);
            this.Selected_Storeroom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Storeroom.Name = "Selected_Storeroom";
            this.Selected_Storeroom.Size = new System.Drawing.Size(27, 15);
            this.Selected_Storeroom.TabIndex = 1;
            this.Selected_Storeroom.Text = "----";
            // 
            // Storeroom_Label
            // 
            this.Storeroom_Label.AutoSize = true;
            this.Storeroom_Label.Location = new System.Drawing.Point(6, 16);
            this.Storeroom_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Storeroom_Label.Name = "Storeroom_Label";
            this.Storeroom_Label.Size = new System.Drawing.Size(66, 15);
            this.Storeroom_Label.TabIndex = 0;
            this.Storeroom_Label.Text = "Storeroom:";
            // 
            // other_Buttons
            // 
            this.other_Buttons.Controls.Add(this.Ok_Button);
            this.other_Buttons.Controls.Add(this.Cancel_Button);
            this.other_Buttons.Controls.Add(this.Reset_Button);
            this.other_Buttons.Location = new System.Drawing.Point(10, 229);
            this.other_Buttons.Name = "other_Buttons";
            this.other_Buttons.Size = new System.Drawing.Size(89, 111);
            this.other_Buttons.TabIndex = 22;
            this.other_Buttons.TabStop = false;
            this.other_Buttons.Text = "Buttons";
            // 
            // Ok_Button
            // 
            this.Ok_Button.Location = new System.Drawing.Point(6, 51);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(75, 23);
            this.Ok_Button.TabIndex = 2;
            this.Ok_Button.Text = "Ok";
            this.Ok_Button.UseVisualStyleBackColor = true;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(6, 80);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(6, 22);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(75, 23);
            this.Reset_Button.TabIndex = 0;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // storageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.other_Buttons);
            this.Controls.Add(this.Selected_Items);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.storageDataGridView);
            this.Name = "storageDialog";
            this.Text = "storageDialog";
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).EndInit();
            this.Message.ResumeLayout(false);
            this.Message.PerformLayout();
            this.Selected_Items.ResumeLayout(false);
            this.Selected_Items.PerformLayout();
            this.other_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView storageDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn Select_Button;
        private System.Windows.Forms.GroupBox Message;
        private System.Windows.Forms.TextBox Message_Output;
        private System.Windows.Forms.GroupBox Selected_Items;
        private System.Windows.Forms.Label Selected_Bin;
        private System.Windows.Forms.Label Bin_Label;
        private System.Windows.Forms.Label Selected_Rack;
        private System.Windows.Forms.Label Selected_Shelf;
        private System.Windows.Forms.Label Shelf_Label;
        private System.Windows.Forms.Label Rack_Label;
        private System.Windows.Forms.Label Selected_Storeroom;
        private System.Windows.Forms.Label Storeroom_Label;
        private System.Windows.Forms.GroupBox other_Buttons;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Ok_Button;
    }
}
