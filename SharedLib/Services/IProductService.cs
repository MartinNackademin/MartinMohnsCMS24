using Shared.Models;

namespace Shared.Services
{
    public interface IProductService
    {
        Product? currentProduct { get; set; }

        bool AddToList(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> GetProducts();
        Product Update(Product product);
    }
}