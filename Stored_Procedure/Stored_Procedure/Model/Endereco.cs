using System.ComponentModel.DataAnnotations;

namespace Stored_Procedure.Model
{
    public class Endereco : Entity
    {
        [StringLength(50)]
        public string Logradouro { get; set; }

        [StringLength(8)]
        public string Cep { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        [StringLength(6)]
        public int Numero { get; set; }

        [StringLength(50)]
        public string Municipio { get; set; }
    }
}
