namespace Kalkulator;

public class ScientificCalculator
{
    Calculator calculator = new Calculator();

    public static double Power(double x, double y)
    {
        double result = Math.Pow(x, y);
        if (double.IsNaN(result) || double.IsInfinity(result))
        {
            throw new InvalidOperationException("Wynik potęgowania jest nieprawidłowy.");
        }
        return result;
    }

    public static double SquareRoot(double x)
    {
        if (x < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(x), "Nie można obliczyć pierwiastka z liczby ujemnej.");
        }
        return Math.Sqrt(x);
    }

    public static double Log(double x)
    {
        if (x <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(x), "Logarytm jest zdefiniowany tylko dla liczb dodatnich.");
        }
        return Math.Log(x);
    }
}