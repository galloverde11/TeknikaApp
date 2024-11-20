using System.Net.Http.Headers;
using TeknikaApp.Services;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        // Recupera il token da SecureStorage
        var token = await SecureStorage.GetAsync("auth_token");

        // Aggiungi il token all'header Authorization
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // Effettua la richiesta GET
        return await _httpClient.GetAsync(url);
    }

    public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
    {
        // Recupera il token da SecureStorage
        var token = await SecureStorage.GetAsync("auth_token");

        // Aggiungi il token all'header Authorization
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // Effettua la richiesta POST
        return await _httpClient.PostAsync(url, content);
    }
}