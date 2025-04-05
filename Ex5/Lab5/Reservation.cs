namespace Lab5;

public class Reservation
{
    private int ReservationId ;
    Vehicle ReservedVehicle;
    string Customer;
    DateTime ReservationDate;

    public Reservation(Vehicle NewVehicle, string Customer, int ReservationId)
    {
        this.ReservationId = ReservationId;
        this.ReservedVehicle = NewVehicle;
        this.Customer = Customer;
        ReservationDate = DateTime.Now;
    }
    
    public new string ToString()
    {
        return $"ReservationId: {ReservationId}, ReservationDate: {ReservationDate}, Customer: {Customer}";
    }

    public int GetReservationId()
    {
        return ReservationId;
    }

    public int GetCarId()
    {
        return ReservedVehicle.GetId();
    }
}