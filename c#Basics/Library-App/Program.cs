using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_App.model;

namespace Library_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("History of Ancient India","ASB12345","Upinder Singh",1100f);
            Book book2 = new Book("A Discovery Of India","JSB42911","Jawaharlal Nehru",500f);
            Library libraryInstance = new Library(101,"J.N Petit Library","Nariman Point");

            SortedSet<Book> listOfBooks = new SortedSet<Book>();
            listOfBooks.Add(book1);
            listOfBooks.Add(book2);

            libraryInstance.ListOfBooksInLibrary = listOfBooks;

            PrintLibraryDetails(libraryInstance);
            Console.ReadLine();
        }

        public static void PrintLibraryDetails(Library libraryInstance)
        {
            Console.WriteLine($"Library Details-------------" +
                $"\n\nLibrary Name : {libraryInstance.LibraryName}" +
                $"\nLibrary Location : {libraryInstance.LibraryLocation}" +
                $"\n\n List of Books in Library" +
                $"\n");
                
            foreach(Book book in libraryInstance.ListOfBooksInLibrary)
            {
                Console.WriteLine($"Title : {book.BookTitle}" +
                                  $"\nAuthor : {book.BookAuthor}" +
                                  $"\nISBN : {book.BookISBN}" +
                                  $"\nPrice : Rs.{book.BookPrice}/-" +
                                  $"\n");
            }
            
        }
    }
}
