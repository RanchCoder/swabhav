using Contact_Core.DBContext;
using Contact_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Core.Repository
{
    public class ContactRepository : IContactRepository
    {
        private const bool OPERTION_FAILED = false;
        private const bool OPERATION_SUCCEEDED = true;
        protected ContactDBContext _contactDBContext;
        public ContactRepository(ContactDBContext contactDBContext)
        {
            _contactDBContext = contactDBContext;
        }
        public void Add(Contact contact)
        {
            _contactDBContext.Contacts.Add(contact);
            Save();
        }

        public bool Delete(int id)
        {
            try
            {
                var contactToRemove = _contactDBContext.Contacts.Where(contact => contact.Id == id).FirstOrDefault();
                _contactDBContext.Contacts.Remove(contactToRemove);
                Save();
                return OPERATION_SUCCEEDED;

            }
            catch (Exception ex)
            {
                return OPERTION_FAILED;
            }


        }

        public List<Contact> GetContacts()
        {
            return _contactDBContext.Contacts.ToList();
        }


        public Contact GetContactById(int id)
        {
            return _contactDBContext.Contacts.Where(contact => contact.Id == id).FirstOrDefault();
        }

        public bool Update(Contact contactToUpdate)
        {
            try
            {
                foreach (var contact in _contactDBContext.Contacts.Where(c => c.Id == contactToUpdate.Id))
                {
                    contact.Id = contactToUpdate.Id;
                    contact.FirstName = contactToUpdate.FirstName;
                    contact.LastName = contactToUpdate.LastName;
                    contact.PhoneNo = contactToUpdate.PhoneNo;
                    contact.Address = contactToUpdate.Address;
                }
                Save();
                return OPERATION_SUCCEEDED;
            }
            catch (Exception ex)
            {
                return OPERTION_FAILED;
            }

        }

        public void Save()
        {
            _contactDBContext.SaveChanges();
        }

    }
}
