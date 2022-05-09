namespace CapstoneApp
{
    partial class Admin
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
            this.AddUserBox = new System.Windows.Forms.GroupBox();
            this.AddUserHelpButton = new System.Windows.Forms.Button();
            this.RoleOfNewUser = new System.Windows.Forms.ComboBox();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.AddUserInput = new System.Windows.Forms.TextBox();
            this.ModifyUserBox = new System.Windows.Forms.GroupBox();
            this.roleOfModifyUser = new System.Windows.Forms.ComboBox();
            this.selectedUserDisplay = new System.Windows.Forms.TextBox();
            this.SelectedUser = new System.Windows.Forms.Label();
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.Select_Button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DropButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.Message_Output = new System.Windows.Forms.TextBox();
            this.AddUserBox.SuspendLayout();
            this.ModifyUserBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
            this.outputBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddUserBox
            // 
            this.AddUserBox.Controls.Add(this.AddUserHelpButton);
            this.AddUserBox.Controls.Add(this.RoleOfNewUser);
            this.AddUserBox.Controls.Add(this.AddUserButton);
            this.AddUserBox.Controls.Add(this.AddUserInput);
            this.AddUserBox.Location = new System.Drawing.Point(12, 12);
            this.AddUserBox.Name = "AddUserBox";
            this.AddUserBox.Size = new System.Drawing.Size(281, 84);
            this.AddUserBox.TabIndex = 0;
            this.AddUserBox.TabStop = false;
            this.AddUserBox.Text = "Add User";
            // 
            // AddUserHelpButton
            // 
            this.AddUserHelpButton.Location = new System.Drawing.Point(197, 50);
            this.AddUserHelpButton.Name = "AddUserHelpButton";
            this.AddUserHelpButton.Size = new System.Drawing.Size(75, 23);
            this.AddUserHelpButton.TabIndex = 3;
            this.AddUserHelpButton.Text = "Help";
            this.AddUserHelpButton.UseVisualStyleBackColor = true;
            // 
            // RoleOfNewUser
            // 
            this.RoleOfNewUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleOfNewUser.FormattingEnabled = true;
            this.RoleOfNewUser.Location = new System.Drawing.Point(6, 51);
            this.RoleOfNewUser.Name = "RoleOfNewUser";
            this.RoleOfNewUser.Size = new System.Drawing.Size(185, 23);
            this.RoleOfNewUser.TabIndex = 2;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(197, 22);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(75, 23);
            this.AddUserButton.TabIndex = 1;
            this.AddUserButton.Text = "Add";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // AddUserInput
            // 
            this.AddUserInput.Location = new System.Drawing.Point(6, 22);
            this.AddUserInput.Name = "AddUserInput";
            this.AddUserInput.Size = new System.Drawing.Size(185, 23);
            this.AddUserInput.TabIndex = 0;
            // 
            // ModifyUserBox
            // 
            this.ModifyUserBox.Controls.Add(this.roleOfModifyUser);
            this.ModifyUserBox.Controls.Add(this.selectedUserDisplay);
            this.ModifyUserBox.Controls.Add(this.SelectedUser);
            this.ModifyUserBox.Controls.Add(this.userDataGridView);
            this.ModifyUserBox.Controls.Add(this.DropButton);
            this.ModifyUserBox.Controls.Add(this.UpdateButton);
            this.ModifyUserBox.Location = new System.Drawing.Point(12, 102);
            this.ModifyUserBox.Name = "ModifyUserBox";
            this.ModifyUserBox.Size = new System.Drawing.Size(633, 284);
            this.ModifyUserBox.TabIndex = 1;
            this.ModifyUserBox.TabStop = false;
            this.ModifyUserBox.Text = "Modify";
            // 
            // roleOfModifyUser
            // 
            this.roleOfModifyUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleOfModifyUser.FormattingEnabled = true;
            this.roleOfModifyUser.Location = new System.Drawing.Point(6, 66);
            this.roleOfModifyUser.Name = "roleOfModifyUser";
            this.roleOfModifyUser.Size = new System.Drawing.Size(185, 23);
            this.roleOfModifyUser.TabIndex = 23;
            // 
            // selectedUserDisplay
            // 
            this.selectedUserDisplay.Location = new System.Drawing.Point(6, 37);
            this.selectedUserDisplay.Name = "selectedUserDisplay";
            this.selectedUserDisplay.ReadOnly = true;
            this.selectedUserDisplay.Size = new System.Drawing.Size(185, 23);
            this.selectedUserDisplay.TabIndex = 22;
            // 
            // SelectedUser
            // 
            this.SelectedUser.AutoSize = true;
            this.SelectedUser.Location = new System.Drawing.Point(6, 19);
            this.SelectedUser.Name = "SelectedUser";
            this.SelectedUser.Size = new System.Drawing.Size(33, 15);
            this.SelectedUser.TabIndex = 21;
            this.SelectedUser.Text = "User:";
            // 
            // userDataGridView
            // 
            this.userDataGridView.AllowUserToAddRows = false;
            this.userDataGridView.AllowUserToDeleteRows = false;
            this.userDataGridView.AllowUserToResizeColumns = false;
            this.userDataGridView.AllowUserToResizeRows = false;
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select_Button});
            this.userDataGridView.Dock = System.Windows.Forms.DockStyle.Right;
            this.userDataGridView.Location = new System.Drawing.Point(290, 19);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.RowTemplate.Height = 25;
            this.userDataGridView.Size = new System.Drawing.Size(340, 262);
            this.userDataGridView.TabIndex = 20;
            this.userDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataGridView_CellContentClick);
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
            // DropButton
            // 
            this.DropButton.Location = new System.Drawing.Point(206, 253);
            this.DropButton.Name = "DropButton";
            this.DropButton.Size = new System.Drawing.Size(75, 23);
            this.DropButton.TabIndex = 3;
            this.DropButton.Text = "Drop";
            this.DropButton.UseVisualStyleBackColor = true;
            this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(206, 224);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.Controls.Add(this.Message_Output);
            this.outputBox.Location = new System.Drawing.Point(299, 12);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(346, 84);
            this.outputBox.TabIndex = 2;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "Message Box";
            // 
            // Message_Output
            // 
            this.Message_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Message_Output.Location = new System.Drawing.Point(3, 19);
            this.Message_Output.Multiline = true;
            this.Message_Output.Name = "Message_Output";
            this.Message_Output.ReadOnly = true;
            this.Message_Output.Size = new System.Drawing.Size(340, 62);
            this.Message_Output.TabIndex = 0;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 390);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.ModifyUserBox);
            this.Controls.Add(this.AddUserBox);
            this.Name = "Admin";
            this.Text = "Admin";
            this.AddUserBox.ResumeLayout(false);
            this.AddUserBox.PerformLayout();
            this.ModifyUserBox.ResumeLayout(false);
            this.ModifyUserBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
            this.outputBox.ResumeLayout(false);
            this.outputBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddUserBox;
        private System.Windows.Forms.ComboBox RoleOfNewUser;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.TextBox AddUserInput;
        private System.Windows.Forms.GroupBox ModifyUserBox;
        private System.Windows.Forms.Button DropButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn Select_Button;
        private System.Windows.Forms.ComboBox roleOfModifyUser;
        private System.Windows.Forms.TextBox selectedUserDisplay;
        private System.Windows.Forms.Label SelectedUser;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.TextBox Message_Output;
        private System.Windows.Forms.Button AddUserHelpButton;
    }
}