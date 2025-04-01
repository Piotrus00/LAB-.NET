using NUnit.Framework;
namespace Lib
{
    [TestFixture]
    public class LibraryTests
    {
        private Library library;
        private StringWriter consoleOutput;

        [SetUp]
        public void Setup()
        {
            library = new Library();
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [TearDown]
        public void TearDown()
        {
            consoleOutput.Dispose();
            Console.SetOut(Console.Out);
        }

        [Test]
        public void AddBook_AddsBookToLibrary()
        {
            var book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);

            library.ListAvailableBooks();
            string output = consoleOutput.ToString();
            
            Assert.IsTrue(output.Contains("Test Book"));
            Assert.IsTrue(output.Contains("Test Author"));
        }

        [Test]
        public void ListAvailableBooks_OnlyShowsAvailableBooks()
        {
            var book1 = new Book(1, "Available Book", "Author 1");
            var book2 = new Book(2, "Borrowed Book", "Author 2");
            book2.IsAvailable = false;
            book2.Borrower = "Someone";
            
            library.AddBook(book1);
            library.AddBook(book2);
            
            library.ListAvailableBooks();
            string output = consoleOutput.ToString();
            
            Assert.IsTrue(output.Contains("Available Book"));
            Assert.IsFalse(output.Contains("Borrowed Book"));
        }

        [Test]
        public void BorrowBook_WhenBookIsAvailable_MarksBookAsBorrowed()
        {
            var book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);
            
            try
            {
                library.BorrowBook(1, "Test Borrower");
                
                Assert.IsFalse(book.IsAvailable);
                Assert.AreEqual("Test Borrower", book.Borrower);
            }
            catch (ArgumentException)
            {
                Assert.Fail("BorrowBook incorrectly throws an exception for valid book");
            }
        }

        [Test]
        public void BorrowBook_WhenBookIsNotAvailable_ThrowsException()
        {
            var book = new Book(1, "Test Book", "Test Author");
            book.IsAvailable = false;
            library.AddBook(book);
            
            Assert.Throws<ArgumentException>(() => library.BorrowBook(1, "Test Borrower"));
        }

        [Test]
        public void BorrowBook_WhenBookDoesNotExist_ThrowsException()
        {
            var book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);
            
            Assert.Throws<ArgumentException>(() => library.BorrowBook(999, "Test Borrower"));
        }

        [Test]
        public void ReturnBook_WhenBookIsBorrowed_MarksBookAsAvailable()
        {
            var book = new Book(1, "Test Book", "Test Author");
            book.IsAvailable = false;
            book.Borrower = "Test Borrower";
            library.AddBook(book);
            
            try
            {
                library.ReturnBook(1);
                
                Assert.IsTrue(book.IsAvailable);
                Assert.AreEqual("", book.Borrower);
            }
            catch (ArgumentException)
            {
                Assert.Fail("ReturnBook incorrectly throws an exception for valid book");
            }
        }

        [Test]
        public void ReturnBook_WhenBookIsAlreadyAvailable_ThrowsException()
        {
            var book = new Book(1, "Test Book", "Test Author");
            library.AddBook(book);
            
            Assert.Throws<ArgumentException>(() => library.ReturnBook(1));
        }

        [Test]
        public void ReturnBook_WhenBookDoesNotExist_ThrowsException()
        {
            var book = new Book(1, "Test Book", "Test Author");
            book.IsAvailable = false;
            library.AddBook(book);
            
            Assert.Throws<ArgumentException>(() => library.ReturnBook(999));
        }
    }
}