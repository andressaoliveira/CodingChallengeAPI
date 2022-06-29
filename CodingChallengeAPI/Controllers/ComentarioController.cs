using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentarioController : ControllerBase
    {
        [Route("ComentariosByIdFilme")]
        [HttpGet]
        public async Task<List<Comentario>> GetComentariosByIdFilme([FromQuery] string idFilme)
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

        [HttpPost]
        [Route("AvaliarComentario")]
        public async Task AvaliarComentario([FromBody] ComentarioAvaliacao avaliacao)
        {
            var processo = new ComentarioAvaliacaoProcesso();
            await processo.FazerAvaliacao(avaliacao);
        }

        [HttpPut]
        [Route("MarcarComoRepetido")]
        public async Task MarcarComentarioComoRepetido([FromQuery] int idComentario, int idUsuario, bool repetido)
        {
            var processo = new ComentariosProcesso();
            await processo.MarcarComentarioComoRepetido(idComentario, idUsuario, repetido);
        }

        [HttpDelete]
        [Route("ExcluirComentario")]
        public async Task ExcluirComentario([FromQuery] int idComentario, int idUsuario)
        {
            var processo = new ComentariosProcesso();
            await processo.ExcluirComentario(idComentario, idUsuario);
        }
    }
}