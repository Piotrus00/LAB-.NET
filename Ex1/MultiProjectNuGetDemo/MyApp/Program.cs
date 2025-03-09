using MyLibrary;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using MyServices;

public class MyApp
{
    static void Main(string[] args)
    {
        Calculator obj = new Calculator();
        // Console.WriteLine(obj.Add(1,2));
        // Console.WriteLine(obj.Subtract(1,2));
        
        double sum = obj.Add(5, 3);
        var result = new { Operation = "Add", A = 5, B = 3, Result = sum };
        string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
        Console.WriteLine(jsonResult);
        
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ILoggerService, ConsoleLogger>()
            .BuildServiceProvider();

// Uzyskanie instancji loggera
        var logger = serviceProvider.GetService<ILoggerService>();
        logger.Log("Aplikacja uruchomiona.");

// Przykładowe użycie kalkulatora
        double suma = obj.Add(10, 15);
        logger.Log($"Wynik dodawania: {sum}");

    }
}
