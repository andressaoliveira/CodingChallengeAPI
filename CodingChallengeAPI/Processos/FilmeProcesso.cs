using CodingChallengeAPI.Models;

public class FilmeProcesso
{
    public FilmeProcesso()
    { }

    public async Task<Filme> GetFilme(string idFilme)
    {
        var repositorio = new FilmeRepositorio();
        var filme = await repositorio.GetFilme(idFilme);
        return filme;
    }
    public async Task<List<Filme>> GetFilmes(string busca)
    {
        var repositorio = new FilmeRepositorio();
        var filme = await repositorio.GetFilmes(busca);
        return filme;
    }
    public async Task<Filme> GetFilmeBd(string idFilme)
    {
        var repositorioBd = new FilmeBdRepositorio();
        var filme = await repositorioBd.GetFilme(idFilme);
        return filme;
    }
}