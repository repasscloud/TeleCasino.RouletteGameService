using Microsoft.AspNetCore.Mvc;
namespace TeleCasino.RouletteGameService.Controllers;
[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Healthy");
    }
}