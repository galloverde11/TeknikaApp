using System.Windows.Input;
using TeknikaApp.Views;

namespace TeknikaApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Navigating += OnNavigating;
        BindingContext = this;
    }

    private async void OnNavigating(object? sender, ShellNavigatingEventArgs e)
    {
        // Ottieni il token dal SecureStorage
        var token = await SecureStorage.GetAsync("auth_token");

        // Se il token è mancante e l'utente non sta navigando verso la pagina di login
        if (string.IsNullOrEmpty(token) && e.Target.Location.OriginalString != "//LoginPage")
        {
            // Annulla la navigazione
            e.Cancel();

            // Reindirizza alla pagina di login
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }

    // Comando di Logout
    public ICommand LogoutCommand => new Command(OnLogout);

    private async void OnLogout()
    {
        // Esegui il logout (esempio, elimina il token di autenticazione)
        SecureStorage.Remove("auth_token");

        // Naviga alla pagina di login (opzionale)
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
