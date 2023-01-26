namespace Parking.Model;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public double Budget { get; set; }
    public List<Payment> Payments { get; set; }
    public List<Car>? Cars { get; set; }
}