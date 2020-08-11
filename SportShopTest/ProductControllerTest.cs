using System;
using Xunit;
using Moq;
using SportShop.Controllers;
using SportShop.Models;
using System.Linq;
using System.Collections.Generic;

namespace SportShopTest
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Peginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1" },
                new Product {ProductId = 2, Name = "P2" },
                new Product {ProductId = 3, Name = "P3" },
                new Product {ProductId = 4, Name = "P4" },
                new Product {ProductId = 5, Name = "P5" }

                }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;

            Product[] proArry = result.ToArray();

            Assert.True(proArry.Length == 2);
            Assert.Equal("P4", proArry[0].Name);
            Assert.Equal("P5", proArry[1].Name);

        }
    }
}
