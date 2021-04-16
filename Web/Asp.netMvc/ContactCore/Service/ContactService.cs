using ContactCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCore.Service
{
    public class ContactService
    {
        public const bool FAILED_OPERATION = false, PASSED_OPERATION = true;
        private const int FIRSTNAME = 1;
        private const int LASTNAME = 2;
        private const int PHONENO = 3;

        public static List<Contact> Contacts = new List<Contact>();
       
        public void AddContact(Contact c)
        {
            Contacts.Add(c);

        }



        public bool DeleteContact(int id)
        {
            try
            {
                var contactToDelete = Contacts.Single(x => x.Id == id);

                Contacts.Remove(contactToDelete);

                return PASSED_OPERATION;
            }
            catch (Exception ex)
            {
                return FAILED_OPERATION;
            }

        }



        public bool EditContact(Contact contactToEdit)
        {
            try
            {
                foreach (var contact in Contacts.Where(x => x.Id == contactToEdit.Id))
                {
                     contact.Id = contactToEdit.Id;
                     contact.FirstName= contactToEdit.FirstName;
                     contact.LastName = contactToEdit.LastName;
                     contact.Address  = contactToEdit.Address;
                     contact.PhoneNo  = contactToEdit.PhoneNo;

                }
                return PASSED_OPERATION;
            }catch(Exception ex)
            {
                return FAILED_OPERATION;
            }
            
        }



        public Contact GetContactById(int id)
        {
            var contactList = Contacts.Where(x => x.Id == id).SingleOrDefault();
            return contactList;
        }

        public List<Contact> GetContacts()
        {
            return Contacts.ToList();
        }


        public List<Contact> SearchContacts(string contatName)
        {
            List<Contact> searchedContacts = new List<Contact>();
            foreach (Contact c in Contacts)
            {
                if (c.FirstName.Contains(contatName) || c.LastName.Contains(contatName))
                {
                    searchedContacts.Add(c);
                }
            }
            return searchedContacts;
        }

        public void InitializeList()
        {
            if(Contacts.Count() == 0)
            {
                Contacts.Add(new Contact() { Id = 1, FirstName="Vishal",LastName="Singh",PhoneNo=0948833,Address="Mumbai"});
            }
        }


    }
}
