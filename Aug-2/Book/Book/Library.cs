using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class Library
    {
        public List<Book1> Books { get; private set; }
        public List<Borrower> Borrowers { get; private set; }

        public Library()
        {
            Books = new List<Book1>();
            Borrowers = new List<Borrower>();
        }

        public void AddBook(Book1 book) => Books.Add(book);

        public void RegisterBorrower(Borrower borrower) => Borrowers.Add(borrower);

        public bool BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            var borrower = Borrowers.FirstOrDefault(br => br.LibraryCardNumber == libraryCardNumber);

            if (book != null && borrower != null)
            {
                borrower.BorrowBook(book);
                return true;
            }

            return false;
        }

        public bool ReturnBook(string isbn, string libraryCardNumber)
        {
            var borrower = Borrowers.FirstOrDefault(br => br.LibraryCardNumber == libraryCardNumber);
            var book = borrower?.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);

            if (book != null)
            {
                borrower.ReturnBook(book);
                return true;
            }

            return false;
        }

        public List<Book1> ViewBooks() => Books;

        public List<Borrower> ViewBorrowers() => Borrowers;
    }
}
