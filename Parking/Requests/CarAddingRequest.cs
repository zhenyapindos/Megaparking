using Parking.Enum;

namespace Parking.Requests;

public class CarAddingRequest
{
    public string Number { get; set; }
    public int ClientId { get; set; }
    public CarType CarType { get; set; }
}