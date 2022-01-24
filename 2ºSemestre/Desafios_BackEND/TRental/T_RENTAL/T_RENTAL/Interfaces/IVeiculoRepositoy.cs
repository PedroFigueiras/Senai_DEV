using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_RENTAL.Controllers;

namespace T_RENTAL.Interfaces
{
    interface IVeiculoRepositoy
    {
        /// <summary>
        ///  Lista todos os veiculos
        /// </summary>
        /// <returns>Uma lista de veiculos</returns>
        List<VeiculoDomain> ListarTodos();


        /// <summary>
        ///  Busca um veiculo através do seu id
        /// </summary>
        /// <param name="IdVeiculo">id do veiculo que será buscado</param>
        /// <returns>Um veiculo buscado</returns>
        VeiculoDomain BuscarPorId(int IdVeiculo);


        /// <summary>
        /// Cadastra um novo veiculo
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo com os novos dados</param>
        void Cadastrar(VeiculoDomain novoVeiculo);


        /// <summary>
        /// Atualiza um Veiculo existente
        /// </summary>
        /// <param name="IdVeiculo">id do veiculo que será atualizado</param>
        /// <param 
        /// name="VeiculoAtualizado">Objeto veiculoAtualizado com os novos dados atualizados
        /// </param>
        void AtualizarIdUrl(int IdVeiculo, VeiculoDomain VeiculoAtualizado);

        /// <summary>
        /// Deleta um veiculo existente
        /// </summary>
        /// <param name="IdVeiculo">id do veiculo que será deletado</param>
        void Deletar(int IdVeiculo);



    }
}
