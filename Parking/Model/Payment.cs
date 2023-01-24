namespace Parking.Model;

public class Payment
{
    public int Id { get; set; }
    public double Value { get; set; }
    public double StartBalance { get; set; }
    public double EndBalance { get; set; }
    public int ClientId { get; set; }
}