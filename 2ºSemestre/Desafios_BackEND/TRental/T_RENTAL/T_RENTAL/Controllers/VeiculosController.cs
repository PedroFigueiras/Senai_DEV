using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_RENTAL.Interfaces;
using T_RENTAL.Repositories;
using static T_RENTAL.Repositories.VeiculoRepository;

namespace T_RENTAL.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepositoy _veiculoRepository { get; set; }

        public VeiculosController()
        {
            _veiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaveiculos = _veiculoRepository.ListarTodos();

            return Ok(listaveiculos);

        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(Id);

            if (veiculoBuscado == null)
            {
                return NotFound("Veiculo não encontrado");
            }

            return Ok(veiculoBuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {

            _veiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpPut("{Id}")]
        public IActionResult PutIdUrl(int Id, VeiculoDomain VeiculoAtualizado)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(Id);

            if (veiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Veiculo não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _veiculoRepository.AtualizarIdUrl(Id, VeiculoAtualizado);

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
            _veiculoRepository.Deletar(Id);

            return NoContent();
        }
    }
}
