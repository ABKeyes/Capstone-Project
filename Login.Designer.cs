using System;

namespace CapstoneApp
{
    partial class Login
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
            this.LoginInfo = new System.Windows.Forms.GroupBox();
            this.loginSubmit = new System.Windows.Forms.Button();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.Login_Button = new System.Windows.Forms.Button();
            this.LoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginInfo
            // 
            this.LoginInfo.Controls.Add(this.loginSubmit);
            this.LoginInfo.Controls.Add(this.passwordInput);
            this.LoginInfo.Controls.Add(this.passwordLabel);
            this.LoginInfo.Controls.Add(this.usernameInput);
            this.LoginInfo.Controls.Add(this.usernameLabel);
            this.LoginInfo.Location = new System.Drawing.Point(12, 11);
            this.LoginInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginInfo.Size = new System.Drawing.Size(193, 106);
            this.LoginInfo.TabIndex = 0;
            this.LoginInfo.TabStop = false;
            this.LoginInfo.Visible = false;
            // 
            // loginSubmit
            // 
            this.loginSubmit.Location = new System.Drawing.Point(103, 78);
            this.loginSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginSubmit.Name = "loginSubmit";
            this.loginSubmit.Size = new System.Drawing.Size(82, 22);
            this.loginSubmit.TabIndex = 4;
            this.loginSubmit.Text = "Submit";
            this.loginSubmit.UseVisualStyleBackColor = true;
            this.loginSubmit.Click += new System.EventHandler(this.loginSubmit_Click);
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(76, 53);
            this.passwordInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(110, 23);
            this.passwordInput.TabIndex = 3;
            this.passwordInput.Text = "test";
            this.passwordInput.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(5, 56);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(57, 15);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(76, 17);
            this.usernameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(110, 23);
            this.usernameInput.TabIndex = 1;
            this.usernameInput.Text = "test";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(5, 17);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(60, 15);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(315, 305);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(82, 22);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // Login_Button
            // 
            this.Login_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Login_Button.Location = new System.Drawing.Point(162, 158);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 23);
            this.Login_Button.TabIndex = 2;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(409, 338);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.LoginInfo);
            this.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.LoginInfo.ResumeLayout(false);
            this.LoginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.GroupBox LoginInfo;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Button loginSubmit;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button Login_Button;
    }
}
