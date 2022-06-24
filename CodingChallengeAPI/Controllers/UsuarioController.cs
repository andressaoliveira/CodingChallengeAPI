using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [Route("Usuarios")]
        [HttpGet]
        public async Task<List<Usuario>> GetUsuarios()
        {
            var usuarioProcesso = new UsuarioProcesso();
            var usuarios = await usuarioProcesso.getUsuarios();

            return usuarios;
        }


        [Route("Usuario")]
        [HttpGet]
        public async Task<Usuario> GetUsuario([FromQuery] int idUsuario)
        {
            var usuarioProcesso = new UsuarioProcesso();
            var usuario = await usuarioProcesso.getUsuario(idUsuario);

            return usuario;
        }
    }
}