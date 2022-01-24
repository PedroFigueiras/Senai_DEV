using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(short idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(idUsuario);

            if (UsuarioAtualizado.Nome != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Nome = UsuarioAtualizado.Nome;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(p => p.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId( idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Login(string email, string senha)
        {
           return ctx.Usuarios.FirstOrDefault(U => U.Email == email && U.Senha == senha);
        }
    }
}
