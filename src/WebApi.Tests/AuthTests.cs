using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using WebApi.Controllers;
using System.Collections.Generic;
using Xunit;
namespace WebApi.Tests.AuthTests;
public class AuthTests
{
    private readonly AuthController _controller;
    private readonly Mock<IConfiguration> _mockConfig;

    public AuthTests()
    {
        _mockConfig = new Mock<IConfiguration>();
        _mockConfig.SetupGet(x => x["Jwt:Key"]).Returns("Test1234!DluzszyKlucz!!12312312323!");
        _mockConfig.SetupGet(x => x["Jwt:ExpireMinutes"]).Returns("60");
        _mockConfig.SetupGet(x => x["Jwt:Issuer"]).Returns("Test");
        _mockConfig.SetupGet(x => x["Jwt:Audience"]).Returns("User");

        _controller = new AuthController(_mockConfig.Object);
    }

    [Fact]
    public void Login_WithValidCredentials_ReturnsOkResult()
    {
        var model = new LoginModel { Username = "test", Password = "password" };

        var result = _controller.Login(model);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Login_WithInvalidCredentials_ReturnsUnauthorizedResult()
    {
        var model = new LoginModel { Username = "wrong", Password = "wrong" };

        var result = _controller.Login(model);

        Assert.IsType<UnauthorizedResult>(result);
    }
}
