using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        [Route("FilmesApi")]
        [HttpGet]
        public async Task<List<Filme>> GetFilmes([FromQuery] string busca)
        {
            var filmeProcesso = new FilmeProcesso();
            var filmes = await filmeProcesso.GetFilmes(busca);

            return filmes;
        }

        [Route("FilmesApiPorId")]
        [HttpGet]
        public async Task<Filme> GetFilmePorId([FromQuery] string idFilme)
        {
            var filmeProcesso = new FilmeProcesso();
            var filme = await filmeProcesso.GetFilme(idFilme);

            return filme;
        }

        [Route("FilmesBdPorId")]
        [HttpGet]
        public async Task<Filme> GetFilmeBdPorId([FromQuery] string idFilme)
        {
            var filmeProcesso = new FilmeProcesso();
            var filme = await filmeProcesso.GetFilmeBd(idFilme);

            return filme;
        }
    }
}