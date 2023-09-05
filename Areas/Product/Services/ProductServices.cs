using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controller_View.Areas.Product.Models;

namespace Controller_View.Areas.Product.Services
{
    public class ProductServices : List<ProductModel>
    {
        public ProductServices()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() { Id = 1, Name = "Iphone", Price = 1000 },
            new ProductModel() { Id = 2, Name = "Nokia", Price = 600 },
            new ProductModel() { Id = 3, Name = "SamSung", Price = 800 },
            new ProductModel() { Id = 4, Name = "Oppo", Price = 700 }
            });
        }


    }
}