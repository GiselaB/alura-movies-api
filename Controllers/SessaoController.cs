using Microsoft.AspNetCore.Mvc;
using FluentResults;
using FilmesAPI.Models;
using FilmesAPI.Services;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private SessaoService _sessaoService;
    public SessaoController(SessaoService sessaoService)
    {
        _sessaoService = sessaoService;
    }

    [HttpPost]
    public IActionResult AdicionaSessao(CreateSessaoDto sessaoDto)
    {
        // problema ao mapear para ReadSessaoDto
        Sessao sessao = _sessaoService.AdicionaSessao(sessaoDto);
        return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
    }

    [HttpGet]
    public IActionResult RecuperaSessoes()
    {
        List<ReadSessaoDto> sessoesDto = _sessaoService.RecuperaSessoes();
        return Ok(sessoesDto);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaSessaoPorId(int id)
    {
        ReadSessaoDto sessaoDto = _sessaoService.RecuperaSessaoPorId(id);
        if (sessaoDto != null) return Ok(sessaoDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
    {
        Result resultado = _sessaoService.AtualizaSessao(id, sessaoDto);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaSessao(int id)
    {
        Result resultado = _sessaoService.DeletaSessao(id);
        if (resultado.IsFailed) return NotFound();
        return NoContent();
    }
}
