using CodingChallengeAPI.Models;

public class RespostasProcesso
{
    public RespostasProcesso()
    { }

    public async Task<List<Resposta>> GetRespostasByIdComentario(string idComentario)
    {
        var repositorio = new RespostasBdRepositorio();
        var comentarios = await repositorio.GetRespostasByIdComentario(idComentario);
        return comentarios;
    }
    public async Task ResponderComentario(Resposta resposta)
    {
        var perfilProcesso = new PerfilProcesso();
        var repositorio = new RespostasBdRepositorio();

        var processo = new UsuarioProcesso();
        var usuario = await processo.GetUsuario(resposta.IdUsuario);
        if (usuario != null && usuario.Perfil != 1)
        {
            await repositorio.ResponderComentario(resposta);
            var perfil = await perfilProcesso.ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);
            await processo.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
        }
    }

}