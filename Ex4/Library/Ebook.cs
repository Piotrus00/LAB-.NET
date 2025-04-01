namespace Lib;

public class EBook : Book
{
    public string FileFormat { get; private set; }

    public EBook(int id, string title, string author, string fileFormat)
        : base(id, title, author)
    {
        FileFormat = fileFormat;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Format pliku: {FileFormat}");
    }
}
