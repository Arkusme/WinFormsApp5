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
    public partial class DriverDetailsForm : Form
    {
        // Параметры для хранения данных о водителе
        private string lastName;
        private string firstName;
        private string middleName;
        private string passportNumber;
        private string phone;
        private string address;
        private string certificateOfRegistration;
        private string driverLicense;
        private DateTime dateOfBirth;
        public DriverDetailsForm(string lastName, string firstName, string middleName, string passportNumber,
                             string phone, string address, string certificateOfRegistration,
                             string driverLicense, DateTime dateOfBirth)
        {
            InitializeComponent();
            // Сохранение переданных параметров
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.passportNumber = passportNumber;
            this.phone = phone;
            this.address = address;
            this.certificateOfRegistration = certificateOfRegistration;
            this.driverLicense = driverLicense;
            this.dateOfBirth = dateOfBirth;

            // Здесь можно установить значения в элементы управления на форме
            PopulateFields();
        }
        private void PopulateFields()
        {
            // Пример, как установить значения в текстовые поля на форме
            SurnameTextBox.Text = lastName;
            firstnametextbox.Text = firstName;
            middlenametextbox.Text = middleName;
            passportnumbertextbox.Text = passportNumber;
            phonetextbox.Text = phone;
            addresstextbox.Text = address;
            certificateofregistrationtextbox.Text = certificateOfRegistration;
            driverLicenseTextBox.Text = driverLicense;
            driverDateOfBirthPicker.Value = dateOfBirth; // Если у вас есть DateTimePicker для даты рождения
        }
    }
}
