using InsurSoft.Backend.Web.Segurados.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Domain.Entities
{
    public class Segurado
    {
        public int Codigo { get; private set; }

        public NomeCompleto Nome { get; private set; }
        public DataNascimento DataNascimento { get; private set; }

        public bool Ativo { get; private set; } 
        public bool Apagado { get; private set; }

        protected Segurado()
        {
        }

        public Segurado(int codigo, NomeCompleto nome, DataNascimento dataNascimento)
        {
            Codigo = codigo;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public Segurado(NomeCompleto nome, DataNascimento dataNascimento)
        { 
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void MarcarComoApagado()
        {
            Apagado = true;
            Inativar();
        }
    }
}
