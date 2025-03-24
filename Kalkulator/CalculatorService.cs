namespace Kalkulator;

public class CalculatorService
{
    ScientificCalculator calculator = new ScientificCalculator();

    public static void Run()
    {
        System.Console.WriteLine("Wybierz operacje:\n" +
                                 "1. Dodawanie\n" +
                                 "2. Odejmowanie\n" +
                                 "3. Mnozenie\n" +
                                 "4. Dzielenie\n" +
                                 "5. Suma wyrazow\n" +
                                 "6. Srednia wyrazow\n" +
                                 "7. Maksymalny wyraz\n" +
                                 "8. Minimalny wyraz\n" +
                                 "9. Potegowanie(x^y)\n" +
                                 "10. Pierwiastkowanie\n" +
                                 "11. Logarytm naturalny\n" +
                                 "12.Wyjscie\n"
        );
        
        string? input = Console.ReadLine();
        int choice;
        double x, y, w;
        double[] wynik;

        if (int.TryParse(input, out choice))
        {
            switch (choice)
            {
                case 1:
                    x=give_x();
                    y=give_y();
                    w = Calculator.Add(x, y);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 2:
                    x=give_x();
                    y=give_y();
                    w = Calculator.Substract(x, y);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 3:
                    x=give_x();
                    y=give_y();
                    w = Calculator.Multiply(x, y);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 4:
                    x=give_x();
                    y=give_y();
                    w = Calculator.Divide(x, y);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 5:
                    wynik = GiveSeq();
                    w = Calculator.SumSequence(wynik);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 6:
                    wynik = GiveSeq();
                    w = Calculator.AverageSequence(wynik);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 7:
                    wynik = GiveSeq();
                    w = Calculator.MaxSequence(wynik);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 8:
                    wynik = GiveSeq();
                    w = Calculator.MinSequence(wynik);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 9:
                    x=give_x();
                    y=give_y();
                    w = ScientificCalculator.Power(x,y);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 10:
                    x=give_x();
                    w = ScientificCalculator.SquareRoot(x);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 11:
                    x=give_x();
                    w = ScientificCalculator.Log(x);
                    System.Console.WriteLine($"wynik: {w}");
                    break;
                case 12:
                    break;
                default:
                    Console.WriteLine("Nieprawidlowy wybor.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nieprawidlowy input.");
        }
    }

    private static double give_x()
    {
        System.Console.WriteLine("Podaj x:");
        string? input = Console.ReadLine();
        return double.Parse(input);
    }
    private static double give_y()
    {
        System.Console.WriteLine("Podaj y:");
        string? input = Console.ReadLine();
        return double.Parse(input);
    }

    private static double[] GiveSeq()
    {
        Console.WriteLine("Podaj ile liczb chcesz wprowadzić:");
        int liczba = int.Parse(Console.ReadLine());

        double[] liczby = new double[liczba]; // Tablica na podane liczby

        Console.WriteLine("Podaj liczby ('w' żeby zakończyć wcześniejszy wpis):");

        for (int i = 0; i < liczba; i++)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "w")
                Array.Resize(ref liczby, i); // Skraca tablicę do wprowadzonych wartości
            else if (double.TryParse(input, out liczby[i])) 
                continue;
            else
            {
                Console.WriteLine("Niepoprawna liczba, spróbuj ponownie.");
                i--; // Powtórz iterację dla tej samej pozycji
            }
        }
        return liczby;
    }
}