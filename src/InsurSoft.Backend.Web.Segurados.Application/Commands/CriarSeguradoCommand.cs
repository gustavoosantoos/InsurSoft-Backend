using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Web.Segurados.Domain.ValueObjects;
using System;

namespace InsurSoft.Backend.Web.Segurados.Application.Commands
{
    public class CriarSeguradoCommand 
    {
        public NomeCompleto Nome { get; }
        public DataNascimento DataNascimento { get; }

        private CriarSeguradoCommand(NomeCompleto nome, DataNascimento data)
        {
            Nome = nome;
            DataNascimento = data;
        }

        public static Result<CriarSeguradoCommand> Create(string nome, string sobrenome, DateTime dataNascimento)
        {
            var nomeCompleto = NomeCompleto.Create(nome, sobrenome);
            var data = DataNascimento.Create(dataNascimento);

            var result = Result.Combine(nomeCompleto, data);
            
            if (result.IsFailure)
            {
                return Result.Fail<CriarSeguradoCommand>(result.Errors);
            }

            return Result.Ok(new CriarSeguradoCommand(nomeCompleto.Value, data.Value));
        }
    }
}
