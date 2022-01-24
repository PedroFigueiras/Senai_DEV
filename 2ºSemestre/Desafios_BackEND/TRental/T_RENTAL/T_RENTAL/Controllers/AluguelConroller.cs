using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using T_RENTAL.Interfaces;
using T_RENTAL.Repositories;

namespace T_RENTAL.Controllers

{


    [Route("api/[controller]")]

    [Produces("application/json")]


    [ApiController]
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _aluguelRepository { get; set; }

        public AluguelController()
        {
            _aluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _aluguelRepository.ListarTodos();

            return Ok(listaAlugueis);

        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            AluguelDomain BuscarAluguel = _aluguelRepository.BuscarPorId(Id);

            if (BuscarAluguel == null)
            {
                return NotFound(" aluguel não encontrado");
            }

            return Ok(BuscarAluguel);
        }
        [HttpPut("{Id}")]
        

        [HttpDelete("Deletar/{Id}")]
        public IActionResult Delete(int Id)
        {
            _aluguelRepository.Deletar(Id);

            return NoContent();
        }

        [HttpPost]
        public IActionResult PutIdUrl(int Id, AluguelDomain AluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorId(Id);

            if (aluguelBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Aluguel não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _aluguelRepository.AtualizarIdUrl(Id, AluguelAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}