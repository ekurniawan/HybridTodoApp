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
    public IEnumerable<ConnectionProfile> ConnectionProfiles => new List<ConnectionProfile> { ConnectionProfile.Unknown };
    public NetworkAccess NetworkAccess => NetworkAccess.Internet; // Assume internet is available in web browser

    public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;
}

public class BlazorGeolocation : IGeolocation
{
    public bool IsListeningForeground => false;

    public event EventHandler<GeolocationLocationChangedEventArgs>? LocationChanged;
    public event EventHandler<GeolocationListeningFailedEventArgs>? ListeningFailed;

    public Task<Location?> GetLastKnownLocationAsync()
    {
        // Return null since we can't get last known location in web browser without user permission
        return Task.FromResult<Location?>(null);
    }

    public Task<Location?> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken = default)
    {
        // For web browsers, geolocation requires JavaScript APIs that aren't directly available
        // Return null to indicate location is not available
        return Task.FromResult<Location?>(null);
    }

    public Task<bool> StartListeningForegroundAsync(GeolocationListeningRequest request)
    {
        // Not supported in web browsers through this interface
        return Task.FromResult(false);
    }

    public void StopListeningForeground()
    {
        // Nothing to stop
    }
}

public class BlazorGeocoding : IGeocoding
{
    public Task<IEnumerable<Location>> GetLocationsAsync(string address)
    {
        // Geocoding is not available in this web implementation
        return Task.FromResult(Enumerable.Empty<Location>());
    }

    public Task<IEnumerable<Placemark>> GetPlacemarksAsync(double latitude, double longitude)
    {
        // Reverse geocoding is not available in this web implementation
        return Task.FromResult(Enumerable.Empty<Placemark>());
    }
}