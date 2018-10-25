using AutoMapper;
using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Application.Output.Segurados;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using InsurSoft.Backend.Web.Segurados.Domain.ValueObjects;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;
using System;

namespace InsurSoft.Backend.Web.Segurados.Application.Services
{
    public class SeguradoAppService : ISeguradoAppService
    {
        private readonly ISeguradoRepository _seguradoRepository;
        private readonly IMapper _mapper;

        public SeguradoAppService(
            ISeguradoRepository seguradoRepository,
            IMapper mapper)
        {
            _seguradoRepository = seguradoRepository;
            _mapper = mapper;
        }

        public Result<Maybe<SeguradoOutput>> ObterPorId(CodigoNumerico codigo)
        {
            try
            {
                Segurado segurado = _seguradoRepository.Obter(codigo.Codigo);

                if (segurado == null)
                    return Result.Fail<Maybe<SeguradoOutput>>();

                Maybe<SeguradoOutput> output = _mapper.Map<SeguradoOutput>(segurado);

                return Result.Ok(output);
            }
            catch (Exception ex)
            {
                return Result.Fail<Maybe<SeguradoOutput>>(MensagemFalhaAoObterPorCodigo);
            }
        }

        public Result CriarSegurado(CriarSeguradoInput input)
        {
            if (input == null)
                return Result.Fail(MensagemComandoVazio);

            var commandResult = CriarSeguradoCommand.Create(input);
            if (commandResult.IsFailure)
                return commandResult;

            var command = commandResult.Value;

            _seguradoRepository?.Salvar(new Segurado(command.Nome, command.DataNascimento));

            return Result.Ok();
        }


        private const string MensagemComandoVazio = "O comando para criação de segurados não deve ser vazio.";
        private const string MensagemFalhaAoCriar = "Falha ao salvar segurado.";
        private const string MensagemFalhaAoObterPorCodigo = "Falha ao obter segurado pelo código.";
    }
}
