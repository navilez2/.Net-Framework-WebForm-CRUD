USE MASTER
GO

DROP DATABASE IF EXISTS GESTAO_PEDIDO

CREATE DATABASE GESTAO_PEDIDO
GO

USE GESTAO_PEDIDO
GO

DROP TABLE IF EXISTS TB_PRODUTO_PEDIDO
DROP TABLE IF EXISTS TB_PRODUTO
DROP TABLE IF EXISTS TB_PEDIDO
GO


CREATE TABLE TB_PRODUTO
(
	ID_PRODUTO INT IDENTITY NOT NULL PRIMARY KEY,
	DC_PRODUTO VARCHAR(200) NOT NULL,
	DC_MARCA VARCHAR(100) NOT NULL,
	DC_CATEGORIA VARCHAR(100) NOT NULL,
	DC_UNIDADE_MEDIDA VARCHAR(10),
	VL_PRECO FLOAT,
	DT_ALTERACAO DATETIME,
)
GO

CREATE TABLE TB_PEDIDO
(
	ID_PEDIDO INT IDENTITY NOT NULL PRIMARY KEY,
	NM_CLIENTE VARCHAR (100),
	DT_DATA_PEDIDO DATETIME,
	DC_CIDADE VARCHAR (100),
	DC_ESTADO VARCHAR (50),
	NR_CEP INT,
	DC_ENDERECO VARCHAR (100),
	DT_ALTERACAO DATETIME
)
GO

CREATE TABLE TB_PRODUTO_PEDIDO
(
	ID_PEDIDO_PRODUTO INT IDENTITY NOT NULL PRIMARY KEY,
	ID_PEDIDO INT REFERENCES TB_PEDIDO(ID_PEDIDO) NOT NULL UNIQUE,
	ID_PRODUTO INT REFERENCES TB_PRODUTO(ID_PRODUTO) NOT NULL UNIQUE,
	NR_QUANTIDADE INT NOT NULL
)
GO

