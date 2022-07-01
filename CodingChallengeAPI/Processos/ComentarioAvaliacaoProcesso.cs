using CodingChallengeAPI.Dominio;
using CodingChallengeAPI.Models;
using CodingChallengeAPI.Util;
using Equipagem.API.Dominio.Excecao;

public class ComentarioAvaliacaoProcesso
{
    private readonly UsuarioProcesso usuarioProcesso = new UsuarioProcesso();
    private readonly ComentarioAvaliacaoBdRepositorio comentarioAvaliacaoBdRepositorio = new ComentarioAvaliacaoBdRepositorio();

    public async Task FazerAvaliacao(ComentarioAvaliacao avaliacao)
    {
        var usuario = await usuarioProcesso.GetUsuario(avaliacao.IdUsuario);

        if(usuario == null)
        {
            throw new UsuarioException();
        }
        
        if (usuario.Perfil == PerfilUsuario.AVANCADO || usuario.Perfil == PerfilUsuario.MODERADOR)
        {
            var avaliacaoAtual = await comentarioAvaliacaoBdRepositorio.GetAvaliacoesByIdComentarioIdUsuario(avaliacao.IdComentario, avaliacao.IdUsuario);

            if (avaliacaoAtual.IdAvaliacao != 0)
            {
                await comentarioAvaliacaoBdRepositorio.AtualizarAvaliacao(avaliacaoAtual.IdAvaliacao, avaliacao);
                return;
            }
            await comentarioAvaliacaoBdRepositorio.FazerAvaliacao(avaliacao);
        }
        else
        {
            throw new PerfilException();
        }
    }
    public async Task<List<ComentarioAvaliacao>> GetAvaliacoesByIdComentario(int idComentario)
    {
        var avaliacoes = await comentarioAvaliacaoBdRepositorio.GetAvaliacoesByIdComentario(idComentario);

        if (avaliacoes.IsNullOrEmpty())
        {
            throw new ComentarioException();
        }

        return avaliacoes;
    }
}