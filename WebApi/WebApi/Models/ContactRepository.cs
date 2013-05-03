using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ContactRepository
    {
        private List<Contact> repo = new List<Contact>();
        public ContactRepository()
        {
            repo.Add(new Contact() { Id = 0, Name = "Youngjune Hong" }); 
            repo.Add(new Contact() { Id = 0, Name = "Bruce Lee" }); 
            repo.Add(new Contact() { Id = 0, Name = "Mitt Gilman" }); 
        }
        public IEnumerable<Contact> GetAll()
        {
            return repo;
        }
    }
}