﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InsurSoft.Backend.Shared.Application.Interfaces;
using InsurSoft.Backend.Shared.DomainModel.SeguradosAggregate;
using InsurSoft.Backend.Shared.Functional;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using MediatR;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.AdicionarSegurado
{
    public class AdicionarSeguradoCommandHandler : IRequestHandler<AdicionarSeguradoCommand>
    {
        private readonly ISeguradoRepositoryAsync _seguradoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;

        public AdicionarSeguradoCommandHandler(
            ISeguradoRepositoryAsync seguradoRepository,
            IMapper mapper,
            IMediatorHandler mediatorHandler)
        {
            _seguradoRepository = seguradoRepository;
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Unit> Handle(AdicionarSeguradoCommand request, CancellationToken cancellationToken)
        {
            var nomeCompleto = NomeCompleto.Create(request.Nome, request.Sobrenome);
            var dataNascimento = DataNascimento.Create(request.DataNascimento);
            var validationResult = Result.Combine(nomeCompleto, dataNascimento);

            if (validationResult.IsFailure)
            {
                await _mediatorHandler.RaiseDomainEvents(this, validationResult.Errors);
                return Unit.Value;
            }

            var segurado = new Segurado(nomeCompleto.Value, dataNascimento.Value);
            await _seguradoRepository.Adicionar(segurado);
            await _seguradoRepository.Salvar();

            return Unit.Value;
        }
    }
}
