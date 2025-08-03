using TeleCasino.RouletteGameService.Models;

namespace TeleCasino.RouletteGameService.Services.Interface;

public interface IRouletteGameService
{
    RouletteResult PlayGame(int wager, string betArg, int gameSessionId);
}