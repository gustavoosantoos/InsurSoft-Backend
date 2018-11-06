using FluentValidation;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.ObterSeguradoDetalhado
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
