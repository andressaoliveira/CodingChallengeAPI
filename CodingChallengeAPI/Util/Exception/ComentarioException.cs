namespace Equipagem.API.Dominio.Excecao
{
    [Serializable]
    public class ComentarioException : Exception
    {
        public ComentarioException() : base("Comentario Inexistente") { }

        public ComentarioException(string message) : base(message) { }

    }
}
