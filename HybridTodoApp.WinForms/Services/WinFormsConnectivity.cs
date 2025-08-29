using Microsoft.Maui.Networking;

namespace HybridTodoApp.WinForms.Services;

public class WinFormsConnectivity : IConnectivity
{
    public IEnumerable<ConnectionProfile> ConnectionProfiles => new List<ConnectionProfile> { ConnectionProfile.WiFi };
    
    public NetworkAccess NetworkAccess
    {
        get
        {
            try
            {
                return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() 
                    ? NetworkAccess.Internet 
                    : NetworkAccess.None;
            }
            catch
            {
                return NetworkAccess.Unknown;
            }
        }
    }

    public event EventHandler<ConnectivityChangedEventArgs>? ConnectivityChanged;
}