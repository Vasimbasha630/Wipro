using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BookLirary;
using Book;
namespace Book.Tests
{
    [TestFixture]
    public class Book1Tests
    {
        [Test]
        public void Borrow_WhenBookIsAvailable_ShouldMarkAsBorrowed()
        {
            // Arrange
            var book = new Book.Book1
            {
                Title = "Clean Code",
                Author = "Robert C. Martin",
                ISBN = "123456"
            };

            // Act
            book.Borrow();

            // Assert
            Assert.IsTrue(book.IsBorrowed, "Book should be marked as borrowed.");
        }

        [Test]
        public void Borrow_WhenBookIsAlreadyBorrowed_ShouldRemainBorrowed()
        {
            // Arrange
            var book = new Book1
            {
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                ISBN = "789101"
            };
            book.Borrow(); // already borrowed

            // Act
            book.Borrow(); // try borrowing again

            // Assert
            Assert.IsTrue(book.IsBorrowed, "Book should remain borrowed.");
        }

        [Test]
        public void Return_WhenBookIsBorrowed_ShouldMarkAsAvailable()
        {
            // Arrange
            var book = new Book1
            {
                Title = "Refactoring",
                Author = "Martin Fowler",
                ISBN = "112233"
            };
            book.Borrow(); // borrow first

            // Act
            book.Return();

            // Assert
            Assert.IsFalse(book.IsBorrowed, "Book should be marked as available.");
        }

        [Test]
        public void Return_WhenBookIsAlreadyAvailable_ShouldRemainAvailable()
        {
            // Arrange
            var book = new Book1
            {
                Title = "Design Patterns",
                Author = "GoF",
                ISBN = "445566"
            };

            // Act
            book.Return(); // return without borrowing

            // Assert
            Assert.IsFalse(book.IsBorrowed, "Book should remain available.");
        }
    }
}
