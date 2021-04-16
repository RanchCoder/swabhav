using ContactCore.DBContext;
using ContactCore.Model;
using ContactCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCore.Services
{
    public class ContactService
    {

        protected readonly IContactRepository contactRepository;

        protected static ContactDBContext contactDBContext = new ContactDBContext();
        public ContactService()
        {
            contactRepository = new ContactRepository(contactDBContext);
        }

        public void Add(Contact contact)
        {
            contactRepository.Add(contact);
        }
        public bool Update(Contact contact)
        {
            return contactRepository.Update(contact);
        }
        public bool Delete(int id)
        {
            return contactRepository.Delete(id);
        }
        public List<Contact> GetContacts()
        {
            return contactRepository.GetContacts();
        }

        public Contact GetContactById(int id)
        {
            return contactRepository.GetContactById(id);
        }
    }
}
