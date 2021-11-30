using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Exceptions
{
    public class AbrigoNaoCadastradoException : Exception
    {
        public AbrigoNaoCadastradoException()
      : base("Este abrigo não está cadastrado")
        { }
    }
}
