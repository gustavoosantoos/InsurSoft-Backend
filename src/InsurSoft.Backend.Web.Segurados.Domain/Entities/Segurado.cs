using InsurSoft.Backend.Web.Segurados.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Domain.Entities
{
    public class Segurado
    {
        public CodigoNumerico Id { get; private set; }
        public NomeCompleto Nome { get; private set; }
        public DataNascimento DataNascimento { get; private set; }

        protected Segurado()
        {
        }

        public Segurado(NomeCompleto nome, DataNascimento dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
