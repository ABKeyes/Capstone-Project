namespace CapstoneApp.ProductDetailWindows
{
    partial class AddImageWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddImageWindow));
            this.imageOptionsPanel = new System.Windows.Forms.Panel();
            this.DeleteImageBtn = new System.Windows.Forms.Button();
            this.selectDifImageButton = new System.Windows.Forms.Button();
            this.insertImageButton = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.imageOptions = new System.Windows.Forms.Label();
            this.currentImage = new System.Windows.Forms.Label();
            this.Moveleft = new System.Windows.Forms.Button();
            this.moveRight = new System.Windows.Forms.Button();
            this.imageOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageOptionsPanel
            // 
            this.imageOptionsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.imageOptionsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imageOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageOptionsPanel.Controls.Add(this.DeleteImageBtn);
            this.imageOptionsPanel.Controls.Add(this.selectDifImageButton);
            this.imageOptionsPanel.Controls.Add(this.insertImageButton);
            this.imageOptionsPanel.Location = new System.Drawing.Point(624, 30);
            this.imageOptionsPanel.Name = "imageOptionsPanel";
            this.imageOptionsPanel.Size = new System.Drawing.Size(120, 290);
            this.imageOptionsPanel.TabIndex = 0;
            // 
            // DeleteImageBtn
            // 
            this.DeleteImageBtn.Location = new System.Drawing.Point(3, 71);
            this.DeleteImageBtn.Name = "DeleteImageBtn";
            this.DeleteImageBtn.Size = new System.Drawing.Size(112, 29);
            this.DeleteImageBtn.TabIndex = 2;
            this.DeleteImageBtn.Text = "Delete Image";
            this.DeleteImageBtn.UseVisualStyleBackColor = true;
            this.DeleteImageBtn.Click += new System.EventHandler(this.DeleteImageBtn_Click);
            // 
            // selectDifImageButton
            // 
            this.selectDifImageButton.Location = new System.Drawing.Point(3, 37);
            this.selectDifImageButton.Name = "selectDifImageButton";
            this.selectDifImageButton.Size = new System.Drawing.Size(112, 28);
            this.selectDifImageButton.TabIndex = 1;
            this.selectDifImageButton.Text = "Select Image";
            this.selectDifImageButton.UseVisualStyleBackColor = true;
            this.selectDifImageButton.Click += new System.EventHandler(this.SelectOnClick);
            // 
            // insertImageButton
            // 
            this.insertImageButton.Location = new System.Drawing.Point(3, 3);
            this.insertImageButton.Name = "insertImageButton";
            this.insertImageButton.Size = new System.Drawing.Size(112, 28);
            this.insertImageButton.TabIndex = 0;
            this.insertImageButton.Text = "Insert Image";
            this.insertImageButton.UseVisualStyleBackColor = true;
            this.insertImageButton.Click += new System.EventHandler(this.InsertOnClick);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("mainPictureBox.ErrorImage")));
            this.mainPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("mainPictureBox.InitialImage")));
            this.mainPictureBox.Location = new System.Drawing.Point(20, 30);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(580, 350);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            // 
            // imageOptions
            // 
            this.imageOptions.AutoSize = true;
            this.imageOptions.BackColor = System.Drawing.SystemColors.Control;
            this.imageOptions.Location = new System.Drawing.Point(633, 7);
            this.imageOptions.Name = "imageOptions";
            this.imageOptions.Size = new System.Drawing.Size(107, 20);
            this.imageOptions.TabIndex = 2;
            this.imageOptions.Text = "Image Options";
            // 
            // currentImage
            // 
            this.currentImage.AutoSize = true;
            this.currentImage.Location = new System.Drawing.Point(20, 7);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(103, 20);
            this.currentImage.TabIndex = 3;
            this.currentImage.Text = "Current Image";
            // 
            // Moveleft
            // 
            this.Moveleft.Location = new System.Drawing.Point(225, 399);
            this.Moveleft.Name = "Moveleft";
            this.Moveleft.Size = new System.Drawing.Size(63, 29);
            this.Moveleft.TabIndex = 5;
            this.Moveleft.Text = "<";
            this.Moveleft.UseVisualStyleBackColor = true;
            this.Moveleft.Click += new System.EventHandler(this.Moveleft_Click);
            // 
            // moveRight
            // 
            this.moveRight.Location = new System.Drawing.Point(306, 399);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(63, 29);
            this.moveRight.TabIndex = 5;
            this.moveRight.Text = ">";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.Click += new System.EventHandler(this.moveRight_Click);
            // 
            // AddImageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moveRight);
            this.Controls.Add(this.Moveleft);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.imageOptionsPanel);
            this.Controls.Add(this.imageOptions);
            this.Controls.Add(this.currentImage);
            this.Name = "AddImageWindow";
            this.Size = new System.Drawing.Size(759, 450);
            this.imageOptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel imageOptionsPanel;
        private System.Windows.Forms.Button insertImageButton;
        private System.Windows.Forms.Button selectDifImageButton;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Label imageOptions;
        private System.Windows.Forms.Label currentImage;
        private System.Windows.Forms.Button DeleteImageBtn;
        private System.Windows.Forms.Button Moveleft;
        private System.Windows.Forms.Button moveRight;

        public System.Windows.Forms.PictureBoxSizeMode SizeMode { get; set; }
    }
}
