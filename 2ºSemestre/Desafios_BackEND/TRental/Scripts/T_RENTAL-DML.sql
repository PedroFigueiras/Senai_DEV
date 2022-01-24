USE T_Rental
GO

INSERT INTO EMPRESA (empresa)
VALUES ('Ford'),('Chevrollet');
GO

INSERT INTO MARCA (Marca)
VALUES ('Ford'),('Chevrollet')
GO


INSERT INTO MODELO (idMarca,modelo)
VALUES (1,'KA'), (2,'UNO')
GO

INSERT INTO VEICULO(IdEmpresa,IdModelo,placaVeiculo)
VALUES (1,1,'4123'),(1,2,'5678')
GO

INSERT INTO CLIENTE (nomeCliente,sobrenomeCliente,cnpjCliente)
VALUES('Pedro','Figueira','1234567890123'),('Rosa','Figueira','0102030405060')
GO

INSERT INTO ALUGUEL (IdVeiculo,IdCliente,Aluguel,Devolucao)
VALUES (1,1,'28/02/2021','24/05/2021'),(2,2,'14/03/2003','05/03/2020')
GO


SELECT * FROM CLIENTE
SELECT * FROM ALUGUEL
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM EMPRESA












