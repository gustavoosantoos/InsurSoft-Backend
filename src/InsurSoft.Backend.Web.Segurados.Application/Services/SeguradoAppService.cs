﻿using AutoMapper;
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

        public async Task<Maybe<SeguradoOutput>> ObterPorCodigo(int codigo)
        {
            try
            {
                var codigoNumerico = CodigoNumerico.Create(codigo);
                if (codigoNumerico.IsFailure)
                {
                    await MediatorHandler.RaiseDomainEvents(this, codigoNumerico.Errors);
                    return null;
                }

                Maybe<Segurado> segurado = _seguradoRepository.Obter(codigoNumerico.Value);
                Maybe<SeguradoOutput> output = segurado.HasValue ? Mapper.Map<SeguradoOutput>(segurado.Value) : null;

                return output;
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

            var command = CriarSeguradoCommand.Create(input);
            if (command.IsFailure)
            {
                await MediatorHandler.RaiseDomainEvents(this, command.Errors);
                return;
            }
            
            _seguradoRepository.Salvar(new Segurado(command.Value.Nome, command.Value.DataNascimento));
        }
        
        private const string MensagemInputVazio = "O comando para criação de segurados não deve ser vazio.";
        private const string MensagemFalhaAoCriar = "Falha ao salvar segurado.";
        private const string MensagemFalhaAoObterPorCodigo = "Falha ao obter segurado pelo código.";
    }
}
