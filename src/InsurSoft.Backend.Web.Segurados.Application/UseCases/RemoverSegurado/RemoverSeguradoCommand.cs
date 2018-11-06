using System;
using MediatR;

namespace InsurSoft.Backend.Web.Segurados.Application.UseCases.RemoverSegurado
{
    public class RemoverSeguradoCommand : IRequest
    {
        public Guid Codigo { get; set; }
    }
}
