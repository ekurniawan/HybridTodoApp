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
    public IEnumerable<ConnectionProfile> ConnectionProfiles => throw new NotImplementedException();
    public NetworkAccess NetworkAccess => throw new NotImplementedException();

    public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;
}

public class BlazorGeolocation : IGeolocation
{
    public bool IsListeningForeground => throw new NotImplementedException();

    public event EventHandler<GeolocationLocationChangedEventArgs>? LocationChanged;
    public event EventHandler<GeolocationListeningFailedEventArgs>? ListeningFailed;

    public Task<Location?> GetLastKnownLocationAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Location?> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StartListeningForegroundAsync(GeolocationListeningRequest request)
    {
        throw new NotImplementedException();
    }

    public void StopListeningForeground()
    {
        throw new NotImplementedException();
    }
}

public class BlazorGeocoding : IGeocoding
{
    public Task<IEnumerable<Location>> GetLocationsAsync(string address)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Placemark>> GetPlacemarksAsync(double latitude, double longitude)
    {
        throw new NotImplementedException();
    }
}