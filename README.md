# CodingChallengeAPI

Link da API Publicada: https://codingchallengeapi.azurewebsites.net

Exemplo de Get: https://localhost:7197/Filme/FilmesApiPorId?idFilme=tt1570728


# Rotas:

## Comentario:
### GET/Comentario/ComentariosByIdFilme?idFilme - Busca todos comentários de um filme
/Comentario/ComentariosByIdFilme?idFilme=tt1570728

### POST /Comentario - Faz um comentário

Body: IdFilme, IdUsuario, Texto

### PUT /Comentario/AvaliarComentario - Avalia um comentário (Gostei ou NãoGostei)
Body: idComentario, idComentario, goste i(true ou false)





## Usuário:

### GET /Usuario - Buscar usuário por Id

/Usuario?idUsuario=1

### POST /Usuario - Cadastrar novo usuário

Body: Nome, Email e Senha 

### GET /Usuario/Todos - Busca todos os usuários

/Usuario/Todos

### PUT /Usuario/TornarModerador - Moderador tornar outro usuário moderador

/Usuario/TornarModerador?idUsuarioModerador=1&idUsuario=1
