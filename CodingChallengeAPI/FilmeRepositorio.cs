using Newtonsoft.Json;
using System.Net.Http.Headers;
    
   public class FilmeRepositorio
{
    HttpClient cliente = new HttpClient();
    public FilmeRepositorio()
    {
        cliente.BaseAddress = new Uri("http://www.omdbapi.com/?apikey=a4a6b32f&");
        cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<Filme> GetFilme(string idFilme, string tituloFilme)
    {
        string busca = "";

        if(idFilme != null)
        {
            busca = $"i={idFilme}";
        }
        if (tituloFilme != null)
        {
            busca = $"{busca}&t={tituloFilme}";
        }

        HttpResponseMessage response = await cliente.GetAsync($"?apikey=a4a6b32f&{busca}");
        if (response.IsSuccessStatusCode)
        {
            var dados = JsonConvert.DeserializeObject<Filme>(await response.Content.ReadAsStringAsync());
            return dados ?? new Filme();
        }
        return new Filme();
    }
    public async Task<List<Filme>> GetFilmes(string busca)
    {

        HttpResponseMessage response = await cliente.GetAsync("?apikey=a4a6b32f&s=love");
        if (response.IsSuccessStatusCode)
        {
            var dados = JsonConvert.DeserializeObject<List<Filme>>(await response.Content.ReadAsStringAsync());
            return dados ?? new List<Filme>();
        }
        return new List<Filme>();
    }
}