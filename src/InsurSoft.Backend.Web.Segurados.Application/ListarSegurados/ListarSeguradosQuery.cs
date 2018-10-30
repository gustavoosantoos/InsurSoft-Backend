using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.ListarSegurados
{
    public class ListarSeguradosQuery : IRequest<IEnumerable<SeguradoPreview>>
    {

    }
}
