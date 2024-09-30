using AnPInventoryApp.ViewModels;
using AnPInventoryApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AnPInventoryApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();
        base.OnExit(e);
    }
}
