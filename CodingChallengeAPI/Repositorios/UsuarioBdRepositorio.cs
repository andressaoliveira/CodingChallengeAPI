using CodingChallengeAPI.Models;
using MySqlConnector;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
    
   public class UsuarioBdRepositorio
{
    public UsuarioBdRepositorio()
    {
    }

    public async Task<List<Usuario>> GetUsuarios()
    {
        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM Usuario", connection);

        connection.Open();

        var reader = await comando.ExecuteReaderAsync();
      
        var usuarios = new List<Usuario>();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var usuario = new Usuario()
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Perfil = reader.GetInt32(4),
                    Pontos = reader.GetInt32(5),
                };
                usuarios.Add(usuario);
            }
        }        
        return usuarios;
    }
    public async Task<Usuario> GetUsuario(int idUsuario)
    {
        var usuario = new Usuario();

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM Usuario where IdUsuario=@idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                usuario = new Usuario()
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Perfil = reader.GetInt32(4),
                    Pontos = reader.GetInt32(5),
                };
            }
        }
        connection.Close();

        return usuario;
    }
}