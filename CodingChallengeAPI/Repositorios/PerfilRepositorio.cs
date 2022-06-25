using CodingChallengeAPI.Models;
using MySqlConnector;
    
   public class PerfilRepositorio
{
    public PerfilRepositorio()
    {
    }

    public async Task<List<Perfil>> GetPerfis()
    {
        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM Perfil", connection);

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