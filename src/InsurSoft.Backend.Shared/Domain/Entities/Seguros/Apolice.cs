using System;

namespace InsurSoft.Backend.Shared.Domain.Entities.Seguros
{
    public class Apolice
    {
        protected Apolice()
        {

        }

        public Apolice(
            NumeroApolice numeroApolice, 
            PeriodoVigencia vigencia, 
            PremioApolice premioTotal, 
            PremioApolice premioLiquido,
            Guid codigoSegurado)
        {
            NumeroApolice = numeroApolice;
            Vigencia = vigencia;
            PremioTotal = premioTotal;
            PremioLiquido = premioLiquido;
            CodigoSegurado = codigoSegurado;
        }

        public Guid Codigo { get; private set; }
        
        public NumeroApolice NumeroApolice { get; private set; }
        public PeriodoVigencia Vigencia { get; private set; }
        public PremioApolice PremioTotal { get; private set; }
        public PremioApolice PremioLiquido { get; private set; }

        public Guid CodigoSegurado { get; private set; }
        public Segurado Segurado { get; private set; }
        
        public bool Apagado { get; private set; }

        public bool EstaVigente => DateTime.Today >= Vigencia.Inicio && DateTime.Today <= Vigencia.Final;
        
        public void MarcarComoApagado()
        {
            Apagado = true;
        }
    }
}
