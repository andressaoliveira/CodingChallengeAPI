using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;
using System.Net;
using Equipagem.API.Dominio.Excecao;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentariosProcesso comentariosProcesso = new ComentariosProcesso();
        private readonly ComentarioAvaliacaoProcesso comentarioAvaliacaoProcesso = new ComentarioAvaliacaoProcesso();


        [Route("ComentariosByIdFilme")]
        [HttpGet]
        public async Task<ActionResult> GetComentariosByIdFilme([FromQuery] string idFilme)
        {
            try
            {
                var comentarios = await comentariosProcesso.GetComentarios(idFilme);
                return Ok(comentarios);
            }
            catch (ComentarioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> FazerComentario([FromBody] Comentario comentario)
        {
            try
            {
                await comentariosProcesso.FazerComentario(comentario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AvaliarComentario")]
        public async Task<ActionResult> AvaliarComentario([FromBody] ComentarioAvaliacao avaliacao)
        {
            try
            {
                await comentarioAvaliacaoProcesso.FazerAvaliacao(avaliacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("MarcarComoRepetido")]
        public async Task<ActionResult> MarcarComentarioComoRepetido([FromQuery] int idComentario, int idUsuario, bool repetido)
        {
            try
            {
                await comentariosProcesso.MarcarComentarioComoRepetido(idComentario, idUsuario, repetido);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("ExcluirComentario")]
        public async Task<ActionResult> ExcluirComentario([FromQuery] int idComentario, int idUsuario)
        {
            try
            {
                await comentariosProcesso.ExcluirComentario(idComentario, idUsuario);
                await comentariosProcesso.ExcluirComentario(idComentario, idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}