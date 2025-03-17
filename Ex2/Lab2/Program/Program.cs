namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyzer analyzer = new TextAnalyzer();
            string text = "";

            Console.WriteLine("Wybierz sposób wprowadzenia tekstu:");
            Console.WriteLine("1 - Wpisz ręcznie");
            Console.WriteLine("2 - Wczytaj z pliku (ścieżka podana w kodzie)");
            Console.WriteLine("3 - Wczytaj z pliku (ścieżka podana jako argument)");
            Console.Write("Twój wybór: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Wpisz tekst:");
                text = Console.ReadLine();
            }
            else if (choice == "2")
            {
                string filePath = "example.txt";
                if (File.Exists(filePath))
                {
                    text = File.ReadAllText(filePath);
                    Console.WriteLine($"Wczytano tekst z pliku: {filePath}");
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje!");
                    return;
                }
            }
            else if (choice == "3")
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Nie podano ścieżki do pliku jako argument programu.");
                    return;
                }

                string filePath = args[0];
                if (File.Exists(filePath))
                {
                    text = File.ReadAllText(filePath);
                    Console.WriteLine($"Wczytano tekst z pliku: {filePath}");
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór!");
                return;
            }

            TextStatistics stats = analyzer.AnalyzeText(text);
 
            Console.WriteLine("\n=== WYNIKI ANALIZY TEKSTU ===");
            Console.WriteLine($"Znaki (ze spacjami): {stats.CharacterCount}");
            Console.WriteLine($"Znaki (bez spacji): {stats.CharacterCountWithoutSpaces}");
            Console.WriteLine($"Litery: {stats.LetterCount}");
            Console.WriteLine($"Liczby: {stats.NumberCount}");
            Console.WriteLine($"Interpunkcja: {stats.PunctuationCount}");
            Console.WriteLine($"Słowa: {stats.WordCount}");
            Console.WriteLine($"Unikalne słowa: {stats.UniqueWordCount}");
            Console.WriteLine($"Najczęstsze słowo: {stats.MostCommonWord}");
            Console.WriteLine($"Średnia długość słowa: {stats.AverageWordLength}");
            Console.WriteLine($"Najkrótsze i najdłuższe słowo: {stats.ShortestAndLongestWord}");
            Console.WriteLine($"Liczba zdań: {stats.SentenceCount}");
            Console.WriteLine($"Średnia długość zdania: {stats.AverageSentenceLength}");
            Console.WriteLine($"Najdłuższe zdanie: {stats.LongestSentence}");
        }
    }
}
