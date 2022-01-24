
USE OPCUSEX
GO


INSERT INTO USUARIO(nomeUsuario,cpf, email,senha, tipodePermissao)
VALUES ('Pedro', '111', 'p@gmail.com', '123', 'ADM1'), ('Rosa', '222', 'r@gmail.com', '123', 'ADM2');
GO

INSERT INTO ARTISTAS(nomeArtistas)
VALUES ('Marcos'),('Bianca');
GO

INSERT INTO ESTILOMUSICAL(nomeEstMusical)
VALUES ('Setanejo'),('FUNK');
GO

INSERT INTO EMPRESA(nomeEmpresa, IdUsuario)
VALUES ('Hardware STORE',2);
GO

INSERT INTO CD (nomeCD, IdArtistas, IdEstMusical)
VALUES ('Alô Ambev',1, 1),('Só quer vral',2, 3);
GO

INSERT INTO ALBUM( nomeAlbum, IdArtistas, IdEstMusical)
VALUES ('Solidão',1, 2),('Loucos',2, 3);
GO

UPDATE ALBUM
SET daralançamento = '111111'
WHERE IdALBUM = 2

UPDATE ALBUM
SET quantMin = '20min'
WHERE IdALBUM = 2

UPDATE ALBUM
SET Localização = 'São Paulo'
WHERE IdALBUM = 2

UPDATE ALBUM
SET Visualização = 'Ativado'
WHERE IdALBUM = 2