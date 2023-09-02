using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controller_View.Controllers
{
    public class FirstController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public FirstController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            ViewBag.Key1 = "value 1";
            ViewBag.Key2 = "value 2";

            List<string> cars = new List<string>(){
                "Mercedes",
                "BMW",
                "Audi",
                "Lamborghini",
            };

            return View(cars);
        }
        public IActionResult Car()
        {

            var ImgPath = Path.Combine(_env.ContentRootPath, "Files", "car.jpeg");

            var bytes = System.IO.File.ReadAllBytes(ImgPath);

            return File(bytes, "image/jpeg");
        }
    }
}