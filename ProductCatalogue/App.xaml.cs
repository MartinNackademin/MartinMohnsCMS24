﻿using Microsoft.Extensions.DependencyInjection;
using ProductCatalogue.ViewModels;
using ProductCatalogue.Views;
using Shared.Services;
using SharedLib.Services;
using System.IO;
using System.Windows;

namespace ProductCatalogue;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application // Dependency Injection
{

    public static IServiceProvider? ServiceProvider { get; private set; }
    private void ConfigureServices(IServiceCollection services)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDirectory, "ProductData.json");


        services.AddSingleton<IProductService, ProductService>();
        services.AddSingleton<IFileService>(new FileService(filePath));
        services.AddTransient<ICategoryService, CategoryService>();

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<MainWindow>();

        services.AddTransient<OverViewViewModel>();
        services.AddTransient<OverviewView>();

        services.AddTransient<CreateViewModel>();
        services.AddTransient<CreateView>();

        services.AddTransient<EditViewModel>();
        services.AddTransient<EditView>();

        services.AddTransient<AddUserWindowViewModel>();
        services.AddTransient<AddUserWindow>();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        ServiceCollection serviceCollection = new();
        ConfigureServices(serviceCollection);
        
        ServiceProvider = serviceCollection.BuildServiceProvider();

        MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        MainWindow.DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>();
        MainWindow.Show();
        base.OnStartup(e);
    }
}