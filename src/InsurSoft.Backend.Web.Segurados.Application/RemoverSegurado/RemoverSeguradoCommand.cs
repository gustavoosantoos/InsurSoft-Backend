using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Segurados.Application.RemoverSegurado
{
    public class RemoverSeguradoCommand : IRequest
    {
        public int Codigo { get; set; }
    }
}
