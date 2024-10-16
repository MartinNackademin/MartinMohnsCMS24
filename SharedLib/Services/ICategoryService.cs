using Shared.Models;

namespace SharedLib.Services
{
    public interface ICategoryService
    {
        void ClearCategoryLists();
        List<Product> FilterList(string filterType, List<Product> productsToBeFiltered);
        void GiveCategory(Product product);
    }
}