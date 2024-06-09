using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Application.Common.Interfaces;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Repositories;

namespace FinalProject14231.Application.BikeRentals;
public class CustomerRepository : ICustomerRepository
{
    private readonly IApplicationDbContext _dbContext;

    public CustomerRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Customer> GetByIdAsync(int userId)
    {
        var user = await _dbContext.Customers.FindAsync(userId);
        if (user == null)
        {
            throw new Exception($"There is no such user: {userId}");
        }
        return user;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task AddAsync(Customer user)
    {
        await _dbContext.Customers.AddAsync(user);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task UpdateAsync(Customer user)
    {
        _dbContext.Customers.Update(user);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteAsync(Customer user)
    {
        _dbContext.Customers.Remove(user);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}
