using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HybridTodoApp.Components.Data;
using HybridTodoApp.WinForms.Services;

namespace HybridTodoApp.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var host = CreateHostBuilder().Build();
        
        using (var scope = host.Services.CreateScope())
        {
            var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddWindowsFormsBlazorWebView();
                
#if DEBUG
                services.AddBlazorWebViewDeveloperTools();
                services.AddLogging(builder => builder.AddDebug());
#endif

                // Register services
                services.AddSingleton<TodoService>();
                services.AddSingleton<Microsoft.Maui.Networking.IConnectivity, WinFormsConnectivity>();
                services.AddSingleton<Microsoft.Maui.Devices.Sensors.IGeolocation, WinFormsGeolocation>();
                services.AddSingleton<Microsoft.Maui.Devices.Sensors.IGeocoding, WinFormsGeocoding>();
                
                // Register the main form
                services.AddTransient<MainForm>();
            });
    }
}