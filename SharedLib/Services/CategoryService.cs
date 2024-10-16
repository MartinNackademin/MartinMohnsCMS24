using Shared.Models;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Services
{
    public class CategoryService : ICategoryService
    {
        private List<Product> _categoryGames = new List<Product>();
        private List<Product> _categoryPets = new List<Product>();
        private List<Product> _categoryFoods = new List<Product>();
        private List<Product> _categoryOthers = new List<Product>();

        public CategoryService()
        {
        }

        public void GiveCategory(Product product)
        {
            product.Category = product.Category.Substring(product.Category.IndexOf(":") + 1).Trim();

            Debug.WriteLine($"Meow the new string of the product category is now{product.Category} ");
            switch (product.Category)
            {
                case "Games":
                    Debug.WriteLine("Category has been set to Games");
                    _categoryGames.Add(product);
                    break;
                case "Pets":
                    _categoryPets.Add(product);
                    Debug.WriteLine("Category has been set to Pets");
                    break;
                case "Foods":
                    _categoryFoods.Add(product);
                    Debug.WriteLine("Cataegory has been set to Foods");
                    break;

                default: 
                case "Others":
                    product.Category = "Others";
                    _categoryOthers.Add(product);
                    Debug.WriteLine("Category was set to Others");
                    break;
            }
        }

        public void ClearCategoryLists()
        {
            _categoryGames.Clear();
            _categoryPets.Clear();
            _categoryFoods.Clear();
            _categoryOthers.Clear();
        }

        public List<Product> FilterList(string filterType, List<Product> productsToBeFiltered)
        {
            foreach (Product product in productsToBeFiltered)
            {
                GiveCategory(product);
            }
            switch (filterType)
            {
                case "Games":
                    Debug.WriteLine("Category that you want is games");
                    return _categoryGames;
                case "Pets":

                    Debug.WriteLine("Category has been set to Pets");
                    return _categoryPets;
                case "Foods":
                    Debug.WriteLine("Cataegory has been set to Foods");
                    return _categoryFoods;
                case "Others":
                    Debug.WriteLine("Cataegory has been set to Others");
                    return _categoryOthers;

                default:
                case "All":
                    Debug.WriteLine("Category was set to All");
                    return productsToBeFiltered;
            
            }



        }


    }
}
