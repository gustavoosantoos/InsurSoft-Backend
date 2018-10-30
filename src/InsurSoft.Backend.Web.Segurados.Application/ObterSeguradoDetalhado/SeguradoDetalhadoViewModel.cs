using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.ObterSeguradoDetalhado
{
    public class SeguradoDetalhadoViewModel 
    {
        public SeguradoDetalhadoViewModel(int codigo, string nome, string sobrenome, DateTime dataNascimento)
        {
            Codigo = codigo;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public static SeguradoDetalhadoViewModel FromSegurado(Segurado segurado)
        {
            return new SeguradoDetalhadoViewModel(
                segurado.Codigo,
                segurado.Nome.Nome,
                segurado.Nome.Sobrenome,
                segurado.DataNascimento.Data);
        }
    }
}
