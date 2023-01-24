using Microsoft.EntityFrameworkCore;
using Parking.Context;
using Parking.Interfaces;
using Parking.Model;

namespace Parking.Services;

public class CarService : ICarDbService
{
    private readonly ParkingContext _parkingContext;

    public CarService(ParkingContext parkingContext)
    {
        _parkingContext = parkingContext;
    }

    public Task<List<Car>> GetAllCars()
    {
        return _parkingContext.Cars.ToListAsync();
    }

    public async Task<Car> AddCar(Car car)
    {
        var client = _parkingContext.Clients.FirstOrDefault(x => x.Id == car.ClientId) ?? throw new ArgumentException();

        var newCar = new Car
        {
            Number = car.Number,
            CarType = car.CarType,
            ClientId = car.ClientId
        };
        
        //вопрос про исправление
        client.Cars.Add(newCar);
        
        _parkingContext.Cars.Add(newCar);
        
        await _parkingContext.SaveChangesAsync();
        
        return newCar;
    }

    public async Task<Car> ChangeCarInfo(int id, Car newCarInfo)
    {
        var resultCar = _parkingContext.Cars.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException();

        resultCar.CarType = newCarInfo.CarType;
        resultCar.Number = newCarInfo.Number;

        await _parkingContext.SaveChangesAsync();

        return resultCar;
    }

    public async Task<Car> DeleteCar(int id)
    {
        var car = _parkingContext.Cars.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException();

        _parkingContext.Cars.Remove(car);

        await _parkingContext.SaveChangesAsync();

        return car;
    }
}