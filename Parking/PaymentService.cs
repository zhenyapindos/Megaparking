using Parking.Model;
using Parking.Utilities;

namespace Parking;

public class PaymentService
{
    public void ParkingFee(Client client)
    {
        foreach (var car in client.Cars)
        {
            client.Budget -= car.GetRate();
        }
        //ToDo
    }
}