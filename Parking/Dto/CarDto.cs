using Parking.Enum;

namespace Parking.Dto;

public class CarDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int ClientId { get; set; }
    public CarType CarType { get; set; }
}