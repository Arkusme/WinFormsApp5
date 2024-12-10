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
    public partial class AutoDetailsForm : Form
    {
        public AutoDetailsForm(string certificateOfRegistration, string make, string model, string licensePlate, int year, string OwnerName)
        {
            InitializeComponent();
            STStextBox.Text = certificateOfRegistration;
            MakeTextBox.Text = make;
            ModeltextBox.Text = model;
            PlatetextBox.Text = licensePlate;
            yeartextBox.Text = year.ToString();
            DriverNameTextBox.Text = OwnerName;

        }
    }
}
