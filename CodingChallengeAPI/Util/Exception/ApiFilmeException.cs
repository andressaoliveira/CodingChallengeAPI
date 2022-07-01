namespace CodingChallengeAPI.Excecao
{
    [Serializable]
    public class ApiFilmeException : Exception
    {
        public ApiFilmeException() : base("Erro ao buscar filme na omdbapi") { }

        public ApiFilmeException(string message) : base(message) { }

    }
}
