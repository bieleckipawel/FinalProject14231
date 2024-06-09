using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Domain.Repositories;
public interface IRentalRepository
{
    Task<IEnumerable<Rental>> GetAllAsync();
    Task<Rental> GetByIdAsync(int id);
    Task AddAsync(Rental rental);
    Task UpdateAsync(Rental rental);
    Task DeleteAsync(Rental rental);
}
