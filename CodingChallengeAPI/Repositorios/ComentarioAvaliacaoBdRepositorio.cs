using CodingChallengeAPI.Models;
using MySqlConnector;
    
   public class ComentarioAvaliacaoBdRepositorio
{
    public ComentarioAvaliacaoBdRepositorio()
    {
    }

    public async Task<List<ComentarioAvaliacao>> GetAvaliacoesByIdComentario(int idComentario)
    {
        var avaliacoes = new List<ComentarioAvaliacao>();

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM ComentarioAvaliacao where IdComentario=@idComentario", connection);
        comando.Parameters.Add(new MySqlParameter("@idComentario", idComentario));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var avaliacao = new ComentarioAvaliacao()
                {
                    IdAvaliacao = reader.GetInt32(0),
                    IdComentario = reader.GetInt32(1),
                    IdUsuario = reader.GetInt32(2),
                    Gostei = reader.GetBoolean(3)
                };
                avaliacoes.Add(avaliacao);
            }
        }
        connection.Close();

        return avaliacoes;
    }
    public async Task<ComentarioAvaliacao> GetAvaliacoesByIdComentarioIdUsuario(int idComentario, int idUsuario)
    {
        var avaliacao = new ComentarioAvaliacao();

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM ComentarioAvaliacao where IdComentario=@idComentario AND IdUsuario = @idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@idComentario", idComentario));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                avaliacao = new ComentarioAvaliacao()
                {
                    IdAvaliacao = reader.GetInt32(0),
                    IdComentario = reader.GetInt32(1),
                    IdUsuario = reader.GetInt32(2),
                    Gostei = reader.GetBoolean(3)
                };
            }
        }
        connection.Close();

        return avaliacao;
    }
    public async Task FazerAvaliacao(ComentarioAvaliacao avaliacao)
    {

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("INSERT INTO ComentarioAvaliacao (`IdComentario`,`IdUsuario`,`Gostei`) VALUES (@idComentario, @idUsuario, @gostei)", connection);

        comando.Parameters.Add(new MySqlParameter("@idComentario", avaliacao.IdComentario));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", avaliacao.IdUsuario));
        comando.Parameters.Add(new MySqlParameter("@gostei", avaliacao.Gostei));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
           
        }
        connection.Close();
    }

    public async Task AtualizarAvaliacao(int idAvaliacao, ComentarioAvaliacao avaliacao)
    {

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("UPDATE ComentarioAvaliacao SET Gostei = @gostei WHERE IdAvaliacao=@idAvaliacao", connection);

        comando.Parameters.Add(new MySqlParameter("@idAvaliacao", idAvaliacao));
        comando.Parameters.Add(new MySqlParameter("@gostei", avaliacao.Gostei));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {

        }
        connection.Close();
    }

}