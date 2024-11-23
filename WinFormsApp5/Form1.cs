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
            string selectQuery = "SELECT a.CertificateOfRegistration, a.Make, a.Model, a.LicensePlate, a.Year, d.FullName AS OwnerName " +
                          "FROM Auto a JOIN Drivers d ON a.OwnerId = d.Id";

            using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
            {
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    AutoDataGridView.DataSource = table;
                }
            }
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
        private int GetNextDriverId()
        {
            // Получаем все существующие ID
            var ids = new List<int>();
            string selectQuery = "SELECT Id FROM Drivers";
            using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0)); // Предполагается, что Id - это первый столбец
                }
            }

            // Найти первый свободный ID
            for (int i = 1; i <= ids.Count + 1; i++)
            {
                if (!ids.Contains(i))
                {
                    return i;
                }
            }

            return ids.Count + 1; // Если все ID заняты, вернуть следующий
        }
        private bool IsDriverExists(string lastName, string firstName, string middleName, string passportNumber)
        {
            string selectQuery = "SELECT COUNT(*) FROM Drivers WHERE LastName = @LastName AND FirstName = @FirstName AND MiddleName = @MiddleName AND PassportNumber = @PassportNumber";
            using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@MiddleName", middleName);
                cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public class Car
        {
            public int Id { get; set; }
            public string CertificateOfRegistration { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string LicensePlate { get; set; }
            public int Year { get; set; }
            public int OwnerId { get; set; } // Убедитесь, что это ID владельца
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

        private void button3_Click(object sender, EventArgs e)//посмотреть
        {
            string licensePlate = PlatetextBox.Text; // Используйте текстовое поле для ввода номера

            string searchQuery = "SELECT * FROM Cars WHERE LicensePlate LIKE '%' || @LicensePlate || '%'";
            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@LicensePlate", licensePlate);

                using (var reader = cmd.ExecuteReader())
                {
                    // Обработка результатов поиска и вывод в carsDataGridView
                }
            }
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
            // Проверяем на уникальность
            if (IsDriverExists(lastName, firstname, middlename, passportnumber))
            {
                MessageBox.Show("Такой водитель уже существует.");
                return;
            }
            // Получаем следующий ID
            int nextId = GetNextDriverId();

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

        private void driversDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что вы кликнули по строке
            {
                DataGridViewRow row = this.driversDataGridView.Rows[e.RowIndex];

                // Здесь можете создать и показать форму с полными данными
                var driverDetailsForm = new DriverDetailsForm(
                    row.Cells["LastName"].Value.ToString(),
                    row.Cells["FirstName"].Value.ToString(),
                    row.Cells["MiddleName"].Value.ToString(),
                    row.Cells["PassportNumber"].Value.ToString(),
                    row.Cells["Phone"].Value.ToString(),
                    row.Cells["Address"].Value.ToString(),
                    row.Cells["CertificateOfRegistration"].Value.ToString(),
                    row.Cells["DriverLicense"].Value.ToString(),
                    Convert.ToDateTime(row.Cells["DateOfBirth"].Value)
                );

                driverDetailsForm.Show();
            }
        }

        private void AddCar_Click(object sender, EventArgs e)
        {
            string certificateOfRegistration = STStextBox.Text; // пример
            string make = MakeTextBox.Text; // пример
            string model = ModeltextBox.Text; // пример
            string licensePlate = PlatetextBox.Text; // пример
            int year = Convert.ToInt32(yeartextBox.Text); // пример (проверьте, что значение может быть преобразовано в int)

            try
            {
                // Получаем OwnerId на основе CertificateOfRegistration водителя
                string getOwnerIdQuery = "SELECT Id FROM Drivers WHERE CertificateOfRegistration = @CertificateOfRegistration";
                int ownerId = -1;

                using (var getOwnerIdCmd = new SQLiteCommand(getOwnerIdQuery, sqliteConn))
                {
                    getOwnerIdCmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                    object result = getOwnerIdCmd.ExecuteScalar();

                    if (result != null)
                    {
                        ownerId = Convert.ToInt32(result); // Присваиваем найденный Id
                    }
                }

                // Проверка, существует ли водитель с указанным свидетельством о регистрации
                if (ownerId != -1)
                {
                    // SQL для вставки данных об автомобиле
                    string insertCarQuery = "INSERT INTO Auto (CertificateOfRegistration, Make, Model, LicensePlate, Year, OwnerId) " +
                                             "VALUES (@CertificateOfRegistration, @Make, @Model, @LicensePlate, @Year, @OwnerId)";

                    using (var insertCmd = new SQLiteCommand(insertCarQuery, sqliteConn))
                    {
                        insertCmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                        insertCmd.Parameters.AddWithValue("@Make", make);
                        insertCmd.Parameters.AddWithValue("@Model", model);
                        insertCmd.Parameters.AddWithValue("@LicensePlate", licensePlate);
                        insertCmd.Parameters.AddWithValue("@Year", year);
                        insertCmd.Parameters.AddWithValue("@OwnerId", ownerId); // Используем найденный Id водителя

                        insertCmd.ExecuteNonQuery(); // Выполняем запрос
                    }

                    MessageBox.Show("Автомобиль успешно добавлен!");
                }
                else
                {
                    MessageBox.Show("Водитель с указанным свидетельством о регистрации не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автомобиля: {ex.Message}");
            }
        }

        private void EditCar_Click(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows; // Предположим, что carsDataGridView - это ваш DataGridView для автомобилей
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int carId = Convert.ToInt32(row.Cells["Id"].Value);//тоже исправить
                string updatedCertificateOfRegistration = STStextBox.Text;
                string updatedMake = MakeTextBox.Text;
                string updatedModel = ModeltextBox.Text;
                string updatedLicensePlate = PlatetextBox.Text;
                int updatedYear;
                int updatedOwnerId;

                if (!int.TryParse(yeartextBox.Text, out updatedYear))
                {
                    MessageBox.Show("Пожалуйста, введите корректный год.");
                    return;
                }

                string updateCar = "UPDATE Cars SET CertificateOfRegistration = @CertificateOfRegistration, Make = @Make, " +
                                    "Model = @Model, LicensePlate = @LicensePlate, Year = @Year, OwnerId = @OwnerId " +
                                    "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateCar, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", carId);
                    cmd.Parameters.AddWithValue("@CertificateOfRegistration", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@Make", updatedMake);
                    cmd.Parameters.AddWithValue("@Model", updatedModel);
                    cmd.Parameters.AddWithValue("@LicensePlate", updatedLicensePlate);
                    cmd.Parameters.AddWithValue("@Year", updatedYear);

                    cmd.ExecuteNonQuery(); // Выполняем обновление
                }
            }

            LoadAuto(); // Перезагрузить данные
        }

        private void DeleteCar_Click(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows; // Предположим, что carsDataGridView - это ваш DataGridView для автомобилей
            if (selectedRows.Count == 0) return;

            var idsToDelete = selectedRows.Cast<DataGridViewRow>().Select(row => Convert.ToInt32(row.Cells["Id"].Value)).ToList();//ошибка здесь!

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные автомобили?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteCar = $"DELETE FROM Cars WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteCar, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadAuto(); // Перезагрузить данные
            }
        }

        private void AutoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что вы кликнули по строке
            {
                DataGridViewRow row = this.AutoDataGridView.Rows[e.RowIndex];

                // Получаем данные для создания формы деталей автомобиля
                string certificateOfRegistration = row.Cells["CertificateOfRegistration"].Value.ToString();
                string make = row.Cells["Make"].Value.ToString();
                string model = row.Cells["Model"].Value.ToString();
                string licensePlate = row.Cells["LicensePlate"].Value.ToString();
                int year = Convert.ToInt32(row.Cells["Year"].Value);
                string ownerName = row.Cells["OwnerName"].Value.ToString();

                // Создайте и покажите форму с полными данными
                var autoDetailsForm = new AutoDetailsForm(certificateOfRegistration, make, model, licensePlate, year, ownerName);
                autoDetailsForm.Show();
            }
        }
    }
}