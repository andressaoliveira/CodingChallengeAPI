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
            var usuarios = await usuarioProcesso.GetUsuarios();

            return usuarios;
        }

        [Route("Usuario")]
        [HttpGet]
        public async Task<Usuario> GetUsuario([FromQuery] int idUsuario)
        {
            var usuarioProcesso = new UsuarioProcesso();
            var usuario = await usuarioProcesso.GetUsuario(idUsuario);

            return usuario;
        }

        [Route("Cadastrar")]
        [HttpPost]
        public async Task CadastrarUsuario([FromBody] Usuario usuario)
        {
            var usuarioProcesso = new UsuarioProcesso();
            await usuarioProcesso.CadastrarUsuario(usuario);
        }
    }
}