using Microsoft.Extensions.Logging;
using TeknikaApp.Service;
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

            // Configurazione di AuthService con HttpClient
            builder.Services.AddTransient<IAuthService, AuthService>(); 
            builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
            {
                client.BaseAddress = new Uri(appSettings.ApiSettings.BaseUrl);
#if DEBUG
                client.Timeout = TimeSpan.FromSeconds(600);
#endif
            });
            builder.Services.AddSingleton<LoginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
