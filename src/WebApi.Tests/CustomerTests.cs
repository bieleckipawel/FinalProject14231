using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Castle.Core.Resource;

namespace WebApi.Tests.CustomerTests;
public class CustomerTests
{
    private readonly Mock<ICustomerService> _mockService;
    private readonly CustomerController _controller;

    public CustomerTests()
    {
        _mockService = new Mock<ICustomerService>();
        _controller = new CustomerController(_mockService.Object);
    }

    [Fact]
    public async Task GetCustomerById_ReturnsOkResult_WithCustomer()
    {
        int customerId = 1;
        var customer = new Customer { Id = customerId, FirstName = "Jan", LastName = "Nowak" };
        _mockService.Setup(service => service.GetUserByIdAsync(customerId)).ReturnsAsync(customer);

        var result = await _controller.GetCustomerById(customerId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedCustomer = Assert.IsType<Customer>(okResult.Value);
        Assert.Equal(customerId, returnedCustomer.Id);
    }

    [Fact]
    public async Task GetAllCustomers_ReturnsOkResult_WithListOfCustomers()
    {
        var customers = new List<Customer> { new Customer { Id = 1, FirstName = "Jan", LastName = "Nowak" }, new Customer { Id = 2, FirstName = "Wojciech", LastName = "Nowak" } };
        _mockService.Setup(service => service.GetAllUsersAsync()).ReturnsAsync(customers);

        var result = await _controller.GetAllCustomers();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedCustomers = Assert.IsType<List<Customer>>(okResult.Value);
        Assert.Equal(2, returnedCustomers.Count);
    }

    [Fact]
    public async Task CreateCustomer_ReturnsCreatedAtActionResult_WithCustomer()
    {
        var customer = new Customer { Id = 1, FirstName = "Jan", LastName = "Nowak" };

        var result = await _controller.CreateCustomer(customer);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedCustomer = Assert.IsType<Customer>(createdAtActionResult.Value);
        Assert.Equal(customer.Id, returnedCustomer.Id);
    }

    [Fact]
    public async Task UpdateCustomer_ReturnsNoContentResult()
    {
        var customer = new Customer { Id = 1, FirstName = "Jan", LastName = "Nowak" };

        var result = await _controller.UpdateCustomer(customer.Id, customer);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteCustomer_ReturnsNoContentResult()
    {
        int customerId = 1;

        var result = await _controller.DeleteCustomer(customerId);

        Assert.IsType<NoContentResult>(result);
    }
}
