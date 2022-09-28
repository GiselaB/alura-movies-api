using Filmes.Services.Data.Dtos.Cinema;
using Filmes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private readonly ICinemaService _cinemaService;
    public CinemaController(ICinemaService cinemaService)
    {
        _cinemaService = cinemaService;
    }
    
    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var readDto = _cinemaService.AdicionaCinema(cinemaDto);
        return CreatedAtAction(nameof(RecuperaCinemasPorId), new { readDto.Id }, readDto);
    }

    [HttpGet]
    public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
    {
        var cinemasDto = _cinemaService.RecuperaCinemas(nomeDoFilme);
        if (cinemasDto != null) return Ok(cinemasDto);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemasPorId(int id)
    {
        var readDto = _cinemaService.RecuperaCinemaPorId(id);
        if (readDto != null) return Ok(readDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var resultado = _cinemaService.AtualizaCinema(id, cinemaDto);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        var resultado = _cinemaService.DeletaCinema(id);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }

}
