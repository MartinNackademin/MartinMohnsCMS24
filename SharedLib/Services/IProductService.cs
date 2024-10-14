using Shared.Models;

namespace Shared.Services
{
    public interface IProductService
    {
        bool AddToList(Product product);
        IEnumerable<Product> GetProducts();
    }
}