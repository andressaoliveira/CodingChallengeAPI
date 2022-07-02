using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;
using System.Net;
using CodingChallengeAPI.Processo;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespostaController : ControllerBase
    {
        private readonly RespostasProcesso respostaProcesso = new();

        [Route("RespostasByComentario")]
        [HttpGet]
        public async Task<ActionResult> GetRespostasByComentario([FromQuery] string idComentario)
        {
            try
            {
                var resposta = await respostaProcesso.GetRespostasByIdComentario(idComentario);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ResponderComentario([FromBody] Resposta resposta)
        {
            try
            {
                await respostaProcesso.ResponderComentario(resposta);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}