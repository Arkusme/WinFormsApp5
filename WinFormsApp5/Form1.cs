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
            sqliteConn = new SQLiteConnection("Data Source=C:\\Users\\vorob\\OneDrive\\–абочий стол\\GAI;Version=3;");
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
            var driverAdapter = new SQLiteDataAdapter("SELECT * FROM Drivers", sqliteConn);
            var driverTable = new DataTable();
            driverAdapter.Fill(driverTable);
            driversDataGridView.DataSource = driverTable;

            var vehicleAdapter = new SQLiteDataAdapter("SELECT * FROM Vehicles", sqliteConn);
            var vehicleTable = new DataTable();
            vehicleAdapter.Fill(vehicleTable);
            vehiclesDataGridView.DataSource = vehicleTable;

            var employeeAdapter = new SQLiteDataAdapter("SELECT * FROM Employees", sqliteConn);
            var employeeTable = new DataTable();
            employeeAdapter.Fill(employeeTable);
            employeesDataGridView.DataSource = employeeTable;

            var violationAdapter = new SQLiteDataAdapter("SELECT * FROM Violations", sqliteConn);
            var violationTable = new DataTable();
            violationAdapter.Fill(violationTable);
            violationsDataGridView.DataSource = violationTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = driverNameTextBox.Text;
            string licenseNumber = driverLicenseNumberTextBox.Text; // убедитесь, что это поле определено и заполн€етс€
            string dateOfBirth = driverDateOfBirthPicker.Value.ToString("yyyy-MM-dd");

            string insertDriver = "INSERT INTO Drivers (Name, LicenseNumber, DateOfBirth) VALUES (@Name, @LicenseNumber, @DateOfBirth)";
            using (var cmd = new SQLiteCommand(insertDriver, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber); // убедитесь, что эта переменна€ определена
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            }


            LoadData();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // «акрытие соединени€ с базой данных
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
                MessageBox.Show("¬ведите им€ дл€ поиска.");
                return;
            }

            var driverAdapter = new SQLiteDataAdapter("SELECT * FROM Employees WHERE Name LIKE @Name", sqliteConn);
            driverAdapter.SelectCommand.Parameters.AddWithValue("@Name", "%" + searchName + "%");
            var driverTable = new DataTable();
            driverAdapter.Fill(driverTable);
            employeesDataGridView.DataSource = driverTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchLicensePlate = searchVehicleTextBox.Text;

            if (string.IsNullOrEmpty(searchLicensePlate))
            {
                MessageBox.Show("¬ведите номер лицензии дл€ поиска.");
                return;
            }

            var vehicleAdapter = new SQLiteDataAdapter("SELECT * FROM Vehicles WHERE LicensePlate LIKE @LicensePlate", sqliteConn);
            vehicleAdapter.SelectCommand.Parameters.AddWithValue("@LicensePlate", "%" + searchLicensePlate + "%");
            var vehicleTable = new DataTable();
            vehicleAdapter.Fill(vehicleTable);
            vehiclesDataGridView.DataSource = vehicleTable;
        }
    }
}