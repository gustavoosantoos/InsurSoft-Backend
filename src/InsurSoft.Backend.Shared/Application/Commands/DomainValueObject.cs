using System;
using FluentValidation.Results;

namespace InsurSoft.Backend.Shared.Application.Commands
{
    public abstract class DomainValueObject 
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected DomainValueObject ()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new Exception("IsValid não implementado");
        }
    }
}