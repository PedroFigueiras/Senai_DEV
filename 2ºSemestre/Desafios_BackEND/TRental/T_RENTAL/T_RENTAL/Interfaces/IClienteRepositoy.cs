using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_RENTAL.Controllers;

namespace T_RENTAL.Interfaces
{
    interface IClienteRepositoy
    {
        /// <summary>
        ///  Lista todos os Clientes
        /// </summary>
        /// <returns>Uma lista de clientes</returns>
        List<ClienteDomain> ListarTodos();


        /// <summary>
        ///  Busca o cliente através do seu Id
        /// </summary>
        /// <param name="IdCliente">id do cliente que será buscado</param>
        /// <returns>Um cliente buscado</returns>
        ClienteDomain BuscarPorId(int IdCliente);


        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com os novos dados</param>
        void Cadastrar(ClienteDomain novoCliente);


        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="IdCliente">id do cliente que será atualizado</param>
        /// <param name="ClienteAtualizado">Objeto clienteAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrl(int IdCliente, ClienteDomain ClienteAtualizado);

        /// <summary>
        /// Deleta um cliente existente
        /// </summary>
        /// <param name="IdCliente">id do cliente que será deletado</param>
        void Deletar(int IdCliente);
    }
}
