﻿namespace WinFormsApp5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            driversDataGridView = new DataGridView();
            SurnameTextBox = new TextBox();
            button1 = new Button();
            violationsDataGridView = new DataGridView();
            AutoDataGridView = new DataGridView();
            PolicemanDataGridView = new DataGridView();
            button2 = new Button();
            searchEmployeeTextBox = new TextBox();
            searchVehicleTextBox = new TextBox();
            button3 = new Button();
            driverLicenseTextBox = new TextBox();
            driverDateOfBirthPicker = new DateTimePicker();
            Adddriver = new Button();
            Editdriver = new Button();
            Deletedriver = new Button();
            label1 = new Label();
            label2 = new Label();
            firstnametextbox = new TextBox();
            middlenametextbox = new TextBox();
            label3 = new Label();
            passportnumbertextbox = new TextBox();
            label4 = new Label();
            phonetextbox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            addresstextbox = new TextBox();
            label7 = new Label();
            certificateofregistrationtextbox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AutoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PolicemanDataGridView).BeginInit();
            SuspendLayout();
            // 
            // driversDataGridView
            // 
            driversDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            driversDataGridView.Location = new Point(535, 35);
            driversDataGridView.Name = "driversDataGridView";
            driversDataGridView.RowTemplate.Height = 25;
            driversDataGridView.Size = new Size(369, 79);
            driversDataGridView.TabIndex = 0;
            // 
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(12, 35);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.Size = new Size(109, 23);
            SurnameTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(526, 140);
            button1.Name = "button1";
            button1.Size = new Size(122, 37);
            button1.TabIndex = 3;
            button1.Text = "Поиск водителей";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // violationsDataGridView
            // 
            violationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            violationsDataGridView.Location = new Point(535, 529);
            violationsDataGridView.Name = "violationsDataGridView";
            violationsDataGridView.RowTemplate.Height = 25;
            violationsDataGridView.Size = new Size(369, 74);
            violationsDataGridView.TabIndex = 4;
            // 
            // AutoDataGridView
            // 
            AutoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AutoDataGridView.Location = new Point(526, 326);
            AutoDataGridView.Name = "AutoDataGridView";
            AutoDataGridView.RowTemplate.Height = 25;
            AutoDataGridView.Size = new Size(369, 75);
            AutoDataGridView.TabIndex = 5;
            // 
            // PolicemanDataGridView
            // 
            PolicemanDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PolicemanDataGridView.Location = new Point(535, 429);
            PolicemanDataGridView.Name = "PolicemanDataGridView";
            PolicemanDataGridView.RowTemplate.Height = 25;
            PolicemanDataGridView.Size = new Size(369, 81);
            PolicemanDataGridView.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(300, 469);
            button2.Name = "button2";
            button2.Size = new Size(122, 41);
            button2.TabIndex = 7;
            button2.Text = "Поиск сотрудников ГАИ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // searchEmployeeTextBox
            // 
            searchEmployeeTextBox.Location = new Point(-1, 487);
            searchEmployeeTextBox.Name = "searchEmployeeTextBox";
            searchEmployeeTextBox.Size = new Size(109, 23);
            searchEmployeeTextBox.TabIndex = 8;
            // 
            // searchVehicleTextBox
            // 
            searchVehicleTextBox.Location = new Point(26, 370);
            searchVehicleTextBox.Name = "searchVehicleTextBox";
            searchVehicleTextBox.Size = new Size(109, 23);
            searchVehicleTextBox.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(284, 360);
            button3.Name = "button3";
            button3.Size = new Size(122, 41);
            button3.TabIndex = 10;
            button3.Text = "Поиск транспортного средства";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // driverLicenseTextBox
            // 
            driverLicenseTextBox.Location = new Point(349, 79);
            driverLicenseTextBox.Name = "driverLicenseTextBox";
            driverLicenseTextBox.Size = new Size(109, 23);
            driverLicenseTextBox.TabIndex = 11;
            // 
            // driverDateOfBirthPicker
            // 
            driverDateOfBirthPicker.Location = new Point(12, 129);
            driverDateOfBirthPicker.Name = "driverDateOfBirthPicker";
            driverDateOfBirthPicker.Size = new Size(224, 23);
            driverDateOfBirthPicker.TabIndex = 12;
            // 
            // Adddriver
            // 
            Adddriver.Location = new Point(663, 147);
            Adddriver.Name = "Adddriver";
            Adddriver.Size = new Size(75, 23);
            Adddriver.TabIndex = 13;
            Adddriver.Text = "добавить";
            Adddriver.UseVisualStyleBackColor = true;
            Adddriver.Click += Adddriver_Click;
            // 
            // Editdriver
            // 
            Editdriver.Location = new Point(744, 147);
            Editdriver.Name = "Editdriver";
            Editdriver.Size = new Size(75, 23);
            Editdriver.TabIndex = 14;
            Editdriver.Text = "изменить";
            Editdriver.UseVisualStyleBackColor = true;
            Editdriver.Click += Editdriver_Click;
            // 
            // Deletedriver
            // 
            Deletedriver.Location = new Point(825, 147);
            Deletedriver.Name = "Deletedriver";
            Deletedriver.Size = new Size(75, 23);
            Deletedriver.TabIndex = 15;
            Deletedriver.Text = "удалить";
            Deletedriver.UseVisualStyleBackColor = true;
            Deletedriver.Click += Deletedriver_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 17);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 16;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 17);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 17;
            label2.Text = "Имя";
            // 
            // firstnametextbox
            // 
            firstnametextbox.Location = new Point(127, 35);
            firstnametextbox.Name = "firstnametextbox";
            firstnametextbox.Size = new Size(100, 23);
            firstnametextbox.TabIndex = 18;
            // 
            // middlenametextbox
            // 
            middlenametextbox.Location = new Point(233, 35);
            middlenametextbox.Name = "middlenametextbox";
            middlenametextbox.Size = new Size(100, 23);
            middlenametextbox.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(254, 17);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 20;
            label3.Text = "Отчество";
            // 
            // passportnumbertextbox
            // 
            passportnumbertextbox.Location = new Point(349, 35);
            passportnumbertextbox.Name = "passportnumbertextbox";
            passportnumbertextbox.Size = new Size(100, 23);
            passportnumbertextbox.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(364, 17);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 22;
            label4.Text = "Паспорт";
            // 
            // phonetextbox
            // 
            phonetextbox.Location = new Point(12, 79);
            phonetextbox.Name = "phonetextbox";
            phonetextbox.Size = new Size(100, 23);
            phonetextbox.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 61);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 24;
            label5.Text = "Телефон";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(149, 61);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 25;
            label6.Text = "Адрес";
            // 
            // addresstextbox
            // 
            addresstextbox.Location = new Point(118, 79);
            addresstextbox.Name = "addresstextbox";
            addresstextbox.Size = new Size(100, 23);
            addresstextbox.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(264, 61);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 27;
            label7.Text = "СТС";
            // 
            // certificateofregistrationtextbox
            // 
            certificateofregistrationtextbox.Location = new Point(232, 79);
            certificateofregistrationtextbox.Name = "certificateofregistrationtextbox";
            certificateofregistrationtextbox.Size = new Size(101, 23);
            certificateofregistrationtextbox.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(332, 61);
            label8.Name = "label8";
            label8.Size = new Size(168, 15);
            label8.TabIndex = 29;
            label8.Text = "Водительское удостоверение";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(92, 111);
            label9.Name = "label9";
            label9.Size = new Size(90, 15);
            label9.TabIndex = 30;
            label9.Text = "Дата рождения";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 604);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(certificateofregistrationtextbox);
            Controls.Add(label7);
            Controls.Add(addresstextbox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(phonetextbox);
            Controls.Add(label4);
            Controls.Add(passportnumbertextbox);
            Controls.Add(label3);
            Controls.Add(middlenametextbox);
            Controls.Add(firstnametextbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Deletedriver);
            Controls.Add(Editdriver);
            Controls.Add(Adddriver);
            Controls.Add(driverDateOfBirthPicker);
            Controls.Add(driverLicenseTextBox);
            Controls.Add(button3);
            Controls.Add(searchVehicleTextBox);
            Controls.Add(searchEmployeeTextBox);
            Controls.Add(button2);
            Controls.Add(PolicemanDataGridView);
            Controls.Add(AutoDataGridView);
            Controls.Add(violationsDataGridView);
            Controls.Add(button1);
            Controls.Add(SurnameTextBox);
            Controls.Add(driversDataGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)AutoDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)PolicemanDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView driversDataGridView;
        private TextBox SurnameTextBox;
        private Button button1;
        private DataGridView violationsDataGridView;
        private DataGridView AutoDataGridView;
        private DataGridView PolicemanDataGridView;
        private Button button2;
        private TextBox searchEmployeeTextBox;
        private TextBox searchVehicleTextBox;
        private Button button3;
        private TextBox driverLicenseTextBox;
        private DateTimePicker driverDateOfBirthPicker;
        private Button Adddriver;
        private Button Editdriver;
        private Button Deletedriver;
        private Label label1;
        private Label label2;
        private TextBox firstnametextbox;
        private TextBox middlenametextbox;
        private Label label3;
        private TextBox passportnumbertextbox;
        private Label label4;
        private TextBox phonetextbox;
        private Label label5;
        private Label label6;
        private TextBox addresstextbox;
        private Label label7;
        private TextBox certificateofregistrationtextbox;
        private Label label8;
        private Label label9;
    }
}