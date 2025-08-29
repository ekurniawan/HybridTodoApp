using Microsoft.Maui.Devices.Sensors;

namespace HybridTodoApp.WinForms.Services;

public class WinFormsGeocoding : IGeocoding
{
    public Task<IEnumerable<Location>> GetLocationsAsync(string address)
    {
        // Geocoding is not available in this Windows Forms implementation
        // You would need to integrate with a geocoding service like Bing Maps, Google Maps, etc.
        return Task.FromResult(Enumerable.Empty<Location>());
    }

    public Task<IEnumerable<Placemark>> GetPlacemarksAsync(double latitude, double longitude)
    {
        // Reverse geocoding is not available in this Windows Forms implementation
        return Task.FromResult(Enumerable.Empty<Placemark>());
    }
}