using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminSQLApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }
        Point Moveable;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left = e.X - Moveable.X;
                this.Top = e.Y - Moveable.Y;
            }
        }
        LoginForm f2 = new LoginForm();
        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите имя")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                MessageBox.Show("Введите логин");
            }
            if (passField.Text == "")
            {
                MessageBox.Show("Введите пароль");
            }
            if (Email.Text == "")
            {
                MessageBox.Show("Введите почту");
            }
            DB regDB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`ID`,`Login`, `Pass`, `Email`) VALUES (NULL, @login, @pass, @email)", regDB.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = Email.Text;

            regDB.OpenConnection();
            if (command.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Аккаунт был создан");
            }
            else 
            { 
                MessageBox.Show("Проверьте поля");
            }
            regDB.CloseConnection();   
        }
        public Boolean Userexists()
        {
            DB DataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @uL", DataBase.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void passField_TextChanged(object sender, EventArgs e)
        {
            passField.UseSystemPasswordChar = true;
        }
    }
}
