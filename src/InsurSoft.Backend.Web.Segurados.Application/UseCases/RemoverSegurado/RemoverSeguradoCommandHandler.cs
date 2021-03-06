﻿using System.Threading;
using System.Threading.Tasks;
using InsurSoft.Backend.Shared.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using MediatR;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.RemoverSegurado
{
    public class RemoverSeguradoCommandHandler : IRequestHandler<RemoverSeguradoCommand>
    {
        private readonly ISeguradoRepositoryAsync _seguradoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public RemoverSeguradoCommandHandler(
            ISeguradoRepositoryAsync seguradoRepository,
            IMediatorHandler mediatorHandler)
        {
            _seguradoRepository = seguradoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Unit> Handle(RemoverSeguradoCommand request, CancellationToken cancellationToken)
        {
            await _seguradoRepository.Remover(request.Codigo);
            await _seguradoRepository.Salvar();

            return Unit.Value;
        }
    }
}
