using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShapesApp.Configuration;
using ShapesApp.Rendering;
using ShapesApp.Services;
using ShapesApp.ViewModels;
using ShapesApp.Views;

namespace ShapesWpfApp;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    private void Application_Startup(object sender, StartupEventArgs e)
    {   
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var shapesOptions = configuration
            .GetSection("ShapesLayout")
            .Get<ShapesLayoutOptions>()
            ?? throw new InvalidOperationException("Секция ShapesLayout в конфиге не найдена.");

        var services = new ServiceCollection();

        services.AddSingleton(shapesOptions);

        services.AddSingleton<IBrightColorService, BrightColorService>();
        services.AddSingleton<IShapesFactory, ShapesFactory>();
        services.AddSingleton<IShapesRenderer, ShapesRenderer>();

        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<MainWindow>();

        Services = services.BuildServiceProvider();

        var mainWindow = Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}