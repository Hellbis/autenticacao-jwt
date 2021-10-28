using System.Linq;
using autenticacao_jwt.Context;
using autenticacao_jwt.Models;

namespace autenticacao_jwt.Repositorios
{
    public class CargoRepositorio
    {
        EmpresaContext _db = new EmpresaContext();

        public Cargo ObterPorId(int id)
        {
            return _db.Cargos.FirstOrDefault(s => s.Id == id);
        }
    }
}