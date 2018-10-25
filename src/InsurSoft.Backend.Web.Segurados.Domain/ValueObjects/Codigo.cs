using InsurSoft.Backend.Shared.Funcional;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Domain.ValueObjects
{
    public class CodigoNumerico : ValueObject
    {
        public int Codigo { get; private set; }

        private CodigoNumerico(int codigo)
        {
            Codigo = codigo;
        }

        public static Result<CodigoNumerico> Create(Maybe<int?> codigoOrNothing)
        {
            return codigoOrNothing
                .ToResult("O código não deve ser vazio.")
                .Ensure(codigo => codigo.HasValue, "O código não deve ser vazio.")
                .Ensure(codigo => codigo > 0, "O código deve ser maior do que zero.")
                .Map(codigo => new CodigoNumerico(codigo.Value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Codigo;
        }
    }
}
