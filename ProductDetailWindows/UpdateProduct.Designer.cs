namespace CapstoneApp.ProductDetailWindows
{
    partial class UpdateProduct
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
            this.buttonCN = new System.Windows.Forms.Button();
            this.inputCN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonCN
            // 
            this.buttonCN.Location = new System.Drawing.Point(65, 99);
            this.buttonCN.Name = "buttonCN";
            this.buttonCN.Size = new System.Drawing.Size(75, 23);
            this.buttonCN.TabIndex = 1;
            this.buttonCN.Text = "Update";
            this.buttonCN.UseVisualStyleBackColor = true;
            this.buttonCN.Click += new System.EventHandler(this.buttonCN_Click);
            // 
            // inputCN
            // 
            this.inputCN.Location = new System.Drawing.Point(65, 70);
            this.inputCN.Name = "inputCN";
            this.inputCN.Size = new System.Drawing.Size(100, 23);
            this.inputCN.TabIndex = 2;
            this.inputCN.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Only update using existing customer names";
            // 
            // UpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputCN);
            this.Controls.Add(this.buttonCN);
            this.Controls.Add(this.label1);
            this.Name = "UpdateProduct";
            this.Size = new System.Drawing.Size(405, 299);
            this.Load += new System.EventHandler(this.UpdateProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCN;
        private System.Windows.Forms.TextBox inputCN;
        private System.Windows.Forms.Label label2;
    }
}
