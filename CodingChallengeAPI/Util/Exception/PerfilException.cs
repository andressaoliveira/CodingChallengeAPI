﻿namespace Equipagem.API.Dominio.Excecao
{
    [Serializable]
    public class PerfilException : Exception
    {
        public PerfilException() : base("Perfil sem permissão") { }

        public PerfilException(string message) : base(message) { }

    }
}
