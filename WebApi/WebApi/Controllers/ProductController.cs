using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private ProductRepository repo = new ProductRepository();
        public IEnumerable<Product> GetAll()
        {
            return repo.GetAll();
        }
    }
}
