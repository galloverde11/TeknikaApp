namespace TeknikaApp.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    // Comandi per la navigazione
    public Command NavigateToCatalogCommand => new Command(async () => await NavigateToPage("CatalogPage"));
    public Command NavigateToCartCommand => new Command(async () => await NavigateToPage("CartPage"));
    public Command NavigateToProfileCommand => new Command(async () => await NavigateToPage("ProfilePage"));

    // Metodo per navigare a una pagina
    private async Task NavigateToPage(string page)
    {
        await Shell.Current.GoToAsync($"//{page}");
    }
}