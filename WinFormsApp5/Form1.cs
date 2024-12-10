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
                    throw new FileNotFoundException("���� ������ �� ������� �� ���������� ����: " + dbPath);
                }

                sqliteConn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
                sqliteConn.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"������ ����������� � ���� ������: {ex.Message}");
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
            string selectDrivers = "SELECT * FROM ��������"; // SQL ������ ��� ������� ������
            using (var cmd = new SQLiteCommand(selectDrivers, sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    DataTable driversTable = new DataTable();
                    driversTable.Load(reader); // ��������� ������ �� ������� � DataTable
                    driversDataGridView.DataSource = driversTable; // ������������� �������� ������
                }
                if (driversDataGridView.Columns.Contains("Id"))
                {
                    driversDataGridView.Columns["Id"].Visible = false;
                }
            }

        }
        private void LoadAuto()
        {
            var AutoAdapter = new SQLiteDataAdapter("SELECT * FROM ����", sqliteConn);
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
            var PolicemanAdapter = new SQLiteDataAdapter("SELECT * FROM ������������", sqliteConn);
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
            var violationAdapter = new SQLiteDataAdapter("SELECT * FROM ���������", sqliteConn);
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
            var registrAdapter = new SQLiteDataAdapter("SELECT * FROM �����������", sqliteConn);
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
            var protAdapter = new SQLiteDataAdapter("SELECT * FROM ������������������", sqliteConn);
            var protTable = new DataTable();
            protAdapter.Fill(protTable);
            protocolsDataGridView.DataSource = protTable;
        }
        private bool IsDriverExists(string lastName, string firstName, string middleName, string passportNumber)
        {
            string selectQuery = "SELECT COUNT(*) FROM �������� WHERE ������� = @������� AND ��� = @��� AND �������� = @�������� AND ������������� = @�������������";
            using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@�������", lastName);
                cmd.Parameters.AddWithValue("@���", firstName);
                cmd.Parameters.AddWithValue("@��������", middleName);
                cmd.Parameters.AddWithValue("@�������������", passportNumber);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �������� ���������� � ����� ������
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
            DateTime dateOfBirth = driverDateOfBirthPicker.Value; // ���������� �������� �� DateTimePicker
            string certificateOfRegistration = certificateofregistrationtextbox.Text.Trim();

            string query = "SELECT * FROM �������� WHERE 1=1"; // ������ �������

            if (!string.IsNullOrEmpty(lastName))
                query += " AND ������� LIKE @lastName";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND ��� LIKE @firstName";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND �������� LIKE @middleName";
            if (dateOfBirth != DateTime.MinValue) // �������� �� ������������ ����
                query += " AND ������������ = @dateOfBirth";
            if (!string.IsNullOrEmpty(certificateOfRegistration))
                query += " AND ������������������������� LIKE @certificateOfRegistration";

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
                    var drivers = new DataTable(); // ������� ��������� ������� ��� ������
                    drivers.Load(reader); // ��������� ������ �� ������� � DataTable

                    if (drivers.Rows.Count == 0)
                    {
                        MessageBox.Show("��� ����� ���������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // �������� DataGridView ��� ���������
                    }
                    else
                    {
                        driversDataGridView.DataSource = drivers; // ��������� DataGridView ������ �������
                                                                  // �������� ������ ������ � �������, ���� ��� ����������
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

            // ����������� ����� � ������ ���
            string fullName = string.IsNullOrEmpty(middleName) ?
                $"{lastName} {firstName}" :
                $"{lastName} {firstName.Substring(0, 1)}. {middleName.Substring(0, 1)}.";

            // ��������� �� ������������
            if (IsDriverExists(lastName, firstName, middleName, passportNumber))
            {
                MessageBox.Show("����� �������� ��� ����������.");
                return;
            }

            // SQL ��� ������� ������
            string insertDriver = "INSERT INTO �������� (���������, �������, ���, ��������, �������������, �������, �����, �������������������������, �������������������������, ������������) " +
                                  "VALUES (@���������, @�������, @���, @��������, @�������������, @�������, @�����, @�������������������������, @�������������������������, @������������)";

            try
            {
                using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
                {
                    // ���������� ����������
                    cmd.Parameters.AddWithValue("@���������", fullName);
                    cmd.Parameters.AddWithValue("@�������", lastName);
                    cmd.Parameters.AddWithValue("@���", firstName);
                    cmd.Parameters.AddWithValue("@��������", middleName);
                    cmd.Parameters.AddWithValue("@�������������", passportNumber);
                    cmd.Parameters.AddWithValue("@�������", phone);
                    cmd.Parameters.AddWithValue("@�����", address);
                    cmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                    cmd.Parameters.AddWithValue("@�������������������������", driverLicense);
                    cmd.Parameters.AddWithValue("@������������", dateOfBirth);

                    cmd.ExecuteNonQuery(); // ��������� ������
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ��������: {ex.Message}");
            }

            LoadDrivers(); // ������������� ������
        }

        private void Editdriver_Click_1(object sender, EventArgs e)
        {
            var selectedRows = driversDataGridView.SelectedRows; // ����� ������������, ��� ��� ��� DataGridView ��� ���������
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int driverId = Convert.ToInt32(row.Cells["�������������"].Value); // �������� ������������� ��������

                string updateDriver = "UPDATE �������� SET " +
                                      "������� = COALESCE(NULLIF(@�������, ''), �������), " +
                                      "��� = COALESCE(NULLIF(@���, ''), ���), " +
                                      "�������� = COALESCE(NULLIF(@��������, ''), ��������), " +
                                      "������������� = COALESCE(NULLIF(@�������������, ''), �������������), " +
                                      "������� = COALESCE(NULLIF(@�������, ''), �������), " +
                                      "����� = COALESCE(NULLIF(@�����, ''), �����), " +
                                      "������������������������� = COALESCE(NULLIF(@�������������������������, ''), �������������������������), " +
                                      "������������������������� = COALESCE(NULLIF(@�������������������������, ''), �������������������������), " +
                                      "������������ = COALESCE(NULLIF(@������������, ''), ������������) " +
                                      "WHERE ������������� = @�������������";

                using (var cmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@�������������", driverId);
                    cmd.Parameters.AddWithValue("@�������", SurnameTextBox.Text);
                    cmd.Parameters.AddWithValue("@���", firstnametextbox.Text);
                    cmd.Parameters.AddWithValue("@��������", middlenametextbox.Text);
                    cmd.Parameters.AddWithValue("@�������������", passportnumbertextbox.Text);
                    cmd.Parameters.AddWithValue("@�������", phonetextbox.Text);
                    cmd.Parameters.AddWithValue("@�����", addresstextbox.Text);
                    cmd.Parameters.AddWithValue("@�������������������������", certificateofregistrationtextbox.Text);
                    cmd.Parameters.AddWithValue("@�������������������������", driverLicenseTextBox.Text);
                    cmd.Parameters.AddWithValue("@������������", driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery(); // ��������� ����������
                }
            }

            LoadDrivers(); // ������������� ������
        }

        private void Deletedriver_Click_1(object sender, EventArgs e)
        {
            var selectedRows = driversDataGridView.SelectedRows; // �����������, ��� ��� ��� DataGridView ��� ���������
            if (selectedRows.Count == 0) return;

            var idsToDelete = new List<int>();

            foreach (DataGridViewRow row in selectedRows)
            {
                idsToDelete.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }

            DialogResult dialogResult = MessageBox.Show("�� �������, ��� ������ ������� ��������� ������?", "�������������", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteDrivers = $"DELETE FROM �������� WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteDrivers, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadData(); // ������������� ������
            }
        }

        private void driversDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ���������, ��� �� �������� �� ������
            {
                DataGridViewRow row = this.driversDataGridView.Rows[e.RowIndex];

                // ����� ������ ������� � �������� ����� � ������� �������
                var driverDetailsForm = new DriverDetailsForm(
                    row.Cells["�������"].Value.ToString(),
                    row.Cells["���"].Value.ToString(),
                    row.Cells["��������"].Value.ToString(),
                    row.Cells["�������������"].Value.ToString(),
                    row.Cells["�������"].Value.ToString(),
                    row.Cells["�����"].Value.ToString(),
                    row.Cells["�������������������������"].Value.ToString(),
                    row.Cells["�������������������������"].Value.ToString(),
                    Convert.ToDateTime(row.Cells["������������"].Value)
                );

                driverDetailsForm.Show();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string licensePlate = PlatetextBox.Text.Trim();
            string certificateOfRegistration = STStextBox.Text.Trim();

            string searchQuery = "SELECT a.�������������������������, a.�����, a.������, a.������������, a.���, a.�������� " +
                                 "FROM ���� a WHERE 1=1"; // �������� � ������� "1=1"

            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND a.������������ LIKE '%' || @������������ || '%'";
            }
            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND a.������������������������� LIKE '%' || @������������������������� || '%'";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@������������", licensePlate);
                }
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                }

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    AutoDataGridView.DataSource = table; // ��������� DataGridView
                }
            }
        }

        private void AddCar_Click_1(object sender, EventArgs e)
        {
            // �������� ������ � ����
            string certificateOfRegistration = STStextBox.Text.Trim();
            string make = MakeTextBox.Text.Trim();
            string model = ModeltextBox.Text.Trim();
            string licensePlate = PlatetextBox.Text.Trim();
            int year;

            // ��������, ��� ��� ������ ���������
            if (!int.TryParse(yeartextBox.Text, out year))
            {
                MessageBox.Show("����������, ������� ���������� ���.");
                return;
            }

            string insurance = StrahovkaTextBox.Text.Trim();

            try
            {
                // �������� ������ ��� ��������� �� ������������� � �����������
                string ownerQuery = "SELECT ��������� FROM �������� WHERE ������������������������� = @�������������������������";
                string fullName = string.Empty; // ���������� ��� �������� ������� ����� ���������

                using (var ownerCmd = new SQLiteCommand(ownerQuery, sqliteConn))
                {
                    ownerCmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                    object result = ownerCmd.ExecuteScalar();

                    if (result != null)
                    {
                        fullName = result.ToString(); // �������� ������ ��� ���������
                    }
                }

                // ���������, ��� �������� ������
                if (!string.IsNullOrEmpty(fullName))
                {
                    // SQL ��� ������� ������ �� ����������
                    string insertCarQuery = "INSERT INTO ���� (�������������������������, �����, ������, ������������, ���, ��������, �����������) " +
                                             "VALUES (@�������������������������, @�����, @������, @������������, @���, @��������, @�����������)";

                    using (var insertCmd = new SQLiteCommand(insertCarQuery, sqliteConn))
                    {
                        insertCmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                        insertCmd.Parameters.AddWithValue("@�����", make);
                        insertCmd.Parameters.AddWithValue("@������", model);
                        insertCmd.Parameters.AddWithValue("@������������", licensePlate);
                        insertCmd.Parameters.AddWithValue("@���", year);
                        insertCmd.Parameters.AddWithValue("@��������", fullName); // ���������� ��������� ������ ��� ���������
                        insertCmd.Parameters.AddWithValue("@�����������", insurance);

                        insertCmd.ExecuteNonQuery(); // ��������� ������
                    }

                    MessageBox.Show("���������� ������� ��������!");
                }
                else
                {
                    MessageBox.Show("�������� � ��������� �������������� � ����������� �� ������.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ����������: {ex.Message}");
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

                // ���������, ��� ��� ����� ������������� � int
                if (!int.TryParse(yeartextBox.Text, out updatedYear))
                {
                    MessageBox.Show("����������, ������� ���������� ���.");
                    return;
                }

                int carId = Convert.ToInt32(row.Cells["Id"].Value); // �������� ������������� ����������

                string updateCarQuery = "UPDATE ���� SET " +
                                         "������������������������� = COALESCE(NULLIF(@�������������������������, ''), �������������������������), " +
                                         "����� = COALESCE(NULLIF(@�����, ''), �����), " +
                                         "������ = COALESCE(NULLIF(@������, ''), ������), " +
                                         "������������ = COALESCE(NULLIF(@������������, ''), ������������), " +
                                         "��� = COALESCE(NULLIF(@���, -1), ���), " +
                                         "����������� = COALESCE(NULLIF(@�����������, ''), �����������) " +
                                         "WHERE Id = @Id"; // �������� �� ������������� Id

                using (var cmd = new SQLiteCommand(updateCarQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", carId);
                    cmd.Parameters.AddWithValue("@�������������������������", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@�����", updatedMake);
                    cmd.Parameters.AddWithValue("@������", updatedModel);
                    cmd.Parameters.AddWithValue("@������������", updatedLicensePlate);
                    cmd.Parameters.AddWithValue("@���", updatedYear);
                    cmd.Parameters.AddWithValue("@�����������", updatedInsurance);

                    cmd.ExecuteNonQuery(); // ��������� ����������
                }
            }

            LoadAuto(); // ������������� ������
        }

        private void DeleteCar_Click_1(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var licensePlatesToDelete = selectedRows.Cast<DataGridViewRow>().Select(row => row.Cells["������������"].Value.ToString()).ToList();

            DialogResult dialogResult = MessageBox.Show("�� �������, ��� ������ ������� ��������� ����������?", "�������������", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteCarQuery = $"DELETE FROM ���� WHERE ������������ IN ({string.Join(",", licensePlatesToDelete.Select(lp => $"'{lp}'"))})";
                using (var cmd = new SQLiteCommand(deleteCarQuery, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadAuto(); // ������������� ������
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
            if (e.RowIndex >= 0) // ���������, ��� �� �������� �� ������
            {
                DataGridViewRow row = this.AutoDataGridView.Rows[e.RowIndex];

                // �������� ������ ��� �������� ����� ������� ����������
                string certificateOfRegistration = row.Cells["�������������������������"].Value.ToString();
                string make = row.Cells["�����"].Value.ToString();
                string model = row.Cells["������"].Value.ToString();
                string licensePlate = row.Cells["������������"].Value.ToString();
                int year = Convert.ToInt32(row.Cells["���"].Value);
                string ownerFullName = row.Cells["��������"].Value.ToString(); // �������� �������� �� ��������

                // �������� � �������� ����� � ������� �������
                var autoDetailsForm = new AutoDetailsForm(certificateOfRegistration, make, model, licensePlate, year, ownerFullName);
                autoDetailsForm.Show();
            }
        }

        private void SearchPolice_Click(object sender, EventArgs e)
        {
            string lastName = lastNameTextBox.Text.Trim();
            string rank = rankTextBox.Text.Trim();

            string query = "SELECT * FROM ������������ WHERE 1=1"; // ������ �������

            if (!string.IsNullOrEmpty(lastName))
                query += " AND ������� LIKE @lastName";
            if (!string.IsNullOrEmpty(rank))
                query += " AND ������ = @rank";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (!string.IsNullOrEmpty(lastName))
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                if (!string.IsNullOrEmpty(rank))
                    cmd.Parameters.AddWithValue("@rank", rank);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    var policemen = new DataTable(); // ������� ��������� ������� ��� ������
                    policemen.Load(reader); // ��������� ������ �� ������� � DataTable

                    if (policemen.Rows.Count == 0)
                    {
                        MessageBox.Show("��� ����� �����������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // �������� DataGridView ��� ���������
                    }
                    else
                    {
                        PolicemanDataGridView.DataSource = policemen; // ��������� DataGridView ������ �������
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
            string issuedProtocols = issuedProtocolsTextBox.Text.Trim(); // �������� IssuedProtocols

            // ����������� ����� � ������ ���
            string fullName = string.IsNullOrEmpty(middleName) ?
                $"{lastName} {firstName}" :
                $"{lastName} {firstName.Substring(0, 1)}. {middleName.Substring(0, 1)}.";

            // SQL ��� ������� ������
            string insertPolice = "INSERT INTO ������������ (���������, �������, ���, ��������, " +
                                  "�������������, �������, �����, ������������, ������, ���������) " +
                                  "VALUES (@fullName, @lastName, @firstName, @middleName, " +
                                  "@passportNumber, @phone, @address, @dateOfBirth, @rank, @position)";

            try
            {
                using (var cmd = new SQLiteCommand(insertPolice, sqliteConn))
                {
                    // ���������� ����������
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
                    cmd.ExecuteNonQuery(); // ��������� ������
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ����������: {ex.Message}");
            }

            LoadPoliceman(); // ������������� ������
        }

        private void EditPolice_Click_1(object sender, EventArgs e)
        {
            var selectedRows = PolicemanDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int policemanId = Convert.ToInt32(row.Cells["Id"].Value);

                string updatePolice = "UPDATE ������������ SET " +
                                      "������� = COALESCE(NULLIF(@lastName, ''), �������), " +
                                      "��� = COALESCE(NULLIF(@firstName, ''), ���), " +
                                      "�������� = COALESCE(NULLIF(@middleName, ''), ��������), " +
                                      "������������� = COALESCE(NULLIF(@passportNumber, ''), �������������), " +
                                      "������� = COALESCE(NULLIF(@phone, ''), �������), " +
                                      "����� = COALESCE(NULLIF(@address, ''), �����), " +
                                      "������������ = COALESCE(NULLIF(@dateOfBirth, ''), ������������), " +
                                      "������ = COALESCE(NULLIF(@rank, ''), ������), " +
                                      "��������� = COALESCE(NULLIF(@position, ''), ���������) " +
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

            LoadPoliceman(); // ������������� ������
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

            DialogResult dialogResult = MessageBox.Show("�� �������, ��� ������ ������� ��������� ������?", "�������������", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deletePolice = $"DELETE FROM ������������ WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deletePolice, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadPoliceman(); // ������������� ������
            }
        }

        private void ObnovePolice_Click_1(object sender, EventArgs e)
        {
            LoadPoliceman();
        }

        private void PolicemanDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ��������� ��������� ����������

            // �������� ��������� ������
            DataGridViewRow selectedRow = PolicemanDataGridView.Rows[e.RowIndex];

            // ��������� ������ �� �����
            string lastName = selectedRow.Cells["�������"].Value.ToString();
            string firstName = selectedRow.Cells["���"].Value.ToString();
            string middleName = selectedRow.Cells["��������"].Value.ToString();
            string passportNumber = selectedRow.Cells["�������������"].Value.ToString();
            string phone = selectedRow.Cells["�������"].Value.ToString();
            string address = selectedRow.Cells["�����"].Value.ToString();
            DateTime dateOfBirth = Convert.ToDateTime(selectedRow.Cells["������������"].Value);
            string rank = selectedRow.Cells["������"].Value.ToString();
            string position = selectedRow.Cells["���������"].Value.ToString();

            // ������� ��������� PolicemanForm � �������� ������
            PolicemanForm policemanForm = new PolicemanForm(lastName, firstName, middleName, passportNumber, phone, address, dateOfBirth, rank, position);

            // ��������� ����� ��� ���������
            policemanForm.ShowDialog();
        }

        private void SearchViol_Click_1(object sender, EventArgs e)
        {
            string licensePlate = Licenseplate.Text.Trim();
            DateTime violationDate = VioldateTimePicker.Value; // ���������� �������� �� DateTimePicker

            string query = "SELECT * FROM ��������� WHERE 1=1"; // ������ �������

            if (!string.IsNullOrEmpty(licensePlate))
                query += " AND ������������ LIKE @licensePlate";
            if (violationDate != DateTime.MinValue) // �������� �� ������������ ����
                query += " AND ������������� = @violationDate";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (!string.IsNullOrEmpty(licensePlate))
                    cmd.Parameters.AddWithValue("@licensePlate", licensePlate);
                if (violationDate != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@violationDate", violationDate.ToString("yyyy-MM-dd"));

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    var violations = new DataTable(); // ������� ��������� ������� ��� ������
                    violations.Load(reader); // ��������� ������ �� ������� � DataTable

                    if (violations.Rows.Count == 0)
                    {
                        MessageBox.Show("��� ����� ���������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        violationsDataGridView.DataSource = violations; // ��������� DataGridView ������ �������
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

            // SQL ��� ������� ������
            string insertViolation = "INSERT INTO ��������� (��������������, �������������, ��������, �����, ��������������������, ������������, ��������) " +
                                     "VALUES (@ProtocolNumber, @ViolationDate, @Description, @Fine, @ReferenceInfo, @LicensePlate, " +
                                     "(SELECT ��������� FROM �������� WHERE ��������� = (SELECT �������� FROM ���� WHERE ������������ = @LicensePlate)))";

            try
            {
                using (var cmd = new SQLiteCommand(insertViolation, sqliteConn))
                {
                    // ���������� ����������
                    cmd.Parameters.AddWithValue("@ProtocolNumber", ProtocolNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@ViolationDate", violationDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Fine", fine);
                    cmd.Parameters.AddWithValue("@ReferenceInfo", referenceInfo);
                    cmd.Parameters.AddWithValue("@LicensePlate", licensePlate);

                    cmd.ExecuteNonQuery(); // ��������� ������
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ���������: {ex.Message}");
            }

            LoadViolations(); // ������������� ������
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var selectedRows = violationsDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int violationId = Convert.ToInt32(row.Cells["Id"].Value);

                string updateViolation = "UPDATE ��������� SET " +
                                         "������������� = COALESCE(NULLIF(@ViolationDate, ''), �������������), " +
                                         "�������� = COALESCE(NULLIF(@Description, ''), ��������), " +
                                         "����� = COALESCE(NULLIF(@Fine, ''), �����), " +
                                         "�������������������� = COALESCE(NULLIF(@ReferenceInfo, ''), ��������������������), " +
                                         "������������ = COALESCE(NULLIF(@LicensePlate, ''), ������������) " +
                                         "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateViolation, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", violationId);
                    cmd.Parameters.AddWithValue("@ViolationDate", VioldateTimePicker.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Description", Description.Text);
                    cmd.Parameters.AddWithValue("@Fine", Convert.ToDecimal(Fine.Text));
                    cmd.Parameters.AddWithValue("@ReferenceInfo", Info.Text);
                    cmd.Parameters.AddWithValue("@LicensePlate", Licenseplate.Text);

                    cmd.ExecuteNonQuery(); // ��������� ����������
                }
            }

            LoadViolations(); // ������������� ������
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

            DialogResult dialogResult = MessageBox.Show("�� �������, ��� ������ ������� ��������� ������?", "�������������", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteViolations = $"DELETE FROM ��������� WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteViolations, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadViolations(); // ������������� ������
            }
        }

        private void ObnoveViol_Click_1(object sender, EventArgs e)
        {
            LoadViolations();
        }

        private void violationsDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ��������� ��������� ����������

            DataGridViewRow selectedRow = violationsDataGridView.Rows[e.RowIndex];

            string protocolNumber = selectedRow.Cells["��������������"].Value.ToString();
            string description = selectedRow.Cells["��������"].Value.ToString();
            string info = selectedRow.Cells["��������������������"].Value.ToString();
            string licensePlate = selectedRow.Cells["������������"].Value.ToString();
            decimal fine = Convert.ToDecimal(selectedRow.Cells["�����"].Value);
            DateTime violateDate = Convert.ToDateTime(selectedRow.Cells["�������������"].Value);
            string driverName = selectedRow.Cells["��������"].Value.ToString();

            ViolationsForm violationForm = new ViolationsForm(protocolNumber, description, licensePlate, info, fine, violateDate, driverName);

            violationForm.ShowDialog();
        }

        private void searchRegistr_Click(object sender, EventArgs e)
        {
            string licensePlate = NumberTextBox.Text.Trim();
            string certificateOfRegistration = STStextBox5.Text.Trim();

            // �������� � �������� �������
            string searchQuery = "SELECT r.��������, r.������������, r.�������������������������, r.��������������� " +
                     "FROM ����������� r JOIN �������� d ON r.�������� = d.��������� " +
                     "WHERE 1=1"; // ������� ������ ������� (��� �������� ���������� ������ �������)

            // ��������� ������� ������
            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND r.������������ LIKE '%' || @������������ || '%'";
            }
            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND r.������������������������� LIKE '%' || @������������������������� || '%'";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                // ��������� ���������, ���� ��� ���� �������
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@������������", licensePlate);
                }
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                }

                // ��������� ������ � ��������� DataGridView
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var resultTable = new DataTable();
                    adapter.Fill(resultTable);

                    // ��������� ������� �����������
                    if (resultTable.Rows.Count > 0)
                    {
                        RegistrdataGridView.DataSource = resultTable;
                        RegistrdataGridView.Rows[0].Selected = true; // �������� ������ ������
                    }
                    else
                    {
                        // ���� ��� �����������, ����� ��������� ��������� ������������
                        RegistrdataGridView.DataSource = null; // ������� DataGridView
                        MessageBox.Show("��� ����������� ��� ������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string ownerName = GetOwnerByCertificate(certificateOfRegistration); // ������ ��� ��������� �� ���

                if (string.IsNullOrEmpty(ownerName))
                {
                    MessageBox.Show("�������� � ��������� ������� ������������� �� ������.");
                    return;
                }

                string insertQuery = "INSERT INTO ����������� (��������, ������������, �������������������������, ����������, ���������������) " +
                                     "VALUES (@��������, @������������, @�������������������������, @����������, @���������������)";

                using (var cmd = new SQLiteCommand(insertQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@��������", ownerName);
                    cmd.Parameters.AddWithValue("@������������", licensePlate);
                    cmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                    cmd.Parameters.AddWithValue("@����������", insurance);
                    cmd.Parameters.AddWithValue("@���������������", registrationDate);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("����������� ������� ���������!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� �����������: {ex.Message}");
            }
            LoadRegistr();
        }

        // ����� ��� ��������� ����� ��������� �� ������ �������������
        private string GetOwnerByCertificate(string certificate)
        {
            string ownerName = string.Empty;

            string query = "SELECT �������� FROM ���� WHERE ������������������������� = @�������������";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@�������������", certificate);
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
                string ownerName = row.Cells["��������"].Value.ToString();
                string updatedCertificateOfRegistration = STStextBox5.Text;
                string updatedLicensePlate = NumberTextBox.Text;
                DateTime updatedRegistrationDate = dateTimePicker1.Value; // ���� �����������

                // �������� �������� �� �������� ������� ����� WHERE
                string updateCarQuery = "UPDATE ����������� SET " +
                                         "������������������������� = COALESCE(NULLIF(@�������������������������, ''), �������������������������), " +
                                         "������������ = COALESCE(NULLIF(@������������, ''), ������������), " +
                                         "��������������� = COALESCE(NULLIF(@���������������, '0001-01-01'), ���������������) " +
                                         "WHERE �������� = @��������";

                using (var cmd = new SQLiteCommand(updateCarQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@��������", ownerName);
                    cmd.Parameters.AddWithValue("@�������������������������", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@������������", updatedLicensePlate);
                    cmd.Parameters.AddWithValue("@���������������", updatedRegistrationDate.ToString("yyyy-MM-dd")); // �������������� ����

                    cmd.ExecuteNonQuery(); // ��������� ����������
                }
            }

            LoadRegistr(); // ������������� ������
        }

        private void ObnoveRegistr_Click(object sender, EventArgs e)
        {
            LoadRegistr();
        }

        private void RegistrdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ���������, ��� �� �������� �� ������
            {
                DataGridViewRow row = this.RegistrdataGridView.Rows[e.RowIndex];

                // �������� ������ ��� �������� ����� �������
                string licensePlate = row.Cells["������������"].Value.ToString();
                string certificateOfRegistration = row.Cells["�������������������������"].Value.ToString();
                DateTime registrationDate = Convert.ToDateTime(row.Cells["���������������"].Value);

                // ���������� ������ ���� ���������� ����� ��������������
                string strahovka = row.Cells["����������"].Value?.ToString() ?? string.Empty; // ��������������, ��� ���� ������� ����������
                string driverName = row.Cells["��������"].Value?.ToString() ?? string.Empty; // ��������������, ��� ���� ������� ��������

                // �������� � �������� ����� � ������� �������
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

            DialogResult dialogResult = MessageBox.Show("�� �������, ��� ������ ������� ��������� ������?", "�������������", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteViolations = $"DELETE FROM ����������� WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteViolations, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadRegistr(); // ������������� ������
            }
        }

        private void SearchProtocol_Click(object sender, EventArgs e)
        {
            int employeeGAIId;
            int protocolNumber;

            if (!int.TryParse(GAIidTextBox.Text.Trim(), out employeeGAIId))
            {
                MessageBox.Show("������� ���������� id ���������� ���.");
                return;
            }

            if (!int.TryParse(ProtocoltextBox.Text.Trim(), out protocolNumber))
            {
                MessageBox.Show("������� ���������� ����� ���������.");
                return;
            }

            string searchQuery = "SELECT sp.*, (SELECT ��������� FROM ������������ WHERE Id = sp.������������_Id) AS ��������� " +
                                 "FROM ������������������ sp " +
                                 "WHERE sp.������������_Id = @������������_Id AND sp.�������������� = @��������������";

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@������������_Id", employeeGAIId);
                cmd.Parameters.AddWithValue("@��������������", protocolNumber);

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
                        MessageBox.Show("��� ����������� ��� ������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void AddProtocol_Click(object sender, EventArgs e)
        {
            int employeeGAIId;
            int protocolNumber;

            // �������� ������������ id ���������� ���
            if (!int.TryParse(GAIidTextBox.Text, out employeeGAIId))
            {
                MessageBox.Show("������� ���������� id ���������� ���.");
                return;
            }

            // �������� ������������ ������ ���������
            if (!int.TryParse(ProtocoltextBox.Text, out protocolNumber))
            {
                MessageBox.Show("������� ���������� ����� ���������.");
                return;
            }

            // ��������, ���������� �� �������� � ������� ���������
            string checkQuery = "SELECT COUNT(*) FROM ��������� WHERE �������������� = @��������������";
            using (var checkCmd = new SQLiteCommand(checkQuery, sqliteConn))
            {
                checkCmd.Parameters.AddWithValue("@��������������", protocolNumber);
                var count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("�������� � ����� ������� �� ������ � ������� ���������.");
                    return;
                }
            }

            // �������� ������ ��� ���������� ���
            string fullNameQuery = "SELECT ��������� FROM ������������ WHERE Id = @������������_Id";
            string fullName = null; // ������������� ���������� fullName

            using (var fullNameCmd = new SQLiteCommand(fullNameQuery, sqliteConn))
            {
                fullNameCmd.Parameters.AddWithValue("@������������_Id", employeeGAIId);
                object result = fullNameCmd.ExecuteScalar();

                // ��������, ������ �� ��������� �� ID
                if (result != null)
                {
                    fullName = result.ToString();
                }
                else
                {
                    MessageBox.Show("��������� ��� � ����� id �� ������.");
                    return;
                }
            }

            // ������ �� ���������� ������ ���������
            string insertQuery = "INSERT INTO ������������������ (������������_Id, ��������������, ���������) VALUES (@������������_Id, @��������������, @���������)";

            using (var cmd = new SQLiteCommand(insertQuery, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@������������_Id", employeeGAIId);
                cmd.Parameters.AddWithValue("@��������������", protocolNumber);
                cmd.Parameters.AddWithValue("@���������", fullName);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("�������� ������� ��������!");
            LoadProtocol(); // ����� ��� ������������ ������ � DataGridView
        }


        private void EditProtocol_Click(object sender, EventArgs e)
        {
            var selectedRows = protocolsDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ��������������.");
                return;
            }

            int newEmployeeGAIId;
            if (!int.TryParse(GAIidTextBox.Text.Trim(), out newEmployeeGAIId))
            {
                MessageBox.Show("������� ���������� id ���������� ���.");
                return;
            }

            int newProtocolNumber;
            if (!int.TryParse(ProtocoltextBox.Text.Trim(), out newProtocolNumber))
            {
                MessageBox.Show("������� ���������� ����� ����� ���������.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int currentEmployeeGAIId = Convert.ToInt32(row.Cells["������������_Id"].Value);
                int currentProtocolNumber = Convert.ToInt32(row.Cells["��������������"].Value);

                // �������� �� ������������� ����������
                string checkQuery = "SELECT COUNT(*) FROM ������������������ WHERE ������������_Id = @New������������_Id AND �������������� = @New��������������";
                using (var checkCmd = new SQLiteCommand(checkQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@New������������_Id", newEmployeeGAIId);
                    checkCmd.Parameters.AddWithValue("@New��������������", newProtocolNumber);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("������ � ����� id ���������� ��� � ������� ��������� ��� ����������.");
                        return;
                    }
                }

                // �������� ����� ������ ���
                string newFullNameQuery = "SELECT ��������� FROM ������������ WHERE Id = @New������������_Id";
                string newFullName;
                using (var fullNameCmd = new SQLiteCommand(newFullNameQuery, sqliteConn))
                {
                    fullNameCmd.Parameters.AddWithValue("@New������������_Id", newEmployeeGAIId);
                    newFullName = (string)fullNameCmd.ExecuteScalar();
                }

                // ���������� ������
                string updateQuery = "UPDATE ������������������ SET ������������_Id = @New������������_Id, �������������� = @New��������������, ��������� = @��������� " +
                                     "WHERE ������������_Id = @������������_Id AND �������������� = @��������������";

                using (var cmd = new SQLiteCommand(updateQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@������������_Id", currentEmployeeGAIId);
                    cmd.Parameters.AddWithValue("@��������������", currentProtocolNumber);
                    cmd.Parameters.AddWithValue("@New������������_Id", newEmployeeGAIId);
                    cmd.Parameters.AddWithValue("@New��������������", newProtocolNumber);
                    cmd.Parameters.AddWithValue("@���������", newFullName); // ��������� ������ ���
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("�������� ������� �������!");
            LoadProtocol();
        }

        private void DeliteProtocol_Click(object sender, EventArgs e)
        {
            var selectedRows = protocolsDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var protocolsToDelete = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                int employeeGAIId = Convert.ToInt32(row.Cells["������������_Id"].Value);
                int protocolNumber = Convert.ToInt32(row.Cells["��������������"].Value);
                protocolsToDelete.Add($"({employeeGAIId}, {protocolNumber})");
            }

            DialogResult dialogResult = MessageBox.Show("�� �������, ��� ������ ������� ��������� ������?", "�������������", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteQuery = $"DELETE FROM ������������������ WHERE (������������_Id, ��������������) IN ({string.Join(",", protocolsToDelete)})";

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

            //    int protocolNumber = Convert.ToInt32(row.Cells["��������������"].Value);
            //    ������� � ���������� ����� � ������� ���������, ���� ���������
            //    var protocolDetails = new protocolsDetailsForm(protocolNumber);
            //    protocolDetails.Show();
            //}
        }
    }
}
