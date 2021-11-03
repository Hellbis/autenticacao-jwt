using System;
using System.Net;
using autenticacao_jwt.Models;
using autenticacao_jwt.Services;
using autenticacao_jwt.Services.FuncionarioServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace autenticacao_jwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        [HttpGet("obter")]
        [Authorize]
        public IActionResult ObterPorMatricula([FromQuery] string matricula)
        {
            try
            {
                return Ok(new ObterPorMatriculaFuncionarioService().handle(matricula));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(new ListarFuncionariosService().handle());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Inserir(Funcionario funcionario)
        {
            try
            {
                new InserirFuncionarioService().handle(funcionario);
                return StatusCode(201, "Usuário criado com sucesso!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Alterar(Funcionario funcionario)
        {
            try
            {
                new AlterarFuncionarioService().handle(funcionario);
                return StatusCode(200, "Usuário alterado com sucesso!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Deletar(int id)
        {
            try
            {
                new DeletarFuncionarioService().handle(id);
                return StatusCode(200, "Usuário deletado com sucesso!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}