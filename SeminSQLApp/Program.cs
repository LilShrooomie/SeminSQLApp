namespace SeminSQLApp
{
    internal static class Program
    {
        public static LoginForm LP;
        public static RegisterForm RP;
        public static MainMenu MM;
        public static Table1 table;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RP = new RegisterForm();
            LP = new LoginForm();
            table = new Table1();
            Application.Run(MM = new MainMenu());
        }
    }
}