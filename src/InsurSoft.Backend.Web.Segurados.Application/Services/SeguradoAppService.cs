using AutoMapper;
using InsurSoft.Backend.Shared.Application;
using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Application.Output.Segurados;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces.Repositories;
using InsurSoft.Backend.Web.Segurados.Domain.ValueObjects;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.Services
{
    public class SeguradoAppService : AppService, ISeguradoAppService
    {
        private readonly ISeguradoRepository _seguradoRepository;
        
        public SeguradoAppService(
            ISeguradoRepository seguradoRepository,
            IMapper mapper,
            ILogger<SeguradoAppService> logger,
            IMediatorHandler mediatorHandler) : base(logger, mediatorHandler, mapper)
        {
            _seguradoRepository = seguradoRepository;
        }

        public async Task<Maybe<SeguradoOutput>> ObterPorCodigo(CodigoNumerico codigo)
        {
            try
            {
                Segurado segurado = _seguradoRepository.Obter(codigo.Codigo);

                if (segurado == null)
                    return null;

                return Mapper.Map<SeguradoOutput>(segurado);
            }
            catch (Exception ex)
            {
                Logger.LogInformation(ex, ex.Message);
                await MediatorHandler.RaiseAppEvent(this, MensagemFalhaAoObterPorCodigo);

                return null;
            }
        }

        public async Task CriarSegurado(CriarSeguradoInput input)
        {
            if (input == null)
            {
                await MediatorHandler.RaiseDomainEvent(this, MensagemInputVazio);
                return;
            }

            var commandResult = CriarSeguradoCommand.Create(input);
            if (commandResult.IsFailure)
            {
                await MediatorHandler.RaiseDomainEvents(this, commandResult.Errors);
                return;
            }

            var command = commandResult.Value;

            _seguradoRepository.Salvar(new Segurado(command.Nome, command.DataNascimento));
        }
        
        private const string MensagemInputVazio = "O comando para criação de segurados não deve ser vazio.";
        private const string MensagemFalhaAoCriar = "Falha ao salvar segurado.";
        private const string MensagemFalhaAoObterPorCodigo = "Falha ao obter segurado pelo código.";
    }
}
