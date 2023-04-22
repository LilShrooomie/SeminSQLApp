using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace SeminSQLApp
{
    public partial class LoginForm : Form
    {
        Thread th;
        public LoginForm()
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
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left= e.X - lastPoint.X;
                this.Top= e.Y - lastPoint.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;
            String PassUser = passField.Text;
            DB DataBase = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @uL AND `Pass` = @uP", DataBase.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.Binary).Value = PassUser;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Добро пожаловать");
                this.Hide();
                Program.table.Show();
            }
            else
            {
                MessageBox.Show("Пользователя не существует");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void RegButton_Click(object sender, EventArgs e)
        {
            RegisterForm f2 = new RegisterForm();
            f2.Show();
            this.Hide();
            f2.FormBorderStyle= FormBorderStyle.None;
            f2.StartPosition= FormStartPosition.CenterScreen;
        }

        private void Noacc_Click(object sender, EventArgs e)
        {
                this.Hide();
                Program.RP.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}