using HybridTodoApp.Components.Data;
using Microsoft.Extensions.Logging;

namespace HybridTodoApp
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<TodoService>();
            builder.Services.AddSingleton<IConnectivity>(c => Connectivity.Current);
            //add geolocation service
            builder.Services.AddSingleton<IGeolocation>(c => Geolocation.Default);
            //add geocoding service
            builder.Services.AddSingleton<IGeocoding>(c => Geocoding.Default);

            return builder.Build();
        }
    }
}
