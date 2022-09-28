using Filmes.Services.Data.Dtos.Filme;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Filmes.Services.Interfaces;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly IFilmeService _filmeService;
    public FilmeController(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        var readDto = _filmeService.AdicionaFilme(filmeDto);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = readDto.Id }, readDto);
    }

    [HttpGet]
    [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
    public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
    {
        var filmesDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
        if (filmesDto != null) return Ok(filmesDto);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filmeDto = _filmeService.RecuperaFilmePorId(id);
        if (filmeDto != null) return Ok(filmeDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var resultado = _filmeService.AtualizaFilme(id, filmeDto);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var resultado = _filmeService.DeletaFilme(id);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }
}
