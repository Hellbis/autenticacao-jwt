using System;
using autenticacao_jwt.Models;
using autenticacao_jwt.Repositorios;
using autenticacao_jwt.Util;

namespace autenticacao_jwt.Services.FuncionarioServices
{
    public class AlterarFuncionarioService
    {
        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
        
        public void handle(Funcionario funcionario)
        {
            if(string.IsNullOrEmpty(funcionario.Matricula) || string.IsNullOrEmpty(funcionario.Senha) || string.IsNullOrEmpty(funcionario.Nome))
                throw new Exception("Preencha todos os dados!");
            
            var result = funcionarioRepositorio.ObterPorMatricula(funcionario.Matricula);

            if(result?.Id != funcionario.Id)
                throw new Exception("Matrícula já cadastrada!");
            
            if(funcionario.IdCargo == 0)
                throw new Exception("Selecione um cargo para o funcionario!");
            
            if(!funcionario.Senha.Equals(result.Senha))
                funcionario.Senha = Utils.GerarMd5(funcionario.Senha);

            funcionarioRepositorio.Alterar(funcionario);
        }
    }
}