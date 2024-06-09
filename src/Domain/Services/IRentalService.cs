using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Domain.Services;
public interface IRentalService
{
    Task<Rental> GetRentalByIdAsync(int rentalId);
    Task<IEnumerable<Rental>> GetAllRentalsAsync();
    Task CreateRentalAsync(Rental rental);
    Task UpdateRentalAsync(int rentalId, Rental rental);
    Task DeleteRentalAsync(int rentalId);
    Task ReturnBikeAsync(int rentalId);
}
