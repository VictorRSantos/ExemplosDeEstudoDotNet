using Dapper.Contrib.Extensions;

namespace Web.Models
{
    [Table("Usuario")]
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }

    }
}
