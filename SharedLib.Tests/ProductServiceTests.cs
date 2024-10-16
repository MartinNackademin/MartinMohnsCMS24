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
    public class ProductServiceTests
    {

        [Fact]
        public void AddToList_ShouldAddProductToList()
        {
            // Arrange
            var _categoryService = new CategoryService();
            var _fileService = new FileService("");
            var _productService = new ProductService(_fileService, _categoryService);

            var product = new Product
            {
                Name = "Test Product",
                Price = "10",
                Category = "Foods"
            };

            // Act
            _productService.AddToList(product);

            // Assert
            Assert.Contains(product, _productService.GetProducts());
            Assert.Contains(product, _productService.GetProducts());
        }



        [Fact]
        public void AddToList_Duplication_ShouldNotAddProductToList()
        {
            // Arrange
            var _categoryService = new CategoryService();
            var _fileService = new FileService("");
            var _productService = new ProductService(_fileService, _categoryService);

            var product1 = new Product
            {
                Name = "Test Product",
                Price = "10",
                Category = "Foods"
            };

            var product2 = new Product
            {
                Name = "Test Product",
                Price = "10",
                Category = "Foods"
            };


            // Act
            _productService.AddToList(product1);
            _productService.AddToList(product2);

            // Assert
            Assert.Contains(product1, _productService.GetProducts());
            Assert.DoesNotContain(product2, _productService.GetProducts());
        }
        [Fact]
        public void GetProducts_ShouldGiveProductList()
        {
            // Arrange
            var _categoryService = new CategoryService();
            var _fileService = new FileService("");
            var _productService = new ProductService(_fileService, _categoryService);

            var product1 = new Product
            {
                Name = "Test Product 1",
                Price = "10",
                Category = "Others"
            };

            var product2 = new Product
            {
                Name = "Test Product 2",
                Price = "10",
                Category = "Foods"
            };

            var product3 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Games"
            };


            // Act
            _productService.AddToList(product1);
            _productService.AddToList(product2);
            _productService.AddToList(product3);
            var productsList = _productService.GetProducts();



            // Assert
            Assert.Contains(product1, _productService.GetProducts());
            Assert.Contains(product2, _productService.GetProducts());
            Assert.Contains(product3, _productService.GetProducts());
        }

        [Fact]
        public void DeleteProduct_ShouldDeleteProductFromlist()
        {
            // Arrange
            var _categoryService = new CategoryService();
            var _fileService = new FileService("");
            var _productService = new ProductService(_fileService, _categoryService);

            var product1 = new Product
            {
                Name = "Test Product 1",
                Price = "10",
                Category = "Others"
            };

            var product2 = new Product
            {
                Name = "Test Product 2",
                Price = "10",
                Category = "Foods"
            };

            var product3 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Games"
            };


            // Act
            _productService.AddToList(product1);
            _productService.AddToList(product2);
            _productService.AddToList(product3);
            _productService.DeleteProduct(product2);


            // Assert
            Assert.Contains(product1, _productService.GetProducts());
            Assert.DoesNotContain(product2, _productService.GetProducts());
            Assert.Contains(product3, _productService.GetProducts());
        }
        [Fact]
        public void UpdateProduct_ShouldUpdateProduct()
        {
            // Arrange
            var _categoryService = new CategoryService();
            var _fileService = new FileService("");
            var _productService = new ProductService(_fileService, _categoryService);

            var product1 = new Product
            {
                Name = "Test Product 1",
                Price = "10",
                Category = "Others"
            };

            var product2 = new Product
            {
                Name = "Test Product 2",
                Price = "10",
                Category = "Foods"
            };

            var product3 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Games"
            };


            // Act
            _productService.AddToList(product1);
            _productService.AddToList(product2);
            _productService.AddToList(product3);
            _productService.currentProduct = product2; // user selected product

            product2.Name = "Test Product 2 Updated";

            _productService.Update(product2); // users updated product


            // Assert
            Assert.Contains(product1, _productService.GetProducts());
            Assert.Contains(product2, _productService.GetProducts());
            Assert.Contains(product3, _productService.GetProducts());
            Assert.Equal("Test Product 2 Updated", product2.Name);

        }
        [Fact]
        public void FilterList_ShouldGiveBackACorrectlyFilteredList()
        {
            // Arrange
            var _categoryService = new CategoryService();
            var _fileService = new FileService("");
            var _productService = new ProductService(_fileService, _categoryService);

            var product1 = new Product
            {
                Name = "Test Product 1",
                Price = "10",
                Category = "Others"
            };

            var product2 = new Product
            {
                Name = "Test Product 2",
                Price = "10",
                Category = "Foods"
            };

            var product3 = new Product
            {
                Name = "Test Product 3",
                Price = "10",
                Category = "Games"
            };


            // Act
            _productService.AddToList(product1);
            _productService.AddToList(product2);
            _productService.AddToList(product3);
            _productService.currentProduct = product3; // product 3 is the User selected product
            
            var userUpdatedProduct = new Product
            {
                Name = "Test Product 1",
                Price = "10",
                Category = "Foods"
            };
            _productService.Update(userUpdatedProduct); // I want to update User selected product to this product

            var productsList = _productService.GetProducts().ToList();

            // Assert
            Assert.Equal("Test Product 3", productsList[2].Name);  // should not let you update because duplication

        }


    }




}
