using CodingChallengeAPI.Models;
using MySqlConnector;

namespace CodingChallengeAPI.Repositorio;
public class ComentariosBdRepositorio
{
    private readonly MySqlConnection connection = new("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");

    public async Task<Comentario> GetComentario(int idComentario)
    {
        var comentario = new Comentario();

        MySqlCommand comando = new("SELECT * FROM Comentario where IdComentario=@idComentario", connection);
        comando.Parameters.Add(new MySqlParameter("@idComentario", idComentario));

        connection.Open();

        try
        {
            var reader = await comando.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                comentario = new Comentario()
                {
                    IdComentario = reader.GetInt32(0),
                    IdFilme = reader.GetString(1),
                    IdUsuario = reader.GetInt32(2),
                    Texto = reader.GetString(3),
                    Repetido = reader.GetBoolean(4)
                };
            }
            connection.Close();

            return comentario;
        }
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Comentario>> GetComentarios(string idFilme)
    {
        var comentarios = new List<Comentario>();

        MySqlCommand comando = new("SELECT * FROM Comentario where IdFilme=@idFilme", connection);
        comando.Parameters.Add(new MySqlParameter("@idFilme", idFilme));

        connection.Open();
        try
        {
            var reader = await comando.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var comentario = new Comentario()
                    {
                        IdComentario = reader.GetInt32(0),
                        IdFilme = reader.GetString(1),
                        IdUsuario = reader.GetInt32(2),
                        Texto = reader.GetString(3),
                        Repetido = reader.GetBoolean(4)
                    };
                    comentarios.Add(comentario);
                }
            }
            connection.Close();

            return comentarios;
        }
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception(ex.Message);
        }
    }
    public async Task FazerComentario(Comentario comentario)
    {
        MySqlCommand comando = new("INSERT INTO Comentario (`IdFilme`,`IdUsuario`,`Texto`) VALUES (@idFilme, @idUsuario, @texto)", connection);

        comando.Parameters.Add(new MySqlParameter("@idFilme", comentario.IdFilme));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", comentario.IdUsuario));
        comando.Parameters.Add(new MySqlParameter("@texto", comentario.Texto));

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

    public async Task ExcluirComentario(int idComentario)
    {
        MySqlConnection connection = new("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new(
            "DELETE FROM ComentarioAvaliacao WHERE IdComentario=@idComentario; " +
            "DELETE FROM Resposta WHERE IdComentario=@idComentario; " +
            "DELETE FROM Comentario WHERE IdComentario=@idComentario; ", connection);

        comando.Parameters.Add(new MySqlParameter("@IdComentario", idComentario));

        connection.Open();
        try
        {
            var reader = await comando.ExecuteReaderAsync();
            connection.Close();
        }
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception(ex.Message);
        }
    }

    public async Task MarcarComentarioComoRepetido(int idComentario, bool repetido)
    {
        MySqlCommand comando = new("UPDATE Comentario SET Repetido = @repetido WHERE IdComentario = @idComentario", connection);
        comando.Parameters.Add(new MySqlParameter("@idComentario", idComentario));
        comando.Parameters.Add(new MySqlParameter("@repetido", repetido));

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