using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Завершить приложение при закрытии Form2
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            if (userName == "gai" && password == "")
            {
                Gai gaiForm = new Gai();
                gaiForm.Show();
                this.Hide();
            }
            if (userName == "user" && password == "")
            {
                User userForm = new User();
                userForm.Show();
                this.Hide();
            }
            else if (userName == "admin" && password == "admin")
            {
                Form1 adminForm = new Form1();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }

        }
        private void GoBackToForm1()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide(); // Скрыть текущую форму вместо закрытия
        }

    }
}
