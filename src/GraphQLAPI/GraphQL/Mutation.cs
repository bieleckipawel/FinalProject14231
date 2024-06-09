using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Services;
using System.Threading.Tasks;

public class Mutation
{
    private readonly IBikeService _bikeService;
    private readonly ICustomerService _customerService;
    private readonly IRentalService _rentalService;

    public Mutation(IBikeService bikeService, ICustomerService customerService, IRentalService rentalService)
    {
        _bikeService = bikeService;
        _customerService = customerService;
        _rentalService = rentalService;
    }

    public async Task<Bike> CreateBike(Bike bike)
    {
        await _bikeService.CreateBikeAsync(bike);
        return bike;
    }

    public async Task<Bike> UpdateBike(int bikeId, Bike bike)
    {
        await _bikeService.UpdateBikeAsync(bikeId, bike);
        return bike;
    }

    public async Task<bool> DeleteBike(int bikeId)
    {
        await _bikeService.DeleteBikeAsync(bikeId);
        return true;
    }

    public async Task<Customer> CreateCustomer(Customer customer)
    {
        await _customerService.CreateUserAsync(customer);
        return customer;
    }

    public async Task<Customer> UpdateCustomer(int customerId, Customer customer)
    {
        await _customerService.UpdateUserAsync(customerId, customer);
        return customer;
    }

    public async Task<bool> DeleteCustomer(int customerId)
    {
        await _customerService.DeleteUserAsync(customerId);
        return true;
    }

    public async Task<Rental> CreateRental(Rental rental)
    {
        await _rentalService.CreateRentalAsync(rental);
        return rental;
    }

    public async Task<Rental> UpdateRental(int rentalId, Rental rental)
    {
        await _rentalService.UpdateRentalAsync(rentalId, rental);
        return rental;
    }

    public async Task<bool> DeleteRental(int rentalId)
    {
        await _rentalService.DeleteRentalAsync(rentalId);
        return true;
    }

    public async Task<bool> ReturnBike(int rentalId)
    {
        await _rentalService.ReturnBikeAsync(rentalId);
        return true;
    }
}
