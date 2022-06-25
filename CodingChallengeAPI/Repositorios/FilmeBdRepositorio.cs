using CodingChallengeAPI.Models;
using MySqlConnector;
    
   public class FilmeBdRepositorio
{
    public FilmeBdRepositorio()
    {
    }

    public async Task<Filme> GetFilme(string idFilme)
    {
        var filme = new Filme();

        MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");
        MySqlCommand comando = new MySqlCommand("SELECT * FROM Filmes where IdFilme=@idFilme", connection);
        comando.Parameters.Add(new MySqlParameter("@idFilme", idFilme));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                filme = new Filme()
                {
                    imdbID = reader.GetString(0),
                    Title = reader.GetString(1),
                };
            }
        }
        connection.Close();

        return filme;
    }
}