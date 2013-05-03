using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace ProductClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var agent = new ProductAgent();
            foreach (var p in agent.GetProducts().Result)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
