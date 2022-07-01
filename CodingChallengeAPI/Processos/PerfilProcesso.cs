using CodingChallengeAPI.Enum;
using CodingChallengeAPI.Models;

public class PerfilProcesso
{
    private readonly PerfilBdRepositorio perfilBdRepositorio = new PerfilBdRepositorio();

    public async Task<List<Perfil>> GetPerfis()
    {
        var perfis = await perfilBdRepositorio.GetPerfis();
        return perfis;
    }
    public async Task<PerfilUsuario> ObterPerfilUsuario(PerfilUsuario perfilUsuario, int Pontos)
    {
        var perfis = await GetPerfis();

        for (int i = 0; i < perfis.Count; i++)
        {
            if (perfilUsuario == (PerfilUsuario) perfis[i].IdPerfil)
            {
                var perfilSuperior = perfis[i + 1];
                if (perfilSuperior != null && Pontos >= perfilSuperior.PontuacaoMinima)
                {
                    return (PerfilUsuario) perfilSuperior.IdPerfil;
                }
                return perfilUsuario;
            }
        }

        return perfilUsuario;
    }
}