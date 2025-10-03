using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                string path = Path.Combine
                    (
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "banco_sqlite_compras.db3");

                if (_db == null)
                    _db = new SQLiteDatabaseHelper(path);
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListProduct()); //Definindo a main page e a navegacao entre paginas
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //return new Window(new AppShell());

        //}
    }
}