using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2Demo.Models
{
    public interface IContactRepository
    {
        IEnumerable GetAllContacts();
        Contact GetContact(string id);
        Contact AddContact(Contact item);
        bool RemoveContact(string id);
        bool UpdateContact(string id, Contact item);
    }

    public class ContactRepository : IContactRepository
    {
        List<Contact> list = new List<Contact>();
        public ContactRepository(string connection)
        {
            for (int index = 1; index < 5; index++)
            {
                Contact contact1 = new Contact
                {
                    Email = string.Format("test{0}@example.com", index),
                    Name = string.Format("test{0}", index),
                    Phone = string.Format("{0}{0}{0} {0}{0}{0} {0}{0}{0}{0}", index)
                };
                AddContact(contact1);
            }
        }

        public IEnumerable GetAllContacts()
        {
            return this.list;
        }

        public Contact GetContact(string id)
        {
            return list.FirstOrDefault(t => t.Id == id);
        }

        public Contact AddContact(Contact item)
        {
            this.list.Add(item);

            return item;
        }

        public bool RemoveContact(string id)
        {
            var item = this.list.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                return list.Remove(item);
            }

            return false;
        }

        public bool UpdateContact(string id, Contact item)
        {
            var item2 = this.list.FirstOrDefault(t => t.Id == id);
            if (item2 != null)
            {
                list.Remove(item2);
                list.Add(item);
                return true;
            }

            return false;
        }
    }
}