using Microsoft.AspNetCore.Mvc;
using Server.Controller.Setup;
using Server.Data.Interfaces;
using Moq;

namespace Server.Test.Setup;

public class StartupControllerTests
{
    private readonly CancellationToken              _token;
    private readonly Mock<SetupServiceInterface>    _setupService;
    private readonly StartupController              _startupController;

    public StartupControllerTests()
    {
        _setupService           = new();
        _token                  = It.IsAny<CancellationToken>();
        _startupController      = new StartupController(_setupService.Object);
    }

    [Fact]
    public async Task Available_Configuration()
    {
        // Arrange
        _setupService.Setup(s => s.ExistAsync(_token)).ReturnsAsync(true);

        // Act
        var sut = await _startupController.StartupAsync();

        // Assert
        Assert.IsType<OkResult>(sut);
    }

    [Fact]
    public async Task UnAvailable_Configuration()
    {
        // Arrange
        _setupService.Setup(s => s.ExistAsync(_token)).ReturnsAsync(false);

        // Act
        var sut = await _startupController.StartupAsync();

        // Assert
        Assert.IsType<NotFoundObjectResult>(sut);
    }
}