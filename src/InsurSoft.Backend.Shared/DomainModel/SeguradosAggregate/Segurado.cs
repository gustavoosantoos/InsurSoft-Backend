using System;
using System.Collections.Generic;
using InsurSoft.Backend.Shared.DomainModel.SegurosAggregate;

namespace InsurSoft.Backend.Shared.DomainModel.SeguradosAggregate
{
    public class Segurado
    {
        protected Segurado()
        {
            Apolices = new List<Apolice>();
        }

        public Segurado(NomeCompleto nome, DataNascimento dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Apolices = new List<Apolice>();
            Apagado = false;
        }

        public Guid Codigo { get; private set; }

        public NomeCompleto Nome { get; private set; }
        public DataNascimento DataNascimento { get; private set; }
        public List<Apolice> Apolices { get; private set; }

        public bool Apagado { get; private set; }

        public string NomeCompleto => $"{Nome.Nome} {Nome.Sobrenome}";

        public void MarcarComoApagado()
        {
            Apagado = true;
        }
    }
}
