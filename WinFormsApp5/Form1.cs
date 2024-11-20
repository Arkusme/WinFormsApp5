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
        public class Driver
        {
            public int Id { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string PassportNumber { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string CertificateOfRegistration { get; set; }
            public string DriverLicense { get; set; }
            public string DateOfBirth { get; set; }
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
        private string GetSelectedDriverIds()
        {
            var selectedIds = driversDataGridView.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["Id"].Value.ToString())
                .ToList();

            return string.Join(",", selectedIds);
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
            string idsToEdit = GetSelectedDriverIds();
            if (string.IsNullOrEmpty(idsToEdit)) return;
            List<Driver> driversToUpdate = new List<Driver>();
            string selectDriver = $"SELECT Id, LastName, FirstName, MiddleName, PassportNumber, Phone, Address, CertificateOfRegistration, DriverLicense, DateOfBirth FROM Drivers WHERE Id IN ({idsToEdit})";

            using (var cmd = new SQLiteCommand(selectDriver, sqliteConn))
            {
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Driver driver = new Driver
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                PassportNumber = reader["PassportNumber"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                CertificateOfRegistration = reader["CertificateOfRegistration"].ToString(),
                                DriverLicense = reader["DriverLicense"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]).ToString("yyyy-MM-dd")
                            };
                            driversToUpdate.Add(driver);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
            foreach (var driver in driversToUpdate)
            {
                string updatedLastName = string.IsNullOrEmpty(SurnameTextBox.Text) ? driver.LastName : SurnameTextBox.Text;
                string updatedFirstName = string.IsNullOrEmpty(firstnametextbox.Text) ? driver.FirstName : firstnametextbox.Text;
                string updatedMiddleName = string.IsNullOrEmpty(middlenametextbox.Text) ? driver.MiddleName : middlenametextbox.Text;
                string updatedPassportNumber = string.IsNullOrEmpty(passportnumbertextbox.Text) ? driver.PassportNumber : passportnumbertextbox.Text;
                string updatedPhone = string.IsNullOrEmpty(phonetextbox.Text) ? driver.Phone : phonetextbox.Text;
                string updatedAddress = string.IsNullOrEmpty(addresstextbox.Text) ? driver.Address : addresstextbox.Text;
                string updatedCertificateOfRegistration = string.IsNullOrEmpty(certificateofregistrationtextbox.Text) ? driver.CertificateOfRegistration : certificateofregistrationtextbox.Text;
                string updatedDriverLicense = string.IsNullOrEmpty(driverLicenseTextBox.Text) ? driver.DriverLicense : driverLicenseTextBox.Text;
                string updatedDateOfBirth = driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd");

                // Формируем полное имя
                string fullName = $"{updatedLastName} {updatedFirstName.Substring(0, 1)}. {updatedMiddleName.Substring(0, 1)}.";

                string updateDriver = "UPDATE Drivers SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, " +
                              "PassportNumber = @PassportNumber, Phone = @Phone, Address = @Address, " +
                              "CertificateOfRegistration = @CertificateOfRegistration, DriverLicense = @DriverLicense, " +
                              "DateOfBirth = @DateOfBirth, FullName = @FullName WHERE Id = @Id";

                using (var updateCmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    updateCmd.Parameters.AddWithValue("@Id", driver.Id);
                    updateCmd.Parameters.AddWithValue("@LastName", updatedLastName);
                    updateCmd.Parameters.AddWithValue("@FirstName", updatedFirstName);
                    updateCmd.Parameters.AddWithValue("@MiddleName", updatedMiddleName);
                    updateCmd.Parameters.AddWithValue("@PassportNumber", updatedPassportNumber);
                    updateCmd.Parameters.AddWithValue("@Phone", updatedPhone);
                    updateCmd.Parameters.AddWithValue("@Address", updatedAddress);
                    updateCmd.Parameters.AddWithValue("@CertificateOfRegistration", updatedCertificateOfRegistration);
                    updateCmd.Parameters.AddWithValue("@DriverLicense", updatedDriverLicense);
                    updateCmd.Parameters.AddWithValue("@DateOfBirth", updatedDateOfBirth);
                    updateCmd.Parameters.AddWithValue("@FullName", fullName);

                    updateCmd.ExecuteNonQuery();
                }
            }
            LoadDrivers();
        }
        private void Deletedriver_Click(object sender, EventArgs e)
        {
            var selectedRows = driversDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var idsToDelete = selectedRows.Cast<DataGridViewRow>().Select(row => Convert.ToInt32(row.Cells["Id"].Value)).ToList();

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранных водителей?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteDriver = $"DELETE FROM Drivers WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteDriver, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadDrivers();
            }
        }
    }
}