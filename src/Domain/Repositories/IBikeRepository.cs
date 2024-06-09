using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Domain.Repositories;
public interface IBikeRepository
{
    Task<IEnumerable<Bike>> GetAllAsync();
    Task<Bike> GetByIdAsync(int id);
    Task AddAsync(Bike bike);
    Task UpdateAsync(Bike bike);
    Task DeleteAsync(Bike bike);
}
