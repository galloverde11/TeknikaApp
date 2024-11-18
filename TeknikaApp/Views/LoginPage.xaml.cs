using TeknikaApp.Model;
using TeknikaApp.Service;

namespace TeknikaApp.Views;

public partial class LoginPage : ContentPage
{
    private readonly IAuthService _authService;

    public LoginPage(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private void OnUsernameTextChanged(object sender, TextChangedEventArgs e)
    {
        // Abilita il pulsante se Username non è vuoto
        ResetPasswordButton.IsEnabled = !string.IsNullOrWhiteSpace(UsernameEntry.Text);
        LoginButton.IsEnabled = !string.IsNullOrWhiteSpace(UsernameEntry.Text) && !string.IsNullOrWhiteSpace(PasswordEntry.Text);
    }

    private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
    {
        // Abilita il pulsante se Username non è vuoto
        LoginButton.IsEnabled = !string.IsNullOrWhiteSpace(UsernameEntry.Text) && !string.IsNullOrWhiteSpace(PasswordEntry.Text);
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        bool success = await _authService.LoginAsync(UsernameEntry.Text, PasswordEntry.Text);

        if (success)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {
            await DisplayAlert("Errore", "Credenziali non valide.", "OK");
        }
    }

    private async void OnResetPswButtonClicked(object sender, EventArgs e)
    {
        JsonModel resetResult = await _authService.ResetPasswordAsync(UsernameEntry.Text);

        if (resetResult.Success)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {
            await DisplayAlert("Errore", "Problema nel resettare la password", "OK");
        }
    }
}