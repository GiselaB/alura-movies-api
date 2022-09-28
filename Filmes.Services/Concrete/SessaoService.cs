using AutoMapper;
using FluentResults;
using Filmes.Services.Data.Dtos.Sessao;
using Filmes.Services.Interfaces;
using Filmes.Infra;
using Filmes.Domain.Models;

namespace Filmes.Services.Concrete;

public class SessaoService : ISessaoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public SessaoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Sessao AdicionaSessao(CreateSessaoDto sessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();

        return sessao;
    }
    public List<ReadSessaoDto> RecuperaSessoes()
    {
        List<Sessao> sessoes = _context.Sessoes.ToList();
        return _mapper.Map<List<ReadSessaoDto>>(sessoes);
    }
    public ReadSessaoDto RecuperaSessaoPorId(int id)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

        return sessao != null 
            ? _mapper.Map<ReadSessaoDto>(sessao) 
            : null;
    }
    public Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao == null)
        {
            return Result.Fail("Sessão não encontrada");
        }
        _mapper.Map(sessaoDto, sessao);
        _context.SaveChanges();

        return Result.Ok();
    }
    public Result DeletaSessao(int id)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao == null)
        {
            return Result.Fail("Sessão não encontrada");
        }
        _context.Remove(sessao);
        _context.SaveChanges();

        return Result.Ok();
    }
}