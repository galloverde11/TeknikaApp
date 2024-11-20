using TeknikaApp.Services;
using TeknikaApp.Views;

namespace TeknikaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Carica le impostazioni dal file JSON appropriato
            var appSettings = AppSettings.Load();

            builder.Services.AddTransient<AuthHeaderHandler>();

            // Configurazione di AuthService con HttpClient
            builder.Services.AddTransient<IAuthService, AuthService>(); 
            builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
            {
                client.BaseAddress = new Uri(appSettings.ApiSettings.BaseUrl);
#if DEBUG
                client.Timeout = TimeSpan.FromSeconds(600);
#endif
            })
            .AddHttpMessageHandler<AuthHeaderHandler>(); // Aggiungi il handler

            // Configurazione di CartService con HttpClient
            builder.Services.AddTransient<ICartService, CartService>();
            builder.Services.AddHttpClient<ICartService, CartService>(client =>
            {
                client.BaseAddress = new Uri(appSettings.ApiSettings.BaseUrl);
#if DEBUG
    client.Timeout = TimeSpan.FromSeconds(600);
#endif
            })
            .AddHttpMessageHandler<AuthHeaderHandler>(); // Aggiungi lo stesso handler per il CartService

            builder.Services.AddSingleton<LoginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
