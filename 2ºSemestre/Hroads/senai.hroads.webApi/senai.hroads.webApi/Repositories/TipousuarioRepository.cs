using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{

    public class TipousuarioRepository : ITipousuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(short idTipousuario, Tipousario TipousuarioAtualizado)
        {
            Tipousario TipoUsuarioBuscada = ctx.Tipousarios.Find(idTipousuario);

            if (TipousuarioAtualizado.Titulo != null)
            {
                TipoUsuarioBuscada.Titulo = TipousuarioAtualizado.Titulo;

                ctx.Tipousarios.Update(TipoUsuarioBuscada);

                ctx.SaveChanges();
            }
        }

        public Tipousario BuscarPorId(int idTipousuario)
        {
            return ctx.Tipousarios.FirstOrDefault(c => c.IdTipoUsuario == idTipousuario);
        }

        public void Cadastrar(Tipousario novoTipousuario)
        {
            ctx.Tipousarios.Add(novoTipousuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipousuario)
        {
            ctx.Tipousarios.Remove(BuscarPorId(idTipousuario));

            ctx.SaveChanges();
        }

        public List<Tipousario> Listar()
        {
            return ctx.Tipousarios.ToList();
        }
    }
}
