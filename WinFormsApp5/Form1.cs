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
            LoadRegistr();
            LoadProtocol();
        }
        private void LoadDrivers()
        {
            string selectDrivers = "SELECT * FROM Водители"; // SQL запрос для выборки данных
            using (var cmd = new SQLiteCommand(selectDrivers, sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    DataTable driversTable = new DataTable();
                    driversTable.Load(reader); // Загружаем данные из выборки в DataTable
                    driversDataGridView.DataSource = driversTable; // Устанавливаем источник данных
                }
                if (driversDataGridView.Columns.Contains("Id"))
                {
                    driversDataGridView.Columns["Id"].Visible = false;
                }
            }

        }
        private void LoadAuto()
        {
            var AutoAdapter = new SQLiteDataAdapter("SELECT * FROM Авто", sqliteConn);
            var AutoTable = new DataTable();
            AutoAdapter.Fill(AutoTable);
            AutoDataGridView.DataSource = AutoTable;
            if (AutoDataGridView.Columns.Contains("Id"))
            {
                AutoDataGridView.Columns["Id"].Visible = false;
            }
        }
        private void LoadPoliceman()
        {
            var PolicemanAdapter = new SQLiteDataAdapter("SELECT * FROM СотрудникГАИ", sqliteConn);
            var PolicemanTable = new DataTable();
            PolicemanAdapter.Fill(PolicemanTable);
            PolicemanDataGridView.DataSource = PolicemanTable;
            if (PolicemanDataGridView.Columns.Contains("Id"))
            {
                PolicemanDataGridView.Columns["Id"].Visible = false;
            }
        }
        private void LoadViolations()
        {
            var violationAdapter = new SQLiteDataAdapter("SELECT * FROM Нарушения", sqliteConn);
            var violationTable = new DataTable();
            violationAdapter.Fill(violationTable);
            violationsDataGridView.DataSource = violationTable;
            if (violationsDataGridView.Columns.Contains("Id"))
            {
                violationsDataGridView.Columns["Id"].Visible = false;
            }
        }
        private void LoadRegistr()
        {
            var registrAdapter = new SQLiteDataAdapter("SELECT * FROM Регистрация", sqliteConn);
            var registrTable = new DataTable();
            registrAdapter.Fill(registrTable);
            RegistrdataGridView.DataSource = registrTable;
            if (RegistrdataGridView.Columns.Contains("Id"))
            {
                RegistrdataGridView.Columns["Id"].Visible = false;
            }
        }
        private void LoadProtocol()
        {
            var protAdapter = new SQLiteDataAdapter("SELECT * FROM СотрудникПротоколы", sqliteConn);
            var protTable = new DataTable();
            protAdapter.Fill(protTable);
            protocolsDataGridView.DataSource = protTable;
        }
        private bool IsDriverExists(string lastName, string firstName, string middleName, string passportNumber)
        {
            string selectQuery = "SELECT COUNT(*) FROM Водители WHERE Фамилия = @Фамилия AND Имя = @Имя AND Отчество = @Отчество AND НомерПаспорта = @НомерПаспорта";
            using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@Фамилия", lastName);
                cmd.Parameters.AddWithValue("@Имя", firstName);
                cmd.Parameters.AddWithValue("@Отчество", middleName);
                cmd.Parameters.AddWithValue("@НомерПаспорта", passportNumber);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
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

        private void searchdriver_Click_1(object sender, EventArgs e)
        {
            string lastName = SurnameTextBox.Text.Trim();
            string firstName = firstnametextbox.Text.Trim();
            string middleName = middlenametextbox.Text.Trim();
            DateTime dateOfBirth = driverDateOfBirthPicker.Value; // Используем значение из DateTimePicker
            string certificateOfRegistration = certificateofregistrationtextbox.Text.Trim();

            string query = "SELECT * FROM Водители WHERE 1=1"; // Начало запроса

            if (!string.IsNullOrEmpty(lastName))
                query += " AND Фамилия LIKE @lastName";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND Имя LIKE @firstName";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND Отчество LIKE @middleName";
            if (dateOfBirth != DateTime.MinValue) // Проверка на правильность даты
                query += " AND ДатаРождения = @dateOfBirth";
            if (!string.IsNullOrEmpty(certificateOfRegistration))
                query += " AND СвидетельствоОРегистрации LIKE @certificateOfRegistration";

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
        private void Adddriver_Click_1(object sender, EventArgs e)
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
            string insertDriver = "INSERT INTO Водители (ПолноеИмя, Фамилия, Имя, Отчество, НомерПаспорта, Телефон, Адрес, СвидетельствоОРегистрации, ВодительскоеУдостоверение, ДатаРождения) " +
                                  "VALUES (@ПолноеИмя, @Фамилия, @Имя, @Отчество, @НомерПаспорта, @Телефон, @Адрес, @СвидетельствоОРегистрации, @ВодительскоеУдостоверение, @ДатаРождения)";

            try
            {
                using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@ПолноеИмя", fullName);
                    cmd.Parameters.AddWithValue("@Фамилия", lastName);
                    cmd.Parameters.AddWithValue("@Имя", firstName);
                    cmd.Parameters.AddWithValue("@Отчество", middleName);
                    cmd.Parameters.AddWithValue("@НомерПаспорта", passportNumber);
                    cmd.Parameters.AddWithValue("@Телефон", phone);
                    cmd.Parameters.AddWithValue("@Адрес", address);
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                    cmd.Parameters.AddWithValue("@ВодительскоеУдостоверение", driverLicense);
                    cmd.Parameters.AddWithValue("@ДатаРождения", dateOfBirth);

                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении водителя: {ex.Message}");
            }

            LoadDrivers(); // Перезагрузить данные
        }

        private void Editdriver_Click_1(object sender, EventArgs e)
        {
            var selectedRows = driversDataGridView.SelectedRows; // Здесь предполагаем, что это ваш DataGridView для водителей
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int driverId = Convert.ToInt32(row.Cells["Идентификатор"].Value); // Получаем Идентификатор водителя

                string updateDriver = "UPDATE Водители SET " +
                                      "Фамилия = COALESCE(NULLIF(@Фамилия, ''), Фамилия), " +
                                      "Имя = COALESCE(NULLIF(@Имя, ''), Имя), " +
                                      "Отчество = COALESCE(NULLIF(@Отчество, ''), Отчество), " +
                                      "НомерПаспорта = COALESCE(NULLIF(@НомерПаспорта, ''), НомерПаспорта), " +
                                      "Телефон = COALESCE(NULLIF(@Телефон, ''), Телефон), " +
                                      "Адрес = COALESCE(NULLIF(@Адрес, ''), Адрес), " +
                                      "СвидетельствоОРегистрации = COALESCE(NULLIF(@СвидетельствоОРегистрации, ''), СвидетельствоОРегистрации), " +
                                      "ВодительскоеУдостоверение = COALESCE(NULLIF(@ВодительскоеУдостоверение, ''), ВодительскоеУдостоверение), " +
                                      "ДатаРождения = COALESCE(NULLIF(@ДатаРождения, ''), ДатаРождения) " +
                                      "WHERE Идентификатор = @Идентификатор";

                using (var cmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Идентификатор", driverId);
                    cmd.Parameters.AddWithValue("@Фамилия", SurnameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Имя", firstnametextbox.Text);
                    cmd.Parameters.AddWithValue("@Отчество", middlenametextbox.Text);
                    cmd.Parameters.AddWithValue("@НомерПаспорта", passportnumbertextbox.Text);
                    cmd.Parameters.AddWithValue("@Телефон", phonetextbox.Text);
                    cmd.Parameters.AddWithValue("@Адрес", addresstextbox.Text);
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateofregistrationtextbox.Text);
                    cmd.Parameters.AddWithValue("@ВодительскоеУдостоверение", driverLicenseTextBox.Text);
                    cmd.Parameters.AddWithValue("@ДатаРождения", driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery(); // Выполняем обновление
                }
            }

            LoadDrivers(); // Перезагрузить данные
        }

        private void Deletedriver_Click_1(object sender, EventArgs e)
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
                string deleteDrivers = $"DELETE FROM Водители WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteDrivers, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadData(); // Перезагрузить данные
            }
        }

        private void driversDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что вы кликнули по строке
            {
                DataGridViewRow row = this.driversDataGridView.Rows[e.RowIndex];

                // Здесь можете создать и показать форму с полными данными
                var driverDetailsForm = new DriverDetailsForm(
                    row.Cells["Фамилия"].Value.ToString(),
                    row.Cells["Имя"].Value.ToString(),
                    row.Cells["Отчество"].Value.ToString(),
                    row.Cells["НомерПаспорта"].Value.ToString(),
                    row.Cells["Телефон"].Value.ToString(),
                    row.Cells["Адрес"].Value.ToString(),
                    row.Cells["СвидетельствоОРегистрации"].Value.ToString(),
                    row.Cells["ВодительскоеУдостоверение"].Value.ToString(),
                    Convert.ToDateTime(row.Cells["ДатаРождения"].Value)
                );

                driverDetailsForm.Show();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string licensePlate = PlatetextBox.Text.Trim();
            string certificateOfRegistration = STStextBox.Text.Trim();

            string searchQuery = "SELECT a.СвидетельствоОРегистрации, a.Марка, a.Модель, a.НомернойЗнак, a.Год, a.Владелец " +
                                 "FROM Авто a WHERE 1=1"; // Начинаем с условия "1=1"

            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND a.НомернойЗнак LIKE '%' || @НомернойЗнак || '%'";
            }
            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND a.СвидетельствоОРегистрации LIKE '%' || @СвидетельствоОРегистрации || '%'";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                }
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                }

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    AutoDataGridView.DataSource = table; // Обновляем DataGridView
                }
            }
        }

        private void AddCar_Click_1(object sender, EventArgs e)
        {
            // Получаем данные с форм
            string certificateOfRegistration = STStextBox.Text.Trim();
            string make = MakeTextBox.Text.Trim();
            string model = ModeltextBox.Text.Trim();
            string licensePlate = PlatetextBox.Text.Trim();
            int year;

            // Проверка, что год введен корректно
            if (!int.TryParse(yeartextBox.Text, out year))
            {
                MessageBox.Show("Пожалуйста, введите корректный год.");
                return;
            }

            string insurance = StrahovkaTextBox.Text.Trim();

            try
            {
                // Получаем полное имя владельца по свидетельству о регистрации
                string ownerQuery = "SELECT ПолноеИмя FROM Водители WHERE СвидетельствоОРегистрации = @СвидетельствоОРегистрации";
                string fullName = string.Empty; // Переменная для хранения полного имени владельца

                using (var ownerCmd = new SQLiteCommand(ownerQuery, sqliteConn))
                {
                    ownerCmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                    object result = ownerCmd.ExecuteScalar();

                    if (result != null)
                    {
                        fullName = result.ToString(); // Получаем полное имя владельца
                    }
                }

                // Проверяем, что владелец найден
                if (!string.IsNullOrEmpty(fullName))
                {
                    // SQL для вставки данных об автомобиле
                    string insertCarQuery = "INSERT INTO Авто (СвидетельствоОРегистрации, Марка, Модель, НомернойЗнак, Год, Владелец, Страхование) " +
                                             "VALUES (@СвидетельствоОРегистрации, @Марка, @Модель, @НомернойЗнак, @Год, @Владелец, @Страхование)";

                    using (var insertCmd = new SQLiteCommand(insertCarQuery, sqliteConn))
                    {
                        insertCmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                        insertCmd.Parameters.AddWithValue("@Марка", make);
                        insertCmd.Parameters.AddWithValue("@Модель", model);
                        insertCmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                        insertCmd.Parameters.AddWithValue("@Год", year);
                        insertCmd.Parameters.AddWithValue("@Владелец", fullName); // Используем найденное полное имя владельца
                        insertCmd.Parameters.AddWithValue("@Страхование", insurance);

                        insertCmd.ExecuteNonQuery(); // Выполняем запрос
                    }

                    MessageBox.Show("Автомобиль успешно добавлен!");
                }
                else
                {
                    MessageBox.Show("Владелец с указанным свидетельством о регистрации не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автомобиля: {ex.Message}");
            }
        }


        private void EditCar_Click_1(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                string updatedCertificateOfRegistration = STStextBox.Text;
                string updatedMake = MakeTextBox.Text;
                string updatedModel = ModeltextBox.Text;
                string updatedLicensePlate = PlatetextBox.Text;
                string updatedInsurance = StrahovkaTextBox.Text;
                int updatedYear;

                // Проверяем, что год можно преобразовать в int
                if (!int.TryParse(yeartextBox.Text, out updatedYear))
                {
                    MessageBox.Show("Пожалуйста, введите корректный год.");
                    return;
                }

                int carId = Convert.ToInt32(row.Cells["Id"].Value); // Получаем идентификатор автомобиля

                string updateCarQuery = "UPDATE Авто SET " +
                                         "СвидетельствоОРегистрации = COALESCE(NULLIF(@СвидетельствоОРегистрации, ''), СвидетельствоОРегистрации), " +
                                         "Марка = COALESCE(NULLIF(@Марка, ''), Марка), " +
                                         "Модель = COALESCE(NULLIF(@Модель, ''), Модель), " +
                                         "НомернойЗнак = COALESCE(NULLIF(@НомернойЗнак, ''), НомернойЗнак), " +
                                         "Год = COALESCE(NULLIF(@Год, -1), Год), " +
                                         "Страхование = COALESCE(NULLIF(@Страхование, ''), Страхование) " +
                                         "WHERE Id = @Id"; // изменено на использование Id

                using (var cmd = new SQLiteCommand(updateCarQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", carId);
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@Марка", updatedMake);
                    cmd.Parameters.AddWithValue("@Модель", updatedModel);
                    cmd.Parameters.AddWithValue("@НомернойЗнак", updatedLicensePlate);
                    cmd.Parameters.AddWithValue("@Год", updatedYear);
                    cmd.Parameters.AddWithValue("@Страхование", updatedInsurance);

                    cmd.ExecuteNonQuery(); // Выполняем обновление
                }
            }

            LoadAuto(); // Перезагрузить данные
        }

        private void DeleteCar_Click_1(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var licensePlatesToDelete = selectedRows.Cast<DataGridViewRow>().Select(row => row.Cells["НомернойЗнак"].Value.ToString()).ToList();

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные автомобили?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteCarQuery = $"DELETE FROM Авто WHERE НомернойЗнак IN ({string.Join(",", licensePlatesToDelete.Select(lp => $"'{lp}'"))})";
                using (var cmd = new SQLiteCommand(deleteCarQuery, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadAuto(); // Перезагрузить данные
            }
        }

        private void ObnoveAuto_Click_1(object sender, EventArgs e)
        {
            LoadAuto();
        }

        private void Obnovedriv_Click_1(object sender, EventArgs e)
        {
            LoadDrivers();
        }

        private void AutoDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что вы кликнули по строке
            {
                DataGridViewRow row = this.AutoDataGridView.Rows[e.RowIndex];

                // Получаем данные для создания формы деталей автомобиля
                string certificateOfRegistration = row.Cells["СвидетельствоОРегистрации"].Value.ToString();
                string make = row.Cells["Марка"].Value.ToString();
                string model = row.Cells["Модель"].Value.ToString();
                string licensePlate = row.Cells["НомернойЗнак"].Value.ToString();
                int year = Convert.ToInt32(row.Cells["Год"].Value);
                string ownerFullName = row.Cells["Владелец"].Value.ToString(); // Обратите внимание на Владелец

                // Создайте и покажите форму с полными данными
                var autoDetailsForm = new AutoDetailsForm(certificateOfRegistration, make, model, licensePlate, year, ownerFullName);
                autoDetailsForm.Show();
            }
        }

        private void SearchPolice_Click(object sender, EventArgs e)
        {
            string lastName = lastNameTextBox.Text.Trim();
            string rank = rankTextBox.Text.Trim();

            string query = "SELECT * FROM СотрудникГАИ WHERE 1=1"; // Начало запроса

            if (!string.IsNullOrEmpty(lastName))
                query += " AND Фамилия LIKE @lastName";
            if (!string.IsNullOrEmpty(rank))
                query += " AND Звание = @rank";

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

        private void Addpolice_Click_1(object sender, EventArgs e)
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
            string insertPolice = "INSERT INTO СотрудникГАИ (ПолноеИмя, Фамилия, Имя, Отчество, " +
                                  "НомерПаспорта, Телефон, Адрес, ДатаРождения, Звание, Должность) " +
                                  "VALUES (@fullName, @lastName, @firstName, @middleName, " +
                                  "@passportNumber, @phone, @address, @dateOfBirth, @rank, @position)";

            try
            {
                using (var cmd = new SQLiteCommand(insertPolice, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                    cmd.Parameters.AddWithValue("@passportNumber", passportNumber);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@rank", rank);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}");
            }

            LoadPoliceman(); // Перезагрузить данные
        }

        private void EditPolice_Click_1(object sender, EventArgs e)
        {
            var selectedRows = PolicemanDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int policemanId = Convert.ToInt32(row.Cells["Id"].Value);

                string updatePolice = "UPDATE СотрудникГАИ SET " +
                                      "Фамилия = COALESCE(NULLIF(@lastName, ''), Фамилия), " +
                                      "Имя = COALESCE(NULLIF(@firstName, ''), Имя), " +
                                      "Отчество = COALESCE(NULLIF(@middleName, ''), Отчество), " +
                                      "НомерПаспорта = COALESCE(NULLIF(@passportNumber, ''), НомерПаспорта), " +
                                      "Телефон = COALESCE(NULLIF(@phone, ''), Телефон), " +
                                      "Адрес = COALESCE(NULLIF(@address, ''), Адрес), " +
                                      "ДатаРождения = COALESCE(NULLIF(@dateOfBirth, ''), ДатаРождения), " +
                                      "Звание = COALESCE(NULLIF(@rank, ''), Звание), " +
                                      "Должность = COALESCE(NULLIF(@position, ''), Должность) " +
                                      "WHERE Id = @id";

                using (var cmd = new SQLiteCommand(updatePolice, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@id", policemanId);
                    cmd.Parameters.AddWithValue("@lastName", lastNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@firstName", fiNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@middleName", miNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@passportNumber", passportTextBox.Text);
                    cmd.Parameters.AddWithValue("@phone", protophonTextBox.Text);
                    cmd.Parameters.AddWithValue("@address", addrTextBox.Text);
                    cmd.Parameters.AddWithValue("@dateOfBirth", DateOfBirthPicker.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@rank", rankTextBox.Text);
                    cmd.Parameters.AddWithValue("@position", positionTextBox.Text);
                    //System.Data.SQLite.SQLiteException: "SQL logic error near "WHERE": syntax error"
                    cmd.ExecuteNonQuery();
                }
            }

            LoadPoliceman(); // Перезагрузить данные
        }

        private void DeletePolice_Click_1(object sender, EventArgs e)
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
                string deletePolice = $"DELETE FROM СотрудникГАИ WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deletePolice, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadPoliceman(); // Перезагрузить данные
            }
        }

        private void ObnovePolice_Click_1(object sender, EventArgs e)
        {
            LoadPoliceman();
        }

        private void PolicemanDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Отключаем обработку заголовков

            // Получаем выбранную строку
            DataGridViewRow selectedRow = PolicemanDataGridView.Rows[e.RowIndex];

            // Извлекаем данные из ячеек
            string lastName = selectedRow.Cells["Фамилия"].Value.ToString();
            string firstName = selectedRow.Cells["Имя"].Value.ToString();
            string middleName = selectedRow.Cells["Отчество"].Value.ToString();
            string passportNumber = selectedRow.Cells["НомерПаспорта"].Value.ToString();
            string phone = selectedRow.Cells["Телефон"].Value.ToString();
            string address = selectedRow.Cells["Адрес"].Value.ToString();
            DateTime dateOfBirth = Convert.ToDateTime(selectedRow.Cells["ДатаРождения"].Value);
            string rank = selectedRow.Cells["Звание"].Value.ToString();
            string position = selectedRow.Cells["Должность"].Value.ToString();

            // Создаем экземпляр PolicemanForm и передаем данные
            PolicemanForm policemanForm = new PolicemanForm(lastName, firstName, middleName, passportNumber, phone, address, dateOfBirth, rank, position);

            // Открываем форму как модальную
            policemanForm.ShowDialog();
        }

        private void SearchViol_Click_1(object sender, EventArgs e)
        {
            string licensePlate = Licenseplate.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value; // Используем значение из DateTimePicker

            string query = "SELECT * FROM Нарушения WHERE 1=1"; // Начало запроса

            if (!string.IsNullOrEmpty(licensePlate))
                query += " AND НомернойЗнак LIKE @licensePlate";
            if (violationDate != DateTime.MinValue) // Проверка на правильность даты
                query += " AND ДатаНарушения = @violationDate";

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
                    }
                    else
                    {
                        violationsDataGridView.DataSource = violations; // Заполняем DataGridView новыми данными
                    }
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string licensePlate = Licenseplate.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value;
            string description = Description.Text.Trim();
            decimal fine = Convert.ToDecimal(Fine.Text.Trim());
            string referenceInfo = Info.Text.Trim();

            // SQL для вставки данных
            string insertViolation = "INSERT INTO Нарушения (НомерПротокола, ДатаНарушения, Описание, Штраф, СправочнаяИнформация, НомернойЗнак, Водитель) " +
                                     "VALUES (@ProtocolNumber, @ViolationDate, @Description, @Fine, @ReferenceInfo, @LicensePlate, " +
                                     "(SELECT ПолноеИмя FROM Водители WHERE ПолноеИмя = (SELECT Владелец FROM Авто WHERE НомернойЗнак = @LicensePlate)))";

            try
            {
                using (var cmd = new SQLiteCommand(insertViolation, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@ProtocolNumber", ProtocolNumber.Text.Trim());
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

            LoadViolations(); // Перезагрузить данные
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var selectedRows = violationsDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int violationId = Convert.ToInt32(row.Cells["Id"].Value);

                string updateViolation = "UPDATE Нарушения SET " +
                                         "ДатаНарушения = COALESCE(NULLIF(@ViolationDate, ''), ДатаНарушения), " +
                                         "Описание = COALESCE(NULLIF(@Description, ''), Описание), " +
                                         "Штраф = COALESCE(NULLIF(@Fine, ''), Штраф), " +
                                         "СправочнаяИнформация = COALESCE(NULLIF(@ReferenceInfo, ''), СправочнаяИнформация), " +
                                         "НомернойЗнак = COALESCE(NULLIF(@LicensePlate, ''), НомернойЗнак) " +
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

        private void DelViol_Click_1(object sender, EventArgs e)
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
                string deleteViolations = $"DELETE FROM Нарушения WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteViolations, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadViolations(); // Перезагрузить данные
            }
        }

        private void ObnoveViol_Click_1(object sender, EventArgs e)
        {
            LoadViolations();
        }

        private void violationsDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Отключаем обработку заголовков

            DataGridViewRow selectedRow = violationsDataGridView.Rows[e.RowIndex];

            string protocolNumber = selectedRow.Cells["НомерПротокола"].Value.ToString();
            string description = selectedRow.Cells["Описание"].Value.ToString();
            string info = selectedRow.Cells["СправочнаяИнформация"].Value.ToString();
            string licensePlate = selectedRow.Cells["НомернойЗнак"].Value.ToString();
            decimal fine = Convert.ToDecimal(selectedRow.Cells["Штраф"].Value);
            DateTime violateDate = Convert.ToDateTime(selectedRow.Cells["ДатаНарушения"].Value);
            string driverName = selectedRow.Cells["Водитель"].Value.ToString();

            ViolationsForm violationForm = new ViolationsForm(protocolNumber, description, licensePlate, info, fine, violateDate, driverName);

            violationForm.ShowDialog();
        }

        private void searchRegistr_Click(object sender, EventArgs e)
        {
            string licensePlate = NumberTextBox.Text.Trim();
            string certificateOfRegistration = STStextBox5.Text.Trim();

            // Начинаем с базового запроса
            string searchQuery = "SELECT r.Владелец, r.НомернойЗнак, r.СвидетельствоОРегистрации, r.ДатаРегистрации " +
                     "FROM Регистрация r JOIN Водители d ON r.Владелец = d.ПолноеИмя " +
                     "WHERE 1=1"; // Условие всегда истинно (для удобства добавления других условий)

            // Добавляем условия поиска
            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND r.НомернойЗнак LIKE '%' || @НомернойЗнак || '%'";
            }
            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND r.СвидетельствоОРегистрации LIKE '%' || @СвидетельствоОРегистрации || '%'";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                // Заполняем параметры, если они были введены
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                }
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                }

                // Выполняем запрос и наполняем DataGridView
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var resultTable = new DataTable();
                    adapter.Fill(resultTable);

                    // Проверяем наличия результатов
                    if (resultTable.Rows.Count > 0)
                    {
                        RegistrdataGridView.DataSource = resultTable;
                        RegistrdataGridView.Rows[0].Selected = true; // Выделяем первую строку
                    }
                    else
                    {
                        // Если нет результатов, можно визуально уведомить пользователя
                        RegistrdataGridView.DataSource = null; // Очищаем DataGridView
                        MessageBox.Show("Нет результатов для поиска.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void addRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string licensePlate = NumberTextBox.Text;
                string certificateOfRegistration = STStextBox5.Text;
                string insurance = strahTextBox.Text;
                string registrationDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                string ownerName = GetOwnerByCertificate(certificateOfRegistration); // Вводим имя владельца по СТС

                if (string.IsNullOrEmpty(ownerName))
                {
                    MessageBox.Show("Владелец с указанным номером свидетельства не найден.");
                    return;
                }

                string insertQuery = "INSERT INTO Регистрация (Владелец, НомернойЗнак, СвидетельствоОРегистрации, Страховака, ДатаРегистрации) " +
                                     "VALUES (@Владелец, @НомернойЗнак, @СвидетельствоОРегистрации, @Страховака, @ДатаРегистрации)";

                using (var cmd = new SQLiteCommand(insertQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Владелец", ownerName);
                    cmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                    cmd.Parameters.AddWithValue("@Страховака", insurance);
                    cmd.Parameters.AddWithValue("@ДатаРегистрации", registrationDate);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Регистрация успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении регистрации: {ex.Message}");
            }
            LoadRegistr();
        }

        // Метод для получения имени владельца по номеру свидетельства
        private string GetOwnerByCertificate(string certificate)
        {
            string ownerName = string.Empty;

            string query = "SELECT Владелец FROM Авто WHERE СвидетельствоОРегистрации = @Свидетельство";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@Свидетельство", certificate);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    ownerName = result.ToString();
                }
            }

            return ownerName;
        }

        private void EditRegister_Click(object sender, EventArgs e)
        {
            var selectedRows = RegistrdataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                string ownerName = row.Cells["Владелец"].Value.ToString();
                string updatedCertificateOfRegistration = STStextBox5.Text;
                string updatedLicensePlate = NumberTextBox.Text;
                DateTime updatedRegistrationDate = dateTimePicker1.Value; // Дата регистрации

                // Обратите внимание на удаление запятой перед WHERE
                string updateCarQuery = "UPDATE Регистрация SET " +
                                         "СвидетельствоОРегистрации = COALESCE(NULLIF(@СвидетельствоОРегистрации, ''), СвидетельствоОРегистрации), " +
                                         "НомернойЗнак = COALESCE(NULLIF(@НомернойЗнак, ''), НомернойЗнак), " +
                                         "ДатаРегистрации = COALESCE(NULLIF(@ДатаРегистрации, '0001-01-01'), ДатаРегистрации) " +
                                         "WHERE Владелец = @Владелец";

                using (var cmd = new SQLiteCommand(updateCarQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Владелец", ownerName);
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@НомернойЗнак", updatedLicensePlate);
                    cmd.Parameters.AddWithValue("@ДатаРегистрации", updatedRegistrationDate.ToString("yyyy-MM-dd")); // Форматирование даты

                    cmd.ExecuteNonQuery(); // Выполняем обновление
                }
            }

            LoadRegistr(); // Перезагрузить данные
        }

        private void ObnoveRegistr_Click(object sender, EventArgs e)
        {
            LoadRegistr();
        }

        private void RegistrdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что вы кликнули по строке
            {
                DataGridViewRow row = this.RegistrdataGridView.Rows[e.RowIndex];

                // Получаем данные для создания формы деталей
                string licensePlate = row.Cells["НомернойЗнак"].Value.ToString();
                string certificateOfRegistration = row.Cells["СвидетельствоОРегистрации"].Value.ToString();
                DateTime registrationDate = Convert.ToDateTime(row.Cells["ДатаРегистрации"].Value);

                // Переменные должны быть определены перед использованием
                string strahovka = row.Cells["Страховака"].Value?.ToString() ?? string.Empty; // Предполагается, что есть колонка Страховака
                string driverName = row.Cells["Владелец"].Value?.ToString() ?? string.Empty; // Предполагается, что есть колонка Владелец

                // Создайте и покажите форму с полными данными
                var Registr = new Registr(certificateOfRegistration, strahovka, licensePlate, driverName, registrationDate);
                Registr.Show();
            }
        }

        private void DeleteRegistr_Click(object sender, EventArgs e)
        {
            var selectedRows = RegistrdataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var idsToDelete = new List<int>();

            foreach (DataGridViewRow row in selectedRows)
            {
                idsToDelete.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные записи?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteViolations = $"DELETE FROM Регистрация WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteViolations, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadRegistr(); // Перезагрузить данные
            }
        }

        private void SearchProtocol_Click(object sender, EventArgs e)
        {
            int employeeGAIId;
            int protocolNumber;

            if (!int.TryParse(GAIidTextBox.Text.Trim(), out employeeGAIId))
            {
                MessageBox.Show("Введите корректный id сотрудника ГАИ.");
                return;
            }

            if (!int.TryParse(ProtocoltextBox.Text.Trim(), out protocolNumber))
            {
                MessageBox.Show("Введите корректный номер протокола.");
                return;
            }

            string searchQuery = "SELECT sp.*, (SELECT ПолноеИмя FROM СотрудникГАИ WHERE Id = sp.СотрудникГАИ_Id) AS ПолноеИмя " +
                                 "FROM СотрудникПротоколы sp " +
                                 "WHERE sp.СотрудникГАИ_Id = @СотрудникГАИ_Id AND sp.НомерПротокола = @НомерПротокола";

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@СотрудникГАИ_Id", employeeGAIId);
                cmd.Parameters.AddWithValue("@НомерПротокола", protocolNumber);

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var resultTable = new DataTable();
                    adapter.Fill(resultTable);

                    if (resultTable.Rows.Count > 0)
                    {
                        protocolsDataGridView.DataSource = resultTable;
                        protocolsDataGridView.Rows[0].Selected = true;
                    }
                    else
                    {
                        protocolsDataGridView.DataSource = null;
                        MessageBox.Show("Нет результатов для поиска.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void AddProtocol_Click(object sender, EventArgs e)
        {
            int employeeGAIId;
            int protocolNumber;

            // Проверка корректности id сотрудника ГАИ
            if (!int.TryParse(GAIidTextBox.Text, out employeeGAIId))
            {
                MessageBox.Show("Введите корректный id сотрудника ГАИ.");
                return;
            }

            // Проверка корректности номера протокола
            if (!int.TryParse(ProtocoltextBox.Text, out protocolNumber))
            {
                MessageBox.Show("Введите корректный номер протокола.");
                return;
            }

            // Проверка, существует ли протокол в таблице Нарушения
            string checkQuery = "SELECT COUNT(*) FROM Нарушения WHERE НомерПротокола = @НомерПротокола";
            using (var checkCmd = new SQLiteCommand(checkQuery, sqliteConn))
            {
                checkCmd.Parameters.AddWithValue("@НомерПротокола", protocolNumber);
                var count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Протокол с таким номером не найден в таблице Нарушения.");
                    return;
                }
            }

            // Получаем полное имя сотрудника ГАИ
            string fullNameQuery = "SELECT ПолноеИмя FROM СотрудникГАИ WHERE Id = @СотрудникГАИ_Id";
            string fullName = null; // Инициализация переменной fullName

            using (var fullNameCmd = new SQLiteCommand(fullNameQuery, sqliteConn))
            {
                fullNameCmd.Parameters.AddWithValue("@СотрудникГАИ_Id", employeeGAIId);
                object result = fullNameCmd.ExecuteScalar();

                // Проверка, найден ли сотрудник по ID
                if (result != null)
                {
                    fullName = result.ToString();
                }
                else
                {
                    MessageBox.Show("Сотрудник ГАИ с таким id не найден.");
                    return;
                }
            }

            // Запрос на добавление нового протокола
            string insertQuery = "INSERT INTO СотрудникПротоколы (СотрудникГАИ_Id, НомерПротокола, ПолноеИмя) VALUES (@СотрудникГАИ_Id, @НомерПротокола, @ПолноеИмя)";

            using (var cmd = new SQLiteCommand(insertQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@СотрудникГАИ_Id", employeeGAIId);
                cmd.Parameters.AddWithValue("@НомерПротокола", protocolNumber);
                cmd.Parameters.AddWithValue("@ПолноеИмя", fullName);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Протокол успешно добавлен!");
            LoadProtocol(); // Метод для перезагрузки данных в DataGridView
        }


        private void EditProtocol_Click(object sender, EventArgs e)
        {
            var selectedRows = protocolsDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                return;
            }

            int newEmployeeGAIId;
            if (!int.TryParse(GAIidTextBox.Text.Trim(), out newEmployeeGAIId))
            {
                MessageBox.Show("Введите корректный id сотрудника ГАИ.");
                return;
            }

            int newProtocolNumber;
            if (!int.TryParse(ProtocoltextBox.Text.Trim(), out newProtocolNumber))
            {
                MessageBox.Show("Введите корректный новый номер протокола.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int currentEmployeeGAIId = Convert.ToInt32(row.Cells["СотрудникГАИ_Id"].Value);
                int currentProtocolNumber = Convert.ToInt32(row.Cells["НомерПротокола"].Value);

                // Проверка на существование комбинации
                string checkQuery = "SELECT COUNT(*) FROM СотрудникПротоколы WHERE СотрудникГАИ_Id = @NewСотрудникГАИ_Id AND НомерПротокола = @NewНомерПротокола";
                using (var checkCmd = new SQLiteCommand(checkQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@NewСотрудникГАИ_Id", newEmployeeGAIId);
                    checkCmd.Parameters.AddWithValue("@NewНомерПротокола", newProtocolNumber);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Запись с таким id сотрудника ГАИ и номером протокола уже существует.");
                        return;
                    }
                }

                // Получаем новое полное имя
                string newFullNameQuery = "SELECT ПолноеИмя FROM СотрудникГАИ WHERE Id = @NewСотрудникГАИ_Id";
                string newFullName;
                using (var fullNameCmd = new SQLiteCommand(newFullNameQuery, sqliteConn))
                {
                    fullNameCmd.Parameters.AddWithValue("@NewСотрудникГАИ_Id", newEmployeeGAIId);
                    newFullName = (string)fullNameCmd.ExecuteScalar();
                }

                // Обновление записи
                string updateQuery = "UPDATE СотрудникПротоколы SET СотрудникГАИ_Id = @NewСотрудникГАИ_Id, НомерПротокола = @NewНомерПротокола, ПолноеИмя = @ПолноеИмя " +
                                     "WHERE СотрудникГАИ_Id = @СотрудникГАИ_Id AND НомерПротокола = @НомерПротокола";

                using (var cmd = new SQLiteCommand(updateQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@СотрудникГАИ_Id", currentEmployeeGAIId);
                    cmd.Parameters.AddWithValue("@НомерПротокола", currentProtocolNumber);
                    cmd.Parameters.AddWithValue("@NewСотрудникГАИ_Id", newEmployeeGAIId);
                    cmd.Parameters.AddWithValue("@NewНомерПротокола", newProtocolNumber);
                    cmd.Parameters.AddWithValue("@ПолноеИмя", newFullName); // Обновляем полное имя
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Протокол успешно обновлён!");
            LoadProtocol();
        }

        private void DeliteProtocol_Click(object sender, EventArgs e)
        {
            var selectedRows = protocolsDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var protocolsToDelete = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                int employeeGAIId = Convert.ToInt32(row.Cells["СотрудникГАИ_Id"].Value);
                int protocolNumber = Convert.ToInt32(row.Cells["НомерПротокола"].Value);
                protocolsToDelete.Add($"({employeeGAIId}, {protocolNumber})");
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные записи?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteQuery = $"DELETE FROM СотрудникПротоколы WHERE (СотрудникГАИ_Id, НомерПротокола) IN ({string.Join(",", protocolsToDelete)})";

                using (var cmd = new SQLiteCommand(deleteQuery, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadProtocol();
            }
        }

        private void ObnoveProt_Click(object sender, EventArgs e)
        {
            LoadProtocol();
        }

        private void protocolsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.protocolsDataGridView.Rows[e.RowIndex];

            //    int protocolNumber = Convert.ToInt32(row.Cells["НомерПротокола"].Value);
            //    Создаем и показываем форму с данными протокола, если требуется
            //    var protocolDetails = new protocolsDetailsForm(protocolNumber);
            //    protocolDetails.Show();
            //}
        }
    }
}
