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

            // �������� ������� CellDoubleClick � ������ �����������
            this.driversDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(driversDataGridView_CellDoubleClick);

            // ���������� DataGridView ������ ��� ������
            this.driversDataGridView.ReadOnly = true;
            this.AutoDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(AutoDataGridView_CellDoubleClick);
            this.AutoDataGridView.ReadOnly = true;
            this.PolicemanDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(PolicemanDataGridView_CellDoubleClick);
            this.PolicemanDataGridView.ReadOnly = true;
            this.violationsDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(violationsDataGridView_CellDoubleClick);
            this.violationsDataGridView.ReadOnly = true;
            this.RegistrdataGridView.CellDoubleClick += new DataGridViewCellEventHandler(RegistrdataGridView_CellDoubleClick);
            this.RegistrdataGridView.ReadOnly = true;
            // �������� ������������ �������
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
            // ��������� ����������� ���
            var positions = new List<string>
            {
                "���������",
                "������� ���������",
                "������� ���������",
                "��������� ������",
                "����������� ���������� ������",
                "������� ������������",
                "������������"
            };

            // ������ ����������� ���
            var ranks = new List<string>
            {
                "������� ���������",
                "���������",
                "������� ���������",
                "�������",
                "�����",
                "������������",
                "���������",
                "�������-�����",
                "�������-���������",
                "�������-���������"
            };
            var status = new List<string>
            {
                "�������",
                "�� �������"
            };

            // ��������� positionComboBox
            positioncomboBox.Items.Clear();
            positioncomboBox.Items.AddRange(positions.ToArray());

            // ��������� rankComboBox
            rankcomboBox.Items.Clear();
            rankcomboBox.Items.AddRange(ranks.ToArray());



            statuscomboBox.Items.Clear();
            statuscomboBox.Items.AddRange(status.ToArray());
        }
        private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ������� �����, '�', '�' � Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '�' || e.KeyChar > '�') && e.KeyChar != '�' && e.KeyChar != '�')
            {
                e.Handled = true;
            }
        }

        private void firstnametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ������� �����, '�', '�' � Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '�' || e.KeyChar > '�') && e.KeyChar != '�' && e.KeyChar != '�')
            {
                e.Handled = true;
            }
        }

        private void middlenametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ������� �����, '�', '�' � Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '�' || e.KeyChar > '�') && e.KeyChar != '�' && e.KeyChar != '�')
            {
                e.Handled = true;
            }
        }

        private void SurnameTextBox_Leave(object sender, EventArgs e)
        {
            // ��������� ������ ����� � ���������
            SurnameTextBox.Text = CapitalizeFirstLetter(SurnameTextBox.Text);
        }

        private void firstnametextbox_Leave(object sender, EventArgs e)
        {
            // ��������� ������ ����� � ���������
            firstnametextbox.Text = CapitalizeFirstLetter(firstnametextbox.Text);
        }

        private void middlenametextbox_Leave(object sender, EventArgs e)
        {
            // ��������� ������ ����� � ���������
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
            // ��������� ������ ����� � Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void phonetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ����� � Backspace, ���� ��������� ������ + � ������
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void phonetextbox_Leave(object sender, EventArgs e)
        {
            // ���������, ����� ����� ��������� � +7 � �������� ��� 10 ����
            if (!phonetextbox.Text.StartsWith("+7") || phonetextbox.Text.Length != 12)
            {
                MessageBox.Show("����� �������� ������ ���������� � +7 � ��������� 10 ���� ����� +7.");
                phonetextbox.Focus();
            }
        }

        private void certificateofregistrationtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ����� � Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void StrahovkaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ����� � Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void driverLicenseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ����� � Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void STStextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ����� � Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //���
        private void lastNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ������� �����, '�', '�' � Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '�' || e.KeyChar > '�') && e.KeyChar != '�' && e.KeyChar != '�')
            {
                e.Handled = true;
            }
        }

        private void fiNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ������� �����, '�', '�' � Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '�' || e.KeyChar > '�') && e.KeyChar != '�' && e.KeyChar != '�')
            {
                e.Handled = true;
            }
        }

        private void miNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ������� �����, '�', '�' � Backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '�' || e.KeyChar > '�') && e.KeyChar != '�' && e.KeyChar != '�')
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
            // ��������� ������ ����� � Backspace, ���� ��������� ������ + � ������
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void protophonTextBox_Leave(object sender, EventArgs e)
        {
            // ���������, ����� ����� ��������� � +7 � �������� ��� 10 ����
            if (!protophonTextBox.Text.StartsWith("+7") || protophonTextBox.Text.Length != 12)
            {
                MessageBox.Show("����� �������� ������ ���������� � +7 � ��������� 10 ���� ����� +7.");
                protophonTextBox.Focus();
            }
        }

        private void issuedProtocolsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ���� ������ ����, Backspace � "�" � ������ ������
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
            // ��������� ������ ����� � Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void STStextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ����� � Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void strahTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ������ ����� � Backspace
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
            if (AutoDataGridView.Columns.Contains("��������_ID"))
            {
                AutoDataGridView.Columns["��������_ID"].Visible = false;
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

            // ������� �������� "Id", "����_Id" � "���_���������_ID"
            if (violationsDataGridView.Columns.Contains("Id"))
            {
                violationsDataGridView.Columns["Id"].Visible = false;
            }
            if (violationsDataGridView.Columns.Contains("����_Id"))
            {
                violationsDataGridView.Columns["����_Id"].Visible = false;
            }
            if (violationsDataGridView.Columns.Contains("���_���������_ID"))
            {
                violationsDataGridView.Columns["���_���������_ID"].Visible = false;
            }
            if (violationsDataGridView.Columns.Contains("��������_ID"))
            {
                violationsDataGridView.Columns["��������_ID"].Visible = false;
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
            if (RegistrdataGridView.Columns.Contains("����_ID"))
            {
                RegistrdataGridView.Columns["����_ID"].Visible = false;
            }
            if (RegistrdataGridView.Columns.Contains("��������_ID"))
            {
                RegistrdataGridView.Columns["��������_ID"].Visible = false;
            }
            if (RegistrdataGridView.Columns.Contains("���������_ID"))
            {
                RegistrdataGridView.Columns["���������_ID"].Visible = false;
            }
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
            Application.Exit(); // ��������� ���������� ��� �������� Form1            
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

            string query = "SELECT * FROM �������� WHERE 1=1"; // ������ �������

            // ������� ������
            if (!string.IsNullOrEmpty(lastName))
                query += " AND ������� LIKE '%' || @lastName || '%'";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND ��� LIKE '%' || @firstName || '%'";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND �������� LIKE '%' || @middleName || '%'";
            if (!string.IsNullOrEmpty(passportNumber))
                query += " AND ������������� LIKE '%' || @passportNumber || '%'";
            if (!string.IsNullOrEmpty(phone))
                query += " AND ������� LIKE '%' || @phone || '%'";
            if (!string.IsNullOrEmpty(address))
                query += " AND ����� LIKE '%' || @address || '%'";
            if (!string.IsNullOrEmpty(certificateOfRegistration))
                query += " AND ������������������������� LIKE '%' || @certificateOfRegistration || '%'";
            if (!string.IsNullOrEmpty(driverLicense))
                query += " AND ������������������������� LIKE '%' || @driverLicense || '%'";
            if (includeDate && dateOfBirth != DateTime.MinValue)
                query += " AND ������������ = @dateOfBirth";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                // ���������� ����������
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

                // ����� �� ������� ��� �������
                Console.WriteLine("SQL Query: " + query);
                foreach (SQLiteParameter parameter in cmd.Parameters)
                {
                    Console.WriteLine($"{parameter.ParameterName}: {parameter.Value}");
                }

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
                        if (drivers.Rows.Count > 0)
                        {
                            try
                            {
                                // ���������, ��� ������ ������ ������ ����� ���������� ������� ������
                                if (driversDataGridView.Rows[0].Visible)
                                {
                                    driversDataGridView.Rows[0].Selected = true;
                                    driversDataGridView.CurrentCell = driversDataGridView.Rows[0].Cells
                                        .Cast<DataGridViewCell>()
                                        .First(cell => cell.Visible); // ���������� ������� ������� ������
                                }
                            }
                            catch (InvalidOperationException ex)
                            {
                                // ��������� ������
                                MessageBox.Show("������ ��� ������ ������� ������: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // ���������, ����� ��� ���� ���� ���������
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(middleName) ||
                string.IsNullOrEmpty(passportNumber) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(certificateOfRegistration) || string.IsNullOrEmpty(driverLicense))
            {
                MessageBox.Show("����������, ��������� ��� ������������ ����.");
                return;
            }

            // ��������� �� ������������
            if (IsDriverExists(lastName, firstName, middleName, passportNumber))
            {
                MessageBox.Show("����� �������� ��� ����������.");
                return;
            }

            // SQL ��� ������� ������
            string insertDriver = "INSERT INTO �������� (�������, ���, ��������, �������������, �������, �����, �������������������������, �������������������������, ������������) " +
                                  "VALUES (@�������, @���, @��������, @�������������, @�������, @�����, @�������������������������, @�������������������������, @������������)";

            try
            {
                using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
                {
                    // ���������� ����������
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
                MessageBox.Show("�������� ������� ��������!");
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ���������.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int driverId = Convert.ToInt32(row.Cells["Id"].Value); // �������� ������������� ��������

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
                                      "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateDriver, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", driverId);
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
                return;
            }

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

        private void driversDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ���������, ��� �������� �� ������
            {
                DataGridViewRow row = this.driversDataGridView.Rows[e.RowIndex];

                // ���������� ��������������� ��������� �����
                SurnameTextBox.Text = row.Cells["�������"].Value.ToString();
                firstnametextbox.Text = row.Cells["���"].Value.ToString();
                middlenametextbox.Text = row.Cells["��������"].Value.ToString();
                passportnumbertextbox.Text = row.Cells["�������������"].Value.ToString();
                phonetextbox.Text = row.Cells["�������"].Value.ToString();
                addresstextbox.Text = row.Cells["�����"].Value.ToString();
                certificateofregistrationtextbox.Text = row.Cells["�������������������������"].Value.ToString();
                driverLicenseTextBox.Text = row.Cells["�������������������������"].Value.ToString();
                driverDateOfBirthPicker.Value = Convert.ToDateTime(row.Cells["������������"].Value);
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

            string searchQuery = "SELECT a.�������������������������, a.�����, a.������, a.������������, a.���, a.��������, a.����������� " +
                                 "FROM ���� a WHERE 1=1"; // �������� � ������� "1=1"

            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND a.������������������������� LIKE '%' || @������������������������� || '%'";
            }
            if (!string.IsNullOrEmpty(make))
            {
                searchQuery += " AND a.����� LIKE '%' || @����� || '%'";
            }
            if (!string.IsNullOrEmpty(model))
            {
                searchQuery += " AND a.������ LIKE '%' || @������ || '%'";
            }
            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND a.������������ LIKE '%' || @������������ || '%'";
            }
            if (isYearParsed)
            {
                searchQuery += " AND a.��� = @���";
            }
            if (!string.IsNullOrEmpty(insurance))
            {
                searchQuery += " AND a.����������� LIKE '%' || @����������� || '%'";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                }
                if (!string.IsNullOrEmpty(make))
                {
                    cmd.Parameters.AddWithValue("@�����", make);
                }
                if (!string.IsNullOrEmpty(model))
                {
                    cmd.Parameters.AddWithValue("@������", model);
                }
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@������������", licensePlate);
                }
                if (isYearParsed)
                {
                    cmd.Parameters.AddWithValue("@���", year);
                }
                if (!string.IsNullOrEmpty(insurance))
                {
                    cmd.Parameters.AddWithValue("@�����������", insurance);
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
            string insurance = StrahovkaTextBox.Text.Trim();
            int year;

            // ��������, ��� ��� ���� ���������
            if (string.IsNullOrEmpty(certificateOfRegistration) || string.IsNullOrEmpty(make) ||
                string.IsNullOrEmpty(model) || string.IsNullOrEmpty(licensePlate) ||
                string.IsNullOrEmpty(insurance) || !int.TryParse(yeartextBox.Text, out year))
            {
                MessageBox.Show("����������, ��������� ��� ���� ���������.");
                return;
            }

            try
            {
                // �������� �� ������������ �������� ����
                string checkLicensePlateQuery = "SELECT COUNT(*) FROM ���� WHERE ������������ = @licensePlate";
                using (var checkCmd = new SQLiteCommand(checkLicensePlateQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@licensePlate", licensePlate);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("���������� � ����� �������� ������ ��� ����������.");
                        return;
                    }
                }

                // SQL ��� ������� ������ �� ���������� � ����������� ���������
                string insertCarQuery = @"
INSERT INTO ���� (�������������������������, �����, ������, ������������, ���, ��������, ��������_ID, �����������) 
VALUES (@�������������������������, @�����, @������, @������������, @���, 
        (SELECT ������� || ' ' || SUBSTR(���, 1, 1) || '. ' || IFNULL(SUBSTR(��������, 1, 1) || '.', '') 
         FROM �������� WHERE ������������������������� = @�������������������������), 
        (SELECT Id FROM �������� WHERE ������������������������� = @�������������������������), 
        @�����������)";

                using (var insertCmd = new SQLiteCommand(insertCarQuery, sqliteConn))
                {
                    insertCmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                    insertCmd.Parameters.AddWithValue("@�����", make);
                    insertCmd.Parameters.AddWithValue("@������", model);
                    insertCmd.Parameters.AddWithValue("@������������", licensePlate);
                    insertCmd.Parameters.AddWithValue("@���", year);
                    insertCmd.Parameters.AddWithValue("@�����������", insurance);

                    insertCmd.ExecuteNonQuery(); // ��������� ������
                }

                MessageBox.Show("���������� ������� ��������!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ����������: {ex.Message}");
            }

            LoadAuto();
        }

        private void EditCar_Click_1(object sender, EventArgs e)
        {
            var selectedRows = AutoDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ���������.");
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
                return;
            }

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

        private void AutoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ���������, ��� �� �������� �� ������
            {
                DataGridViewRow row = this.AutoDataGridView.Rows[e.RowIndex];

                // �������� ������ ��� ���������� ��������� �����
                string certificateOfRegistration = row.Cells["�������������������������"].Value.ToString();
                string make = row.Cells["�����"].Value.ToString();
                string model = row.Cells["������"].Value.ToString();
                string licensePlate = row.Cells["������������"].Value.ToString();
                int year = Convert.ToInt32(row.Cells["���"].Value);
                string ownerFullName = row.Cells["��������"].Value.ToString();
                string insurance = row.Cells["�����������"].Value?.ToString() ?? string.Empty; // ��������������, ��� ���� ������� �����������

                // ��������� ��������� ���� �� �����
                STStextBox.Text = certificateOfRegistration;
                MakeTextBox.Text = make;
                ModeltextBox.Text = model;
                PlatetextBox.Text = licensePlate;
                yeartextBox.Text = year.ToString();
                OwnerTextBox.Text = ownerFullName;
                StrahovkaTextBox.Text = insurance; // ��������� ���������� ���� StrahovkaTextBox
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

            string query = "SELECT * FROM ������������ WHERE 1=1"; // ������ �������

            // ������� ������
            if (!string.IsNullOrEmpty(lastName))
                query += " AND ������� LIKE '%' || @lastName || '%'";
            if (!string.IsNullOrEmpty(firstName))
                query += " AND ��� LIKE '%' || @firstName || '%'";
            if (!string.IsNullOrEmpty(middleName))
                query += " AND �������� LIKE '%' || @middleName || '%'";
            if (!string.IsNullOrEmpty(passportNumber))
                query += " AND ������������� LIKE '%' || @passportNumber || '%'";
            if (!string.IsNullOrEmpty(phone))
                query += " AND ������� LIKE '%' || @phone || '%'";
            if (!string.IsNullOrEmpty(address))
                query += " AND ����� LIKE '%' || @address || '%'";
            if (!string.IsNullOrEmpty(rank))
                query += " AND ������ LIKE '%' || @rank || '%'";
            if (!string.IsNullOrEmpty(position))
                query += " AND ��������� LIKE '%' || @position || '%'";
            if (includeDate && dateOfBirth != DateTime.MinValue) // ��������, ���� ���� �������� �������
                query += " AND ������������ = @dateOfBirth";
            if (!string.IsNullOrEmpty(issuedProtocol))
                query += " AND ������������������ LIKE '%' || @issuedProtocol || '%'";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                // ���������� ����������
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
            string rank = rankcomboBox.SelectedItem?.ToString();
            string position = positioncomboBox.SelectedItem?.ToString();
            string dateOfBirth = DateOfBirthPicker.Value.ToString("yyyy-MM-dd");
            string protocolNumber = issuedProtocolsTextBox.Text.Trim();

            // ���������, ����� ��� ���� ���� ���������
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(middleName) ||
                string.IsNullOrEmpty(passportNumber) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(rank) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(protocolNumber))
            {
                MessageBox.Show("����������, ��������� ��� ������������ ����.");
                return;
            }

            // �������� �� ������������ ���������� �� ��� � ������ ��������
            string checkUniqueQuery = "SELECT COUNT(*) FROM ������������ WHERE ������� = @lastName AND ��� = @firstName AND �������� = @middleName AND ������������� = @passportNumber";
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
                    MessageBox.Show("��������� � ������ ��� � ������� �������� ��� ����������.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������������ ����������: {ex.Message}");
                return;
            }

            // �������� �� ������������ ����������� ���������
            string checkProtocolQuery = "SELECT COUNT(*) FROM ������������ WHERE ������������������ = @protocolNumber";
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
                    MessageBox.Show("�������� � ����� ������� ��� �������.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������������ ���������: {ex.Message}");
                return;
            }

            // SQL ��� ������� ������
            string insertPolice = "INSERT INTO ������������ (�������, ���, ��������, �������������, �������, �����, ������������, ������, ���������, ������������������) " +
                                  "VALUES (@lastName, @firstName, @middleName, @passportNumber, @phone, @address, @dateOfBirth, @rank, @position, @protocolNumber)";

            try
            {
                using (var cmd = new SQLiteCommand(insertPolice, sqliteConn))
                {
                    // ���������� ����������
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
                    cmd.ExecuteNonQuery(); // ��������� ������
                }
                MessageBox.Show("��������� ������� ��������!");
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ���������.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row.Selected)
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
                                          "��������� = COALESCE(NULLIF(@position, ''), ���������), " +
                                          "������������������ = COALESCE(NULLIF(@protocolNumber, ''), ������������������) " +
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

            LoadPoliceman(); // ������������� ������
        }




        private void DeletePolice_Click_1(object sender, EventArgs e)
        {
            var selectedRows = PolicemanDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
                return;
            }

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

        private void PolicemanDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            string protocol = selectedRow.Cells["������������������"].Value.ToString();

            // ��������� ��������� ���� �� �����
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
            string status = statuscomboBox.SelectedItem?.ToString() ?? string.Empty; // �������� ��������� ������ ������
            bool includeDate = checkBox1.Checked;

            string query = "SELECT * FROM ��������� WHERE 1=1"; // ������ �������

            // ������� ������
            if (!string.IsNullOrEmpty(protocolNumber))
                query += " AND �������������� LIKE @protocolNumber";
            if (includeDate && violationDate != DateTime.MinValue)
                query += " AND ������������� = @violationDate";
            if (!string.IsNullOrEmpty(violation))
                query += " AND ��������� LIKE @violation";
            if (!string.IsNullOrEmpty(info))
                query += " AND �������� LIKE @info";
            if (!string.IsNullOrEmpty(licensePlate))
                query += " AND ������������ LIKE @licensePlate";
            if (!string.IsNullOrEmpty(status))
                query += " AND ������������ = @status"; // �������� �� ������ ���������

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                // ���������� ����������
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
                    cmd.Parameters.AddWithValue("@status", status); // �������� ������ ��� ���������

                // ����� ���������� ��� �������
                Console.WriteLine("SQL Query: " + query);
                foreach (SQLiteParameter parameter in cmd.Parameters)
                {
                    Console.WriteLine($"{parameter.ParameterName}: {parameter.Value}");
                }

                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� ���������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string status = statuscomboBox.SelectedItem.ToString(); // �������� ��������� ������ ������

            // ��������, ����� ��� ���� ���� ���������
            if (string.IsNullOrEmpty(protocolNumber) || string.IsNullOrEmpty(violation) || string.IsNullOrEmpty(fineText) ||
                string.IsNullOrEmpty(description) || string.IsNullOrEmpty(licensePlate))
            {
                MessageBox.Show("����������, ��������� ��� ������������ ����.");
                return;
            }

            // �������� ������������ ����� ������
            decimal fine;
            if (!decimal.TryParse(fineText, out fine))
            {
                MessageBox.Show("����������, ������� ���������� �����.");
                return;
            }

            // �������� ������� ��������� � ������� ���������
            string checkViolationProtocolQuery = "SELECT COUNT(*) FROM ��������� WHERE �������������� = @ProtocolNumber";
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
                    MessageBox.Show("�������� � ����� ������� ��� ����������.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ���������: {ex.Message}");
                return;
            }

            // �������� ������� ���������� � ������� ����
            string checkCarQuery = "SELECT Id, ��������, ��������_ID FROM ���� WHERE ������������ = @LicensePlate";
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
                            MessageBox.Show("���������� � ����� �������� ������ �� ����������.");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ����������: {ex.Message}");
                return;
            }

            // ��������� Id ���������� ���
            int gAI_OfficerId = 0;
            string checkGAIOfficerQuery = "SELECT Id FROM ������������ WHERE ������������������ = @ProtocolNumber";
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
                        MessageBox.Show("��������� ��� � ������ ������� ��������� �� ������.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ���������� ���: {ex.Message}");
                return;
            }

            // SQL ��� ������� ������
            string insertViolation = @"
