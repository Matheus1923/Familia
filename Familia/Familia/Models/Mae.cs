using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Familia.Models
{
    [Table("Mae")]
    public class Mae
    {
        [Key]
        [Column("idmae")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public Int32 IdMae { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O campo deve ser obrigatório")]
        [Column("nome")]

        public string Nome { get; set; }

        [Column("idade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo deve ser obrigatório")]

        public string Idade { get; set; }
    }
}
