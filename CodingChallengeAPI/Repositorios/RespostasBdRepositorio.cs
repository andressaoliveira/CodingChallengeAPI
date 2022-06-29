using CodingChallengeAPI.Models;
using MySqlConnector;
    
   public class RespostasBdRepositorio
{
    public RespostasBdRepositorio()
    {
    }

    public async Task<List<Resposta>> GetRespostasByIdComentario(string idComentario)
    {
        var respostas = new List<Resposta>();

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM Resposta where IdComentario=@idComentario", connection);
        comando.Parameters.Add(new MySqlParameter("@idComentario", idComentario));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var resposta = new Resposta()
                {
                    IdResposta = reader.GetInt32(0),
                    IdComentario = reader.GetInt32(1),
                    IdUsuario = reader.GetInt32(2),
                    Texto = reader.GetString(3)
                };
                respostas.Add(resposta);
            }
        }
        connection.Close();

        return respostas;
    }
    public async Task ResponderComentario(Resposta resposta)
    {

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("INSERT INTO Resposta (`IdComentario`,`IdUsuario`,`Texto`) VALUES (@idComentario, @idUsuario, @texto)", connection);

        comando.Parameters.Add(new MySqlParameter("@idComentario", resposta.IdComentario));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", resposta.IdUsuario));
        comando.Parameters.Add(new MySqlParameter("@texto", resposta.Texto));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
           
        }
        connection.Close();
    }
}