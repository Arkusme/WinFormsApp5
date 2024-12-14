using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{

    public partial class User : Form
    {
        private SQLiteConnection sqliteConn;
        public User()
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

            this.violationsDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(violationsDataGridView_CellDoubleClick);
            this.violationsDataGridView.ReadOnly = true;

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

            ProtocolNumber.KeyPress += new KeyPressEventHandler(ProtocolNumber_KeyPress);
            ProtocolNumber.Leave += new EventHandler(ProtocolNumber_Leave);
            Fine.KeyPress += new KeyPressEventHandler(Fine_KeyPress);
            PopulateComboBoxes();
        }
        private void PopulateComboBoxes()
        {
            
            var status = new List<string>
            {
                "оплачен",
                "не оплачен"
            };       
            statuscomboBox.Items.Clear();
            statuscomboBox.Items.AddRange(status.ToArray());
        }
        private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я' || e.KeyChar == 'ё' || e.KeyChar == 'Ё'))
            {
                e.Handled = true;
            }
        }

        private void firstnametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я' || e.KeyChar == 'ё' || e.KeyChar == 'Ё'))
            {
                e.Handled = true;
            }
        }

        private void middlenametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только русские буквы и Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < 'А' || e.KeyChar > 'я' || e.KeyChar == 'ё' || e.KeyChar == 'Ё'))
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


        private void ProtocolNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, Backspace и "№" в начале строки
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '№' || ProtocolNumber.SelectionStart != 0))
            {
                e.Handled = true;
            }
        }


        private void ProtocolNumber_Leave(object sender, EventArgs e)
        {
            // Проверка, чтобы избежать лишнего пробела
            if (string.IsNullOrWhiteSpace(ProtocolNumber.Text) || ProtocolNumber.Text.Trim() == "№")
            {
                ProtocolNumber.Text = "№";
            }
            else if (!ProtocolNumber.Text.StartsWith("№"))
            {
                ProtocolNumber.Text = "№" + ProtocolNumber.Text.Trim();
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
            LoadViolations();
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
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Закрытие соединения с базой данных
            if (sqliteConn != null && sqliteConn.State == ConnectionState.Open)
            {
                sqliteConn.Close();
            }
            Application.Exit();
        }

        private void searchdriver_Click(object sender, EventArgs e)
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
            if (dateOfBirth != DateTime.MinValue)
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
                if (dateOfBirth != DateTime.MinValue)
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

        private void Obnovedriv_Click(object sender, EventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
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

        private void ObnoveAuto_Click(object sender, EventArgs e)
        {
            LoadAuto();
        }

        private void SearchViol_Click(object sender, EventArgs e)
        {
            string protocolNumber = ProtocolNumber.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value;
            string violation = Description.Text.Trim();
            string info = Info.Text.Trim();
            string licensePlate = Licenseplate.Text.Trim();
            string status = statuscomboBox.SelectedItem.ToString(); // Получаем выбранный статус штрафа

            string query = "SELECT * FROM Нарушения WHERE 1=1"; // Начало запроса

            if (!string.IsNullOrEmpty(protocolNumber))
                query += " AND НомерПротокола LIKE @protocolNumber";
            if (violationDate != DateTime.MinValue)
                query += " AND ДатаНарушения = @violationDate";
            if (!string.IsNullOrEmpty(violation))
                query += " AND Нарушение LIKE @violation";
            if (!string.IsNullOrEmpty(info))
                query += " AND Описание LIKE @info";
            if (!string.IsNullOrEmpty(licensePlate))
                query += " AND НомернойЗнак LIKE @licensePlate";
            if (!string.IsNullOrEmpty(status))
                query += " AND СтатусШтрафа LIKE @status";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (!string.IsNullOrEmpty(protocolNumber))
                    cmd.Parameters.AddWithValue("@protocolNumber", "%" + protocolNumber + "%");
                if (violationDate != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@violationDate", violationDate.ToString("yyyy-MM-dd"));
                if (!string.IsNullOrEmpty(violation))
                    cmd.Parameters.AddWithValue("@violation", "%" + violation + "%");
                if (!string.IsNullOrEmpty(info))
                    cmd.Parameters.AddWithValue("@info", "%" + info + "%");
                if (!string.IsNullOrEmpty(licensePlate))
                    cmd.Parameters.AddWithValue("@licensePlate", "%" + licensePlate + "%");
                if (!string.IsNullOrEmpty(status))
                    cmd.Parameters.AddWithValue("@status", "%" + status + "%");

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
        private void ObnoveViol_Click(object sender, EventArgs e)
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
                this.Hide(); // Скрыть текущую форму
                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Show(); // Показать текущую форму после закрытия form2
            }
            // Если пользователь выбрал "Нет", ничего не делаем, и форма останется открытой.
        }

        private void violationsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
