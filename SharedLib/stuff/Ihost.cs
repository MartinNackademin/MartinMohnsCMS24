// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Shared.Services;
// using System.IO;
// using System.Windows;
// using static System.Net.Mime.MediaTypeNames;

// namespace ProductCatalogue;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
// public partial class App : Application // Dependency Injection
// {


    //

//    private readonly IHost _host;

  //  public App() // Builder med Host
   // {
    //    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
     //   string filePath = Path.Combine(baseDirectory, "ProductData.json");

//        _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
  //      {
    //        services.AddSingleton<ProductService>();//  Singleton: samma instans över hela applikationen , om jag hyr en bil och lämnar tillbaka den så kan någon annan hyra samma bil med samma skräp
      //                                              //    services.AddTransient<FileService>(); // Om du vill ha en ny instans hela tiden så använder du Transient du låter applikationen ta hand om instansiering varje gång du behöver en ny instans
        //    services.AddSingleton<FileService>(new FileService(filePath)); // Fileservice behöver en parameter, vart ska filen ligga, Base directory + om vi vill ändra filepath under runtime så måste vi skapa en metod som ändrar filepathen i vår instansierade singleton 
        //
          //  services.AddSingleton<MainWindow>();

      //  }).Build();
   // }
  //  protected override async void OnStartup(StartupEventArgs e)
   // {
    //    base.OnStartup(e); // Grund config , starta applikationen, dependencies etc , 
     //   await _host.StartAsync(); // Starta applikationen
//
  //      var mainWindow = _host.Services.GetRequiredService<MainWindow>(); // Hämtar instansierade singleton mainwindow  från builder, 
    //    mainWindow.Show(); // Visa mainwindow

//    }

// }