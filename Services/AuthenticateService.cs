using System;
using autenticacao_jwt.Models;
using autenticacao_jwt.Repositorios;
using autenticacao_jwt.Util;

namespace autenticacao_jwt.Services
{
    public class AuthenticateService
    {
        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

        public string handle(Funcionario funcionario)
        {
            if(string.IsNullOrEmpty(funcionario.Matricula) || string.IsNullOrEmpty(funcionario.Senha))
                throw new Exception("Matrícula e senha não podem ser nulos!");
            
            var result = funcionarioRepositorio.ObterPorMatricula(funcionario.Matricula);

            if(result == null)
                throw new Exception("Funcionário não encontrado!");
            
            if(result.Senha != Utils.GerarMd5(funcionario.Senha))
                throw new Exception("Usuário e senha inválidos!");
            
            return new TokenService().GenerateToken(result);
        }
    }
}