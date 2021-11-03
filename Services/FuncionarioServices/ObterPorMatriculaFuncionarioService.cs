using autenticacao_jwt.Models;
using autenticacao_jwt.Repositorios;

namespace autenticacao_jwt.Services.FuncionarioServices
{
    public class ObterPorMatriculaFuncionarioService
    {
        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

        public Funcionario handle(string matricula)
        {
            return funcionarioRepositorio.ObterPorMatricula(matricula);
        }
    }
}