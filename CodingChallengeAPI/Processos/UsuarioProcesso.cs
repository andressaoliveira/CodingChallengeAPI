using CodingChallengeAPI.Util;
using CodingChallengeAPI.Models;
using CodingChallengeAPI.Excecao;
using CodingChallengeAPI.Enum;
using CodingChallengeAPI.Repositorio;

namespace CodingChallengeAPI.Processo;
public class UsuarioProcesso
{
    private readonly UsuarioBdRepositorio usuarioBdRepositorio = new();

    public async Task<Usuario?> GetUsuario(int idUsuario)
    {
        var usuario = await usuarioBdRepositorio.GetUsuario(idUsuario);
        return usuario;
    }

    public async Task<List<Usuario>> GetUsuarios()
    {
        var usuarios = await usuarioBdRepositorio.GetUsuarios();
        if (usuarios.IsNullOrEmpty()) { 
            throw new UsuarioException(); 
        }

        return usuarios;
    }

    public async Task CadastrarUsuario(Usuario usuario)
    {
        await usuarioBdRepositorio.CadastrarUsuario(usuario);
    }

    public async Task TornarModerador(int idUsuarioModerador, int idUsuario)
    {
        var usuarioModerador = await GetUsuario(idUsuarioModerador);
        if (usuarioModerador == null)
        {
            throw new UsuarioException();
        }

        if (usuarioModerador.Perfil == PerfilUsuario.MODERADOR)
        {
            await usuarioBdRepositorio.AtualizarPerfil(idUsuario, 4);
        }
    }

    public async Task AtualizarPontuacao(int idUsuario, PerfilUsuario perfil, int pontos)
    {
        await usuarioBdRepositorio.AtualizarPontuacao(idUsuario, perfil, pontos);
    }
}