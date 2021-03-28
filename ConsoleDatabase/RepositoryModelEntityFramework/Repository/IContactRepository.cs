using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryModelEntityFramework.Model;

namespace RepositoryModelEntityFramework.Repository
{
    interface IContactRepository 
    {
         List<Contact> GetContacts();
         List<Contact> SearchContacts(string name);
         void AddContact(Contact c);
         void EditContact(int choice, int id, string Modification);
         void DeleteContact(int id);
    }
}
