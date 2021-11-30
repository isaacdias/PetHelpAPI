using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.ViewModel
{
    public class AbrigoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string  Cidade { get; set; }
        public string Estado { get; set; }  
        public string Telefone { get; set; }    
        public bool AceitaCachorro { get; set; }
        public bool AceitaGato { get; set; }
    }
}
