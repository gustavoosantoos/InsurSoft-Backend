using System;
using MediatR;

namespace InsurSoft.Backend.Web.Seguros.Application.UseCases.CriarApolice
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
