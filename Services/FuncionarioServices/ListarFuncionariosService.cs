using System.Collections.Generic;
using autenticacao_jwt.Models;
using autenticacao_jwt.Repositorios;

namespace autenticacao_jwt.Services
{
    public class ListarFuncionariosService
    {
        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();
        public List<Funcionario> handle()
        {
            return funcionarioRepositorio.Listar();
        }
    }
}