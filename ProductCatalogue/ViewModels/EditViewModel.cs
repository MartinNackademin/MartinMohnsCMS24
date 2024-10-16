using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Shared.Models;
using Shared.Services;
using System.Diagnostics;

namespace ProductCatalogue.ViewModels;

public partial class EditViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService _productService;

    public EditViewModel(IProductService productService, IServiceProvider serviceProvider)
    {
        _productService = productService;
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private Product product = new Product();

    [RelayCommand]
    public void Add()
    {
        if (Product.Name != null && Product.Category !=null  && Product.Price!=null  )
        {
            var overviewModel = _serviceProvider.GetRequiredService<OverViewViewModel>();
            overviewModel.UpdateProductList();
            _productService.Update(Product);

            var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewViewModel>();
        }
    }

    [RelayCommand]

    public void Cancel()
    {
        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverViewViewModel>();

    }
}