INSERT INTO ��������� (��������������, �������������, ���������, ������������, �����, ��������, ������������, ��������, ���������������, ����_Id, ���_���������_ID, ��������_ID) 
VALUES (@ProtocolNumber, @ViolationDate, @Violation, @LicensePlate, @FineText, @Description, @Status, 
        @Driver, 
        (SELECT ������ || ' ' || ������� || ' ' || SUBSTR(���, 1, 1) || '.' || IFNULL(SUBSTR(��������, 1, 1) || '.', '') 
         FROM ������������ WHERE ������������������ = @ProtocolNumber), 
        @CarId, 
        @GAI_OfficerId, 
        @DriverId)";

            try
            {
                using (var cmd = new SQLiteCommand(insertViolation, sqliteConn))
                {
                    // ���������� ����������
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

                    cmd.ExecuteNonQuery(); // ��������� ������
                }
                MessageBox.Show("��������� ������� ���������!");
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
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ���������.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int violationId = Convert.ToInt32(row.Cells["Id"].Value);

                string updateViolation = "UPDATE ��������� SET " +
                                         "�������������� = COALESCE(NULLIF(@ProtocolNumber, ''), ��������������), " +
                                         "������������� = COALESCE(NULLIF(@ViolationDate, ''), �������������), " +
                                         "��������� = COALESCE(NULLIF(@Violation, ''), ���������), " +
                                         "������������ = COALESCE(NULLIF(@LicensePlate, ''), ������������), " +
                                         "����� = COALESCE(NULLIF(@Fine, ''), �����), " +
                                         "�������� = COALESCE(NULLIF(@Description, ''), ��������), " +
                                         "������������ = COALESCE(NULLIF(@Status, ''), ������������) " +
                                         "WHERE Id = @Id";

                try
                {
                    using (var cmd = new SQLiteCommand(updateViolation, sqliteConn))
                    {
                        // ���������� ����������
                        cmd.Parameters.AddWithValue("@Id", violationId);
                        cmd.Parameters.AddWithValue("@ProtocolNumber", string.IsNullOrEmpty(ProtocolNumber.Text.Trim()) ? (object)DBNull.Value : ProtocolNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@ViolationDate", VioldateTimePicker.Value == VioldateTimePicker.MinDate ? (object)DBNull.Value : VioldateTimePicker.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Violation", string.IsNullOrEmpty(Description.Text.Trim()) ? (object)DBNull.Value : Description.Text.Trim());
                        cmd.Parameters.AddWithValue("@LicensePlate", string.IsNullOrEmpty(Licenseplate.Text.Trim()) ? (object)DBNull.Value : Licenseplate.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fine", string.IsNullOrEmpty(Fine.Text.Trim()) ? (object)DBNull.Value : (object)Convert.ToDecimal(Fine.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Info.Text.Trim()) ? (object)DBNull.Value : Info.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", statuscomboBox.SelectedItem == null ? (object)DBNull.Value : statuscomboBox.SelectedItem.ToString());

                        cmd.ExecuteNonQuery(); // ��������� ����������
                    }
                    MessageBox.Show("��������� ������� ���������!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� ���������� ���������: {ex.Message}");
                }
            }

            LoadViolations(); // ������������� ������
        }




        private void DelViol_Click_1(object sender, EventArgs e)
        {
            var selectedRows = violationsDataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
                return;
            }

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

        private void violationsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ��������� ��������� ����������

            // �������� ��������� ������
            DataGridViewRow selectedRow = violationsDataGridView.Rows[e.RowIndex];

            // ��������� ������ �� �����
            string protocolNumber = selectedRow.Cells["��������������"].Value.ToString();
            string violation = selectedRow.Cells["���������"].Value.ToString();
            string description = selectedRow.Cells["��������"].Value.ToString();
            string licensePlate = selectedRow.Cells["������������"].Value.ToString();
            decimal fine = Convert.ToDecimal(selectedRow.Cells["�����"].Value);
            DateTime violateDate = Convert.ToDateTime(selectedRow.Cells["�������������"].Value);
            string inspectorName = selectedRow.Cells["���������������"].Value.ToString();
            string driverName = selectedRow.Cells["��������"].Value.ToString();
            string status = selectedRow.Cells["������������"].Value.ToString();

            // ��������� ��������� ���� �� �����
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

            // �������� � �������� �������
            string searchQuery = "SELECT r.��������, r.������������, r.�������������������������, r.���������, r.��������������� " +
                                 "FROM ����������� r WHERE 1=1"; // ������� ������ ������� (��� �������� ���������� ������ �������)

            // ��������� ������� ������
            if (!string.IsNullOrEmpty(certificateOfRegistration))
            {
                searchQuery += " AND r.������������������������� LIKE '%' || @������������������������� || '%'";
            }
            if (!string.IsNullOrEmpty(insurance))
            {
                searchQuery += " AND r.��������� LIKE '%' || @��������� || '%'";
            }
            if (!string.IsNullOrEmpty(licensePlate))
            {
                searchQuery += " AND r.������������ LIKE '%' || @������������ || '%'";
            }
            if (includeDate && registrationDate != DateTime.MinValue)
            {
                searchQuery += " AND r.��������������� = @���������������";
            }

            using (var cmd = new SQLiteCommand(searchQuery, sqliteConn))
            {
                // ��������� ���������, ���� ��� ���� �������
                if (!string.IsNullOrEmpty(certificateOfRegistration))
                {
                    cmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                }
                if (!string.IsNullOrEmpty(insurance))
                {
                    cmd.Parameters.AddWithValue("@���������", insurance);
                }
                if (!string.IsNullOrEmpty(licensePlate))
                {
                    cmd.Parameters.AddWithValue("@������������", licensePlate);
                }
                if (includeDate && registrationDate != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@���������������", registrationDate.ToString("yyyy-MM-dd"));
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
            string certificateOfRegistration = STStextBox5.Text.Trim();
            DateTime registrationDate = dateTimePicker1.Value;

            // ��������, ����� ��� ���� ���� ���������
            if (string.IsNullOrEmpty(certificateOfRegistration))
            {
                MessageBox.Show("����������, ��������� ���� ������������� � �����������.");
                return;
            }

            // �������� �� ������������ ���
            string checkExistingQuery = "SELECT COUNT(*) FROM ����������� WHERE ������������������������� = @certificateOfRegistration";
            using (var checkCmd = new SQLiteCommand(checkExistingQuery, sqliteConn))
            {
                checkCmd.Parameters.AddWithValue("@certificateOfRegistration", certificateOfRegistration);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("����������� � ����� ��� ��� ����������.");
                    return;
                }
            }

            // ��������� ������ �� ������� ���� �� ���
            string checkCarQuery = "SELECT Id, ������������, ��������, ����������� FROM ���� WHERE ������������������������� = @�������������������������";
            int carId = 0;
            string licensePlate = "";
            string owner = "";
            string insurance = "";
            int driverId = 0;

            try
            {
                using (var checkCmd = new SQLiteCommand(checkCarQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
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
                            MessageBox.Show("���������� � ����� ��� �� ������.");
                            return;
                        }
                    }
                }

                // ��������� ��������_ID �� ������� �������� �� ���
                string checkDriverQuery = "SELECT Id FROM �������� WHERE ������������������������� = @�������������������������";

                using (var checkCmd = new SQLiteCommand(checkDriverQuery, sqliteConn))
                {
                    checkCmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                    var result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        driverId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("�������� � ����� ��� �� ������.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������: {ex.Message}");
                return;
            }

            // SQL ��� ������� ������
            string insertQuery = "INSERT INTO ����������� (��������, ������������, �������������������������, ���������, ���������������, ��������_ID, ����_ID) " +
                                 "VALUES (@��������, @������������, @�������������������������, @���������, @���������������, @��������_ID, @����_ID)";

            try
            {
                using (var cmd = new SQLiteCommand(insertQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@��������", owner);
                    cmd.Parameters.AddWithValue("@������������", licensePlate);
                    cmd.Parameters.AddWithValue("@�������������������������", certificateOfRegistration);
                    cmd.Parameters.AddWithValue("@���������", insurance);
                    cmd.Parameters.AddWithValue("@���������������", registrationDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@��������_ID", driverId);
                    cmd.Parameters.AddWithValue("@����_ID", carId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("����������� ������� ���������!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� �����������: {ex.Message}");
            }
            LoadRegistr(); // ������������� ������
        }


        private void EditRegister_Click(object sender, EventArgs e)
        {
            var selectedRows = RegistrdataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("����������, �������� ������ ��� ���������.");
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int registrationId = Convert.ToInt32(row.Cells["Id"].Value);
                string updatedCertificateOfRegistration = STStextBox5.Text.Trim();
                string updatedLicensePlate = NumberTextBox.Text.Trim();
                DateTime updatedRegistrationDate = dateTimePicker1.Value; // ���� �����������
                string updatedInsurance = strahTextBox.Text.Trim();

                string updateCarQuery = "UPDATE ����������� SET " +
                                        "������������������������� = COALESCE(NULLIF(@�������������������������, ''), �������������������������), " +
                                        "������������ = COALESCE(NULLIF(@������������, ''), ������������), " +
                                        "��������������� = COALESCE(NULLIF(@���������������, '0001-01-01'), ���������������), " +
                                        "��������� = COALESCE(NULLIF(@���������, ''), ���������) " +
                                        "WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(updateCarQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@Id", registrationId);
                    cmd.Parameters.AddWithValue("@�������������������������", updatedCertificateOfRegistration);
                    cmd.Parameters.AddWithValue("@������������", updatedLicensePlate);
                    cmd.Parameters.AddWithValue("@���������������", updatedRegistrationDate.ToString("yyyy-MM-dd")); // �������������� ����
                    cmd.Parameters.AddWithValue("@���������", updatedInsurance);

                    cmd.ExecuteNonQuery(); // ��������� ����������
                }
            }

            LoadRegistr(); // ������������� ������
        }


        private void ObnoveRegistr_Click(object sender, EventArgs e)
        {
            LoadRegistr();
        }

        private void RegistrdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ���������, ��� �� �������� �� ������
            {
                DataGridViewRow row = this.RegistrdataGridView.Rows[e.RowIndex];

                // �������� ������ ��� ���������� ��������� �����
                string certificateOfRegistration = row.Cells["�������������������������"].Value.ToString();
                string strahovka = row.Cells["���������"].Value?.ToString() ?? string.Empty; // ��������������, ��� ���� ������� ���������
                string licensePlate = row.Cells["������������"].Value.ToString();
                DateTime registrationDate = Convert.ToDateTime(row.Cells["���������������"].Value);
                string driverName = row.Cells["��������"].Value?.ToString() ?? string.Empty; // ��������������, ��� ���� ������� ��������

                // ��������� ��������� ���� �� �����
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
                MessageBox.Show("����������, �������� ������ ��� ��������.");
                return;
            }
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

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ������� ���� TextBox � ComboBox
            foreach (Control control in this.Controls)
            {
                ClearControl(control);
            }

            // ������� ���� ��������� ������ TabControl
            foreach (TabPage tab in tabControl1.TabPages)
            {
                foreach (Control control in tab.Controls)
                {
                    ClearControl(control);
                }
            }
        }

        // ����������� ����� ��� ������� TextBox � ComboBox
        private void ClearControl(Control control)
        {
            if (control is TextBox)
            {
                ((TextBox)control).Clear();
            }
            else if (control is ComboBox)
            {
                ((ComboBox)control).SelectedIndex = -1; // �������� ���������
            }
            else if (control is Panel || control is GroupBox)
            {
                foreach (Control nestedControl in control.Controls)
                {
                    ClearControl(nestedControl);
                }
            }
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("�� ����� ������ �����?", "������������� ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide(); // ������ ������� ����� ������ ��������
            }
            // ���� ������������ ������ "���", ������ �� ������, � ����� ��������� ��������.
        }
    }
}
