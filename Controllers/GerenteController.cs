using Microsoft.AspNetCore.Mvc;
using FluentResults;
using FilmesAPI.Services;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
    private GerenteService _gerenteService;
    public GerenteController(GerenteService gerenteService)
    {
        _gerenteService = gerenteService;
    }
    [HttpPost]
    public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
    {
        ReadGerenteDto readDto = _gerenteService.AdicionaGerente(gerenteDto);
        return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto.Id }, readDto);
    }

    [HttpGet]
    public IActionResult RecuperaGerentes()
    {
        List<ReadGerenteDto> gerentes = _gerenteService.RecuperaGerentes();
        return Ok(gerentes);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaGerentePorId(int id)
    {
        ReadGerenteDto gerenteDto = _gerenteService.RecuperaGerentePorId(id);
        if (gerenteDto != null) return Ok(gerenteDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
    {
        Result resultado = _gerenteService.AtualizaGerente(id, gerenteDto);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaGerente(int id)
    {
        Result resultado = _gerenteService.DeletaGerente(id);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }
}
