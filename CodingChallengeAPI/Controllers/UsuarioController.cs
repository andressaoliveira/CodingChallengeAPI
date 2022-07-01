using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;
using System.Net;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioProcesso usuarioProcesso = new UsuarioProcesso();


        [Route("Usuarios")]
        [HttpGet]
        public async Task<ActionResult> GetUsuarios()
        {
            try
            {
                var usuarios = await usuarioProcesso.GetUsuarios();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Usuario")]
        [HttpGet]
        public async Task<ActionResult> GetUsuario([FromQuery] int idUsuario)
        {
            try
            {
                var usuario = await usuarioProcesso.GetUsuario(idUsuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Cadastrar")]
        [HttpPost]
        public async Task<ActionResult> CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                await usuarioProcesso.CadastrarUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("TornarModerador")]
        [HttpPut]
        public async Task<ActionResult> TornarModerador([FromQuery] int idUsuarioModerador, [FromQuery] int idUsuario)
        {
            try
            {
                await usuarioProcesso.TornarModerador(idUsuarioModerador, idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}