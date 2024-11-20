using System.Collections.ObjectModel;
using TeknikaApp.Models;
using TeknikaApp.Services;

namespace TeknikaApp.Views;

public partial class CartPage : ContentPage
{
	public CartPage()
	{

        private readonly ICartService _cartService;
    public ObservableCollection<CartItemModel> CartItems { get; set; }
    public decimal TotalPrice => CartItems.Sum(item => item.RowPriceDiscounted);
    public bool NoRecords => !CartItems.Any();

    public Command FlushCartCommand { get; }
    public Command ProceedToCheckoutCommand { get; }
    public Command GoToCatalogCommand { get; }

    public CartPage(ICartService cartService)
    {
        InitializeComponent();
        _cartService = cartService;
        CartItems = new ObservableCollection<CartItemModel>();

        // Registrazione dei comandi
        FlushCartCommand = new Command(FlushCart);
        ProceedToCheckoutCommand = new Command(ProceedToCheckout);
        GoToCatalogCommand = new Command(GoToCatalog);

        // Carica gli articoli del carrello
        LoadCartItems();
    }

    // Metodo per caricare gli articoli dal servizio
    private async void LoadCartItems()
    {
        var items = await _cartService.GetCartItemsAsync();
        CartItems.Clear();
        foreach (var item in items)
        {
            CartItems.Add(item);
        }
    }

    // Metodo per svuotare il carrello
    private async void FlushCart()
    {
        await _cartService.FlushCartAsync();
        CartItems.Clear();
    }

    // Metodo per procedere con l'ordine
    private async void ProceedToCheckout()
    {
        var success = await _cartService.ConfirmCartInOrderAsync(CartItems);
        if (success)
        {
            // Logica per procedere con il pagamento
            await DisplayAlert("Successo", "Carrello confermato", "OK");
        }
        else
        {
            await DisplayAlert("Errore", "Si è verificato un errore", "OK");
        }
    }

    // Metodo per tornare al catalogo
    private void GoToCatalog()
    {
        // Navigazione al catalogo
        Navigation.PushAsync(new CatalogPage());
    }

    // Metodo per modificare un articolo
    private void EditCartItem(CartItemModel item)
    {
        // Logica per modificare l'articolo
        // Naviga alla pagina di modifica o visualizza un dialogo
    }

    // Metodo per eliminare un articolo
    private async void DelCartItem(int itemId)
    {
        await _cartService.DelCartItemAsync(itemId);
        CartItems.Remove(CartItems.FirstOrDefault(item => item.Id == itemId));
    }
}
}