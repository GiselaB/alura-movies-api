using Microsoft.AspNetCore.Mvc;
using FluentResults;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeService _filmeService;
    public FilmeController(FilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = readDto.Id }, readDto);
    }

    [HttpGet]
    [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
    public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
    {
        List<ReadFilmeDto> filmesDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
        if (filmesDto != null) return Ok(filmesDto);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        ReadFilmeDto filmeDto = _filmeService.RecuperaFilmePorId(id);
        if (filmeDto != null) return Ok(filmeDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        Result resultado = _filmeService.AtualizaFilme(id, filmeDto);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        Result resultado = _filmeService.DeletaFilme(id);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }
}
