using System.Net.Http.Headers;

public class AuthHeaderHandler : DelegatingHandler
{
    public AuthHeaderHandler() { }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Verifica se la richiesta è verso l'endpoint di autenticazione (ad esempio, "oauth/token")
        if (request.RequestUri.AbsolutePath.Contains("oauth/token", System.StringComparison.OrdinalIgnoreCase))
        {
            // Se è la richiesta per ottenere il token, non aggiungere l'intestazione di autorizzazione
            return await base.SendAsync(request, cancellationToken);
        }

        // Altrimenti, aggiungi il token di autorizzazione a tutte le altre richieste
        var token = await SecureStorage.GetAsync("auth_token");

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // Continua l'elaborazione della richiesta
        return await base.SendAsync(request, cancellationToken);
    }
}
