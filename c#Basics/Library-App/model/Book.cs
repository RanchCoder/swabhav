using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_App.model
{
    class Book : IComparable
    {
        private string bookTitle;
        private string bookISBN;
        private string bookAuthor;
        private float bookPrice;

        public Book(string bookTitle, string bookISBN, string bookAuthor, float bookPrice)
        {
            this.bookTitle = bookTitle;
            this.bookISBN = bookISBN;
            this.bookAuthor = bookAuthor;
            this.bookPrice = bookPrice;
        }

        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string BookISBN { get => bookISBN; set => bookISBN = value; }
        public string BookAuthor { get => bookAuthor; set => bookAuthor = value; }
        public float BookPrice { get => bookPrice; set => bookPrice = value; }

        public int CompareTo(object obj)
        {
            Book bookInstance = (Book)obj;
            return BookTitle.CompareTo(bookInstance.BookTitle);
        }
    }
}
