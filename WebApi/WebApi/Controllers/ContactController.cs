using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository repo = new ContactRepository();

        public IEnumerable<Contact> GetAll()
        {
            return repo.GetAll();
        }
    }
}
