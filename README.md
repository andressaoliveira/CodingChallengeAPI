# CodingChallengeAPI

Link da API Publicada: https://codingchallengeapi.azurewebsites.net

Exemplo de Get: https://codingchallengeapi.azurewebsites.net/Filme/FilmesApiPorId?idFilme=tt1570728


# Rotas:

## &emsp; Comentario:
### GET/Comentario/ComentariosByIdFilme?idFilme - Busca todos comentários de um filme
/Comentario/ComentariosByIdFilme?idFilme=tt1570728

### POST /Comentario - Faz um comentário

Body: IdFilme, IdUsuario, Texto

### PUT /Comentario/AvaliarComentario - Avalia um comentário (Gostei ou NãoGostei)
Body: idComentario, idComentario, goste i(true ou false)

### PUT /Comentario/MarcarComoRepetido - Marca/Desmarca comentario como Repetido ou 
/Comentario/MarcarComoRepetido?idComentario=3&idUsuario=1&repetido=true

### DELETE - /Comentario/ExcluirComentario - Apaga um comentário
/Comentario/ExcluirComentario?idComentario=6&idUsuario=1


<br /><br />


## &emsp; Filme:
### GET /Filme/FilmesApi - Faz busca por uma string
/Filme/FilmesApi?busca=love

### GET - Busca um filme pelo seu Id
/Filme/FilmesApiPorId?idFilme=tt1570728


<br /><br />

## &emsp; Nota:

### GET /Nota/NotasByFIlme - Busca as notas do filme pelo seu Id
/Nota/NotasByFIlme?idFilme=tt1570728

### POST
Body: idFilme, idUsuario, valorNota


<br /><br />


## &emsp; Resposta:
### GET /Resposta/RespostasByComentario - Busca as respostas de um comentário
/Resposta/RespostasByComentario?idComentario=

### POST /Resposta - Cria uma resposta para um comentário
Body: idComentario, idUsuario, texto


<br /><br />


## &emsp; Usuário:

### GET /Usuario - Buscar usuário por Id

/Usuario?idUsuario=1

### POST /Usuario - Cadastrar novo usuário

Body: Nome, Email e Senha 

### GET /Usuario/Todos - Busca todos os usuários

/Usuario/Todos

### PUT /Usuario/TornarModerador - Moderador tornar outro usuário moderador

/Usuario/TornarModerador?idUsuarioModerador=1&idUsuario=1
