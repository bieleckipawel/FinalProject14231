using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Application.Common.Interfaces;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Repositories;
namespace FinalProject14231.Application.BikeRentals;
public class BikeRepository : IBikeRepository
{
    private readonly IApplicationDbContext _dbContext;

    public BikeRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Bike> GetByIdAsync(int bikeId)
    {
        var bike = await _dbContext.Bikes.FindAsync(bikeId);
        if (bike == null)
        {
            throw new Exception($"There is no such bike: {bikeId}");
        }
        return bike;
    }

    public async Task<IEnumerable<Bike>> GetAllAsync()
    {
        return await _dbContext.Bikes.ToListAsync();
    }

    public async Task AddAsync(Bike bike)
    {
        await _dbContext.Bikes.AddAsync(bike);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task UpdateAsync(Bike bike)
    {
        _dbContext.Bikes.Update(bike);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteAsync(Bike bike)
    {
        _dbContext.Bikes.Remove(bike);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}
