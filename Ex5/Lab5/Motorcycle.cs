namespace Lab5;

public class Motorcycle : Vehicle, IReservable
{
    private int EngineCapacity { get; set; }
    private bool Ava;

    public Motorcycle(int Id, string Brand, string Model, int Year, int EngineCapacity) : base(Id, Brand, Model, Year)
    {
        this.EngineCapacity = EngineCapacity;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Enginge Capacity: {EngineCapacity}");
    }
    
    public void Reserve(string customer)
    {
        Console.WriteLine($"Reserving motorcycle {Id} for {customer}");
        Ava = false;
    }

    public void CancelReservation()
    {
        Console.WriteLine($"Cancel reservation of motorcycle {Id}");
        Ava = true;
    }

    public bool IsAvailable()
    {
        return Ava;
    }
}