using CodingChallengeAPI.Models;
using MySqlConnector;

namespace CodingChallengeAPI.Repositorio;
public class PerfilBdRepositorio
{
    private readonly MySqlConnection connection = new("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");

    public async Task<List<Perfil>> GetPerfis()
    {
        MySqlCommand comando = new("SELECT * FROM Perfil", connection);

        connection.Open();

        var reader = await comando.ExecuteReaderAsync();
      
        var perfis = new List<Perfil>();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var perfil = new Perfil()
                {
                    IdPerfil = reader.GetInt32(0),
                    NomePerfil = reader.GetString(1),
                    PontuacaoMinima = reader.GetInt32(2)
                };
                perfis.Add(perfil);
            }
        }        
        return perfis;
    }
}