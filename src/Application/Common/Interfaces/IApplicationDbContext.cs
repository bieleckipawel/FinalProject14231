using FinalProject14231.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject14231.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Bike> Bikes { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Rental> Rentals { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
