using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryModelEntityFramework.Model;
using RepositoryModelEntityFramework.Repository;
using RepositoryModelEntityFramework.Service;
using RepositoryModelEntityFramework.DataBaseContext;
namespace RepositoryModelEntityFramework
{
    class Program
    {
        private const int ADD = 1;
        private const int EDIT = 2;
        private const int SEARCH = 3;
        private const int DELETE = 4;
        private const int EXIT = 5;
        static void  Main(string[] args)
        {
            ContactService service = new ContactService(new ContactRepository(new ContactDbContext()));

            int choice = 0;
            while(choice != 5)
            {
                Console.WriteLine("\n");
                foreach(var c in service.GetContacts())
                {
                    Console.WriteLine($"Id : {c.Id} , First Name : {c.FirstName} , Last Name : {c.LastName} , Phone Number : {c.PhoneNo}");
                   
                }

                Console.WriteLine("\n1. Add to Contact\n2. Modify Contact\n3.Search Contact\n4.Delete Contact\n5.Exit");
                Console.WriteLine("Enter Your Choice");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case ADD:
                         AddContact(service);
                        break;
                    case DELETE:
                        DeleteContact(service);
                        break;
                    case EDIT:
                        EditContact(service);
                        break;
                    case SEARCH:
                        SearchContact(service);
                        break;
                    case EXIT:
                        SearchContact(service);
                        break;
                    default:                       
                        break;
                }
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

                service.EditContact(choice,id,modification);
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

        private  static void AddContact(ContactService service)
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
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
