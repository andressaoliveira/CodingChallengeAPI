using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespostaController : ControllerBase
    {
        [Route("RespostasByComentario")]
        [HttpGet]
        public async Task<List<Resposta>> GetRespostasByComentario([FromQuery] string idComentario)
        {
            var processo = new RespostasProcesso();
            var resposta = await processo.GetRespostasByIdComentario(idComentario);

            return resposta;
        }

        [HttpPost]
        public async Task ResponderComentario([FromBody] Resposta resposta)
        {
            var processo = new RespostasProcesso();
            await processo.ResponderComentario(resposta);
        }
    }
}