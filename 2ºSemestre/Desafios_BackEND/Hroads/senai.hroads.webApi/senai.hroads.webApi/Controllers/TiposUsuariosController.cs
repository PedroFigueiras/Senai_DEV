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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipousuarioRepository _tipousuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tipousuarioRepository = new TipousuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipousuarioRepository.Listar());
        }

        [HttpGet("{idTipousuario}")]
        public IActionResult BuscarPorId(int idTipousuario)
        {
            return Ok(_tipousuarioRepository.BuscarPorId(idTipousuario));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar( Tipousario novoTipousuario)
        {
            _tipousuarioRepository.Cadastrar(novoTipousuario);

            return StatusCode(201);
        }

        [Authorize(Roles = "2")]
        [HttpPut("{idTipousuario}")]
        public IActionResult Atualizar(short idTipousuario, Tipousario TipousuarioAtualizado)
        {
            _tipousuarioRepository.Atualizar(idTipousuario, TipousuarioAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{idTipousuario}")]
        public IActionResult Deletar(int idTipousuario)
        {
            _tipousuarioRepository.Deletar(idTipousuario);

            return StatusCode(204);
        }
    }
}
