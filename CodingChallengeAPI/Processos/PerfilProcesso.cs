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
}