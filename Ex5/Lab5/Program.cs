namespace Lab5;

public class Program
{
    static void Main(string[] args)
    {
        RentalCompany rentalCompany = new RentalCompany();
        rentalCompany.OnNewReservation += message => Console.WriteLine(message);
        rentalCompany.AddVehicle(new Car(1, "Toyota", "Corrolla", 2020, "Sedan"));
        rentalCompany.AddVehicle(new Car(2, "Txd", "Corrolla", 2020, "Sedan"));
        rentalCompany.ListAvailableVechicles();
        rentalCompany.ReserveVehicle(1, "Adam");
        rentalCompany.ReserveVehicle(2, "Adam");
        rentalCompany.ListAvailableVechicles();
        rentalCompany.CancelReservation(2);
        rentalCompany.ListAvailableVechicles();
        rentalCompany.GetAllVehicles();
        
    }
}