using Newtonsoft.Json;
using Shared.Models;
using SharedLib.Services;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text.Json.Serialization;
namespace Shared.Services;

public class ProductService : IProductService
{
    private List<Product> _products = new List<Product>();
    private readonly ICategoryService _categoryService;
    private readonly IFileService _fileService;

    public Product? currentProduct { get; set; }

    public ProductService(IFileService fileService, ICategoryService categoryService)
    {
        _fileService = fileService;
        _categoryService = categoryService;
    }

    public bool AddToList(Product product) // Add product to list , save the changes of the list and return true if success
    {
        try                   // Need to get better at lambda expressions 
        {
            bool duplicateDetected = false;
            foreach (Product item in _products)  // duplication checker 
            {
                if (item.Name.ToLower() == product.Name.ToLower()) // makes sure capitalization does not matter
                {
                    Debug.WriteLine("Duplicate name detected");
                    duplicateDetected = true;  // maybe not needed at all i mean im already returning false if duplicate is detected
                    break;
                }

            }
            if (duplicateDetected == true) // if duplicate is detected return false not sure i need this?
            {
                Debug.WriteLine("Duplicate name detected");
                return false;
            }
            _categoryService.GiveCategory(product);
            _products.Add(product); Debug.WriteLine("Product added to real list");
            _fileService.SaveToFile((JsonConvert.SerializeObject(_products)));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<Product> GetProducts() // Get list of products, Set List of products to the list from the file and return the list
    {
        var jsonProductList = _fileService.GetFromFile();

        if (string.IsNullOrEmpty(jsonProductList)) // check if you have a list of products if you dont have a list of products return the current list of products
        {
            Debug.WriteLine("No products found returning the list empty");
            return _products;
        }
        Debug.WriteLine("ProductList was found ");
        List<Product> tempList = JsonConvert.DeserializeObject<List<Product>>(jsonProductList)!;
        _products = tempList;
        Debug.WriteLine("the current list has this many objects in it " + _products.Count);
        return _products;

    }

    public void DeleteProduct(Product product) // Delete product from list, save the changes of the list
    {
        foreach (Product productInList in _products)
        {
            if (product.Id == productInList.Id)
            {
                currentProduct = productInList;
                Debug.WriteLine("Product that user wants to  delete has been found" + $"   {productInList.Name}");
            }

        }
        _products.Remove(currentProduct!);
        _fileService.SaveToFile(JsonConvert.SerializeObject(_products));

    }

    public Product Update(Product updatedProduct) //  this is terrible
    {                                              //

        foreach (Product productInList in _products)
        {
            if (currentProduct!.Id == productInList.Id)
            {
                _products.Remove(productInList);
               bool success = AddToList(updatedProduct);
                if (success)
                {
                    return updatedProduct;
                }
                else 
                {
                    _products.Add(productInList);
                    return updatedProduct;
                }  

            }
        }
        return updatedProduct;
    }
}
