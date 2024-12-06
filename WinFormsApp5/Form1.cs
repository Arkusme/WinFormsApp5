using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Net;
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
            try
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GAI.db");

                if (!File.Exists(dbPath))
                {
                    throw new FileNotFoundException("База данных не найдена по следующему пути: " + dbPath);
                }

                sqliteConn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
                sqliteConn.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
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
            string selectDrivers = "SELECT * FROM Drivers"; // SQL запрос для выборки данных
            using (var cmd = new SQLiteCommand(selectDrivers, sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    DataTable driversTable = new DataTable();
                    driversTable.Load(reader); // Загружаем данные из выборки в DataTable
                    driversDataGridView.DataSource = driversTable; // Устанавливаем источник данных
                }
            }

        }
        private void LoadAuto()
        {
            string selectQuery = "SELECT a.CertificateOfRegistration, a.Make, a.Model, a.LicensePlate, a.Year, d.FullName AS OwnerName " +
                          "FROM Auto a JOIN Drivers d ON a.OwnerName = d.FullName";

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
        private void button1_Click(object sender, EventArgs e)
        {
            string lastName = SurnameTextBox.Text.Trim();
            string firstName = firstnametextbox.Text.Trim();
            string middleName = middlenametextbox.Text.Trim();
            DateTime dateOfBirth = driverDateOfBirthPicker.Value; // Используем значение из DateTimePicker
            string certificateOfRegistration = certificateofregistrationtextbox.Text.Trim();

            string query = "SELECT * FROM Drivers WHERE 1=1"; // Начало запроса

            if (!string.IsNullOrEmpty(lastName))
                query += " AND LastName LIKE @lastName";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND FirstName LIKE @firstName";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND MiddleName LIKE @middleName";
            if (dateOfBirth != DateTime.MinValue) // Проверка на правильность даты
                query += " AND DateOfBirth = @dateOfBirth";
            if (!string.IsNullOrEmpty(certificateOfRegistration))
                query += " AND CertificateOfRegistration LIKE @certificateOfRegistration";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (!string.IsNullOrEmpty(lastName))
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                if (!string.IsNullOrEmpty(firstName))
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                if (!string.IsNullOrEmpty(middleName))
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                if (dateOfBirth != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"));
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                    cmd.Parameters.AddWithValue("@certificateOfRegistration", certificateOfRegistration);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    var drivers = new DataTable(); // Создаем временную таблицу для данных
                    drivers.Load(reader); // Загружаем данные из запроса в DataTable

                    if (drivers.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет таких водителей!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Оставьте DataGridView без изменений
                    }
                    else
                    {
                        driversDataGridView.DataSource = drivers; // Заполняем DataGridView новыми данными
                                                                  // Выделяем первую строку с данными, если она существует
                        driversDataGridView.Rows[0].Selected = true;
                        driversDataGridView.CurrentCell = driversDataGridView.Rows[0].Cells[0];
                    }
                }
            }
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
            string lastName = lastNameTextBox.Text.Trim();
            string rank = rankTextBox.Text.Trim();

            string query = "SELECT * FROM Policeman WHERE 1=1"; // Начало запроса

            if (!string.IsNullOrEmpty(lastName))
                query += " AND LastName LIKE @lastName";
            if (!string.IsNullOrEmpty(rank))
                query += " AND Rank = @rank";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (!string.IsNullOrEmpty(lastName))
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                if (!string.IsNullOrEmpty(rank))
                    cmd.Parameters.AddWithValue("@rank", rank);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    var policemen = new DataTable(); // Создаем временную таблицу для данных
                    policemen.Load(reader); // Загружаем данные из запроса в DataTable

                    if (policemen.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет таких сотрудников!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Оставьте DataGridView без изменений
                    }
                    else
                    {
                        PolicemanDataGridView.DataSource = policemen; // Заполняем DataGridView новыми данными
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//посмотреть
        {
            string licensePlate = PlatetextBox.Text.Trim();
            string certificateOfRegistration = STStextBox.Text.Trim();

            string searchQuery = "SELECT a.CertificateOfRegistration, a.Make, a.Model, a.LicensePlate, a.Year, d.FullName AS OwnerName " +
                                 "FROM Auto a JOIN Drivers d ON a.OwnerName = d.FullName " +
                                 "WHERE 1=1"; // Начинаем с условия "1=1"

            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND a.LicensePlate LIKE '%' || @LicensePlate || '%'";
            }
            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND a.CertificateOfRegistration LIKE '%' || @CertificateOfRegistration || '%'";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@LicensePlate", licensePlate);
                }
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                }

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    AutoDataGridView.DataSource = table; // Обновляем DataGridView
                }
            }
        }
        private void Adddriver_Click(object sender, EventArgs e)
        {
            string lastName = SurnameTextBox.Text.Trim();
            string firstName = firstnametextbox.Text.Trim();
            string middleName = middlenametextbox.Text.Trim();
            string passportNumber = passportnumbertextbox.Text.Trim();
            string phone = phonetextbox.Text.Trim();
            string address = addresstextbox.Text.Trim();
            string certificateOfRegistration = certificateofregistrationtextbox.Text.Trim();
            string driverLicense = driverLicenseTextBox.Text.Trim();
            string dateOfBirth = driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd");

            // Объединение имени в полное имя
            string fullName = string.IsNullOrEmpty(middleName) ?
                $"{lastName} {firstName}" :
                $"{lastName} {firstName.Substring(0, 1)}. {middleName.Substring(0, 1)}.";

            // Проверяем на уникальность
            if (IsDriverExists(lastName, firstName, middleName, passportNumber))
            {
                MessageBox.Show("Такой водитель уже существует.");
                return;
            }

            // SQL для вставки данных
            string insertDriver = "INSERT INTO Drivers (FullName, LastName, FirstName, MiddleName, PassportNumber, Phone, Address, CertificateOfRegistration, DriverLicense, DateOfBirth) " +
                                  "VALUES (@FullName, @LastName, @FirstName, @MiddleName, @PassportNumber, @Phone, @Address, @CertificateOfRegistration, @DriverLicense, @DateOfBirth)";

            try
            {
                using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                    cmd.Parameters.AddWithValue("@DriverLicense", driverLicense);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении водителя: {ex.Message}");
            }

            LoadDrivers(); // Перезагрузить данные
        }

        private void Editdriver_Click(object sender, EventArgs e)
        {
            var selectedRows = driversDataGridView.SelectedRows; // Здесь предполагаем, что это ваш DataGridView для водителей
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int driverId = Convert.ToInt32(row.Cells["Id"].Value); // Получаем Id водителя

                string updateDriver = "UPDATE Drivers SET " +
                                      "LastName = COALESCE(NULLIF(@LastName, ''), LastName), " +
                                      "FirstName = COALESCE(NULLIF(@FirstName, ''), FirstName), " +
                                      "MiddleName = COALESCE(NULLIF(@MiddleName, ''), MiddleName), " +
                                      "PassportNumber = COALESCE(NULLIF(@PassportNumber, ''), PassportNumber), " +
                                      "Phone = COALESCE(NULLIF(@Phone, ''), Phone), " +
                                      "Address = COALESCE(NULLIF(@Address, ''), Address), " +
                                      "CertificateOfRegistration = COALESCE(NULLIF(@CertificateOfRegistration, ''), CertificateOfRegistration), " +
                                      "DriverLicense = COALESCE(NULLIF(@DriverLicense, ''), DriverLicense), " + // Измените на DriverLicense
                                      "DateOfBirth = COALESCE(NULLIF(@DateOfBirth, ''), DateOfBirth) " +
                                      "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", driverId);
                    cmd.Parameters.AddWithValue("@LastName", SurnameTextBox.Text); // Измените на LastName
                    cmd.Parameters.AddWithValue("@FirstName", firstnametextbox.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", middlenametextbox.Text);
                    cmd.Parameters.AddWithValue("@PassportNumber", passportnumbertextbox.Text);
                    cmd.Parameters.AddWithValue("@Phone", phonetextbox.Text);
                    cmd.Parameters.AddWithValue("@Address", addresstextbox.Text);
                    cmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateofregistrationtextbox.Text);
                    cmd.Parameters.AddWithValue("@DriverLicense", driverLicenseTextBox.Text); // Измените на DriverLicense
                    cmd.Parameters.AddWithValue("@DateOfBirth", driverDateOfBirthPicker.Value);

                    cmd.ExecuteNonQuery(); // Выполняем обновление
                }
            }

            LoadData(); // Перезагрузить данные
        }
        private void Deletedriver_Click(object sender, EventArgs e)
        {
            var selectedRows = driversDataGridView.SelectedRows; // Предположим, что это ваш DataGridView для водителей
            if (selectedRows.Count == 0) return;

            var idsToDelete = new List<int>();

            foreach (DataGridViewRow row in selectedRows)
            {
                idsToDelete.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные записи?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteDrivers = $"DELETE FROM Drivers WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteDrivers, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadData(); // Перезагрузить данные
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
                // Получаем FullName на основе CertificateOfRegistration водителя
                string getOwnerNameQuery = "SELECT FullName FROM Drivers WHERE CertificateOfRegistration = @CertificateOfRegistration";
                string ownerName = string.Empty;

                using (var getOwnerNameCmd = new SQLiteCommand(getOwnerNameQuery, sqliteConn))
                {
                    getOwnerNameCmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                    object result = getOwnerNameCmd.ExecuteScalar();

                    if (result != null)
                    {
                        ownerName = result.ToString(); // Присваиваем найденный FullName
                    }
                }

                // Проверка, существует ли водитель с указанным свидетельством о регистрации
                if (!string.IsNullOrEmpty(ownerName))
                {
                    // SQL для вставки данных об автомобиле
                    string insertCarQuery = "INSERT INTO Auto (CertificateOfRegistration, Make, Model, LicensePlate, Year, OwnerName) " +
                                             "VALUES (@CertificateOfRegistration, @Make, @Model, @LicensePlate, @Year, @OwnerName)";

                    using (var insertCmd = new SQLiteCommand(insertCarQuery, sqliteConn))
                    {
                        insertCmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                        insertCmd.Parameters.AddWithValue("@Make", make);
                        insertCmd.Parameters.AddWithValue("@Model", model);
                        insertCmd.Parameters.AddWithValue("@LicensePlate", licensePlate);
                        insertCmd.Parameters.AddWithValue("@Year", year);
                        insertCmd.Parameters.AddWithValue("@OwnerName", ownerName); // Используем найденный FullName водителя

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
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                string ownerName = row.Cells["OwnerName"].Value.ToString();
                string updatedCertificateOfRegistration = STStextBox.Text;
                string updatedMake = MakeTextBox.Text;
                string updatedModel = ModeltextBox.Text;
                string updatedLicensePlate = PlatetextBox.Text;
                int updatedYear;

                // Проверяем, что год можно преобразовать в int
                if (!int.TryParse(yeartextBox.Text, out updatedYear))
                {
                    MessageBox.Show("Пожалуйста, введите корректный год.");
                    return;
                }

                string updateCarQuery = "UPDATE Auto SET " +
                                         "CertificateOfRegistration = COALESCE(NULLIF(@CertificateOfRegistration, ''), CertificateOfRegistration), " +
                                         "Make = COALESCE(NULLIF(@Make, ''), Make), " +
                                         "Model = COALESCE(NULLIF(@Model, ''), Model), " +
                                         "LicensePlate = COALESCE(NULLIF(@LicensePlate, ''), LicensePlate), " +
                                         "Year = COALESCE(NULLIF(@Year, -1), Year) " +
                                         "WHERE OwnerName = @OwnerName";

                using (var cmd = new SQLiteCommand(updateCarQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@OwnerName", ownerName);
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
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var licensePlatesToDelete = selectedRows.Cast<DataGridViewRow>().Select(row => row.Cells["LicensePlate"].Value.ToString()).ToList();

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные автомобили?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteCarQuery = $"DELETE FROM Auto WHERE LicensePlate IN ({string.Join(",", licensePlatesToDelete.Select(lp => $"'{lp}'"))})";
                using (var cmd = new SQLiteCommand(deleteCarQuery, sqliteConn))
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
                var autoDetailsForm = new AutoDetailsForm(certificateOfRegistration, make, model, licensePlate, year);
                autoDetailsForm.Show();
            }
        }

        private void Obnovedriv_Click(object sender, EventArgs e)
        {
            LoadDrivers();
        }

        private void ObnoveAuto_Click(object sender, EventArgs e)
        {
            LoadAuto();
        }

        private void Addpolice_Click(object sender, EventArgs e)
        {
            string lastName = lastNameTextBox.Text.Trim();
            string firstName = fiNameTextBox.Text.Trim();
            string middleName = miNameTextBox.Text.Trim();
            string passportNumber = passportTextBox.Text.Trim();
            string phone = protophonTextBox.Text.Trim();
            string address = addrTextBox.Text.Trim();
            string rank = rankTextBox.Text.Trim();
            string position = positionTextBox.Text.Trim();
            string dateOfBirth = DateOfBirthPicker.Value.ToString("yyyy-MM-dd");
            string issuedProtocols = issuedProtocolsTextBox.Text.Trim(); // Получаем IssuedProtocols

            // Объединение имени в полное имя
            string fullName = string.IsNullOrEmpty(middleName) ?
                $"{lastName} {firstName}" :
                $"{lastName} {firstName.Substring(0, 1)}. {middleName.Substring(0, 1)}.";

            // SQL для вставки данных
            string insertPoliceman = "INSERT INTO Policeman (FullName, LastName, FirstName, MiddleName, " +
                                     "PassportNumber, Phone, Address, DateOfBirth, Rank, Position, IssuedProtocols) " + // Добавлено IssuedProtocols
                                     "VALUES (@FullName, @LastName, @FirstName, @MiddleName, " +
                                     "@PassportNumber, @Phone, @Address, @DateOfBirth, @Rank, @Position, @IssuedProtocols)";

            try
            {
                using (var cmd = new SQLiteCommand(insertPoliceman, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@Rank", rank);
                    cmd.Parameters.AddWithValue("@Position", position);
                    cmd.Parameters.AddWithValue("@IssuedProtocols", issuedProtocols); // Добавлено IssuedProtocols

                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}");
            }

            LoadPoliceman(); // Перезагрузить данные
        }

        private void EditPolice_Click(object sender, EventArgs e)
        {
            var selectedRows = PolicemanDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int policemanId = Convert.ToInt32(row.Cells["Id"].Value);

                string updatePoliceman = "UPDATE Policeman SET " +
                                          "LastName = COALESCE(NULLIF(@LastName, ''), LastName), " +
                                          "FirstName = COALESCE(NULLIF(@FirstName, ''), FirstName), " +
                                          "MiddleName = COALESCE(NULLIF(@MiddleName, ''), MiddleName), " +
                                          "PassportNumber = COALESCE(NULLIF(@PassportNumber, ''), PassportNumber), " +
                                          "Phone = COALESCE(NULLIF(@Phone, ''), Phone), " +
                                          "Address = COALESCE(NULLIF(@Address, ''), Address), " +
                                          "DateOfBirth = COALESCE(NULLIF(@DateOfBirth, ''), DateOfBirth), " +
                                          "Rank = COALESCE(NULLIF(@Rank, ''), Rank), " +
                                          "Position = COALESCE(NULLIF(@Position, ''), Position), " +
                                          "IssuedProtocols = COALESCE(NULLIF(@IssuedProtocols, ''), IssuedProtocols) " + // Добавлено IssuedProtocols
                                          "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updatePoliceman, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", policemanId);
                    cmd.Parameters.AddWithValue("@LastName", lastNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@FirstName", fiNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", miNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@PassportNumber", passportTextBox.Text);
                    cmd.Parameters.AddWithValue("@Phone", protophonTextBox.Text);
                    cmd.Parameters.AddWithValue("@Address", addrTextBox.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirthPicker.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Rank", rankTextBox.Text);
                    cmd.Parameters.AddWithValue("@Position", positionTextBox.Text);
                    cmd.Parameters.AddWithValue("@IssuedProtocols", issuedProtocolsTextBox.Text); // Добавлено IssuedProtocols

                    cmd.ExecuteNonQuery();
                }
            }

            LoadPoliceman(); // Перезагрузить данные
        }

        private void DeletePolice_Click(object sender, EventArgs e)
        {
            var selectedRows = PolicemanDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var idsToDelete = new List<int>();

            foreach (DataGridViewRow row in selectedRows)
            {
                idsToDelete.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные записи?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deletePoliceman = $"DELETE FROM Policeman WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deletePoliceman, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadPoliceman(); // Перезагрузить данные
            }
        }

        private void ObnovePolice_Click(object sender, EventArgs e)
        {
            LoadPoliceman();
        }

        private void PolicemanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Отключаем обработку заголовков

            // Получаем выбранную строку
            DataGridViewRow selectedRow = PolicemanDataGridView.Rows[e.RowIndex];

            // Извлекаем данные из ячеек
            string lastName = selectedRow.Cells["LastName"].Value.ToString();
            string firstName = selectedRow.Cells["FirstName"].Value.ToString();
            string middleName = selectedRow.Cells["MiddleName"].Value.ToString();
            string passportNumber = selectedRow.Cells["PassportNumber"].Value.ToString();
            string phone = selectedRow.Cells["Phone"].Value.ToString();
            string address = selectedRow.Cells["Address"].Value.ToString();
            DateTime dateOfBirth = Convert.ToDateTime(selectedRow.Cells["DateOfBirth"].Value);
            string rank = selectedRow.Cells["Rank"].Value.ToString();
            string position = selectedRow.Cells["Position"].Value.ToString();
            string issuedProtocols = selectedRow.Cells["IssuedProtocols"].Value.ToString(); // Получаем IssuedProtocols

            // Создаем экземпляр PolicemanForm и передаем данные
            PolicemanForm policemanForm = new PolicemanForm(lastName, firstName, middleName, passportNumber, phone, address, dateOfBirth, rank, position, issuedProtocols);

            // Открываем форму как модальную
            policemanForm.ShowDialog();
        }

        private void SearchViol_Click(object sender, EventArgs e)
        {
            string licensePlate = Licenseplate.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value.Date; // Используем значение из DateTimePicker

            string query = "SELECT * FROM Violations WHERE 1=1"; // Начало запроса

            if (!string.IsNullOrEmpty(licensePlate))
                query += " AND LicensePlate LIKE @licensePlate";
            if (violationDate != DateTime.MinValue) // Проверка на правильность даты
                query += " AND ViolationDate = @violationDate";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (!string.IsNullOrEmpty(licensePlate))
                    cmd.Parameters.AddWithValue("@licensePlate", licensePlate);
                if (violationDate != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@violationDate", violationDate.ToString("yyyy-MM-dd"));

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    var violations = new DataTable(); // Создаем временную таблицу для данных
                    violations.Load(reader); // Загружаем данные из запроса в DataTable

                    if (violations.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет таких нарушений!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Оставьте DataGridView без изменений
                    }
                    else
                    {
                        violationsDataGridView.DataSource = violations; // Заполняем DataGridView новыми данными
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string licensePlate = Licenseplate.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value;
            string description = Description.Text.Trim();
            decimal fine = Convert.ToDecimal(Fine.Text.Trim());
            string referenceInfo = Info.Text.Trim();

            // SQL для вставки данных
            string insertViolation = "INSERT INTO Violations (ProtocolNumber, ViolationDate, Description, Fine, ReferenceInfo, LicensePlate, DriverName) " +
                                     "VALUES (@ProtocolNumber, @ViolationDate, @Description, @Fine, @ReferenceInfo, @LicensePlate, " +
                                     "(SELECT OwnerName FROM Auto WHERE LicensePlate = @LicensePlate))"; // Получаем OwnerName из таблицы Auto

            try
            {
                using (var cmd = new SQLiteCommand(insertViolation, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@ProtocolNumber", ProtocolNumber.Text.Trim()); // Если у вас есть текстовое поле для ввода номера протокола
                    cmd.Parameters.AddWithValue("@ViolationDate", violationDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Fine", fine);
                    cmd.Parameters.AddWithValue("@ReferenceInfo", referenceInfo);
                    cmd.Parameters.AddWithValue("@LicensePlate", licensePlate);

                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении нарушения: {ex.Message}");
            }

            LoadViolations(); // Перезагрузить данные (вы должны реализовать этот метод)
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedRows = violationsDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int violationId = Convert.ToInt32(row.Cells["Id"].Value); // Получаем Id нарушения

                string updateViolation = "UPDATE Violations SET " +
                                         "ViolationDate = COALESCE(NULLIF(@ViolationDate, ''), ViolationDate), " +
                                         "Description = COALESCE(NULLIF(@Description, ''), Description), " +
                                         "Fine = COALESCE(NULLIF(@Fine, ''), Fine), " +
                                         "ReferenceInfo = COALESCE(NULLIF(@ReferenceInfo, ''), ReferenceInfo), " +
                                         "LicensePlate = COALESCE(NULLIF(@LicensePlate, ''), LicensePlate) " +
                                         "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateViolation, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", violationId);
                    cmd.Parameters.AddWithValue("@ViolationDate", VioldateTimePicker.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Description", Description.Text);
                    cmd.Parameters.AddWithValue("@Fine", Convert.ToDecimal(Fine.Text));
                    cmd.Parameters.AddWithValue("@ReferenceInfo", Info.Text);
                    cmd.Parameters.AddWithValue("@LicensePlate", Licenseplate.Text);

                    cmd.ExecuteNonQuery(); // Выполняем обновление
                }
            }

            LoadViolations(); // Перезагрузить данные
        }

        private void DelViol_Click(object sender, EventArgs e)
        {
            var selectedRows = violationsDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var idsToDelete = new List<int>();

            foreach (DataGridViewRow row in selectedRows)
            {
                idsToDelete.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные записи?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteViolations = $"DELETE FROM Violations WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteViolations, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadViolations(); // Перезагрузить данные
            }
        }

        private void ObnoveViol_Click(object sender, EventArgs e)
        {
            LoadViolations();
        }

        private void violationsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Отключаем обработку заголовков

            // Получаем выбранную строку
            DataGridViewRow selectedRow = violationsDataGridView.Rows[e.RowIndex];

            // Извлекаем данные из ячеек
            string protocolNumber = selectedRow.Cells["ProtocolNumber"].Value.ToString();
            string description = selectedRow.Cells["Description"].Value.ToString();
            string Info = selectedRow.Cells["ReferenceInfo"].Value.ToString();
            string licensePlate = selectedRow.Cells["LicensePlate"].Value.ToString();
            decimal fine = Convert.ToDecimal(selectedRow.Cells["Fine"].Value);
            DateTime violateDate = Convert.ToDateTime(selectedRow.Cells["ViolationDate"].Value); // Убедитесь в правильном имени столбца
            string driverName = selectedRow.Cells["DriverName"].Value.ToString(); // Имя водителя

            // Создаем экземпляр ViolationForm и передаем данные
            ViolationsForm violationForm = new ViolationsForm(protocolNumber, description, licensePlate, Info, fine, violateDate, driverName);

            // Открываем форму как модальную
            violationForm.ShowDialog();
        }
    }
}
