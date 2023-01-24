using Microsoft.EntityFrameworkCore;
using Parking.Model;

namespace Parking.Context;

public class ParkingContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    
    public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
    { }
}