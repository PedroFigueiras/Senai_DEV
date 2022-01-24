using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_RENTAL.Controllers;

namespace T_RENTAL.Interfaces
{
    /// <summary>
    /// Responsável pelo repositório  'AluguelRepository'
    /// </summary> 
   
        interface IAluguelRepository
        {
            /// <summary>
            ///  Resposável por listar todos os Alugueis
            /// </summary>
            /// <returns>lista de Aluguel</returns>
            List<AluguelDomain> ListarTodos();


            /// <summary>
            ///  Buscar um Aluguel através do 'id'
            /// </summary>
            /// <param name="IdAluguel">id do Aluguel que será buscado</param>
            /// <returns>Um Aluguel buscado</returns>
            AluguelDomain BuscarPorId(int IdAluguel);


            /// <summary>
            /// Cadastra um novo Aluguel
            /// </summary>
            /// <param name="novoAluguel">Objeto novoAluguel com os dados</param>
            void Cadastrar(AluguelDomain novoAluguel);


            /// <summary>
            /// Atualiza um Aluguel existente
            /// </summary>
            /// <param name="IdAluguel">id do Aluguel que será atualizado</param>
            /// <param name="AluguelAtualizado">Objeto veiculoAtualizado com os novos dados atualizados</param>
            void AtualizarIdUrl(int IdAluguel, AluguelDomain AluguelAtualizado);

            /// <summary>
            /// Deleta um Aluguel existente
            /// </summary>
            /// <param name="IdAluguel">id do Aluguel que será deletado</param>
            void Deletar(int IdAluguel);


    }

       
}
