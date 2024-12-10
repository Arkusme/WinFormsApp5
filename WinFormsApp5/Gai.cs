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
    public partial class Gai : Form
    {
        private SQLiteConnection sqliteConn;
        public Gai()
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
            protocolsDataGridView.DataSource = PolicemanTable;
            if (protocolsDataGridView.Columns.Contains("Id"))
            {
                protocolsDataGridView.Columns["Id"].Visible = false;
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

        private void SearchPolice_Click(object sender, EventArgs e)
        {
            int protocolNumber = 0;
            if (!int.TryParse(issuedProtocolsTextBox.Text.Trim(), out protocolNumber))
            {
                MessageBox.Show("Номер протокола должен быть числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string lastNameOfficer = officerLastNameTextBox.Text.Trim();


            string query = "SELECT sp.НомерПротокола, sp.СотрудникГАИ_Id, sg.Фамилия, sg.Имя, sg.Отчество, n.* " +
                           "FROM СотрудникПротоколы sp " +
                           "JOIN СотрудникГАИ sg ON sp.СотрудникГАИ_Id = sg.Id " +
                           "JOIN Нарушения n ON sp.НомерПротокола = n.НомерПротокола " +
                           "WHERE 1=1"; // Начало запроса

            if (protocolNumber > 0)
                query += " AND sp.НомерПротокола = @protocolNumber";
            if (!string.IsNullOrEmpty(lastNameOfficer))
                query += " AND sg.Фамилия LIKE @lastNameOfficer";


            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (protocolNumber > 0)
                    cmd.Parameters.AddWithValue("@protocolNumber", protocolNumber);
                if (!string.IsNullOrEmpty(lastNameOfficer))
                    cmd.Parameters.AddWithValue("@lastNameOfficer", "%" + lastNameOfficer + "%"); // Используем % для поиска подстроки


                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    var protocols = new DataTable();
                    protocols.Load(reader);

                    if (protocols.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет таких протоколов!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        protocolsDataGridView.DataSource = protocols;
                        protocolsDataGridView.Rows[0].Selected = true;
                        protocolsDataGridView.CurrentCell = protocolsDataGridView.Rows[0].Cells[0];
                    }
                }
            }
        }
    }
}
