using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Shared.Models;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace ProductCatalogue.ViewModels;

public partial class OverViewViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public OverViewViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;


        productlist.Add(new Product { Name = "Product1", Price = "100", Category = "Category1" });
        productlist.Add(new Product { Name = "Product2", Price = "100", Category = "Category1" });
        productlist.Add(new Product { Name = "Product3", Price = "100", Category = "Category2" });
        Debug.WriteLine("Dummy product has been added to display list");
        
    }




    [ObservableProperty]
    private ObservableCollection<Product> productlist = new ObservableCollection<Product>();

    [ObservableProperty]
    private Product selectedProduct=null!;


    [RelayCommand]
    public void AddProduct()
    {
        Debug.WriteLine("addproduct has been called");
        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
       
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CreateViewModel>();
 
        
        
        
     //      var mainWindow = viewModel as ContentControl;

     //       AddUser addUserWin = new AddUser();
     //       addUserWin.Owner = mainWindow;
     //       addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
     //       addUserWin.Show();


        


    }

    [RelayCommand]
    public void DeleteProduct()
    {
        Debug.WriteLine("deleteproduct has been called");
        if (SelectedProduct != null) 
        {
           
        }
    }

    [RelayCommand]
    public void EditProduct()
    {
        Debug.WriteLine("editproduct has been called");
    }
    [RelayCommand]
    public void Hans()
    {
        Debug.WriteLine("HANS COMMAND HAS BEEN CALLED DELETE EVERYTHING NOW");
        Debug.WriteLine($"{SelectedProduct.Name}");
    }



}
