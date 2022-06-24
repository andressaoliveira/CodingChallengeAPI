using Microsoft.AspNetCore.Mvc;

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
            var filme = await filmeProcesso.getFilmes(busca);

            return filme;
        }


        [Route("PesquisarByIdTitulo")]
        [HttpGet]
        public async Task<Filme> GetFilmeByIDorTitle([FromQuery] string tituloFilme)
        {
            var filmeProcesso = new FilmeProcesso();
            var filme = await filmeProcesso.getFilme(null, tituloFilme);

            return filme;
        }
    }
}