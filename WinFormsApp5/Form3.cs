using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class PolicemanForm : Form
    {

        public PolicemanForm(string lastName, string firstName, string middleName, string passportNumber, string phone, string address, DateTime dateOfBirth, string rank, string position, string issuedProtocols)
        {
            InitializeComponent();
            this.lastNameTextBox.Text = lastName;
            this.fiNameTextBox.Text = firstName;
            this.miNameTextBox.Text = middleName;
            this.passportTextBox.Text = passportNumber;
            this.protophonTextBox.Text = phone;
            this.addrTextBox.Text = address;
            this.DateOfBirthPicker.Value = dateOfBirth; // Учитывайте, что это DateTimePicker
            this.rankTextBox.Text = rank;
            this.positionTextBox.Text = position;
            this.issuedProtocolsTextBox.Text = issuedProtocols;
        }
    }
}
