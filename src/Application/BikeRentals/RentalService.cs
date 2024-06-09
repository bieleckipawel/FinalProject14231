using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Domain.Services;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Repositories;

namespace FinalProject14231.Application.BikeRentals;
public class RentalService: IRentalService
{
    private readonly IRentalRepository _rentalRepository;
    public RentalService(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
    }

    public async Task<Rental> GetRentalByIdAsync(int rentalId)
    {
        var rentalEntity = await _rentalRepository.GetByIdAsync(rentalId);
        if (rentalEntity == null)
        {
            throw new Exception($"Rental {rentalId} not found");
        }
        return rentalEntity;
    }

    public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
    {
        var rentalEntities = await _rentalRepository.GetAllAsync();
        if (rentalEntities == null)
        {
            throw new Exception("There are no rentals");
        }
        return rentalEntities;
    }

    public async Task CreateRentalAsync(Rental rental)
    {
        await _rentalRepository.AddAsync(rental);
    }

    public async Task UpdateRentalAsync(int rentalId, Rental rental)
    {
        var existingRentalEntity = await _rentalRepository.GetByIdAsync(rentalId);
        if (existingRentalEntity == null)
        {
            throw new Exception($"Rental {rentalId} not found.");
        }
        if(rental.StartDate > rental.EndDate)
        {
            throw new Exception("Start date must be before end date.");
        }
        existingRentalEntity.StartDate = rental.StartDate;
        existingRentalEntity.EndDate = rental.EndDate;
        existingRentalEntity.Price = (rental.EndDate - rental.StartDate).Days * rental.RentedBike.Price;
        existingRentalEntity.RentedBike.IsRented = true;

        await _rentalRepository.UpdateAsync(existingRentalEntity);
    }

    public async Task DeleteRentalAsync(int rentalId)
    {
        var rentalEntity = await _rentalRepository.GetByIdAsync(rentalId);
        await _rentalRepository.DeleteAsync(rentalEntity);
    }
    public async Task ReturnBikeAsync(int rentalId)
    {
        var rentalEntity = await _rentalRepository.GetByIdAsync(rentalId);
        rentalEntity.Renter.HasBikeRented = false;
        rentalEntity.RentedBike.IsRented = false;
    }
}
