using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAddressApp.Model;
using ContactAddressApp.Repository;
using ContactAddressApp.Service;
using ContactAddressApp.DatabaseContext;
namespace ContactAddressApp
{
    class Program
    {
        private const int ADD_CONTACT = 1;
        private const int EDIT_CONTACT = 2;
        private const int SEARCH_CONTACT = 3;
        private const int DELETE_CONTACT = 4;

        private const int ADD_ADDRESS = 5;
        private const int EDIT_ADDRESS = 6;
        private const int SEARCH_ADDRESS = 7;
        private const int DELETE_ADDRESS = 8;
        private const int DELETE_ALL_ADDRESS = 9;

        private const int EXIT = 10;

        public static void Main(string[] args)
        {
            StartAddingContact();

        }

        private static void StartAddingContact()
        {


        ContactService service = new ContactService(new ContactRepository(new RepositoryModelDbContext()));
       
        int choice = 0;
            while (choice != 10)
            {
                Console.WriteLine("\n");
                foreach (var c in service.GetContacts())
                {
                    Console.WriteLine($"Id : {c.Id} , First Name : {c.FirstName} , Last Name : {c.LastName} , Phone Number : {c.PhoneNo}");

                }

                Console.WriteLine("\n1. Add to Contact\n2. Modify Contact\n3.Search Contact\n4.Delete Contact" +
                    "\n-----------------FOR Address Purpose----------------------" +
                    "\n5.Add address for CONTACT\n6. Modify Address \n7.Search Addresses\n8.Delete Address \n9.Delete All Address\n10.Exit");
                Console.WriteLine("Enter Your Choice");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case ADD_CONTACT:
                        AddContact(service);
                        break;
                    case DELETE_CONTACT:
                        DeleteContact(service);
                        break;
                    case EDIT_CONTACT:
                        EditContact(service);
                        break;
                    case SEARCH_CONTACT:
                        SearchContact(service);
                        break;
                    case ADD_ADDRESS:
                        AddAddress(service);
                        break;
                    case DELETE_ADDRESS:
                        DeleteAddress(service);
                        break;
                    case EDIT_ADDRESS:
                        EditAddress(service);
                        break;
                    case SEARCH_ADDRESS:
                        SearchAddress(service);
                        break;
                    case EXIT:
                        SearchAddress(service);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SearchAddress(ContactService service)
        {
            Console.Write($"Enter a location keyword you want to search : ");
            string addressKey = Console.ReadLine();
            List<Address> addressList = service.SearchAddress(addressKey);
            foreach(var address in addressList)
            {
                Console.WriteLine($"Address Id : {address.Id} || Address Location : {address.Location}");
            }
        }

        private static void EditAddress(ContactService service)
        {
            DisplayContactsWithAddress(service);

            Console.Write($"\nEnter Address Id : ");
            int address_id = Int32.Parse(Console.ReadLine());


            Console.Write($"\nEnter contact Id : ");
            int contact_id = Int32.Parse(Console.ReadLine());


            Console.Write($"\nEnter new Address Location : ");
            string address_location = Console.ReadLine();

            try
            {
                service.EditAddress(contact_id,address_id,address_location);
                Console.WriteLine("Address Updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void DeleteAddress(ContactService service)
        {
            DisplayContactsWithAddress(service);
            
            Console.Write($"\nEnter Address Id : ");
            int address_id = Int32.Parse(Console.ReadLine());

            try
            {
                service.DeleteAddress(address_id);
                Console.WriteLine("Address deleted");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void DisplayContactsWithAddress(ContactService service)
        {
            var contacts = service.GetContacts();
            Console.WriteLine($"\nShowing Addresses for all contacts...");
            foreach(var contact in contacts)
            {
                Console.WriteLine($"\nContact Id : {contact.Id} || Contact Name : {contact.FirstName + " " + contact.LastName}");
                var addresses = service.GetAddress(contact);
                foreach(var address in addresses)
                {
                    Console.WriteLine($"\n------- Address Id : {address.Id} || Address Location : {address.Location}");
                }
            }

        }
        private static void AddAddress(ContactService contactService)
        {
            DisplayAllContacts(contactService);
            Console.Write($"Enter the Id of contact you wish to add address : ");
            
            int idOfContact = Int32.Parse(Console.ReadLine());
            Contact contact = contactService.GetContactById(idOfContact);
            
            Console.Write("Enter Location for the Addresses : ");
            string addressLocation = Console.ReadLine();
            try
            {
                
                    contactService.AddAddress(contact, new Address() { Location = addressLocation });
                    Console.WriteLine("address addded successfully");

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void DisplayAllContacts(ContactService contactService)
        {
            List<Contact> contactList = contactService.GetContacts();
            foreach(var contact in contactList)
            {
                Console.WriteLine($"Contact Id :{contact.Id} || Contact Name : {contact.FirstName + " " + contact.LastName}");
            }
        }
        private static void SearchContact(ContactService service)
        {
            Console.WriteLine("Enter the key to search the contact");
            string searchKey = Console.ReadLine();
            try
            {
                List<Contact> searchedContacts = service.SearchContacts(searchKey);
                foreach (var contact in searchedContacts)
                {
                    Console.WriteLine($"Id : {contact.Id} , First Name : {contact.FirstName} , Last Name : {contact.LastName} , Phone Number : {contact.PhoneNo}");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void EditContact(ContactService service)
        {
            Console.Write("\nEnter Contact Id you want to modify");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat do you want to modify\n1.First Name\n2.Last Name\n3.Phone Number");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the modified value");
            string modification = Console.ReadLine();
            try
            {

                service.EditContact(choice, id, modification);
                Console.WriteLine("\nContact edited successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteContact(ContactService service)
        {
            Console.Write("\nEnter Contact Id you want to delete");
            int id = int.Parse(Console.ReadLine());

            try
            {
                service.DeleteContact(id);
                Console.WriteLine("\nContact deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddContact(ContactService service)
        {
            Console.Write("\nEnter First Name : ");
            string firstName = Console.ReadLine();

            Console.Write("\nEnter Last Name : ");
            string lastName = Console.ReadLine();

            Console.Write("\nEnter phoneNo : ");
            long phoneNo = long.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat do you want to modify\n1.First Name\n2.Last Name\n3.Phone Number");
            try
            {

                service.AddContact(new Contact() { FirstName = firstName, LastName = lastName, PhoneNo = phoneNo });
                Console.WriteLine("\nContact added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
