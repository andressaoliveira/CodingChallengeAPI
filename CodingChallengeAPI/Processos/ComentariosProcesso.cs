using CodingChallengeAPI.Models;

public class ComentariosProcesso
{
    public ComentariosProcesso()
    { }

    public async Task<List<Comentario>> GetComentarios(string idFilme)
    {
        var repositorio = new ComentariosBdRepositorio();
        var comentarios = await repositorio.GetComentarios(idFilme);
        return comentarios;
    }
    public async Task FazerComentario(Comentario comentario)
    {
        var repositorio = new ComentariosBdRepositorio();
        await repositorio.FazerComentario(comentario);

        var processo = new UsuarioProcesso();
        var usuario = await processo.GetUsuario(comentario.IdUsuario);
        if (usuario != null)
        {
            var perfil = await ObterPerfilUsuario(usuario.Perfil, usuario.Pontos + 1);
            await processo.AtualizarPontuacao(usuario.IdUsuario, perfil, usuario.Pontos + 1);
        }
    }

    private async Task<int> ObterPerfilUsuario(int perfilUsuario, int Pontos)
    {
        var processo = new PerfilProcesso();
        var perfis = await processo.GetPerfis();

        for(int i = 0; i < perfis.Count; i++)
        {
            if (perfilUsuario == perfis[i].IdPerfil)
            {
                var perfilSuperior = perfis[i + 1];
                if (perfilSuperior != null && Pontos >= perfilSuperior.PontuacaoMinima)
                {
                    return perfilSuperior.IdPerfil;
                }
                return perfilUsuario;
            }
        }

        return perfilUsuario;
    }
}