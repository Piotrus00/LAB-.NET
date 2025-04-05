namespace Lab5;

public abstract class Vehicle
{
    protected int Id{get;set;}
    protected string Brand{get;set;}
    protected string Model{get;set;}
    protected int Year{get;set;}
    bool IsAvailable{get;set;} = true;

    public Vehicle(int Id, string Brand, string Model, int Year)
    {
        this.Id = Id;
        this.Brand = Brand;
        this.Model = Model;
        this.Year = Year;
    }

    public int GetId()
    {
        return this.Id;
    }

    public bool GetAvailability()
    {
        return this.IsAvailable;
    }

    public void SetAvailable(bool IsAvailable)
    {
        this.IsAvailable = IsAvailable;
    }

    public abstract void DisplayInfo();
}