namespace Lab5;

public class RentalCompany
{
    private List<Vehicle> vehicles;
    private List<Reservation> reservations;
    public event Action<string> OnNewReservation;
    public RentalCompany()
    {
        vehicles = new List<Vehicle>();
        reservations = new List<Reservation>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }
    
    public void ReserveVehicle(int vechicleId, string customer)
    {
        foreach (var v in vehicles)
        {
            if (v.GetId() == vechicleId)
            {
                v.SetAvailable(false);
                Reservation reservation = new Reservation(v, customer, reservations.Count+1);
                reservations.Add(reservation);
                OnNewReservation.Invoke(reservation.ToString());
                if (v is Car car)
                {
                    car.Reserve(customer);
                }
                else if (v is Motorcycle motorcycle)
                {
                    motorcycle.Reserve(customer);
                }
                break;
            }
        }
    }

    public void CancelReservation(int reservationId)
    {
        foreach (var r in reservations)
        {
            if (r.GetReservationId() == reservationId)
            {
                var vehicle = vehicles.FirstOrDefault(v => v.GetId() == r.GetCarId());
                if (vehicle != null)
                {
                    vehicle.SetAvailable(true);
                    if (vehicle is Car car)
                    {
                        car.CancelReservation();
                    }
                    else if (vehicle is Motorcycle motorcycle)
                    {
                        motorcycle.CancelReservation();
                    }
                }
                reservations.Remove(r);
                break;
            }
        }
    }

        public void ListAvailableVechicles()
        {
            var availableVehicles = vehicles.GetAvailableVehicles();
            Console.WriteLine("Dostępne pojazdy:");
            foreach (var vehicle in availableVehicles)
            {
                vehicle.DisplayInfo();
            }
        }

    public List<Vehicle> GetAllVehicles()
    {
        return vehicles.Select(v => v).ToList();
    }
}
