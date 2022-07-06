CREATE TABLE Perfil (
	IdPerfil int NOT NULL,
    Perfil varchar(100),
    PontuacaoMinima int,
    PRIMARY KEY (IdPerfil)
);

CREATE TABLE Usuario (
	IdUsuario int NOT NULL AUTO_INCREMENT,
    Nome varchar(100),
    Email varchar(100),
    Senha varchar(100),
    IdPerfil int DEFAULT 1,
    Pontos int DEFAULT 0,
    PRIMARY KEY (IdUsuario),
    FOREIGN KEY (IdPerfil) REFERENCES Perfil(IdPerfil)
);

CREATE TABLE Comentario (
	IdComentario int NOT NULL AUTO_INCREMENT,
    IdFilme varchar(100),
    IdUsuario int,
    Texto varchar(1000),
    Repetido boolean DEFAULT false,
    PRIMARY KEY (IdComentario),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Nota (
	IdNota int NOT NULL AUTO_INCREMENT,
    IdFilme varchar(100),
    IdUsuario int,
    Nota int,
    PRIMARY KEY (IdNota),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Resposta (
	IdResposta int NOT NULL AUTO_INCREMENT,
    IdComentario int,
    IdUsuario int,
    Texto varchar(1000),
    PRIMARY KEY (IdResposta),
    FOREIGN KEY (IdComentario) REFERENCES Comentario(IdComentario),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE ComentarioAvaliacao (
	IdAvaliacao int NOT NULL AUTO_INCREMENT,
    IdComentario int,
    IdUsuario int,
    Gostei boolean,
    PRIMARY KEY (IdAvaliacao),
    FOREIGN KEY (IdComentario) REFERENCES Comentario(IdComentario),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

INSERT INTO Perfil (IdPerfil,Perfil,PontuacaoMinima)
VALUES (1,'Leitor',0);
INSERT INTO Perfil (IdPerfil,Perfil,PontuacaoMinima)
VALUES (2,'Basico',20);
INSERT INTO Perfil (IdPerfil,Perfil,PontuacaoMinima)
VALUES (3,'Avancado',100);
INSERT INTO Perfil (IdPerfil,Perfil,PontuacaoMinima)
VALUES (4,'Moderador',1000);


SELECT * FROM Nota;
SELECT * FROM Comentario;
SELECT * FROM ComentarioAvaliacao;
SELECT * FROM Resposta;
SELECT * FROM Perfil;
SELECT * FROM Usuario;


UPDATE Usuario SET Pontos = 200, IdPerfil = 4 WHERE IdUsuario = 1;






#DROP TABLE Comentario;
#DROP TABLE Nota;
#DROP TABLE Usuario;
#DROP TABLE Perfil;