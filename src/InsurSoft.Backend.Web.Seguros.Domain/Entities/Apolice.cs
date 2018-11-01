using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Seguros.Domain.ValueObjects;
using System;

namespace InsurSoft.Backend.Web.Seguros.Domain.Entities
{
    public class Apolice
    {
        public int Codigo { get; private set; }
        public Guid CodigoSeguro { get; private set; }

        public NumeroApolice NumeroApolice { get; private set; }
        public PeriodoVigencia Vigencia { get; private set; }
        public PremioApolice PremioTotal { get; private set; }
        public PremioApolice PremioLiquido { get; private set; }

        public NumeroApolice NumeroApoliceAnterior { get; private set; }

        public Segurado Segurado { get; private set; }
        public Proposta Proposta { get; private set; }
        
        public bool Apagado { get; private set; }

        public bool EstaVigente() => DateTime.Today > Vigencia.Inicio && DateTime.Today < Vigencia.Final;
    }
}
