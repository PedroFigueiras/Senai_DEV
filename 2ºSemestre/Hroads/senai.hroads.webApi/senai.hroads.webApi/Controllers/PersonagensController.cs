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
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.Listar());
        }

        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_personagemRepository.BuscarPorId(idPersonagem));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(short idPersonagem, Personagem PersonagemAtualizado)
        {
            _personagemRepository.Atualizar(idPersonagem, PersonagemAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _personagemRepository.Deletar(idPersonagem);

            return StatusCode(204);
        }
    }
}
