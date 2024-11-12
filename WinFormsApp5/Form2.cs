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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string userName = userNameTextBox.Text;

                if (radioButtonUser.Checked)
                {
                    // Если выбран пользователь, открываем форму пользователя без возможности видеть сотрудников
                    Form1 userForm = new Form1();
                    userForm.Show();
                }
                else if (radioButtonAdmin.Checked)
                {
                    // Если выбран администратор, открываем форму администратора
                    Form1 adminForm = new Form1();
                    adminForm.Show();
                }
                else
                {
                    MessageBox.Show("Выберите роль: Пользователь или Администратор.");
                }

                this.Hide(); // Скрываем текущую форму после открытия нужной
            }
        }        
    }
}
