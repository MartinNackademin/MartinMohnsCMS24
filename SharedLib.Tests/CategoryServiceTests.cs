using Shared.Models;
using Shared.Services;
using SharedLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public void GiveCategory_ProductShouldBeGivenCorrectCategory()
        {
            // Arrange
            var _categoryService = new CategoryService();

            var product1 = new Product
            {
                Name = "Test Product 1",
                Price = "10",
                Category = "Object:Games"
            };

            var product2 = new Product
            {
                Name = "Test Product 2",
                Price = "10",
                Category = "Object:Pets"
            };

            var product3 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Object:Foods"
            };

            var product4 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Object:Others"
            };

            var product5 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Some Nonesense that doesnt make any sense its just some craaaaaaaaaaaazy value"
            };



            // Act
            _categoryService.GiveCategory(product1);
            _categoryService.GiveCategory(product2);
            _categoryService.GiveCategory(product3);
            _categoryService.GiveCategory(product4);
            _categoryService.GiveCategory(product5);
            // Assert
            Assert.Equal("Games", product1.Category);
            Assert.Equal("Pets", product2.Category);
            Assert.Equal("Foods", product3.Category);
            Assert.Equal("Others", product4.Category);
            Assert.Equal("Others", product5.Category);
        }

        [Fact]
        public void FilterList_ShouldGiveCorrectlyFilteredList()
        {
            // Arrange
            var _categoryService = new CategoryService();

            var product1 = new Product
            {
                Name = "Test Product 1",
                Price = "10",
                Category = "Object:Games"
            };

            var product2 = new Product
            {
                Name = "Test Product 2",
                Price = "10",
                Category = "Object:Pets"
            };

            var product3 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Object:Foods"
            };

            var product4 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Object:Others"
            };

            var product5 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Some Nonesense that doesnt make any sense its just some craaaaaaaaaaaazy value"
            };

            var ListToBeFiltered = new List<Product>
            {
                product1,
                product2,
                product3,
                product4,
                product5
            };

            // Act
            var gamesList = _categoryService.FilterList("Games", ListToBeFiltered);
            var petsList = _categoryService.FilterList("Pets", ListToBeFiltered);
            var foodsList = _categoryService.FilterList("Foods", ListToBeFiltered);
            var othersList = _categoryService.FilterList("Others", ListToBeFiltered);
            var allList = _categoryService.FilterList("All", ListToBeFiltered);
            var unkownList = _categoryService.FilterList("Some Unkown Category", ListToBeFiltered);
            // Assert

            // Games Filterlist checks //
            Assert.Contains(product1, gamesList);
            Assert.DoesNotContain(product2, gamesList);
            Assert.DoesNotContain(product3, gamesList);
            Assert.DoesNotContain(product4, gamesList);
            Assert.DoesNotContain(product5, gamesList);

            // Pets Filterlist checks //
            Assert.Contains(product2, petsList);
            Assert.DoesNotContain(product1, petsList);
            Assert.DoesNotContain(product3, petsList);
            Assert.DoesNotContain(product4, petsList);
            Assert.DoesNotContain(product5, petsList);


            // Foods Filterlist checks //
            Assert.Contains(product3, foodsList);
            Assert.DoesNotContain(product1, foodsList);
            Assert.DoesNotContain(product2, foodsList);
            Assert.DoesNotContain(product4, foodsList);
            Assert.DoesNotContain(product5, foodsList);


            // Others Filterlist checks //
            Assert.Contains(product4, othersList);
            Assert.Contains(product5, othersList);
            Assert.DoesNotContain(product1, othersList);
            Assert.DoesNotContain(product2, othersList);
            Assert.DoesNotContain(product3, othersList);

            // All Filterlist checks //
            Assert.Contains(product1, allList);
            Assert.Contains(product2, allList);
            Assert.Contains(product3, allList);
            Assert.Contains(product4, allList);
            Assert.Contains(product5, allList);

            // unkown Filterlist checks //
            Assert.Contains(product1, unkownList);
            Assert.Contains(product2, unkownList);
            Assert.Contains(product3, unkownList);
            Assert.Contains(product4, unkownList);
            Assert.Contains(product5, unkownList);
        }
    }
}
