using InsurSoft.Backend.Shared.Funcional;
using System.Collections.Generic;

namespace InsurSoft.Backend.Web.Segurados.Domain.ValueObjects
{
    public class NomeCompleto : ValueObject
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        protected NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public static Result<NomeCompleto> Create(Maybe<string> nome, Maybe<string> sobrenome)
        {
            var resultNome = nome
                .ToResult("O nome não deve ser vazio")
                .Ensure(n => n.Length >= 3, "O nome deve ter ao menos 3 caracteres")
                .Ensure(n => n.Length <= 25, "O nome deve ter no máximo 20 caracteres");

            var resultSobrenome = sobrenome
                .ToResult("O sobrenome não deve ser vazio")
                .Ensure(n => n.Length >= 3, "O sobrenome deve ter ao menos 3 caracteres")
                .Ensure(n => n.Length <= 50, "O sobrenome deve ter no máximo 50 caracteres");

            var result = Result.Combine(resultNome, resultSobrenome);

            if (result.IsFailure)
                return Result.Fail<NomeCompleto>(result.Errors);

            return Result.Ok(new NomeCompleto(nome.Value, sobrenome.Value));
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nome;
            yield return Sobrenome;
        }
    }
}
