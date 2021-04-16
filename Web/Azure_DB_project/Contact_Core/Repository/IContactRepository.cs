using Contact_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Core.Repository
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        bool Update(Contact contact);
        bool Delete(int id);
        List<Contact> GetContacts();
        Contact GetContactById(int id);
        void Save();
    }
}
