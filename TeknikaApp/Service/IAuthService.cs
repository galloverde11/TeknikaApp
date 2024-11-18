using TeknikaApp.Model;

namespace TeknikaApp.Service;

public interface IAuthService
{
    Task<bool> LoginAsync(string username, string password);
    Task<string> GetAuthTokenAsync();
    Task<bool> IsAuthenticatedAsync();
    Task LogoutAsync();
    Task<JsonModel> ResetPasswordAsync(string email);
}