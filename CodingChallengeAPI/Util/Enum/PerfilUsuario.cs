using System.ComponentModel;

namespace CodingChallengeAPI.Enum
{
        public enum PerfilUsuario
        {
            [Description("Leitor")]
            LEITOR = 1,
            [Description("Básico")]
            BASICO = 2,
            [Description("Avançado")]
            AVANCADO = 3,
            [Description("Moderador")]
            MODERADOR = 4
        }

}
