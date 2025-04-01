namespace Lib;

public class Library : IBookOperations
{
    private List<Book> books = new List<Book>();
    
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    
    public void ListAvailableBooks()
    {
        foreach (var book in books)
        {
            if (book.IsAvailable)
            {
                book.DisplayInfo();
            }
        }
    }

    public void BorrowBook(int bookId, string borrowerName)
    {
        foreach (var book in books)
        {
            if (book.IsAvailable && book.Id == bookId)
            {
                book.IsAvailable = false;
                book.Borrower = borrowerName;
                return;
            }
            throw new ArgumentException("Borrowing book is not available");
        }
    }

    public void ReturnBook(int bookId)
    {
        foreach (var book in books)
        {
            if (!book.IsAvailable && book.Id == bookId)
            {
                book.IsAvailable = true;
                book.Borrower = "";
                return;
            }
            throw new ArgumentException("Returning book is not available");
        }
    }
}
