using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet]
    public IActionResult GetWeather([FromQuery] string country, [FromQuery] string state)
    {
        if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(state))
            return BadRequest(new { message = "País e Estado são obrigatórios." });

        // Simulação de dados de clima (mock)
        var random = new Random();
        var temperature = random.Next(15, 40); // Temperatura entre 15 e 40 graus
        var conditions = new[] { "Ensolarado", "Nublado", "Chuvoso", "Tempestade", "Nevoeiro" };
        var condition = conditions[random.Next(conditions.Length)];

        var response = new
        {
            Country = country,
            State = state,
            Temperature = $"{temperature}°C",
            Condition = condition,
            Date = DateTime.UtcNow
        };

        return Ok(response);
    }
}
