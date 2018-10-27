CREATE TABLE Noticias
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Titulo varchar(30) NULL,
	Subtitulo varchar(100) NULL,
	Descricao varchar(500) NOT NULL,
	Autor varchar(20),
	DataCadastro datetime NOT NULL
);

CREATE TABLE Noticias_LOG
(
	Id UNIQUEIDENTIFIER NOT NULL,
	Titulo varchar(30) NULL,
	Subtitulo varchar(100) NULL,
	Descricao varchar(500) NOT NULL,
	Autor varchar(20),
	DataOperacao datetime NOT NULL,
	Operacao char(1) NOT NULL
);