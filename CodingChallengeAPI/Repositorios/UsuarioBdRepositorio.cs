using CodingChallengeAPI.Enum;
using CodingChallengeAPI.Models;
using MySqlConnector;

namespace CodingChallengeAPI.Repositorio;
public class UsuarioBdRepositorio
{
    private readonly MySqlConnection connection = new("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");

    public async Task<List<Usuario>> GetUsuarios()
    {
        MySqlCommand comando = new("SELECT * FROM Usuario", connection);

        connection.Open();

        var reader = await comando.ExecuteReaderAsync();
      
        var usuarios = new List<Usuario>();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var usuario = new Usuario()
                {
                    IdUsuario = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Perfil = (PerfilUsuario) reader.GetInt32(4),
                    Pontos = reader.GetInt32(5),
                };
                usuarios.Add(usuario);
            }
        }        
        return usuarios;
    }

    public async Task<Usuario?> GetUsuario(int idUsuario)
    {
        MySqlCommand comando = new("SELECT * FROM Usuario where IdUsuario=@idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {

            Usuario usuario = new();
            while (reader.Read())
            {
                usuario = new Usuario()
                {
                    IdUsuario = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Perfil = (PerfilUsuario) reader.GetInt32(4),
                    Pontos = reader.GetInt32(5),
                };
            }
            connection.Close();
            return usuario;
        }
        connection.Close();
        return null;
    }

    public async Task CadastrarUsuario(Usuario usuario)
    {
        MySqlCommand comando = new("INSERT INTO Usuario (`Nome`,`Email`,`Senha`) VALUES (@nome, @email, @senha)", connection);
        comando.Parameters.Add(new MySqlParameter("@nome", usuario.Nome));
        comando.Parameters.Add(new MySqlParameter("@email", usuario.Email));
        comando.Parameters.Add(new MySqlParameter("@senha", usuario.Senha));

        connection.Open();
        try
        {
            await comando.ExecuteReaderAsync();
            connection.Close();
        }
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception(ex.Message);
        }
    }

    public async Task AtualizarPontuacao(int idUsuario, PerfilUsuario perfil, int pontos)
    {
        MySqlCommand comando = new("UPDATE Usuario SET Pontos = @pontos, IdPerfil = @perfil WHERE IdUsuario = @idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));
        comando.Parameters.Add(new MySqlParameter("@perfil", perfil));
        comando.Parameters.Add(new MySqlParameter("@pontos", pontos));

        connection.Open();
        try
        {
            await comando.ExecuteReaderAsync();
            connection.Close();
        }
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception(ex.Message);
        }
    }

    public async Task AtualizarPerfil(int idUsuario, int perfil)
    {
        MySqlCommand comando = new("UPDATE Usuario SET IdPerfil = @perfil WHERE IdUsuario = @idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@perfil", perfil));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));

        connection.Open();
        try
        {
            await comando.ExecuteReaderAsync();
            connection.Close();
        }
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception(ex.Message);
        }
    }

}