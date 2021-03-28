using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryModelEntityFramework.Repository;
using RepositoryModelEntityFramework.Model;

namespace RepositoryModelEntityFramework.Service
{
    class ContactService
    {
        private IContactRepository contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

       public List<Contact> GetContacts()
        {
            return contactRepository.GetContacts();
        }
        public List<Contact> SearchContacts(string name)
        {
            return contactRepository.SearchContacts(name);
        }
        public void AddContact(Contact c)
        {
            contactRepository.AddContact(c);
        }
        public void EditContact(int choice, int id, string Modification)
        {
            contactRepository.EditContact(choice,id,Modification);
        }
        public void DeleteContact(int id)
        {
            contactRepository.DeleteContact(id);
        }
    }
}
