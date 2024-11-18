namespace TeknikaApp.Model;

public class TokenModel
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string UserRole { get; set; }
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public string ExpiresIn { get; set; }
}
