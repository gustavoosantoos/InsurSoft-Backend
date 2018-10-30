using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados
{
    public class SeguradoPreview
    {
        public SeguradoPreview()
        {

        }

        public SeguradoPreview(int codigo, string nome, string sobrenome, DateTime dataNascimento)
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

        public static SeguradoPreview FromSegurado(Segurado segurado)
        {
            return new SeguradoPreview(
                segurado.Codigo,
                segurado.Nome.Nome,
                segurado.Nome.Sobrenome,
                segurado.DataNascimento.Data
            );
        }

        public static Expression<Func<Segurado, SeguradoPreview>> SelectField()
        {
            return (segurado) => new SeguradoPreview()
            {
                Codigo = segurado.Codigo,
                Nome = segurado.Nome.Nome,
                Sobrenome = segurado.Nome.Sobrenome,
                DataNascimento = segurado.DataNascimento.Data
            };
        }
    }
}
