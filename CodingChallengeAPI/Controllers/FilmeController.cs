using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;
using System.Net;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeProcesso filmeProcesso = new ();

        [Route("FilmesApi")]
        [HttpGet]
        public async Task<ActionResult> GetFilmes([FromQuery] string busca)
        {
            try
            {
                var filmes = await filmeProcesso.GetFilmes(busca);

                return Ok(filmes);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("FilmesApiPorId")]
        [HttpGet]
        public async Task<ActionResult> GetFilmePorId([FromQuery] string idFilme)
        {
            try
            {
                var filme = await filmeProcesso.GetFilme(idFilme);
                return Ok(filme);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}