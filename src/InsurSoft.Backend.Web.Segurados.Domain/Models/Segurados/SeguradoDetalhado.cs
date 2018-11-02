using InsurSoft.Backend.Shared.Domain.Entities;
using System;

namespace InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados
{
    public class SeguradoDetalhado
    {
        public SeguradoDetalhado(Guid codigo, string nome, string sobrenome, DateTime dataNascimento)
        {
            Codigo = codigo;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public Guid Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public static SeguradoDetalhado FromSegurado(Segurado segurado)
        {
            return new SeguradoDetalhado(
                segurado.Codigo,
                segurado.Nome.Nome,
                segurado.Nome.Sobrenome,
                segurado.DataNascimento.Data);
        }
    }
}
