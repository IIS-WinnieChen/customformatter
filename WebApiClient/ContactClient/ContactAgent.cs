using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApi.Formatter;
using WebApi.Models;

namespace WebApiClient
{
    public class ContactAgent
    {
        private HttpClient client;

        public ContactAgent()
            // : this("http://entityframework.azurewebsites.net/")
            : this("http://localhost.fiddler:51541/")
        {
        }

        public ContactAgent(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/x-vcard"));
        }

        public async Task<List<Contact>> GetContacts()
        {
            var response = await client.GetAsync("api/contact");
            if (response.IsSuccessStatusCode)
            {
                var c = await response.Content.ReadAsAsync<List<Contact>>(new[] { new VCardCustomFormatter() });
                return c;
            }
            return null;
        }
    }
}