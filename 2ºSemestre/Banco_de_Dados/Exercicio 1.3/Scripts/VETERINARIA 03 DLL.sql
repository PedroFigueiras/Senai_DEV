

CREATE DATABASE VETERINARIA;
GO

USE VETERINARIA;;
GO

CREATE TABLE CLINICA (
 IdClinica TINYINT PRIMARY KEY IDENTITY(1,1),
 razaoSocial VARCHAR(30) NOT NULL UNIQUE,
 cnpj CHAR(15) UNIQUE,
 endereco VARCHAR(30) 
);
GO

CREATE TABLE DONO (
 IdDono SMALLINT PRIMARY KEY IDENTITY(1,1),
 nomeDono VARCHAR(20) NOT NULL
);
GO

CREATE TABLE TIPOSPETS (
 IdTipoPet SMALLINT PRIMARY KEY IDENTITY(1,1),
 descricaoTipos VARCHAR(30) NOT NULL
);
GO



--SALVAR

CREATE TABLE VETERINARIOS (
 IdVeterinario TINYINT PRIMARY KEY IDENTITY(1,1),
 IdClinica TINYINT FOREIGN KEY REFERENCES CLINICA(IdClinica),
 nome VARCHAR(30) NOT NULL
);
GO

CREATE TABLE RACA (
 IdRaca TINYINT PRIMARY KEY IDENTITY(1,1),
 IdTipoPet SMALLINT FOREIGN KEY REFERENCES TIPOSPETS(IdTipopet),
 descricaoRaca VARCHAR(20) NOT NULL
);
GO

CREATE TABLE PETS (
 IdPet SMALLINT PRIMARY KEY IDENTITY(1,1),
 IdRaca TINYINT FOREIGN KEY REFERENCES RACA(IdRaca),
 IdDono SMALLINT FOREIGN KEY REFERENCES DONO(IdDono),
 descricaoNome VARCHAR(30) NOT NULL,
 nascimentoData VARCHAR(20) NOT NULL
);
GO

   --COMO APAGAR--

--ALTER TABLE PETS
--DROP COLUMN IdRaca

--ALTER TABLE PETS
--ADD IdRaca TINYINT FOREIGN KEY REFERENCES RACA(IdRaca),

CREATE TABLE ATENDIMENTO (
 IdAtendimento SMALLINT PRIMARY KEY IDENTITY(1,1),
 IdVeterinario TINYINT FOREIGN KEY REFERENCES VETERINARIOS(IdVeterinario),
 IdPet SMALLINT FOREIGN KEY REFERENCES PETS(IdPet),
 descricaoDoenca VARCHAR(18) NOT NULL
);
GO


--DML


INSERT INTO CLINICA(razaoSocial, cnpj, endereco)
VALUES ('limoeiro', '11223344', 'Av.  Urucun Deblin, 222');
GO

SELECT * FROM CLINICA


INSERT INTO VETERINARIOS(IdClinica, nome)
VALUES (1,'Marcos'), (1,'Bianca');
GO

SELECT * FROM VETERINARIOS


INSERT INTO TIPOSPETS(descricaoTipos)
VALUES ('Cachorro'), ('Gato');
GO

SELECT * FROM TIPOSPETS

INSERT INTO DONO(nomeDono)
VALUES ('Pedro'), ('Rosa');
GO

SELECT * FROM DONO



INSERT INTO RACA(IdTipoPet, descricaoRaca)
VALUES (1,'Pintcher'), (2,'Ciames');
GO

SELECT * FROM RACA

INSERT INTO PETS(IdRaca,IdDono, descricaoNome, nascimentoData)
VALUES (1,1,'toto','02/02/2018'), (2,2,'neco','06/07/2016');
GO

SELECT * FROM PETS


INSERT INTO ATENDIMENTO(IdVeterinario, IdPet, descricaoDoenca)
VALUES (1,2,'Cancer'), (2,3,'Infecção');
GO

SELECT * FROM ATENDIMENTO



SELECT * FROM CLINICA
SELECT * FROM VETERINARIOS
SELECT * FROM TIPOSPETS
SELECT * FROM DONO
SELECT * FROM RACA
SELECT * FROM PETS
SELECT * FROM ATENDIMENTO


---------DQL


--- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)

SELECT nome, razaoSocial FROM VETERINARIOS
LEFT JOIN CLINICA
ON VETERINARIOS.IdClinica = CLINICA.idClinica

--- listar todas as raças que começam com a letra S

SELECT descricaoRaca FROM RACA
WHERE descricaoRaca LIKE 'c%';

-- listar todos os tipos de pet que terminam com a letra O

SELECT descricaoRaca FROM RACA
WHERE descricaoRaca LIKE '%r';

-- listar todos os pets mostrando os nomes dos seus donos

SELECT descricaoNome, nomeDono FROM PETS
LEFT JOIN DONO
ON PETS.IdDono = DONO.IdDono

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica onde o pet foi atendido

SELECT nome, descricaoNome, descricaoDoenca FROM ATENDIMENTO
RIGHT JOIN PETS
ON ATENDIMENTO.idPet = PETS.IdPet
FULL OUTER JOIN VETERINARIOS
ON ATENDIMENTO.idVeterinario = VETERINARIOS.IdVeterinario