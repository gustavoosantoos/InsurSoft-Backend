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
                .GreaterThan(0).WithMessage("O código deve ser maior do que 0.");
        }
    }
}
