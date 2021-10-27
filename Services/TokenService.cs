using System;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using System.Text;
using autenticacao_jwt.Models;
using Microsoft.Extensions.Configuration;

namespace autenticacao_jwt.Services
{
    public class TokenService 
    {
        public IConfigurationRoot Configuration { get; }

        public string GenerateToken(Funcionario funcionario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //var key = Encoding.ASCII.GetBytes(Configuration.GetConnectionString("Secrect"));
            
            if(Configuration == null) {
                return "TA NULL";
            }
            return new string("TESTE" + Configuration.GetConnectionString("Secrect"));
        }
    }
}