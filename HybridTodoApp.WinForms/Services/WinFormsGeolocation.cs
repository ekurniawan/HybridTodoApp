using Microsoft.Maui.Devices.Sensors;

namespace HybridTodoApp.WinForms.Services;

public class WinFormsGeolocation : IGeolocation
{
    public bool IsListeningForeground => false;

    public event EventHandler<GeolocationLocationChangedEventArgs>? LocationChanged;
    public event EventHandler<GeolocationListeningFailedEventArgs>? ListeningFailed;

    public Task<Location?> GetLastKnownLocationAsync()
    {
        // Windows Forms doesn't have built-in location services
        return Task.FromResult<Location?>(null);
    }

    public Task<Location?> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken = default)
    {
        // For Windows Forms, you would need to integrate with Windows Location API
        // For now, return null to indicate location is not available
        return Task.FromResult<Location?>(null);
    }

    public Task<bool> StartListeningForegroundAsync(GeolocationListeningRequest request)
    {
        // Not supported in this implementation
        return Task.FromResult(false);
    }

    public void StopListeningForeground()
    {
        // Nothing to stop
    }
}