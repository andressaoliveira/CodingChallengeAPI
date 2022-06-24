using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly ILogger<FilmeController> _logger;

        public FilmeController(ILogger<FilmeController> logger)
        {
            _logger = logger;
        }

        [Route("Pesquisar")]
        [HttpGet]
        public async Task<List<Filme>> GetFilmes([FromQuery] string busca)
        {
            var filmeProcesso = new FilmeProcesso();
            var filmes = await filmeProcesso.getFilmes(busca);

            return filmes;
        }


        [Route("PesquisarByIdTitulo")]
        [HttpGet]
        public async Task<Filme> GetFilmeByIdOrTitle([FromQuery] string tituloFilme)
        {
            var filmeProcesso = new FilmeProcesso();
            var filme = await filmeProcesso.getFilme(null, tituloFilme);

            return filme;
        }
    }
}