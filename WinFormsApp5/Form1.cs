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

            // Привязка события CellDoubleClick к методу обработчика
            this.driversDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(driversDataGridView_CellDoubleClick);

            // Установите DataGridView только для чтения
            this.driversDataGridView.ReadOnly = true;
            this.AutoDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(AutoDataGridView_CellDoubleClick);
            this.AutoDataGridView.ReadOnly = true;
            this.PolicemanDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(PolicemanDataGridView_CellDoubleClick);
            this.PolicemanDataGridView.ReadOnly = true;
            this.violationsDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(violationsDataGridView_CellDoubleClick);
            this.violationsDataGridView.ReadOnly = true;
            this.RegistrdataGridView.CellDoubleClick += new DataGridViewCellEventHandler(RegistrdataGridView_CellDoubleClick);
            this.RegistrdataGridView.ReadOnly = true;
            // Привязка обработчиков событий
            SurnameTextBox.KeyPress += new KeyPressEventHandler(SurnameTextBox_KeyPress);
            SurnameTextBox.Leave += new EventHandler(SurnameTextBox_Leave);

            firstnametextbox.KeyPress += new KeyPressEventHandler(firstnametextbox_KeyPress);
            firstnametextbox.Leave += new EventHandler(firstnametextbox_Leave);

            middlenametextbox.KeyPress += new KeyPressEventHandler(middlenametextbox_KeyPress);
            middlenametextbox.Leave += new EventHandler(middlenametextbox_Leave);

            passportnumbertextbox.KeyPress += new KeyPressEventHandler(passportnumbertextbox_KeyPress);
            phonetextbox.KeyPress += new KeyPressEventHandler(phonetextbox_KeyPress);
            phonetextbox.Leave += new EventHandler(phonetextbox_Leave);

            certificateofregistrationtextbox.KeyPress += new KeyPressEventHandler(certificateofregistrationtextbox_KeyPress);
            driverLicenseTextBox.KeyPress += new KeyPressEventHandler(driverLicenseTextBox_KeyPress);
            STStextBox.KeyPress += new KeyPressEventHandler(STStextBox_KeyPress);
            StrahovkaTextBox.KeyPress += new KeyPressEventHandler(StrahovkaTextBox_KeyPress);

            lastNameTextBox.KeyPress += new KeyPressEventHandler(lastNameTextBox_KeyPress);
            lastNameTextBox.Leave += new EventHandler(lastNameTextBox_Leave);

            fiNameTextBox.KeyPress += new KeyPressEventHandler(fiNameTextBox_KeyPress);
            fiNameTextBox.Leave += new EventHandler(fiNameTextBox_Leave);

            miNameTextBox.KeyPress += new KeyPressEventHandler(miNameTextBox_KeyPress);
            miNameTextBox.Leave += new EventHandler(miNameTextBox_Leave);

            passportTextBox.KeyPress += new KeyPressEventHandler(passportTextBox_KeyPress);

            protophonTextBox.KeyPress += new KeyPressEventHandler(protophonTextBox_KeyPress);
            protophonTextBox.Leave += new EventHandler(protophonTextBox_Leave);

            issuedProtocolsTextBox.KeyPress += new KeyPressEventHandler(issuedProtocolsTextBox_KeyPress);
            ProtocolNumber.KeyPress += new KeyPressEventHandler(ProtocolNumber_KeyPress);
            Fine.KeyPress += new KeyPressEventHandler(Fine_KeyPress);

            STStextBox5.KeyPress += new KeyPressEventHandler(STStextBox5_KeyPress);
            strahTextBox.KeyPress += new KeyPressEventHandler(strahTextBox_KeyPress);
            PopulateComboBoxes();
        }
        private void PopulateComboBoxes()
        {
            // Должности сотрудников ГАИ
            var positions = new List<string>
            {
                "Инспектор",
                "Старший инспектор",
                "Главный инспектор",
                "Начальник отдела",
                "Заместитель начальника отдела",
                "Старший госинспектор",
                "Госинспектор"
            };

            // Звания сотрудников ГАИ
            var ranks = new List<string>
            {
                "Младший лейтенант",
                "Лейтенант",
                "Старший лейтенант",
                "Капитан",
                "Майор",
                "Подполковник",
                "Полковник",
                "Генерал-майор",
                "Генерал-лейтенант",
                "Генерал-полковник"
            };
            var status = new List<string>
            {
                "оплачен",
                "не оплачен"
            };

            // Заполняем positionComboBox
            positioncomboBox.Items.Clear();
            positioncomboBox.Items.AddRange(positions.ToArray());

            // Заполняем rankComboBox
            rankcomboBox.Items.Clear();
            rankcomboBox.Items.AddRange(ranks.ToArray());



            statuscomboBox.Items.Clear();
            statuscomboBox.Items.AddRange(status.ToArray());
        }
        private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы, 'ё', 'Ё' и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 'ё' && e.KeyChar != 'Ё')
            {
                e.Handled = true;
            }
        }

        private void firstnametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы, 'ё', 'Ё' и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 'ё' && e.KeyChar != 'Ё')
            {
                e.Handled = true;
            }
        }

        private void middlenametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы, 'ё', 'Ё' и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 'ё' && e.KeyChar != 'Ё')
            {
                e.Handled = true;
            }
        }

        private void SurnameTextBox_Leave(object sender, EventArgs e)
        {
            // Переводим первую букву в заглавную
            SurnameTextBox.Text = CapitalizeFirstLetter(SurnameTextBox.Text);
        }

        private void firstnametextbox_Leave(object sender, EventArgs e)
        {
            // Переводим первую букву в заглавную
            firstnametextbox.Text = CapitalizeFirstLetter(firstnametextbox.Text);
        }

        private void middlenametextbox_Leave(object sender, EventArgs e)
        {
            // Переводим первую букву в заглавную
            middlenametextbox.Text = CapitalizeFirstLetter(middlenametextbox.Text);
        }

        private string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        private void passportnumbertextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void phonetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace, плюс разрешаем только + в начале
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void phonetextbox_Leave(object sender, EventArgs e)
        {
            // Проверяем, чтобы номер начинался с +7 и содержал еще 10 цифр
            if (!phonetextbox.Text.StartsWith("+7") || phonetextbox.Text.Length != 12)
            {
                MessageBox.Show("Номер телефона должен начинаться с +7 и содержать 10 цифр после +7.");
                phonetextbox.Focus();
            }
        }

        private void certificateofregistrationtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void StrahovkaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void driverLicenseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void STStextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //ГАИ
        private void lastNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы, 'ё', 'Ё' и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 'ё' && e.KeyChar != 'Ё')
            {
                e.Handled = true;
            }
        }

        private void fiNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы, 'ё', 'Ё' и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 'ё' && e.KeyChar != 'Ё')
            {
                e.Handled = true;
            }
        }

        private void miNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы, 'ё', 'Ё' и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 'ё' && e.KeyChar != 'Ё')
            {
                e.Handled = true;
            }
        }


        private void lastNameTextBox_Leave(object sender, EventArgs e)
        {
            lastNameTextBox.Text = CapitalizeFirstLetter(lastNameTextBox.Text);
        }

        private void fiNameTextBox_Leave(object sender, EventArgs e)
        {
            fiNameTextBox.Text = CapitalizeFirstLetter(fiNameTextBox.Text);
        }

        private void miNameTextBox_Leave(object sender, EventArgs e)
        {
            miNameTextBox.Text = CapitalizeFirstLetter(miNameTextBox.Text);
        }
        private void passportTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void protophonTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace, плюс разрешаем только + в начале
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void protophonTextBox_Leave(object sender, EventArgs e)
        {
            // Проверяем, чтобы номер начинался с +7 и содержал еще 10 цифр
            if (!protophonTextBox.Text.StartsWith("+7") || protophonTextBox.Text.Length != 12)
            {
                MessageBox.Show("Номер телефона должен начинаться с +7 и содержать 10 цифр после +7.");
                protophonTextBox.Focus();
            }
        }

        private void issuedProtocolsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, Backspace и "№" в начале строки
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ProtocolNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Fine_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void STStextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void strahTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
            if (AutoDataGridView.Columns.Contains("Владелец_ID"))
            {
                AutoDataGridView.Columns["Владелец_ID"].Visible = false;
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

            // Скрытие столбцов "Id", "Авто_Id" и "ГАИ_Сотрудник_ID"
            if (violationsDataGridView.Columns.Contains("Id"))
            {
                violationsDataGridView.Columns["Id"].Visible = false;
            }
            if (violationsDataGridView.Columns.Contains("Авто_Id"))
            {
                violationsDataGridView.Columns["Авто_Id"].Visible = false;
            }
            if (violationsDataGridView.Columns.Contains("ГАИ_Сотрудник_ID"))
            {
                violationsDataGridView.Columns["ГАИ_Сотрудник_ID"].Visible = false;
            }
            if (violationsDataGridView.Columns.Contains("Водитель_ID"))
            {
                violationsDataGridView.Columns["Водитель_ID"].Visible = false;
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
            if (RegistrdataGridView.Columns.Contains("Авто_ID"))
            {
                RegistrdataGridView.Columns["Авто_ID"].Visible = false;
            }
            if (RegistrdataGridView.Columns.Contains("Водитель_ID"))
            {
                RegistrdataGridView.Columns["Водитель_ID"].Visible = false;
            }
            if (RegistrdataGridView.Columns.Contains("Сотрудник_ID"))
            {
                RegistrdataGridView.Columns["Сотрудник_ID"].Visible = false;
            }
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
            Application.Exit(); // Завершить приложение при закрытии Form1            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchdriver_Click_1(object sender, EventArgs e)
        {
            string lastName = SurnameTextBox.Text.Trim();
            string firstName = firstnametextbox.Text.Trim();
            string middleName = middlenametextbox.Text.Trim();
            string passportNumber = passportnumbertextbox.Text.Trim();
            string phone = phonetextbox.Text.Trim();
            string address = addresstextbox.Text.Trim();
            string certificateOfRegistration = certificateofregistrationtextbox.Text.Trim();
            string driverLicense = driverLicenseTextBox.Text.Trim();
            DateTime dateOfBirth = driverDateOfBirthPicker.Value;
            bool includeDate = checkBox1.Checked;

            string query = "SELECT * FROM Водители WHERE 1=1"; // Начало запроса

            // Условия поиска
            if (!string.IsNullOrEmpty(lastName))
                query += " AND Фамилия LIKE '%' || @lastName || '%'";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND Имя LIKE '%' || @firstName || '%'";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND Отчество LIKE '%' || @middleName || '%'";
            if (!string.IsNullOrEmpty(passportNumber))
                query += " AND НомерПаспорта LIKE '%' || @passportNumber || '%'";
            if (!string.IsNullOrEmpty(phone))
                query += " AND Телефон LIKE '%' || @phone || '%'";
            if (!string.IsNullOrEmpty(address))
                query += " AND Адрес LIKE '%' || @address || '%'";
            if (!string.IsNullOrEmpty(certificateOfRegistration))
                query += " AND СвидетельствоОРегистрации LIKE '%' || @certificateOfRegistration || '%'";
            if (!string.IsNullOrEmpty(driverLicense))
                query += " AND ВодительскоеУдостоверение LIKE '%' || @driverLicense || '%'";
            if (includeDate && dateOfBirth != DateTime.MinValue)
                query += " AND ДатаРождения = @dateOfBirth";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                // Добавление параметров
                if (!string.IsNullOrEmpty(lastName))
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                if (!string.IsNullOrEmpty(firstName))
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                if (!string.IsNullOrEmpty(middleName))
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                if (!string.IsNullOrEmpty(passportNumber))
                    cmd.Parameters.AddWithValue("@passportNumber", passportNumber);
                if (!string.IsNullOrEmpty(phone))
                    cmd.Parameters.AddWithValue("@phone", phone);
                if (!string.IsNullOrEmpty(address))
                    cmd.Parameters.AddWithValue("@address", address);
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                    cmd.Parameters.AddWithValue("@certificateOfRegistration", certificateOfRegistration);
                if (!string.IsNullOrEmpty(driverLicense))
                    cmd.Parameters.AddWithValue("@driverLicense", driverLicense);
                if (includeDate && dateOfBirth != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"));

                // Вывод на консоль для отладки
                Console.WriteLine("SQL Query: " + query);
                foreach (SQLiteParameter parameter in cmd.Parameters)
                {
                    Console.WriteLine($"{parameter.ParameterName}: {parameter.Value}");
                }

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
                        if (drivers.Rows.Count > 0)
                        {
                            try
                            {
                                // Убедитесь, что первая строка видима перед установкой текущей ячейки
                                if (driversDataGridView.Rows[0].Visible)
                                {
                                    driversDataGridView.Rows[0].Selected = true;
                                    driversDataGridView.CurrentCell = driversDataGridView.Rows[0].Cells
                                        .Cast<DataGridViewCell>()
                                        .First(cell => cell.Visible); // Установите текущую видимую ячейку
                                }
                            }
                            catch (InvalidOperationException ex)
                            {
                                // Обработка ошибки
                                MessageBox.Show("Ошибка при выборе текущей ячейки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
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

            // Проверяем, чтобы все поля были заполнены
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(middleName) ||
                string.IsNullOrEmpty(passportNumber) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(certificateOfRegistration) || string.IsNullOrEmpty(driverLicense))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            // Проверяем на уникальность
            if (IsDriverExists(lastName, firstName, middleName, passportNumber))
            {
                MessageBox.Show("Такой водитель уже существует.");
                return;
            }

            // SQL для вставки данных
            string insertDriver = "INSERT INTO Водители (Фамилия, Имя, Отчество, НомерПаспорта, Телефон, Адрес, СвидетельствоОРегистрации, ВодительскоеУдостоверение, ДатаРождения) " +
                                  "VALUES (@Фамилия, @Имя, @Отчество, @НомерПаспорта, @Телефон, @Адрес, @СвидетельствоОРегистрации, @ВодительскоеУдостоверение, @ДатаРождения)";

            try
            {
                using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
                {
                    // Добавление параметров
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
                MessageBox.Show("Водитель успешно добавлен!");
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для изменения.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int driverId = Convert.ToInt32(row.Cells["Id"].Value); // Получаем Идентификатор водителя

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
                                      "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", driverId);
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для удаления.");
                return;
            }

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

        private void driversDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что кликнули по строке
            {
                DataGridViewRow row = this.driversDataGridView.Rows[e.RowIndex];

                // Заполнение соответствующих текстовых полей
                SurnameTextBox.Text = row.Cells["Фамилия"].Value.ToString();
                firstnametextbox.Text = row.Cells["Имя"].Value.ToString();
                middlenametextbox.Text = row.Cells["Отчество"].Value.ToString();
                passportnumbertextbox.Text = row.Cells["НомерПаспорта"].Value.ToString();
                phonetextbox.Text = row.Cells["Телефон"].Value.ToString();
                addresstextbox.Text = row.Cells["Адрес"].Value.ToString();
                certificateofregistrationtextbox.Text = row.Cells["СвидетельствоОРегистрации"].Value.ToString();
                driverLicenseTextBox.Text = row.Cells["ВодительскоеУдостоверение"].Value.ToString();
                driverDateOfBirthPicker.Value = Convert.ToDateTime(row.Cells["ДатаРождения"].Value);
            }
        }



        private void driversDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string certificateOfRegistration = STStextBox.Text.Trim();
            string make = MakeTextBox.Text.Trim();
            string model = ModeltextBox.Text.Trim();
            string licensePlate = PlatetextBox.Text.Trim();
            int year;
            bool isYearParsed = int.TryParse(yeartextBox.Text, out year);
            string insurance = StrahovkaTextBox.Text.Trim();

            string searchQuery = "SELECT a.СвидетельствоОРегистрации, a.Марка, a.Модель, a.НомернойЗнак, a.Год, a.Владелец, a.Страхование " +
                                 "FROM Авто a WHERE 1=1"; // Начинаем с условия "1=1"

            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND a.СвидетельствоОРегистрации LIKE '%' || @СвидетельствоОРегистрации || '%'";
            }
            if (!string.IsNullOrEmpty(make))
            {
                searchQuery += " AND a.Марка LIKE '%' || @Марка || '%'";
            }
            if (!string.IsNullOrEmpty(model))
            {
                searchQuery += " AND a.Модель LIKE '%' || @Модель || '%'";
            }
            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND a.НомернойЗнак LIKE '%' || @НомернойЗнак || '%'";
            }
            if (isYearParsed)
            {
                searchQuery += " AND a.Год = @Год";
            }
            if (!string.IsNullOrEmpty(insurance))
            {
                searchQuery += " AND a.Страхование LIKE '%' || @Страхование || '%'";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                }
                if (!string.IsNullOrEmpty(make))
                {
                    cmd.Parameters.AddWithValue("@Марка", make);
                }
                if (!string.IsNullOrEmpty(model))
                {
                    cmd.Parameters.AddWithValue("@Модель", model);
                }
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                }
                if (isYearParsed)
                {
                    cmd.Parameters.AddWithValue("@Год", year);
                }
                if (!string.IsNullOrEmpty(insurance))
                {
                    cmd.Parameters.AddWithValue("@Страхование", insurance);
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
            string insurance = StrahovkaTextBox.Text.Trim();
            int year;

            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(certificateOfRegistration) || string.IsNullOrEmpty(make) ||
                string.IsNullOrEmpty(model) || string.IsNullOrEmpty(licensePlate) ||
                string.IsNullOrEmpty(insurance) || !int.TryParse(yeartextBox.Text, out year))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                return;
            }

            try
            {
                // Проверка на существующий номерной знак
                string checkLicensePlateQuery = "SELECT COUNT(*) FROM Авто WHERE НомернойЗнак = @licensePlate";
                using (var checkCmd = new SQLiteCommand(checkLicensePlateQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@licensePlate", licensePlate);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Автомобиль с таким номерным знаком уже существует.");
                        return;
                    }
                }

                // SQL для вставки данных об автомобиле и определения владельца
                string insertCarQuery = @"
INSERT INTO Авто (СвидетельствоОРегистрации, Марка, Модель, НомернойЗнак, Год, Владелец, Владелец_ID, Страхование) 
VALUES (@СвидетельствоОРегистрации, @Марка, @Модель, @НомернойЗнак, @Год, 
        (SELECT Фамилия || ' ' || SUBSTR(Имя, 1, 1) || '. ' || IFNULL(SUBSTR(Отчество, 1, 1) || '.', '') 
         FROM Водители WHERE СвидетельствоОРегистрации = @СвидетельствоОРегистрации), 
        (SELECT Id FROM Водители WHERE СвидетельствоОРегистрации = @СвидетельствоОРегистрации), 
        @Страхование)";

                using (var insertCmd = new SQLiteCommand(insertCarQuery, sqliteConn))
                {
                    insertCmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                    insertCmd.Parameters.AddWithValue("@Марка", make);
                    insertCmd.Parameters.AddWithValue("@Модель", model);
                    insertCmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                    insertCmd.Parameters.AddWithValue("@Год", year);
                    insertCmd.Parameters.AddWithValue("@Страхование", insurance);

                    insertCmd.ExecuteNonQuery(); // Выполняем запрос
                }

                MessageBox.Show("Автомобиль успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автомобиля: {ex.Message}");
            }

            LoadAuto();
        }

        private void EditCar_Click_1(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для изменения.");
                return;
            }

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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для удаления.");
                return;
            }

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

        private void AutoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что вы кликнули по строке
            {
                DataGridViewRow row = this.AutoDataGridView.Rows[e.RowIndex];

                // Получаем данные для заполнения текстовых полей
                string certificateOfRegistration = row.Cells["СвидетельствоОРегистрации"].Value.ToString();
                string make = row.Cells["Марка"].Value.ToString();
                string model = row.Cells["Модель"].Value.ToString();
                string licensePlate = row.Cells["НомернойЗнак"].Value.ToString();
                int year = Convert.ToInt32(row.Cells["Год"].Value);
                string ownerFullName = row.Cells["Владелец"].Value.ToString();
                string insurance = row.Cells["Страхование"].Value?.ToString() ?? string.Empty; // Предполагается, что есть колонка Страхование

                // Заполняем текстовые поля на форме
                STStextBox.Text = certificateOfRegistration;
                MakeTextBox.Text = make;
                ModeltextBox.Text = model;
                PlatetextBox.Text = licensePlate;
                yeartextBox.Text = year.ToString();
                OwnerTextBox.Text = ownerFullName;
                StrahovkaTextBox.Text = insurance; // Добавляем заполнение поля StrahovkaTextBox
            }
        }




        private void AutoDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchPolice_Click(object sender, EventArgs e)
        {
            string lastName = lastNameTextBox.Text.Trim();
            string firstName = fiNameTextBox.Text.Trim();
            string middleName = miNameTextBox.Text.Trim();
            string passportNumber = passportTextBox.Text.Trim();
            string phone = protophonTextBox.Text.Trim();
            string address = addrTextBox.Text.Trim();
            string rank = rankcomboBox.SelectedItem?.ToString() ?? string.Empty;
            string position = positioncomboBox.SelectedItem?.ToString() ?? string.Empty;
            string issuedProtocol = issuedProtocolsTextBox.Text.Trim();
            bool includeDate = checkBox1.Checked;
            DateTime dateOfBirth = DateOfBirthPicker.Value;

            string query = "SELECT * FROM СотрудникГАИ WHERE 1=1"; // Начало запроса

            // Условия поиска
            if (!string.IsNullOrEmpty(lastName))
                query += " AND Фамилия LIKE '%' || @lastName || '%'";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND Имя LIKE '%' || @firstName || '%'";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND Отчество LIKE '%' || @middleName || '%'";
            if (!string.IsNullOrEmpty(passportNumber))
                query += " AND НомерПаспорта LIKE '%' || @passportNumber || '%'";
            if (!string.IsNullOrEmpty(phone))
                query += " AND Телефон LIKE '%' || @phone || '%'";
            if (!string.IsNullOrEmpty(address))
                query += " AND Адрес LIKE '%' || @address || '%'";
            if (!string.IsNullOrEmpty(rank))
                query += " AND Звание LIKE '%' || @rank || '%'";
            if (!string.IsNullOrEmpty(position))
                query += " AND Должность LIKE '%' || @position || '%'";
            if (includeDate && dateOfBirth != DateTime.MinValue) // Проверка, если дата рождения указана
                query += " AND ДатаРождения = @dateOfBirth";
            if (!string.IsNullOrEmpty(issuedProtocol))
                query += " AND ВыписанныйПротокол LIKE '%' || @issuedProtocol || '%'";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                // Добавление параметров
                if (!string.IsNullOrEmpty(lastName))
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                if (!string.IsNullOrEmpty(firstName))
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                if (!string.IsNullOrEmpty(middleName))
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                if (!string.IsNullOrEmpty(passportNumber))
                    cmd.Parameters.AddWithValue("@passportNumber", passportNumber);
                if (!string.IsNullOrEmpty(phone))
                    cmd.Parameters.AddWithValue("@phone", phone);
                if (!string.IsNullOrEmpty(address))
                    cmd.Parameters.AddWithValue("@address", address);
                if (!string.IsNullOrEmpty(rank))
                    cmd.Parameters.AddWithValue("@rank", rank);
                if (!string.IsNullOrEmpty(position))
                    cmd.Parameters.AddWithValue("@position", position);
                if (includeDate && dateOfBirth != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"));
                if (!string.IsNullOrEmpty(issuedProtocol))
                    cmd.Parameters.AddWithValue("@issuedProtocol", issuedProtocol);

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
            string rank = rankcomboBox.SelectedItem?.ToString();
            string position = positioncomboBox.SelectedItem?.ToString();
            string dateOfBirth = DateOfBirthPicker.Value.ToString("yyyy-MM-dd");
            string protocolNumber = issuedProtocolsTextBox.Text.Trim();

            // Проверяем, чтобы все поля были заполнены
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(middleName) ||
                string.IsNullOrEmpty(passportNumber) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(rank) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(protocolNumber))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            // Проверка на уникальность сотрудника по ФИО и номеру паспорта
            string checkUniqueQuery = "SELECT COUNT(*) FROM СотрудникГАИ WHERE Фамилия = @lastName AND Имя = @firstName AND Отчество = @middleName AND НомерПаспорта = @passportNumber";
            int count = 0;

            try
            {
                using (var checkCmd = new SQLiteCommand(checkUniqueQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@lastName", lastName);
                    checkCmd.Parameters.AddWithValue("@firstName", firstName);
                    checkCmd.Parameters.AddWithValue("@middleName", middleName);
                    checkCmd.Parameters.AddWithValue("@passportNumber", passportNumber);

                    count = Convert.ToInt32(checkCmd.ExecuteScalar());
                }

                if (count > 0)
                {
                    MessageBox.Show("Сотрудник с такими ФИО и номером паспорта уже существует.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке уникальности сотрудника: {ex.Message}");
                return;
            }

            // Проверка на уникальность выписанного протокола
            string checkProtocolQuery = "SELECT COUNT(*) FROM СотрудникГАИ WHERE ВыписанныйПротокол = @protocolNumber";
            int protocolCount = 0;

            try
            {
                using (var protocolCmd = new SQLiteCommand(checkProtocolQuery, sqliteConn))
                {
                    protocolCmd.Parameters.AddWithValue("@protocolNumber", protocolNumber);
                    protocolCount = Convert.ToInt32(protocolCmd.ExecuteScalar());
                }

                if (protocolCount > 0)
                {
                    MessageBox.Show("Протокол с таким номером уже выписан.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке уникальности протокола: {ex.Message}");
                return;
            }

            // SQL для вставки данных
            string insertPolice = "INSERT INTO СотрудникГАИ (Фамилия, Имя, Отчество, НомерПаспорта, Телефон, Адрес, ДатаРождения, Звание, Должность, ВыписанныйПротокол) " +
                                  "VALUES (@lastName, @firstName, @middleName, @passportNumber, @phone, @address, @dateOfBirth, @rank, @position, @protocolNumber)";

            try
            {
                using (var cmd = new SQLiteCommand(insertPolice, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                    cmd.Parameters.AddWithValue("@passportNumber", passportNumber);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@rank", rank);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@protocolNumber", protocolNumber);
                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
                MessageBox.Show("Сотрудник успешно добавлен!");
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для изменения.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row.Selected)
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
                                          "Должность = COALESCE(NULLIF(@position, ''), Должность), " +
                                          "ВыписанныйПротокол = COALESCE(NULLIF(@protocolNumber, ''), ВыписанныйПротокол) " +
                                          "WHERE Id = @id";

                    using (var cmd = new SQLiteCommand(updatePolice, sqliteConn))
                    {
                        cmd.Parameters.AddWithValue("@id", policemanId);
                        cmd.Parameters.AddWithValue("@lastName", string.IsNullOrWhiteSpace(lastNameTextBox.Text) ? (object)DBNull.Value : lastNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@firstName", string.IsNullOrWhiteSpace(fiNameTextBox.Text) ? (object)DBNull.Value : fiNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@middleName", string.IsNullOrWhiteSpace(miNameTextBox.Text) ? (object)DBNull.Value : miNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@passportNumber", string.IsNullOrWhiteSpace(passportTextBox.Text) ? (object)DBNull.Value : passportTextBox.Text);
                        cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(protophonTextBox.Text) ? (object)DBNull.Value : protophonTextBox.Text);
                        cmd.Parameters.AddWithValue("@address", string.IsNullOrWhiteSpace(addrTextBox.Text) ? (object)DBNull.Value : addrTextBox.Text);
                        cmd.Parameters.AddWithValue("@dateOfBirth", DateOfBirthPicker.Value == DateOfBirthPicker.MinDate ? (object)DBNull.Value : DateOfBirthPicker.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@rank", rankcomboBox.SelectedItem == null ? (object)DBNull.Value : rankcomboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@position", positioncomboBox.SelectedItem == null ? (object)DBNull.Value : positioncomboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@protocolNumber", string.IsNullOrWhiteSpace(issuedProtocolsTextBox.Text) ? (object)DBNull.Value : issuedProtocolsTextBox.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            LoadPoliceman(); // Перезагрузить данные
        }




        private void DeletePolice_Click_1(object sender, EventArgs e)
        {
            var selectedRows = PolicemanDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для удаления.");
                return;
            }

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

        private void PolicemanDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            string protocol = selectedRow.Cells["ВыписанныйПротокол"].Value.ToString();

            // Заполняем текстовые поля на форме
            lastNameTextBox.Text = lastName;
            fiNameTextBox.Text = firstName;
            miNameTextBox.Text = middleName;
            passportTextBox.Text = passportNumber;
            protophonTextBox.Text = phone;
            addrTextBox.Text = address;
            DateOfBirthPicker.Value = dateOfBirth;
            rankcomboBox.SelectedItem = rank;
            positioncomboBox.SelectedItem = position;
            issuedProtocolsTextBox.Text = protocol;
        }




        private void PolicemanDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchViol_Click_1(object sender, EventArgs e)
        {
            string protocolNumber = ProtocolNumber.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value;
            string violation = Description.Text.Trim();
            string info = Info.Text.Trim();
            string licensePlate = Licenseplate.Text.Trim();
            string status = statuscomboBox.SelectedItem?.ToString() ?? string.Empty; // Получаем выбранный статус штрафа
            bool includeDate = checkBox1.Checked;

            string query = "SELECT * FROM Нарушения WHERE 1=1"; // Начало запроса

            // Условия поиска
            if (!string.IsNullOrEmpty(protocolNumber))
                query += " AND НомерПротокола LIKE @protocolNumber";
            if (includeDate && violationDate != DateTime.MinValue)
                query += " AND ДатаНарушения = @violationDate";
            if (!string.IsNullOrEmpty(violation))
                query += " AND Нарушение LIKE @violation";
            if (!string.IsNullOrEmpty(info))
                query += " AND Описание LIKE @info";
            if (!string.IsNullOrEmpty(licensePlate))
                query += " AND НомернойЗнак LIKE @licensePlate";
            if (!string.IsNullOrEmpty(status))
                query += " AND СтатусШтрафа = @status"; // Изменяем на точное сравнение

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                // Добавление параметров
                if (!string.IsNullOrEmpty(protocolNumber))
                    cmd.Parameters.AddWithValue("@protocolNumber", "%" + protocolNumber + "%");
                if (includeDate && violationDate != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@violationDate", violationDate.ToString("yyyy-MM-dd"));
                if (!string.IsNullOrEmpty(violation))
                    cmd.Parameters.AddWithValue("@violation", "%" + violation + "%");
                if (!string.IsNullOrEmpty(info))
                    cmd.Parameters.AddWithValue("@info", "%" + info + "%");
                if (!string.IsNullOrEmpty(licensePlate))
                    cmd.Parameters.AddWithValue("@licensePlate", "%" + licensePlate + "%");
                if (!string.IsNullOrEmpty(status))
                    cmd.Parameters.AddWithValue("@status", status); // Передаем статус без процентов

                // Вывод параметров для отладки
                Console.WriteLine("SQL Query: " + query);
                foreach (SQLiteParameter parameter in cmd.Parameters)
                {
                    Console.WriteLine($"{parameter.ParameterName}: {parameter.Value}");
                }

                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении поиска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            string protocolNumber = ProtocolNumber.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value;
            string violation = Description.Text.Trim();
            string fineText = Fine.Text.Trim();
            string description = Info.Text.Trim();
            string licensePlate = Licenseplate.Text.Trim();
            string status = statuscomboBox.SelectedItem.ToString(); // Получаем выбранный статус штрафа

            // Проверка, чтобы все поля были заполнены
            if (string.IsNullOrEmpty(protocolNumber) || string.IsNullOrEmpty(violation) || string.IsNullOrEmpty(fineText) ||
                string.IsNullOrEmpty(description) || string.IsNullOrEmpty(licensePlate))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            // Проверка корректности ввода штрафа
            decimal fine;
            if (!decimal.TryParse(fineText, out fine))
            {
                MessageBox.Show("Пожалуйста, введите корректный штраф.");
                return;
            }

            // Проверка наличия протокола в таблице Нарушения
            string checkViolationProtocolQuery = "SELECT COUNT(*) FROM Нарушения WHERE НомерПротокола = @ProtocolNumber";
            int violationProtocolCount = 0;

            try
            {
                using (var checkCmd = new SQLiteCommand(checkViolationProtocolQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@ProtocolNumber", protocolNumber);
                    violationProtocolCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                }

                if (violationProtocolCount > 0)
                {
                    MessageBox.Show("Протокол с таким номером уже существует.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке протокола: {ex.Message}");
                return;
            }

            // Проверка наличия автомобиля в таблице Авто
            string checkCarQuery = "SELECT Id, Владелец, Владелец_ID FROM Авто WHERE НомернойЗнак = @LicensePlate";
            int carId = 0;
            string driver = "";
            int driverId = 0;

            try
            {
                using (var checkCmd = new SQLiteCommand(checkCarQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@LicensePlate", licensePlate);
                    using (var reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carId = reader.GetInt32(0);
                            driver = reader.GetString(1);
                            driverId = reader.GetInt32(2);
                        }
                        else
                        {
                            MessageBox.Show("Автомобиль с таким номерным знаком не существует.");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке автомобиля: {ex.Message}");
                return;
            }

            // Получение Id сотрудника ГАИ
            int gAI_OfficerId = 0;
            string checkGAIOfficerQuery = "SELECT Id FROM СотрудникГАИ WHERE ВыписанныйПротокол = @ProtocolNumber";
            try
            {
                using (var checkGAICmd = new SQLiteCommand(checkGAIOfficerQuery, sqliteConn))
                {
                    checkGAICmd.Parameters.AddWithValue("@ProtocolNumber", protocolNumber);
                    var gAIResult = checkGAICmd.ExecuteScalar();
                    if (gAIResult != null)
                    {
                        gAI_OfficerId = Convert.ToInt32(gAIResult);
                    }
                    else
                    {
                        MessageBox.Show("Сотрудник ГАИ с данным номером протокола не найден.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке сотрудника ГАИ: {ex.Message}");
                return;
            }

            // SQL для вставки данных
            string insertViolation = @"
INSERT INTO Нарушения (НомерПротокола, ДатаНарушения, Нарушение, НомернойЗнак, Штраф, Описание, СтатусШтрафа, Водитель, ВыписалПротокол, Авто_Id, ГАИ_Сотрудник_ID, Водитель_ID) 
VALUES (@ProtocolNumber, @ViolationDate, @Violation, @LicensePlate, @FineText, @Description, @Status, 
        @Driver, 
        (SELECT Звание || ' ' || Фамилия || ' ' || SUBSTR(Имя, 1, 1) || '.' || IFNULL(SUBSTR(Отчество, 1, 1) || '.', '') 
         FROM СотрудникГАИ WHERE ВыписанныйПротокол = @ProtocolNumber), 
        @CarId, 
        @GAI_OfficerId, 
        @DriverId)";

            try
            {
                using (var cmd = new SQLiteCommand(insertViolation, sqliteConn))
                {
                    // Добавление параметров
                    cmd.Parameters.AddWithValue("@ProtocolNumber", protocolNumber);
                    cmd.Parameters.AddWithValue("@ViolationDate", violationDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Violation", violation);
                    cmd.Parameters.AddWithValue("@LicensePlate", licensePlate);
                    cmd.Parameters.AddWithValue("@FineText", fineText);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Driver", driver);
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.Parameters.AddWithValue("@GAI_OfficerId", gAI_OfficerId);
                    cmd.Parameters.AddWithValue("@DriverId", driverId);

                    cmd.ExecuteNonQuery(); // Выполняем запрос
                }
                MessageBox.Show("Нарушение успешно добавлено!");
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для изменения.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int violationId = Convert.ToInt32(row.Cells["Id"].Value);

                string updateViolation = "UPDATE Нарушения SET " +
                                         "НомерПротокола = COALESCE(NULLIF(@ProtocolNumber, ''), НомерПротокола), " +
                                         "ДатаНарушения = COALESCE(NULLIF(@ViolationDate, ''), ДатаНарушения), " +
                                         "Нарушение = COALESCE(NULLIF(@Violation, ''), Нарушение), " +
                                         "НомернойЗнак = COALESCE(NULLIF(@LicensePlate, ''), НомернойЗнак), " +
                                         "Штраф = COALESCE(NULLIF(@Fine, ''), Штраф), " +
                                         "Описание = COALESCE(NULLIF(@Description, ''), Описание), " +
                                         "СтатусШтрафа = COALESCE(NULLIF(@Status, ''), СтатусШтрафа) " +
                                         "WHERE Id = @Id";

                try
                {
                    using (var cmd = new SQLiteCommand(updateViolation, sqliteConn))
                    {
                        // Добавление параметров
                        cmd.Parameters.AddWithValue("@Id", violationId);
                        cmd.Parameters.AddWithValue("@ProtocolNumber", string.IsNullOrEmpty(ProtocolNumber.Text.Trim()) ? (object)DBNull.Value : ProtocolNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@ViolationDate", VioldateTimePicker.Value == VioldateTimePicker.MinDate ? (object)DBNull.Value : VioldateTimePicker.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Violation", string.IsNullOrEmpty(Description.Text.Trim()) ? (object)DBNull.Value : Description.Text.Trim());
                        cmd.Parameters.AddWithValue("@LicensePlate", string.IsNullOrEmpty(Licenseplate.Text.Trim()) ? (object)DBNull.Value : Licenseplate.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fine", string.IsNullOrEmpty(Fine.Text.Trim()) ? (object)DBNull.Value : (object)Convert.ToDecimal(Fine.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Info.Text.Trim()) ? (object)DBNull.Value : Info.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", statuscomboBox.SelectedItem == null ? (object)DBNull.Value : statuscomboBox.SelectedItem.ToString());

                        cmd.ExecuteNonQuery(); // Выполняем обновление
                    }
                    MessageBox.Show("Нарушение успешно обновлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении нарушения: {ex.Message}");
                }
            }

            LoadViolations(); // Перезагрузить данные
        }




        private void DelViol_Click_1(object sender, EventArgs e)
        {
            var selectedRows = violationsDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для удаления.");
                return;
            }

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

        private void violationsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Отключаем обработку заголовков

            // Получаем выбранную строку
            DataGridViewRow selectedRow = violationsDataGridView.Rows[e.RowIndex];

            // Извлекаем данные из ячеек
            string protocolNumber = selectedRow.Cells["НомерПротокола"].Value.ToString();
            string violation = selectedRow.Cells["Нарушение"].Value.ToString();
            string description = selectedRow.Cells["Описание"].Value.ToString();
            string licensePlate = selectedRow.Cells["НомернойЗнак"].Value.ToString();
            decimal fine = Convert.ToDecimal(selectedRow.Cells["Штраф"].Value);
            DateTime violateDate = Convert.ToDateTime(selectedRow.Cells["ДатаНарушения"].Value);
            string inspectorName = selectedRow.Cells["ВыписалПротокол"].Value.ToString();
            string driverName = selectedRow.Cells["Водитель"].Value.ToString();
            string status = selectedRow.Cells["СтатусШтрафа"].Value.ToString();

            // Заполняем текстовые поля на форме
            ProtocolNumber.Text = protocolNumber;
            Description.Text = violation;
            Licenseplate.Text = licensePlate;
            Fine.Text = fine.ToString();
            Info.Text = description;
            VioldateTimePicker.Value = violateDate;
            FIOGAItextBox.Text = inspectorName;
            FIOVODtextBox.Text = driverName;
            statuscomboBox.Text = status;
        }

        private void violationsDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchRegistr_Click(object sender, EventArgs e)
        {
            string certificateOfRegistration = STStextBox5.Text.Trim();
            string insurance = strahTextBox.Text.Trim();
            string licensePlate = NumberTextBox.Text.Trim();
            DateTime registrationDate = dateTimePicker1.Value;
            bool includeDate = checkBox1.Checked;

            // Начинаем с базового запроса
            string searchQuery = "SELECT r.Владелец, r.НомернойЗнак, r.СвидетельствоОРегистрации, r.Страховка, r.ДатаРегистрации " +
                                 "FROM Регистрация r WHERE 1=1"; // Условие всегда истинно (для удобства добавления других условий)

            // Добавляем условия поиска
            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND r.СвидетельствоОРегистрации LIKE '%' || @СвидетельствоОРегистрации || '%'";
            }
            if (!string.IsNullOrEmpty(insurance))
            {
                searchQuery += " AND r.Страховка LIKE '%' || @Страховка || '%'";
            }
            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND r.НомернойЗнак LIKE '%' || @НомернойЗнак || '%'";
            }
            if (includeDate && registrationDate != DateTime.MinValue)
            {
                searchQuery += " AND r.ДатаРегистрации = @ДатаРегистрации";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                // Заполняем параметры, если они были введены
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                }
                if (!string.IsNullOrEmpty(insurance))
                {
                    cmd.Parameters.AddWithValue("@Страховка", insurance);
                }
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                }
                if (includeDate && registrationDate != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@ДатаРегистрации", registrationDate.ToString("yyyy-MM-dd"));
                }

                // Выполняем запрос и наполняем DataGridView
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var resultTable = new DataTable();
                    adapter.Fill(resultTable);

                    // Проверяем наличие результатов
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
            string certificateOfRegistration = STStextBox5.Text.Trim();
            DateTime registrationDate = dateTimePicker1.Value;

            // Проверка, чтобы все поля были заполнены
            if (string.IsNullOrEmpty(certificateOfRegistration))
            {
                MessageBox.Show("Пожалуйста, заполните поле свидетельства о регистрации.");
                return;
            }

            // Проверка на существующий СТС
            string checkExistingQuery = "SELECT COUNT(*) FROM Регистрация WHERE СвидетельствоОРегистрации = @certificateOfRegistration";
            using (var checkCmd = new SQLiteCommand(checkExistingQuery, sqliteConn))
            {
                checkCmd.Parameters.AddWithValue("@certificateOfRegistration", certificateOfRegistration);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Регистрация с таким СТС уже существует.");
                    return;
                }
            }

            // Получение данных из таблицы Авто по СТС
            string checkCarQuery = "SELECT Id, НомернойЗнак, Владелец, Страхование FROM Авто WHERE СвидетельствоОРегистрации = @СвидетельствоОРегистрации";
            int carId = 0;
            string licensePlate = "";
            string owner = "";
            string insurance = "";
            int driverId = 0;

            try
            {
                using (var checkCmd = new SQLiteCommand(checkCarQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                    using (var reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carId = reader.GetInt32(0);
                            licensePlate = reader.GetString(1);
                            owner = reader.GetString(2);
                            insurance = reader.GetString(3);
                        }
                        else
                        {
                            MessageBox.Show("Автомобиль с таким СТС не найден.");
                            return;
                        }
                    }
                }

                // Получение Водитель_ID из таблицы Водители по СТС
                string checkDriverQuery = "SELECT Id FROM Водители WHERE СвидетельствоОРегистрации = @СвидетельствоОРегистрации";

                using (var checkCmd = new SQLiteCommand(checkDriverQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                    var result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        driverId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Водитель с таким СТС не найден.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке данных: {ex.Message}");
                return;
            }

            // SQL для вставки данных
            string insertQuery = "INSERT INTO Регистрация (Владелец, НомернойЗнак, СвидетельствоОРегистрации, Страховка, ДатаРегистрации, Водитель_ID, Авто_ID) " +
                                 "VALUES (@Владелец, @НомернойЗнак, @СвидетельствоОРегистрации, @Страховка, @ДатаРегистрации, @Водитель_ID, @Авто_ID)";

            try
            {
                using (var cmd = new SQLiteCommand(insertQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Владелец", owner);
                    cmd.Parameters.AddWithValue("@НомернойЗнак", licensePlate);
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", certificateOfRegistration);
                    cmd.Parameters.AddWithValue("@Страховка", insurance);
                    cmd.Parameters.AddWithValue("@ДатаРегистрации", registrationDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Водитель_ID", driverId);
                    cmd.Parameters.AddWithValue("@Авто_ID", carId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Регистрация успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении регистрации: {ex.Message}");
            }
            LoadRegistr(); // Перезагрузить данные
        }


        private void EditRegister_Click(object sender, EventArgs e)
        {
            var selectedRows = RegistrdataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для изменения.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int registrationId = Convert.ToInt32(row.Cells["Id"].Value);
                string updatedCertificateOfRegistration = STStextBox5.Text.Trim();
                string updatedLicensePlate = NumberTextBox.Text.Trim();
                DateTime updatedRegistrationDate = dateTimePicker1.Value; // Дата регистрации
                string updatedInsurance = strahTextBox.Text.Trim();

                string updateCarQuery = "UPDATE Регистрация SET " +
                                        "СвидетельствоОРегистрации = COALESCE(NULLIF(@СвидетельствоОРегистрации, ''), СвидетельствоОРегистрации), " +
                                        "НомернойЗнак = COALESCE(NULLIF(@НомернойЗнак, ''), НомернойЗнак), " +
                                        "ДатаРегистрации = COALESCE(NULLIF(@ДатаРегистрации, '0001-01-01'), ДатаРегистрации), " +
                                        "Страховка = COALESCE(NULLIF(@Страховка, ''), Страховка) " +
                                        "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateCarQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", registrationId);
                    cmd.Parameters.AddWithValue("@СвидетельствоОРегистрации", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@НомернойЗнак", updatedLicensePlate);
                    cmd.Parameters.AddWithValue("@ДатаРегистрации", updatedRegistrationDate.ToString("yyyy-MM-dd")); // Форматирование даты
                    cmd.Parameters.AddWithValue("@Страховка", updatedInsurance);

                    cmd.ExecuteNonQuery(); // Выполняем обновление
                }
            }

            LoadRegistr(); // Перезагрузить данные
        }


        private void ObnoveRegistr_Click(object sender, EventArgs e)
        {
            LoadRegistr();
        }

        private void RegistrdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Убедитесь, что вы кликнули по строке
            {
                DataGridViewRow row = this.RegistrdataGridView.Rows[e.RowIndex];

                // Получаем данные для заполнения текстовых полей
                string certificateOfRegistration = row.Cells["СвидетельствоОРегистрации"].Value.ToString();
                string strahovka = row.Cells["Страховка"].Value?.ToString() ?? string.Empty; // Предполагается, что есть колонка Страховка
                string licensePlate = row.Cells["НомернойЗнак"].Value.ToString();
                DateTime registrationDate = Convert.ToDateTime(row.Cells["ДатаРегистрации"].Value);
                string driverName = row.Cells["Владелец"].Value?.ToString() ?? string.Empty; // Предполагается, что есть колонка Владелец

                // Заполняем текстовые поля на форме
                STStextBox5.Text = certificateOfRegistration;
                strahTextBox.Text = strahovka;
                NumberTextBox.Text = licensePlate;
                dateTimePicker1.Value = registrationDate;
                FiodrivertextBox.Text = driverName;
            }
        }

        private void RegistrdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteRegistr_Click(object sender, EventArgs e)
        {
            var selectedRows = RegistrdataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выделите строку для удаления.");
                return;
            }
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

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Очистка всех TextBox и ComboBox
            foreach (Control control in this.Controls)
            {
                ClearControl(control);
            }

            // Очистка всех элементов внутри TabControl
            foreach (TabPage tab in tabControl1.TabPages)
            {
                foreach (Control control in tab.Controls)
                {
                    ClearControl(control);
                }
            }
        }

        // Рекурсивный метод для очистки TextBox и ComboBox
        private void ClearControl(Control control)
        {
            if (control is TextBox)
            {
                ((TextBox)control).Clear();
            }
            else if (control is ComboBox)
            {
                ((ComboBox)control).SelectedIndex = -1; // Сбросить выделение
            }
            else if (control is Panel || control is GroupBox)
            {
                foreach (Control nestedControl in control.Controls)
                {
                    ClearControl(nestedControl);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide(); // Скрыть текущую форму вместо закрытия
            }
            // Если пользователь выбрал "Нет", ничего не делаем, и форма останется открытой.
        }
    }
}
