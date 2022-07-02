using CodingChallengeAPI.Models;
using MySqlConnector;

namespace CodingChallengeAPI.Repositorio;
public class RespostasBdRepositorio
{
    private readonly MySqlConnection connection = new("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");

    public async Task<List<Resposta>> GetRespostasByIdComentario(string idComentario)
    {
        var respostas = new List<Resposta>();

        MySqlCommand comando = new("SELECT * FROM Resposta where IdComentario=@idComentario", connection);
        comando.Parameters.Add(new MySqlParameter("@idComentario", idComentario));

        connection.Open();
        try
        {
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
        catch (Exception ex)
        {
            connection.Close();
            throw new Exception(ex.Message);
        }
    }
    public async Task ResponderComentario(Resposta resposta)
    {
        MySqlCommand comando = new("INSERT INTO Resposta (`IdComentario`,`IdUsuario`,`Texto`) VALUES (@idComentario, @idUsuario, @texto)", connection);

        comando.Parameters.Add(new MySqlParameter("@idComentario", resposta.IdComentario));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", resposta.IdUsuario));
        comando.Parameters.Add(new MySqlParameter("@texto", resposta.Texto));

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