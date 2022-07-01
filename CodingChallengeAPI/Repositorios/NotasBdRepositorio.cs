using CodingChallengeAPI.Models;
using MySqlConnector;
    
   public class NotasBdRepositorio
{
    private readonly MySqlConnection connection = new MySqlConnection("server=mysqlserver.cv8svfzmm14w.us-east-1.rds.amazonaws.com;user=admin;password=CW5HgxwDg4fzYATuqWDv;database=dbcodingchallenge");

    public async Task<List<Nota>> GetNotas(string idFilme)
    {
        var notas = new List<Nota>();

        MySqlCommand comando = new MySqlCommand("SELECT * FROM Nota where IdFilme=@idFilme", connection);
        comando.Parameters.Add(new MySqlParameter("@idFilme", idFilme));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var nota = new Nota()
                {
                    IdNota = reader.GetInt32(0),
                    IdFilme = reader.GetString(1),
                    IdUsuario = reader.GetInt32(2),
                    ValorNota = reader.GetInt32(3)
                };
                notas.Add(nota);
            }
        }
        connection.Close();

        return notas;
    }

    public async Task<List<Nota>> GetNotasByUsuario(int idUsuario)
    {
        var notas = new List<Nota>();

        MySqlCommand comando = new MySqlCommand("SELECT * FROM Nota where IdUsuario=@idUsuario", connection);
        comando.Parameters.Add(new MySqlParameter("@idUsuario", idUsuario));

        connection.Open();
        var reader = await comando.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var nota = new Nota()
                {
                    IdNota = reader.GetInt32(0),
                    IdFilme = reader.GetString(1),
                    IdUsuario = reader.GetInt32(2),
                    ValorNota = reader.GetInt32(3)
                };
                notas.Add(nota);
            }
        }
        connection.Close();

        return notas;
    }
    public async Task DarNota(Nota nota)
    {
        MySqlCommand comando = new MySqlCommand("INSERT INTO Nota (`IdFilme`,`IdUsuario`,`Nota`) VALUES (@idFilme, @idUsuario, @nota)", connection);
        comando.Parameters.Add(new MySqlParameter("@idFilme", nota.IdFilme));
        comando.Parameters.Add(new MySqlParameter("@idUsuario", nota.IdUsuario));
        comando.Parameters.Add(new MySqlParameter("@nota", nota.ValorNota));

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
    public async Task AtualizarNota(int idNota, int valorNota)
    {
        MySqlCommand comando = new MySqlCommand("UPDATE Nota SET Nota = @nota WHERE IdNota = @idNota", connection);
        comando.Parameters.Add(new MySqlParameter("@idNota", idNota));
        comando.Parameters.Add(new MySqlParameter("@nota", valorNota));

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