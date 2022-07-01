
using CodingChallengeAPI.Enum;

namespace CodingChallengeAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public int Pontos { get; set; }

        public PerfilUsuario Perfil { get; set; }
    }
}
