using CodingChallengeAPI.Models;
   public class UsuarioProcesso
{
    public UsuarioProcesso()
    { }

    public async Task<Usuario> GetUsuario(int idUsuario)
    {
        var repositorio = new UsuarioBdRepositorio();
        var usuario = await repositorio.GetUsuario(idUsuario);
        return usuario;
    }
    public async Task<List<Usuario>> GetUsuarios()
    {
        var repositorio = new UsuarioBdRepositorio();
        var usuarios = await repositorio.GetUsuarios();
        return usuarios;
    }
    public async Task CadastrarUsuario(Usuario usuario)
    {
        var repositorio = new UsuarioBdRepositorio();
        await repositorio.CadastrarUsuario(usuario);
    }
    public async Task AtualizarPontuacao(int idUsuario, int perfil, int pontos)
    {
        var repositorio = new UsuarioBdRepositorio();
        await repositorio.AtualizarPontuacao(idUsuario, perfil, pontos);

    }
}