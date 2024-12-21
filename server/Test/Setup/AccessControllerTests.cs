using Microsoft.AspNetCore.Mvc;
using Server.Controller.Setup;
using Server.Data.Interfaces;
using Server.Data.Dtos;
using Moq;

namespace Setup;

public class AccessControllerTests
{
    private readonly AccessDto                      _dto;
    private readonly CancellationToken              _token;
    private readonly Mock<SetupServiceInterface>    _setupService;
    private readonly AccessController               _accessController;

    public AccessControllerTests()
    {
        _setupService       = new();
        _dto                = new("111", "222", "333");
        _accessController   = new(_setupService.Object);
        _token              = It.IsAny<CancellationToken>();
    }

    [Fact]
    public async Task UnAvailable_Previous_Settings()
    {
        // Arrange
        _setupService.Setup(s => s.LoadAsync(_token)).ReturnsAsync(It.IsAny<AccessDto?>());

        // Act
        var sut = await _accessController.PasswordAsync(_token);

        // Assert
        Assert.IsType<NotFoundObjectResult>(sut.Result);
    }

    [Fact]
    public async Task Available_Previous_Settings()
    {
        // Arrange
        _setupService.Setup(s => s.LoadAsync(_token)).ReturnsAsync(_dto);

        // Act
        var sut = await _accessController.PasswordAsync(_token);

        // Assert
        Assert.IsType<OkObjectResult>(sut.Result);
    }    
}