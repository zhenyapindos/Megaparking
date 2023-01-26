using Parking.Context;
using Parking.Model;
using Parking.Utilities;

namespace Parking.Services;

public class PaymentService
{
    private readonly ParkingContext _context;

    public PaymentService(ParkingContext context)
    {
        _context = context;
    }

    public async Task<List<Payment>> CreatePayment(int clientId)
    {
        var client = _context.Clients.FirstOrDefault(x => x.Id == clientId) ?? throw new ArgumentException();
        var paymentsList = new List<Payment>();
        
        foreach (var car in client.Cars)
        {
            var payment = new Payment
            {
                Value = car.GetRate(),
                ClientId = client.Id,
                StartBalance = client.Budget,
                EndBalance = client.Budget - car.GetRate(),
                CreationTime = DateTime.Now
            };

            client.Budget -= payment.Value;
            
            paymentsList.Add(payment);
        }
        
        await _context.Payments.AddRangeAsync(paymentsList);
        await _context.SaveChangesAsync();

        return paymentsList;
    }
}