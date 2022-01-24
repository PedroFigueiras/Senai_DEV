using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_RENTAL.Interfaces;
using T_RENTAL.Repositories;

namespace T_RENTAL.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepositoy _clienteRepository { get; set; }

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _clienteRepository.ListarTodos();

            return Ok(listaClientes);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Cliente não encontrado");
            }

            return Ok(clienteBuscado);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {

            _clienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int Id, ClienteDomain clienteAtualizado)
        {
            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(Id);

            if (clienteBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Nenhum Cliente encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _clienteRepository.AtualizarIdUrl(Id, clienteAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpDelete("excluir/{Id}")]
        public IActionResult Delete(int Id)
        {
            _clienteRepository.Deletar(Id);

            return NoContent();
        }
    }
}

