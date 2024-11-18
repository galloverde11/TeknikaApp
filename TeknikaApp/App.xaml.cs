namespace TeknikaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            CheckAuthentication();
        }

        private async void CheckAuthentication()
        {
            var token = await SecureStorage.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                // Reindirizza alla pagina di login se non autenticato
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                // Vai alla HomePage se autenticato
                await Shell.Current.GoToAsync("//HomePage");
            }
        }
    }
}
