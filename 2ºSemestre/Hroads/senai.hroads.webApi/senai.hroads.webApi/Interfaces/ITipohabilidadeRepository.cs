using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipohabilidadeRepository
    {
        List<Tipohabilidade> Listar();

        Tipohabilidade BuscarPorId(int idTipohabilidade);

        void Cadastrar(Tipohabilidade novoTipohabilidade);

        void Atualizar(short idTipohabilidade, Tipohabilidade TipohabilidadeAtualizado);

        void Deletar(int idTipohabilidade);
    }
}
