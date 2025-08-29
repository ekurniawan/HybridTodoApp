# HybridTodoApp - Windows Forms Support

This project now includes Windows Forms support for the Blazor Hybrid application.

## Project Structure

- **HybridTodoApp** - .NET MAUI project (Android, iOS, macOS, Windows)
- **HybridTodoApp.Website** - ASP.NET Core Blazor Server project
- **HybridTodoApp.WinForms** - Windows Forms project with Blazor WebView
- **HybridTodoApp.Components** - Shared Blazor components

## Running the Windows Forms Application

To run the Windows Forms version of the application:

```bash
dotnet run --project HybridTodoApp.WinForms\HybridTodoApp.WinForms.csproj
```

Or from Visual Studio, set `HybridTodoApp.WinForms` as the startup project and run.

## Features

The Windows Forms version includes:

- **Full Todo Functionality**: Add, save, and manage todo items
- **Bootstrap UI**: Uses the same styling as the web version
- **Service Integration**: Windows Forms-specific implementations of MAUI services
- **Shared Components**: Uses the same Blazor components as other platforms

## Architecture

The Windows Forms application:

1. Uses `Microsoft.AspNetCore.Components.WebView.WindowsForms` to host Blazor components
2. Implements Windows Forms-specific versions of MAUI services:
   - `WinFormsConnectivity` - Network connectivity detection
   - `WinFormsGeolocation` - Location services (placeholder implementation)
   - `WinFormsGeocoding` - Geocoding services (placeholder implementation)
3. Shares the same `TodoService` and Blazor components with other platforms

## Dependencies

- .NET 9.0
- Microsoft.AspNetCore.Components.WebView.WindowsForms
- Microsoft.Maui.Essentials
- Windows Forms (.NET 9.0)

## Notes

- Location services are currently not implemented for Windows Forms
- The application uses file-based storage for todo items
- Network connectivity detection uses .NET's built-in networking APIs