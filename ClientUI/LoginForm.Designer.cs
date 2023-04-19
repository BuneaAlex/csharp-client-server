namespace Agency
{
    partial class LoginForm
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelAgency = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.agencyTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(321, 32);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(47, 16);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "LOGIN";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(188, 91);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(67, 16);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "username";
            // 
            // labelAgency
            // 
            this.labelAgency.AutoSize = true;
            this.labelAgency.Location = new System.Drawing.Point(188, 154);
            this.labelAgency.Name = "labelAgency";
            this.labelAgency.Size = new System.Drawing.Size(52, 16);
            this.labelAgency.TabIndex = 2;
            this.labelAgency.Text = "agency";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(189, 226);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(66, 16);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(191, 121);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(315, 22);
            this.usernameTextBox.TabIndex = 4;
            // 
            // agencyTextBox
            // 
            this.agencyTextBox.Location = new System.Drawing.Point(191, 189);
            this.agencyTextBox.Name = "agencyTextBox";
            this.agencyTextBox.Size = new System.Drawing.Size(315, 22);
            this.agencyTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(192, 260);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(315, 22);
            this.passwordTextBox.TabIndex = 6;
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(300, 333);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(85, 23);
            this.continueButton.TabIndex = 7;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.agencyTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelAgency);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelLogin);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion    }

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelAgency;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox agencyTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button continueButton;
    }
}