using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Api.Models.Input.Segurados
{
    public class CriarSeguradoInput
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }    
    }
}
