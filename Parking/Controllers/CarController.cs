using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Parking.Context;
using Parking.Dto;
using Parking.Interfaces;
using Parking.Model;
using Parking.Services;

namespace Parking.Controllers;

public class CarController : Controller
{
    private readonly ICarDbService _service;
    private readonly ParkingContext _context;

    public CarController(ICarDbService service, ParkingContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpGet("GetClients")]
    [ProducesResponseType(typeof(IEnumerable<CarDto>), 200)]
    [ProducesResponseType(typeof(List<Task>), 200)]
    public async Task<IActionResult> GetAllCars()
    {
        return Ok(await _service.GetAllCars());
    }

    [HttpPost("AddCar")]
    [ProducesResponseType(typeof(CarDto), 200)]
    public async Task<IActionResult> AddCar([FromBody] Car car)
    {
        var newCar = new Car
        {
            Number = car.Number,
            ClientId = car.ClientId,
            CarType = car.CarType
        };
        
        await _context.Cars.AddAsync(newCar);
        await _context.SaveChangesAsync();

        var resultCar = new Car
        {
            Id = newCar.Id,
            Number = newCar.Number,
            ClientId = newCar.ClientId,
            CarType = newCar.CarType
        };

        return Ok(resultCar);
    }

    [HttpGet("ChangeCarInfo")]
    [ProducesResponseType(typeof(CarDto), 200)]
    [ProducesResponseType(typeof(object), 404)]
    public async Task<IActionResult> ChangeCarInfo(int id, [FromBody] Car car)
    {
        return Ok(await _service.ChangeCarInfo(id, car));
        //ToCarDtoExstension?
    }

    [HttpDelete("DeleteCar")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(object), 404)]
    public async Task<IActionResult> DeleteCar(int id)
    {
        return Ok(await _service.DeleteCar(id));
    }
}