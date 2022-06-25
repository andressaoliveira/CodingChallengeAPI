using CodingChallengeAPI.Models;
using MySqlConnector;
    
   public class ComentariosBdRepositorio
{
    public ComentariosBdRepositorio()
    {
    }

    public async Task<List<Comentario>> GetComentarios(string idFilme)
    {
        var comentarios = new List<Comentario>();

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM Comentario where IdFilme=@idFilme", connection);
        comando.Parameters.Add(new MySqlParameter("@idFilme", idFilme));

        connection.Open();
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
                    Texto = reader.GetString(3)
                };
                comentarios.Add(comentario);
            }
        }
        connection.Close();

        return comentarios;
    }
    public async Task FazerComentario(Comentario comentario)
    {

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("INSERT INTO Comentario (`IdFilme`,`IdUsuario`,`Texto`) VALUES (@idFilme, @idUsuario, @texto)", connection);
        //comando.Parameters.Add(new MySqlParameter("@idComentario", comentario.IdComentario));
        comando.Parameters.Add(new MySqlParameter("@idFilme", comentario.IdFilme));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", comentario.IdUsuario));
        comando.Parameters.Add(new MySqlParameter("@texto", comentario.Texto));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
           
        }
        connection.Close();
    }
}