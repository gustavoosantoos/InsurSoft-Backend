using FluentValidation.Results;
using InsurSoft.Backend.Shared.Events;
using System;

namespace InsurSoft.Backend.Shared.Domain.Commands
{
    public abstract class DomainCommand : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected DomainCommand()
        {
            Timestamp = DateTime.Now;
        }
        public abstract bool IsValid();
    }
}