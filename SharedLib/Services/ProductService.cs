using Newtonsoft.Json;
using Shared.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text.Json.Serialization;
namespace Shared.Services;

public class ProductService : IProductService
{
    private List<Product> _products = new List<Product>();
    private readonly FileService _fileService;

    public ProductService(FileService fileService)
    {
        _fileService = fileService;

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
                return false;
            }
            Debug.WriteLine("Duplicate name detected");
            _products.Add(product);
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
        Debug.WriteLine("HEY you just added a product we currently have this many products " + _products.Count);
        return _products;

    }

    public void DeleteProduct(Product product) // Delete product from list, save the changes of the list
    {
        _products.Remove(product);
//        _fileService.SaveToFile(JsonConvert.SerializeObject(_products));
        Debug.WriteLine("Product has been deleted");
    }
}
