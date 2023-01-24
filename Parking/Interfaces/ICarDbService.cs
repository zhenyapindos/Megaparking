using Parking.Model;

namespace Parking.Interfaces;

public interface ICarDbService
{
    public Task<List<Car>> GetAllCars();
    public Task<Car> AddCar(Car car);
    public Task<Car> ChangeCarInfo(int id, Car car);
    public Task<Car> DeleteCar(int id);
}