using HybridTodoApp.Components.Data;
using HybridTodoApp.Website.Components;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Networking;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<TodoService>();
builder.Services.AddSingleton<IConnectivity, BlazorConnectivity>();
builder.Services.AddSingleton<IGeolocation, BlazorGeolocation>();
builder.Services.AddSingleton<IGeocoding, BlazorGeocoding>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public class BlazorConnectivity : IConnectivity
{
    public IEnumerable<ConnectionProfile> ConnectionProfiles => new[] { ConnectionProfile.WiFi };
    public NetworkAccess NetworkAccess => NetworkAccess.Internet;

    public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;
}

public class BlazorGeolocation : IGeolocation
{
    public bool IsListeningForeground => false;

    public event EventHandler<GeolocationLocationChangedEventArgs>? LocationChanged;
    public event EventHandler<GeolocationListeningFailedEventArgs>? ListeningFailed;

    public Task<Location?> GetLastKnownLocationAsync()
    {
        return Task.FromResult<Location?>(null);
    }

    public Task<Location?> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken)
    {
        // For web, we can't access location directly, return null
        return Task.FromResult<Location?>(null);
    }

    public Task<bool> StartListeningForegroundAsync(GeolocationListeningRequest request)
    {
        return Task.FromResult(false);
    }

    public void StopListeningForeground()
    {
        // No implementation needed for web
    }
}

public class BlazorGeocoding : IGeocoding
{
    public Task<IEnumerable<Location>> GetLocationsAsync(string address)
    {
        // For web, we can't access geocoding directly, return empty collection
        return Task.FromResult(Enumerable.Empty<Location>());
    }

    public Task<IEnumerable<Placemark>> GetPlacemarksAsync(double latitude, double longitude)
    {
        // For web, we can't access geocoding directly, return empty collection
        return Task.FromResult(Enumerable.Empty<Placemark>());
    }
}