using InsurSoft.Backend.Shared.Funcional;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Seguros.Domain.ValueObjects
{
    public class PeriodoVigencia : ValueObject
    {
        public DateTime Inicio { get; private set; }
        public DateTime Final { get; private set; }

        protected PeriodoVigencia(DateTime inicio, DateTime final)
        {
            Inicio = inicio;
            Final = final;
        }

        public static Result<PeriodoVigencia> Create(Maybe<DateTime> inicioOrNothing, Maybe<DateTime> finalOrNothing)
        {
            var validacaoInicio = inicioOrNothing
                .ToResult("O início da vigência não deve ser vazio.")
                .Ensure(data => data != default(DateTime), "O início da vigência não deve ser vazio.");

            var validacaoFinal = finalOrNothing
                .ToResult("O final da vigência não deve ser vazio.")
                .Ensure(data => data != default(DateTime), "O final da vigência não deve ser vazia.")
                .Ensure(data => inicioOrNothing.HasValue && data > inicioOrNothing.Value, "O final da vigência deve ser após o início da vigência.");

            var result = Result.Combine(validacaoInicio, validacaoFinal);
            if (result.IsFailure)
                return Result.Fail<PeriodoVigencia>(result.Errors);

            return Result.Ok(new PeriodoVigencia(inicioOrNothing.Value, finalOrNothing.Value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Inicio;
            yield return Final;
        }
    }
}
