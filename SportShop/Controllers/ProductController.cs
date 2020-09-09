using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;
using SportShop.Models.ViewModels;


namespace SportShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }



        public ViewResult List(int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemPerPage = PageSize,
                    TotalItem = repository.Products.Count()
                }
            });
            
        
    }
}