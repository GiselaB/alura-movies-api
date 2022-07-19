using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
    private AppDbContext _context;
    private IMapper _mapper;

    public GerenteController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
    {
        Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
        _context.Gerentes.Add(gerente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
    }

    [HttpGet]
    public IActionResult RecuperarGerentes()
    {
        return Ok(_context.Gerentes);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaGerentePorId(int id)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente != null)
        {
            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
            return Ok(gerenteDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente == null)
        {
            return NotFound();
        }
        _mapper.Map(gerenteDto, gerente);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaGerente(int id)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente == null)
        {
            return NotFound();
        }
        _context.Remove(gerente);
        _context.SaveChanges();
        return NoContent();
    }
}
