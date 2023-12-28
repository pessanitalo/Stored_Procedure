using System.ComponentModel.DataAnnotations;

namespace Stored_Procedure.Model
{
    public class Pessoa : Entity
    {
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(11)]
        public string Cpf { get; set; }

        [StringLength(8)]
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
    }
}
