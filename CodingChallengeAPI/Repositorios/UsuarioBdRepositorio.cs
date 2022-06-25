using CodingChallengeAPI.Models;
using MySqlConnector;
    
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
                    IdUsuario = reader.GetInt32(0),
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
                    IdUsuario = reader.GetInt32(0),
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

    public async Task CadastrarUsuario(Usuario usuario)
    {

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("INSERT INTO Usuario (`Nome`,`Email`,`Senha`,`IdPerfil`,`Pontos`) VALUES (@nome, @email, @senha, @perfil, @pontos)", connection);
        comando.Parameters.Add(new MySqlParameter("@nome", usuario.Nome));
        comando.Parameters.Add(new MySqlParameter("@email", usuario.Email));
        comando.Parameters.Add(new MySqlParameter("@senha", usuario.Senha));
        comando.Parameters.Add(new MySqlParameter("@perfil", 1));
        comando.Parameters.Add(new MySqlParameter("@pontos", 0));

        connection.Open();
        await comando.ExecuteReaderAsync();
        connection.Close();
    }
    public async Task AtualizarPontuacao(int idUsuario, int perfil, int pontos)
    {
        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("UPDATE Usuario SET Pontos = @pontos, IdPerfil = @perfil WHERE IdUsuario = @idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));
        comando.Parameters.Add(new MySqlParameter("@perfil", perfil));
        comando.Parameters.Add(new MySqlParameter("@pontos", pontos));

        connection.Open();
        await comando.ExecuteReaderAsync();
        connection.Close();
    }

    public async Task AtualizarPerfil(int idUsuario, int perfil)
    {
        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("UPDATE Usuario SET Perfil = @perfil WHERE IdUsuario = @idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@pontos", perfil));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));

        connection.Open();
        await comando.ExecuteReaderAsync();
        connection.Close();
    }
}