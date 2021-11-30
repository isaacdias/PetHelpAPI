using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.InputModel
{
    public class AbrigoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do abrigo deve ser informado")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O endereço deve ser informado")]
        public string Endereco { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O número deve ser informado")]
        public string Numero { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O bairro deve ser informado")]
        public string Bairro { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A cidade deve ser informado")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Estado deve ser informado")]
        public string Estado { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O Telefone deve ser informado")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O AceitaCachorro deve ser informado")]
        public bool AceitaCachorro { get; set; }

        [Required(ErrorMessage = "O AceitaGato deve ser informado")]
        public bool AceitaGato { get; set; }

    }
}
