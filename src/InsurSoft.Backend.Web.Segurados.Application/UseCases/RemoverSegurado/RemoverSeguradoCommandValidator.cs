using FluentValidation;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.RemoverSegurado
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
