using InsurSoft.Backend.Shared.Domain.Entities.Seguros;
using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Web.Segurados.Domain.Interfaces;
using InsurSoft.Backend.Web.Seguros.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Seguros.Application.CriarApolice
{
    public class CriarApoliceCommandHandler : IRequestHandler<CriarApoliceCommand>
    {
        private readonly ISeguradoRepositoryAsync _seguradoRepository;
        private readonly IApoliceRepositoryAsync _apoliceRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public CriarApoliceCommandHandler(
            ISeguradoRepositoryAsync seguradoRepository,
            IApoliceRepositoryAsync apoliceRepository,
            IMediatorHandler mediatorHandler)
        {
            _seguradoRepository = seguradoRepository;
            _apoliceRepository = apoliceRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Unit> Handle(CriarApoliceCommand request, CancellationToken cancellationToken)
        {
            var segurado = await _seguradoRepository.Obter(request.CodigoSegurado);
            if (segurado == null)
            {
                await _mediatorHandler.RaiseAppEvent(this, "Não foi encontrado o segurado com o código informado.");
                return Unit.Value;
            }

            var numeroApolice = NumeroApolice.Create(request.Apolice);
            var vigencia = PeriodoVigencia.Create(request.InicioVigencia, request.FinalVigencia);
            var premioTotal = PremioApolice.Create(request.PremioTotal);
            var premioLiquido = PremioApolice.Create(request.PremioLiquido);

            var result = Result.Combine(numeroApolice, vigencia, premioLiquido, premioTotal);

            if (result.IsFailure)
            {
                await _mediatorHandler.RaiseAppEvents(this, result.Errors);
                return Unit.Value;
            }

            var apolice = new Apolice(
                numeroApolice.Value,
                vigencia.Value,
                premioTotal.Value,
                premioLiquido.Value,
                segurado.Codigo
            );

            await _apoliceRepository.Adicionar(apolice);
            await _apoliceRepository.Salvar();

            return Unit.Value;
        }
    }
}
