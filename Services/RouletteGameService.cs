using System.Security.Cryptography;
using NanoidDotNet;
using TeleCasino.RouletteGameService.Models;
using TeleCasino.RouletteGameService.Services.Interface;

namespace TeleCasino.RouletteGameService.Services;

public class RouletteGameService : IRouletteGameService
{
    private readonly string _htmlDir;
    public RouletteGameService(IConfiguration config)
        => _htmlDir = config["HtmlDir"] ?? "/app/wwwroot";

    public RouletteResult PlayGame(int wager, string betArg, int gameSessionId)
    {
        if (!new[] { 1, 2, 5 }.Contains(wager))
            throw new ArgumentException("Valid wager is $1, $2 or $5 only.");

        var rouletteResultId = Nanoid.Generate();

        // generate roulette spin
        int spin;
        using (var rng = RandomNumberGenerator.Create())
        {
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            spin = BitConverter.ToInt32(bytes, 0) & int.MaxValue; // non-negative
            spin %= 37;
        }
        string color = GetColor(spin);

        // parse bet
        var (betType, betParams) = ParseBet(betArg);

        bool win = BetMatches(betType, betParams, spin);
        int payout = win ? wager * GetPayoutMultiplier(betType) : 0;

        // determine animation filename based on colour and spin result
        string animation = color == "green"
            ? Path.Combine(_htmlDir, $"green_{spin}.mp4")
            : Path.Combine(_htmlDir, $"{color}_{spin}.mp4");

        // convert color string to enum
        if (!Enum.TryParse<RoulettePocketColor>(color, out var colorEnum))
            throw new Exception($"Unknown color type '{color}'");

        if (!Enum.TryParse<RouletteBetType>(betArg, out var betTypeEnum))
            throw new Exception($"Unknown bet type '{betArg}'");

        var netGain = payout - wager;

        var result = new RouletteResult
        {
            Id = rouletteResultId,
            Wager = wager,
            Payout = payout,
            NetGain = netGain,
            VideoFile = animation,
            Win = netGain > 0
                ? true
                : false,
            BetType = betTypeEnum,
            Pocket = spin,
            Color = colorEnum,
            GameSessionId = gameSessionId
        };

        return result;
    }

    private static string GetColor(int n)
    {
        if (n == 0) return "green";
        if (RouletteProperties.RedNumbers.Contains(n)) return "red";
        return "black";
    }

    private static (string BetType, List<int> Params) ParseBet(string betArg)
    {
        if (betArg.StartsWith("n")) // Straight up
            return ("straight", new List<int> { int.Parse(betArg.Substring(1)) });
        if (betArg.StartsWith("split_"))
            return ("split", betArg.Substring(6).Split('_').Select(int.Parse).ToList());
        if (betArg.StartsWith("street_"))
            return ("street", new List<int> { int.Parse(betArg.Substring(7)) });
        if (betArg.StartsWith("corner_"))
            return ("corner", betArg.Substring(7).Split('_').Select(int.Parse).ToList());
        if (betArg.StartsWith("sixline_"))
            return ("sixline", new List<int> { int.Parse(betArg.Substring(8)) });
        if (betArg.StartsWith("trio12")) // trio_0_1_2
            return ("trio", new List<int> { 0, 1, 2 });
        if (betArg.StartsWith("trio23")) // trio_0_2_3
            return ("trio", new List<int> { 0, 2, 3 });
        if (betArg.StartsWith("basket"))
            return ("basket", new List<int> { 0, 1, 2, 3 });
        if (betArg is "col1" or "col2" or "col3")
            return (betArg, new List<int>());
        if (betArg is "_1st12" or "_2nd12" or "_3rd12" or "red" or "black" or "odd" or "even" or "low" or "high")
            return (betArg, new List<int>());
        throw new Exception("Invalid bet format.");
    }
    
    private static bool BetMatches(string betType, List<int> param, int spin)
    {
        switch (betType)
        {
            case "straight": return spin == param[0];
            case "split": return param.Count == 2 && (spin == param[0] || spin == param[1]);
            case "street":
                {
                    int start = param[0];
                    return Enumerable.Range(start, 3).Contains(spin);
                }
            case "corner": return param.Contains(spin);
            case "sixline":
                {
                    int start = param[0];
                    return Enumerable.Range(start, 6).Contains(spin);
                }
            case "trio": return param.Contains(spin);
            case "basket": return param.Contains(spin);
            case "col1": return spin != 0 && RouletteProperties.NumberProps[spin].Column == 1;
            case "col2": return spin != 0 && RouletteProperties.NumberProps[spin].Column == 2;
            case "col3": return spin != 0 && RouletteProperties.NumberProps[spin].Column == 3;
            case "_1st12": return spin >= 1 && spin <= 12;
            case "_2nd12": return spin >= 13 && spin <= 24;
            case "_3rd12": return spin >= 25 && spin <= 36;
            case "red": return RouletteProperties.RedNumbers.Contains(spin);
            case "black": return RouletteProperties.BlackNumbers.Contains(spin);
            case "odd": return spin != 0 && (spin % 2 == 1);
            case "even": return spin != 0 && (spin % 2 == 0);
            case "low": return spin >= 1 && spin <= 18;
            case "high": return spin >= 19 && spin <= 36;
            default: return false;
        }
    }

    private static int GetPayoutMultiplier(string betType)
        => RouletteProperties.BetPayouts.TryGetValue(betType, out var val) ? val : 0;
}