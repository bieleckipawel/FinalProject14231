using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Domain.Repositories;
public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);
    Task AddAsync(Customer user);
    Task UpdateAsync(Customer user);
    Task DeleteAsync(Customer user);
}
