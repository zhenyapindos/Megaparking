using Parking.Enum;

namespace Parking.Model;

public class Car
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int ClientId { get; set; }
    public CarType CarType { get; set; }
    //тут сделать свойство с множителем оплаты + метод или чё там или вынести отдельно в сервис?    
}