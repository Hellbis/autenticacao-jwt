using autenticacao_jwt.Repositorios;

namespace autenticacao_jwt.Services.FuncionarioServices
{
    public class DeletarFuncionarioService
    {
        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

        public void handle(int id)
        {
            funcionarioRepositorio.Deletar(id);
        }
    }
}