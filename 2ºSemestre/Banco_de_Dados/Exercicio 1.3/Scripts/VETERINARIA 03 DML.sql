
USE VETERINARIA;;
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

