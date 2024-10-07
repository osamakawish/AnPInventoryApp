using AnPInventoryApp.Models;
using AnPInventoryAvalonia.ViewModels;
using AnPInventoryAvalonia.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Input;
using System;

namespace AnPInventoryAvalonia;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
            desktop.MainWindow.AttachDevTools();
        }

        base.OnFrameworkInitializationCompleted();
    }

    /// <summary>
    /// Assigns all the necessary commands to the view model.
    /// </summary>
    /// <param name="mainWindow"></param>
    /// <param name="mainWindowViewModel"></param>
    /// <!--The mainwindow and its viewmodel are both passed as parameters separately to avoid null checks.
    /// DO NOT remove the mainWindowViewModel parameter to access it view mainWindow.DataContext.-->
    private static void AssignCommands(MainWindow mainWindow, MainWindowViewModel mainWindowViewModel)
    {
        // NOTE: This won't work. Seems to cause issues as it doesn't enable the buttons.

        
    }
}