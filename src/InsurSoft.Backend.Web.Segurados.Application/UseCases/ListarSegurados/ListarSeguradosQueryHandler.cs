using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InsurSoft.Backend.Shared.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using MediatR;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.ListarSegurados
{
    public class ListarSeguradosQueryHandler : IRequestHandler<ListarSeguradosQuery, IEnumerable<SeguradoPreview>>
    {
        private readonly ISeguradoRepositoryAsync _seguradoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ListarSeguradosQueryHandler(
            ISeguradoRepositoryAsync seguradoRepository,
            IMediatorHandler mediatorHandler)
        {
            _seguradoRepository = seguradoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<IEnumerable<SeguradoPreview>> Handle(ListarSeguradosQuery request, CancellationToken cancellationToken)
        {
            return await _seguradoRepository.ObterPreviews();
        }
    }
}
