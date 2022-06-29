using CodingChallengeAPI.Models;

public class ComentariosProcesso
{
    public ComentariosProcesso()
    { }

    public async Task<List<Comentario>> GetComentarios(string idFilme)
    {
        var repositorio = new ComentariosBdRepositorio();
        var processo = new ComentarioAvaliacaoProcesso();
        var comentarios = await repositorio.GetComentarios(idFilme);
        foreach (var comentario in comentarios)
        {
            var avaliacoes = await processo.GetAvaliacoesByIdComentario(comentario.IdComentario);
            if (avaliacoes.Count > 0)
            {
                comentario.Gostei = GetQuantidadeAvaliacoesTipo(avaliacoes, true);
                comentario.NaoGostei = GetQuantidadeAvaliacoesTipo(avaliacoes, false);
            }
        }
        return comentarios;
    }
    public async Task FazerComentario(Comentario comentario)
    {
        var perfilProcesso = new PerfilProcesso();

        var repositorio = new ComentariosBdRepositorio();
        await repositorio.FazerComentario(comentario);

        var processo = new UsuarioProcesso();
        var usuario = await processo.GetUsuario(comentario.IdUsuario);
        if (usuario != null)
        {
            var perfil = await perfilProcesso.ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);
            await processo.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
        }
    }
    public async Task ExcluirComentario(int idComentario, int idUsuario)
    {
        var repositorio = new ComentariosBdRepositorio();

        var processo = new UsuarioProcesso();
        var usuario = await processo.GetUsuario(idUsuario);
        if (usuario != null && usuario.Perfil == 4)
        {
            await repositorio.ExcluirComentario(idComentario);
        }
    }
    public async Task MarcarComentarioComoRepetido(int idComentario, int idUsuario, bool repetido)
    {
        var repositorio = new ComentariosBdRepositorio();

        var processo = new UsuarioProcesso();
        var usuario = await processo.GetUsuario(idUsuario);
        if (usuario != null && usuario.Perfil == 4)
        {
            await repositorio.MarcarComentarioComoRepetido(idComentario, repetido);
        }
    }

    private int GetQuantidadeAvaliacoesTipo(List<ComentarioAvaliacao> avaliacoes, bool gostei)
    {
        return avaliacoes.FindAll(a => a.Gostei == gostei).Count();
    }

}