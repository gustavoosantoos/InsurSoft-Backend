using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using InsurSoft.Backend.Web.Seguros.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Web.Seguros.Domain.Entities
{
    public class Seguro
    {
        public int Codigo { get; private set; }
        public Segurado Segurado { get; private set; }
        public PeriodoVigencia Vigencia { get; private set; }
        public bool Apagado { get; private set; }


        public bool IsVigente() => DateTime.Today > Vigencia.Inicio && DateTime.Today < Vigencia.Final;
    }
}
