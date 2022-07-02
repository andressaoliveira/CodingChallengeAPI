using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;
using System.Net;
using CodingChallengeAPI.Processo;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly NotasProcesso notaProcesso = new();

        [Route("NotasByFIlme")]
        [HttpGet]
        public async Task<ActionResult> GetNotasByFIlme([FromQuery] string idFilme)
        {
            try
            {
                var comentarios = await notaProcesso.GetNotas(idFilme);

                return Ok(comentarios);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DarNota([FromBody] Nota nota)
        {
            try
            {
                await notaProcesso.DarNota(nota);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}