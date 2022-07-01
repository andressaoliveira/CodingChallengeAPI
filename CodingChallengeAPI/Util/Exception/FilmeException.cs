namespace CodingChallengeAPI.Excecao
{
    [Serializable]
    public class FilmeException : Exception
    {
        public FilmeException() : base("Filme Inexistente") { }

        public FilmeException(string message) : base(message) { }

    }
}
