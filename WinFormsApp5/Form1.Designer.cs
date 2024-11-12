namespace WinFormsApp5
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
            driverNameTextBox = new TextBox();
            button1 = new Button();
            violationsDataGridView = new DataGridView();
            vehiclesDataGridView = new DataGridView();
            employeesDataGridView = new DataGridView();
            button2 = new Button();
            searchEmployeeTextBox = new TextBox();
            searchVehicleTextBox = new TextBox();
            button3 = new Button();
            driverLicenseNumberTextBox = new TextBox();
            driverDateOfBirthPicker = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vehiclesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // driversDataGridView
            // 
            driversDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            driversDataGridView.Location = new Point(419, 35);
            driversDataGridView.Name = "driversDataGridView";
            driversDataGridView.RowTemplate.Height = 25;
            driversDataGridView.Size = new Size(369, 79);
            driversDataGridView.TabIndex = 0;
            // 
            // driverNameTextBox
            // 
            driverNameTextBox.Location = new Point(12, 35);
            driverNameTextBox.Name = "driverNameTextBox";
            driverNameTextBox.Size = new Size(109, 23);
            driverNameTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(282, 35);
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
            violationsDataGridView.Location = new Point(419, 349);
            violationsDataGridView.Name = "violationsDataGridView";
            violationsDataGridView.RowTemplate.Height = 25;
            violationsDataGridView.Size = new Size(369, 74);
            violationsDataGridView.TabIndex = 4;
            // 
            // vehiclesDataGridView
            // 
            vehiclesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            vehiclesDataGridView.Location = new Point(419, 136);
            vehiclesDataGridView.Name = "vehiclesDataGridView";
            vehiclesDataGridView.RowTemplate.Height = 25;
            vehiclesDataGridView.Size = new Size(369, 75);
            vehiclesDataGridView.TabIndex = 5;
            // 
            // employeesDataGridView
            // 
            employeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesDataGridView.Location = new Point(419, 232);
            employeesDataGridView.Name = "employeesDataGridView";
            employeesDataGridView.RowTemplate.Height = 25;
            employeesDataGridView.Size = new Size(369, 81);
            employeesDataGridView.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(291, 254);
            button2.Name = "button2";
            button2.Size = new Size(122, 41);
            button2.TabIndex = 7;
            button2.Text = "Поиск сотрудников ГАИ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // searchEmployeeTextBox
            // 
            searchEmployeeTextBox.Location = new Point(66, 264);
            searchEmployeeTextBox.Name = "searchEmployeeTextBox";
            searchEmployeeTextBox.Size = new Size(109, 23);
            searchEmployeeTextBox.TabIndex = 8;
            // 
            // searchVehicleTextBox
            // 
            searchVehicleTextBox.Location = new Point(66, 163);
            searchVehicleTextBox.Name = "searchVehicleTextBox";
            searchVehicleTextBox.Size = new Size(109, 23);
            searchVehicleTextBox.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(291, 153);
            button3.Name = "button3";
            button3.Size = new Size(122, 41);
            button3.TabIndex = 10;
            button3.Text = "Поиск транспортного средства";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // driverLicenseNumberTextBox
            // 
            driverLicenseNumberTextBox.Location = new Point(127, 35);
            driverLicenseNumberTextBox.Name = "driverLicenseNumberTextBox";
            driverLicenseNumberTextBox.Size = new Size(109, 23);
            driverLicenseNumberTextBox.TabIndex = 11;
            // 
            // driverDateOfBirthPicker
            // 
            driverDateOfBirthPicker.Location = new Point(12, 64);
            driverDateOfBirthPicker.Name = "driverDateOfBirthPicker";
            driverDateOfBirthPicker.Size = new Size(224, 23);
            driverDateOfBirthPicker.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(driverDateOfBirthPicker);
            Controls.Add(driverLicenseNumberTextBox);
            Controls.Add(button3);
            Controls.Add(searchVehicleTextBox);
            Controls.Add(searchEmployeeTextBox);
            Controls.Add(button2);
            Controls.Add(employeesDataGridView);
            Controls.Add(vehiclesDataGridView);
            Controls.Add(violationsDataGridView);
            Controls.Add(button1);
            Controls.Add(driverNameTextBox);
            Controls.Add(driversDataGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)vehiclesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView driversDataGridView;
        private TextBox driverNameTextBox;
        private Button button1;
        private DataGridView violationsDataGridView;
        private DataGridView vehiclesDataGridView;
        private DataGridView employeesDataGridView;
        private Button button2;
        private TextBox searchEmployeeTextBox;
        private TextBox searchVehicleTextBox;
        private Button button3;
        private TextBox driverLicenseNumberTextBox;
        private DateTimePicker driverDateOfBirthPicker;
    }
}