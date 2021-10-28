using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using autenticacao_jwt.Models;
using autenticacao_jwt.Repositorios;
using autenticacao_jwt.Util;
using Microsoft.IdentityModel.Tokens;

namespace autenticacao_jwt.Services
{
    public class TokenService 
    {
        private CargoRepositorio cargoRepositorio = new CargoRepositorio();

        public string GenerateToken(Funcionario funcionario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Utils.SecrectJwt());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, funcionario.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, funcionario.Matricula),
                    new Claim(ClaimTypes.Name, funcionario.Nome),
                    new Claim(ClaimTypes.Role, cargoRepositorio.ObterPorId(funcionario.IdCargo).Nome)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            StringBuilder tokenResult = new StringBuilder();
            tokenResult.Append("{\n\t AccessToken: ");
            tokenResult.Append(token);
            tokenResult.Append("\n\t Expiration : ");
            tokenResult.Append(DateTime.UtcNow.AddHours(5).ToString("yyyy-MM-dd HH:mm:ss"));
            tokenResult.Append("\n}");

            return tokenResult.ToString();
        }
    }
}