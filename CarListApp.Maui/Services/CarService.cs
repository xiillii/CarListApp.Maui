using Bogus;
using CarListApp.Maui.Models;

namespace CarListApp.Maui.Services;

public class CarService
{
    public List<Car> GetCars()
    {
        var faker = new Faker();
        
        return new List<Car>
        {
            new() { Id = 1, Make = faker.Vehicle.Manufacturer(), Model = faker.Vehicle.Model(), Vin = faker.Vehicle.Vin()},
            new() { Id = 2, Make = faker.Vehicle.Manufacturer(), Model = faker.Vehicle.Model(), Vin = faker.Vehicle.Vin()},
            new() { Id = 3, Make = faker.Vehicle.Manufacturer(), Model = faker.Vehicle.Model(), Vin = faker.Vehicle.Vin()},
            new() { Id = 4, Make = faker.Vehicle.Manufacturer(), Model = faker.Vehicle.Model(), Vin = faker.Vehicle.Vin()},
            new() { Id = 5, Make = faker.Vehicle.Manufacturer(), Model = faker.Vehicle.Model(), Vin = faker.Vehicle.Vin()},
            new() { Id = 6, Make = faker.Vehicle.Manufacturer(), Model = faker.Vehicle.Model(), Vin = faker.Vehicle.Vin()},
            new() { Id = 7, Make = faker.Vehicle.Manufacturer(), Model = faker.Vehicle.Model(), Vin = faker.Vehicle.Vin()},
        };
    }
}