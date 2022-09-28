using AutoMapper;
using FluentResults;
using Filmes.Services.Data.Dtos.Endereco;
using Filmes.Infra;
using Filmes.Domain.Models;
using Filmes.Services.Interfaces;

namespace Filmes.Services.Concrete;

public class EnderecoService : IEnderecoService
{
    private AppDbContext _context;
    private IMapper _mapper;
    public EnderecoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        return _mapper.Map<ReadEnderecoDto>(endereco);
    }
    public List<ReadEnderecoDto> RecuperaEnderecos()
    {
        List<Endereco> enderecos = _context.Enderecos.ToList();
        return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
    }
    public ReadEnderecoDto RecuperaEnderecoPorId(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco != null)
        {
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return enderecoDto;
        }

        return null;
    }
    public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return Result.Fail("Endereço não encontrado");
        }
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();

        return Result.Ok();
    }
    public Result DeletaEndereco(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return Result.Fail("Endereço não encontrado");
        }
        _context.Remove(endereco);
        _context.SaveChanges();

        return Result.Ok();
    }
}