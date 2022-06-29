using CodingChallengeAPI.Models;

public class ComentarioAvaliacaoProcesso
{
    public ComentarioAvaliacaoProcesso()
    { }

    public async Task FazerAvaliacao(ComentarioAvaliacao avaliacao)
    {
        var repositorio = new ComentarioAvaliacaoBdRepositorio();

        var processo = new UsuarioProcesso();
        var usuario = await processo.GetUsuario(avaliacao.IdUsuario);
        
        if (usuario != null && (usuario.Perfil == 3 || usuario.Perfil == 4))
        {
            var avaliacaoAtual = await repositorio.GetAvaliacoesByIdComentarioIdUsuario(avaliacao.IdComentario, avaliacao.IdUsuario);

            if (avaliacaoAtual.IdAvaliacao != 0)
            {
                await repositorio.AtualizarAvaliacao(avaliacaoAtual.IdAvaliacao, avaliacao);
                return;
            }
            await repositorio.FazerAvaliacao(avaliacao);
        }
    }
    public async Task<List<ComentarioAvaliacao>> GetAvaliacoesByIdComentario(int idComentario)
    {
        var repositorio = new ComentarioAvaliacaoBdRepositorio();
        var avaliacoes = await repositorio.GetAvaliacoesByIdComentario(idComentario);
        return avaliacoes;
    }
}