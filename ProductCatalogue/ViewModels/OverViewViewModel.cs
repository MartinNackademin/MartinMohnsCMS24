using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Shared.Models;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using ProductCatalogue.Views;
using SharedLib.Services;
using Shared.Services;

namespace ProductCatalogue.ViewModels;

public partial class OverViewViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public OverViewViewModel(IServiceProvider serviceProvider, IProductService productService, ICategoryService categoryService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
        _categoryService = categoryService;
        UpdateProductList();

    }




    [ObservableProperty]
    private ObservableCollection<Product> productlist = new ObservableCollection<Product>();

    [ObservableProperty]
    private Product selectedProduct = null!;


    [RelayCommand]
    public void AddProduct()
    {

        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CreateViewModel>();

        Debug.WriteLine("addproduct has been called");  // creating a new window is a job for the ViewModel.
                                                        // However, neither the View nor the ViewModel should know how exactly to create a Window,
                                                        // that's not part of their responsibilities and belongs to a different class.
                                                        // work on making a new window that will be created when the button is clicked
    }

    [RelayCommand]
    public void DeleteProduct()
    {
        Debug.WriteLine("deleteproduct has been called");
        if (SelectedProduct != null)
        {
            _productService.DeleteProduct(SelectedProduct);
            UpdateProductList();
            Debug.WriteLine("Hey i just deleted a product and tried to update the list");
        }

    }

    [RelayCommand]
    public void EditProduct(Product product)
    {
        if (SelectedProduct != null)
        {
            Debug.WriteLine("editproduct has been called the object name that you have selected is " + SelectedProduct.Name);
            var editViewModel = _serviceProvider.GetRequiredService<EditViewModel>();
            var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditViewModel>();
            _productService.currentProduct = product;
        }

    }
    [RelayCommand]
    public void Hans()
    {
        Debug.WriteLine("HANS COMMAND HAS BEEN CALLED DELETE EVERYTHING NOW");

    }

    [RelayCommand]
    public void FilterList(string filterType)
    {
        List<Product> listofAllproducts = [];
        foreach (var product in _productService.GetProducts())
        {
            listofAllproducts.Add(product);
        }

        List<Product> templist = _categoryService.FilterList(filterType, listofAllproducts);
        UpdateProductList(templist);
        templist.Clear();
    }


    public void UpdateProductList()
    {
        Productlist.Clear();
        foreach (var product in _productService.GetProducts())
        {
            Productlist.Add(product);
        }
        Debug.WriteLine("Added finished , im ID 2");
    }

    public void UpdateProductList(List<Product> listOfProducts)
    {

        Productlist.Clear();
        foreach (var product in listOfProducts)
        {
            Productlist.Add(product);
        }
        _categoryService.ClearCategoryLists();
        Debug.WriteLine("Added finished , im ID 1");
    }
}
