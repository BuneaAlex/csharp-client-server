namespace Agency
{
    partial class DestinationsForm
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
            this.labelDestination = new System.Windows.Forms.Label();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.destinationsDataGridView = new System.Windows.Forms.DataGridView();
            this.filteredDestinationsDataGridView = new System.Windows.Forms.DataGridView();
            this.logOutButton = new System.Windows.Forms.Button();
            this.buyButton = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.labelTourists = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.noOfSeatsTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.touristsTextBox = new System.Windows.Forms.TextBox();
            this.clientTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.destinationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredDestinationsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(13, 16);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(85, 20);
            this.labelDestination.TabIndex = 0;
            this.labelDestination.Text = "Destination";
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Location = new System.Drawing.Point(94, 16);
            this.destinationTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(133, 27);
            this.destinationTextBox.TabIndex = 1;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(297, 16);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(247, 27);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(247, 22);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(41, 20);
            this.labelDate.TabIndex = 3;
            this.labelDate.Text = "Date";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(605, 14);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 39);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // destinationsDataGridView
            // 
            this.destinationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.destinationsDataGridView.Location = new System.Drawing.Point(12, 104);
            this.destinationsDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.destinationsDataGridView.Name = "destinationsDataGridView";
            this.destinationsDataGridView.RowHeadersWidth = 51;
            this.destinationsDataGridView.RowTemplate.Height = 24;
            this.destinationsDataGridView.Size = new System.Drawing.Size(512, 298);
            this.destinationsDataGridView.TabIndex = 5;
            // 
            // filteredDestinationsDataGridView
            // 
            this.filteredDestinationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filteredDestinationsDataGridView.Location = new System.Drawing.Point(579, 104);
            this.filteredDestinationsDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filteredDestinationsDataGridView.Name = "filteredDestinationsDataGridView";
            this.filteredDestinationsDataGridView.RowHeadersWidth = 51;
            this.filteredDestinationsDataGridView.RowTemplate.Height = 24;
            this.filteredDestinationsDataGridView.Size = new System.Drawing.Size(250, 298);
            this.filteredDestinationsDataGridView.TabIndex = 6;
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(387, 484);
            this.logOutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(88, 41);
            this.logOutButton.TabIndex = 7;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(697, 484);
            this.buyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(117, 41);
            this.buyButton.TabIndex = 8;
            this.buyButton.Text = "Buy Ticket";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInfo.Location = new System.Drawing.Point(912, 40);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(44, 25);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "Info";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(873, 117);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(47, 20);
            this.labelClient.TabIndex = 10;
            this.labelClient.Text = "Client";
            // 
            // labelTourists
            // 
            this.labelTourists.AutoSize = true;
            this.labelTourists.Location = new System.Drawing.Point(873, 165);
            this.labelTourists.Name = "labelTourists";
            this.labelTourists.Size = new System.Drawing.Size(59, 20);
            this.labelTourists.TabIndex = 11;
            this.labelTourists.Text = "Tourists";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(873, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Number of seats";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(873, 225);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(62, 20);
            this.labelAddress.TabIndex = 12;
            this.labelAddress.Text = "Address";
            // 
            // noOfSeatsTextBox
            // 
            this.noOfSeatsTextBox.Location = new System.Drawing.Point(1010, 274);
            this.noOfSeatsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.noOfSeatsTextBox.Name = "noOfSeatsTextBox";
            this.noOfSeatsTextBox.Size = new System.Drawing.Size(228, 27);
            this.noOfSeatsTextBox.TabIndex = 17;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(1010, 221);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(228, 27);
            this.addressTextBox.TabIndex = 16;
            // 
            // touristsTextBox
            // 
            this.touristsTextBox.Location = new System.Drawing.Point(1010, 163);
            this.touristsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.touristsTextBox.Name = "touristsTextBox";
            this.touristsTextBox.Size = new System.Drawing.Size(228, 27);
            this.touristsTextBox.TabIndex = 15;
            // 
            // clientTextBox
            // 
            this.clientTextBox.Location = new System.Drawing.Point(1010, 110);
            this.clientTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.Size = new System.Drawing.Size(228, 27);
            this.clientTextBox.TabIndex = 14;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(1010, 383);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 29);
            this.confirmButton.TabIndex = 18;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // DestinationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 562);
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
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.filteredDestinationsDataGridView);
            this.Controls.Add(this.destinationsDataGridView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.destinationTextBox);
            this.Controls.Add(this.labelDestination);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DestinationsForm";
            this.Text = "DestinationsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DestinationsForm_FormClosed);
            this.Load += new System.EventHandler(this.DestinationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.destinationsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredDestinationsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridView destinationsDataGridView;
        private System.Windows.Forms.DataGridView filteredDestinationsDataGridView;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button buyButton;
        private Label labelInfo;
        private Label labelClient;
        private Label labelTourists;
        private Label label4;
        private Label labelAddress;
        private TextBox noOfSeatsTextBox;
        private TextBox addressTextBox;
        private TextBox touristsTextBox;
        private TextBox clientTextBox;
        private Button confirmButton;
    }
}