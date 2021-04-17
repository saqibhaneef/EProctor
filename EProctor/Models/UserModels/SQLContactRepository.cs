using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Models.UserModels
{
    public class SQLContactRepository : IContactRepository
    {
        private AppDbContext context;

        public SQLContactRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Contact Add(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return contact;
        }

        public Contact Delete(int id)
        {
            Contact contact = context.Contacts.Find(id);
            if(context!=null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
                
            }
            return contact;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return context.Contacts;
        }

        public Contact GetContact(int id)
        {
            return context.Contacts.Find(id);
        }
    }
}
