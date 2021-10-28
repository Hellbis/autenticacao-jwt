using System;
using autenticacao_jwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace autenticacao_jwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
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
                return BadRequest(e);
            }
        }
    }
}