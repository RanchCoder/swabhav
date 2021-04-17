using FirstCoreWebApplication.Models;
using FirstCoreWebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static BookService bookService = new BookService();

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookService.GetBooks();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            bool isContactAdded = bookService.AddBook(book);
            if (isContactAdded)
            {
                return new ObjectResult("book added");
            }
            return BadRequest("cannot add book");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            bool isContactUpdated = bookService.UpdateBook(book);
            if (isContactUpdated)
            {
                return new ObjectResult("book updated");
            }
            return BadRequest("cannot add updated");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            bool isContactDeleted = bookService.DeleteBook(id);
            if (isContactDeleted)
            {
                return new ObjectResult("book deleted");
            }
            return BadRequest("cannot add deleted");
        }
    }
}
