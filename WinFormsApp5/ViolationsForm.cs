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
    public partial class ViolationsForm : Form
    {
        public ViolationsForm(string protocolNumber, string description, string licensePlate, string Info, decimal fine, DateTime violateDate, string driverName)
        {
            InitializeComponent();
            this.ProtocolNumber.Text = protocolNumber;
            this.Description.Text = description;
            this.Licenseplate.Text = licensePlate;
            this.InfolistBox.Text = Info;
            this.Fine.Text = fine.ToString("F2"); // отображаем с 2 знаками после запятой
            this.VioldateTimePicker.Value = violateDate; // Учитывайте, что это DateTimePicker
            this.DriverNameTextBox.Text = driverName; // Добавьте текстовое поле для имени водителя
        }
    }
}
