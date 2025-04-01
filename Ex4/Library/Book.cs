namespace Lib;
public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public bool IsAvailable { get; set; } = true;
    public string Borrower { get; set; } = "";

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Tytuł: {Title}, Autor: {Author}, Dostępność: {(IsAvailable ? "Dostępna" : $"Wypożyczona przez {Borrower}")}");
    }
}
