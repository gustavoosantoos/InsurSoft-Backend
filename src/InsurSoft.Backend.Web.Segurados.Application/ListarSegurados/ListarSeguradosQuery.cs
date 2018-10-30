using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.ListarSegurados
{
    public class ListarSeguradosQuery : IRequest<List<SeguradoPreviewViewModel>>
    {

    }
}
