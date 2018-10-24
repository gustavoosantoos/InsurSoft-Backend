using InsurSoft.Backend.Web.Segurados.Domain.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Domain.Entities
{
    public class Segurado
    {
        public Guid Id { get; private set; }
        public NomeCompleto Nome { get; private set; }
    }
}
