using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentarioController : ControllerBase
    {
        [Route("Comentarios")]
        [HttpGet]
        public async Task<List<Comentario>> GetComentarios([FromQuery] string idFilme)
        {
            var processo = new ComentariosProcesso();
            var comentarios = await processo.GetComentarios(idFilme);

            return comentarios;
        }

        [HttpPost]
        public async Task FazerComentario([FromBody] Comentario comentario)
        {
            var processo = new ComentariosProcesso();
            await processo.FazerComentario(comentario);
        }
    }
}