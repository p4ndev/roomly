using Microsoft.AspNetCore.Mvc;
using Server.Controller.Setup;
using Server.Data.Interfaces;
using Server.Data.Enums;
using Server.Data.Dtos;
using Moq;

namespace Server.Test.Setup;

public class AuthenticationControllerTests
{
    private readonly CancellationToken              _token;
    private readonly Mock<SetupServiceInterface>    _setupService;
    private readonly Mock<TokenServiceInterface>    _tokenService;
    private readonly AuthenticationController       _authenticationController;

    public AuthenticationControllerTests()
    {
        _setupService               = new();
        _tokenService               = new();
        _token                      = It.IsAny<CancellationToken>();
        _authenticationController   = new(_setupService.Object, _tokenService.Object);
    }

    [Theory]
    [InlineData("tH>M>o7Q", "J3PkxKv8YvwUMK8uaZY6cQ==", RoleEnum.Viewer)]
    [InlineData("D9-J1wmk", "G7gYZqy3nHpraJ9FCCfoBQ==", RoleEnum.Coordinator)]
    [InlineData("g|5>N$(M", "Kh5O/naBc2cLy11qucBpsg==", RoleEnum.Administrator)]
    public async Task Connect_Valid_Data(string userPassword, string userToken, RoleEnum userRole)
    {
        // Arrange
        string  serverToken = string.Empty,
                serverRole = string.Empty;

        _tokenService
            .Setup(s => s.Generate(userRole))
            .Returns(userToken);

        _setupService
            .Setup(s => s.FindAsync(userPassword, _token))
            .ReturnsAsync(userRole);

        // Act
        ActionResult<AuthenticationDto> sut = await _authenticationController.ConnectAsync(userPassword, _token);
        
        // Assert
        var httpResult = Assert.IsType<OkObjectResult>(sut.Result);
        var model = Assert.IsType<AuthenticationDto>(httpResult.Value);

        Assert.Equal(userToken, model.Token);
        Assert.Equal(userRole.ToString(), model.Role);
    }
}