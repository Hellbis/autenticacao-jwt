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
                var token = new AuthenticateService().handle(funcionario);
                return Ok(token);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
