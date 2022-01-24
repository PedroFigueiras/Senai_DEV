SELECT * FROM EMPRESA
SELECT * FROM USUARIO
SELECT * FROM CD
SELECT * FROM ALBUM
SELECT * FROM ESTILOMUSICAL
SELECT * FROM ARTISTAS

-- listar todos os usuários administradores, sem exibir suas senhas
SELECT nomeUsuario, email, cpf, tipodePermissão FROM USUARIO
WHERE tipodePermissão = 'Adm'

--listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT * FROM ALBUM
WHERE daralançamento BETWEEN '2021-08-04'AND '2017-08-05';

SELECT * FROM ALBUM
WHERE daralançamento BETWEEN '2002-08-06'AND '2021-12-15';

--listar os dados de um usuário através do e-mail e senha

SELECT * FROM USUARIO
WHERE email = 'p@email.com' AND senha = 1111

SELECT * FROM USUARIO
WHERE email = 'r@email.com' AND senha = 2222

--listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 

SELECT nomeAlbum, nomeArtistas , nomeEstMusical FROM ALBUM
LEFT JOIN ARTISTAS
ON ALBUM.IdArtistas = ARTISTAS.IdArtistas
LEFT JOIN ESTILOMUSICAL
ON ALBUM.IdEstMusical = ESTILOMUSICAL.idEstMusical