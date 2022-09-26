using Filmes.Services;
using Filmes.Services.Data.Dtos.Gerente;
using Microsoft.AspNetCore.Mvc;
using FluentResults;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
    private readonly IGerenteService _gerenteService;
    public GerenteController(IGerenteService gerenteService)
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
