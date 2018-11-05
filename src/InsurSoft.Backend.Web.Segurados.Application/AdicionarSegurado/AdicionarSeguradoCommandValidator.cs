using FluentValidation;
using InsurSoft.Backend.Shared.Domain.Entities.Segurados;
using System;

namespace InsurSoft.Backend.Web.Segurados.Application.AdicionarSegurado
{
    public class AdicionarSeguradoCommandValidator : AbstractValidator<AdicionarSeguradoCommand>
    {
        public AdicionarSeguradoCommandValidator()
        {
            RuleFor(command => command.Nome)
                .NotEmpty().WithMessage("O nome não deve ser vazio.")
                .MinimumLength(3).WithMessage("O nome deve ter ao menos 3 caracteres.")
                .MaximumLength(25).WithMessage("O nome deve ter no máximo 25 caracteres.");

            RuleFor(command => command.Sobrenome)
               .NotEmpty().WithMessage("O sobrenome não deve ser vazio.")
               .MinimumLength(3).WithMessage("O sobrenome deve ter ao menos 3 caracteres.")
               .MaximumLength(50).WithMessage("O sobrenome deve ter no máximo 50 caracteres.");

            RuleFor(command => command.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento não deve ser vazia.")
                .LessThan(DateTime.Today).WithMessage("A data de nascimento deve estar no passado.")
                .GreaterThan(DataNascimento.DataMinimaNascimento).WithMessage($"A data de nascimento deve ser após {DataNascimento.DataMinimaNascimento.ToString("d")}");
        }
    }
}
