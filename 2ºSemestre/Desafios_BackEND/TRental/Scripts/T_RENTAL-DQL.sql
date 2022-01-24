USE T_Rental
GO


SELECT IdAluguel, nomeCliente, nomeModelo, placaVeiculo,dataAluguel , dataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
INNER JOIN MODELO
ON MODELO.IdModelo = veiculo.IdModelo
LEFT JOIN CLIENTE
ON CLIENTE.IdCliente = ALUGUEL.IdCliente


SELECT IdAluguel, nomeCliente, nomeModelo, placaVeiculo,dataAluguel , dataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
INNER JOIN MODELO
ON MODELO.IdModelo = veiculo.IdModelo
LEFT JOIN CLIENTE
ON CLIENTE.IdCliente = ALUGUEL.IdCliente
WHERE nomeCliente = 'Pedro'


SELECT idCliente,nomeCliente, sobrenomeCliente,cnpjCliente FROM CLIENTE

SELECT idVeiculo,ISNULL(VEICULO.idEmpresa,0),ISNULL(VEICULO.idModelo,0),nomeEmpresa,nomeModelo,placaVeiculo FROM VEICULO
INNER JOIN EMPRESA
ON EMPRESA.idEmpresa = VEICULO.idEmpresa
INNER JOIN MODELO
ON  MODELO.idModelo = VEICULO.idModelo

SELECT idAluguel 'ID',ISNULL(ALUGUEL.idVeiculo,0),ISNULL(ALUGUEL.idCliente,0), nomeCliente, placaVeiculo,dataAluguel , dataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN CLIENTE
ON CLIENTE.idCliente = ALUGUEL.idCliente


SELECT * FROM CLIENTE
SELECT * FROM ALUGUEL
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM EMPRESA

