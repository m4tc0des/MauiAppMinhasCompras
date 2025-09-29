namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
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