using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipousuarioRepository
    {
        List<Tipousario> Listar();

        Tipousario BuscarPorId(int idTipousuario);

        void Cadastrar(Tipousario novoTipousuario);

        void Atualizar(short idTipousuario, Tipousario TipousuarioAtualizado);

        void Deletar(int idTipousuario);
    }
}
