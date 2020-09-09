using System;
using Xunit;
using Moq;
using SportShop.Controllers;
using SportShop.Models;
using System.Linq;
using System.Collections.Generic;
using SportShop.Models.ViewModels;

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

            ProductsListViewModel result = controller.List(2).ViewData.Model as ProductsListViewModel;

            Product[] proArry = result.Products.ToArray();

            Assert.True(proArry.Length == 2);
            Assert.Equal("P4", proArry[0].Name);
            Assert.Equal("P5", proArry[1].Name);

        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
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

            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

            ProductsListViewModel result = controller.List(2).ViewData.Model as ProductsListViewModel;

            PagingInfo pagingInfo = result.PagingInfo;

            Assert.Equal(2, pagingInfo.CurrentPage);
            Assert.Equal(3, pagingInfo.ItemPerPage);
            Assert.Equal(5, pagingInfo.TotalItem);
            Assert.Equal(2, pagingInfo.TotalPages);

        }
        }
}
