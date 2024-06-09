using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.Tests.BikeTests;
public class BikeTests
{
    private readonly Mock<IBikeService> _mockService;
    private readonly BikeController _controller;

    public BikeTests()
    {
        _mockService = new Mock<IBikeService>();
        _controller = new BikeController(_mockService.Object);
    }

    [Fact]
    public async Task GetBikeById_ReturnsOkResult()
    {
        int bikeId = 1;
        var bike = new Bike { Id = bikeId, Name = "Kross", Description = "Hexagon 8" };
        _mockService.Setup(service => service.GetBikeByIdAsync(bikeId)).ReturnsAsync(bike);

        var result = await _controller.GetBikeById(bikeId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBike = Assert.IsType<Bike>(okResult.Value);
        Assert.Equal(bikeId, returnedBike.Id);
    }

    [Fact]
    public async Task GetAllBikes_ReturnsOkResult()
    {
        var bikes = new List<Bike> { new Bike { Id = 1, Name = "Kross", Description = "Hexagon 8" } };
        _mockService.Setup(service => service.GetAllBikesAsync()).ReturnsAsync(bikes);

        var result = await _controller.GetAllBikes();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBikes = Assert.IsType<List<Bike>>(okResult.Value);
        Assert.Single(returnedBikes);
    }

    [Fact]
    public async Task CreateBike_ReturnsCreatedAtActionResult()
    {
        var bike = new Bike { Id = 1, Name = "Kross", Description = "Hexagon 8" };

        var result = await _controller.CreateBike(bike);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedBike = Assert.IsType<Bike>(createdAtActionResult.Value);
        Assert.Equal(bike.Id, returnedBike.Id);
    }

    [Fact]
    public async Task UpdateBike_ReturnsNoContentResult()
    {
        var bike = new Bike { Id = 1, Name = "Kross", Description = "Hexagon 5" };

        var result = await _controller.UpdateBike(bike.Id, bike);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteBike_ReturnsNoContentResult()
    {
        int bikeId = 1;

        var result = await _controller.DeleteBike(bikeId);

        Assert.IsType<NoContentResult>(result);
    }
}
