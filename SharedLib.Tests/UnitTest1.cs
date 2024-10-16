
namespace SharedLib.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
        
        }


        public class ProductServiceTests
        {
            [Fact]
            public void AddToList_ShouldAddProductToList()
            {
                // Arrange
                var productService = new ProductService();
                var product = new Product();

                // Act
                productService.AddToList(product);

                // Assert
                Assert.Contains(product, productService.GetProducts());
            }
        }
        {
            [Fact] // This attribute marks this method as a test.
            public void ShouldAddTwoNumbers()
            {
                // Arrange
                int a = 3;
                int b = 5;

                // Act
                int result = a + b;

                // Assert
                Assert.Equal(8, result); // Check if the result is as expected.
            }
        }
}