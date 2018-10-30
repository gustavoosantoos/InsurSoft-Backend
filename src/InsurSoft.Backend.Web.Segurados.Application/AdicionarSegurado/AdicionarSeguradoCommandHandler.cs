using AutoMapper;
using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Segurados.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.AdicionarSegurado
{
    public class AdicionarSeguradoCommandHandler : IRequestHandler<AdicionarSeguradoCommand>
    {
        private readonly InsurSoftContext _context;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;

        public AdicionarSeguradoCommandHandler(
            InsurSoftContext context,
            IMapper mapper,
            IMediatorHandler mediatorHandler)
        {
            _context = context;
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

            _context.Segurados.Add(segurado);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
