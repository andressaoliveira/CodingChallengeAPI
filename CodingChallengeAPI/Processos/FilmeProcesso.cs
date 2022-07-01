using CodingChallengeAPI.Models;
using CodingChallengeAPI.Repositorio;

namespace CodingChallengeAPI.Processo;
public class FilmeProcesso
{
    private readonly FilmeRepositorio filmeRepositorio = new();

    public async Task<Filme> GetFilme(string idFilme)
    {
        var filme = await filmeRepositorio.GetFilme(idFilme);
        return filme;
    }
    public async Task<List<Filme>> GetFilmes(string busca)
    {
        var filme = await filmeRepositorio.GetFilmes(busca);
        return filme;
    }
    public async Task<Filme> GetFilmeBd(string idFilme)
    {
        var filme = await filmeRepositorio.GetFilme(idFilme);
        return filme;
    }
}