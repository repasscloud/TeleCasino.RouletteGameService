namespace TeleCasino.RouletteGameService.Models;

public class RouletteResult
{
    public required string Id { get; set; }
    public int Wager { get; set; }
    public double Payout { get; set; }
    public double NetGain { get; set; }
    public required string VideoFile { get; set; }
    public bool Win { get; set; }

    // game mechanics
    public RouletteBetType BetType { get; set; }
    public int Pocket { get; set; }
    public RoulettePocketColor Color { get; set; }
    public int GameSessionId { get; set; }
}