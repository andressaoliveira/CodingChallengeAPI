namespace CodingChallengeAPI.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }

        public string? IdFilme { get; set; }

        public int IdUsuario { get; set; }

        public string? Texto { get; set; }
    }
}
