using Microsoft.AspNetCore.Mvc;
using Server.Controller.Setup;
using Server.Data.Interfaces;
using Server.Data.Dtos;
using Moq;

namespace Server.Test.Setup;

public class InstallationControllerTests
{
    private readonly InstallationDto                    _stub;
    private readonly CancellationToken                  _token;
    private readonly Mock<SetupServiceInterface>        _setupService;
    private readonly Mock<PasswordServiceInterface>     _passwordService;
    private readonly InstallationController             _installationController;

    public InstallationControllerTests()
    {
        _setupService           = new();
        _passwordService        = new();
        _token                  = It.IsAny<CancellationToken>();
        _stub                   = new("Dell Morumbi", "logo.png");
        _installationController = new(_setupService.Object, _passwordService.Object);
    }

    [Fact]
    public async Task No_Input()
    {
        // Arrange
        var stub = It.IsAny<InstallationDto>();

        // Act
        var sut = await _installationController
            .InstallationAsync(stub, _token);

        // Assert
        Assert.IsType<UnsupportedMediaTypeResult>(sut);
    }

    [Fact]
    public async Task Empty_Required_Input()
    {
        // Arrange
        var stub = new InstallationDto(string.Empty, string.Empty);

        // Act
        var sut = await _installationController
            .InstallationAsync(stub, _token);

        // Assert
        Assert.IsType<UnsupportedMediaTypeResult>(sut);
    }

    [Fact]
    public async Task Can_Expose_Password_Once()
    {
        // Arrange
        _setupService
            .Setup(s => s.ExistAsync(_token))
            .ReturnsAsync(true);

        // Act
        var sut = await _installationController
            .InstallationAsync(_stub, _token);

        // Assert
        Assert.IsType<ConflictObjectResult>(sut);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task Install_Successfully(bool state)
    {
        // Arrange
        _setupService
            .Setup(s => s.ExistAsync(_token))
            .ReturnsAsync(false);
        
        _setupService
            .Setup(s => s.IsValid(_stub))
            .Returns(true);

        _passwordService
            .Setup(s => s.Generate())
            .Returns("TestPassword");

        _setupService
            .Setup(s => s.InstallAsync(_stub, It.IsAny<AccessDto>(), _token))
            .ReturnsAsync(state);

        // Act
        var sut = await _installationController.InstallationAsync(_stub, _token);

        // Assert
        if (state)
            Assert.IsType<CreatedResult>(sut);
        else
            Assert.IsType<BadRequestObjectResult>(sut);
    }
}