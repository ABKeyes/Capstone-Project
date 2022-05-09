namespace CapstoneApp.ProductDetailWindows
{
    partial class DetailsWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.apiContainers = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.fishbowlText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WarrantyStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.warrantyIcon = new System.Windows.Forms.PictureBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.warrantyEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.apiContainers)).BeginInit();
            this.apiContainers.Panel1.SuspendLayout();
            this.apiContainers.Panel2.SuspendLayout();
            this.apiContainers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warrantyIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Viewing Product Details";
            // 
            // apiContainers
            // 
            this.apiContainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apiContainers.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.apiContainers.Location = new System.Drawing.Point(0, 187);
            this.apiContainers.Name = "apiContainers";
            // 
            // apiContainers.Panel1
            // 
            this.apiContainers.Panel1.Controls.Add(this.label2);
            this.apiContainers.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.apiContainers_Panel1_Paint);
            // 
            // apiContainers.Panel2
            // 
            this.apiContainers.Panel2.Controls.Add(this.fishbowlText);
            this.apiContainers.Panel2.Controls.Add(this.button1);
            this.apiContainers.Panel2.Controls.Add(this.label3);
            this.apiContainers.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.apiContainers_Panel2_Paint);
            this.apiContainers.Size = new System.Drawing.Size(721, 364);
            this.apiContainers.SplitterDistance = 361;
            this.apiContainers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "aligni id: ";
            // 
            // fishbowlText
            // 
            this.fishbowlText.Location = new System.Drawing.Point(104, 116);
            this.fishbowlText.Name = "fishbowlText";
            this.fishbowlText.Size = new System.Drawing.Size(100, 23);
            this.fishbowlText.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update Fishbowl ID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "fishbowl id:";
            // 
            // WarrantyStart
            // 
            this.WarrantyStart.Enabled = false;
            this.WarrantyStart.Location = new System.Drawing.Point(116, 73);
            this.WarrantyStart.Name = "WarrantyStart";
            this.WarrantyStart.Size = new System.Drawing.Size(200, 23);
            this.WarrantyStart.TabIndex = 2;
            this.WarrantyStart.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Warranty Start:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Warranty End:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Active Warranty:";
            // 
            // warrantyIcon
            // 
            this.warrantyIcon.Image = global::CapstoneProject.Properties.Resources.No16x16;
            this.warrantyIcon.Location = new System.Drawing.Point(116, 51);
            this.warrantyIcon.Name = "warrantyIcon";
            this.warrantyIcon.Size = new System.Drawing.Size(20, 20);
            this.warrantyIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.warrantyIcon.TabIndex = 7;
            this.warrantyIcon.TabStop = false;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(322, 106);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // warrantyEnd
            // 
            this.warrantyEnd.Location = new System.Drawing.Point(116, 106);
            this.warrantyEnd.Name = "warrantyEnd";
            this.warrantyEnd.Size = new System.Drawing.Size(200, 23);
            this.warrantyEnd.TabIndex = 9;
            this.warrantyEnd.Value = new System.DateTime(2022, 2, 8, 0, 0, 0, 0);
            // 
            // DetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.warrantyEnd);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.warrantyIcon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WarrantyStart);
            this.Controls.Add(this.apiContainers);
            this.Controls.Add(this.label1);
            this.Name = "DetailsWindow";
            this.Size = new System.Drawing.Size(721, 551);
            this.apiContainers.Panel1.ResumeLayout(false);
            this.apiContainers.Panel1.PerformLayout();
            this.apiContainers.Panel2.ResumeLayout(false);
            this.apiContainers.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apiContainers)).EndInit();
            this.apiContainers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warrantyIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer apiContainers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker WarrantyStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox warrantyIcon;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.DateTimePicker warrantyEnd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fishbowlText;
    }
}
