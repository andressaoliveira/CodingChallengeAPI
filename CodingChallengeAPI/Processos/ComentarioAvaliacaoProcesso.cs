using CodingChallengeAPI.Enum;
using CodingChallengeAPI.Excecao;
using CodingChallengeAPI.Models;
using CodingChallengeAPI.Repositorio;
using CodingChallengeAPI.Util;

namespace CodingChallengeAPI.Processo;
public class ComentarioAvaliacaoProcesso
{
    private readonly UsuarioProcesso usuarioProcesso = new();
    private readonly ComentarioAvaliacaoBdRepositorio comentarioAvaliacaoBdRepositorio = new();

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

            if (avaliacaoAtual != null)
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