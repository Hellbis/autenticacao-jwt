using System;
using Microsoft.AspNetCore.Mvc;
using autenticacao_jwt.Models;
using autenticacao_jwt.Services;

namespace AUTENTICACAO_JWT.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Funcionario funcionario)
        {
            try
            {
                return Ok(new AuthenticateService().handle(funcionario));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
