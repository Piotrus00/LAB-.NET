namespace Lab5;

public static class VehicleExtensions
{
    public static List<Vehicle> GetAvailableVehicles(this List<Vehicle> vehicles)
    {
        return vehicles.Where(v => v.GetAvailability()).ToList();
    }
}