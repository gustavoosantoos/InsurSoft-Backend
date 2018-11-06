using System;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using MediatR;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.ObterSeguradoDetalhado
{
    public class ObterSeguradoDetalhadoQuery : IRequest<SeguradoDetalhado>
    {
        public Guid Codigo { get; set; }
    }
}
