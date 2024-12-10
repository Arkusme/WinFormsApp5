using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Registr : Form
    {
        public Registr(string certificateOfRegistration, string strahovka, string licensePlate, string driverName, DateTime registrationDate)
        {
            InitializeComponent();
            this.STStextBox5.Text = certificateOfRegistration;
            this.strahTextBox.Text = strahovka;
            this.NumberTextBox.Text = licensePlate;
            this.dateTimePicker1.Value = registrationDate;
            this.DriverNameTextBox.Text = driverName; // Добавьте текстовое поле для имени водителя

        }
    }
}
