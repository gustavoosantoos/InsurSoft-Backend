using MediatR;
using System;

namespace InsurSoft.Backend.Web.Seguros.Application.CriarApolice
{
    public class CriarApoliceCommand : IRequest
    {
        public string Apolice { get; set; }
        public decimal PremioTotal { get; set; }
        public decimal PremioLiquido { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinalVigencia { get; set; }
        public Guid CodigoSegurado { get; set; }
    }
}
