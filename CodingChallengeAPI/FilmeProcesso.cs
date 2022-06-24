using Newtonsoft.Json;
using System.Net.Http.Headers;
    
   public class FilmeProcesso
{
    public FilmeProcesso()
    {

    }

    public async Task<Filme> getFilme(string idFilme, string tituloFilme)
    {
        var repositorio = new FilmeRepositorio();
        var filme = await repositorio.GetFilme(idFilme, tituloFilme);
        return filme;
    }
    public async Task<List<Filme>> getFilmes(string busca)
    {
        var repositorio = new FilmeRepositorio();
        var filme = await repositorio.GetFilmes(busca);
        return filme;
    }
}