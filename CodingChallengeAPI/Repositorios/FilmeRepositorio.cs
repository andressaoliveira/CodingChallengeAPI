using CodingChallengeAPI.Excecao;
using CodingChallengeAPI.Models;
using MySqlConnector;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;

namespace CodingChallengeAPI.Repositorio;
public class FilmeRepositorio
{
    private readonly HttpClient cliente = new();
    public FilmeRepositorio()
    {
        cliente.BaseAddress = new Uri("http://www.omdbapi.com/?apikey=a4a6b32f&");
        cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<Filme> GetFilme(string idFilme)
    {
        HttpResponseMessage response = await cliente.GetAsync($"?apikey=a4a6b32f&i={idFilme}");
        if (response.IsSuccessStatusCode)
        {
            var dados = JsonConvert.DeserializeObject<Filme>(await response.Content.ReadAsStringAsync());
            return dados ?? new Filme();
        }
        return new Filme();
    }
    public async Task<List<Filme>> GetFilmes(string busca)
    {
        try
        {
            HttpResponseMessage response = await cliente.GetAsync($"?apikey=a4a6b32f&s={busca}");
            if (response.IsSuccessStatusCode)
            {
                var dados = JsonConvert.DeserializeObject<Busca>(await response.Content.ReadAsStringAsync());
                return dados?.Search ?? new List<Filme>();
            }

            throw new ApiFilmeException();
        }
        catch (Exception ex)
        {
            throw new FilmeException(ex.Message);
        }
    }
}