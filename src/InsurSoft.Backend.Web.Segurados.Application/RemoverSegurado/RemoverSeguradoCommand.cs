using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.RemoverSegurado
{
    public class RemoverSeguradoCommand : IRequest
    {
        public Guid Codigo { get; set; }
    }
}
