using System.Text.RegularExpressions;
using Server.Data.Interfaces;
using System.Text;

namespace Server.Business.Services;

public sealed class PasswordService : PasswordServiceInterface
{
    private Random? _random;
    private StringBuilder _parser;

    private readonly int _maxItems;
    private readonly string _numbers;
    private readonly string _symbols;
    private readonly string _content;
    private readonly string _upperCase;
    private readonly string _lowerCase;

    public PasswordService()
    {
        _maxItems = 8;
        _parser = new();
        _numbers = "0123456789";
        _upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        _lowerCase = "abcdefghijklmnopqrstuvwxyz";
        _symbols = "!@#$%^&*()-_=+[]{}|;:',.<>?/";
        _content = _upperCase + _symbols + _lowerCase + _numbers;
    }

    public string Generate()
    {
        _random = new Random();

        char[] composition = [
            _upperCase[_random.Next(_upperCase.Length)],
            _lowerCase[_random.Next(_lowerCase.Length)],
            _numbers[_random.Next(_numbers.Length)],
            _symbols[_random.Next(_symbols.Length)]
        ];

        char[] remaining = Enumerable
            .Range(0, _maxItems - composition.Length)
            .Select(_ => _content[_random.Next(_content.Length)])
                .ToArray();

        char[] output = composition.Concat(remaining).ToArray();

        return new string(output.OrderBy(_ => _random.Next()).ToArray());
    }

    public bool Validate(string input)
    {
        _parser.Append(@"^");

        // At least one uppercase
        _parser.Append(@"(?=.*[A-Z])");

        // At least one lowercase
        _parser.Append(@"(?=.*[a-z])");

        // At least one number
        _parser.Append(@"(?=.*\d)");

        // At least one symbol
        _parser.Append(@"(?=.*[!@#$%^&*()_\-+=\[\]{}|;:',.<>?/])");

        // At least max count available
        _parser.Append(@".{" + _maxItems + ",}");

        _parser.Append(@"$");

        var validator = new Regex(_parser.ToString());

        return validator.IsMatch(input);
    }
}