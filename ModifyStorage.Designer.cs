namespace CapstoneApp
{
    partial class ModifyStorage
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
            this.Reset_Fields = new System.Windows.Forms.Button();
            this.storageDataGridView = new System.Windows.Forms.DataGridView();
            this.Select_Button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Selected_Items = new System.Windows.Forms.GroupBox();
            this.Selected_Bin = new System.Windows.Forms.Label();
            this.Bin_Label = new System.Windows.Forms.Label();
            this.Selected_Rack = new System.Windows.Forms.Label();
            this.Selected_Shelf = new System.Windows.Forms.Label();
            this.Shelf_Label = new System.Windows.Forms.Label();
            this.Rack_Label = new System.Windows.Forms.Label();
            this.Selected_Storeroom = new System.Windows.Forms.Label();
            this.Storeroom_Label = new System.Windows.Forms.Label();
            this.Add_Buttons = new System.Windows.Forms.GroupBox();
            this.Add_Bin = new System.Windows.Forms.Button();
            this.Add_Rack = new System.Windows.Forms.Button();
            this.Add_Shelf = new System.Windows.Forms.Button();
            this.Add_Storeroom = new System.Windows.Forms.Button();
            this.Delete_Buttons = new System.Windows.Forms.GroupBox();
            this.Delete_Bin = new System.Windows.Forms.Button();
            this.Delete_Storeroom = new System.Windows.Forms.Button();
            this.Delete_Rack = new System.Windows.Forms.Button();
            this.Delete_Shelf = new System.Windows.Forms.Button();
            this.Move_Buttons = new System.Windows.Forms.GroupBox();
            this.Move_Bin = new System.Windows.Forms.Button();
            this.Move_Rack = new System.Windows.Forms.Button();
            this.Move_Shelf = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.Other_Buttons = new System.Windows.Forms.GroupBox();
            this.Read_Bin = new System.Windows.Forms.Button();
            this.Message_Output = new System.Windows.Forms.TextBox();
            this.Message = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).BeginInit();
            this.Selected_Items.SuspendLayout();
            this.Add_Buttons.SuspendLayout();
            this.Delete_Buttons.SuspendLayout();
            this.Move_Buttons.SuspendLayout();
            this.Other_Buttons.SuspendLayout();
            this.Message.SuspendLayout();
            this.SuspendLayout();
            // 
            // Reset_Fields
            // 
            this.Reset_Fields.Location = new System.Drawing.Point(9, 45);
            this.Reset_Fields.Margin = new System.Windows.Forms.Padding(1);
            this.Reset_Fields.Name = "Reset_Fields";
            this.Reset_Fields.Size = new System.Drawing.Size(74, 26);
            this.Reset_Fields.TabIndex = 9;
            this.Reset_Fields.Text = "Reset";
            this.Reset_Fields.UseVisualStyleBackColor = true;
            this.Reset_Fields.Click += new System.EventHandler(this.Reset_Fields_Click);
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
            this.storageDataGridView.Location = new System.Drawing.Point(279, 99);
            this.storageDataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.storageDataGridView.Name = "storageDataGridView";
            this.storageDataGridView.RowHeadersWidth = 51;
            this.storageDataGridView.RowTemplate.Height = 25;
            this.storageDataGridView.Size = new System.Drawing.Size(279, 393);
            this.storageDataGridView.TabIndex = 10;
            this.storageDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StorageDataGridView_CellContentClick);
            // 
            // Select_Button
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Select";
            this.Select_Button.DefaultCellStyle = dataGridViewCellStyle1;
            this.Select_Button.HeaderText = "Select_Button";
            this.Select_Button.MinimumWidth = 6;
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.ReadOnly = true;
            this.Select_Button.Width = 125;
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
            this.Selected_Items.Location = new System.Drawing.Point(2, 1);
            this.Selected_Items.Margin = new System.Windows.Forms.Padding(1);
            this.Selected_Items.Name = "Selected_Items";
            this.Selected_Items.Padding = new System.Windows.Forms.Padding(1);
            this.Selected_Items.Size = new System.Drawing.Size(556, 78);
            this.Selected_Items.TabIndex = 11;
            this.Selected_Items.TabStop = false;
            this.Selected_Items.Text = "Selected";
            // 
            // Selected_Bin
            // 
            this.Selected_Bin.AutoSize = true;
            this.Selected_Bin.Location = new System.Drawing.Point(312, 50);
            this.Selected_Bin.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Bin.Name = "Selected_Bin";
            this.Selected_Bin.Size = new System.Drawing.Size(27, 15);
            this.Selected_Bin.TabIndex = 7;
            this.Selected_Bin.Text = "----";
            // 
            // Bin_Label
            // 
            this.Bin_Label.AutoSize = true;
            this.Bin_Label.Location = new System.Drawing.Point(275, 50);
            this.Bin_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Bin_Label.Name = "Bin_Label";
            this.Bin_Label.Size = new System.Drawing.Size(27, 15);
            this.Bin_Label.TabIndex = 6;
            this.Bin_Label.Text = "Bin:";
            // 
            // Selected_Rack
            // 
            this.Selected_Rack.AutoSize = true;
            this.Selected_Rack.Location = new System.Drawing.Point(312, 18);
            this.Selected_Rack.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Rack.Name = "Selected_Rack";
            this.Selected_Rack.Size = new System.Drawing.Size(27, 15);
            this.Selected_Rack.TabIndex = 5;
            this.Selected_Rack.Text = "----";
            // 
            // Selected_Shelf
            // 
            this.Selected_Shelf.AutoSize = true;
            this.Selected_Shelf.Location = new System.Drawing.Point(76, 50);
            this.Selected_Shelf.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Shelf.Name = "Selected_Shelf";
            this.Selected_Shelf.Size = new System.Drawing.Size(27, 15);
            this.Selected_Shelf.TabIndex = 3;
            this.Selected_Shelf.Text = "----";
            // 
            // Shelf_Label
            // 
            this.Shelf_Label.AutoSize = true;
            this.Shelf_Label.Location = new System.Drawing.Point(8, 50);
            this.Shelf_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Shelf_Label.Name = "Shelf_Label";
            this.Shelf_Label.Size = new System.Drawing.Size(39, 15);
            this.Shelf_Label.TabIndex = 2;
            this.Shelf_Label.Text = "Shelf: ";
            // 
            // Rack_Label
            // 
            this.Rack_Label.AutoSize = true;
            this.Rack_Label.Location = new System.Drawing.Point(275, 18);
            this.Rack_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Rack_Label.Name = "Rack_Label";
            this.Rack_Label.Size = new System.Drawing.Size(35, 15);
            this.Rack_Label.TabIndex = 4;
            this.Rack_Label.Text = "Rack:";
            // 
            // Selected_Storeroom
            // 
            this.Selected_Storeroom.AutoSize = true;
            this.Selected_Storeroom.Location = new System.Drawing.Point(76, 18);
            this.Selected_Storeroom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Selected_Storeroom.Name = "Selected_Storeroom";
            this.Selected_Storeroom.Size = new System.Drawing.Size(27, 15);
            this.Selected_Storeroom.TabIndex = 1;
            this.Selected_Storeroom.Text = "----";
            // 
            // Storeroom_Label
            // 
            this.Storeroom_Label.AutoSize = true;
            this.Storeroom_Label.Location = new System.Drawing.Point(8, 18);
            this.Storeroom_Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Storeroom_Label.Name = "Storeroom_Label";
            this.Storeroom_Label.Size = new System.Drawing.Size(66, 15);
            this.Storeroom_Label.TabIndex = 0;
            this.Storeroom_Label.Text = "Storeroom:";
            // 
            // Add_Buttons
            // 
            this.Add_Buttons.Controls.Add(this.Add_Bin);
            this.Add_Buttons.Controls.Add(this.Add_Rack);
            this.Add_Buttons.Controls.Add(this.Add_Shelf);
            this.Add_Buttons.Controls.Add(this.Add_Storeroom);
            this.Add_Buttons.Location = new System.Drawing.Point(2, 187);
            this.Add_Buttons.Margin = new System.Windows.Forms.Padding(1);
            this.Add_Buttons.Name = "Add_Buttons";
            this.Add_Buttons.Padding = new System.Windows.Forms.Padding(1);
            this.Add_Buttons.Size = new System.Drawing.Size(92, 134);
            this.Add_Buttons.TabIndex = 14;
            this.Add_Buttons.TabStop = false;
            this.Add_Buttons.Text = "Add";
            // 
            // Add_Bin
            // 
            this.Add_Bin.Location = new System.Drawing.Point(8, 102);
            this.Add_Bin.Margin = new System.Windows.Forms.Padding(1);
            this.Add_Bin.Name = "Add_Bin";
            this.Add_Bin.Size = new System.Drawing.Size(74, 26);
            this.Add_Bin.TabIndex = 3;
            this.Add_Bin.Text = "Bin";
            this.Add_Bin.UseVisualStyleBackColor = true;
            this.Add_Bin.Click += new System.EventHandler(this.Add_Bin_Click);
            // 
            // Add_Rack
            // 
            this.Add_Rack.Location = new System.Drawing.Point(8, 46);
            this.Add_Rack.Margin = new System.Windows.Forms.Padding(1);
            this.Add_Rack.Name = "Add_Rack";
            this.Add_Rack.Size = new System.Drawing.Size(74, 26);
            this.Add_Rack.TabIndex = 2;
            this.Add_Rack.Text = "Rack";
            this.Add_Rack.UseVisualStyleBackColor = true;
            this.Add_Rack.Click += new System.EventHandler(this.Add_Rack_Click);
            // 
            // Add_Shelf
            // 
            this.Add_Shelf.Location = new System.Drawing.Point(8, 74);
            this.Add_Shelf.Margin = new System.Windows.Forms.Padding(1);
            this.Add_Shelf.Name = "Add_Shelf";
            this.Add_Shelf.Size = new System.Drawing.Size(74, 26);
            this.Add_Shelf.TabIndex = 1;
            this.Add_Shelf.Text = "Shelf";
            this.Add_Shelf.UseVisualStyleBackColor = true;
            this.Add_Shelf.Click += new System.EventHandler(this.Add_Shelf_Click);
            // 
            // Add_Storeroom
            // 
            this.Add_Storeroom.Location = new System.Drawing.Point(8, 18);
            this.Add_Storeroom.Margin = new System.Windows.Forms.Padding(1);
            this.Add_Storeroom.Name = "Add_Storeroom";
            this.Add_Storeroom.Size = new System.Drawing.Size(74, 26);
            this.Add_Storeroom.TabIndex = 0;
            this.Add_Storeroom.Text = "Storeroom";
            this.Add_Storeroom.UseVisualStyleBackColor = true;
            this.Add_Storeroom.Click += new System.EventHandler(this.Add_Storeroom_Click);
            // 
            // Delete_Buttons
            // 
            this.Delete_Buttons.Controls.Add(this.Delete_Bin);
            this.Delete_Buttons.Controls.Add(this.Delete_Storeroom);
            this.Delete_Buttons.Controls.Add(this.Delete_Rack);
            this.Delete_Buttons.Controls.Add(this.Delete_Shelf);
            this.Delete_Buttons.Location = new System.Drawing.Point(154, 187);
            this.Delete_Buttons.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Buttons.Name = "Delete_Buttons";
            this.Delete_Buttons.Padding = new System.Windows.Forms.Padding(1);
            this.Delete_Buttons.Size = new System.Drawing.Size(92, 134);
            this.Delete_Buttons.TabIndex = 15;
            this.Delete_Buttons.TabStop = false;
            this.Delete_Buttons.Text = "Delete";
            // 
            // Delete_Bin
            // 
            this.Delete_Bin.Location = new System.Drawing.Point(9, 102);
            this.Delete_Bin.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Bin.Name = "Delete_Bin";
            this.Delete_Bin.Size = new System.Drawing.Size(74, 26);
            this.Delete_Bin.TabIndex = 18;
            this.Delete_Bin.Text = "Bin";
            this.Delete_Bin.UseVisualStyleBackColor = true;
            this.Delete_Bin.Click += new System.EventHandler(this.Delete_Bin_Click);
            // 
            // Delete_Storeroom
            // 
            this.Delete_Storeroom.Location = new System.Drawing.Point(9, 18);
            this.Delete_Storeroom.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Storeroom.Name = "Delete_Storeroom";
            this.Delete_Storeroom.Size = new System.Drawing.Size(74, 26);
            this.Delete_Storeroom.TabIndex = 0;
            this.Delete_Storeroom.Text = "Storeroom";
            this.Delete_Storeroom.UseVisualStyleBackColor = true;
            this.Delete_Storeroom.Click += new System.EventHandler(this.Delete_Storeroom_Click);
            // 
            // Delete_Rack
            // 
            this.Delete_Rack.Location = new System.Drawing.Point(9, 46);
            this.Delete_Rack.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Rack.Name = "Delete_Rack";
            this.Delete_Rack.Size = new System.Drawing.Size(74, 26);
            this.Delete_Rack.TabIndex = 17;
            this.Delete_Rack.Text = "Rack";
            this.Delete_Rack.UseVisualStyleBackColor = true;
            this.Delete_Rack.Click += new System.EventHandler(this.Delete_Rack_Click);
            // 
            // Delete_Shelf
            // 
            this.Delete_Shelf.Location = new System.Drawing.Point(9, 74);
            this.Delete_Shelf.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Shelf.Name = "Delete_Shelf";
            this.Delete_Shelf.Size = new System.Drawing.Size(74, 26);
            this.Delete_Shelf.TabIndex = 16;
            this.Delete_Shelf.Text = "Shelf";
            this.Delete_Shelf.UseVisualStyleBackColor = true;
            this.Delete_Shelf.Click += new System.EventHandler(this.Delete_Shelf_Click);
            // 
            // Move_Buttons
            // 
            this.Move_Buttons.Controls.Add(this.Move_Bin);
            this.Move_Buttons.Controls.Add(this.Move_Rack);
            this.Move_Buttons.Controls.Add(this.Move_Shelf);
            this.Move_Buttons.Location = new System.Drawing.Point(2, 350);
            this.Move_Buttons.Margin = new System.Windows.Forms.Padding(1);
            this.Move_Buttons.Name = "Move_Buttons";
            this.Move_Buttons.Padding = new System.Windows.Forms.Padding(1);
            this.Move_Buttons.Size = new System.Drawing.Size(92, 110);
            this.Move_Buttons.TabIndex = 16;
            this.Move_Buttons.TabStop = false;
            this.Move_Buttons.Text = "Move";
            // 
            // Move_Bin
            // 
            this.Move_Bin.Location = new System.Drawing.Point(8, 73);
            this.Move_Bin.Margin = new System.Windows.Forms.Padding(1);
            this.Move_Bin.Name = "Move_Bin";
            this.Move_Bin.Size = new System.Drawing.Size(74, 26);
            this.Move_Bin.TabIndex = 20;
            this.Move_Bin.Text = "Bin";
            this.Move_Bin.UseVisualStyleBackColor = true;
            this.Move_Bin.Click += new System.EventHandler(this.Move_Bin_Click);
            // 
            // Move_Rack
            // 
            this.Move_Rack.Location = new System.Drawing.Point(8, 18);
            this.Move_Rack.Margin = new System.Windows.Forms.Padding(1);
            this.Move_Rack.Name = "Move_Rack";
            this.Move_Rack.Size = new System.Drawing.Size(74, 25);
            this.Move_Rack.TabIndex = 19;
            this.Move_Rack.Text = "Rack";
            this.Move_Rack.UseVisualStyleBackColor = true;
            this.Move_Rack.Click += new System.EventHandler(this.Move_Rack_Click);
            // 
            // Move_Shelf
            // 
            this.Move_Shelf.Location = new System.Drawing.Point(8, 45);
            this.Move_Shelf.Margin = new System.Windows.Forms.Padding(1);
            this.Move_Shelf.Name = "Move_Shelf";
            this.Move_Shelf.Size = new System.Drawing.Size(74, 26);
            this.Move_Shelf.TabIndex = 18;
            this.Move_Shelf.Text = "Shelf";
            this.Move_Shelf.UseVisualStyleBackColor = true;
            this.Move_Shelf.Click += new System.EventHandler(this.Move_Shelf_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(9, 73);
            this.backButton.Margin = new System.Windows.Forms.Padding(1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(74, 26);
            this.backButton.TabIndex = 17;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Other_Buttons
            // 
            this.Other_Buttons.Controls.Add(this.Read_Bin);
            this.Other_Buttons.Controls.Add(this.backButton);
            this.Other_Buttons.Controls.Add(this.Reset_Fields);
            this.Other_Buttons.Location = new System.Drawing.Point(154, 350);
            this.Other_Buttons.Margin = new System.Windows.Forms.Padding(1);
            this.Other_Buttons.Name = "Other_Buttons";
            this.Other_Buttons.Padding = new System.Windows.Forms.Padding(1);
            this.Other_Buttons.Size = new System.Drawing.Size(92, 110);
            this.Other_Buttons.TabIndex = 18;
            this.Other_Buttons.TabStop = false;
            this.Other_Buttons.Text = "Other";
            // 
            // Read_Bin
            // 
            this.Read_Bin.Location = new System.Drawing.Point(9, 18);
            this.Read_Bin.Margin = new System.Windows.Forms.Padding(1);
            this.Read_Bin.Name = "Read_Bin";
            this.Read_Bin.Size = new System.Drawing.Size(74, 25);
            this.Read_Bin.TabIndex = 18;
            this.Read_Bin.Text = "Read Bin";
            this.Read_Bin.UseVisualStyleBackColor = true;
            this.Read_Bin.Click += new System.EventHandler(this.Read_Bin_Click);
            // 
            // Message_Output
            // 
            this.Message_Output.Location = new System.Drawing.Point(4, 18);
            this.Message_Output.Margin = new System.Windows.Forms.Padding(1);
            this.Message_Output.Multiline = true;
            this.Message_Output.Name = "Message_Output";
            this.Message_Output.ReadOnly = true;
            this.Message_Output.Size = new System.Drawing.Size(259, 75);
            this.Message_Output.TabIndex = 0;
            // 
            // Message
            // 
            this.Message.Controls.Add(this.Message_Output);
            this.Message.Location = new System.Drawing.Point(2, 81);
            this.Message.Margin = new System.Windows.Forms.Padding(1);
            this.Message.Name = "Message";
            this.Message.Padding = new System.Windows.Forms.Padding(1);
            this.Message.Size = new System.Drawing.Size(265, 101);
            this.Message.TabIndex = 19;
            this.Message.TabStop = false;
            this.Message.Text = "Message Box";
            // 
            // ModifyStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 502);
            this.Controls.Add(this.Other_Buttons);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Move_Buttons);
            this.Controls.Add(this.Delete_Buttons);
            this.Controls.Add(this.Add_Buttons);
            this.Controls.Add(this.Selected_Items);
            this.Controls.Add(this.storageDataGridView);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ModifyStorage";
            this.Text = "ModStorage";
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).EndInit();
            this.Selected_Items.ResumeLayout(false);
            this.Selected_Items.PerformLayout();
            this.Add_Buttons.ResumeLayout(false);
            this.Delete_Buttons.ResumeLayout(false);
            this.Move_Buttons.ResumeLayout(false);
            this.Other_Buttons.ResumeLayout(false);
            this.Message.ResumeLayout(false);
            this.Message.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Reset_Fields;
        private System.Windows.Forms.DataGridView storageDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn Select_Button;
        private System.Windows.Forms.GroupBox Selected_Items;
        private System.Windows.Forms.Label Selected_Storeroom;
        private System.Windows.Forms.Label Storeroom_Label;
        private System.Windows.Forms.Label Shelf_Label;
        private System.Windows.Forms.Label Selected_Shelf;
        private System.Windows.Forms.Label Selected_Bin;
        private System.Windows.Forms.Label Bin_Label;
        private System.Windows.Forms.Label Selected_Rack;
        private System.Windows.Forms.Label Rack_Label;
        private System.Windows.Forms.GroupBox Add_Buttons;
        private System.Windows.Forms.Button Add_Bin;
        private System.Windows.Forms.Button Add_Rack;
        private System.Windows.Forms.Button Add_Shelf;
        private System.Windows.Forms.Button Add_Storeroom;
        private System.Windows.Forms.GroupBox Delete_Buttons;
        private System.Windows.Forms.Button Delete_Bin;
        private System.Windows.Forms.Button Delete_Storeroom;
        private System.Windows.Forms.Button Delete_Rack;
        private System.Windows.Forms.Button Delete_Shelf;
        private System.Windows.Forms.GroupBox Move_Buttons;
        private System.Windows.Forms.Button Move_Bin;
        private System.Windows.Forms.Button Move_Rack;
        private System.Windows.Forms.Button Move_Shelf;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.GroupBox Other_Buttons;
        private System.Windows.Forms.Button Read_Bin;
        private System.Windows.Forms.TextBox Message_Output;
        private System.Windows.Forms.GroupBox Message;
    }
}
