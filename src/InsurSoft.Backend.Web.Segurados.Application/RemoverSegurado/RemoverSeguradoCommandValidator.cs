using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.RemoverSegurado
{
    public class RemoverSeguradoCommandValidator : AbstractValidator<RemoverSeguradoCommand>
    {
        public RemoverSeguradoCommandValidator()
        {
            RuleFor(command => command.Codigo)
                .NotEmpty().WithMessage("O código não deve ser vazio");
        }
    }
}
