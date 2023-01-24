using Parking.Model;

namespace Parking.Requests;

public class AddClientRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int Budget { get; set; }
    public List<Car>? Cars { get; set; }
}