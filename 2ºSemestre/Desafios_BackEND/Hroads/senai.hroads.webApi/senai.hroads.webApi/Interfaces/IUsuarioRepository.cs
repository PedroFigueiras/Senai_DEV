using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int idUsuario);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(short idUsuario, Usuario UsuarioAtualizado);

        void Deletar(int Usuario);

        Usuario Login(string email, string senha);
    }
}
