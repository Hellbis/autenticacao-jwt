using System.Linq;
using autenticacao_jwt.Context;
using autenticacao_jwt.Models;

namespace autenticacao_jwt.Repositorios
{
    public class FuncionarioRepositorio
    {
        EmpresaContext _db = new EmpresaContext();

        public Funcionario ObterPorMatricula(string matricula)
        {
            var obj =_db.Funcionarios.FirstOrDefault(s => s.Matricula == matricula);
            
            return obj;
        }

    }
}