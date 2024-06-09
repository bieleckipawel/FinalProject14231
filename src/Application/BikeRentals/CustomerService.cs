using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Repositories;
using FinalProject14231.Domain.Services;

namespace FinalProject14231.Application.BikeRentals;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _userRepository;

    public CustomerService(ICustomerRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<Customer> GetUserByIdAsync(int userId)
    {
        var userEntity = await _userRepository.GetByIdAsync(userId);
        if (userEntity == null)
        {
            throw new Exception($"User {userId} not found");
        }
        return userEntity;
    }

    public async Task<IEnumerable<Customer>> GetAllUsersAsync()
    {
        var userEntities = await _userRepository.GetAllAsync();
        if(userEntities == null)
        {
            throw new Exception("There are no users");
        }
        return userEntities;
    }

    public async Task CreateUserAsync(Customer user)
    {
        await _userRepository.AddAsync(user);
    }

    public async Task UpdateUserAsync(int userId, Customer user)
    {
        var existingUserEntity = await _userRepository.GetByIdAsync(userId);
        if (existingUserEntity == null)
        {
            throw new Exception($"User {userId} not found");
        }

        existingUserEntity.FirstName = user.FirstName;
        existingUserEntity.LastName = user.LastName;
        existingUserEntity.Email = user.Email;
        await _userRepository.UpdateAsync(existingUserEntity);
    }

    public async Task DeleteUserAsync(int userId)
    {
        var userEntity = await _userRepository.GetByIdAsync(userId);
        if(userEntity.HasBikeRented)
        {
            throw new Exception("User has rented bike");
        }
        await _userRepository.DeleteAsync(userEntity);
    }
}
