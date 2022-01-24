USE HROADS_NP;
GO

SELECT * FROM PERSONAGEM
SELECT * FROM CLASSE
SELECT * FROM HABILIDADE
SELECT * FROM TIPOHABILIDADE

--6-Selecionar todos os personagens
  SELECT nomePersonagem FROM PERSONAGEM

-- 7 Selecionar todos as classes
   SELECT * FROM CLASSE

--8 Selecionar somente o nome das classes;
    SELECT descricaoClasse FROM CLASSE

--9. Selecionar todas as habilidades;
 SELECT nomeHabilidade FROM HABILIDADE

--10. Realizar a contagem de quantas habilidades estão cadastradas;
  SELECT  COUNT (*) [Quantidade de Habilidades] FROM HABILIDADE

--11 Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
  SELECT idHabilidade FROM HABILIDADE
  ORDER BY idHabilidade


 -- 12. Selecionar todos os tipos de habilidades;
   SELECT * FROM TIPOHABILIDADE


--13. Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT nomeHabilidade, descricaoTipo FROM HABILIDADE
LEFT JOIN  TIPOHABILIDADE
ON TIPOHABILIDADE.idTipo = HABILIDADE.idTipo


--14 Selecionar todos os personagens e suas respectivas classes;
SELECT nomePersonagem, descricaoClasse FROM PERSONAGEM
LEFT JOIN  CLASSE
ON CLASSE.idClasse = PERSONAGEM.idClasse


--15. Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
SELECT nomePersonagem, descricaoClasse FROM PERSONAGEM
FULL JOIN  CLASSE
ON CLASSE.idClasse = PERSONAGEM.idClasse

--16. Selecionar todas as classes e suas respectivas habilidades;
SELECT descricaoClasse, nomeHabilidade FROM CLASSE
LEFT JOIN  CLASSE_HABILIDADE
ON CLASSE.idClasse = CLASSE_HABILIDADE.idClasse
LEFT JOIN HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade

--17. Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT  nomeHabilidade,descricaoClasse FROM HABILIDADE
INNER JOIN  CLASSE_HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade
INNER JOIN CLASSE
ON CLASSE.idClasse = CLASSE_HABILIDADE.idClasse

--18. Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT  nomeHabilidade,descricaoClasse FROM HABILIDADE
LEFT JOIN  CLASSE_HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade
FULL JOIN CLASSE
ON CLASSE.idClasse = CLASSE_HABILIDADE.idClasse




