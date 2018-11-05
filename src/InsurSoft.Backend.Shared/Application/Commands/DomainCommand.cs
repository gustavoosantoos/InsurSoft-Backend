using System;
using FluentValidation.Results;
using InsurSoft.Backend.Shared.Application.Events;

namespace InsurSoft.Backend.Shared.Application.Commands
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