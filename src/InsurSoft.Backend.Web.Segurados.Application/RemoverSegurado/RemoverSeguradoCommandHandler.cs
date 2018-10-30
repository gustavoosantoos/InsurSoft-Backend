using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.RemoverSegurado
{
    public class RemoverSeguradoCommandHandler : IRequestHandler<RemoverSeguradoCommand>
    {
        private readonly InsurSoftContext _context;
        private readonly IMediatorHandler _mediatorHandler;

        public RemoverSeguradoCommandHandler(
            InsurSoftContext context,
            IMediatorHandler mediatorHandler)
        {
            _context = context;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Unit> Handle(RemoverSeguradoCommand request, CancellationToken cancellationToken)
        {
            Maybe<Segurado> segurado = _context.Segurados.Find(request.Codigo);
            if (segurado.HasNoValue)
            {
                await _mediatorHandler.RaiseDomainEvent(this, "Segurado não encontrado com o código informado.");
                return Unit.Value;
            }

            segurado.Value.MarcarComoApagado();

            _context.Entry(segurado.Value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
