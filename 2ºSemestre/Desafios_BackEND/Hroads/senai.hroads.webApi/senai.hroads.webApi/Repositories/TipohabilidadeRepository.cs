using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipohabilidadeRepository : ITipohabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(short idTipohabilidade, Tipohabilidade TipohabilidadeAtualizado)
        {
            Tipohabilidade tipohBuscado = ctx.Tipohabilidades.Find(idTipohabilidade);

            if (TipohabilidadeAtualizado.DescricaoTipo != null)
            {
                tipohBuscado.DescricaoTipo = TipohabilidadeAtualizado.DescricaoTipo;

                ctx.Tipohabilidades.Update(tipohBuscado);

                ctx.SaveChanges();
            }
        }

        public Tipohabilidade BuscarPorId(int idTipohabilidade)
        {
            return ctx.Tipohabilidades.FirstOrDefault(tp => tp.IdTipo == idTipohabilidade);
        }

        public void Cadastrar(Tipohabilidade novoTipohabilidade)
        {
            ctx.Tipohabilidades.Add(novoTipohabilidade);

            ctx.SaveChanges();
        }


        public void Deletar(int idTipohabilidade)
        {
            ctx.Tipohabilidades.Remove(BuscarPorId(idTipohabilidade));

            ctx.SaveChanges();
        }

        public List<Tipohabilidade> Listar()
        {
            return ctx.Tipohabilidades.ToList();
        }
    }
}
