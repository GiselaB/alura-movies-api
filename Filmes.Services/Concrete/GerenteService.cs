using AutoMapper;
using Filmes.Domain.Models;
using Filmes.Infra;
using Filmes.Services.Data.Dtos.Gerente;
using Filmes.Services.Interfaces;
using FluentResults;

namespace Filmes.Services.Concrete;

public class GerenteService : IGerenteService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public GerenteService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
    {
        Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
        _context.Gerentes.Add(gerente);
        _context.SaveChanges();

        return _mapper.Map<ReadGerenteDto>(gerente);
    }
    public List<ReadGerenteDto> RecuperaGerentes()
    {
        List<Gerente> gerentes = _context.Gerentes.ToList();
        return _mapper.Map<List<ReadGerenteDto>>(gerentes);
    }
    public ReadGerenteDto RecuperaGerentePorId(int id)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

        return gerente != null 
            ? _mapper.Map<ReadGerenteDto>(gerente) 
            : null;
    }
    public Result AtualizaGerente(int id, UpdateGerenteDto gerenteDto)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente == null)
        {
            return Result.Fail("Gerente não encontrado");
        }
        _mapper.Map(gerenteDto, gerente);
        _context.SaveChanges();

        return Result.Ok();
    }
    public Result DeletaGerente(int id)
    {
        Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
        if (gerente == null)
        {
            return Result.Fail("Gerente não encontrado");
        }
        _context.Remove(gerente);
        _context.SaveChanges();

        return Result.Ok();
    }
}