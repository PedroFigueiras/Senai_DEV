using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadesRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadesRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_habilidadesRepository.Listar());
        }

        [HttpGet("{idHabilidade}")]
        public IActionResult BuscarPorId(int idHabilidade)
        {
            return Ok(_habilidadesRepository.BuscarPorId(idHabilidade));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar( Habilidade novaHabilidade)
        {
            _habilidadesRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "2")]
        [HttpPut("{IdHabilidade}")]
        public IActionResult Atualizar(short IdHabilidade, Habilidade HabilidadeAtualizada)
        {
            _habilidadesRepository.Atualizar(IdHabilidade, HabilidadeAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{idHabilidade}")]
        public IActionResult Deletar(int idHabilidade)
        {
            _habilidadesRepository.Deletar(idHabilidade);

            return StatusCode(204);
        }
    }
}
