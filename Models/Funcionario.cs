namespace autenticacao_jwt.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public int IdCargo { get; set; }
    }
}