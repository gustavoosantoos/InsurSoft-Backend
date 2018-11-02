using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Segurados.Application.ObterSeguradoDetalhado
{
    public class ObterSeguradoDetalhadoQueryHandler : IRequestHandler<ObterSeguradoDetalhadoQuery, SeguradoDetalhado>
    {
        private readonly ISeguradoRepositoryAsync _seguradoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ObterSeguradoDetalhadoQueryHandler(
            ISeguradoRepositoryAsync seguradoRepository,
            IMediatorHandler mediatorHandler)
        {
            _seguradoRepository = seguradoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<SeguradoDetalhado> Handle(ObterSeguradoDetalhadoQuery request, CancellationToken cancellationToken)
        {
            Maybe<SeguradoDetalhado> segurado = await _seguradoRepository.ObterDetalhado(request.Codigo);
            if (segurado.HasNoValue)
            {
                await _mediatorHandler.RaiseAppEvent(this, "Não foi encontrado segurado com o código informado.");
                return null;
            }

            return segurado.Value;
        }
    }
}
