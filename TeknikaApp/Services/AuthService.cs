using System.Text;
using System.Text.Json;
using TeknikaApp.Models;

namespace TeknikaApp.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var formData = new Dictionary<string, string>
        {
            { "grant_type", "password" },
            { "username", username },
            { "password", password }
        };

        var content = new FormUrlEncodedContent(formData);
        var response = await _httpClient.PostAsync("oauth/token", content);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            await SecureStorage.SetAsync("auth_token", token); // Salva il token
            return true;
        }

        return false; // Ritorna falso se la login fallisce
    }

    public async Task<string> GetAuthTokenAsync()
    {
        return await SecureStorage.GetAsync("auth_token");
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await GetAuthTokenAsync();
        return !string.IsNullOrEmpty(token);
    }

    public async Task LogoutAsync()
    {
        await SecureStorage.SetAsync("auth_token", string.Empty); // Rimuovi il token
    }

    public async Task<JsonModel> ResetPasswordAsync(string email)
    {
        var jsonModel = new JsonModel();

        try
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(new { email = email }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/Account/ForgotPassword", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                jsonModel = JsonSerializer.Deserialize<JsonModel>(responseContent);
                jsonModel.Success = true;
            }
            else
            {
                jsonModel.Success = false;
                jsonModel.ErrorMessage = $"Il server ha restituito questo errore {response.StatusCode}, {response.ReasonPhrase}";
            }
        }
        catch (Exception ex)
        {
            jsonModel.Success = false;
            jsonModel.ErrorMessage = $"Si è verificato un errore: {ex.Message}";
            Console.WriteLine(jsonModel.ErrorMessage);
        }

        return jsonModel;
    }
}