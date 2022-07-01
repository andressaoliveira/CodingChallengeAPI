namespace CodingChallengeAPI.Excecao
{
    [Serializable]
    public class UsuarioException : Exception
    {
        public UsuarioException() : base("Usuário Inexistente") { }

        public UsuarioException(string message) : base(message) { }

    }
}
