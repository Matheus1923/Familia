using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Familia.Models
{
    [Table("Filho")]
    public class Filho
    {
        [Key]
        [Column("idfilho")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public Int32 IdFilho { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O campo deve ser obrigatório")]
        [Column("nome")]

        public string Nome { get; set; }

        [Column("idade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo deve ser obrigatório")]

        public string Idade { get; set; }

        [Column("idpai")]
        [Required (ErrorMessage = "O campo é obrigatório")]

        public int IdPai { get; set; }

        [Column("idmae")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public int IdMae { get; set; }
    }
}
