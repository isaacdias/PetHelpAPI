using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Exceptions
{
    public class AbrigoJaCadastradoException : Exception
    {
        public AbrigoJaCadastradoException()
      : base("Este abrigo já está cadastrado")
        { }
    }
}
