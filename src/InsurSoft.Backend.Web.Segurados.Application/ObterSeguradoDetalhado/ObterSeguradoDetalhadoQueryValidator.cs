using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.ObterSeguradoDetalhado
{
    public class ObterSeguradoDetalhadoQueryValidator : AbstractValidator<ObterSeguradoDetalhadoQuery>
    {
        public ObterSeguradoDetalhadoQueryValidator()
        {
            RuleFor(query => query.Codigo)
                .NotEmpty().WithMessage("O código não deve ser vazio.");
        }
    }
}
