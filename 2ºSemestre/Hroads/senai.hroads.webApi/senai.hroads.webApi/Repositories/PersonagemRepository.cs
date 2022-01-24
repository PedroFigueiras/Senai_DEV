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
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(short idPersonagem, Personagem PersonagemAtualizado)
        {
            Personagem personagemBuscada = ctx.Personagems.Find(idPersonagem);

            if (PersonagemAtualizado.NomePersonagem != null)
            {
                personagemBuscada.NomePersonagem = PersonagemAtualizado.NomePersonagem;
                personagemBuscada.CapacidadeMax = PersonagemAtualizado.CapacidadeMax;
                personagemBuscada.CapacidadeMana = PersonagemAtualizado.CapacidadeMana;
                personagemBuscada.DataAtualizacao = PersonagemAtualizado.DataAtualizacao;
                personagemBuscada.DataCriacao = PersonagemAtualizado.DataCriacao;

                ctx.Personagems.Update(personagemBuscada);

                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == idPersonagem);
        }

        public void Cadastrar(Personagem novoPesonagem)
        {
            ctx.Personagems.Add(novoPesonagem);

            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            ctx.Personagems.Remove(BuscarPorId(idPersonagem));

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList();
        }
    }
}
