using FirstCoreWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplication.Services
{
    public class BookService
    {
        private const bool OPERATION_SUCCESS = true;
        private const bool OPERATION_FAILURE = false;
        private static List<Book> _books = new List<Book>();

        public List<Book> GetBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.SingleOrDefault(x=>x.Id == id);
        }

        public bool AddBook(Book book)
        {
            try
            {
                _books.Add(book);
                return OPERATION_SUCCESS;
            }catch(Exception ex)
            {
                return OPERATION_FAILURE;
            }
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                foreach (var bk in _books.Where(x => x.Id == book.Id))
                {
                    bk.Name = book.Name;
                }
                return OPERATION_SUCCESS;
            }catch(Exception ex)
            {
                return OPERATION_FAILURE;
            }
            
        }

        public bool DeleteBook(int id)
        {
            try
            {

                var bookToDelete = _books.Where(x => x.Id == id).FirstOrDefault();
                _books.Remove(bookToDelete);
                return OPERATION_SUCCESS;
            } catch(Exception ex)
            {
                return OPERATION_FAILURE;
            }
        }

    }
}
