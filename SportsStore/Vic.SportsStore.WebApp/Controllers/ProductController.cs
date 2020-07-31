using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public IProductsRepository ProductsRepository { get; set; }

        public const int PageSize = 5;

        /*"through "constructor method" by "Dependence injection", constructor or property injection."
        "property injection use "_productsRepository"; constructor use "ProductsRepository"."*/

        /*private IProductsRepository _productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }*/

        /*public ViewResult List(int page = 1)
        {
            var model = ProductsRepository
                .Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            //var model = _productsRepository.Products;
            return View(model);
        }*/

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = ProductsRepository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    /*TotalItems = ProductsRepository
                      .Products
                      .Where(p => category == null || p.Category == category)
                      .Count()*/

                    TotalItems = category == null
                    ? ProductsRepository.Products.Count()
                    : ProductsRepository.Products.Where(e => e.Category == category).Count()
                },

                CurrentCategory = category 
            };

            return View(model);
        }

    }
}
