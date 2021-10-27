using autenticacao_jwt.Models;
using Microsoft.EntityFrameworkCore;
using autenticacao_jwt.Util;

namespace autenticacao_jwt.Context
{
    public class EmpresaContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("DataSource=./Database/empresa.db;Cache=Shared;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasOne<Cargo>()
                .WithMany()
                .HasForeignKey(p => p.IdCargo);

            modelBuilder.Entity<Cargo>()
                .HasData(
                    new Cargo{
                        Id = 1,
                        Nome = "ADMINISTRADOR"
                    }
                );

            modelBuilder.Entity<Funcionario>()
                .HasData(
                    new Funcionario{
                        Id = 1,
                        Matricula = "0001",
                        Senha = Utils.GerarMd5("adm01"),
                        IdCargo = 1,
                        Nome = "Administrador"
                    }
                );
        }
    }
}