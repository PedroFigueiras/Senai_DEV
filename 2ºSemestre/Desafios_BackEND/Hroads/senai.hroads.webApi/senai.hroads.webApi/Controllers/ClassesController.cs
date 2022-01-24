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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.Listar());
        }

        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            return Ok(_classeRepository.BuscarPorId(idClasse));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novoClasse)
        {
            _classeRepository.Cadastrar(novoClasse);

            return StatusCode(201);
        }

        [Authorize(Roles = "2")]
        [HttpPut("{idClasse}")]
        public IActionResult Atualizar(short idClasse, Classe ClasseAtualizada)
        {
            _classeRepository.Atualizar(idClasse, ClasseAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{idClasse}")]
        public IActionResult Deletar(int idClasse)
        {
            _classeRepository.Deletar(idClasse);

            return StatusCode(204);
        }

    }
}
