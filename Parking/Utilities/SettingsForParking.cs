using Parking.Enum;
using Parking.Model;

namespace Parking.Utilities;

public static class SettingsForParking
{
    public const double PassengerRate = 3;

    public const double TruckRate = 5;
    //рейты + кол-во мест
    public static double GetRate(this Car car) => car.CarType switch
    {
        CarType.Truck => TruckRate,
        CarType.Passenger => PassengerRate,
        _ => throw new ArgumentOutOfRangeException()
    };
}