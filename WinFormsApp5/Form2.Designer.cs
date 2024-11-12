namespace WinFormsApp5
{
    partial class Form2
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
            LoginButton = new Button();
            userNameTextBox = new TextBox();
            radioButtonUser = new RadioButton();
            radioButtonAdmin = new RadioButton();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(346, 243);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(115, 42);
            LoginButton.TabIndex = 1;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += button1_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(252, 214);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(308, 23);
            userNameTextBox.TabIndex = 3;
            // 
            // radioButtonUser
            // 
            radioButtonUser.AutoSize = true;
            radioButtonUser.Location = new Point(252, 189);
            radioButtonUser.Name = "radioButtonUser";
            radioButtonUser.RightToLeft = RightToLeft.No;
            radioButtonUser.Size = new Size(102, 19);
            radioButtonUser.TabIndex = 4;
            radioButtonUser.TabStop = true;
            radioButtonUser.Text = "Пользователь";
            radioButtonUser.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdmin
            // 
            radioButtonAdmin.AutoSize = true;
            radioButtonAdmin.Location = new Point(448, 189);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(112, 19);
            radioButtonAdmin.TabIndex = 5;
            radioButtonAdmin.TabStop = true;
            radioButtonAdmin.Text = "Администратор";
            radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(radioButtonAdmin);
            Controls.Add(radioButtonUser);
            Controls.Add(userNameTextBox);
            Controls.Add(LoginButton);
            Name = "Form2";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button LoginButton;
        private TextBox userNameTextBox;
        private RadioButton radioButtonUser;
        private RadioButton radioButtonAdmin;
        private TextBox userIdTextBox;
    }
}