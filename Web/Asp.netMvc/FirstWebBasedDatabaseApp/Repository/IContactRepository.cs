using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstWebBasedDatabaseApp.Models;

namespace FirstWebBasedDatabaseApp.Repository
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        List<Contact> SearchContacts(string name);
        void AddContact(Contact c);
        void EditContact(int choice, int id, string Modification);
        void DeleteContact(int id);
        string AddContacts();
    }
}
