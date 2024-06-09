using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Application.Common.Interfaces;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Repositories;

namespace FinalProject14231.Application.BikeRentals;
public class RentalRepository : IRentalRepository
{
    private readonly IApplicationDbContext _dbContext;

    public RentalRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Rental> GetByIdAsync(int rentalId)
    {
        var rental = await _dbContext.Rentals.FindAsync(rentalId);
        if(rental == null)
        {
            throw new Exception($"There is no such rental: {rentalId}");
        }
        return rental;
    }

    public async Task<IEnumerable<Rental>> GetAllAsync()
    {
        return await _dbContext.Rentals.ToListAsync();
    }

    public async Task AddAsync(Rental rental)
    {
        await _dbContext.Rentals.AddAsync(rental);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task UpdateAsync(Rental rental)
    {
        _dbContext.Rentals.Update(rental);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteAsync(Rental rental)
    {
        _dbContext.Rentals.Remove(rental);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}
