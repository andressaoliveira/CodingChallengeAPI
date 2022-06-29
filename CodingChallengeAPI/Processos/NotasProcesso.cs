using CodingChallengeAPI.Models;

public class NotasProcesso
{
    public NotasProcesso()
    { }

    public async Task<List<Nota>> GetNotas(string idFilme)
    {
        var repositorio = new NotasBdRepositorio();
        var notas = await repositorio.GetNotas(idFilme);
        return notas;
    }
    public async Task DarNota(Nota nota)
    {
        var repositorio = new NotasBdRepositorio();
        var processo = new UsuarioProcesso();
        var perfilProcesso = new PerfilProcesso();
        var usuario = await processo.GetUsuario(nota.IdUsuario);
        if(usuario == null)
        {
            return;
        }
        var perfil = await perfilProcesso.ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);

        var notasUsuario = repositorio.GetNotasByUsuario(nota.IdUsuario);
        foreach (var notaUsuario in notasUsuario.Result)
        {
            if (notaUsuario.IdFilme == nota.IdFilme)
            {
                await repositorio.AtualizarNota(notaUsuario.IdNota, nota.ValorNota);
                return;
            }
        }

        await repositorio.DarNota(nota);
        await processo.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
    }
}