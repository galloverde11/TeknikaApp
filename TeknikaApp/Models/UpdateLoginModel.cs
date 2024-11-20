namespace TeknikaApp.Models;

public class UpdateLoginModel
{
    public int UserId { get; set; }
    public string NewEmail { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}