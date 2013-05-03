using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace ContactClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var agent = new ContactAgent();
            foreach (var p in agent.GetContacts().Result)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
