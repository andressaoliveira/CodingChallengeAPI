namespace CodingChallengeAPI.Models
{
    public class ComentarioAvaliacao
    {
        public int IdAvaliacao { get; set; }

        public int IdComentario { get; set; }

        public int IdUsuario { get; set; }

        public bool Gostei { get; set; }
    }
}
