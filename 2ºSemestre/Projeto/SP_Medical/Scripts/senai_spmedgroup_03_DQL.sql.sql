USE SP
GO


UPDATE CONSULTA SET descricao = 'teste'
WHERE idConsulta  = 11 ;


--Mostrar a quantidade de usuários 
 SELECT  COUNT (*) [Quantidade de Usuários] FROM USUARIO

--Converter a data de nascimento do paciente para o formato (mm-dd-yyyy) na exibição
SELECT convert(varchar(20),DataNascimento,106) [Data de nascimento] FROM PACIENTE

--Calcular a idade do paciente a partir da data de nascimento
SELECT NomePaciente [Nome Paciente],FLOOR(DATEDIFF(DAY, DataNascimento, GETDATE()) / 365.25)[Idade] FROM PACIENTE




-- Mostrar pela a consulta o nome do médico e a especialidade dele , a situaçãõ da consulta e o nome do paciente
SELECT NomePaciente, TipoSituacao [Consulta],NomeMedico,NomeEspecialidade FROM CONSULTA
INNER JOIN MEDICO
ON MEDICO.idMedico = CONSULTA.idMedico
INNER JOIN ESPECIALIDADE
ON ESPECIALIDADE.idEspecialidade = MEDICO.idEspecialidade
INNER JOIN PACIENTE 
ON PACIENTE.idPaciente = CONSULTA.idPaciente
INNER JOIN SITUACAO 
ON SITUACAO.idSituacao = CONSULTA.idSituacao


--Criou uma função para retornar a quantidade de médicos de uma determinada especialidade
SELECT  COUNT (*) [Quantidade de Médicos] FROM MEDICO
INNER JOIN ESPECIALIDADE
ON ESPECIALIDADE.idEspecialidade = MEDICO.idEspecialidade
WHERE NomeEspecialidade = 'Pediatria'
;