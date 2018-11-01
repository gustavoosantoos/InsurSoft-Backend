using InsurSoft.Backend.Shared.Domain.Commands;
using InsurSoft.Backend.Shared.Events;
using System;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Shared.Interfaces.Domain
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : DomainCommand;
        Task RaiseEvent<T>(T @event) where T : Event;
        Task RaiseDomainEvent(string key, string value);
        Task RaiseAppEvent(string key, string value);
        Task RaiseDomainEvent(Type type, string value);
        Task RaiseAppEvent(Type type, string value);
        Task RaiseDomainEvents(Type type, string[] values);

        Task RaiseAppEvent(object caller, string value);
        Task RaiseDomainEvent(object caller, string value);

        Task RaiseAppEvents(object caller, string[] values);
        Task RaiseDomainEvents(object caller, string[] values);
    }
}
