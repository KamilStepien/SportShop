using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

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



        public ViewResult List(int productpage = 1)
            => View(repository.Products
            .OrderBy(p => p.ProductId)
            .Skip((productpage - 1) * PageSize)
            .Take(PageSize));
        
    }
}