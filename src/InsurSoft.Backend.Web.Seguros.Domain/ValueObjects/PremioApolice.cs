using InsurSoft.Backend.Shared.Funcional;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Seguros.Domain.ValueObjects
{
    public class PremioApolice : ValueObject
    {
        public decimal Valor { get; private set; }

        private PremioApolice(decimal valor)
        {
            Valor = valor;
        }

        public static Result<PremioApolice> Create(Maybe<decimal> valorOrNothing)
        {
            return valorOrNothing
                .ToResult("O prêmio não pode ser vazio.")
                .Ensure(valor => valor > 0, "O prêmio deve ser maior do que zero.")
                .Map(valor => new PremioApolice(valor));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }
    }
}
