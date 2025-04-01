namespace Lib;

public class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBook(new Book(1,"aaaa", "dddd"));
        library.AddBook(new Book(2,"bbbb", "cccc"));
        library.AddBook(new EBook(3,"aaaa", "dddd", "PDF"));
        library.ListAvailableBooks();
        library.BorrowBook(1,"andrzej");
        library.BorrowBook(3,"andrzej");
        Console.WriteLine("Hello World!");
        library.ListAvailableBooks();
        library.ReturnBook(1);
        Console.WriteLine("Hello World!");
        library.ListAvailableBooks();
    }
}