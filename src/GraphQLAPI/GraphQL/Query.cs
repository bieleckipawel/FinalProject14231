using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Query
{
    private readonly IBikeService _bikeService;
    private readonly ICustomerService _customerService;
    private readonly IRentalService _rentalService;

    public Query(IBikeService bikeService, ICustomerService customerService, IRentalService rentalService)
    {
        _bikeService = bikeService;
        _customerService = customerService;
        _rentalService = rentalService;
    }

    public async Task<Bike> GetBikeById(int bikeId) => await _bikeService.GetBikeByIdAsync(bikeId);

    public async Task<IEnumerable<Bike>> GetAllBikes() => await _bikeService.GetAllBikesAsync();

    public async Task<Customer> GetCustomerById(int customerId) => await _customerService.GetUserByIdAsync(customerId);

    public async Task<IEnumerable<Customer>> GetAllCustomers() => await _customerService.GetAllUsersAsync();

    public async Task<Rental> GetRentalById(int rentalId) => await _rentalService.GetRentalByIdAsync(rentalId);

    public async Task<IEnumerable<Rental>> GetAllRentals() => await _rentalService.GetAllRentalsAsync();
}
