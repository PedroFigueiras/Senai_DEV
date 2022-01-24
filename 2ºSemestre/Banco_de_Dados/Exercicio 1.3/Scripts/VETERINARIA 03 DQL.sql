

USE VETERINARIA;;
GO



SELECT * FROM CLINICA
SELECT * FROM VETERINARIOS
SELECT * FROM TIPOSPETS
SELECT * FROM DONO
SELECT * FROM RACA
SELECT * FROM PETS
SELECT * FROM ATENDIMENTO

---------DQL


--- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)

SELECT nome, razaoSocial FROM VETERINARIOS
LEFT JOIN CLINICA
ON VETERINARIOS.IdClinica = CLINICA.idClinica

--- listar todas as ra�as que come�am com a letra S

SELECT descricaoRaca FROM RACA
WHERE descricaoRaca LIKE 'c%';

-- listar todos os tipos de pet que terminam com a letra O

SELECT descricaoRaca FROM RACA
WHERE descricaoRaca LIKE '%r';

-- listar todos os pets mostrando os nomes dos seus donos

SELECT descricaoNome, nomeDono FROM PETS
LEFT JOIN DONO
ON PETS.IdDono = DONO.IdDono

-- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, o nome do dono do pet e o nome da cl�nica onde o pet foi atendido

SELECT nome, descricaoNome, descricaoDoenca FROM ATENDIMENTO
RIGHT JOIN PETS
ON ATENDIMENTO.idPet = PETS.IdPet
FULL OUTER JOIN VETERINARIOS
ON ATENDIMENTO.idVeterinario = VETERINARIOS.IdVeterinario