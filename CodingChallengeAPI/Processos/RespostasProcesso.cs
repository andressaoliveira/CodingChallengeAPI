using CodingChallengeAPI.Dominio;
using CodingChallengeAPI.Models;

public class RespostasProcesso
{
    private readonly RespostasBdRepositorio respostasBdRepositorio = new RespostasBdRepositorio();
    private readonly PerfilProcesso perfilProcesso = new PerfilProcesso();
    private readonly UsuarioProcesso usuarioProcesso = new UsuarioProcesso();

    public async Task<List<Resposta>> GetRespostasByIdComentario(string idComentario)
    {
        var comentarios = await respostasBdRepositorio.GetRespostasByIdComentario(idComentario);
        return comentarios;
    }
    public async Task ResponderComentario(Resposta resposta)
    {
        var usuario = await usuarioProcesso.GetUsuario(resposta.IdUsuario);
        if (usuario != null && usuario.Perfil != PerfilUsuario.LEITOR)
        {
            await respostasBdRepositorio.ResponderComentario(resposta);
            var perfil = await perfilProcesso.ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);
            await usuarioProcesso.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
        }
    }

}