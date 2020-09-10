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

            ProductsListViewModel result = controller.List(null,2).ViewData.Model as ProductsListViewModel;

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

            ProductsListViewModel result = controller.List(null,2).ViewData.Model as ProductsListViewModel;

            PagingInfo pagingInfo = result.PagingInfo;

            Assert.Equal(2, pagingInfo.CurrentPage);
            Assert.Equal(3, pagingInfo.ItemPerPage);
            Assert.Equal(5, pagingInfo.TotalItem);
            Assert.Equal(2, pagingInfo.TotalPages);

        }
        [Fact]
        public void Can_Filter_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
           {
                new Product {ProductId = 1, Name = "P1", Category="Cat1"},
                new Product {ProductId = 2, Name = "P2", Category="Cat2"},
                new Product {ProductId = 3, Name = "P3", Category="Cat1"},
                new Product {ProductId = 4, Name = "P4", Category="Cat2"},
                new Product {ProductId = 5, Name = "P5", Category="Cat3"}

               }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

            Product[] result = (controller.List("Cat2", 1).ViewData.Model as ProductsListViewModel).Products.ToArray();

            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");

        }



    }

        

}
