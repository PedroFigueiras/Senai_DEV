

USE HROADS_NP;
GO

INSERT INTO CLASSE(descricaoClasse)
VALUES ('Barbaro'), ('Cruzado'), ('CAÇADORA DE DEMONIOS'), ('Monge'),
('Necromante'), ('Feiticeiro'), ('Arcanista');
GO

--5-Atualizar o nome da classe de Necromante para Necromancer;
update CLASSE SET descricaoClasse = 'Necromancer' 
WHERE idClasse = 12


INSERT INTO TIPOHABILIDADE(descricaoTipo)
VALUES ('Ataque'), ('Defesa'), ('Cura'), ('Magia');
GO

INSERT INTO PERSONAGEM(idClasse,nomePersonagem, capacidadeMax, capacidadeMana, dataAtualizacao, dataCriacao)
VALUES (1,'DeuBug', '100', '80', '09/08/2021', '18/01/2019'),
(4,'BitBug', '70', '100', '09/08/2021', '17/03/2016'),
(7,'Fer8', '75', '60','09/08/2021', '18/03/2018');
GO

--4- Atualizar o nome do personagem Fer8 para Fer7
update PERSONAGEM SET nomePersonagem = 'Fer7' 
WHERE idPersonagem = 3 


INSERT INTO HABILIDADE(idTipo, nomeHabilidade)
VALUES (1,'Lança Mortal'), (2,'Escudo Supremo'), (3,'Recuperar Vida');
GO

INSERT INTO CLASSE_HABILIDADE(idClasse, idHabilidade)
VALUES (1,1), (1,1), (2,2),(3,1), (4,3), (4,2),(5,NULL),(6,3), (7,NULL);
GO

select * from CLASSE_HABILIDADE

INSERT INTO TIPOUSARIO(titulo)
VALUES ('Jogador'), ('Administrador');
GO

SELECT * FROM TIPOUSARIO

INSERT INTO USUARIO(idTipoUsuario,email,nome,senha)
VALUES (1,'jogador@email.com','jogador','123'), (2,'admin@email.com','administrador','456');
GO
select * from USUARIO