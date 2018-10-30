using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.ObterSeguradoDetalhado
{
    public class ObterSeguradoDetalhadoQuery : IRequest<SeguradoDetalhadoViewModel>
    {
        public int Codigo { get; private set; }
    }
}
