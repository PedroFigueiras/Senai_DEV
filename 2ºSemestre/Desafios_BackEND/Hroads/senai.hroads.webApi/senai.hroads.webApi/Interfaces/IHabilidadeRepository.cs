using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();

        Habilidade BuscarPorId(int idHabilidade);

        void Cadastrar(Habilidade novaHabilidade);

        void Atualizar(short idHabilidade, Habilidade HabilidadeAtualizada);

        void Deletar(int idHabilidade);
    }
}
