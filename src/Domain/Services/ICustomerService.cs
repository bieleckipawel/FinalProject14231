using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Domain.Services;
public interface ICustomerService
{
    Task<Customer> GetUserByIdAsync(int userId);
    Task<IEnumerable<Customer>> GetAllUsersAsync();
    Task CreateUserAsync(Customer user);
    Task UpdateUserAsync(int userId, Customer user);
    Task DeleteUserAsync(int userId);
}
