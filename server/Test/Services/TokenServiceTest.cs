using Server.Business.Services;
using Server.Data.Interfaces;
using Xunit.Abstractions;
using Server.Data.Enums;
using Moq;

namespace Server.Test.Services;

public sealed class TokenServiceTest
{
    private readonly TokenServiceInterface _sut;
    private readonly Mock<IConfiguration> _config;
    private readonly ITestOutputHelper _logger;

    // Arrange
    public TokenServiceTest(ITestOutputHelper output)
    {
        _config = new Mock<IConfiguration>();

        _config
            .Setup(c => c["Secret"]) // Dev version
            .Returns("aB3dF8gH9jK1lM2nP0qR5tS7uV6wXyZ4");

        _sut = new TokenService(_config.Object);

        _logger = output;
    }

    [Theory]
    [InlineData(RoleEnum.Viewer, "J3PkxKv8YvwUMK8uaZY6cQ==")]
    [InlineData(RoleEnum.Coordinator, "G7gYZqy3nHpraJ9FCCfoBQ==")]
    [InlineData(RoleEnum.Administrator, "Kh5O/naBc2cLy11qucBpsg==")]
    public void Generate_Token_By(RoleEnum role, string content)
    {
        // Act
        var token = _sut.Generate(role);
        _logger.WriteLine(token);

        // Assert
        Assert.NotNull(token);
        Assert.NotEmpty(token);
        Assert.Equal(token, content);
    }
}