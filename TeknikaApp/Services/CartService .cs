using System.Net.Http.Json;
using System.Text.Json;
using TeknikaApp.Models;

namespace TeknikaApp.Services;

public class CartService : ICartService
{
    private readonly HttpClient _httpClient;

    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CartItemModel>> GetCartItemsAsync()
    {
        var response = await _httpClient.GetAsync("GetCartItems");
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }

        var resultData = result?.Data;

        if (string.IsNullOrEmpty(resultData))
        {
            return Enumerable.Empty<CartItemModel>();  // Restituisce una lista vuota se la data è nulla o vuota
        }

        try
        {
            var cartItems = JsonSerializer.Deserialize<IEnumerable<CartItemModel>>(resultData);
            return cartItems ?? Enumerable.Empty<CartItemModel>();  // Gestisce il caso in cui la deserializzazione fallisce
        }
        catch (JsonException ex)
        {
            // Gestione degli errori di deserializzazione
            throw new Exception("Errore nella deserializzazione dei dati", ex);
        }
    }

    public async Task<CartItemModel> GetCartItemAsync(int id)
    {
        var response = await _httpClient.GetAsync($"GetCartItem?id={id}");
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }

        var resultData = result?.Data;

        if (string.IsNullOrEmpty(resultData))
        {
            return null;  // Restituisce null se la data è nulla o vuota
        }

        try
        {
            var cartItem = JsonSerializer.Deserialize<CartItemModel>(resultData);
            return cartItem;  // Restituisce l'oggetto CartItemModel deserializzato
        }
        catch (JsonException ex)
        {
            // Gestione degli errori di deserializzazione
            throw new Exception("Errore nella deserializzazione del singolo elemento", ex);
        }
    }

    public async Task<IEnumerable<OrderLineModel>> GetOrderLinesAsync(int orderId)
    {
        var response = await _httpClient.GetAsync($"GetOrderLines?id={orderId}");
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }

        var resultData = result?.Data;

        if (string.IsNullOrEmpty(resultData))
        {
            return Enumerable.Empty<OrderLineModel>(); // Restituisce una lista vuota se la data è nulla o vuota
        }

        try
        {
            var orderLines = JsonSerializer.Deserialize<IEnumerable<OrderLineModel>>(resultData);
            return orderLines ?? Enumerable.Empty<OrderLineModel>(); // Restituisce una lista vuota se la deserializzazione restituisce null
        }
        catch (JsonException ex)
        {
            // Gestione degli errori di deserializzazione
            throw new Exception("Errore nella deserializzazione della lista di OrderLineModel", ex);
        }
    }

    public async Task<decimal> CalcItemPriceAsync(CartItemModel cartItem)
    {
        var response = await _httpClient.PostAsJsonAsync("CalcItemPrice", cartItem);
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }

        var resultData = result?.Data;

        if (string.IsNullOrEmpty(resultData))
        {
            throw new Exception("Dati di risposta invalidi per il calcolo del prezzo.");
        }

        try
        {
            // Deserializza il valore di risposta in un decimal
            var price = JsonSerializer.Deserialize<decimal>(resultData);
            return price; // Restituisce il prezzo calcolato
        }
        catch (JsonException ex)
        {
            // Gestione degli errori di deserializzazione
            throw new Exception("Errore nella deserializzazione del prezzo", ex);
        }
    }

    public async Task AddCartItemAsync(CartItemModel cartItem)
    {
        var response = await _httpClient.PostAsJsonAsync("AddCartItem", cartItem);
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }
    }

    public async Task DelCartItemAsync(int cartItemId)
    {
        var response = await _httpClient.PostAsync($"DelCartItem?id={cartItemId}", null);
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }
    }

    public async Task EditCartItemAsync(CartItemModel cartItem)
    {
        var response = await _httpClient.PostAsJsonAsync("EditCartItem", cartItem);
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }
    }

    public async Task CheckOptionalConflictsAsync(CartItemModel cartItem)
    {
        var response = await _httpClient.PostAsJsonAsync("CheckOptionalConflicts", cartItem);
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }
    }

    public async Task ConfirmCartInOrderAsync(CartItemModel cartConfirm)
    {
        var response = await _httpClient.PostAsJsonAsync("ConfirmCartInOrder", cartConfirm);
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }
    }

    public async Task FlushCartAsync()
    {
        var response = await _httpClient.PostAsync("FlushCart", null);
        var result = await response.Content.ReadFromJsonAsync<JsonModel>();

        if (result?.Success == false)
        {
            throw new Exception($"Errore: {result?.ErrorMessage}");
        }
    }
}
