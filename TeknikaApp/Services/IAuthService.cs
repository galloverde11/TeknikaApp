using TeknikaApp.Models;

namespace TeknikaApp.Services;

public interface IAuthService
{
    Task<bool> LoginAsync(string username, string password);
    Task<string> GetAuthTokenAsync();
    Task<bool> IsAuthenticatedAsync();
    Task LogoutAsync();
    Task<JsonModel> ResetPasswordAsync(string email);
}