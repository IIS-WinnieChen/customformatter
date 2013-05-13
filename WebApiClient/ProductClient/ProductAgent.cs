using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class ProductAgent
    {
        private HttpClient client;

        public ProductAgent() 
            // : this("http://entityframework.azurewebsites.net/")
            : this("http://localhost:51541/")
        {
        }

        public ProductAgent(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Product>> GetProducts()
        {
            var response = await client.GetAsync("api/product");
            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadAsAsync<List<Product>>();
                return products;
            }
            return null;
        }
    }
}