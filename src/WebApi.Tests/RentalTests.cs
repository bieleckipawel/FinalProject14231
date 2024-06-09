using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.Tests.RentalTests;
public class RentalControllerTests
{
    private readonly Mock<IRentalService> _mockService;
    private readonly RentalController _controller;

    public RentalControllerTests()
    {
        _mockService = new Mock<IRentalService>();
        _controller = new RentalController(_mockService.Object);
    }

    [Fact]
    public async Task GetRentalById_ReturnsOkResult_WithRental()
    {
        int rentalId = 1;
        var rental = new Rental
        {
            Id = rentalId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddHours(2),
            RentedBike = new Bike { Id = 1, Name = "Kross", Description = "Hexagon 8", Price = 100.0},
            Renter = new Customer { Id = 1, FirstName = "Jan", LastName = "Nowak"}
        };
        _mockService.Setup(service => service.GetRentalByIdAsync(rentalId)).ReturnsAsync(rental);

        var result = await _controller.GetRentalById(rentalId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedRental = Assert.IsType<Rental>(okResult.Value);
        Assert.Equal(rentalId, returnedRental.Id);
    }

    [Fact]
    public async Task GetAllRentals_ReturnsOkResult_WithListOfRentals()
    {
        var rentals = new List<Rental>
        {
            new Rental
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                RentedBike = new Bike { Id = 1, Name = "Kross", Description = "Hexagon 8", Price = 100},
                Renter = new Customer { Id = 1, FirstName = "Jan", LastName = "Nowak"}
            },
            new Rental
            {
                Id = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(3),
                RentedBike = new Bike { Id = 2, Name = "Kross", Description = "Hexagon 8", Price = 100.0},
                Renter = new Customer { Id = 2, FirstName = "Wojciech", LastName = "Nowak"}
            }
        };
        _mockService.Setup(service => service.GetAllRentalsAsync()).ReturnsAsync(rentals);

        var result = await _controller.GetAllRentals();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedRentals = Assert.IsType<List<Rental>>(okResult.Value);
        Assert.Equal(2, returnedRentals.Count);
    }

    [Fact]
    public async Task CreateRental_ReturnsCreatedAtActionResult_WithRental()
    {
        var rental = new Rental
        {
            Id = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddHours(2),
            RentedBike = new Bike { Id = 1, Name = "Kross", Description = " Hexagon 8", Price = 100.0 },
            Renter = new Customer { Id = 1, FirstName = "Jan", LastName = "Nowak" }
        };

        var result = await _controller.CreateRental(rental);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedRental = Assert.IsType<Rental>(createdAtActionResult.Value);
        Assert.Equal(rental.Id, returnedRental.Id);
    }

    [Fact]
    public async Task UpdateRental_ReturnsNoContentResult()
    {
        var rental = new Rental
        {
            Id = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddHours(2),
            RentedBike = new Bike { Id = 1, Name = "Kross", Description = " Hexagon 8", Price = 100.0},
            Renter = new Customer { Id = 1, FirstName = "Jan", LastName = "Nowak"}
        };

        var result = await _controller.UpdateRental(rental.Id, rental);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteRental_ReturnsNoContentResult()
    {
        int rentalId = 1;

        var result = await _controller.DeleteRental(rentalId);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task ReturnBike_ReturnsNoContentResult()
    {
        int rentalId = 1;

        var result = await _controller.ReturnBike(rentalId);

        Assert.IsType<NoContentResult>(result);
    }
}
