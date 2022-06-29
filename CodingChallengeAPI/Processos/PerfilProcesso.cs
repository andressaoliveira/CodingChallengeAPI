using CodingChallengeAPI.Models;

public class PerfilProcesso
{
    public PerfilProcesso()
    { }

    public async Task<List<Perfil>> GetPerfis()
    {
        var repositorio = new PerfilRepositorio();
        var perfis = await repositorio.GetPerfis();
        return perfis;
    }
    public async Task<int> ObterPerfilUsuario(int perfilUsuario, int Pontos)
    {
        var perfis = await GetPerfis();

        for (int i = 0; i < perfis.Count; i++)
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