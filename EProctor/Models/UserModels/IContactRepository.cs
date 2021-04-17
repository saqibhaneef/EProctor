using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Models.UserModels
{
    public interface IContactRepository
    {
        Contact GetContact(int id);
        IEnumerable<Contact> GetAllContacts();
        Contact Add(Contact contact);
        Contact Delete(int id);
    }
}
