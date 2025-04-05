namespace Lab5;

public class Car : Vehicle, IReservable
{
    private string BodyType { get; set; }

    public Car(int Id, string Brand, string Model, int Year, string bodyType) : base(Id, Brand, Model, Year)
    {
        this.BodyType = bodyType;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Body Type: {BodyType}");
    }

    public void Reserve(string customer)
    {
        Console.WriteLine($"Reserving Car {Id} for {customer}");
    }

    public void CancelReservation()
    {
        Console.WriteLine($"Cancel Car reservation {Id}");
    }

    public bool IsAvailable()
    {
        return true;
    }
}