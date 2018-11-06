using System.Collections.Generic;
using InsurSoft.Backend.Web.Segurados.Domain.Models.Segurados;
using MediatR;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.ListarSegurados
{
    public class ListarSeguradosQuery : IRequest<IEnumerable<SeguradoPreview>>
    {

    }
}
