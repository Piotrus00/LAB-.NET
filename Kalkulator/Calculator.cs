namespace Kalkulator;

public class Calculator
{
    public static double Add(double x, double y)
    {
        return x + y;
    }

    public static double Substract(double x, double y)
    {
        return x - y;
    }

    public static double Multiply(double x, double y)
    {
        return x * y;
    }

    public static double Divide(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Nie można dzielić przez zero.");
        }
        return x / y;
    }

    public static double SumSequence(IEnumerable<double> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "Lista liczb nie może być null.");
        }
        return numbers.Sum();
    }

    public static double AverageSequence(IEnumerable<double> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "Lista liczb nie może być null.");
        }
        if (!numbers.Any())
        {
            throw new InvalidOperationException("Nie można obliczyć średniej dla pustej listy.");
        }
        return numbers.Average();
    }

    public static double MaxSequence(IEnumerable<double> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "Lista liczb nie może być null.");
        }
        if (!numbers.Any())
        {
            throw new InvalidOperationException("Lista liczb nie może być pusta.");
        }
        return numbers.Max();
    }

    public static double MinSequence(IEnumerable<double> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "Lista liczb nie może być null.");
        }
        if (!numbers.Any())
        {
            throw new InvalidOperationException("Lista liczb nie może być pusta.");
        }
        return numbers.Min();
    }
}