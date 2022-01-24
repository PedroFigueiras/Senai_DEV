
USE LOCADORA;
GO


SELECT * FROM CLIENTE
SELECT * FROM EMPRESA
SELECT * FROM ALUGUEL
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO


--- listar todos os alugueis mostrando as datas de início e fim, o nome do
--cliente que alugou e nome do modelo do carro

SELECT IdAluguel, nomeCliente, dataAluguelInicio, dataAluguelFim  FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.IdVeiculo = VEICULO.IdVeiculo


--listar os alugueis de um determinado cliente mostrando seu nome, as datas
--de início e fim e o nome do modelo do carro

SELECT IdVeiculo, descriçãoModelo, placa FROM VEICULO
LEFT JOIN MODELO
ON VEICULO.IdModelo = MODELO.IdModelo
                                                                                                                                                                              

