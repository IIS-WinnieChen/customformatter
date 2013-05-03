using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using WebApi.Models;

namespace WebApi.Formatter
{
    public class VCardCustomFormatter : MediaTypeFormatter
    {
        public VCardCustomFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/x-vcard")); 
        }
        public override bool CanReadType(Type type)
        {
            return type.FullName.Contains("Contact");
        }

        public override bool CanWriteType(Type type)
        {
            return type.FullName.Contains("Contact");
        }

        public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, System.IO.Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            var task = new TaskCompletionSource<object>();
            var contacts = new List<Contact>();

            StreamReader reader = new StreamReader(readStream);
            while(!reader.EndOfStream)
            {
                var contactData = reader.ReadLine().Split(',');
                contacts.Add(new Contact() {Id = Int32.Parse(contactData[0]), Name = contactData[1] });
            }

            task.SetResult(contacts);
            return task.Task;
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            return Task.Factory.StartNew(() => WriteVCard((IEnumerable<Contact>) value, writeStream));
        }

        private void WriteVCard(IEnumerable<Contact> contacts, System.IO.Stream writeStream)
        {
            foreach (var c in contacts)
            {
                using (var writer = new StreamWriter(writeStream))
                {
                    writer.Write("{0},{1}\r\n", c.Id, c.Name);
                }
            }
        }
    }
}