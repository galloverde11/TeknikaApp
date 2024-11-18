using System.Reflection;
using System.Text.Json;

namespace TeknikaApp;

public class ApiSettings
{
    public string BaseUrl { get; set; }
}

public class AppSettings
{
    public ApiSettings ApiSettings { get; set; }

    public static AppSettings Load()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var commonSettings = LoadJson("TeknikaApp.appsettings.json");
#if DEBUG
        var environmentSettings = LoadJson("TeknikaApp.appsettings.Debug.json");
#else
        var environmentSettings = LoadJson("TeknikaApp.appsettings.Production.json");
#endif

        // Merge settings: se l'impostazione è presente in environmentSettings, sovrascrive quella in commonSettings
        return MergeSettings(commonSettings, environmentSettings);
    }

    private static AppSettings LoadJson(string resourceName)
    {
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        using StreamReader reader = new StreamReader(stream);
        string json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<AppSettings>(json);
    }

    private static AppSettings MergeSettings(AppSettings common, AppSettings environment)
    {
        if (environment?.ApiSettings != null)
        {
            common.ApiSettings = environment.ApiSettings; // Sovrascrive le impostazioni comuni
        }
        return common;
    }
}