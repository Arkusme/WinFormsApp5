using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace WinFormsApp5
{
    public partial class Form1 : Form
    {

        private SQLiteConnection sqliteConn;
        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }
        private void InitializeDatabase()
        {
            sqliteConn = new SQLiteConnection("Data Source=C:\\Users\\vorob\\OneDrive\\Рабочий стол\\GAI;Version=3;");
            sqliteConn.Open();

        }
        private void ExecuteQuery(string query)
        {
            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        private void LoadData()
        {
            LoadDrivers();
            LoadAuto();
            LoadPoliceman();
            LoadViolations();
        }
        private void LoadDrivers()
        {
            var driverAdapter = new SQLiteDataAdapter("SELECT * FROM Drivers", sqliteConn);
            var driverTable = new DataTable();
            driverAdapter.Fill(driverTable);
            driversDataGridView.DataSource = driverTable;
        }
        private void LoadAuto()
        {
            var AutoAdapter = new SQLiteDataAdapter("SELECT * FROM Auto", sqliteConn);
            var AutoTable = new DataTable();
            AutoAdapter.Fill(AutoTable);
            AutoDataGridView.DataSource = AutoTable;
        }
        private void LoadPoliceman()
        {
            var PolicemanAdapter = new SQLiteDataAdapter("SELECT * FROM Policeman", sqliteConn);
            var PolicemanTable = new DataTable();
            PolicemanAdapter.Fill(PolicemanTable);
            PolicemanDataGridView.DataSource = PolicemanTable;
        }
        private void LoadViolations()
        {
            var violationAdapter = new SQLiteDataAdapter("SELECT * FROM Violations", sqliteConn);
            var violationTable = new DataTable();
            violationAdapter.Fill(violationTable);
            violationsDataGridView.DataSource = violationTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = SurnameTextBox.Text;
            string licenseNumber = driverLicenseTextBox.Text; // убедитесь, что это поле определено и заполняется
            string dateOfBirth = driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd");

            string insertDriver = "INSERT INTO Drivers (Name, LicenseNumber, DateOfBirth) VALUES (@Name, @LicenseNumber, @DateOfBirth)";
            using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber); // убедитесь, что эта переменная определена
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            }


            LoadData();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Закрытие соединения с базой данных
            if (sqliteConn != null && sqliteConn.State == ConnectionState.Open)
            {
                sqliteConn.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchName = searchEmployeeTextBox.Text;

            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Введите имя для поиска.");
                return;
            }

            var driverAdapter = new SQLiteDataAdapter("SELECT * FROM Employees WHERE Name LIKE @Name", sqliteConn);
            driverAdapter.SelectCommand.Parameters.AddWithValue("@Name", "%" + searchName + "%");
            var driverTable = new DataTable();
            driverAdapter.Fill(driverTable);
            PolicemanDataGridView.DataSource = driverTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchLicensePlate = searchVehicleTextBox.Text;

            if (string.IsNullOrEmpty(searchLicensePlate))
            {
                MessageBox.Show("Введите номер лицензии для поиска.");
                return;
            }

            var vehicleAdapter = new SQLiteDataAdapter("SELECT * FROM Vehicles WHERE LicensePlate LIKE @LicensePlate", sqliteConn);
            vehicleAdapter.SelectCommand.Parameters.AddWithValue("@LicensePlate", "%" + searchLicensePlate + "%");
            var vehicleTable = new DataTable();
            vehicleAdapter.Fill(vehicleTable);
            AutoDataGridView.DataSource = vehicleTable;
        }

        private void Adddriver_Click(object sender, EventArgs e)
        {
            string lastName = SurnameTextBox.Text;
            string firstname = firstnametextbox.Text;
            string middlename = middlenametextbox.Text;
            string passportnumber = passportnumbertextbox.Text;
            string phone = phonetextbox.Text;
            string address = addresstextbox.Text;
            string certificateofregistration = certificateofregistrationtextbox.Text;
            string driverlicense = driverLicenseTextBox.Text;
            string dateOfBirth = driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd");

            // Формируем полное имя в формате "Фамилия И. О."
            string fullName = $"{lastName} {firstname.Substring(0, 1)}. {middlename.Substring(0, 1)}.";

            // SQL для вставки данных
            string insertDriver = "INSERT INTO Drivers (LastName, FirstName, MiddleName, PassportNumber, Phone, Address, CertificateOfRegistration, DriverLicense, DateOfBirth, FullName) " +
                                  "VALUES (@LastName, @FirstName, @MiddleName, @PassportNumber, @Phone, @Address, @CertificateOfRegistration, @DriverLicense, @DateOfBirth, @FullName)";

            using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstname);
                cmd.Parameters.AddWithValue("@MiddleName", middlename);
                cmd.Parameters.AddWithValue("@PassportNumber", passportnumber);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateofregistration);
                cmd.Parameters.AddWithValue("@DriverLicense", driverlicense);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@FullName", fullName);

                cmd.ExecuteNonQuery(); // Выполняем запрос
            }

            LoadDrivers(); // Перезагрузить данные
        }

        private void Editdriver_Click(object sender, EventArgs e)
        {
            if (driversDataGridView.CurrentRow == null) return;

            int driverId = Convert.ToInt32(driversDataGridView.CurrentRow.Cells["Id"].Value);
            string selectDriver = "SELECT LastName, FirstName, MiddleName, PassportNumber, Phone, Address, CertificateOfRegistration, DriverLicense, DateOfBirth FROM Drivers WHERE Id = @Id";
            string lastName = null, firstName = null, middleName = null, passportNumber = null, phone = null, address = null, certificateOfRegistration = null, driverLicense = null, dateOfBirth = null;
            
            using (var cmd = new SQLiteCommand(selectDriver, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@Id", driverId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()){
                        lastName = reader["LastName"].ToString();
                        firstName = reader["FirstName"].ToString();
                        middleName = reader["MiddleName"].ToString();
                        passportNumber = reader["PassportNumber"].ToString();
                        phone = reader["Phone"].ToString();
                        address = reader["Address"].ToString();
                        certificateOfRegistration = reader["CertificateOfRegistration"].ToString();
                        driverLicense = reader["DriverLicense"].ToString();
                        dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]).ToString("yyyy-MM-dd");
                    }
                }
                string updatedLastName = string.IsNullOrEmpty(SurnameTextBox.Text) ? lastName : SurnameTextBox.Text;
                string updatedFirstName = string.IsNullOrEmpty(firstnametextbox.Text) ? firstName : firstnametextbox.Text;
                string updatedMiddleName = string.IsNullOrEmpty(middlenametextbox.Text) ? middleName : middlenametextbox.Text;
                string updatedPassportNumber = string.IsNullOrEmpty(passportnumbertextbox.Text) ? passportNumber : passportnumbertextbox.Text;
                string updatedPhone = string.IsNullOrEmpty(phonetextbox.Text) ? phone : phonetextbox.Text;
                string updatedAddress = string.IsNullOrEmpty(addresstextbox.Text) ? address : addresstextbox.Text;
                string updatedCertificateOfRegistration = string.IsNullOrEmpty(certificateofregistrationtextbox.Text) ? certificateOfRegistration : certificateofregistrationtextbox.Text;
                string updatedDriverLicense = string.IsNullOrEmpty(driverLicenseTextBox.Text) ? driverLicense : driverLicenseTextBox.Text;
                string updatedDateOfBirth = driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd"); // Здесь можно оставить настройку по умолчанию

                // Формируем полное имя
                string fullName = $"{updatedLastName} {updatedFirstName.Substring(0, 1)}. {updatedMiddleName.Substring(0, 1)}.";

                string updateDriver = "UPDATE Drivers SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, " +
                                      "PassportNumber = @PassportNumber, Phone = @Phone, Address = @Address, " +
                                      "CertificateOfRegistration = @CertificateOfRegistration, DriverLicense = @DriverLicense, " +
                                      "DateOfBirth = @DateOfBirth, FullName = @FullName WHERE Id = @Id";
                using (var updateCmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", driverId);
                    cmd.Parameters.AddWithValue("@LastName", updatedLastName);
                    cmd.Parameters.AddWithValue("@FirstName", updatedFirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", updatedMiddleName);
                    cmd.Parameters.AddWithValue("@PassportNumber", updatedPassportNumber);
                    cmd.Parameters.AddWithValue("@Phone", updatedPhone);
                    cmd.Parameters.AddWithValue("@Address", updatedAddress);
                    cmd.Parameters.AddWithValue("@CertificateOfRegistration", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@DriverLicense", updatedDriverLicense);
                    cmd.Parameters.AddWithValue("@DateOfBirth", updatedDateOfBirth);
                    cmd.Parameters.AddWithValue("@FullName", fullName);

                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
                LoadDrivers(); // Перезагрузить данные
            }

            
        }

        private void Deletedriver_Click(object sender, EventArgs e)
        {
            if (driversDataGridView.CurrentRow == null) return;

            int driverId = Convert.ToInt32(driversDataGridView.CurrentRow.Cells["Id"].Value);

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить данного водителя?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteDriver = "DELETE FROM Drivers WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(deleteDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", driverId);
                }

                LoadDrivers(); // Перезагрузить данные
            }
        }
    }
}