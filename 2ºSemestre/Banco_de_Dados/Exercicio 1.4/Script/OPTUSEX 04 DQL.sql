SELECT * FROM EMPRESA
SELECT * FROM USUARIO
SELECT * FROM CD
SELECT * FROM ALBUM
SELECT * FROM ESTILOMUSICAL
SELECT * FROM ARTISTAS

-- listar todos os usu�rios administradores, sem exibir suas senhas
SELECT nomeUsuario, email, cpf, tipodePermiss�o FROM USUARIO
WHERE tipodePermiss�o = 'Adm'

--listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
SELECT * FROM ALBUM
WHERE daralan�amento BETWEEN '2021-08-04'AND '2017-08-05';

SELECT * FROM ALBUM
WHERE daralan�amento BETWEEN '2002-08-06'AND '2021-12-15';

--listar os dados de um usu�rio atrav�s do e-mail e senha

SELECT * FROM USUARIO
WHERE email = 'p@email.com' AND senha = 1111

SELECT * FROM USUARIO
WHERE email = 'r@email.com' AND senha = 2222

--listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 

SELECT nomeAlbum, nomeArtistas , nomeEstMusical FROM ALBUM
LEFT JOIN ARTISTAS
ON ALBUM.IdArtistas = ARTISTAS.IdArtistas
LEFT JOIN ESTILOMUSICAL
ON ALBUM.IdEstMusical = ESTILOMUSICAL.idEstMusical