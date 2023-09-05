using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controller_View.Areas.Product.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controller_View.Areas.Product.Controllers
{
    [Area("Product")]
    [Route("san-pham")]
    public class ProductController : Controller
    {

        private readonly ProductServices _ProductServices;

        public ProductController(ProductServices ProductServices)
        {
            _ProductServices = ProductServices;
        }

        [Route("")]
        public IActionResult Index()
        {
            var products = _ProductServices.OrderBy(p => p.Price).ToList();

            return View(products);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult ViewProduct(int id)
        {
            var product = _ProductServices.Find(p => p.Id == id);
            return View("ViewProduct", product);
        }
    }
}