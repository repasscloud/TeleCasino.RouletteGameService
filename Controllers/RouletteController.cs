using Microsoft.AspNetCore.Mvc;
using TeleCasino.RouletteGameService.Models;
using TeleCasino.RouletteGameService.Services.Interface;

namespace TeleCasino.RouletteGameApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteGameService _rouletteGameService;

        public RouletteController(IRouletteGameService rouletteGameService)
        {
            _rouletteGameService = rouletteGameService;
        }

        /// <summary>
        /// Plays a Roulette game and returns the result with a generated video file path.
        /// </summary>
        /// <param name="wager">Amount wagered (only 1, 2, or 5 are valid).</param>
        /// <param name="betArg">
        /// Betting argument string (examples: n17, split_14_17, corner_1_2_4_5, col1, red, even, low, _1st12, basket, trio12, trio23).
        /// </param>
        /// <param name="gameSessionId">Game session identifier.</param>
        [HttpPost("play")]
        [ProducesResponseType(typeof(RouletteResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PlayGame(
            [FromQuery] int wager,
            [FromQuery] string betArg,
            [FromQuery] int gameSessionId)
        {
            if (wager <= 0)
                return BadRequest("Wager must be a positive integer.");

            if (string.IsNullOrWhiteSpace(betArg))
                return BadRequest("Bet argument cannot be empty.");

            // validate betArg matches a valid RouletteBetType enum member
            if (!Enum.TryParse<RouletteBetType>(betArg, true, out _))
                return BadRequest($"Invalid bet argument '{betArg}'. Must match a defined RouletteBetType enum value.");

            try
            {
                var result = _rouletteGameService.PlayGame(wager, betArg, gameSessionId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
