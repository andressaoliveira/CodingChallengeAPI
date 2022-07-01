using CodingChallengeAPI.Enum;
using CodingChallengeAPI.Excecao;
using CodingChallengeAPI.Models;
using CodingChallengeAPI.Repositorio;

namespace CodingChallengeAPI.Processo;
public class RespostasProcesso
{
    private readonly RespostasBdRepositorio respostasBdRepositorio = new();
    private readonly PerfilProcesso perfilProcesso = new();
    private readonly UsuarioProcesso usuarioProcesso = new();

    public async Task<List<Resposta>> GetRespostasByIdComentario(string idComentario)
    {
        var comentarios = await respostasBdRepositorio.GetRespostasByIdComentario(idComentario);
        return comentarios;
    }
    public async Task ResponderComentario(Resposta resposta)
    {
        var usuario = await usuarioProcesso.GetUsuario(resposta.IdUsuario);
        if (usuario == null)
        {
            throw new UsuarioException();
        }

        if (usuario.Perfil != PerfilUsuario.LEITOR)
        {
            await respostasBdRepositorio.ResponderComentario(resposta);
            var perfil = await perfilProcesso.ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);
            await usuarioProcesso.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
        }
    }

}