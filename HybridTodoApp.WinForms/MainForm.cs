using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HybridTodoApp.Components.Data;

namespace HybridTodoApp.WinForms;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public MainForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
        
        var blazorWebView = new BlazorWebView()
        {
            Dock = DockStyle.Fill,
            HostPage = "wwwroot/index.html",
            Services = serviceProvider
        };
        
        blazorWebView.RootComponents.Add(new RootComponent("#app", typeof(Components.App), null));

        Controls.Add(blazorWebView);
    }

    private void InitializeComponent()
    {
        Text = "HybridTodoApp - Windows Forms";
        Size = new Size(1200, 800);
        StartPosition = FormStartPosition.CenterScreen;
    }
}