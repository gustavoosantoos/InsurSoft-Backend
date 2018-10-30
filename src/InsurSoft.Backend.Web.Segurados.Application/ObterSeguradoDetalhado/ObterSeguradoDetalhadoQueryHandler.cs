using InsurSoft.Backend.Infra.Repository.PostgreSQL.Context;
using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.ObterSeguradoDetalhado
{
    public class ObterSeguradoDetalhadoQueryHandler : IRequestHandler<ObterSeguradoDetalhadoQuery, SeguradoDetalhadoViewModel>
    {
        private readonly InsurSoftContext _context;
        private readonly IMediatorHandler _mediatorHandler;

        public ObterSeguradoDetalhadoQueryHandler(
            InsurSoftContext context,
            IMediatorHandler mediatorHandler)
        {
            _context = context;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<SeguradoDetalhadoViewModel> Handle(ObterSeguradoDetalhadoQuery request, CancellationToken cancellationToken)
        {
            Maybe<Segurado> segurado = _context.Segurados.Find(request.Codigo);
            if (segurado.HasNoValue)
            {
                await _mediatorHandler.RaiseAppEvent(this, "Não foi encontrado segurado com o código informado.");
                return null;
            }

            return SeguradoDetalhadoViewModel.FromSegurado(segurado.Value);
        }
    }
}
