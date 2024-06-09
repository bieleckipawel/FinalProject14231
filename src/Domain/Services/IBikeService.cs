using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Domain.Services;
public interface IBikeService
{
    Task<Bike> GetBikeByIdAsync(int bikeId);
    Task<IEnumerable<Bike>> GetAllBikesAsync();
    Task CreateBikeAsync(Bike bike);
    Task UpdateBikeAsync(int bikeId, Bike bike);
    Task DeleteBikeAsync(int bikeId);
}
