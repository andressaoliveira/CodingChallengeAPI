using CodingChallengeAPI.Excecao;
using CodingChallengeAPI.Models;

public class NotasProcesso
{
    private readonly NotasBdRepositorio notasBdRepositorio = new NotasBdRepositorio();
    private readonly UsuarioProcesso usuarioProcesso = new UsuarioProcesso();
    private readonly PerfilProcesso perfilProcesso = new PerfilProcesso();

    public async Task<List<Nota>> GetNotas(string idFilme)
    {
        var notas = await notasBdRepositorio.GetNotas(idFilme);
        return notas;
    }
    public async Task DarNota(Nota nota)
    {
        var usuario = await usuarioProcesso.GetUsuario(nota.IdUsuario);
        if(usuario == null)
        {
            throw new UsuarioException();
        }

        var perfil = await perfilProcesso.ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);

        var notasUsuario = notasBdRepositorio.GetNotasByUsuario(nota.IdUsuario);
        foreach (var notaUsuario in notasUsuario.Result)
        {
            if (notaUsuario.IdFilme == nota.IdFilme)
            {
                await notasBdRepositorio.AtualizarNota(notaUsuario.IdNota, nota.ValorNota);
                return;
            }
        }

        await notasBdRepositorio.DarNota(nota);
        await usuarioProcesso.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
    }
}