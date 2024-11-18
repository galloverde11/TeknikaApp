namespace TeknikaApp.Model;

public class JsonModel
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public string SuccessMessage { get; set; }
    public string HtmlString { get; set; }
    public bool NoMoreData { get; set; }
    public string Data { get; set; }
}
