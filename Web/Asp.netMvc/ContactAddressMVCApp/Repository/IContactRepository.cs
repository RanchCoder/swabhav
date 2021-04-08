using ContactAddressMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAddressMVCApp.Repository
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        List<Contact> SearchContacts(string name);
        void AddContact(Contact c);
        void EditContact(int choice, int id, string Modification);
        bool DeleteContact(int id);
        Contact GetContactById(int id);
        bool IntializeContact();
    }
}
