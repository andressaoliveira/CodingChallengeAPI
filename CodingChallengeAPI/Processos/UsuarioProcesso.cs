using CodingChallengeAPI.Models;
   public class UsuarioProcesso
{
    public UsuarioProcesso()
    { }

    public async Task<Usuario> getUsuario(int idUsuario)
    {
        var repositorio = new UsuarioBdRepositorio();
        var usuario = await repositorio.GetUsuario(idUsuario);
        return usuario;
    }
    public async Task<List<Usuario>> getUsuarios()
    {
        var repositorio = new UsuarioBdRepositorio();
        var usuarios = await repositorio.GetUsuarios();
        return usuarios;
    }
}