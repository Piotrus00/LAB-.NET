using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab5.Tests
{
    [TestFixture]
    public class VehicleTests
    {
        [Test]
        public void Vehicle_InitialState_PropertiesSetCorrectly()
        {
            // Arrange & Act
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            
            // Assert
            Assert.AreEqual(1, car.GetId());
            Assert.IsTrue(car.GetAvailability());
        }
        
        [Test]
        public void Vehicle_SetAvailable_ChangesAvailability()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            
            // Act
            car.SetAvailable(false);
            
            // Assert
            Assert.IsFalse(car.GetAvailability());
        }
    }
    
    [TestFixture]
    public class CarTests
    {
        [Test]
        public void Car_Constructor_PropertiesSetCorrectly()
        {
            // Arrange & Act
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            
            // Assert
            Assert.AreEqual(1, car.GetId());
            Assert.IsTrue(car.GetAvailability());
            Assert.IsTrue(car.IsAvailable());
        }
        
        [Test]
        public void Car_DisplayInfo_WritesCorrectOutput()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Act
            car.DisplayInfo();
            
            // Assert
            Assert.AreEqual($"Id: 1, Brand: Toyota, Model: Corolla, Year: 2020, Body Type: Sedan{Environment.NewLine}", stringWriter.ToString());
        }
        
        [Test]
        public void Car_Reserve_WritesCorrectOutput()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Act
            car.Reserve("John");
            
            // Assert
            Assert.AreEqual($"Reserving Car 1 for John{Environment.NewLine}", stringWriter.ToString());
        }
        
        [Test]
        public void Car_CancelReservation_WritesCorrectOutput()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Act
            car.CancelReservation();
            
            // Assert
            Assert.AreEqual($"Cancel Car reservation 1{Environment.NewLine}", stringWriter.ToString());
        }
    }
    
    [TestFixture]
    public class MotorcycleTests
    {
        [Test]
        public void Motorcycle_Constructor_PropertiesSetCorrectly()
        {
            // Arrange & Act
            Motorcycle motorcycle = new Motorcycle(1, "Honda", "CBR", 2021, 600);
            
            // Assert
            Assert.AreEqual(1, motorcycle.GetId());
            Assert.IsTrue(motorcycle.GetAvailability());
        }
        
        [Test]
        public void Motorcycle_DisplayInfo_WritesCorrectOutput()
        {
            // Arrange
            Motorcycle motorcycle = new Motorcycle(1, "Honda", "CBR", 2021, 600);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Act
            motorcycle.DisplayInfo();
            
            // Assert
            Assert.AreEqual($"Id: 1, Brand: Honda, Model: CBR, Year: 2021, Enginge Capacity: 600{Environment.NewLine}", stringWriter.ToString());
        }
        
        [Test]
        public void Motorcycle_Reserve_SetsAvailabilityToFalse()
        {
            // Arrange
            Motorcycle motorcycle = new Motorcycle(1, "Honda", "CBR", 2021, 600);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Act
            motorcycle.Reserve("John");
            
            // Assert
            Assert.AreEqual($"Reserving motorcycle 1 for John{Environment.NewLine}", stringWriter.ToString());
            Assert.IsFalse(motorcycle.IsAvailable());
        }
        
        [Test]
        public void Motorcycle_CancelReservation_SetsAvailabilityToTrue()
        {
            // Arrange
            Motorcycle motorcycle = new Motorcycle(1, "Honda", "CBR", 2021, 600);
            motorcycle.Reserve("John");
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Act
            motorcycle.CancelReservation();
            
            // Assert
            Assert.AreEqual($"Cancel reservation of motorcycle 1{Environment.NewLine}", stringWriter.ToString());
            Assert.IsTrue(motorcycle.IsAvailable());
        }
    }
    
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void Reservation_Constructor_PropertiesSetCorrectly()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            
            // Act
            Reservation reservation = new Reservation(car, "John", 101);
            
            // Assert
            Assert.AreEqual(101, reservation.GetReservationId());
            Assert.AreEqual(1, reservation.GetCarId());
        }
        
        [Test]
        public void Reservation_ToString_ReturnsCorrectString()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            Reservation reservation = new Reservation(car, "John", 101);
            DateTime now = DateTime.Now;
            
            // Act
            string result = reservation.ToString();
            
            // Assert
            StringAssert.Contains("ReservationId: 101", result);
            StringAssert.Contains("Customer: John", result);
            StringAssert.Contains("ReservationDate:", result);
        }
    }
    
    [TestFixture]
    public class VehicleExtensionsTests
    {
        [Test]
        public void GetAvailableVehicles_ReturnsOnlyAvailableVehicles()
        {
            // Arrange
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car(1, "Toyota", "Corolla", 2020, "Sedan"),
                new Car(2, "Honda", "Civic", 2021, "Sedan"),
                new Motorcycle(3, "Kawasaki", "Ninja", 2019, 650)
            };
            
            vehicles[1].SetAvailable(false);
            
            // Act
            List<Vehicle> availableVehicles = vehicles.GetAvailableVehicles();
            
            // Assert
            Assert.AreEqual(2, availableVehicles.Count);
            Assert.IsTrue(availableVehicles.Any(v => v.GetId() == 1));
            Assert.IsTrue(availableVehicles.Any(v => v.GetId() == 3));
            Assert.IsFalse(availableVehicles.Any(v => v.GetId() == 2));
        }
    }
    
    [TestFixture]
    public class RentalCompanyTests
    {
        private RentalCompany rentalCompany;
        private StringWriter stringWriter;
        private bool eventRaised;
        private string eventMessage;
        
        [SetUp]
        public void Setup()
        {
            rentalCompany = new RentalCompany();
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            eventRaised = false;
            eventMessage = string.Empty;
            
            rentalCompany.OnNewReservation += message => 
            {
                eventRaised = true;
                eventMessage = message;
            };
        }
        
        [Test]
        public void AddVehicle_AddsVehicleToCollection()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            
            // Act
            rentalCompany.AddVehicle(car);
            List<Vehicle> vehicles = rentalCompany.GetAllVehicles();
            
            // Assert
            Assert.AreEqual(1, vehicles.Count);
            Assert.AreEqual(1, vehicles[0].GetId());
        }
        
        [Test]
        public void ReserveVehicle_SetsVehicleUnavailableAndRaisesEvent()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            rentalCompany.AddVehicle(car);
            
            // Act
            rentalCompany.ReserveVehicle(1, "John");
            
            // Assert
            List<Vehicle> vehicles = rentalCompany.GetAllVehicles();
            Assert.IsFalse(vehicles[0].GetAvailability());
            Assert.IsTrue(eventRaised);
            StringAssert.Contains("ReservationId:", eventMessage);
            StringAssert.Contains("Customer: John", eventMessage);
            StringAssert.Contains($"Reserving Car 1 for John{Environment.NewLine}", stringWriter.ToString());
        }
        
        [Test]
        public void CancelReservation_SetsVehicleAvailable()
        {
            // Arrange
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            rentalCompany.AddVehicle(car);
            rentalCompany.ReserveVehicle(1, "John");
            stringWriter.GetStringBuilder().Clear(); // Clear console output from reservation
            
            // Act
            rentalCompany.CancelReservation(1);
            
            // Assert
            List<Vehicle> vehicles = rentalCompany.GetAllVehicles();
            Assert.IsTrue(vehicles[0].GetAvailability());
            StringAssert.Contains($"Cancel Car reservation 1{Environment.NewLine}", stringWriter.ToString());
        }
        
        [Test]
        public void ListAvailableVehicles_WritesOnlyAvailableVehicles()
        {
            // Arrange
            rentalCompany.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
            rentalCompany.AddVehicle(new Car(2, "Honda", "Civic", 2021, "Sedan"));
            rentalCompany.ReserveVehicle(2, "John");
            stringWriter.GetStringBuilder().Clear(); // Clear previous console output
            
            // Act
            rentalCompany.ListAvailableVechicles();
            
            // Assert
            string output = stringWriter.ToString();
            StringAssert.Contains("Dostępne pojazdy:", output);
            StringAssert.Contains("Id: 1, Brand: Toyota, Model: Corolla, Year: 2020", output);
            StringAssert.DoesNotContain("Id: 2, Brand: Honda, Model: Civic, Year: 2021", output);
        }
        
        [Test]
        public void GetAllVehicles_ReturnsAllVehicles()
        {
            // Arrange
            rentalCompany.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
            rentalCompany.AddVehicle(new Car(2, "Honda", "Civic", 2021, "Sedan"));
            rentalCompany.ReserveVehicle(2, "John");
            
            // Act
            List<Vehicle> allVehicles = rentalCompany.GetAllVehicles();
            
            // Assert
            Assert.AreEqual(2, allVehicles.Count);
            Assert.IsTrue(allVehicles[0].GetAvailability());
            Assert.IsFalse(allVehicles[1].GetAvailability());
        }
    }
    
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void RentalCompany_EndToEndWorkflow()
        {
            // Arrange
            RentalCompany rentalCompany = new RentalCompany();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            bool eventRaised = false;
            string eventMessage = string.Empty;
            
            rentalCompany.OnNewReservation += message => 
            {
                eventRaised = true;
                eventMessage = message;
            };
            
            // Act & Assert - Add vehicles
            rentalCompany.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
            rentalCompany.AddVehicle(new Motorcycle(2, "Honda", "CBR", 2021, 600));
            
            List<Vehicle> allVehicles = rentalCompany.GetAllVehicles();
            Assert.AreEqual(2, allVehicles.Count);
            
            // Act & Assert - List available vehicles
            stringWriter.GetStringBuilder().Clear();
            rentalCompany.ListAvailableVechicles();
            string availableOutput = stringWriter.ToString();
            StringAssert.Contains("Id: 1, Brand: Toyota, Model: Corolla", availableOutput);
            StringAssert.Contains("Id: 2, Brand: Honda, Model: CBR", availableOutput);
            
            // Act & Assert - Reserve vehicle
            stringWriter.GetStringBuilder().Clear();
            rentalCompany.ReserveVehicle(1, "John");
            Assert.IsTrue(eventRaised);
            StringAssert.Contains("ReservationId:", eventMessage);
            StringAssert.Contains("Customer: John", eventMessage);
            StringAssert.Contains("Reserving Car 1 for John", stringWriter.ToString());
            
            // Act & Assert - List available after reservation
            stringWriter.GetStringBuilder().Clear();
            rentalCompany.ListAvailableVechicles();
            string afterReservationOutput = stringWriter.ToString();
            StringAssert.DoesNotContain("Id: 1, Brand: Toyota, Model: Corolla", afterReservationOutput);
            StringAssert.Contains("Id: 2, Brand: Honda, Model: CBR", afterReservationOutput);
            
            // Act & Assert - Cancel reservation
            stringWriter.GetStringBuilder().Clear();
            rentalCompany.CancelReservation(1);
            StringAssert.Contains("Cancel Car reservation 1", stringWriter.ToString());
            
            // Act & Assert - List available after cancellation
            stringWriter.GetStringBuilder().Clear();
            rentalCompany.ListAvailableVechicles();
            string afterCancellationOutput = stringWriter.ToString();
            StringAssert.Contains("Id: 1, Brand: Toyota, Model: Corolla", afterCancellationOutput);
            StringAssert.Contains("Id: 2, Brand: Honda, Model: CBR", afterCancellationOutput);
        }
    }
}