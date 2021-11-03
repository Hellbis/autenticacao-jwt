using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using autenticacao_jwt.Context;
using autenticacao_jwt.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Funcionario> Listar()
        {
            return _db.Funcionarios.ToList();
        }

        public void Inserir(Funcionario funcionario)
        {
            _db.Funcionarios.Add(funcionario);
            _db.SaveChanges();
        }

        public void Alterar(Funcionario funcionario)
        {
            var funcionarioAtual = _db.Funcionarios.FirstOrDefault(s => s.Id == funcionario.Id);
            
            funcionarioAtual.Matricula = funcionario.Matricula;
            funcionarioAtual.Nome = funcionario.Nome;
            funcionarioAtual.Senha = funcionario.Senha;
            funcionarioAtual.IdCargo = funcionario.IdCargo;

            _db.Funcionarios.Update(funcionarioAtual);
            _db.SaveChanges();
        }

        public void Deletar(int id)
        {
            var funcionario = _db.Funcionarios.FirstOrDefault(s => s.Id == id);
            _db.Remove(funcionario);
            _db.SaveChanges();
        }
    }
}