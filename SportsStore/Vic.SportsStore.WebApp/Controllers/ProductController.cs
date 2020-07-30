using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;

namespace Vic.SportsStore.WebApp.Controllers
{    public class ProductController : Controller
    {
        // GET: Product
        //public IProductsRepository ProductsRepository { get; set; }

        //through "constructor method" by "Dependence injection", constructor or property injection.
        //property injection use "_productsRepository"; constructor use "ProductsRepository".
        private IProductsRepository _productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ViewResult List()
        {
            //var model = ProductsRepository.Products;
            var model = _productsRepository.Products;
            return View(model);
        }

    }
}