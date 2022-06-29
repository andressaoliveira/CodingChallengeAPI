namespace CodingChallengeAPI.Models
{
    public class Resposta
    {
        public int IdResposta { get; set; }

        public int IdComentario { get; set; }

        public int IdUsuario { get; set; }

        public string? Texto { get; set; }
    }
}
