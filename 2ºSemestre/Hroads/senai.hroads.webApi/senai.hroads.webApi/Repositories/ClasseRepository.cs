using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(short idClasse, Classe ClasseAtualizada)
        {
             Classe classeBuscada = ctx.Classes.Find(idClasse);

            if (ClasseAtualizada.DescricaoClasse != null)
            {
                classeBuscada.DescricaoClasse = ClasseAtualizada.DescricaoClasse;

                ctx.Classes.Update(classeBuscada);

                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int idClasse)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == idClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            ctx.Classes.Remove(BuscarPorId(idClasse));

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }
    }
}
