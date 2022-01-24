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
    public class TipohabilidadeController : ControllerBase
    {
        private ITipohabilidadeRepository _tipohRepository { get; set; }

        public TipohabilidadeController()
        {
            _tipohRepository = new TipohabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipohRepository.Listar());
        }

        [HttpGet("{idTipohabilidade}")]
        public IActionResult BuscarPorId(int idTipohabilidade)
        {
            return Ok(_tipohRepository.BuscarPorId(idTipohabilidade));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Tipohabilidade novoTipohabilidade)
        {
            _tipohRepository.Cadastrar(novoTipohabilidade);

            return StatusCode(201);
        }
        [Authorize(Roles = "2")]
        [HttpPut("{idTipohabilidade}")]
        public IActionResult Atualizar(short idTipohabilidade, Tipohabilidade TipohabilidadeAtualizado)
        {
            _tipohRepository.Atualizar(idTipohabilidade, TipohabilidadeAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{idTipohabilidade}")]
        public IActionResult Deletar(int idTipohabilidade)
        {
            _tipohRepository.Deletar(idTipohabilidade);

            return StatusCode(204);
        }
    }
}
