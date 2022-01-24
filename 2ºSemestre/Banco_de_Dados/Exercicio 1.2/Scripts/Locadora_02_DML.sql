

USE LOCADORA;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Carrefour'), ('Scania');
GO

SELECT * FROM EMPRESA



INSERT INTO VEICULO ( IdModelo, placa)
VALUES (2,'aaaaa'),   (3,'11111');
GO

SELECT * FROM VEICULO



INSERT INTO MODELO( IdMarca, descriçãoModelo)
VALUES (1,'BMW2'), (2,'3008');

SELECT * FROM MODELO


INSERT INTO MARCA (nomeMarca)
VALUES ('BMW'), ('PEUGEOT');
GO

SELECT * FROM MARCA

--IdCliente nulo

INSERT INTO ALUGUEL(IdVeiculo, IdCliente, valor, dataAluguelInicio, dataAluguelFim) 
VALUES (1,1,'R$500','05/02/2017','05/02/2018'), (2,2,'R$1000','20/05/2004','20/05/2017');
GO

SELECT * FROM ALUGUEL

INSERT INTO CLIENTE(nomeCliente, cpfCliente) 
VALUES ('Pedro','500'), ('Rosa','1000');
GO

SELECT * FROM CLIENTE