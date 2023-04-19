namespace Agency
{
    partial class BookingForm
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.labelTourists = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clientTextBox = new System.Windows.Forms.TextBox();
            this.touristsTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.noOfSeatsTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInfo.Location = new System.Drawing.Point(25, 26);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(44, 25);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Info";
            this.labelInfo.Click += new System.EventHandler(this.labelInfo_Click);
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(43, 115);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(47, 20);
            this.labelClient.TabIndex = 1;
            this.labelClient.Text = "Client";
            this.labelClient.Click += new System.EventHandler(this.labelClient_Click);
            // 
            // labelTourists
            // 
            this.labelTourists.AutoSize = true;
            this.labelTourists.Location = new System.Drawing.Point(43, 175);
            this.labelTourists.Name = "labelTourists";
            this.labelTourists.Size = new System.Drawing.Size(59, 20);
            this.labelTourists.TabIndex = 2;
            this.labelTourists.Text = "Tourists";
            this.labelTourists.Click += new System.EventHandler(this.labelTourists_Click);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(43, 234);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(62, 20);
            this.labelAddress.TabIndex = 3;
            this.labelAddress.Text = "Address";
            this.labelAddress.Click += new System.EventHandler(this.labelAddress_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Number of seats";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // clientTextBox
            // 
            this.clientTextBox.Location = new System.Drawing.Point(154, 115);
            this.clientTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.Size = new System.Drawing.Size(228, 27);
            this.clientTextBox.TabIndex = 5;
            this.clientTextBox.TextChanged += new System.EventHandler(this.clientTextBox_TextChanged);
            // 
            // touristsTextBox
            // 
            this.touristsTextBox.Location = new System.Drawing.Point(154, 168);
            this.touristsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.touristsTextBox.Name = "touristsTextBox";
            this.touristsTextBox.Size = new System.Drawing.Size(228, 27);
            this.touristsTextBox.TabIndex = 6;
            this.touristsTextBox.TextChanged += new System.EventHandler(this.touristsTextBox_TextChanged);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(154, 226);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(228, 27);
            this.addressTextBox.TabIndex = 7;
            this.addressTextBox.TextChanged += new System.EventHandler(this.addressTextBox_TextChanged);
            // 
            // noOfSeatsTextBox
            // 
            this.noOfSeatsTextBox.Location = new System.Drawing.Point(154, 279);
            this.noOfSeatsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.noOfSeatsTextBox.Name = "noOfSeatsTextBox";
            this.noOfSeatsTextBox.Size = new System.Drawing.Size(228, 27);
            this.noOfSeatsTextBox.TabIndex = 8;
            this.noOfSeatsTextBox.TextChanged += new System.EventHandler(this.noOfSeatsTextBox_TextChanged);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(182, 414);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 29);
            this.confirmButton.TabIndex = 9;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 519);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 29);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 562);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.noOfSeatsTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.touristsTextBox);
            this.Controls.Add(this.clientTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelTourists);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.labelInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BookingForm";
            this.Text = "BookingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BookingForm_FormClosed);
            this.Load += new System.EventHandler(this.BookingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelTourists;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox clientTextBox;
        private System.Windows.Forms.TextBox touristsTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox noOfSeatsTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button backButton;
    }
}