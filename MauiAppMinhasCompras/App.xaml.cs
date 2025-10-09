using MauiAppMinhasCompras.Helpers;
using System.Globalization;

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
            var culture = new CultureInfo("pt-BR")
            {
                NumberFormat =
        {
            NumberDecimalSeparator = ".",
            CurrencyDecimalSeparator = "."
               }
            };
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR"); //Definindo a cultura para portugues do Brasil

            MainPage = new NavigationPage(new Views.ListProduct()); //Definindo a main page e a navegacao entre paginas

        }


        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //return new Window(new AppShell());

        //}
    }
}