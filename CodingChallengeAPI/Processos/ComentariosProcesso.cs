using CodingChallengeAPI.Dominio;
using CodingChallengeAPI.Models;
using CodingChallengeAPI.Util;
using Equipagem.API.Dominio.Excecao;

public class ComentariosProcesso
{
    private readonly ComentariosBdRepositorio comentariosRepositorio = new ComentariosBdRepositorio();
    private readonly ComentarioAvaliacaoProcesso comentarioAvaliacaoProcesso = new ComentarioAvaliacaoProcesso();
    private readonly PerfilProcesso perfilProcesso = new PerfilProcesso();
    private readonly UsuarioProcesso usuarioProcesso = new UsuarioProcesso();

    public async Task<List<Comentario>> GetComentarios(string idFilme)
    {
        var comentarios = await comentariosRepositorio.GetComentarios(idFilme);
        if (comentarios.IsNullOrEmpty())
        {
            throw new ComentarioException();
        }

        foreach (var comentario in comentarios)
        {
            var avaliacoes = await comentarioAvaliacaoProcesso.GetAvaliacoesByIdComentario(comentario.IdComentario);
            if (avaliacoes.Count > 0)
            {
                comentario.Gostei = GetQuantidadeAvaliacoesTipo(avaliacoes, true);
                comentario.NaoGostei = GetQuantidadeAvaliacoesTipo(avaliacoes, false);
            }
        }
        return comentarios;
    }

    public async Task<Comentario> GetComentario(int idComentario)
    {
        var comentario = await comentariosRepositorio.GetComentario(idComentario);

        return comentario;
    }
    public async Task FazerComentario(Comentario comentario)
    {
        await comentariosRepositorio.FazerComentario(comentario);

        var usuario = await usuarioProcesso.GetUsuario(comentario.IdUsuario);
        if (usuario != null)
        {
            var perfil = await perfilProcesso.ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);
            await usuarioProcesso.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
        }
    }
    public async Task ExcluirComentario(int idComentario, int idUsuario)
    {
        var usuario = await usuarioProcesso.GetUsuario(idUsuario);
        var comentario = await GetComentario(idComentario);
        if (usuario != null && (usuario.Perfil == PerfilUsuario.MODERADOR || idUsuario == comentario.IdUsuario))
            {
            await comentariosRepositorio.ExcluirComentario(idComentario);
        }
    }
    public async Task MarcarComentarioComoRepetido(int idComentario, int idUsuario, bool repetido)
    {
        var usuario = await usuarioProcesso.GetUsuario(idUsuario);
        if (usuario != null && usuario.Perfil == PerfilUsuario.MODERADOR)
        {
            await comentariosRepositorio.MarcarComentarioComoRepetido(idComentario, repetido);
        }
    }

    private int GetQuantidadeAvaliacoesTipo(List<ComentarioAvaliacao> avaliacoes, bool gostei)
    {
        return avaliacoes.FindAll(a => a.Gostei == gostei).Count();
    }

}