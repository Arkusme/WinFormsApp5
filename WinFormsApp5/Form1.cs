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
            string selectDrivers = "SELECT * FROM Drivers"; // SQL ������ ��� ������� ������
            using (var cmd = new SQLiteCommand(selectDrivers, sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    DataTable driversTable = new DataTable();
                    driversTable.Load(reader); // ��������� ������ �� ������� � DataTable
                    driversDataGridView.DataSource = driversTable; // ������������� �������� ������
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
            // �������� ��� ������������ ID
            var ids = new List<int>();
            string selectQuery = "SELECT Id FROM Drivers";
            using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0)); // ��������������, ��� Id - ��� ������ �������
                }
            }

            // ����� ������ ��������� ID
            for (int i = 1; i <= ids.Count + 1; i++)
            {
                if (!ids.Contains(i))
                {
                    return i;
                }
            }

            return ids.Count + 1; // ���� ��� ID ������, ������� ���������
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
            public int OwnerId { get; set; } // ���������, ��� ��� ID ���������
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lastName = SurnameTextBox.Text.Trim();
            string firstName = firstnametextbox.Text.Trim();
            string middleName = middlenametextbox.Text.Trim();
            DateTime dateOfBirth = driverDateOfBirthPicker.Value; // ���������� �������� �� DateTimePicker
            string certificateOfRegistration = certificateofregistrationtextbox.Text.Trim();

            string query = "SELECT * FROM Drivers WHERE 1=1"; // ������ �������

            if (!string.IsNullOrEmpty(lastName))
                query += " AND LastName LIKE @lastName";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND FirstName LIKE @firstName";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND MiddleName LIKE @middleName";
            if (dateOfBirth != DateTime.MinValue) // �������� �� ������������ ����
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
        private void button2_Click(object sender, EventArgs e)
        {
            string searchName = searchEmployeeTextBox.Text;

            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("������� ��� ��� ������.");
                return;
            }

            var driverAdapter = new SQLiteDataAdapter("SELECT * FROM Employees WHERE Name LIKE @Name", sqliteConn);
            driverAdapter.SelectCommand.Parameters.AddWithValue("@Name", "%" + searchName + "%");
            var driverTable = new DataTable();
            driverAdapter.Fill(driverTable);
            PolicemanDataGridView.DataSource = driverTable;
        }

        private void button3_Click(object sender, EventArgs e)//����������
        {
            string licensePlate = PlatetextBox.Text.Trim();
            string certificateOfRegistration = STStextBox.Text.Trim();

            string searchQuery = "SELECT a.CertificateOfRegistration, a.Make, a.Model, a.LicensePlate, a.Year, d.FullName AS OwnerName " +
                                 "FROM Auto a JOIN Drivers d ON a.OwnerName = d.FullName " +
                                 "WHERE 1=1"; // �������� � ������� "1=1"

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
                    AutoDataGridView.DataSource = table; // ��������� DataGridView
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
            string insertDriver = "INSERT INTO Drivers (FullName, LastName, FirstName, MiddleName, PassportNumber, Phone, Address, CertificateOfRegistration, DriverLicense, DateOfBirth) " +
                                  "VALUES (@FullName, @LastName, @FirstName, @MiddleName, @PassportNumber, @Phone, @Address, @CertificateOfRegistration, @DriverLicense, @DateOfBirth)";

            try
            {
                using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
                {
                    // ���������� ����������
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

                    cmd.ExecuteNonQuery(); // ��������� ������
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ��������: {ex.Message}");
            }

            LoadDrivers(); // ������������� ������
        }

        private void Editdriver_Click(object sender, EventArgs e)
        {
            var selectedRows = driversDataGridView.SelectedRows; // ����� ������������, ��� ��� ��� DataGridView ��� ���������
            if (selectedRows.Count == 0) return;

            foreach (DataGridViewRow row in selectedRows)
            {
                int driverId = Convert.ToInt32(row.Cells["Id"].Value); // �������� Id ��������

                string updateDriver = "UPDATE Drivers SET " +
                                      "LastName = COALESCE(NULLIF(@LastName, ''), LastName), " +
                                      "FirstName = COALESCE(NULLIF(@FirstName, ''), FirstName), " +
                                      "MiddleName = COALESCE(NULLIF(@MiddleName, ''), MiddleName), " +
                                      "PassportNumber = COALESCE(NULLIF(@PassportNumber, ''), PassportNumber), " +
                                      "Phone = COALESCE(NULLIF(@Phone, ''), Phone), " +
                                      "Address = COALESCE(NULLIF(@Address, ''), Address), " +
                                      "CertificateOfRegistration = COALESCE(NULLIF(@CertificateOfRegistration, ''), CertificateOfRegistration), " +
                                      "DriverLicense = COALESCE(NULLIF(@DriverLicense, ''), DriverLicense), " + // �������� �� DriverLicense
                                      "DateOfBirth = COALESCE(NULLIF(@DateOfBirth, ''), DateOfBirth) " +
                                      "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", driverId);
                    cmd.Parameters.AddWithValue("@LastName", SurnameTextBox.Text); // �������� �� LastName
                    cmd.Parameters.AddWithValue("@FirstName", firstnametextbox.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", middlenametextbox.Text);
                    cmd.Parameters.AddWithValue("@PassportNumber", passportnumbertextbox.Text);
                    cmd.Parameters.AddWithValue("@Phone", phonetextbox.Text);
                    cmd.Parameters.AddWithValue("@Address", addresstextbox.Text);
                    cmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateofregistrationtextbox.Text);
                    cmd.Parameters.AddWithValue("@DriverLicense", driverLicenseTextBox.Text); // �������� �� DriverLicense
                    cmd.Parameters.AddWithValue("@DateOfBirth", driverDateOfBirthPicker.Value);

                    cmd.ExecuteNonQuery(); // ��������� ����������
                }
            }

            LoadData(); // ������������� ������
        }
        private void Deletedriver_Click(object sender, EventArgs e)
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
                string deleteDrivers = $"DELETE FROM Drivers WHERE Id IN ({string.Join(",", idsToDelete)})";
                using (var cmd = new SQLiteCommand(deleteDrivers, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadData(); // ������������� ������
            }
        }

        private void driversDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ���������, ��� �� �������� �� ������
            {
                DataGridViewRow row = this.driversDataGridView.Rows[e.RowIndex];

                // ����� ������ ������� � �������� ����� � ������� �������
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
            string certificateOfRegistration = STStextBox.Text; // ������
            string make = MakeTextBox.Text; // ������
            string model = ModeltextBox.Text; // ������
            string licensePlate = PlatetextBox.Text; // ������
            int year = Convert.ToInt32(yeartextBox.Text); // ������ (���������, ��� �������� ����� ���� ������������� � int)

            try
            {
                // �������� FullName �� ������ CertificateOfRegistration ��������
                string getOwnerNameQuery = "SELECT FullName FROM Drivers WHERE CertificateOfRegistration = @CertificateOfRegistration";
                string ownerName = string.Empty;

                using (var getOwnerNameCmd = new SQLiteCommand(getOwnerNameQuery, sqliteConn))
                {
                    getOwnerNameCmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                    object result = getOwnerNameCmd.ExecuteScalar();

                    if (result != null)
                    {
                        ownerName = result.ToString(); // ����������� ��������� FullName
                    }
                }

                // ��������, ���������� �� �������� � ��������� �������������� � �����������
                if (!string.IsNullOrEmpty(ownerName))
                {
                    // SQL ��� ������� ������ �� ����������
                    string insertCarQuery = "INSERT INTO Auto (CertificateOfRegistration, Make, Model, LicensePlate, Year, OwnerName) " +
                                             "VALUES (@CertificateOfRegistration, @Make, @Model, @LicensePlate, @Year, @OwnerName)";

                    using (var insertCmd = new SQLiteCommand(insertCarQuery, sqliteConn))
                    {
                        insertCmd.Parameters.AddWithValue("@CertificateOfRegistration", certificateOfRegistration);
                        insertCmd.Parameters.AddWithValue("@Make", make);
                        insertCmd.Parameters.AddWithValue("@Model", model);
                        insertCmd.Parameters.AddWithValue("@LicensePlate", licensePlate);
                        insertCmd.Parameters.AddWithValue("@Year", year);
                        insertCmd.Parameters.AddWithValue("@OwnerName", ownerName); // ���������� ��������� FullName ��������

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

                // ���������, ��� ��� ����� ������������� � int
                if (!int.TryParse(yeartextBox.Text, out updatedYear))
                {
                    MessageBox.Show("����������, ������� ���������� ���.");
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

                    cmd.ExecuteNonQuery(); // ��������� ����������
                }
            }

            LoadAuto(); // ������������� ������
        }

        private void DeleteCar_Click(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0) return;

            var licensePlatesToDelete = selectedRows.Cast<DataGridViewRow>().Select(row => row.Cells["LicensePlate"].Value.ToString()).ToList();

            DialogResult dialogResult = MessageBox.Show("�� �������, ��� ������ ������� ��������� ����������?", "�������������", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string deleteCarQuery = $"DELETE FROM Auto WHERE LicensePlate IN ({string.Join(",", licensePlatesToDelete.Select(lp => $"'{lp}'"))})";
                using (var cmd = new SQLiteCommand(deleteCarQuery, sqliteConn))
                {
                    cmd.ExecuteNonQuery();
                }

                LoadAuto(); // ������������� ������
            }
        }

        private void AutoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ���������, ��� �� �������� �� ������
            {
                DataGridViewRow row = this.AutoDataGridView.Rows[e.RowIndex];

                // �������� ������ ��� �������� ����� ������� ����������
                string certificateOfRegistration = row.Cells["CertificateOfRegistration"].Value.ToString();
                string make = row.Cells["Make"].Value.ToString();
                string model = row.Cells["Model"].Value.ToString();
                string licensePlate = row.Cells["LicensePlate"].Value.ToString();
                int year = Convert.ToInt32(row.Cells["Year"].Value);
                string ownerName = row.Cells["OwnerName"].Value.ToString();

                // �������� � �������� ����� � ������� �������
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
    }
}