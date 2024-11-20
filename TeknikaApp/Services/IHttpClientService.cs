namespace TeknikaApp.Services;

public interface IHttpClientService
{
    Task<HttpResponseMessage> GetAsync(string url);
    Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
}
