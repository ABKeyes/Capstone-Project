using System;

namespace CapstoneApp
{
    partial class PrintSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSettings));
            this.usernameLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.showLabelLabel = new System.Windows.Forms.Label();
            this.labelSizeLabel = new System.Windows.Forms.Label();
            this.labelLocationLabel = new System.Windows.Forms.Label();
            this.qrSizeLabel = new System.Windows.Forms.Label();
            this.qrLocationLabel = new System.Windows.Forms.Label();
            this.previewLabel = new System.Windows.Forms.Label();
            this.printerLabel = new System.Windows.Forms.Label();
            this.printerBox = new System.Windows.Forms.ComboBox();
            this.useLabelBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.labelSizeBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLocationXBox = new System.Windows.Forms.TextBox();
            this.labelLocationYBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.qrSizeBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.qrLocationYBox = new System.Windows.Forms.TextBox();
            this.qrLocationXBox = new System.Windows.Forms.TextBox();
            this.labelLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.testPrintButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.Location = new System.Drawing.Point(12, 9);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(192, 37);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Print Settings";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(690, 528);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(82, 22);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Close";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // showLabelLabel
            // 
            this.showLabelLabel.AutoSize = true;
            this.showLabelLabel.Location = new System.Drawing.Point(12, 110);
            this.showLabelLabel.Name = "showLabelLabel";
            this.showLabelLabel.Size = new System.Drawing.Size(67, 15);
            this.showLabelLabel.TabIndex = 3;
            this.showLabelLabel.Text = "Show Label";
            // 
            // labelSizeLabel
            // 
            this.labelSizeLabel.AutoSize = true;
            this.labelSizeLabel.Location = new System.Drawing.Point(12, 140);
            this.labelSizeLabel.Name = "labelSizeLabel";
            this.labelSizeLabel.Size = new System.Drawing.Size(58, 15);
            this.labelSizeLabel.TabIndex = 4;
            this.labelSizeLabel.Text = "Label Size";
            // 
            // labelLocationLabel
            // 
            this.labelLocationLabel.AutoSize = true;
            this.labelLocationLabel.Location = new System.Drawing.Point(12, 170);
            this.labelLocationLabel.Name = "labelLocationLabel";
            this.labelLocationLabel.Size = new System.Drawing.Size(84, 15);
            this.labelLocationLabel.TabIndex = 5;
            this.labelLocationLabel.Text = "Label Location";
            // 
            // qrSizeLabel
            // 
            this.qrSizeLabel.AutoSize = true;
            this.qrSizeLabel.Location = new System.Drawing.Point(12, 200);
            this.qrSizeLabel.Name = "qrSizeLabel";
            this.qrSizeLabel.Size = new System.Drawing.Size(46, 15);
            this.qrSizeLabel.TabIndex = 6;
            this.qrSizeLabel.Text = "QR Size";
            // 
            // qrLocationLabel
            // 
            this.qrLocationLabel.AutoSize = true;
            this.qrLocationLabel.Location = new System.Drawing.Point(12, 230);
            this.qrLocationLabel.Name = "qrLocationLabel";
            this.qrLocationLabel.Size = new System.Drawing.Size(72, 15);
            this.qrLocationLabel.TabIndex = 7;
            this.qrLocationLabel.Text = "QR Location";
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.previewLabel.Location = new System.Drawing.Point(12, 300);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(127, 25);
            this.previewLabel.TabIndex = 8;
            this.previewLabel.Text = "Live Preview:";
            // 
            // printerLabel
            // 
            this.printerLabel.AutoSize = true;
            this.printerLabel.Location = new System.Drawing.Point(12, 80);
            this.printerLabel.Name = "printerLabel";
            this.printerLabel.Size = new System.Drawing.Size(42, 15);
            this.printerLabel.TabIndex = 9;
            this.printerLabel.Text = "Printer";
            // 
            // printerBox
            // 
            this.printerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printerBox.FormattingEnabled = true;
            this.printerBox.Location = new System.Drawing.Point(143, 79);
            this.printerBox.Name = "printerBox";
            this.printerBox.Size = new System.Drawing.Size(285, 23);
            this.printerBox.TabIndex = 11;
            // 
            // useLabelBox
            // 
            this.useLabelBox.AutoSize = true;
            this.useLabelBox.Location = new System.Drawing.Point(143, 110);
            this.useLabelBox.Name = "useLabelBox";
            this.useLabelBox.Size = new System.Drawing.Size(15, 14);
            this.useLabelBox.TabIndex = 12;
            this.useLabelBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "_________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "_________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "_________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "_________________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "_________________________";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "_________________________";
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Transparent;
            this.previewBox.Location = new System.Drawing.Point(12, 328);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(496, 222);
            this.previewBox.TabIndex = 19;
            this.previewBox.TabStop = false;
            // 
            // labelSizeBox
            // 
            this.labelSizeBox.Location = new System.Drawing.Point(143, 140);
            this.labelSizeBox.Name = "labelSizeBox";
            this.labelSizeBox.Size = new System.Drawing.Size(61, 23);
            this.labelSizeBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "pt";
            // 
            // labelLocationXBox
            // 
            this.labelLocationXBox.Location = new System.Drawing.Point(143, 170);
            this.labelLocationXBox.Name = "labelLocationXBox";
            this.labelLocationXBox.Size = new System.Drawing.Size(61, 23);
            this.labelLocationXBox.TabIndex = 22;
            // 
            // labelLocationYBox
            // 
            this.labelLocationYBox.Location = new System.Drawing.Point(234, 170);
            this.labelLocationYBox.Name = "labelLocationYBox";
            this.labelLocationYBox.Size = new System.Drawing.Size(61, 23);
            this.labelLocationYBox.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "%";
            // 
            // qrSizeBox
            // 
            this.qrSizeBox.Location = new System.Drawing.Point(143, 200);
            this.qrSizeBox.Name = "qrSizeBox";
            this.qrSizeBox.Size = new System.Drawing.Size(61, 23);
            this.qrSizeBox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 15);
            this.label11.TabIndex = 31;
            this.label11.Text = "y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(210, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "x";
            // 
            // qrLocationYBox
            // 
            this.qrLocationYBox.Location = new System.Drawing.Point(234, 230);
            this.qrLocationYBox.Name = "qrLocationYBox";
            this.qrLocationYBox.Size = new System.Drawing.Size(61, 23);
            this.qrLocationYBox.TabIndex = 29;
            // 
            // qrLocationXBox
            // 
            this.qrLocationXBox.Location = new System.Drawing.Point(143, 230);
            this.qrLocationXBox.Name = "qrLocationXBox";
            this.qrLocationXBox.Size = new System.Drawing.Size(61, 23);
            this.qrLocationXBox.TabIndex = 28;
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.BackColor = System.Drawing.Color.Transparent;
            this.labelLabel.Location = new System.Drawing.Point(365, 377);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(46, 15);
            this.labelLabel.TabIndex = 32;
            this.labelLabel.Text = "Sample";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(602, 528);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(82, 22);
            this.resetButton.TabIndex = 33;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // testPrintButton
            // 
            this.testPrintButton.Location = new System.Drawing.Point(514, 528);
            this.testPrintButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testPrintButton.Name = "testPrintButton";
            this.testPrintButton.Size = new System.Drawing.Size(82, 22);
            this.testPrintButton.TabIndex = 34;
            this.testPrintButton.Text = "Test Print";
            this.testPrintButton.UseVisualStyleBackColor = true;
            this.testPrintButton.Click += new System.EventHandler(this.TestPrint_Click);
            // 
            // PrintSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.testPrintButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.qrLocationYBox);
            this.Controls.Add(this.qrLocationXBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.qrSizeBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelLocationYBox);
            this.Controls.Add(this.labelLocationXBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelSizeBox);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.useLabelBox);
            this.Controls.Add(this.printerBox);
            this.Controls.Add(this.printerLabel);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.qrLocationLabel);
            this.Controls.Add(this.qrSizeLabel);
            this.Controls.Add(this.labelLocationLabel);
            this.Controls.Add(this.labelSizeLabel);
            this.Controls.Add(this.showLabelLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PrintSettings";
            this.Text = "The ProGrAnalog Almanac";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label showLabelLabel;
        private System.Windows.Forms.Label labelSizeLabel;
        private System.Windows.Forms.Label labelLocationLabel;
        private System.Windows.Forms.Label qrSizeLabel;
        private System.Windows.Forms.Label qrLocationLabel;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Label printerLabel;
        private System.Windows.Forms.ComboBox printerBox;
        private System.Windows.Forms.CheckBox useLabelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.TextBox labelSizeBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox labelLocationXBox;
        private System.Windows.Forms.TextBox labelLocationYBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox qrSizeBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox qrLocationYBox;
        private System.Windows.Forms.TextBox qrLocationXBox;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button testPrintButton;
    }
}
