using Server.Business.Services;
using Server.Data.Interfaces;
using Xunit.Abstractions;

namespace Server.Test.Services;

public sealed class PasswordServiceTest
{
    private readonly PasswordServiceInterface _sut;
    private readonly ITestOutputHelper _logger;
    private readonly int _maxLength;

    // Arrange
    public PasswordServiceTest(ITestOutputHelper output)
    {
        _sut = new PasswordService();
        _logger = output;
        _maxLength = 8;
    }

    [Fact]
    public void Generate_Eight_Password_Length()
    {
        // Act
        var pwd = _sut.Generate();
        _logger.WriteLine(pwd);

        // Assert
        Assert.NotNull(pwd);
        Assert.NotEmpty(pwd);
        Assert.True(pwd.Length.Equals(_maxLength));
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData("12345678")]
    [InlineData("abcdefgh")]
    [InlineData("ABCDEFGH")]
    [InlineData("@@@@@@@@")]
    [InlineData("aB3")]
    [InlineData("aB@")]
    [InlineData("1234")]
    [InlineData("abcd1234")]
    [InlineData("ABCD1234")]
    [InlineData("abcd@#$%")]
    [InlineData("ABCD@#$%")]
    public void Invalid_Password_Input(string data)
    {
        // Act
        var isValid = _sut.Validate(data);

        // Assert
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("A2b1g@4=")]
    [InlineData("5g)A!H1b")]
    [InlineData("A1@bC2$dEf3")]
    public void Valid_Password_Input(string data)
    {
        // Act
        var isValid = _sut.Validate(data);

        // Assert
        Assert.True(isValid);
    }
}