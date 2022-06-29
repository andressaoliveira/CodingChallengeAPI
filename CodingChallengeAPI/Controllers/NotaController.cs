using Microsoft.AspNetCore.Mvc;
using CodingChallengeAPI.Models;

namespace CodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaController : ControllerBase
    {
        [Route("NotasByFIlme")]
        [HttpGet]
        public async Task<List<Nota>> GetNotasByFIlme([FromQuery] string idFilme)
        {
            var processo = new NotasProcesso();
            var comentarios = await processo.GetNotas(idFilme);

            return comentarios;
        }

        [HttpPost]
        public async Task DarNota([FromBody] Nota nota)
        {
            var processo = new NotasProcesso();
            await processo.DarNota(nota);
        }
    }
}