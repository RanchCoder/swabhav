using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_App.model
{
    class Library
    {
        private int libraryId;
        private string libraryName;
        private string libraryLocation;
        private SortedSet<Book> listOfBooksInLibrary;

        public Library(int libraryId, string libraryName, string libraryLocation)
        {
            this.libraryId = libraryId;
            this.libraryName = libraryName;
            this.libraryLocation = libraryLocation;
        }

        public Library(int libraryId,string libraryName,string libraryLocation,SortedSet<Book> listOfBooksInLibrary)
        {
            this.libraryId = libraryId;
            this.libraryName = libraryName;
            this.libraryLocation = libraryLocation;
            this.listOfBooksInLibrary = listOfBooksInLibrary;
        }

        public int LibraryId { get => libraryId; set => libraryId = value; }
        public string LibraryName { get => libraryName; set => libraryName = value; }
        public string LibraryLocation { get => libraryLocation; set => libraryLocation = value; }
        internal SortedSet<Book> ListOfBooksInLibrary { get => listOfBooksInLibrary; set => listOfBooksInLibrary = value; }
    }
}
