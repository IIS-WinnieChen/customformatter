using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products.Add(new Product() { Id = 0, Name = "Giant Reigin X1" });
            products.Add(new Product() { Id = 0, Name = "Specialized Globe Sport" });
            products.Add(new Product() { Id = 0, Name = "Novara Duster" });
            products.Add(new Product() { Id = 0, Name = "GT Sensor 2.0" });
        }
        public IEnumerable<Product> GetAll()
        {
            return products;
        }
    }
}