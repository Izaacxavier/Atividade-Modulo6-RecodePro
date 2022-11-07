
namespace apivoemais.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}